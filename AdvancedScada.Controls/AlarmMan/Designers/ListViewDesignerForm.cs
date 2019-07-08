//INSTANT C# NOTE: Formerly VB project-level imports:
using AdvancedScada.Controls.AlarmMan.Designers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Deployment;
using System.Diagnostics;
using System.Drawing;

using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace AdvancedHMIControls
{
    public partial class ListViewDesignerForm
    {
        public ListViewDesignerForm()
        {
            InitializeComponent();
        }

        #region Properties
        private iniClass inicls = new iniClass();
        private AlarmSummay m_ControlToEdit;
        public AlarmSummay ControlToEdit
        {
            get
            {
                return m_ControlToEdit;
            }
            set
            {
                m_ControlToEdit = value;
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            try
            {
                m_ControlToEdit._nListViewColumns.Clear();
                for (int i = 0; i < ListBoxSelected.Items.Count; i++)
                {
                    m_ControlToEdit._nListViewColumns.Add(Convert.ToString(ListBoxSelected.Items[i]));
                }
                // Create a file to write to.
                if (File.Exists(path) == false)
                {
                    File.CreateText(path);
                    string ListBoxSelectedItemsCount = ListBoxSelected.Items.Count.ToString();
                    inicls.SetIniValue("Display Format", " ListBoxSelectedItemsCount", ListBoxSelectedItemsCount, path);
                    for (int i = 0; i < ListBoxSelected.Items.Count; i++)
                    {
                        inicls.SetIniValue("Display Format", "ListBoxSelected.Items" + Convert.ToString(i), m_ControlToEdit._nListViewColumns[i], path);
                    }
                }
                else
                {
                    string ListBoxSelectedItemsCount = ListBoxSelected.Items.Count.ToString();
                    inicls.SetIniValue("Display Format", " ListBoxSelectedItemsCount", ListBoxSelectedItemsCount, path);
                    for (int i = 0; i < ListBoxSelected.Items.Count; i++)
                    {
                        inicls.SetIniValue("Display Format", "ListBoxSelected.Items" + Convert.ToString(i), m_ControlToEdit._nListViewColumns[i], path);
                    }
                    inicls.SetIniValue("Alarm Status", ChkAlarmOff.Name, $"{ ChkAlarmOff.Checked}", path);
                    inicls.SetIniValue("Alarm Status", ChkAlarmOn.Name, $"{ChkAlarmOn.Checked}", path);
                    inicls.SetIniValue("Alarm Status", ChkAlarmVariation.Name, $"{ ChkAlarmVariation.Checked}", path);
                    inicls.SetIniValue("Alarm Status", ChkAlarmAck.Name, $"{ChkAlarmAck.Checked}", path);

                }
                m_ControlToEdit.RListViewColumns();
                Close();
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private ListBox Lst = new ListBox();

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                string Selected_txt = Convert.ToString(ListBoxSelected.SelectedItem);

                if (Selected_txt != null) // التحقق من عدم خلو اختيار قيمة فارغة
                {

                    if (!this.ListBoxNonSelected.Items.Contains(Selected_txt)) // يتم التحقق هل النص موجود سلفا باللست بوكس أما لا حتى لا يضاف مرة أخرى
                    {

                        this.ListBoxNonSelected.Items.Add(Selected_txt);
                        ListBoxSelected.Items.RemoveAt(ListBoxSelected.SelectedIndex);
                    }

                }

            }
            catch (Exception ex)
            {
                return;
            }


        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {

                int MyIndex = 0;
                string MyItem = null;
                MyIndex = ListBoxSelected.SelectedIndex;
                MyItem = ListBoxSelected.Text;

                if (MyIndex == 0)
                {
                    return;
                }

                ListBoxSelected.Items.RemoveAt(ListBoxSelected.SelectedIndex);
                ListBoxSelected.Items.Insert(MyIndex - 1, MyItem);
                ListBoxSelected.SelectedIndex = MyIndex - 1;
            }
            catch (Exception ex)
            {
                return;
            }



        }

        private void ListBoxSelected_SelectedIndexChanged(object sender, EventArgs e)
        {
            //If (ListBoxNonSelected.Items.Contains(ListBoxSelected.SelectedItem)) Then
            //    '' The item Is already exist in the listbox collection 
            //    Exit Sub
            //Else
            //    '' The item Is Not exist in the listbox collection 
            //    ListBoxNonSelected.Items.Add(ListBoxSelected.SelectedItem)
            //End If
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                int MyIndex = 0;
                string MyItem = null;
                MyIndex = ListBoxSelected.SelectedIndex;
                MyItem = ListBoxSelected.Text;

                if (MyIndex == ListBoxSelected.Items.Count - 1)
                {
                    return;
                }

                ListBoxSelected.Items.RemoveAt(ListBoxSelected.SelectedIndex);
                ListBoxSelected.Items.Insert(MyIndex + 1, MyItem);
                ListBoxSelected.SelectedIndex = MyIndex + 1;
            }
            catch (Exception ex)
            {
                return;
            }

        }
        private string path = "C:\\Settings.ini";
        private List<string> nListBoxSelected = new List<string>();
        private void ListViewDesignerForm_Load(object sender, EventArgs e)
        {
            try
            {


                for (int i = 0; i < ListBoxSelected.Items.Count; i++)
                {
                    nListBoxSelected.Add(Convert.ToString(ListBoxSelected.Items[i]));
                }
                m_ControlToEdit._nListViewColumnsColor.Clear();
                ListBoxSelected.Items.Clear();
                // Open the file to read from.

                if (File.Exists(path) == true)
                {
                    var ItemsCount = inicls.GetIniValue("Display Format", "ListBoxSelectedItemsCount", path);
                    for (int i = 0; string.CompareOrdinal(i.ToString(), ItemsCount) < 0; i++)
                    {
                        ListBoxSelected.Items.Add(inicls.GetIniValue("Display Format", "ListBoxSelected.Items" + Convert.ToString(i), path));
                    }
                    Button6.BackColor = Color.FromArgb(Convert.ToInt32(inicls.GetIniValue("Alarm Type", "Button6.BackColor", path)));
                    Button7.BackColor = Color.FromArgb(Convert.ToInt32(inicls.GetIniValue("Alarm Type", "Button7.BackColor", path)));
                    Button8.BackColor = Color.FromArgb(Convert.ToInt32(inicls.GetIniValue("Alarm Type", "Button8.BackColor", path)));
                    Button9.BackColor = Color.FromArgb(Convert.ToInt32(inicls.GetIniValue("Alarm Type", "Button9.BackColor", path)));
                    Button5.BackColor = Color.FromArgb(Convert.ToInt32(inicls.GetIniValue("Alarm Type", "BackGround.BackColor", path)));
                    ChkAlarmOff.Checked = bool.Parse(inicls.GetIniValue("Alarm Status", "ChkAlarmOff", path));
                    ChkAlarmOn.Checked = bool.Parse(inicls.GetIniValue("Alarm Status", "ChkAlarmOn", path));
                    ChkAlarmVariation.Checked = bool.Parse(inicls.GetIniValue("Alarm Status", "ChkAlarmVariation", path));
                    ChkAlarmAck.Checked = bool.Parse(inicls.GetIniValue("Alarm Status", "ChkAlarmAck", path));

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                return;
            }

        }

        private void Button6_Click(dynamic sender, EventArgs e)
        {
            try
            {


                ColorDialog1.ShowDialog();

                if (sender.Name == "Button6")
                {
                    Button6.BackColor = ColorDialog1.Color;
                    m_ControlToEdit._nListViewColumnsColor.Add(Button6.BackColor);
                    inicls.SetIniValue("Alarm Type", "Button6.BackColor", Button6.BackColor.ToArgb().ToString(), path);

                }

                if (sender.Name == "Button7")
                {
                    Button7.BackColor = ColorDialog1.Color;
                    m_ControlToEdit._nListViewColumnsColor.Add(Button7.BackColor);
                    inicls.SetIniValue("Alarm Type", "Button7.BackColor", Button7.BackColor.ToArgb().ToString(), path);

                }
                if (sender.Name == "Button8")
                {
                    Button8.BackColor = ColorDialog1.Color;
                    m_ControlToEdit._nListViewColumnsColor.Add(Button8.BackColor);
                    inicls.SetIniValue("Alarm Type", "Button8.BackColor", Button8.BackColor.ToArgb().ToString(), path);

                }
                if (sender.Name == "Button9")
                {
                    Button9.BackColor = ColorDialog1.Color;
                    m_ControlToEdit._nListViewColumnsColor.Add(Button9.BackColor);
                    inicls.SetIniValue("Alarm Type", "Button9.BackColor", Button9.BackColor.ToArgb().ToString(), path);

                }
                if (sender.Name == "Button5")
                {
                    Button5.BackColor = ColorDialog1.Color;
                    m_ControlToEdit._nListViewColumnsColor.Add(Button5.BackColor);
                    inicls.SetIniValue("Alarm Type", "BackGround.BackColor", Button5.BackColor.ToArgb().ToString(), path);

                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        #endregion
        private List<TabPage> colRemovedTabs = new List<TabPage>();
        public void HidePage(string NamePage)
        {
            // Hide multiple pages
            foreach (TabPage tabpg in TabControl1.TabPages)
            {
                if (tabpg.Name == NamePage)
                {
                    colRemovedTabs.Add(tabpg);
                    TabControl1.Controls.Remove(tabpg);
                }
            }
        }
        public void ShowAllPages()
        {
            //  Reinsert all removed pages
            foreach (TabPage savedTab in colRemovedTabs)
            {
                TabControl1.Controls.Add(savedTab);
            }

            // Clear the collection as it has now done its work
            colRemovedTabs.Clear();

        }

        private string SelectTab;
        private void BtnCheckAll_Click(object sender, EventArgs e)
        {

            try
            {


                switch (SelectTab)
                {
                    case "tbAlarmLevel":

                        CheckBox_Check(tbAlarmLevel);
                        break;
                    case "tbAlarmZone":
                        CheckBox_Check(tbAlarmZone);
                        break;
                    case "tbDisplayType":
                        CheckBox_Check(tbDisplayType);
                        break;
                    case "tbAlarmStatus":
                        CheckBox_Check(tbAlarmStatus);
                        break;
                }
            }
            catch (Exception ex)
            {
                return;
            }


        }
        public void CheckBox_Check(Control root)
        {
            foreach (Control ctrl in root.Controls)
            {
                CheckBox_Check(ctrl);
                if (ctrl is CheckBox)
                {
                    ((CheckBox)ctrl).Checked = true;
                }
            }
        }
        public void CheckBox_UCheck(Control root)
        {
            foreach (Control ctrl in root.Controls)
            {
                CheckBox_UCheck(ctrl);
                if (ctrl is CheckBox)
                {
                    ((CheckBox)ctrl).Checked = false;
                }
            }
        }
        private void CheckBox17_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BtnUCheckAll_Click(object sender, EventArgs e)
        {
            try
            {
                switch (SelectTab)
                {
                    case "tbAlarmLevel":
                        CheckBox_UCheck(tbAlarmLevel);
                        break;
                    case "tbAlarmZone":
                        CheckBox_UCheck(tbAlarmZone);
                        break;
                    case "tbDisplayType":
                        CheckBox_UCheck(tbDisplayType);
                        break;
                    case "tbAlarmStatus":
                        CheckBox_UCheck(tbAlarmStatus);
                        break;
                }
            }
            catch (Exception ex)
            {
                return;
            }



        }

        private void ListBoxSelected_DrawItem(dynamic sender, DrawItemEventArgs e)
        {
            try
            {



                //' الخروج من الإجراء إذا لم يوجد عناصر
                if (e.Index < 0)
                {
                    return;
                }

                //' اللون الإفتراضي لخلفية العنصر المحدد
                e.DrawBackground();

                //' خصائص تنسيق النص
                StringFormat _sf = new StringFormat();

                //' تحويل الإتجاه من اليمين إلى اليسار
                if (sender.RightToLeft)
                {
                    _sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                }


                //' للعنصر المحدد
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {

                    //' لون خلفية العنصر المحدد
                    e.Graphics.FillRectangle(Brushes.Brown, e.Bounds);

                    //' لون نص العنصر المحدد
                    e.Graphics.DrawString(sender.GetItemText(sender.Items(e.Index)), e.Font, new SolidBrush(e.ForeColor), e.Bounds, _sf);


                }
                else //' للعناصر غير المحددة
                {

                    if ((e.Index % 2) != 0) // الترتيب الزوجي -------------------------
                    {

                        //' لون خلفية العنصر  غير المحدد حسب الترتيب الزوجي
                        e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(10, 0, 0, 0)), e.Bounds);

                        //' لون نص العنصر بالترتيب الزوجي
                        e.Graphics.DrawString(sender.GetItemText(sender.Items(e.Index)), e.Font, Brushes.Red, e.Bounds, _sf);

                    }
                    else // الترتيب الفردي -------------------------
                    {

                        //' لون خلفية العنصر  غير المحدد حسب الترتيب الفردي
                        e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(20, 0, 0, 0)), e.Bounds);

                        //' لون نص العنصر بالترتيب الفردي
                        e.Graphics.DrawString(sender.GetItemText(sender.Items(e.Index)), e.Font, Brushes.Blue, e.Bounds, _sf);
                    }

                }

                //' رسم مستطيل التركيز
                e.DrawFocusRectangle();

            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                string Selected_txt = Convert.ToString(ListBoxNonSelected.SelectedItem);

                if (Selected_txt != null) // التحقق من عدم خلو اختيار قيمة فارغة
                {

                    if (!this.ListBoxSelected.Items.Contains(Selected_txt)) // يتم التحقق هل النص موجود سلفا باللست بوكس أما لا حتى لا يضاف مرة أخرى
                    {

                        this.ListBoxSelected.Items.Add(Selected_txt);
                        ListBoxNonSelected.Items.RemoveAt(ListBoxNonSelected.SelectedIndex);
                    }

                }
            }
            catch (Exception ex)
            {
                return;
            }


        }


        private void tbAlarmLevel_Enter(dynamic sender, EventArgs e)
        {
            try
            {
                if (sender.name == "tbAlarmLevel")
                {
                    SelectTab = tbAlarmLevel.Name;
                }
                if (sender.name == "tbAlarmZone")
                {
                    SelectTab = tbAlarmZone.Name;
                }
                if (sender.name == "tbDisplayType")
                {
                    SelectTab = tbDisplayType.Name;
                }
                if (sender.name == "tbAlarmStatus")
                {
                    SelectTab = tbAlarmStatus.Name;
                }

            }
            catch (Exception ex)
            {
                return;
            }

        }
    }
}