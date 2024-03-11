using System.IO;
using System.Windows.Forms;

namespace QuranApp.WindowsApp
{
    public static class GlobalVariables
    {
        public static string Layouts => Application.StartupPath + "\\Layouts";
        public static string Files => Application.StartupPath + "\\Files";

        public static string ArabicImages => Path.Combine(Files, "Arabic");

        public static string ArabicFilesRootUrl => "https://github.com/saitorhan/QuranApp/blob/master/Files/Arabic/";
    }
}