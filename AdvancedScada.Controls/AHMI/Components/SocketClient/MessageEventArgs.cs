﻿using AdvancedHMIControls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdvancedScada.Controls.AHMI.Components.SocketClient
{
    public class MessageEventArgs : System.EventArgs
    {
        public MessageEventArgs() : base()
        {
        }

        public MessageEventArgs(string message) : this()
        {
            m_Message = message;
        }

        private string m_Message;
        public string Message
        {
            get
            {
                return m_Message;
            }
            set
            {
                m_Message = value;
            }
        }
    }

}