﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HslScada.Controls.SelectorSwitch
{
    /// <summary>
    /// Interaction logic for PilotLightSmall.xaml
    /// </summary>
    public partial class PilotLightSmall : UserControl
    {
        public PilotLightSmall()
        {
            InitializeComponent();
        }
        #region DependencyProperty

        /// <summary>
        /// Color
        /// </summary>
        public static readonly DependencyProperty PilotLightSmallColorProperty = DependencyProperty.Register(
            "PilotLightSmallColor", typeof(Color), typeof(PilotLightSmall), new PropertyMetadata(Colors.Green));

        public static readonly DependencyProperty PilotLightSmallTextProperty = DependencyProperty.Register(
           "PilotLightSmallText", typeof(string), typeof(PilotLightSmall), new PropertyMetadata("Name"));

        #endregion

        #region Public Properties

        /// <summary>
        /// Color
        /// </summary>
        public Color PilotLightSmallColor
        {
            set { SetValue(PilotLightSmallColorProperty, value); }
            get { return (Color)GetValue(PilotLightSmallColorProperty); }
        }
        /// <summary>
        /// string
        /// </summary>
        public string PilotLightSmallText
        {
            set { SetValue(PilotLightSmallTextProperty, value); }
            get { return (string)GetValue(PilotLightSmallTextProperty); }
        }
        #endregion
    }
}