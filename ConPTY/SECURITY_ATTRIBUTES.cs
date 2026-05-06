using System;
using System.Runtime.InteropServices;

namespace DeepSeekAgent.ConPTY;

[StructLayout(LayoutKind.Sequential)]
public struct SECURITY_ATTRIBUTES
{
    public int nLength;
    public IntPtr lpSecurityDescriptor;
    public bool bInheritHandle;
}