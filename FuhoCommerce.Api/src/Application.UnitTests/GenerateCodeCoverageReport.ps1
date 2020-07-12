$reportGeneratorVersion = "4.5.6"
$dotNetCore = "netcoreapp3.0"
$coverageFolderPath = "BuildReports\Coverage"
$unitTestFolderPath = "BuildReports\UnitTests"

$coverageFolder = Join-Path $PSScriptRoot $coverageFolderPath
$unitTestFolder = Join-Path $PSScriptRoot $unitTestFolderPath

# Get code coverage

dotnet test --logger "trx;LogFileName=TestResults.trx" `
            --logger "xunit;LogFileName=TestResults.xml" `
            --results-directory "./BuildReports/UnitTests" `
            /p:CollectCoverage=true `
            /p:CoverletOutput=BuildReports\Coverage\ `
            /p:CoverletOutputFormat=cobertura `
            /p:Exclude="[xunit.*]*"

# Get report generator path
$reportGenerator = Join-Path $env:userprofile -ChildPath "\.nuget\packages\reportgenerator\" `
                 | Join-Path -ChildPath $reportGeneratorVersion `
                 | Join-Path -ChildPath "\tools\" `
                 | Join-Path -ChildPath $dotNetCore `
                 | Join-Path -ChildPath "\ReportGenerator.exe"
      
if (Test-Path $reportGenerator) 
{
  # Generate report
  & $reportGenerator "-reports:BuildReports\Coverage\coverage.cobertura.xml" "-targetdir:BuildReports\Coverage" "-reporttypes:Html"
  # Open report in browser
  start BuildReports\Coverage\index.htm
}
else
{
  Write-Host "Cannot find ReportGenerator Nuget package version $($reportGeneratorVersion) for $($dotNetCore)" -ForegroundColor red
  Write-Host "Press any key to continue ..."
  $x = $host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
}
