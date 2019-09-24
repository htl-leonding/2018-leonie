using System;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using WindowsInput;
using WindowsInput.Native;
using static LeonieStartup.NativeMethods;

namespace LeonieStartup
{
    class Program
    {
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);
        static void Main(string[] args)
        {

            InputSimulator imp = new InputSimulator();
            Process p = new Process();
            p.StartInfo.FileName = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
            p.StartInfo.Arguments = "leonie.htl-leonding.ac.at";
            p.Start();


            var hwnd = p.MainWindowHandle;
            var monitor = NativeMethods.MonitorFromWindow(hwnd, NativeMethods.MONITOR_DEFAULTTONEAREST);

            if (monitor != IntPtr.Zero)
            {
                var monitorInfo = new NativeMonitorInfo();
                NativeMethods.GetMonitorInfo(monitor, monitorInfo);


                var left = monitorInfo.Monitor.Left;
                var top = monitorInfo.Monitor.Top;
                var width = (monitorInfo.Monitor.Right - monitorInfo.Monitor.Left);
                var height = (monitorInfo.Monitor.Bottom - monitorInfo.Monitor.Top);



                Program.MoveWindow(p.MainWindowHandle, width + 100, 0, 0, 0, true);


                // Better Solution would be: Using SetWindowPos to max sizen and hiding the UI
                System.Threading.Thread.Sleep(1000);
                imp.Keyboard.KeyPress(VirtualKeyCode.F11);

                Process leonie = new Process();
                leonie.StartInfo.FileName = @"C:\opt\leonie.exe";
                //leonie.StartInfo.Arguments = "fullscreen";
                leonie.Start();

            }

        }
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

    }
    public static class NativeMethods
    {
        public const Int32 MONITOR_DEFAULTTOPRIMERTY = 0x00000001;
        public const Int32 MONITOR_DEFAULTTONEAREST = 0x00000002;


        [DllImport("user32.dll")]
        public static extern IntPtr MonitorFromWindow(IntPtr handle, Int32 flags);


        [DllImport("user32.dll")]
        public static extern Boolean GetMonitorInfo(IntPtr hMonitor, NativeMonitorInfo lpmi);


        [Serializable, StructLayout(LayoutKind.Sequential)]
        public struct NativeRectangle
        {
            public Int32 Left;
            public Int32 Top;
            public Int32 Right;
            public Int32 Bottom;


            public NativeRectangle(Int32 left, Int32 top, Int32 right, Int32 bottom)
            {
                this.Left = left;
                this.Top = top;
                this.Right = right;
                this.Bottom = bottom;
            }
        }


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public sealed class NativeMonitorInfo
        {
            public Int32 Size = Marshal.SizeOf(typeof(NativeMonitorInfo));
            public NativeRectangle Monitor;
            public NativeRectangle Work;
            public Int32 Flags;
        }
    }
    public class WinApi
    {
        [DllImport("user32.dll", EntryPoint = "GetSystemMetrics")]
        public static extern int GetSystemMetrics(int which);

        [DllImport("user32.dll")]
        public static extern void
            SetWindowPos(IntPtr hwnd, IntPtr hwndInsertAfter,
                         int X, int Y, int width, int height, uint flags);

        private const int SM_CXSCREEN = 0;
        private const int SM_CYSCREEN = 1;
        private static IntPtr HWND_TOP = IntPtr.Zero;
        private const int SWP_SHOWWINDOW = 64; // 0x0040

        public static int ScreenX
        {
            get { return GetSystemMetrics(SM_CXSCREEN); }
        }

        public static int ScreenY
        {
            get { return GetSystemMetrics(SM_CYSCREEN); }
        }

        public static void SetWinFullScreen(IntPtr hwnd)
        {
            SetWindowPos(hwnd, HWND_TOP, 0, 0, ScreenX, ScreenY, SWP_SHOWWINDOW);
        }
    }
}