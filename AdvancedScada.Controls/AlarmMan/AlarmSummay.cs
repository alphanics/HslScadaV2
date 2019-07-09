using AdvancedScada.Controls;
using AdvancedScada.Controls.AlarmMan.Designers;
using AdvancedScada.Controls.Drivers;
using AdvancedScada.Controls.Subscription;
using AdvancedScada.DriverBase.Common;
using HslScadaControls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;



namespace AdvancedScada.Controls
{
    [DefaultEvent("DataChanged"), Designer(typeof(ListViewDesigner))]
    public partial class AlarmSummay
    {
        private bool InstanceFieldsInitialized = false;

        private void InitializeInstanceFields()
        {
            drsd = DataReturnedSync;
            dcsd = DataChangedSync;
        }

        public event EventHandler<PlcComEventArgs> DataReturned;
        public event EventHandler<PlcComEventArgs> DataChanged;
        public event EventHandler<PlcComEventArgs> ComError;
        public event EventHandler SuccessfulSubscription;
        private int intCount = 0;
        private string nTime = "2017/12/18 16:44:02";
        private string nTagName = "TagName";
        private string nTagValue = "15135";
        private string[] nTagStatus = new string[4] { "Alarm On", "Alarm oFF", "Alarm Ack", "Alarm Variation" };
        private Color[] nColor = new Color[4] { Color.Red, Color.Green, Color.Blue, Color.Yellow };
        #region Constructor/Destructor
        public List<string> _nListViewColumns = new List<string>();
        public List<Color> _nListViewColumnsColor = new List<Color>();
        public ColumnHeader[] nColumns;
        private iniClass inicls = new iniClass();
        public void RListViewColumns()
        {

            ListView1.View = View.Details;
            ListView1.FullRowSelect = true;
            ListView1.GridLines = true;
            ListView1.Columns.Clear();
            ListView1.Items.Clear();
            ListView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            ListView1.BackColor = Color.FromArgb(Convert.ToInt32(inicls.GetIniValue("Alarm Type", "BackGround.BackColor", "C:\\Settings.ini")));
            ListView1.Sorting = SortOrder.Ascending;
            ListView1.ListViewItemSorter = new ListViewItemComparer();
            ListView1.Sort();

            for (int i = 0; i < _nListViewColumns.Count; i++)
            {
                ListView1.Columns.Add(_nListViewColumns[i].ToString(), 130, HorizontalAlignment.Left);
            }

            for (var index = 0; index <= 19; index++)
            {
                string[] row0 = { nTime, nTagName, nTagValue, nTagStatus[intCount] };
                ListViewItem item = new ListViewItem(row0);
                item.ForeColor = _nListViewColumnsColor[intCount];
                this.ListView1.Items.Insert(0, item);
                intCount = intCount + 1;
                if (intCount == 3)
                {
                    intCount = 0;
                }

            }
        }

        public AlarmSummay()
        {

            if (!InstanceFieldsInitialized)
            {
                InitializeInstanceFields();
                InstanceFieldsInitialized = true;
            }
            InitializeComponent();
            ListView1.View = View.Details;
            ListView1.FullRowSelect = true;
            ListView1.GridLines = true;
            ListView1.Columns.Clear();
            ListView1.Items.Clear();
            ListView1.Columns.Add("Time", 130, HorizontalAlignment.Left);
            ListView1.Columns.Add("Tag Name", 130, HorizontalAlignment.Left);
            ListView1.Columns.Add("Tag Value", 130, HorizontalAlignment.Left);
            ListView1.Columns.Add("Tag Status", 320, HorizontalAlignment.Left);
            ListView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;

            for (var index = 0; index <= 19; index++)
            {
                string[] row0 = { nTime, nTagName, nTagValue, nTagStatus[intCount] };
                ListViewItem item = new ListViewItem(row0);
                item.ForeColor = nColor[intCount];
                this.ListView1.Items.Insert(0, item);
                intCount = intCount + 1;
                if (intCount == 3)
                {
                    intCount = 0;
                }

            }

        }

        protected override void Dispose(bool disposing)
        {


            try
            {
                if (disposing)
                {
                    if (SubScriptions != null)
                    {
                        SubScriptions.UnsubscribeAll();
                        SubScriptions.Dispose();
                    }
                    m_PLCAddressValueItems.CollectionChanged -= SubscribedItemsChanged;
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }


        #endregion
        #region Basic Properties
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            if (this.DesignMode && this.Parent != null && this.Parent.Site != null)
            {
                if (base.Site.DesignMode)
                {

                }
            }
        }
        private void DataSubscriberlistView_DataChanged(string senderPlcAddress, PlcComEventArgs e)
        {
            string LastValue = string.Empty;
            if (e.PlcAddress == senderPlcAddress)
            {
                string[] row0 = { e.PlcAddress, e.Values[0], DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") };

                if (e.Values[0] != LastValue)
                {
                    LastValue = e.Values[0];
                    //* Do something here for the value changed
                    if (LastValue == "True")
                    {
                        bool flag = false;
                        foreach (ListViewItem listViewItem in this.ListView1.Items)
                        {
                            if (listViewItem.Text == row0[0] && listViewItem.SubItems[2].Text.Substring(14, 2) == row0[2].Substring(14, 2))
                            {
                                listViewItem.ForeColor = _nListViewColumnsColor[3];
                                if (listViewItem.SubItems[1].Text != row0[1])
                                {
                                    listViewItem.SubItems[1].Text = row0[1];
                                }
                                if (listViewItem.SubItems[2].Text != row0[2])
                                {
                                    listViewItem.SubItems[2].Text = row0[2];
                                }

                                flag = true;
                                break;
                            }
                        }
                        if (!flag)
                        {
                            ListViewItem item = new ListViewItem(row0);
                            item.ForeColor = _nListViewColumnsColor[3];
                            this.ListView1.Items.Insert(0, item);
                        }
                    }
                    else if (LastValue == "False")
                    {
                        string[] row1 = { e.PlcAddress, e.Values[0], DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") };

                        bool flag = false;
                        foreach (ListViewItem listViewItem in this.ListView1.Items)
                        {
                            if (listViewItem.Text == row0[0] && listViewItem.SubItems[2].Text.Substring(14, 2) == row0[2].Substring(14, 2))
                            {
                                listViewItem.ForeColor = _nListViewColumnsColor[0];
                                if (listViewItem.SubItems[1].Text != row1[1])
                                {
                                    listViewItem.SubItems[1].Text = row1[1];
                                }
                                if (listViewItem.SubItems[2].Text != row1[2])
                                {
                                    listViewItem.SubItems[2].Text = row1[2];
                                }
                                flag = true;
                                break;
                            }
                        }
                        if (!flag)
                        {
                            ListViewItem item = new ListViewItem(row1);
                            item.ForeColor = _nListViewColumnsColor[0];
                            this.ListView1.Items.Insert(0, item);
                        }
                    }
                }
            }
        }

        //**************************************************
        //* Its purpose is to fetch
        //* the main form in order to synchronize the
        //* notification thread/event
        //**************************************************
        protected System.ComponentModel.ISynchronizeInvoke m_SynchronizingObject;
        //* do not let this property show up in the property window
        // <System.ComponentModel.Browsable(False)> _
        public System.ComponentModel.ISynchronizeInvoke SynchronizingObject
        {
            get
            {
                System.ComponentModel.Design.IDesignerHost host1 = null;
                if ((m_SynchronizingObject == null) && base.DesignMode)
                {
                    host1 = (System.ComponentModel.Design.IDesignerHost)this.GetService(typeof(System.ComponentModel.Design.IDesignerHost));
                    if (host1 != null)
                    {
                        m_SynchronizingObject = (System.ComponentModel.ISynchronizeInvoke)host1.RootComponent;
                    }
                }

                return m_SynchronizingObject;
            }

            set
            {
                if (value != null)
                {
                    m_SynchronizingObject = value;
                }
            }
        }

        protected string m_Value;
        public string Value
        {
            get
            {
                return m_Value;
            }
            set
            {
                m_Value = value;
            }
        }

        #endregion
        #region PLC Related Properties

        private int _PollRate;
        public int PollRate
        {
            get
            {
                return _PollRate;
            }
            set
            {
                _PollRate = value;
            }
        }


        //*****************************************
        //* Property - Address in PLC to Link to
        //*****************************************
        private System.Collections.ObjectModel.ObservableCollection<PLCAddressItem> m_PLCAddressValueItems = new System.Collections.ObjectModel.ObservableCollection<PLCAddressItem>();
        [System.ComponentModel.Category("PLC Properties"), System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public System.Collections.ObjectModel.ObservableCollection<PLCAddressItem> PLCAddressValueItems
        {
            get
            {
                return m_PLCAddressValueItems;
            }

        }




        #endregion
        #region Events
        protected virtual void OnDataReturned(PlcComEventArgs e)
        {
            if (m_SynchronizingObject == null)
            {
                if (DataReturned != null)
                    DataReturned(this, e);
            }
            else
            {
                if (((Control)m_SynchronizingObject).IsHandleCreated)
                {
                    object[] Parameters = { this, e };
                    SynchronizingObject.BeginInvoke(drsd, Parameters);
                }
            }
        }

        //****************************************************************************
        //* This is required to sync the event back to the parent form's main thread
        //****************************************************************************
        private EventHandler<PlcComEventArgs> drsd;
        private void DataReturnedSync(object sender, PlcComEventArgs e)
        {
            if (DataReturned != null)
                DataReturned(this, e);
        }


        protected virtual void OnDataChanged(PlcComEventArgs e)
        {
            if (m_SynchronizingObject == null)
            {
                if (DataChanged != null)
                    DataChanged(this, e);
            }
            else
            {
                if (((Control)m_SynchronizingObject).IsHandleCreated)
                {
                    object[] Parameters = { this, e };
                    SynchronizingObject.BeginInvoke(dcsd, Parameters);
                }
            }
        }

        //****************************************************************************
        //* This is required to sync the event back to the parent form's main thread
        //****************************************************************************
        private EventHandler<PlcComEventArgs> dcsd;
        private void DataChangedSync(object sender, PlcComEventArgs e)
        {
            if (DataChanged != null)
                DataChanged(this, e);
        }


        protected virtual void OnSuccessfulSubscription(PlcComEventArgs e)
        {
            if (SuccessfulSubscription != null)
                SuccessfulSubscription(this, e);
        }

        protected virtual void OnComError(PlcComEventArgs e)
        {
            if (ComError != null)
                ComError(this, e);
        }

        protected virtual void SubscribedItemsChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //* Ver 3.99b - Added Not Initializing
            if (!this.DesignMode)
            {
                if (SubScriptions != null)
                {
                    SubScriptions.UnsubscribeAll();
                }
                SubscribeToComDriver();
            }
        }
        #endregion
        #region Subscribing and PLC data receiving
        private SubscriptionHandler SubScriptions;
        //**************************************************
        //* Subscribe to addresses in the Comm(PLC) Driver
        //**************************************************
        protected void SubscribeToComDriver()
        {
            if (!DesignMode)
            {
                //If (m_SynchronizingObject Is Nothing OrElse DirectCast(m_SynchronizingObject, Control).IsHandleCreated) Then
                //* Create a subscription handler object
                if (SubScriptions == null)
                {
                    SubScriptions = new SubscriptionHandler();
                    SubScriptions.Parent = this;
                    SubScriptions.DisplayError += DisplaySubscribeError;
                }

                m_PLCAddressValueItems.CollectionChanged += SubscribedItemsChanged;

                for (var index = 0; index < m_PLCAddressValueItems.Count; index++)
                {
                    if (!string.IsNullOrEmpty(m_PLCAddressValueItems[index].PLCAddress))
                    {
                        //Dim AddressList() As String
                        //AddressList = m_PLCAddressValue.Split(","c)

                        //For i = 0 To AddressList.Count - 1
                        //If Not SubscribedValueList.ContainsKey(AddressList(i)) Then
                        //* We must pass the address as a property name so the subscriptionHandler doesn't confuse the next address as a change for the same property
                        SubScriptions.SubscribeTo(m_PLCAddressValueItems[index].PLCAddress, m_PLCAddressValueItems[index].NumberOfElements, PolledDataReturned, m_PLCAddressValueItems[index].PLCAddress, 1, 0);

                        //SubscribedValueList.TryAdd(m_PLCAddressValueItems(index), "")

                        PlcComEventArgs x = new PlcComEventArgs(0, string.Empty);
                        x.PlcAddress = m_PLCAddressValueItems[index].PLCAddress;
                        OnSuccessfulSubscription(x);
                        //End If
                        //Next
                    }
                }


            }
        }

        //***************************************
        //* Call backs for returned data
        //***************************************
        private string OriginalText;
        private void PolledDataReturned(object sender, SubscriptionHandlerEventArgs e)
        {
            if (e.PLCComEventArgs.ErrorId == 0)
            {
                try
                {
                    if (string.IsNullOrEmpty(e.SubscriptionDetail.PropertyNameToSet) || string.Compare(e.SubscriptionDetail.PropertyNameToSet, e.PLCComEventArgs.PlcAddress, true) == 0)
                    {
                        PolledDataReturnedValue(sender, e.PLCComEventArgs);
                    }
                    else if (e.SubscriptionDetail.PropertyNameToSet == "Value")
                    {
                        PolledDataReturnedValue(sender, e.PLCComEventArgs);
                    }
                    else
                    {
                        //* Write the value to the property that came from the end of the PLCAddress... property name
                        try
                        {
                            //* Write the value to the property that came from the end of the PLCAddress... property name
                            this.GetType().GetProperty(e.SubscriptionDetail.PropertyNameToSet).SetValue(this, Utilities.DynamicConverter(e.PLCComEventArgs.Values[0], this.GetType().GetProperty(e.SubscriptionDetail.PropertyNameToSet).PropertyType), null);
                        }
                        catch (Exception ex)
                        {
                            //OnDisplayError("INVALID VALUE RETURNED!" & a.PLCComEventArgs.Values(0))
                        }


                    }
                }
                catch (Exception ex)
                {
                    DisplayError("INVALID VALUE!" + ex.Message);
                }
            }
            else
            {
                DisplayError("Com Error " + e.PLCComEventArgs.ErrorId + "." + e.PLCComEventArgs.ErrorMessage);
            }
        }


        //***************************************
        //* Call backs for returned data
        //***************************************
        private string LastValue;
        private void PolledDataReturnedValue(object sender, PlcComEventArgs e)
        {
            try
            {
                //* Fire this event every time data is returned
                OnDataReturned(e);

                for (var index = 0; index < m_PLCAddressValueItems.Count; index++)
                {
                    if (string.Compare(e.PlcAddress, m_PLCAddressValueItems[index].PLCAddress, true) == 0)
                    {
                        if (e.Values[0] != m_PLCAddressValueItems[index].LastValue)
                        {
                            //* Save this value so we know if it changed without comparing the invert
                            //SubscribedValueList(e.PlcAddress) = e.Values(0)
                            m_PLCAddressValueItems[index].LastValue = e.Values[0];
                            if (!DesignMode)
                            {
                                DataSubscriberlistView_DataChanged(m_PLCAddressValueItems[index].PLCAddress, e);

                            }

                            OnDataChanged(e);
                        }
                    }
                }

            }
            catch
            {
                DisplayError("INVALID VALUE RETURNED!");
            }
        }

        private void DisplaySubscribeError(object sender, PlcComEventArgs e)
        {
            DisplayError(e.ErrorMessage);
        }
        #endregion
        #region Error Display
        //********************************************************
        //* Show an error via the text property for a short time
        //********************************************************
        private System.Windows.Forms.Timer ErrorDisplayTime;
        private void DisplayError(string ErrorMessage)
        {
            if (ErrorDisplayTime == null)
            {
                ErrorDisplayTime = new System.Windows.Forms.Timer();
                ErrorDisplayTime.Tick += ErrorDisplay_Tick;
                ErrorDisplayTime.Interval = 5000;
            }

            //* Save the text to return to
            if (!ErrorDisplayTime.Enabled)
            {
                // OriginalText = Me.Text
            }

            OnComError(new PlcComEventArgs(1, ErrorMessage));

            ErrorDisplayTime.Enabled = true;
        }


        //**************************************************************************************
        //* Return the text back to its original after displaying the error for a few seconds.
        //**************************************************************************************
        private void ErrorDisplay_Tick(object sender, System.EventArgs e)
        {
            if (ErrorDisplayTime != null)
            {
                ErrorDisplayTime.Enabled = false;
                ErrorDisplayTime.Dispose();
                ErrorDisplayTime = null;
            }
        }
        #endregion
        #region Public Methods
        public string GetValueByName(string name)
        {
            int index = 0;
            while (index < m_PLCAddressValueItems.Count)
            {
                if (string.Compare(m_PLCAddressValueItems[index].Name, name, true) == 0)
                {
                    return m_PLCAddressValueItems[index].LastValue;
                }
                index += 1;
            }

            return string.Empty;
        }
        private string path = Application.StartupPath + "\\Settings.ini";
        private void AlarmSummay_Load(object sender, EventArgs e)
        {
            try
            {


                if (!DesignMode)
                {
                    ListView1.Items.Clear();
                    _nListViewColumnsColor.Clear();

                    _nListViewColumnsColor.Add(Color.FromArgb(Convert.ToInt32(inicls.GetIniValue("Alarm Type", "Button6.BackColor", path))));
                    _nListViewColumnsColor.Add(Color.FromArgb(Convert.ToInt32(inicls.GetIniValue("Alarm Type", "Button7.BackColor", path))));
                    _nListViewColumnsColor.Add(Color.FromArgb(Convert.ToInt32(inicls.GetIniValue("Alarm Type", "Button8.BackColor", path))));
                    _nListViewColumnsColor.Add(Color.FromArgb(Convert.ToInt32(inicls.GetIniValue("Alarm Type", "Button9.BackColor", path))));
                    _nListViewColumnsColor.Add(Color.FromArgb(Convert.ToInt32(inicls.GetIniValue("Alarm Type", "BackGround.BackColor", path))));
                    var ItemsCount = inicls.GetIniValue("Display Format", "ListBoxSelectedItemsCount", path);
                    for (int i = 0; string.CompareOrdinal(i.ToString(), ItemsCount) < 0; i++)
                    {

                        _nListViewColumns.Add(inicls.GetIniValue("Display Format", "ListBoxSelected.Items" + Convert.ToString(i), path));

                    }
                    //   _nListViewColumns.Add(inicls.GetIniValue("Display Format", "ListBoxSelected.Items" + Convert.ToString(i), "C:\Settings.ini"))
                    ListView1.View = View.Details;
                    ListView1.FullRowSelect = true;
                    ListView1.GridLines = true;
                    ListView1.Columns.Clear();
                    ListView1.Items.Clear();
                    ListView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
                    ListView1.BackColor = Color.FromArgb(Convert.ToInt32(inicls.GetIniValue("Alarm Type", "BackGround.BackColor", path)));
                    for (int i = 0; i < _nListViewColumns.Count; i++)
                    {
                        ListView1.Columns.Add(_nListViewColumns[i].ToString(), 130, HorizontalAlignment.Left);
                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }

        }







        #endregion
    }

}