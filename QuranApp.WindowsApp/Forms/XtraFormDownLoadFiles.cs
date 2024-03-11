using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QuranApp.WindowsApp.Forms
{
    public partial class XtraFormDownLoadFiles : XtraForm
    {
        public XtraFormDownLoadFiles()
        {
            InitializeComponent();
        }

        private void XtraFormDownloadLanguages_Shown(object sender, EventArgs e)
        {
            if (!Directory.Exists(GlobalVariables.Files))
            {
                Directory.CreateDirectory(GlobalVariables.Files);
            }

            if (!Directory.Exists(GlobalVariables.ArabicImages))
            {
                Directory.CreateDirectory(GlobalVariables.ArabicImages);
            }

            try
            {

                Parallel.For(0, 605, i =>
                {
                    string url = GlobalVariables.ArabicFilesRootUrl + i + ".png";
                    string file = GlobalVariables.ArabicImages + "\\" + i + ".png";
                    if (!File.Exists(file))
                    {
                        using (WebClient client = new WebClient())
                        {
                            
                            client.DownloadFile(url, file);
                        }

                    }
                });

                XtraMessageBox.Show("Dosyalar indirildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception exception)
            {
                XtraMessageBox.Show(exception.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Close();
        }
    }
}