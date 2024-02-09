Param(
    [parameter(Mandatory=$true)][string]$resourceGroup,
    [parameter(Mandatory=$true)][string]$cosmosDbAccountName
)

Push-Location $($MyInvocation.InvocationName | Split-Path)
Push-Location ..
Remove-Item -Path dMT -Recurse -Force -ErrorAction Ignore
New-Item -ItemType Directory -Force -Path "dMT"
Push-Location "dMT"

# mods for Linux, and using the latest version of dmt as of 10 sep 2023; viz. 2.1.4
# original dmt version for windows 2.1.1

if ($IsWindows) {
    $dmtUrl="https://github.com/AzureCosmosDB/data-migration-desktop-tool/releases/download/2.1.1/dmt-2.1.1-win-x64.zip"
}
elseif ($IsLinux)  {
    $dmtUrl="https://github.com/AzureCosmosDB/data-migration-desktop-tool/releases/download/2.1.4/dmt-2.1.4-linux-x64.zip"
}
else {
    write-host "Unrecognized OS" -ForegroundColor Red
    exit 1
}

Invoke-WebRequest -Uri $dmtUrl -OutFile dmt.zip
Expand-Archive -Path dmt.zip -DestinationPath .

if ($IsWindows) {
    Push-Location "windows-package"
    $dmtCommand="./dmt.exe"
}
elseif ($IsLinux) {
    Push-Location "linux-package"
    $dmtCommand="./dmt"
    chmod a+rx $dmtCommand
}
else {
    write-host "Unrecognized OS" -ForegroundColor Red
    exit 1
}

Copy-Item -Path "../../migrationsettings.json" -Destination "./migrationsettings.json" -Force

Write-Host "Bumping up the throughput on the customer container to avoid a known DMT issue..."
az cosmosdb sql container throughput update --account-name $cosmosDbAccountName --database-name database --name properties --resource-group $resourceGroup --max-throughput 10000

& $dmtCommand

Write-Host "Restoring the throughput on the customer container..."
az cosmosdb sql container throughput update --account-name $cosmosDbAccountName --database-name database --name properties --resource-group $resourceGroup --max-throughput 4000

Pop-Location
Pop-Location
Pop-Location
Pop-Location
