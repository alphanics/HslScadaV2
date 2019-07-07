﻿using AdvancedScada.Controls.AHMI.ImageAll.Symbols;
using AdvancedScada.Controls.AHMI.Licenses;
using AdvancedScada.Controls.DialogEditor;
using AdvancedScada.ImagePicker;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace AdvancedScada.Controls.AHMI.ImageAll
{
    [Designer(typeof(ImageContainerDesigner))]
    [ToolboxItem(true)]
    public class HMIImageContainer : GraphicIndicatorBase
    {
        //*****************************************
        //* Property - Address in PLC to Link to
        //*****************************************
        private string m_PLCAddressClick = string.Empty;

        //*****************************************
        //* Property - Address in PLC to Link to
        //*****************************************
        private string m_PLCAddressSelect1 = string.Empty;

        //*****************************************
        //* Property - Address in PLC to Link to
        //*****************************************
        private string m_PLCAddressSelect2 = string.Empty;


        //*****************************************
        //* Property - Address in PLC to Link to
        //*****************************************
        private string m_PLCAddressText2 = string.Empty;

        //*****************************************
        //* Property - Address in PLC to Link to
        //*****************************************
        private string m_PLCAddressVisible = string.Empty;

        private string OriginalText;

        [Category("PLC Properties")]
        [Editor(typeof(TestDialogEditor), typeof(UITypeEditor))]
        public string PLCAddressValueSelect1
        {
            get { return m_PLCAddressSelect1; }
            set
            {
                if (m_PLCAddressSelect1 != value)
                {
                    m_PLCAddressSelect1 = value;

                    try
                    {

                    }
                    catch (Exception ex)
                    {
                        DisplayError(ex.Message);
                    }



                }

            }
        }

        [Category("PLC Properties")]
        [Editor(typeof(TestDialogEditor), typeof(UITypeEditor))]
        public string PLCAddressValueSelect2
        {
            get { return m_PLCAddressSelect2; }
            set
            {
                if (m_PLCAddressSelect2 != value)
                {
                    m_PLCAddressSelect2 = value;
                    //* When address is changed, re-subscribe to new address
                    try
                    {


                    }
                    catch (Exception ex)
                    {
                        DisplayError(ex.Message);
                    }
                }
            }
        }

        [Category("PLC Properties")]
        [Editor(typeof(TestDialogEditor), typeof(UITypeEditor))]
        public string PLCAddressVisible
        {
            get { return m_PLCAddressVisible; }
            set
            {
                if (m_PLCAddressVisible != value)
                {
                    m_PLCAddressVisible = value;
                    //* When address is changed, re-subscribe to new address
                    try
                    {

                    }
                    catch (Exception ex)
                    {
                        DisplayError(ex.Message);
                    }
                }
            }
        }

        [Category("PLC Properties")]
        [Editor(typeof(TestDialogEditor), typeof(UITypeEditor))]
        public string PLCAddressText2
        {
            get { return m_PLCAddressText2; }
            set
            {
                if (m_PLCAddressText2 != value) m_PLCAddressText2 = value;
            }
        }

        [Category("PLC Properties")]
        [Editor(typeof(TestDialogEditor), typeof(UITypeEditor))]
        public string PLCAddressClick
        {
            get { return m_PLCAddressClick; }
            set { m_PLCAddressClick = value; }
        }

        [DefaultValue(false)]
        public bool SuppressErrorDisplay { get; set; }

        #region "Error Display"

        //********************************************************
        //* Show an error via the text property for a short time
        //********************************************************
        private Timer ErrorDisplayTime;

        private void DisplayError(string ErrorMessage)
        {
            if (!SuppressErrorDisplay)
            {
                if (ErrorDisplayTime == null)
                {
                    ErrorDisplayTime = new Timer();
                    ErrorDisplayTime.Tick += ErrorDisplay_Tick;
                    ErrorDisplayTime.Interval = 5000;
                }

                //* Save the text to return to
                if (!ErrorDisplayTime.Enabled) OriginalText = Text;

                ErrorDisplayTime.Enabled = true;

                Text = ErrorMessage;
            }
        }

        //**************************************************************************************
        //* Return the text back to its original after displaying the error for a few seconds.
        //**************************************************************************************
        private void ErrorDisplay_Tick(object sender, EventArgs e)
        {
            Text = OriginalText;

            if (ErrorDisplayTime != null)
            {
                ErrorDisplayTime.Enabled = false;
                ErrorDisplayTime.Dispose();
                ErrorDisplayTime = null;
            }
        }

        #endregion
    }

    internal class ImageContainerDesigner : ControlDesigner
    {
        private DesignerActionListCollection actionLists;

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (actionLists == null)
                {
                    actionLists = new DesignerActionListCollection();
                    actionLists.Add(new ImageContainerListItem(this));
                }

                return actionLists;
            }
        }
    }

    internal class ImageContainerListItem : DesignerActionList
    {
        private readonly HMIImageContainer _HMIImageContainer;

        public ImageContainerListItem(ImageContainerDesigner owner)
            : base(owner.Component)
        {
            _HMIImageContainer = (HMIImageContainer)owner.Component;
        }


        public Color BackColor
        {
            get { return _HMIImageContainer.BackColor; }
            set { _HMIImageContainer.BackColor = value; }
        }

        public Color ForeColor
        {
            get { return _HMIImageContainer.ForeColor; }
            set { _HMIImageContainer.ForeColor = value; }
        }

        public System.Drawing.Image ImageName
        {
            get { return _HMIImageContainer.BackgroundImage; }
            set { _HMIImageContainer.BackgroundImage = value; }
        }

        public override DesignerActionItemCollection GetSortedActionItems()
        {
            var items = new DesignerActionItemCollection();
            items.Add(new DesignerActionTextItem("DXLibraryImages", "DXLibraryImages"));
            items.Add(new DesignerActionMethodItem(this, "ShowTagDesignerForm", "Choote Tag"));
            items.Add(new DesignerActionPropertyItem("BackColor", "BackColor"));
            items.Add(new DesignerActionPropertyItem("ForeColor", "ForeColor"));

            return items;
        }

        public void ShowTagDesignerForm()
        {
            var frm = new MainView();
            frm.OnImagSelected_Clicked += ImageName1 => { SetProperty(_HMIImageContainer, "Image", ImageName1); };
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        public void SetProperty(Control control, string propertyName, object value)
        {
            var pd = TypeDescriptor.GetProperties(control)[propertyName];
            pd.SetValue(control, value);
        }
    }
}
