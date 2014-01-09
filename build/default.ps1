properties { 
  $baseDir  = Resolve-Path ..
  $buildDir = "$baseDir\build"
  $sourceDir = "$baseDir\src"
  $toolsDir = "$baseDir\tools"
  $binDir = "$baseDir\bin"
  
  $version = "3.2.2"
  
  $tempDir = "$binDir\temp"
  $binariesDir = "$binDir\binaries"
  $zipDir = "$binDir\zip"
  $nupkgDir = "$binDir\nupkg"
  
  $nuget = "$toolsDir\nuget\nuget.exe"
  $7zip = "$toolsDir\7zip\7za.exe"
  $vstest = "${Env:ProgramFiles(x86)}\Microsoft Visual Studio 11.0\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe"
  
  $projects = @(
    @{Name = "Cimbalino.Phone.Toolkit"},
    @{Name = "Cimbalino.Phone.Toolkit.Background"},
    @{Name = "Cimbalino.Phone.Toolkit.Camera"},
    @{Name = "Cimbalino.Phone.Toolkit.Controls"},
    @{Name = "Cimbalino.Phone.Toolkit.DeviceInfo"},
    @{Name = "Cimbalino.Phone.Toolkit.Location"},
    @{Name = "Cimbalino.Phone.Toolkit.MediaLibrary"},
    @{Name = "Cimbalino.Phone.Toolkit.PhoneDialer"},
    @{Name = "Cimbalino.Phone.Toolkit.UserInfo"}
  )
  $configurations = @(
    @{Name = "WP71"; Folder = "sl4-wp71"},
    @{Name = "WP8"; Folder = "wp8"}
  )
}

Framework "4.0x86"

task default -depends ?

task Clean -description "Clean the output folder" {
  if (Test-Path -path $binDir)
  {
    Write-Host -ForegroundColor Green "Deleting Working Directory"
    Write-Host
    
    Remove-Item $binDir -Recurse -Force
  }
  
  New-Item -Path $binDir -ItemType Directory | Out-Null
}

task Setup -description "Setup environment" {
  $configurations | % {
    $configName = $_.Name

    $projects | % {
      $projectName = $_.Name
      $fullProjectName = "$projectName ($configName)"
      $packagesConfig = "$sourceDir\$fullProjectName\packages.config"
      
      Write-Host -ForegroundColor Green "Pre-installing NuGet packages for $fullProjectName..."
      Write-Host
      
      Exec { .$nuget install $packagesConfig -solutionDir $sourceDir } "Error pre-installing NuGet packages"
    }
  }
}

task Version -description "Updates the version entries in AssemblyInfo.cs files" {
  $assemblyVersion = $version -replace '([0-9]+(\.[0-9]+){2}).*', '$1.0'
  $fileVersion = $assemblyVersion
  $assemblyVersionPattern = 'AssemblyVersion\("[0-9]+(\.([0-9]+|\*)){1,3}"\)'
  $fileVersionPattern = 'AssemblyFileVersion\("[0-9]+(\.([0-9]+|\*)){1,3}"\)'
  $assemblyVersionValue = 'AssemblyVersion("' + $assemblyVersion + '")';
  $fileVersionValue = 'AssemblyFileVersion("' + $fileVersion + '")';
  
  $configurations | % {
    $configName = $_.Name

    $projects | % {
      $projectName = $_.Name
      $fullProjectName = "$projectName ($configName)"
      $projectDir = "$sourceDir\$fullProjectName\"
      
      Write-Host -ForegroundColor Green "Versioning $fullProjectName..."
      Write-Host
      
      Get-ChildItem -Path $projectDir -Filter AssemblyInfo.cs -Recurse | % {
        $filename = $_.FullName
        
        (Get-Content -Path $filename) | % {
          % { $_ -Replace $assemblyVersionPattern, $assemblyVersionValue } |
          % { $_ -Replace $fileVersionPattern, $fileVersionValue }
        } | Set-Content -Path $filename -Encoding UTF8
      }
    }
  }
}

task Build -depends Clean, Setup, Version -description "Build all projects and get the assemblies" {
  $tempBinariesDir = "$tempDir\binaries"
  
  New-Item -Path $binariesDir -ItemType Directory | Out-Null
  New-Item -Path $tempBinariesDir -ItemType Directory | Out-Null
  
  Exec { msbuild "/t:Clean;Build" /p:Configuration=Release /p:OutDir=$tempBinariesDir /p:GenerateProjectSpecificOutputFolder=true /p:StyleCopTreatErrorsAsWarnings=false /m "$sourceDir\Cimbalino.Phone.Toolkit.sln" } "Error building $solutionFile"
  
  $configurations | % {
    $configName = $_.Name
    $configDir = "$binariesDir\$configName"
    
    New-Item -Path $configDir -ItemType Directory | Out-Null
    
    $projects | % {
      $projectName = $_.Name
      $fullProjectName = "$projectName ($configName)"
      $projectDir = "$configDir\$projectName"
      
      New-Item -Path $projectDir -ItemType Directory | Out-Null
      
      Copy-Item -Path $tempBinariesDir\$fullProjectName\*.* -Destination $projectDir\ -Recurse
    }
  }
}

task Test -depends Build -description "Run tests in the resulting assemblies" {
  pushd $tempDir
  
  Exec { .$vstest "$tempDir\binaries\Cimbalino.Phone.Toolkit.Tests (WP8)\Cimbalino.Phone.Toolkit.Tests.xap" /Logger:trx /InIsolation } "Error running tests"
  
  popd
  
  Get-ChildItem $tempDir\TestResults\*.trx | % {
    $filename = $_.FullName
    [xml]$trx = Get-Content $filename
  
    if (($trx.TestRun.ResultSummary.outcome -ne "Completed") -or ($trx.TestRun.ResultSummary.Counters.failed -ne "0"))
    {
      throw
    }
  }
}

task PackZip -depends Build -description "Create a zip file with the resulting assemblies" {
  $tempZipDir = "$tempDir\zip"
  
  New-Item -Path $zipDir -ItemType Directory | Out-Null
  New-Item -Path $tempZipDir -ItemType Directory | Out-Null
  
  Copy-Item -Path $binariesDir\* -Destination $tempZipDir\ -Recurse
  Copy-Item -Path $sourceDir\License.txt -Destination $tempZipDir\ -Recurse
  
  Exec { .$7zip a -tzip "$zipDir\Cimbalino.Phone.Toolkit.$version.zip" "$tempZipDir\*" } "Error packaging $name"
}

task PackNuGet -depends Build -description "Create the NuGet packages" {
  $tempNupkgDir = "$tempDir\nupkg"
  
  New-Item -Path $nupkgDir -ItemType Directory | Out-Null
  New-Item -Path $tempNupkgDir -ItemType Directory | Out-Null
  
  $projects | % {
    $projectName = $_.Name
    $projectNugetFolder = "$tempNupkgDir\$projectName"
    $projectNuspec = "$projectName.nuspec"
    
    New-Item -Path $projectNugetFolder -ItemType Directory | Out-Null
    
    (Get-Content -Path $buildDir\$projectNuspec) | % {
          % { $_ -Replace '\$version\$', $version }
        } | Set-Content -Path $projectNugetFolder\$projectNuspec -Encoding UTF8
    
    $configurations | % {
      $configName = $_.Name
      $configFolder = $_.Folder
      $fullProjectFolder = "$projectNugetFolder\lib\$configFolder"
      
      New-Item -Path $fullProjectFolder -ItemType Directory | Out-Null
      
      Copy-Item -Path $binariesDir\$configName\$projectName\*.* -Destination $fullProjectFolder\ -Recurse
    }
    
    Write-Host -ForegroundColor Green "Packaging $projectName..."
    Write-Host
    
    Exec { .$nuget pack $projectNugetFolder\$projectNuspec -Output $nupkgDir\ } "Error packaging $name"
  }
}

task PublishNuget -depends PackNuGet -description "Publish the NuGet packages to the remote repositories" {
  Get-ChildItem $nupkgDir\*.nupkg | % {
    $nupkg = $_.FullName
    
    Write-Host -ForegroundColor Green "Publishing $nupkg..."
    Write-Host
    
    Exec { .$nuget push $nupkg } "Error publishing $nupkg"
  }
}

task ? -description "Show the help screen" {
  Write-Documentation
}