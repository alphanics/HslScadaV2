using AdvancedScada.BaseService;
using AdvancedScada.BaseService.Client;
using AdvancedScada.DriverBase;
using AdvancedScada.IBaseService;
using AdvancedScada.IBaseService.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdvancedScada.HMI
{
    public partial class Form1 : Window
    {
        public IReadService client = null;
        public Form1()
        {
            //ReadServiceCallbackClient.LoadTagCollection();
            //XCollection.CURRENT_MACHINE = new Machine
            //{
            //    MachineName = Environment.MachineName,
            //    Description = "Free"
            //};
            //IPAddress[] hostAddresses = Dns.GetHostAddresses(Dns.GetHostName());
            //foreach (IPAddress iPAddress in hostAddresses)
            //{
            //    if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
            //    {
            //        XCollection.CURRENT_MACHINE.IPAddress = $"{iPAddress}";
            //        break;
            //    }
            //}
            //client = DriverHelper.GetInstance().GetReadService();
            //client.Connect(XCollection.CURRENT_MACHINE);

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           /// client?.Disconnect(XCollection.CURRENT_MACHINE);
        }
    }
}
