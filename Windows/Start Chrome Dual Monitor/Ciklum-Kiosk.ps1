######################################################
##########            Kiosk Mode          ############
######################################################
#
# Runs chrome and other apps in full-screen mode 
# on predefined screens
# ----------------------------------------------------

# Remove "Restore Session" prompt
$c = Get-Content "$($env:localAppData)\Google\Chrome\User Data\Default\Preferences"
if ($c.IndexOf('"exit_type":"Crashed"') -gt 0) {
  $c.Replace('"exit_type":"Crashed"', '"exit_type":"Normal"').Replace('"exited_cleanly":false', '"exited_cleanly":true') | Set-Content "$($env:localAppData)\Google\Chrome\User Data\Default\Preferences" -NoNewLine
}

$chromePath = 'C:\Program Files (x86)\Google\Chrome\Application\chrome.exe'
$chromeArguments = '--new-window --incognito'
# if Window not moved (especially on machine start) - try increaing the delay. 
$ChromeStartDelay = 3

Set-Location $PSScriptRoot
. .\HelperFunctions.ps1

# Kill all running instances
# &taskkill /im chrome* /F

Chrome-Kiosk 'http://google.com' -MonitorNum 1 
Chrome-Kiosk 'http://http://www.bbc.com/' -MonitorNum 2