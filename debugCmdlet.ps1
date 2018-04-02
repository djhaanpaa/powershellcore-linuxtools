#!/usr/bin/env pwsh
dotnet build -o ../debugModule
Set-Location ./debugModule
pwsh -NoProfile -NoExit -Command "Import-Module .\PowershellCore.Linux.Mangement.dll"
Set-Location ../
Clear-Host 



