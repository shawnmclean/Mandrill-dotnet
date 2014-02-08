Param(
    $filePath = "",
    [hashtable]$lookupTable = @{}
)

[xml]$xml = gc "$filePath/AppSettings.example.config"
$xml.appSettings.add | ForEach-Object {
    $element = $_
    $lookupTable.GetEnumerator() | ForEach-Object {
        if ($element.key -eq $_.Key)
        {
            $element.value = $_.Value
        }
    } 
}
$xml.Save("$filePath/AppSettings.config")