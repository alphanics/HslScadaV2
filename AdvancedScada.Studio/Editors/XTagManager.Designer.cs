namespace AdvancedScada.Studio.Editors
{
    partial class XTagManager
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XTagManager));
            this.TagDockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colChannel = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTagId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTagName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.popupMenuLeft = new DevExpress.XtraBars.PopupMenu(this.components);
            this.ItemAddChannel = new DevExpress.XtraBars.BarButtonItem();
            this.ItemAddDevice = new DevExpress.XtraBars.BarButtonItem();
            this.ItemAddDataBlock = new DevExpress.XtraBars.BarButtonItem();
            this.ItemAddTag = new DevExpress.XtraBars.BarButtonItem();
            this.ItemImport = new DevExpress.XtraBars.BarButtonItem();
            this.ItemExport = new DevExpress.XtraBars.BarButtonItem();
            this.ItemCopy = new DevExpress.XtraBars.BarButtonItem();
            this.ItemPaste = new DevExpress.XtraBars.BarButtonItem();
            this.ItemDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barButtonNew = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonOpen = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonSave = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.mDeleteTag = new DevExpress.XtraBars.BarButtonItem();
            this.RItemAddTag = new DevExpress.XtraBars.BarButtonItem();
            this.ItemCopyToTag = new DevExpress.XtraBars.BarButtonItem();
            this.RItemCopy = new DevExpress.XtraBars.BarButtonItem();
            this.RItemPaste = new DevExpress.XtraBars.BarButtonItem();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.popupMenuRight = new DevExpress.XtraBars.PopupMenu(this.components);
            this.PvGridChannel = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.PvGridDevice = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.PvGridDataBlock = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            ((System.ComponentModel.ISupportInitialize)(this.TagDockManager)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PvGridChannel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PvGridDevice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PvGridDataBlock)).BeginInit();
            this.SuspendLayout();
            // 
            // TagDockManager
            // 
            this.TagDockManager.AutoHiddenPanelCaptionShowMode = DevExpress.XtraBars.Docking.AutoHiddenPanelCaptionShowMode.ShowForActivePanel;
            this.TagDockManager.Form = this;
            this.TagDockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
            this.TagDockManager.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.ID = new System.Guid("00e97bd8-5c99-4031-8104-2370694232c7");
            this.dockPanel1.Location = new System.Drawing.Point(823, 26);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(219, 200);
            this.dockPanel1.Size = new System.Drawing.Size(219, 599);
            this.dockPanel1.Text = "Properties";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.PvGridDataBlock);
            this.dockPanel1_Container.Controls.Add(this.PvGridDevice);
            this.dockPanel1_Container.Controls.Add(this.PvGridChannel);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 29);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(212, 567);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 26);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.treeList1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(823, 599);
            this.splitContainerControl1.SplitterPosition = 195;
            this.splitContainerControl1.TabIndex = 27;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colChannel});
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.Size = new System.Drawing.Size(195, 599);
            this.treeList1.StateImageList = this.imageList1;
            this.treeList1.TabIndex = 1;
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            this.treeList1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeList1_MouseDoubleClick);
            this.treeList1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeList1_MouseDown);
            // 
            // colChannel
            // 
            this.colChannel.AppearanceCell.Options.UseFont = true;
            this.colChannel.Caption = "ChannelName";
            this.colChannel.FieldName = "Name";
            this.colChannel.Name = "colChannel";
            this.colChannel.OptionsColumn.AllowEdit = false;
            this.colChannel.OptionsColumn.AllowFocus = false;
            this.colChannel.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.colChannel.OptionsColumn.ReadOnly = true;
            this.colChannel.Visible = true;
            this.colChannel.VisibleIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "TreeView_16x16.png");
            this.imageList1.Images.SetKeyName(1, "Convert_16x16.png");
            this.imageList1.Images.SetKeyName(2, "PublicFix_16x16.png");
            this.imageList1.Images.SetKeyName(3, "User_16x16.png");
            this.imageList1.Images.SetKeyName(4, "HistoryItem_16x16.png");
            this.imageList1.Images.SetKeyName(5, "Tag_16x16.png");
            this.imageList1.Images.SetKeyName(6, "ManageDatasource_16x16.png");
            this.imageList1.Images.SetKeyName(7, "Database_16x16.png");
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(622, 599);
            this.gridControl1.TabIndex = 23;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridControl1_MouseDoubleClick);
            this.gridControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridControl1_MouseDown);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTagId,
            this.colTagName,
            this.colAddress,
            this.colDataType,
            this.colDescription});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowViewCaption = true;
            this.gridView1.ViewCaption = "TagList";
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            // 
            // colTagId
            // 
            this.colTagId.AppearanceCell.Options.UseTextOptions = true;
            this.colTagId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTagId.AppearanceHeader.Options.UseTextOptions = true;
            this.colTagId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTagId.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTagId.Caption = "TagId";
            this.colTagId.FieldName = "TagId";
            this.colTagId.Name = "colTagId";
            this.colTagId.OptionsColumn.AllowEdit = false;
            this.colTagId.OptionsColumn.AllowMove = false;
            this.colTagId.OptionsColumn.ReadOnly = true;
            this.colTagId.Visible = true;
            this.colTagId.VisibleIndex = 0;
            this.colTagId.Width = 50;
            // 
            // colTagName
            // 
            this.colTagName.AppearanceCell.Options.UseTextOptions = true;
            this.colTagName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTagName.AppearanceHeader.Options.UseTextOptions = true;
            this.colTagName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTagName.Caption = "TagName";
            this.colTagName.FieldName = "TagName";
            this.colTagName.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colTagName.Name = "colTagName";
            this.colTagName.OptionsColumn.AllowEdit = false;
            this.colTagName.OptionsColumn.AllowFocus = false;
            this.colTagName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colTagName.OptionsColumn.AllowMove = false;
            this.colTagName.OptionsColumn.ReadOnly = true;
            this.colTagName.OptionsFilter.ShowBlanksFilterItems = DevExpress.Utils.DefaultBoolean.True;
            this.colTagName.Visible = true;
            this.colTagName.VisibleIndex = 1;
            this.colTagName.Width = 120;
            // 
            // colAddress
            // 
            this.colAddress.AppearanceCell.Options.UseTextOptions = true;
            this.colAddress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.Caption = "Address";
            this.colAddress.FieldName = "Address";
            this.colAddress.Name = "colAddress";
            this.colAddress.OptionsColumn.AllowEdit = false;
            this.colAddress.OptionsColumn.AllowFocus = false;
            this.colAddress.OptionsColumn.AllowMove = false;
            this.colAddress.OptionsColumn.ReadOnly = true;
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 2;
            this.colAddress.Width = 57;
            // 
            // colDataType
            // 
            this.colDataType.AppearanceCell.Options.UseTextOptions = true;
            this.colDataType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataType.AppearanceHeader.Options.UseTextOptions = true;
            this.colDataType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataType.Caption = "DataType";
            this.colDataType.FieldName = "DataType";
            this.colDataType.Name = "colDataType";
            this.colDataType.OptionsColumn.AllowEdit = false;
            this.colDataType.OptionsColumn.AllowFocus = false;
            this.colDataType.OptionsColumn.ReadOnly = true;
            this.colDataType.Visible = true;
            this.colDataType.VisibleIndex = 3;
            this.colDataType.Width = 64;
            // 
            // colDescription
            // 
            this.colDescription.AppearanceCell.Options.UseTextOptions = true;
            this.colDescription.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.colDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "Description";
            this.colDescription.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowEdit = false;
            this.colDescription.OptionsColumn.AllowFocus = false;
            this.colDescription.OptionsColumn.ReadOnly = true;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 4;
            this.colDescription.Width = 200;
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 26);
            this.barDockControlLeft.Manager = null;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 599);
            // 
            // popupMenuLeft
            // 
            this.popupMenuLeft.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.ItemAddChannel),
            new DevExpress.XtraBars.LinkPersistInfo(this.ItemAddDevice),
            new DevExpress.XtraBars.LinkPersistInfo(this.ItemAddDataBlock),
            new DevExpress.XtraBars.LinkPersistInfo(this.ItemAddTag),
            new DevExpress.XtraBars.LinkPersistInfo(this.ItemImport),
            new DevExpress.XtraBars.LinkPersistInfo(this.ItemExport),
            new DevExpress.XtraBars.LinkPersistInfo(this.ItemCopy),
            new DevExpress.XtraBars.LinkPersistInfo(this.ItemPaste),
            new DevExpress.XtraBars.LinkPersistInfo(this.ItemDelete)});
            this.popupMenuLeft.Manager = this.barManager1;
            this.popupMenuLeft.Name = "popupMenuLeft";
            // 
            // ItemAddChannel
            // 
            this.ItemAddChannel.Caption = "Channel";
            this.ItemAddChannel.Id = 3;
            this.ItemAddChannel.ImageOptions.Image = global::AdvancedScada.Studio.Properties.Resources.AddChannel;
            this.ItemAddChannel.Name = "ItemAddChannel";
            this.ItemAddChannel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ItemAddChannel_ItemClick);
            // 
            // ItemAddDevice
            // 
            this.ItemAddDevice.Caption = "Device";
            this.ItemAddDevice.Id = 4;
            this.ItemAddDevice.ImageOptions.Image = global::AdvancedScada.Studio.Properties.Resources.AddDevice;
            this.ItemAddDevice.Name = "ItemAddDevice";
            this.ItemAddDevice.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ItemAddDevice_ItemClick);
            // 
            // ItemAddDataBlock
            // 
            this.ItemAddDataBlock.Caption = "DataBlock";
            this.ItemAddDataBlock.Id = 1;
            this.ItemAddDataBlock.ImageOptions.Image = global::AdvancedScada.Studio.Properties.Resources.AddGoup;
            this.ItemAddDataBlock.Name = "ItemAddDataBlock";
            this.ItemAddDataBlock.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ItemAddDataBlock_ItemClick);
            // 
            // ItemAddTag
            // 
            this.ItemAddTag.Caption = "Tag";
            this.ItemAddTag.Id = 0;
            this.ItemAddTag.ImageOptions.Image = global::AdvancedScada.Studio.Properties.Resources.AddTag;
            this.ItemAddTag.Name = "ItemAddTag";
            this.ItemAddTag.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ItemAddTag_ItemClick);
            // 
            // ItemImport
            // 
            this.ItemImport.Caption = "Import";
            this.ItemImport.Id = 5;
            this.ItemImport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ItemImport.ImageOptions.Image")));
            this.ItemImport.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("ItemImport.ImageOptions.LargeImage")));
            this.ItemImport.Name = "ItemImport";
            this.ItemImport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ItemImport_ItemClick);
            // 
            // ItemExport
            // 
            this.ItemExport.Caption = "Export";
            this.ItemExport.Id = 6;
            this.ItemExport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ItemExport.ImageOptions.Image")));
            this.ItemExport.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("ItemExport.ImageOptions.LargeImage")));
            this.ItemExport.Name = "ItemExport";
            this.ItemExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ItemExport_ItemClick);
            // 
            // ItemCopy
            // 
            this.ItemCopy.Caption = "Copy";
            this.ItemCopy.Id = 8;
            this.ItemCopy.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ItemCopy.ImageOptions.Image")));
            this.ItemCopy.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("ItemCopy.ImageOptions.LargeImage")));
            this.ItemCopy.Name = "ItemCopy";
            this.ItemCopy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ItemCopy_ItemClick);
            // 
            // ItemPaste
            // 
            this.ItemPaste.Caption = "Paste";
            this.ItemPaste.Id = 9;
            this.ItemPaste.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ItemPaste.ImageOptions.Image")));
            this.ItemPaste.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("ItemPaste.ImageOptions.LargeImage")));
            this.ItemPaste.Name = "ItemPaste";
            this.ItemPaste.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ItemPaste_ItemClick);
            // 
            // ItemDelete
            // 
            this.ItemDelete.Caption = "Delete";
            this.ItemDelete.Id = 7;
            this.ItemDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ItemDelete.ImageOptions.Image")));
            this.ItemDelete.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("ItemDelete.ImageOptions.LargeImage")));
            this.ItemDelete.Name = "ItemDelete";
            this.ItemDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ItemDelete_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControl1);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ItemAddTag,
            this.ItemAddDataBlock,
            this.ItemAddChannel,
            this.ItemAddDevice,
            this.ItemImport,
            this.ItemExport,
            this.ItemDelete,
            this.ItemCopy,
            this.ItemPaste,
            this.mDeleteTag,
            this.RItemAddTag,
            this.ItemCopyToTag,
            this.RItemCopy,
            this.RItemPaste,
            this.barButtonNew,
            this.barButtonOpen,
            this.barButtonSave});
            this.barManager1.MaxItemId = 20;
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 2";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonNew, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonOpen, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonSave, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.OptionsBar.RotateWhenVertical = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Custom 2";
            // 
            // barButtonNew
            // 
            this.barButtonNew.Caption = "New";
            this.barButtonNew.Id = 17;
            this.barButtonNew.ImageOptions.Image = global::AdvancedScada.Studio.Properties.Resources.New;
            this.barButtonNew.Name = "barButtonNew";
            this.barButtonNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonNew_ItemClick);
            // 
            // barButtonOpen
            // 
            this.barButtonOpen.Caption = "Open";
            this.barButtonOpen.Id = 18;
            this.barButtonOpen.ImageOptions.Image = global::AdvancedScada.Studio.Properties.Resources.Open;
            this.barButtonOpen.Name = "barButtonOpen";
            this.barButtonOpen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonOpen_ItemClick);
            // 
            // barButtonSave
            // 
            this.barButtonSave.Caption = "Save";
            this.barButtonSave.Id = 19;
            this.barButtonSave.ImageOptions.Image = global::AdvancedScada.Studio.Properties.Resources.Save;
            this.barButtonSave.Name = "barButtonSave";
            this.barButtonSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonSave_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1042, 26);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 625);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1042, 0);
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl1.Location = new System.Drawing.Point(0, 26);
            this.barDockControl1.Manager = this.barManager1;
            this.barDockControl1.Size = new System.Drawing.Size(0, 599);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1042, 26);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 599);
            // 
            // mDeleteTag
            // 
            this.mDeleteTag.Caption = "Delete";
            this.mDeleteTag.Id = 12;
            this.mDeleteTag.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("mDeleteTag.ImageOptions.Image")));
            this.mDeleteTag.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("mDeleteTag.ImageOptions.LargeImage")));
            this.mDeleteTag.Name = "mDeleteTag";
            this.mDeleteTag.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mDeleteTag_ItemClick);
            // 
            // RItemAddTag
            // 
            this.RItemAddTag.Caption = "Add";
            this.RItemAddTag.Id = 13;
            this.RItemAddTag.ImageOptions.Image = global::AdvancedScada.Studio.Properties.Resources.Tag;
            this.RItemAddTag.Name = "RItemAddTag";
            this.RItemAddTag.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.RItemAddTag_ItemClick);
            // 
            // ItemCopyToTag
            // 
            this.ItemCopyToTag.Caption = "CopyToTagToText";
            this.ItemCopyToTag.Id = 14;
            this.ItemCopyToTag.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ItemCopyToTag.ImageOptions.Image")));
            this.ItemCopyToTag.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("ItemCopyToTag.ImageOptions.LargeImage")));
            this.ItemCopyToTag.Name = "ItemCopyToTag";
            this.ItemCopyToTag.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ItemCopyToTag_ItemClick);
            // 
            // RItemCopy
            // 
            this.RItemCopy.Caption = "Copy";
            this.RItemCopy.Id = 15;
            this.RItemCopy.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("RItemCopy.ImageOptions.Image")));
            this.RItemCopy.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("RItemCopy.ImageOptions.LargeImage")));
            this.RItemCopy.Name = "RItemCopy";
            this.RItemCopy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.RItemCopy_ItemClick);
            // 
            // RItemPaste
            // 
            this.RItemPaste.Caption = "Paste";
            this.RItemPaste.Id = 16;
            this.RItemPaste.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("RItemPaste.ImageOptions.Image")));
            this.RItemPaste.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("RItemPaste.ImageOptions.LargeImage")));
            this.RItemPaste.Name = "RItemPaste";
            this.RItemPaste.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.RItemPaste_ItemClick);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            // 
            // popupMenuRight
            // 
            this.popupMenuRight.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.RItemAddTag),
            new DevExpress.XtraBars.LinkPersistInfo(this.ItemCopyToTag),
            new DevExpress.XtraBars.LinkPersistInfo(this.mDeleteTag),
            new DevExpress.XtraBars.LinkPersistInfo(this.RItemCopy),
            new DevExpress.XtraBars.LinkPersistInfo(this.RItemPaste)});
            this.popupMenuRight.Manager = this.barManager1;
            this.popupMenuRight.Name = "popupMenuRight";
            // 
            // PvGridChannel
            // 
            this.PvGridChannel.Dock = System.Windows.Forms.DockStyle.Top;
            this.PvGridChannel.Location = new System.Drawing.Point(0, 0);
            this.PvGridChannel.Name = "PvGridChannel";
            this.PvGridChannel.Size = new System.Drawing.Size(212, 241);
            this.PvGridChannel.TabIndex = 24;
            // 
            // PvGridDevice
            // 
            this.PvGridDevice.Dock = System.Windows.Forms.DockStyle.Top;
            this.PvGridDevice.Location = new System.Drawing.Point(0, 241);
            this.PvGridDevice.Name = "PvGridDevice";
            this.PvGridDevice.Size = new System.Drawing.Size(212, 110);
            this.PvGridDevice.TabIndex = 34;
            // 
            // PvGridDataBlock
            // 
            this.PvGridDataBlock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PvGridDataBlock.Dock = System.Windows.Forms.DockStyle.Top;
            this.PvGridDataBlock.Location = new System.Drawing.Point(0, 351);
            this.PvGridDataBlock.Name = "PvGridDataBlock";
            this.PvGridDataBlock.Size = new System.Drawing.Size(212, 216);
            this.PvGridDataBlock.TabIndex = 35;
            // 
            // XTagManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 625);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControl1);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "XTagManager";
            this.Text = "TagManager";
            this.Load += new System.EventHandler(this.XtraTagManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TagDockManager)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PvGridChannel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PvGridDevice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PvGridDataBlock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal DevExpress.XtraBars.Docking.DockManager TagDockManager;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colChannel;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colTagId;
        private DevExpress.XtraGrid.Columns.GridColumn colTagName;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colDataType;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        internal DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraBars.PopupMenu popupMenuLeft;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraBars.PopupMenu popupMenuRight;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem ItemAddTag;
        private DevExpress.XtraBars.BarButtonItem ItemAddDataBlock;
        private DevExpress.XtraBars.BarButtonItem ItemAddChannel;
        private DevExpress.XtraBars.BarButtonItem ItemAddDevice;
        private DevExpress.XtraBars.BarButtonItem ItemImport;
        private DevExpress.XtraBars.BarButtonItem ItemExport;
        private DevExpress.XtraBars.BarButtonItem ItemDelete;
        private DevExpress.XtraBars.BarButtonItem ItemCopy;
        private DevExpress.XtraBars.BarButtonItem ItemPaste;
        private DevExpress.XtraBars.BarButtonItem mDeleteTag;
        private DevExpress.XtraBars.BarButtonItem RItemAddTag;
        private DevExpress.XtraBars.BarButtonItem ItemCopyToTag;
        private DevExpress.XtraBars.BarButtonItem RItemCopy;
        private DevExpress.XtraBars.BarButtonItem RItemPaste;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem barButtonNew;
        private DevExpress.XtraBars.BarButtonItem barButtonOpen;
        private DevExpress.XtraBars.BarButtonItem barButtonSave;
        private DevExpress.XtraVerticalGrid.PropertyGridControl PvGridChannel;
        private DevExpress.XtraVerticalGrid.PropertyGridControl PvGridDataBlock;
        private DevExpress.XtraVerticalGrid.PropertyGridControl PvGridDevice;
    }
}
