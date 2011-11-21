Clear-Host

try {
  Import-Module ..\tools\psake\psake.psm1
  Invoke-psake @args
}
finally {
  Remove-Module psake
}