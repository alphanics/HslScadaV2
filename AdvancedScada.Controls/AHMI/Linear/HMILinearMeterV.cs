using AdvancedScada.Controls.AHMI.Licenses;
using AdvancedScada.Monitor;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml.Linq;

namespace AdvancedScada.Controls.AHMI.Linear
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(HMILinearMeterV), "HMI7Segment.ico")]
    public class HMILinearMeterV : AdvancedHMI.Controls_Net45.LinearMeterV
    {



        #region propartas

        private string _TagName;

        [Category("Link TagName")]
        [Browsable(true)]
        public string TagName
        {
            get { return _TagName; }

            set
            {
                _TagName = value;
                try
                {
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        #endregion
    }


}