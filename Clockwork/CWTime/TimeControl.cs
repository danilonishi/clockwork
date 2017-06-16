using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clockwork.CWTime
{
	internal static class NativeMethods
	{
		[DllImport("kernel32.dll", EntryPoint = "GetSystemTime", SetLastError = true)]
		public extern static void Win32GetSystemTime(ref SystemTime sysTime);

		[DllImport("kernel32.dll", EntryPoint = "SetSystemTime", SetLastError = true)]
		public extern static bool Win32SetSystemTime(ref SystemTime sysTime);
		
	}
}