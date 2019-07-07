//INSTANT C# NOTE: Formerly VB project-level imports:
using AdvancedHMIControls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;

using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdvancedScada.Controls.AlarmMan.Designers
{
    /// <summary>
    /// Create a New INI file to store or load data
    /// </summary>
    public class iniClass
    {
        [DllImport("kernel32")]
        private extern static int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32")]
        private extern static long WritePrivateProfileString(string section, string key, string val, string filePath);

        // INI 값 읽기
        public string GetIniValue(string Section, string Key, string iniPath)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, string.Empty, temp, 255, iniPath);
            return temp.ToString();
        }

        // INI 값 설정
        public void SetIniValue(string Section, string Key, string Value, string iniPath)
        {
            WritePrivateProfileString(Section, Key, Value, iniPath);
        }
    }

}