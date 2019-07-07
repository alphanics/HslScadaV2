using System;

namespace AdvancedScada.Controls.HslControls.Keypad
{
    public class KeypadEventArgs : EventArgs
    {
        private string m_Key;

        public string Key
        {
            get
            {
                return this.m_Key;
            }
        }

        public KeypadEventArgs(string Key)
        {
            this.m_Key = Key;
        }
    }


}