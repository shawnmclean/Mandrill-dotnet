Param(
    $filePath = "",
    [hashtable]$lookupTable = @{}
)

[xml]$xml = gc "$filePath/tests/AppSettings.example.config"
$xml.appSettings.add | ForEach-Object {
    $element = $_
    $lookupTable.GetEnumerator() | ForEach-Object {
        if ($element.key -eq $_.Key)
        {
            $element.value = $_.Value
        }
    } 
}
$xml.Save("$filePath/tests/AppSettings.config")