param([String]$version="1.0.0")

# Locate and read the config.xml documents. Use object notation to find the node we need to change to 0 then save the file. 
$files = Get-ChildItem . *.csproj  -Recurse | Select-Object -ExpandProperty FullName

$files | ForEach-Object{
  $xml = [xml](Get-Content $_)
  if($xml.Project.PropertyGroup.VersionPrefix){
    Write-Host "Patching $_"
    # Check to be sure this value actually is present before we try to change it. 
    $xml.Project.PropertyGroup.VersionPrefix = $version
    # Only need to save if change was made. 
    $xml.Save($_)
    Write-Host "Updated $_ to version $version"
  }
}
