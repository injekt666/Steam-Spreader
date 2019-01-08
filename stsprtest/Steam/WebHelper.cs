using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using static stsprtest.NativeMethods;

namespace stsprtest.Steam
{
    public class WebHelper
    {
        public bool Open
        {
            get { return ChatWindows.Count > 0; }
        }

        public List<int> ProcessThreads
        {
            get { return m_ProcessesThreads; }
            set { m_ProcessesThreads = value; }
        }

        public List<ChatWindow> ChatWindows
        {
            get { return m_ChatWindows; }
            protected set { m_ChatWindows = value; }
        }

        public WebHelper()
        {
            ProcessThreads = new List<int>();
            ChatWindows = new List<ChatWindow>();
        }

        public void UpdateThreads()
        {
            ProcessThreads.Clear();
            Process[] targets = Process.GetProcessesByName("steamwebhelper");
            for (int i = 0; i < targets.Length; i++)
            {
                foreach (ProcessThread thread in targets[i].Threads)
                {
                    ProcessThreads.Add(thread.Id);
                }
            }
        }

        public void GetChatWindows()
        {
            ChatWindows.Clear();
            foreach (int processThreadId in ProcessThreads)
            {
                EnumThreadWindows(processThreadId, new EnumThreadWindowsCallback((hwnd, lparam) =>
                {
                    StringBuilder className = new StringBuilder(260);
                    GetClassName(hwnd, className, 260);

                    if (className.ToString() == "SDL_app")
                    {
                        StringBuilder windowText = new StringBuilder(260);
                        GetWindowText(hwnd, windowText, 260);

                        if (windowText.ToString() != "Friends List")
                        {
                            ChatWindow window = ChatWindow.FromHandle(hwnd);
                            ChatWindows.Add(window);

                            Console.WriteLine("Detected chat window: " + windowText.ToString());
                        }
                    }

                    return true;
                }), IntPtr.Zero);
            }
        }

        private List<ChatWindow> m_ChatWindows;
        private List<int> m_ProcessesThreads;
    }
}
