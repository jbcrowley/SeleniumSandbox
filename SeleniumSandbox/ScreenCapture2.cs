using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace SeleniumSandbox
{
    internal class ScreenCapture2
    {
        // https://stackoverflow.com/a/24879511/2386774

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetDesktopWindow();

        [StructLayout(LayoutKind.Sequential)]
        private struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);

        public static Image CaptureDesktop()
        {
            return CaptureWindow(GetDesktopWindow());
        }

        public static Bitmap CaptureActiveWindow()
        {
            return CaptureWindow(GetForegroundWindow());
        }

        public static Rectangle GetCurrentWindowSize()
        {
            Rect rect = new Rect();
            GetWindowRect(GetForegroundWindow(), ref rect);

            return new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
        }

        public static Bitmap CaptureWindow(Rectangle rectangle)
        {
            Bitmap result = new Bitmap(rectangle.Width, rectangle.Height);

            using (Graphics graphics = Graphics.FromImage(result))
            {
                graphics.CopyFromScreen(new Point(rectangle.Left, rectangle.Top), Point.Empty, rectangle.Size);
            }

            return result;
        }

        public static Bitmap CaptureWindow(IntPtr handle)
        {
            Rect rect = new Rect();
            GetWindowRect(handle, ref rect);
            Rectangle bounds = new Rectangle(rect.Left + 8, rect.Top, rect.Right - rect.Left - 16, rect.Bottom - rect.Top - 8);
            Bitmap result = new Bitmap(bounds.Width, bounds.Height);

            using (Graphics graphics = Graphics.FromImage(result))
            {
                graphics.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
            }

            return result;
        }
    }
}