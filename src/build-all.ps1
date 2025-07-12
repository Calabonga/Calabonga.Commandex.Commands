#
# Build all solutions in directory
#

if($PSVersionTable.PSVersion.Major -ge 7 -or ($PSVersionTable.PSVersion.Major -eq 7 -and $PSVersionTable.PSVersion.Minor -ge 2))
{
    $PSStyle.Progress.View="Classic" # Backwards compatible
}

$solutions = Get-ChildItem -Path . -Filter *.sln -ErrorAction SilentlyContinue -Force -Recurse -Depth 1

$count = 0

foreach ($solution in $solutions) 
{
	$process = Start-Process -Wait -PassThru -NoNewWindow -FilePath "dotnet" -WorkingDirectory $solution.DirectoryName -ArgumentList "build","-c Release", "--nologo"
    Write-Host "Exit code $($solution.BaseName) is: $($process.ExitCode)"
    $count++    
}

Write-Host "Total solution built: $($count)"
