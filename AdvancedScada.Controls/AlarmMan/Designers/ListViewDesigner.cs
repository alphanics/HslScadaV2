//INSTANT C# NOTE: Formerly VB project-level imports:
using HslScadaControls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdvancedScada.Controls.AlarmMan.Designers
{
    public class ListViewDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        public override System.ComponentModel.Design.DesignerVerbCollection Verbs
        {
            get
            {
                System.ComponentModel.Design.DesignerVerbCollection verbs_ = new System.ComponentModel.Design.DesignerVerbCollection();
                //* "Editor" will be added to the Smart Tags popup menu
                System.ComponentModel.Design.DesignerVerb dv1 = new System.ComponentModel.Design.DesignerVerb("Editor", new EventHandler(this.ShowDesignerWindow));
                verbs_.Add(dv1);
                return verbs_;
            }
        }

        private void ShowDesignerWindow(object sender, EventArgs e)
        {
            if (this.Component != null)
            {
                ListViewDesignerForm mcdf = new ListViewDesignerForm();
                mcdf.ControlToEdit = (AlarmSummay)Component;
                mcdf.ShowDialog();
            }
        }

        public override void DoDefaultAction() //Implements IDesigner.DoDefaultAction
        {
            //Throw New NotImplementedException()
            if (this.Component != null)
            {
                ListViewDesignerForm mcdf = new ListViewDesignerForm();
                mcdf.ControlToEdit = (AlarmSummay)Component;
                mcdf.ShowDialog();
            }
        }
    }

}