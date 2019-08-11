namespace AdvancedScada.Studio.Monitor
{
    partial class Frm_DeviceTraffc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_DeviceTraffc));
            this.gcDevice = new DevExpress.XtraGrid.GridControl();
            this.RealTimeSource1 = new DevExpress.Data.RealTimeSource();
            this.gvDevice = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDeviceId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeviceName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcDevice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDevice)).BeginInit();
            this.SuspendLayout();
            // 
            // gcDevice
            // 
            this.gcDevice.DataSource = this.RealTimeSource1;
            this.gcDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDevice.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcDevice.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcDevice.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcDevice.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcDevice.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcDevice.EmbeddedNavigator.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.gcDevice.Location = new System.Drawing.Point(0, 0);
            this.gcDevice.MainView = this.gvDevice;
            this.gcDevice.Name = "gcDevice";
            this.gcDevice.Size = new System.Drawing.Size(676, 386);
            this.gcDevice.TabIndex = 3;
            this.gcDevice.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDevice});
            // 
            // RealTimeSource1
            // 
            this.RealTimeSource1.DisplayableProperties = "Status";
            // 
            // gvDevice
            // 
            this.gvDevice.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDeviceId,
            this.colDeviceName,
            this.colStatus,
            this.colDescription,
            this.gridColumn1});
            this.gvDevice.GridControl = this.gcDevice;
            this.gvDevice.Name = "gvDevice";
            this.gvDevice.OptionsBehavior.Editable = false;
            this.gvDevice.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvDevice.OptionsView.ShowAutoFilterRow = true;
            this.gvDevice.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvDevice.OptionsView.ShowGroupPanel = false;
            this.gvDevice.OptionsView.ShowViewCaption = true;
            this.gvDevice.ViewCaption = "DeviceList";
            this.gvDevice.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvDevice_RowCellStyle);
            // 
            // colDeviceId
            // 
            this.colDeviceId.AppearanceCell.Options.UseTextOptions = true;
            this.colDeviceId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDeviceId.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDeviceId.AppearanceHeader.Options.UseTextOptions = true;
            this.colDeviceId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDeviceId.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDeviceId.Caption = "Device Id";
            this.colDeviceId.FieldName = "DeviceId";
            this.colDeviceId.Name = "colDeviceId";
            this.colDeviceId.OptionsColumn.AllowMove = false;
            this.colDeviceId.OptionsColumn.AllowSize = false;
            this.colDeviceId.OptionsColumn.FixedWidth = true;
            this.colDeviceId.Visible = true;
            this.colDeviceId.VisibleIndex = 0;
            this.colDeviceId.Width = 66;
            // 
            // colDeviceName
            // 
            this.colDeviceName.Caption = "Device Name";
            this.colDeviceName.FieldName = "DeviceName";
            this.colDeviceName.Name = "colDeviceName";
            this.colDeviceName.OptionsColumn.AllowMove = false;
            this.colDeviceName.Visible = true;
            this.colDeviceName.VisibleIndex = 1;
            this.colDeviceName.Width = 110;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsColumn.AllowMove = false;
            this.colStatus.OptionsColumn.AllowSize = false;
            this.colStatus.OptionsColumn.FixedWidth = true;
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 2;
            this.colStatus.Width = 103;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowMove = false;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 3;
            this.colDescription.Width = 160;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            this.gridColumn1.Width = 219;
            // 
            // Frm_DeviceTraffc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 386);
            this.Controls.Add(this.gcDevice);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_DeviceTraffc";
            this.Text = "Frm_DeviceTraffc";
            this.Load += new System.EventHandler(this.Frm_DeviceTraffc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcDevice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDevice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcDevice;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDevice;
        private DevExpress.XtraGrid.Columns.GridColumn colDeviceId;
        private DevExpress.XtraGrid.Columns.GridColumn colDeviceName;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.Data.RealTimeSource RealTimeSource1;
    }
}