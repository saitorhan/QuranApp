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
                if (page < 0 || page > 604)
                {
                    XtraMessageBox.Show("Geçersiz sayfa numarası", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

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

        private void buttonEditGotoCuz_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int cuz;
            string s = buttonEditGotoCuz.EditValue?.ToString();
            if (!Int32.TryParse(s, out cuz)) return;

            if (cuz <= 0 || cuz > 30)
            {
                XtraMessageBox.Show("Geçersiz cüz numarası", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            pagemin = (cuz - 1) * 20 + 1;

            if (pagemin == 1)
            {
                pagemin -= 1;
            }

            pagemax = pagemin + 1;

            SetPage();
        }

        private void SetPage()
        {
            string rightPage = Path.Combine(GlobalVariables.ArabicImages, pagemin + ".png");
            string leftPage = Path.Combine(GlobalVariables.ArabicImages, pagemax + ".png");

            pictureEditRightPage.Image = Image.FromFile(rightPage);
            textEditRight.Text = pagemin.ToString();
            pictureEditLeftPage.Image = Image.FromFile(leftPage);
            textEditLeft.Text = pagemax.ToString();

            Properties.Settings.Default.LastMinPage = pagemin;
            Properties.Settings.Default.Save();

            labelControlCuzRight.Text = "Cüz " + (pagemin % 20 == 0 ? (pagemin / 20) : (pagemin / 20 + 1));
            labelControlCuzLeft.Text = "Cüz " + ((pagemax / 20) + 1);
        }
    }
}