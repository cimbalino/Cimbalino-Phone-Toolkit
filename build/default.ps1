properties { 
  $baseDir  = Resolve-Path ..
  $buildDir = "$baseDir\build"
  $sourceDir = "$baseDir\src"
  $toolsDir = "$baseDir\tools"
  $binDir = "$baseDir\bin"
  
  $assemblyVersion = "1.2.2.0"
  $fileVersion = $assemblyVersion
  
  $tempDir = "$binDir\temp"
  $binariesDir = "$binDir\binaries"
  $zipDir = "$binDir\zip"
  $nupkgDir = "$binDir\nupkg"
  
  $nuget = "$toolsDir\nuget\nuget.exe"
  $7zip = "$toolsDir\7zip\7za.exe"
  
  $projects = @(
    @{Name = "Cimbalino.Phone.Toolkit"},
    @{Name = "Cimbalino.Phone.Toolkit.Camera"},
    @{Name = "Cimbalino.Phone.Toolkit.Controls"},
    @{Name = "Cimbalino.Phone.Toolkit.DeviceInfo"},
    @{Name = "Cimbalino.Phone.Toolkit.Location"},
    @{Name = "Cimbalino.Phone.Toolkit.PhoneDialer"},
    @{Name = "Cimbalino.Phone.Toolkit.UserInfo"}
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

task Version -description "Updates the version entries in AssemblyInfo.cs files" {
  $assemblyVersionPattern = 'AssemblyVersion\("[0-9]+(\.([0-9]+|\*)){1,3}"\)'
  $fileVersionPattern = 'AssemblyFileVersion\("[0-9]+(\.([0-9]+|\*)){1,3}"\)'
  $assemblyVersionValue = 'AssemblyVersion("' + $assemblyVersion + '")';
  $fileVersionValue = 'AssemblyFileVersion("' + $fileVersion + '")';
  
  $projects | % {
    $name = $_.Name
    $projectDir = "$sourceDir\$name\"
    
    Write-Host -ForegroundColor Green "Versioning $name..."
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

task Build -depends Clean, Version -description "Build all projects and get the assemblies" {
  $tempBinariesDir = "$tempDir\binaries"
  
  New-Item -Path $binariesDir -ItemType Directory | Out-Null
  New-Item -Path $tempBinariesDir -ItemType Directory | Out-Null
  
  $projects | % {
    $name = $_.Name
    $csproj = "$sourceDir\$name\$name.csproj"

    Write-Host -ForegroundColor Green "Building $name..."
    Write-Host
    
    Exec { msbuild "/t:Clean;Build" /p:Configuration=Release /p:OutputPath=$tempBinariesDir $csproj } "Error building $name"
    
    Copy-Item -Path "$tempBinariesDir\*.*" -Destination "$binariesDir\" -Recurse
  }
}

task PackZip -depends Build -description "Create a zip file with the resulting assemblies" {
  $tempZipDir = "$tempDir\zip"
  
  New-Item -Path $zipDir -ItemType Directory | Out-Null
  New-Item -Path $tempZipDir -ItemType Directory | Out-Null
  
  Copy-Item -Path "$binariesDir\*.*" -Destination "$tempZipDir\" -Recurse
  Copy-Item -Path "$sourceDir\License.txt" -Destination "$tempZipDir\" -Recurse
  
  $zipVersion = $assemblyVersion -replace "(\d+.\d+).*", '$1'
  
  Exec { .$7zip a -tzip "$zipDir\Cimbalino.Phone.Toolkit.$zipVersion.zip" "$tempZipDir\*.*" } "Error packaging $name"
}

task PackNuGet -depends Clean, Version -description "Create the NuGet packages" {
  New-Item -Path $nupkgDir -ItemType Directory | Out-Null
  
  $projects | % {
    $name = $_.Name
    $csproj = "$sourceDir\$name\$name.csproj"

    Write-Host -ForegroundColor Green "Packaging $name..."
    Write-Host
    
    Exec { .$nuget pack $csproj -Prop Configuration=Release -Build -OutputDirectory $nupkgDir } "Error packaging $name"
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