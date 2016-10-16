using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuickReturnTraderChat
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormMain());
            Application.Run(new  Main());
        }
    }
}