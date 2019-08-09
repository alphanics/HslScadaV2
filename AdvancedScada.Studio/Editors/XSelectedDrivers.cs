using System;
using System.Windows.Forms;
using AdvancedScada.Management;
using DevExpress.XtraEditors;
using Microsoft.Win32;

namespace AdvancedScada.Studio.Editors
{
    public partial class XSelectedDrivers : XtraForm
    {
        private string DriverTypes;
        public EventSelectedDriversChanged eventSelectedDriversChanged = null;
        public XSelectedDrivers()
        {
            InitializeComponent();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\FormConfiguration", "ChannelTypes", DriverTypes);
            eventSelectedDriversChanged?.Invoke(true);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            eventSelectedDriversChanged?.Invoke(false);

            Close();
        }

        private void XSelectedDrivers_Load(object sender, EventArgs e)
        {
            DriverTypes = $"{Registry.GetValue("HKEY_CURRENT_USER\\Software\\FormConfiguration", "ChannelTypes", null)}";

            cboxSelectedDrivers.Text = DriverTypes;

            // قراءة مصفوفة  البايت الخاصة بالمشروع الثاني
            txtPath.Text = Application.StartupPath + $@"\{DriverTypes.Insert(0, "X")}.Core.dll";
        }

        private void cboxSelectedDrivers_SelectedIndexChanged(object sender, EventArgs e)
        {
            DriverTypes = cboxSelectedDrivers.Text;

            switch (cboxSelectedDrivers.SelectedIndex)
            {
                case 0:
                    picSelectedDrivers.Image= AdvancedScada.Studio.Properties.Resources._0000157_xbc_dn32ua_500;
                    break;
                case 1:
                    picSelectedDrivers.Image = AdvancedScada.Studio.Properties.Resources.PLC_SIEMENS;
                    break;
                case 2:
                    picSelectedDrivers.Image = AdvancedScada.Studio.Properties.Resources.Modbus;
                    break;
                case 3:
                    picSelectedDrivers.Image = AdvancedScada.Studio.Properties.Resources.Panasonic;
                    break;
                 
                default:
                    break;
            }


            // قراءة مصفوفة  البايت الخاصة بالمشروع الثاني
            txtPath.Text = Application.StartupPath + $@"\AdvancedScada.{DriverTypes.Insert(0, "X")}.Core.dll";
        }
    }
}