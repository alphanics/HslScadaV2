using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AdvancedScada.DriverBase.Devices;

namespace AdvancedScada.Studio.Monitor
{
    public partial class Frm_DeviceTraffc : DevExpress.XtraEditors.XtraForm
    {
        private BindingList<Device> bS7Device;
        public Frm_DeviceTraffc()
        {
            InitializeComponent();
        }

        public Frm_DeviceTraffc(BindingList<Device> bS7Device)
        {
            InitializeComponent();
            this.bS7Device = bS7Device;
        }

        private void Frm_DeviceTraffc_Load(object sender, EventArgs e)
        {
           
            RealTimeSource1.DataSource = bS7Device;
            gvDevice.Invalidate();
        }

        private void gvDevice_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            var val = $"{gvDevice.GetRowCellValue(e.RowHandle, colStatus)}";


            if (val != null || val != string.Empty)
            {
                if (val == "Disconnection") e.Appearance.ForeColor = Color.Red;
                else e.Appearance.ForeColor = Color.Green;

            }
        }
    }
}