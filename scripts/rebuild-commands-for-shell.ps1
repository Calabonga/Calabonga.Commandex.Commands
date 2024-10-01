Get-ChildItem -Path ..\src -Recurse | Where-Object {$_.Name -like "*.csproj"} | Select-Object @{Name = "Path"; Expression = {[System.IO.Path]::GetDirectoryName($_.FullName)}} | ForEach-Object {Start-Process -FilePath 'dotnet' -WorkingDirectory $_.Path -ArgumentList 'build -c Release'}