using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuranApp.WindowsApp.Forms;

namespace QuranApp.WindowsApp
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            XtraFormDownLoadFiles xtraFormDownLoadFiles = new XtraFormDownLoadFiles();
            xtraFormDownLoadFiles.ShowDialog();
        }
    }
}
