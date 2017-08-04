<#
    Requires ImportExcel module to be installed
    https://github.com/dfinke/ImportExcel

    Install-Module ImportExcel
#>

Write-Host "Allow self-signed certs"
[System.Net.ServicePointManager]::ServerCertificateValidationCallback = { $True }

Write-Host "Importing Check Point Module"
import-module ..\CheckPoint.psm1

Write-Host "Logging in. You will be prompted for creds"
$Session = Invoke-CPLogin

Write-Host "Importing Groups"
$Groups = Import-Excel -WorkSheetname Groups   -Path .\Import.xlsx  | Add-CPGroup   -Session $Session -Verbose
Write-Host "Imported $($($Groups | measure).Count) Groups"

Write-Host "Importing Hosts"
$Hosts = Import-Excel -WorkSheetname Hosts    -Path .\Import.xlsx  | Add-CPHost    -Session $Session -Verbose
Write-Host "Imported $($($Hosts | measure).Count) Hosts"

Write-Host "Importing Networks"
$Networks = Import-Excel -WorkSheetname Networks -Path .\Import.xlsx  | Add-CPNetwork -Session $Session -Verbose
Write-Host "Imported $($($Networks | measure).Count) Networks"

Write-Host "Logout and allow session to continue from SmartConsole."
Write-Host "Discard changes in SmartConsole if you want to run this again."
Invoke-CPContinueSessionInSmartconsole $Session


Remove-Module CheckPoint