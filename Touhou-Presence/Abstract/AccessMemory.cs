using System;
using System.Timers;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Touhou_Presence
{
    public abstract class AccessMemory
    {
        protected Process Game;

        #region [    Windows API    ]
        [DllImport("kernel32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ReadProcessMemory
        (
            [In]IntPtr hProcess,
            [In]IntPtr lpBaseAddress,
            [Out]byte[] lpBuffer,
            [In]uint dwSize,
            [Out]out uint lpNumberOfBytesRead
        );

        [DllImport("kernel32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool VirtualProtectEx
        (
            [In]IntPtr hProcess,
            [In]IntPtr lpAddress,
            [In]uint dwSize,
            [In]uint flNewProtect,
            [Out]out uint lpflOldProtect
        );
        #endregion

        protected byte[] Bring(IntPtr Offset, uint size)
        {
            byte[] lpBuffer = new byte[size];
            VirtualProtectEx(Game.Handle, Offset, size, 0x40, out uint lpflOldProtect);
            ReadProcessMemory(Game.Handle, Offset, lpBuffer, size, out uint lpNumberOfBytes);
            VirtualProtectEx(Game.Handle, Offset, size, lpflOldProtect, out uint Null);
            return lpBuffer;
        }

        protected int BringInt(IntPtr Offset) { return BitConverter.ToInt32(Bring(Offset, 4), 0); }
        protected bool BringBool(IntPtr Offset) { return BringByte(Offset) > 0; }
        protected byte BringByte(IntPtr Offset) { return Bring(Offset, 1)[0]; }
    }
}