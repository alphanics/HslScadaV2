using AdvancedScada.BaseService;
using AdvancedScada.BaseService.Client;
using AdvancedScada.DriverBase;
using AdvancedScada.IBaseService;
using AdvancedScada.IBaseService.Common;
using System;
using System.Net;
using System.Net.Sockets;
using System.Windows;

namespace HslScada.Scada
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IReadService client = null;
        public MainWindow()
        {
            ReadServiceCallbackClient.LoadTagCollection();
            XCollection.CURRENT_MACHINE = new Machine
            {
                MachineName = Environment.MachineName,
                Description = "Free"
            };
            IPAddress[] hostAddresses = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress iPAddress in hostAddresses)
            {
                if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
                {
                    XCollection.CURRENT_MACHINE.IPAddress = $"{iPAddress}";
                    break;
                }
            }
            client = DriverHelper.GetInstance().GetReadService();
            client.Connect(XCollection.CURRENT_MACHINE);

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //st1.PLCAddressValue = "CH1.PLC1.DataBlock1.TAG00003";
        }
    }
}
