Param(
    [hashtable]$lookupTable = @{}
)

$executingScriptDirectory = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent
$file = "$executingScriptDirectory/AppSettings.config"

[xml]$xml = gc $file
$xml.appSettings.add | ForEach-Object {
    $element = $_
    $lookupTable.GetEnumerator() | ForEach-Object {
        if ($element.key -eq $_.Key)
        {
            $element.value = $_.Value
        }
    } 
}
$xml.Save($file)