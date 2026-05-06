using System.Runtime.InteropServices;

namespace DeepSeekAgent.ConPTY;

[StructLayout(LayoutKind.Sequential)]
public struct COORD
{
    public short X;
    public short Y;
}