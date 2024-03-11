using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using QuranApp.WindowsApp.Forms;

namespace QuranApp.WindowsApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CreateDirectories();

            Application.Run(new Form1());
        }

        private static void CreateDirectories()
        {
            // create layout directory if not exists on app startup
            if (!System.IO.Directory.Exists(GlobalVariables.Layouts))
            {
                System.IO.Directory.CreateDirectory(GlobalVariables.Layouts);
            }

            // create files directory if not exists on app startup
            if (!System.IO.Directory.Exists(GlobalVariables.Files))
            {
                System.IO.Directory.CreateDirectory(GlobalVariables.Files);
            }

            // create arabic images directory if not exists on app startup
            if (!System.IO.Directory.Exists(GlobalVariables.ArabicImages))
            {
                System.IO.Directory.CreateDirectory(GlobalVariables.ArabicImages);
            }
        }
    }
}
