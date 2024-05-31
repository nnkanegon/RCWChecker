using System;
using System.Runtime.InteropServices;

namespace RCWChecker
{
    internal class NativeMethods
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, ref COPYDATASTRUCT lParam);
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public UInt32 cbData;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpData;
        }
    }
}
