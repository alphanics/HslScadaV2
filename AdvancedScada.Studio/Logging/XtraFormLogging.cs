using System;
using System.ComponentModel;

namespace HslScada.Studio.Logging
{
    public partial class XtraFormLogging : DevExpress.XtraEditors.XtraForm
    {
        private System.ComponentModel.BindingList<Logger> bLoggers;
        public XtraFormLogging()
        {
            InitializeComponent();
        }

        private void XtraFormLogging_Load(object sender, EventArgs e)
        {
            bLoggers = new BindingList<Logger>(Logger.Loggers);
            realTimeSource1.DataSource = bLoggers;
            GridView1.Invalidate();
        }
    }
}