using System;
using System.Linq;

namespace M2M.DataCenter.Panel.FormsUI
{
    public class WinApi
    {
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "GetSystemMetrics")]
        public static extern int GetSystemMetrics(int which);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void
            SetWindowPos(IntPtr hwnd, IntPtr hwndInsertAfter,
                         int X, int Y, int width, int height, uint flags);

        public static void SetWinFullScreen(IntPtr hwnd)
        {
            SetWindowPos(hwnd, IntPtr.Zero, 0, 0, GetSystemMetrics(0), GetSystemMetrics(1), 64);
        }
    }
}
