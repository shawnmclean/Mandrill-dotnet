Param(
    [Parameter(Mandatory=$true)] [string]$filePath = "D:\Projects\Open Source\Mandrill-dotnet\scripts",
    [Parameter(Mandatory=$true)] [hashtable]$lookupTable = @{}
)


$readFile = "$filePath/tests/AppSettings.example.config"
$saveFile = "$filePath/tests/AppSettings.config"

Write-Host "Looking for file: $readFile"

[xml]$xml = gc $readFile

Write-Host "File read into memory: $readFile"

$xml.appSettings.add | ForEach-Object {
    Write-Host "Key Found: " $_.key

    $element = $_

    $lookupTable.GetEnumerator() | ForEach-Object {
        if ($element.key -eq $_.Key)
        {
            $element.value = $_.Value

            Write-Host "Replacing key: " $element.key
        }
    } 
}

Write-Host "Saving file: $saveFile"

$xml.Save($saveFile)