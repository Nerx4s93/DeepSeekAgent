using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

namespace DeepSeekAgent.ConPTY;

internal static class PipeHelper
{
    public static (SafeFileHandle read, SafeFileHandle write) CreatePipe()
    {
        var security = new SECURITY_ATTRIBUTES();
        security.bInheritHandle = true;

        if (!CreatePipe(out var read, out var write, ref security, 0))
        {
            throw new System.ComponentModel.Win32Exception();
        }

        return (read, write);
    }

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool CreatePipe(
        out SafeFileHandle hReadPipe,
        out SafeFileHandle hWritePipe,
        ref SECURITY_ATTRIBUTES lpPipeAttributes,
        uint nSize);
}