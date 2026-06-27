using System;
using System.Runtime.InteropServices;

namespace Tsukishiro.Windows.Runtime.Models;

public static class ComBaseInterop
{
	[DllImport("combase.dll")]
	private static extern IntPtr WindowsCreateString();

	[DllImport("combase.dll")]
	private static extern IntPtr WindowsDeleteString();
    
}