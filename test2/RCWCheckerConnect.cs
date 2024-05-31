using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Reflection;

public static class NativeMethods
{
	public const int WM_COPYDATA = 0x4A;

	[DllImport("User32.dll", CharSet = CharSet.Unicode)]
	public static extern IntPtr FindWindow([MarshalAs(UnmanagedType.LPWStr)]string lpClassName, [MarshalAs(UnmanagedType.LPWStr)]string lpWindowName);

	[DllImport("User32.dll", CharSet = CharSet.Unicode)]
	public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, ref COPYDATASTRUCT lParam);

	[DllImport("User32.dll", CharSet = CharSet.Unicode)]
	public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct COPYDATASTRUCT
	{
		public IntPtr dwData;
		public UInt32 cbData;
		[MarshalAs(UnmanagedType.LPWStr)]
		public string lpData;
	}
}

public static class RCWCheckerConnect
{
	public const int RCWCHECKER_ATTACH = 0x01;
	public const int RCWCHECKER_DUMP = 0x02;

	public static void Send(int command, string msg)
	{
		IntPtr hwnd = NativeMethods.FindWindow(null, "RCWChecker");
		if (hwnd == IntPtr.Zero)
			return;

		NativeMethods.COPYDATASTRUCT cds = new NativeMethods.COPYDATASTRUCT();
		cds.dwData = new IntPtr(command);
		cds.cbData = (uint)(msg.Length * sizeof(char) + 1);
		cds.lpData = msg;

		NativeMethods.SendMessage(hwnd, NativeMethods.WM_COPYDATA, (IntPtr)0, ref cds);
	}

	public static void Attach()
	{
        Assembly myAssembly = Assembly.GetEntryAssembly();
        string processName = Path.GetFileNameWithoutExtension(myAssembly.Location);
        Send(RCWCheckerConnect.RCWCHECKER_ATTACH, processName);
	}

	public static void Dump(string comment = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = -1)
	{
		string msg = String.Format("[{0}:{1}] {2}", Path.GetFileName(filePath), lineNumber, comment);
		Send(RCWCheckerConnect.RCWCHECKER_DUMP, msg);
	}

}
