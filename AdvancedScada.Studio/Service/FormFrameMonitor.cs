using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AdvancedScada.DriverBase.Common;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace AdvancedScada.Studio.Service
{
    public partial class FormFrameMonitor : XtraForm
    {
       
        public FormFrameMonitor()
        {
            InitializeComponent();
        }
        private string bytesTostring(byte[] data)
        {
            var ret = string.Empty;
            foreach (var item in data) ret += $"{item}";
            return ret;
        }
        private string stringsTostring(string[] data)
        {
            var ret = string.Empty;
            foreach (var item in data) ret += $"{item}/";
            return ret;
        }
        private string boolsTostring(bool[] data)
        {
            var ret = string.Empty;
            foreach (var item in data) ret += $"{item}/";
            return ret;
        }
        private void FormFrameMonitor_Load(object sender, EventArgs e)
        {

        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
           

        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            

        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {

            


        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            var val = $"{gridView1.GetRowCellValue(e.RowHandle, colType)}";


            if (val != null || val != string.Empty)
            {
                if (val == "Reception" || val == "0") e.Appearance.ForeColor = Color.Red;
                else e.Appearance.ForeColor = Color.Blue;

            }
        }
    }
}