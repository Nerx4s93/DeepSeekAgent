using System;
using System.Runtime.InteropServices;

namespace DeepSeekAgent.ConPTY;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct STARTUPINFOEX
{
    public STARTUPINFO StartupInfo;
    public IntPtr lpAttributeList;
}