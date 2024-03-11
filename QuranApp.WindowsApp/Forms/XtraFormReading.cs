using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Emf;

namespace QuranApp.WindowsApp.Forms
{
    public partial class XtraFormReading : DevExpress.XtraEditors.XtraForm
    {
        public string SplitLayoutPath => Path.Combine(GlobalVariables.Layouts, "XtraFormReading.xml");

        int pagemin, pagemax;
        public XtraFormReading()
        {
            InitializeComponent();
        }

        private void buttonEditGotoPage_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption == "Sayfaya Git")
            {
                int page;
                string s = buttonEditGotoPage.EditValue?.ToString();
                if (!Int32.TryParse(s, out page)) return;


                if (page % 2 == 0)
                {
                    pagemin = page;
                    pagemax = page + 1;
                }
                else
                {
                    pagemin = page - 1;
                    pagemax = page;
                }
            }
            else if (e.Button.Caption == "Önceki")
            {

                pagemin -= 2;
                pagemax -= 2;
            }
            else if (e.Button.Caption == "Sonraki")
            {
                pagemin += 2;
                pagemax += 2;
            }

            SetPage();
        }

        private void XtraFormReading_FormClosing(object sender, FormClosingEventArgs e)
        {
            splitContainerControl.SaveLayoutToXml(SplitLayoutPath);
        }

        private void XtraFormReading_Load(object sender, EventArgs e)
        {
            int i = Properties.Settings.Default.LastMinPage;

            pagemin = i;
            pagemax = i + 1;

            SetPage();

            if (File.Exists(SplitLayoutPath))
            {
                splitContainerControl.RestoreLayoutFromXml(SplitLayoutPath);
            }
        }

        private void SetPage()
        {
            string path = Properties.Settings.Default.FilesPath;
            string rightPage = Path.Combine(path, "Arabic", pagemin + ".png");
            string leftPage = Path.Combine(path, "Arabic", pagemax + ".png");

            pictureEditRightPage.Image = Image.FromFile(rightPage);
            textEditRight.Text = pagemin.ToString();
            pictureEditLeftPage.Image = Image.FromFile(leftPage);
            textEditLeft.Text = pagemax.ToString();

            Properties.Settings.Default.LastMinPage = pagemin;
            Properties.Settings.Default.Save();
        }
    }
}