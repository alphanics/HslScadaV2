

using AdvancedHMI.Controls_Net45;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdvancedScada.Controls.AHMI.Motor
{
    public class HMIMotor2 : AdvancedHMI.Controls_Net45.Motor2
    {
        private OutputType m_OutputType;

        public OutputType OutputType
        {
            get
            {
                return m_OutputType;
            }
            set
            {
                m_OutputType = value;
            }
        }


    }


}