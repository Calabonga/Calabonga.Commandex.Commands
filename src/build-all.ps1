#
# Собирает в конфигурации Release все solution'ы, найденные в папке src.
# Общего solution в репозитории нет, поэтому каждый пример собирается отдельно.
#

$ErrorActionPreference = 'Stop'
$srcRoot = $PSScriptRoot

$solutions = Get-ChildItem -Path $srcRoot -Filter *.sln -Recurse -File

$failed = @()
$count = 0

foreach ($solution in $solutions)
{
    $count++
    Write-Host "=== [$count/$($solutions.Count)] $($solution.Name) ===" -ForegroundColor Cyan

    dotnet build $solution.FullName -c Release --nologo

    if ($LASTEXITCODE -ne 0)
    {
        $failed += $solution.Name
        Write-Host "FAILED: $($solution.Name) (exit $LASTEXITCODE)" -ForegroundColor Red
    }
}

Write-Host ""
Write-Host "Собрано solution'ов: $count, с ошибкой: $($failed.Count)"

if ($failed.Count -gt 0)
{
    $failed | ForEach-Object { Write-Host "  - $_" -ForegroundColor Red }
    exit 1
}

Write-Host "Все solution'ы собраны успешно." -ForegroundColor Green
exit 0
