﻿using System;
using System.Runtime.InteropServices;

namespace Touhou_Presence.Data
{
    public abstract class TouhouBase
    {
        #region [    Memory Scan    ]
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
            VirtualProtectEx(Handle, Offset, size, 0x40, out uint lpflOldProtect);
            ReadProcessMemory(Handle, Offset, lpBuffer, size, out uint lpNumberOfBytes);
            VirtualProtectEx(Handle, Offset, size, lpflOldProtect, out uint Null);
            return lpBuffer;
        }

        protected int BringInt(IntPtr Offset) { return BitConverter.ToInt32(Bring(Offset, 4), 0); }
        protected bool BringBool(IntPtr Offset) { return BitConverter.ToBoolean(Bring(Offset, 1), 0); }
        protected byte BringByte(IntPtr Offset) { return Bring(Offset, 1)[0]; }
        protected IntPtr Handle = IntPtr.Zero;
        #endregion

        public string ProgramName { get; protected set; }

        protected IntPtr DifficultyOffset = IntPtr.Zero;
        public int Difficulty { get; }

        protected IntPtr ChapterOffset = IntPtr.Zero;
        public int Chapter { get; }

        protected IntPtr CharacterOffset = IntPtr.Zero;
        public virtual int Character { get => BringByte(CharacterOffset); }
        public virtual string CharacterString { get; }

        protected IntPtr SpellOffset = IntPtr.Zero;
        public int Spell { get => BringByte(SpellOffset); }
        public virtual string SpellString { get; }

        protected IntPtr CharSpellOffset = IntPtr.Zero;
        public int CharSpell { get => BringByte(CharSpellOffset); }
        public virtual string CharSpellString { get; }

        protected IntPtr IsPauseOffset = IntPtr.Zero;
        public bool IsPause { get => BringBool(IsPauseOffset); }

        protected IntPtr StatusOffset = IntPtr.Zero;
        public int Status { get; }
        public virtual string StatusString { get; }
    }
}