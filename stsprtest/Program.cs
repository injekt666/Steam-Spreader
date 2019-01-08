using stsprtest.Input;
using stsprtest.Steam;
using System;

namespace stsprtest
{
    class Program
    {
        static void Main(string[] args)
        {
            WebHelper webHelper = new WebHelper();
            webHelper.UpdateThreads();
            webHelper.GetChatWindows();

            // writes hello in each chat window and sends it
            foreach (ChatWindow chatWindow in webHelper.ChatWindows)
            {
                chatWindow.Open();

                Keyboard.InjectKey(false, ScanCode.KEY_H);
                Keyboard.InjectKey(true, ScanCode.KEY_H);

                Keyboard.InjectKey(false, ScanCode.KEY_E);
                Keyboard.InjectKey(true, ScanCode.KEY_E);

                Keyboard.InjectKey(false, ScanCode.KEY_L);
                Keyboard.InjectKey(true, ScanCode.KEY_L);

                Keyboard.InjectKey(false, ScanCode.KEY_L);
                Keyboard.InjectKey(true, ScanCode.KEY_L);
                
                Keyboard.InjectKey(false, ScanCode.KEY_O);
                Keyboard.InjectKey(true, ScanCode.KEY_O);

                //Keyboard.InjectKey(false, ScanCode.RETURN );
                //Keyboard.InjectKey(true, ScanCode.RETURN);
            }

            Console.ReadLine();
        }
    }
}
