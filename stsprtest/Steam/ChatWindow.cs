using System;
using static stsprtest.NativeMethods;

namespace stsprtest
{
    public class ChatWindow
    {
        public IntPtr WindowHandle
        {
            get { return m_WindowHandle; }
            protected set { m_WindowHandle = value; }
        }

        public string DisplayName
        {
            get { return m_DisplayName; }
            protected set { m_DisplayName = value; }
        }

        public void Open()
        {
            SetForegroundWindow(WindowHandle);
        }

        public static ChatWindow FromHandle(IntPtr handle, string displayName)
        {
            return new ChatWindow() { WindowHandle = handle, DisplayName = displayName };
        }

        ~ChatWindow()
        {
            CloseHandle(WindowHandle);
        }

        private IntPtr m_WindowHandle;
        private string m_DisplayName;
    }
}
