properties { 
  $baseDir  = Resolve-Path ..
  $buildDir = "$baseDir\build"
  $sourceDir = "$baseDir\src"
  $toolsDir = "$baseDir\tools"
  $releaseDir = "$baseDir\bin\release"
  $workingDir = "$baseDir\bin\working"
  
  $nuget = "$toolsDir\nuget\nuget.exe"
  
  $builds = @(
    @{Name = "Cimbalino.Phone.Toolkit"},
    @{Name = "Cimbalino.Phone.Toolkit.Camera"},
    @{Name = "Cimbalino.Phone.Toolkit.PhoneDialer"}
  )
}

$framework = '4.0x86'

task default -depends Package

task Clean {
  Set-Location $baseDir
  
  if (Test-Path -path $workingDir)
  {
    Write-Output "Deleting Working Directory"
    
    Remove-Item $workingDir -Recurse -Force
  }
  
  New-Item -Path $workingDir -ItemType Directory | Out-Null
}

task Package -depends Clean {
  $builds | % {
    $name = $_.Name
    $csproj = "$sourceDir\$name\$name.csproj"

    Write-Host -ForegroundColor Green "Packaging $name..."
    Write-Host
    
    Exec { .$nuget pack $csproj -Prop Configuration=Release -Build -OutputDirectory $workingDir } "Error packaging $name"
  }
}

task Publish -depends Package {
  Get-ChildItem $workingDir\*.nupkg | % {
    $nupkg = %_.FullName
    
    Write-Host -ForegroundColor Green "Publishing $nupkg..."
    Write-Host
    
    Exec { .$nuget push $nupkg } "Error publishing $nupkg"
  }
}