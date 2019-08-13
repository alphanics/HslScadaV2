using AdvancedScada.Controls.AHMI.DigitalDisplay;
using AdvancedScada.Controls.AHMI.Display;
using AdvancedScada.Controls.AHMI.SevenSegment;

namespace AdvancedScada.HMI
{
    partial class Form1
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
            this.hmiLedSingle1 = new HslScada.Controls_Binding.Leds.HMILedSingle();
            this.hmiLedSingle2 = new HslScada.Controls_Binding.Leds.HMILedSingle();
            this.hmiLedSingle3 = new HslScada.Controls_Binding.Leds.HMILedSingle();
            this.hmiLedSingle4 = new HslScada.Controls_Binding.Leds.HMILedSingle();
            this.hmiLedSingle5 = new HslScada.Controls_Binding.Leds.HMILedSingle();
            this.hmiLedSingle6 = new HslScada.Controls_Binding.Leds.HMILedSingle();
            this.hmiLedSingle7 = new HslScada.Controls_Binding.Leds.HMILedSingle();
            this.hmiLedSingle8 = new HslScada.Controls_Binding.Leds.HMILedSingle();
            this.hmiLedSingle9 = new HslScada.Controls_Binding.Leds.HMILedSingle();
            this.hmiLedSingle10 = new HslScada.Controls_Binding.Leds.HMILedSingle();
            this.SuspendLayout();
            // 
            // hmiLedSingle1
            // 
            this.hmiLedSingle1.ArrowWidth = 20;
            this.hmiLedSingle1.BorderExteriorColor = System.Drawing.Color.Blue;
            this.hmiLedSingle1.BorderExteriorLength = 0;
            this.hmiLedSingle1.BorderGradientAngle = 225;
            this.hmiLedSingle1.BorderGradientLightPos1 = 1F;
            this.hmiLedSingle1.BorderGradientLightPos2 = -1F;
            this.hmiLedSingle1.BorderGradientRate = 0.5F;
            this.hmiLedSingle1.BorderGradientType = HslScada.Controls_Binding.Enum.DAS_BorderGradientStyle.BGS_Path;
            this.hmiLedSingle1.BorderLightIntermediateBrightness = 0F;
            this.hmiLedSingle1.GradientAngle = 225;
            this.hmiLedSingle1.GradientRate = 0.6F;
            this.hmiLedSingle1.GradientType = HslScada.Controls_Binding.Enum.DAS_BkGradientStyle.BKGS_Shine;
            this.hmiLedSingle1.IndicatorAutoSize = true;
            this.hmiLedSingle1.IndicatorHeight = 50;
            this.hmiLedSingle1.IndicatorWidth = 50;
            this.hmiLedSingle1.InnerBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiLedSingle1.InnerBorderLength = 5;
            this.hmiLedSingle1.InnerBorderLightColor = System.Drawing.Color.White;
            this.hmiLedSingle1.Location = new System.Drawing.Point(80, 35);
            this.hmiLedSingle1.MaximumHoldTime = 3000;
            this.hmiLedSingle1.MiddleBorderColor = System.Drawing.Color.Gray;
            this.hmiLedSingle1.MiddleBorderLength = 0;
            this.hmiLedSingle1.MinimumHoldTime = 500;
            this.hmiLedSingle1.Name = "hmiLedSingle1";
            this.hmiLedSingle1.OffColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.hmiLedSingle1.OffGradientColor = System.Drawing.Color.Gray;
            this.hmiLedSingle1.OnColor = System.Drawing.Color.Lime;
            this.hmiLedSingle1.OnGradientColor = System.Drawing.Color.White;
            this.hmiLedSingle1.OuterBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiLedSingle1.OuterBorderLength = 5;
            this.hmiLedSingle1.OuterBorderLightColor = System.Drawing.Color.White;
            this.hmiLedSingle1.OutputType = HslScada.Controls_Net45.OutputType.MomentarySet;
            this.hmiLedSingle1.PLCAddressClick = "";
            this.hmiLedSingle1.PLCAddressText = "";
            this.hmiLedSingle1.PLCAddressValue = "";
            this.hmiLedSingle1.PLCAddressVisible = "";
            this.hmiLedSingle1.RoundRadius = 30;
            this.hmiLedSingle1.Shape = HslScada.Controls_Binding.Enum.DAS_ShapeStyle.SS_RoundRect;
            this.hmiLedSingle1.ShinePosition = 0.5F;
            this.hmiLedSingle1.Size = new System.Drawing.Size(154, 110);
            this.hmiLedSingle1.TabIndex = 0;
            this.hmiLedSingle1.Text = "hmiLedSingle1";
            this.hmiLedSingle1.TextPosition = HslScada.Controls_Binding.Enum.DAS_TextPosStyle.TPS_Left;
            this.hmiLedSingle1.TextVisible = false;
            this.hmiLedSingle1.Value = true;
            this.hmiLedSingle1.ValueToWrite = 0;
            // 
            // hmiLedSingle2
            // 
            this.hmiLedSingle2.ArrowWidth = 20;
            this.hmiLedSingle2.BorderExteriorColor = System.Drawing.Color.Blue;
            this.hmiLedSingle2.BorderExteriorLength = 0;
            this.hmiLedSingle2.BorderGradientAngle = 225;
            this.hmiLedSingle2.BorderGradientLightPos1 = 1F;
            this.hmiLedSingle2.BorderGradientLightPos2 = -1F;
            this.hmiLedSingle2.BorderGradientRate = 0.5F;
            this.hmiLedSingle2.BorderGradientType = HslScada.Controls_Binding.Enum.DAS_BorderGradientStyle.BGS_Path;
            this.hmiLedSingle2.BorderLightIntermediateBrightness = 0F;
            this.hmiLedSingle2.GradientAngle = 225;
            this.hmiLedSingle2.GradientRate = 0.6F;
            this.hmiLedSingle2.GradientType = HslScada.Controls_Binding.Enum.DAS_BkGradientStyle.BKGS_Shine;
            this.hmiLedSingle2.IndicatorAutoSize = true;
            this.hmiLedSingle2.IndicatorHeight = 50;
            this.hmiLedSingle2.IndicatorWidth = 50;
            this.hmiLedSingle2.InnerBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiLedSingle2.InnerBorderLength = 5;
            this.hmiLedSingle2.InnerBorderLightColor = System.Drawing.Color.White;
            this.hmiLedSingle2.Location = new System.Drawing.Point(251, 35);
            this.hmiLedSingle2.MaximumHoldTime = 3000;
            this.hmiLedSingle2.MiddleBorderColor = System.Drawing.Color.Gray;
            this.hmiLedSingle2.MiddleBorderLength = 0;
            this.hmiLedSingle2.MinimumHoldTime = 500;
            this.hmiLedSingle2.Name = "hmiLedSingle2";
            this.hmiLedSingle2.OffColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.hmiLedSingle2.OffGradientColor = System.Drawing.Color.Gray;
            this.hmiLedSingle2.OnColor = System.Drawing.Color.Lime;
            this.hmiLedSingle2.OnGradientColor = System.Drawing.Color.White;
            this.hmiLedSingle2.OuterBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiLedSingle2.OuterBorderLength = 5;
            this.hmiLedSingle2.OuterBorderLightColor = System.Drawing.Color.White;
            this.hmiLedSingle2.OutputType = HslScada.Controls_Net45.OutputType.MomentarySet;
            this.hmiLedSingle2.PLCAddressClick = "";
            this.hmiLedSingle2.PLCAddressText = "";
            this.hmiLedSingle2.PLCAddressValue = "";
            this.hmiLedSingle2.PLCAddressVisible = "";
            this.hmiLedSingle2.RoundRadius = 30;
            this.hmiLedSingle2.Shape = HslScada.Controls_Binding.Enum.DAS_ShapeStyle.SS_Rect;
            this.hmiLedSingle2.ShinePosition = 0.5F;
            this.hmiLedSingle2.Size = new System.Drawing.Size(154, 110);
            this.hmiLedSingle2.TabIndex = 1;
            this.hmiLedSingle2.Text = "hmiLedSingle2";
            this.hmiLedSingle2.TextPosition = HslScada.Controls_Binding.Enum.DAS_TextPosStyle.TPS_Left;
            this.hmiLedSingle2.TextVisible = false;
            this.hmiLedSingle2.Value = true;
            this.hmiLedSingle2.ValueToWrite = 0;
            // 
            // hmiLedSingle3
            // 
            this.hmiLedSingle3.ArrowWidth = 20;
            this.hmiLedSingle3.BorderExteriorColor = System.Drawing.Color.Blue;
            this.hmiLedSingle3.BorderExteriorLength = 0;
            this.hmiLedSingle3.BorderGradientAngle = 225;
            this.hmiLedSingle3.BorderGradientLightPos1 = 1F;
            this.hmiLedSingle3.BorderGradientLightPos2 = -1F;
            this.hmiLedSingle3.BorderGradientRate = 0.5F;
            this.hmiLedSingle3.BorderGradientType = HslScada.Controls_Binding.Enum.DAS_BorderGradientStyle.BGS_Path;
            this.hmiLedSingle3.BorderLightIntermediateBrightness = 0F;
            this.hmiLedSingle3.GradientAngle = 225;
            this.hmiLedSingle3.GradientRate = 0.6F;
            this.hmiLedSingle3.GradientType = HslScada.Controls_Binding.Enum.DAS_BkGradientStyle.BKGS_Shine;
            this.hmiLedSingle3.IndicatorAutoSize = true;
            this.hmiLedSingle3.IndicatorHeight = 50;
            this.hmiLedSingle3.IndicatorWidth = 50;
            this.hmiLedSingle3.InnerBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiLedSingle3.InnerBorderLength = 5;
            this.hmiLedSingle3.InnerBorderLightColor = System.Drawing.Color.White;
            this.hmiLedSingle3.Location = new System.Drawing.Point(424, 35);
            this.hmiLedSingle3.MaximumHoldTime = 3000;
            this.hmiLedSingle3.MiddleBorderColor = System.Drawing.Color.Gray;
            this.hmiLedSingle3.MiddleBorderLength = 0;
            this.hmiLedSingle3.MinimumHoldTime = 500;
            this.hmiLedSingle3.Name = "hmiLedSingle3";
            this.hmiLedSingle3.OffColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.hmiLedSingle3.OffGradientColor = System.Drawing.Color.Gray;
            this.hmiLedSingle3.OnColor = System.Drawing.Color.Lime;
            this.hmiLedSingle3.OnGradientColor = System.Drawing.Color.White;
            this.hmiLedSingle3.OuterBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiLedSingle3.OuterBorderLength = 5;
            this.hmiLedSingle3.OuterBorderLightColor = System.Drawing.Color.White;
            this.hmiLedSingle3.OutputType = HslScada.Controls_Net45.OutputType.MomentarySet;
            this.hmiLedSingle3.PLCAddressClick = "";
            this.hmiLedSingle3.PLCAddressText = "";
            this.hmiLedSingle3.PLCAddressValue = "";
            this.hmiLedSingle3.PLCAddressVisible = "";
            this.hmiLedSingle3.RoundRadius = 30;
            this.hmiLedSingle3.Shape = HslScada.Controls_Binding.Enum.DAS_ShapeStyle.SS_Diamond;
            this.hmiLedSingle3.ShinePosition = 0.5F;
            this.hmiLedSingle3.Size = new System.Drawing.Size(154, 110);
            this.hmiLedSingle3.TabIndex = 2;
            this.hmiLedSingle3.Text = "hmiLedSingle3";
            this.hmiLedSingle3.TextPosition = HslScada.Controls_Binding.Enum.DAS_TextPosStyle.TPS_Left;
            this.hmiLedSingle3.TextVisible = false;
            this.hmiLedSingle3.Value = true;
            this.hmiLedSingle3.ValueToWrite = 0;
            // 
            // hmiLedSingle4
            // 
            this.hmiLedSingle4.ArrowWidth = 20;
            this.hmiLedSingle4.BorderExteriorColor = System.Drawing.Color.Blue;
            this.hmiLedSingle4.BorderExteriorLength = 0;
            this.hmiLedSingle4.BorderGradientAngle = 225;
            this.hmiLedSingle4.BorderGradientLightPos1 = 1F;
            this.hmiLedSingle4.BorderGradientLightPos2 = -1F;
            this.hmiLedSingle4.BorderGradientRate = 0.5F;
            this.hmiLedSingle4.BorderGradientType = HslScada.Controls_Binding.Enum.DAS_BorderGradientStyle.BGS_Path;
            this.hmiLedSingle4.BorderLightIntermediateBrightness = 0F;
            this.hmiLedSingle4.GradientAngle = 225;
            this.hmiLedSingle4.GradientRate = 0.6F;
            this.hmiLedSingle4.GradientType = HslScada.Controls_Binding.Enum.DAS_BkGradientStyle.BKGS_Shine;
            this.hmiLedSingle4.IndicatorAutoSize = true;
            this.hmiLedSingle4.IndicatorHeight = 50;
            this.hmiLedSingle4.IndicatorWidth = 50;
            this.hmiLedSingle4.InnerBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiLedSingle4.InnerBorderLength = 5;
            this.hmiLedSingle4.InnerBorderLightColor = System.Drawing.Color.White;
            this.hmiLedSingle4.Location = new System.Drawing.Point(584, 35);
            this.hmiLedSingle4.MaximumHoldTime = 3000;
            this.hmiLedSingle4.MiddleBorderColor = System.Drawing.Color.Gray;
            this.hmiLedSingle4.MiddleBorderLength = 0;
            this.hmiLedSingle4.MinimumHoldTime = 500;
            this.hmiLedSingle4.Name = "hmiLedSingle4";
            this.hmiLedSingle4.OffColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.hmiLedSingle4.OffGradientColor = System.Drawing.Color.Gray;
            this.hmiLedSingle4.OnColor = System.Drawing.Color.Lime;
            this.hmiLedSingle4.OnGradientColor = System.Drawing.Color.White;
            this.hmiLedSingle4.OuterBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiLedSingle4.OuterBorderLength = 5;
            this.hmiLedSingle4.OuterBorderLightColor = System.Drawing.Color.White;
            this.hmiLedSingle4.OutputType = HslScada.Controls_Net45.OutputType.MomentarySet;
            this.hmiLedSingle4.PLCAddressClick = "";
            this.hmiLedSingle4.PLCAddressText = "";
            this.hmiLedSingle4.PLCAddressValue = "";
            this.hmiLedSingle4.PLCAddressVisible = "";
            this.hmiLedSingle4.RoundRadius = 30;
            this.hmiLedSingle4.Shape = HslScada.Controls_Binding.Enum.DAS_ShapeStyle.SS_Circle;
            this.hmiLedSingle4.ShinePosition = 0.5F;
            this.hmiLedSingle4.Size = new System.Drawing.Size(154, 110);
            this.hmiLedSingle4.TabIndex = 3;
            this.hmiLedSingle4.Text = "hmiLedSingle4";
            this.hmiLedSingle4.TextPosition = HslScada.Controls_Binding.Enum.DAS_TextPosStyle.TPS_Left;
            this.hmiLedSingle4.TextVisible = false;
            this.hmiLedSingle4.Value = true;
            this.hmiLedSingle4.ValueToWrite = 0;
            // 
            // hmiLedSingle5
            // 
            this.hmiLedSingle5.ArrowWidth = 20;
            this.hmiLedSingle5.BorderExteriorColor = System.Drawing.Color.Blue;
            this.hmiLedSingle5.BorderExteriorLength = 0;
            this.hmiLedSingle5.BorderGradientAngle = 225;
            this.hmiLedSingle5.BorderGradientLightPos1 = 1F;
            this.hmiLedSingle5.BorderGradientLightPos2 = -1F;
            this.hmiLedSingle5.BorderGradientRate = 0.5F;
            this.hmiLedSingle5.BorderGradientType = HslScada.Controls_Binding.Enum.DAS_BorderGradientStyle.BGS_Path;
            this.hmiLedSingle5.BorderLightIntermediateBrightness = 0F;
            this.hmiLedSingle5.GradientAngle = 225;
            this.hmiLedSingle5.GradientRate = 0.6F;
            this.hmiLedSingle5.GradientType = HslScada.Controls_Binding.Enum.DAS_BkGradientStyle.BKGS_Shine;
            this.hmiLedSingle5.IndicatorAutoSize = true;
            this.hmiLedSingle5.IndicatorHeight = 50;
            this.hmiLedSingle5.IndicatorWidth = 50;
            this.hmiLedSingle5.InnerBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiLedSingle5.InnerBorderLength = 5;
            this.hmiLedSingle5.InnerBorderLightColor = System.Drawing.Color.White;
            this.hmiLedSingle5.Location = new System.Drawing.Point(80, 163);
            this.hmiLedSingle5.MaximumHoldTime = 3000;
            this.hmiLedSingle5.MiddleBorderColor = System.Drawing.Color.Gray;
            this.hmiLedSingle5.MiddleBorderLength = 0;
            this.hmiLedSingle5.MinimumHoldTime = 500;
            this.hmiLedSingle5.Name = "hmiLedSingle5";
            this.hmiLedSingle5.OffColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.hmiLedSingle5.OffGradientColor = System.Drawing.Color.Gray;
            this.hmiLedSingle5.OnColor = System.Drawing.Color.Lime;
            this.hmiLedSingle5.OnGradientColor = System.Drawing.Color.White;
            this.hmiLedSingle5.OuterBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiLedSingle5.OuterBorderLength = 5;
            this.hmiLedSingle5.OuterBorderLightColor = System.Drawing.Color.White;
            this.hmiLedSingle5.OutputType = HslScada.Controls_Net45.OutputType.MomentarySet;
            this.hmiLedSingle5.PLCAddressClick = "";
            this.hmiLedSingle5.PLCAddressText = "";
            this.hmiLedSingle5.PLCAddressValue = "";
            this.hmiLedSingle5.PLCAddressVisible = "";
            this.hmiLedSingle5.RoundRadius = 30;
            this.hmiLedSingle5.Shape = HslScada.Controls_Binding.Enum.DAS_ShapeStyle.SS_Left_Triangle;
            this.hmiLedSingle5.ShinePosition = 0.5F;
            this.hmiLedSingle5.Size = new System.Drawing.Size(154, 110);
            this.hmiLedSingle5.TabIndex = 4;
            this.hmiLedSingle5.Text = "hmiLedSingle5";
            this.hmiLedSingle5.TextPosition = HslScada.Controls_Binding.Enum.DAS_TextPosStyle.TPS_Left;
            this.hmiLedSingle5.TextVisible = false;
            this.hmiLedSingle5.Value = true;
            this.hmiLedSingle5.ValueToWrite = 0;
            // 
            // hmiLedSingle6
            // 
            this.hmiLedSingle6.ArrowWidth = 20;
            this.hmiLedSingle6.BorderExteriorColor = System.Drawing.Color.Blue;
            this.hmiLedSingle6.BorderExteriorLength = 0;
            this.hmiLedSingle6.BorderGradientAngle = 225;
            this.hmiLedSingle6.BorderGradientLightPos1 = 1F;
            this.hmiLedSingle6.BorderGradientLightPos2 = -1F;
            this.hmiLedSingle6.BorderGradientRate = 0.5F;
            this.hmiLedSingle6.BorderGradientType = HslScada.Controls_Binding.Enum.DAS_BorderGradientStyle.BGS_Path;
            this.hmiLedSingle6.BorderLightIntermediateBrightness = 0F;
            this.hmiLedSingle6.GradientAngle = 225;
            this.hmiLedSingle6.GradientRate = 0.6F;
            this.hmiLedSingle6.GradientType = HslScada.Controls_Binding.Enum.DAS_BkGradientStyle.BKGS_Shine;
            this.hmiLedSingle6.IndicatorAutoSize = true;
            this.hmiLedSingle6.IndicatorHeight = 50;
            this.hmiLedSingle6.IndicatorWidth = 50;
            this.hmiLedSingle6.InnerBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiLedSingle6.InnerBorderLength = 5;
            this.hmiLedSingle6.InnerBorderLightColor = System.Drawing.Color.White;
            this.hmiLedSingle6.Location = new System.Drawing.Point(366, 197);
            this.hmiLedSingle6.MaximumHoldTime = 3000;
            this.hmiLedSingle6.MiddleBorderColor = System.Drawing.Color.Gray;
            this.hmiLedSingle6.MiddleBorderLength = 0;
            this.hmiLedSingle6.MinimumHoldTime = 500;
            this.hmiLedSingle6.Name = "hmiLedSingle6";
            this.hmiLedSingle6.OffColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.hmiLedSingle6.OffGradientColor = System.Drawing.Color.Gray;
            this.hmiLedSingle6.OnColor = System.Drawing.Color.Lime;
            this.hmiLedSingle6.OnGradientColor = System.Drawing.Color.White;
            this.hmiLedSingle6.OuterBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiLedSingle6.OuterBorderLength = 5;
            this.hmiLedSingle6.OuterBorderLightColor = System.Drawing.Color.White;
            this.hmiLedSingle6.OutputType = HslScada.Controls_Net45.OutputType.MomentarySet;
            this.hmiLedSingle6.PLCAddressClick = "";
            this.hmiLedSingle6.PLCAddressText = "";
            this.hmiLedSingle6.PLCAddressValue = "";
            this.hmiLedSingle6.PLCAddressVisible = "";
            this.hmiLedSingle6.RoundRadius = 30;
            this.hmiLedSingle6.Shape = HslScada.Controls_Binding.Enum.DAS_ShapeStyle.SS_Left_Arrow;
            this.hmiLedSingle6.ShinePosition = 0.5F;
            this.hmiLedSingle6.Size = new System.Drawing.Size(154, 110);
            this.hmiLedSingle6.TabIndex = 5;
            this.hmiLedSingle6.Text = "hmiLedSingle6";
            this.hmiLedSingle6.TextPosition = HslScada.Controls_Binding.Enum.DAS_TextPosStyle.TPS_Left;
            this.hmiLedSingle6.TextVisible = false;
            this.hmiLedSingle6.Value = true;
            this.hmiLedSingle6.ValueToWrite = 0;
            // 
            // hmiLedSingle7
            // 
            this.hmiLedSingle7.ArrowWidth = 20;
            this.hmiLedSingle7.BorderExteriorColor = System.Drawing.Color.Blue;
            this.hmiLedSingle7.BorderExteriorLength = 0;
            this.hmiLedSingle7.BorderGradientAngle = 225;
            this.hmiLedSingle7.BorderGradientLightPos1 = 1F;
            this.hmiLedSingle7.BorderGradientLightPos2 = -1F;
            this.hmiLedSingle7.BorderGradientRate = 0.5F;
            this.hmiLedSingle7.BorderGradientType = HslScada.Controls_Binding.Enum.DAS_BorderGradientStyle.BGS_Path;
            this.hmiLedSingle7.BorderLightIntermediateBrightness = 0F;
            this.hmiLedSingle7.GradientAngle = 225;
            this.hmiLedSingle7.GradientRate = 0.6F;
            this.hmiLedSingle7.GradientType = HslScada.Controls_Binding.Enum.DAS_BkGradientStyle.BKGS_Shine;
            this.hmiLedSingle7.IndicatorAutoSize = true;
            this.hmiLedSingle7.IndicatorHeight = 50;
            this.hmiLedSingle7.IndicatorWidth = 50;
            this.hmiLedSingle7.InnerBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiLedSingle7.InnerBorderLength = 5;
            this.hmiLedSingle7.InnerBorderLightColor = System.Drawing.Color.White;
            this.hmiLedSingle7.Location = new System.Drawing.Point(121, 313);
            this.hmiLedSingle7.MaximumHoldTime = 3000;
            this.hmiLedSingle7.MiddleBorderColor = System.Drawing.Color.Gray;
            this.hmiLedSingle7.MiddleBorderLength = 0;
            this.hmiLedSingle7.MinimumHoldTime = 500;
            this.hmiLedSingle7.Name = "hmiLedSingle7";
            this.hmiLedSingle7.OffColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.hmiLedSingle7.OffGradientColor = System.Drawing.Color.Gray;
            this.hmiLedSingle7.OnColor = System.Drawing.Color.Lime;
            this.hmiLedSingle7.OnGradientColor = System.Drawing.Color.White;
            this.hmiLedSingle7.OuterBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiLedSingle7.OuterBorderLength = 5;
            this.hmiLedSingle7.OuterBorderLightColor = System.Drawing.Color.White;
            this.hmiLedSingle7.OutputType = HslScada.Controls_Net45.OutputType.MomentarySet;
            this.hmiLedSingle7.PLCAddressClick = "";
            this.hmiLedSingle7.PLCAddressText = "";
            this.hmiLedSingle7.PLCAddressValue = "";
            this.hmiLedSingle7.PLCAddressVisible = "";
            this.hmiLedSingle7.RoundRadius = 30;
            this.hmiLedSingle7.Shape = HslScada.Controls_Binding.Enum.DAS_ShapeStyle.SS_Left_Triangle;
            this.hmiLedSingle7.ShinePosition = 0.5F;
            this.hmiLedSingle7.Size = new System.Drawing.Size(154, 110);
            this.hmiLedSingle7.TabIndex = 6;
            this.hmiLedSingle7.Text = "hmiLedSingle7";
            this.hmiLedSingle7.TextPosition = HslScada.Controls_Binding.Enum.DAS_TextPosStyle.TPS_Left;
            this.hmiLedSingle7.TextVisible = false;
            this.hmiLedSingle7.Value = true;
            this.hmiLedSingle7.ValueToWrite = 0;
            // 
            // hmiLedSingle8
            // 
            this.hmiLedSingle8.ArrowWidth = 20;
            this.hmiLedSingle8.BorderExteriorColor = System.Drawing.Color.Blue;
            this.hmiLedSingle8.BorderExteriorLength = 0;
            this.hmiLedSingle8.BorderGradientAngle = 225;
            this.hmiLedSingle8.BorderGradientLightPos1 = 1F;
            this.hmiLedSingle8.BorderGradientLightPos2 = -1F;
            this.hmiLedSingle8.BorderGradientRate = 0.5F;
            this.hmiLedSingle8.BorderGradientType = HslScada.Controls_Binding.Enum.DAS_BorderGradientStyle.BGS_Path;
            this.hmiLedSingle8.BorderLightIntermediateBrightness = 0F;
            this.hmiLedSingle8.GradientAngle = 225;
            this.hmiLedSingle8.GradientRate = 0.6F;
            this.hmiLedSingle8.GradientType = HslScada.Controls_Binding.Enum.DAS_BkGradientStyle.BKGS_Shine;
            this.hmiLedSingle8.IndicatorAutoSize = true;
            this.hmiLedSingle8.IndicatorHeight = 50;
            this.hmiLedSingle8.IndicatorWidth = 50;
            this.hmiLedSingle8.InnerBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiLedSingle8.InnerBorderLength = 5;
            this.hmiLedSingle8.InnerBorderLightColor = System.Drawing.Color.White;
            this.hmiLedSingle8.Location = new System.Drawing.Point(396, 321);
            this.hmiLedSingle8.MaximumHoldTime = 3000;
            this.hmiLedSingle8.MiddleBorderColor = System.Drawing.Color.Gray;
            this.hmiLedSingle8.MiddleBorderLength = 0;
            this.hmiLedSingle8.MinimumHoldTime = 500;
            this.hmiLedSingle8.Name = "hmiLedSingle8";
            this.hmiLedSingle8.OffColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.hmiLedSingle8.OffGradientColor = System.Drawing.Color.Gray;
            this.hmiLedSingle8.OnColor = System.Drawing.Color.Lime;
            this.hmiLedSingle8.OnGradientColor = System.Drawing.Color.White;
            this.hmiLedSingle8.OuterBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiLedSingle8.OuterBorderLength = 5;
            this.hmiLedSingle8.OuterBorderLightColor = System.Drawing.Color.White;
            this.hmiLedSingle8.OutputType = HslScada.Controls_Net45.OutputType.MomentarySet;
            this.hmiLedSingle8.PLCAddressClick = "";
            this.hmiLedSingle8.PLCAddressText = "";
            this.hmiLedSingle8.PLCAddressValue = "";
            this.hmiLedSingle8.PLCAddressVisible = "";
            this.hmiLedSingle8.RoundRadius = 30;
            this.hmiLedSingle8.Shape = HslScada.Controls_Binding.Enum.DAS_ShapeStyle.SS_Left_Triangle;
            this.hmiLedSingle8.ShinePosition = 0.5F;
            this.hmiLedSingle8.Size = new System.Drawing.Size(154, 110);
            this.hmiLedSingle8.TabIndex = 7;
            this.hmiLedSingle8.Text = "hmiLedSingle8";
            this.hmiLedSingle8.TextPosition = HslScada.Controls_Binding.Enum.DAS_TextPosStyle.TPS_Left;
            this.hmiLedSingle8.TextVisible = false;
            this.hmiLedSingle8.Value = true;
            this.hmiLedSingle8.ValueToWrite = 0;
            // 
            // hmiLedSingle9
            // 
            this.hmiLedSingle9.ArrowWidth = 20;
            this.hmiLedSingle9.BorderExteriorColor = System.Drawing.Color.Blue;
            this.hmiLedSingle9.BorderExteriorLength = 0;
            this.hmiLedSingle9.BorderGradientAngle = 225;
            this.hmiLedSingle9.BorderGradientLightPos1 = 1F;
            this.hmiLedSingle9.BorderGradientLightPos2 = -1F;
            this.hmiLedSingle9.BorderGradientRate = 0.5F;
            this.hmiLedSingle9.BorderGradientType = HslScada.Controls_Binding.Enum.DAS_BorderGradientStyle.BGS_Path;
            this.hmiLedSingle9.BorderLightIntermediateBrightness = 0F;
            this.hmiLedSingle9.GradientAngle = 225;
            this.hmiLedSingle9.GradientRate = 0.6F;
            this.hmiLedSingle9.GradientType = HslScada.Controls_Binding.Enum.DAS_BkGradientStyle.BKGS_Shine;
            this.hmiLedSingle9.IndicatorAutoSize = true;
            this.hmiLedSingle9.IndicatorHeight = 50;
            this.hmiLedSingle9.IndicatorWidth = 50;
            this.hmiLedSingle9.InnerBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiLedSingle9.InnerBorderLength = 5;
            this.hmiLedSingle9.InnerBorderLightColor = System.Drawing.Color.White;
            this.hmiLedSingle9.Location = new System.Drawing.Point(700, 313);
            this.hmiLedSingle9.MaximumHoldTime = 3000;
            this.hmiLedSingle9.MiddleBorderColor = System.Drawing.Color.Gray;
            this.hmiLedSingle9.MiddleBorderLength = 0;
            this.hmiLedSingle9.MinimumHoldTime = 500;
            this.hmiLedSingle9.Name = "hmiLedSingle9";
            this.hmiLedSingle9.OffColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.hmiLedSingle9.OffGradientColor = System.Drawing.Color.Gray;
            this.hmiLedSingle9.OnColor = System.Drawing.Color.Lime;
            this.hmiLedSingle9.OnGradientColor = System.Drawing.Color.White;
            this.hmiLedSingle9.OuterBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiLedSingle9.OuterBorderLength = 5;
            this.hmiLedSingle9.OuterBorderLightColor = System.Drawing.Color.White;
            this.hmiLedSingle9.OutputType = HslScada.Controls_Net45.OutputType.MomentarySet;
            this.hmiLedSingle9.PLCAddressClick = "";
            this.hmiLedSingle9.PLCAddressText = "";
            this.hmiLedSingle9.PLCAddressValue = "";
            this.hmiLedSingle9.PLCAddressVisible = "";
            this.hmiLedSingle9.RoundRadius = 30;
            this.hmiLedSingle9.Shape = HslScada.Controls_Binding.Enum.DAS_ShapeStyle.SS_Left_Triangle;
            this.hmiLedSingle9.ShinePosition = 0.5F;
            this.hmiLedSingle9.Size = new System.Drawing.Size(154, 110);
            this.hmiLedSingle9.TabIndex = 8;
            this.hmiLedSingle9.Text = "hmiLedSingle9";
            this.hmiLedSingle9.TextPosition = HslScada.Controls_Binding.Enum.DAS_TextPosStyle.TPS_Left;
            this.hmiLedSingle9.TextVisible = false;
            this.hmiLedSingle9.Value = true;
            this.hmiLedSingle9.ValueToWrite = 0;
            // 
            // hmiLedSingle10
            // 
            this.hmiLedSingle10.ArrowWidth = 20;
            this.hmiLedSingle10.BorderExteriorColor = System.Drawing.Color.Blue;
            this.hmiLedSingle10.BorderExteriorLength = 0;
            this.hmiLedSingle10.BorderGradientAngle = 225;
            this.hmiLedSingle10.BorderGradientLightPos1 = 1F;
            this.hmiLedSingle10.BorderGradientLightPos2 = -1F;
            this.hmiLedSingle10.BorderGradientRate = 0.5F;
            this.hmiLedSingle10.BorderGradientType = HslScada.Controls_Binding.Enum.DAS_BorderGradientStyle.BGS_Path;
            this.hmiLedSingle10.BorderLightIntermediateBrightness = 0F;
            this.hmiLedSingle10.GradientAngle = 225;
            this.hmiLedSingle10.GradientRate = 0.6F;
            this.hmiLedSingle10.GradientType = HslScada.Controls_Binding.Enum.DAS_BkGradientStyle.BKGS_Shine;
            this.hmiLedSingle10.IndicatorAutoSize = true;
            this.hmiLedSingle10.IndicatorHeight = 50;
            this.hmiLedSingle10.IndicatorWidth = 50;
            this.hmiLedSingle10.InnerBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiLedSingle10.InnerBorderLength = 5;
            this.hmiLedSingle10.InnerBorderLightColor = System.Drawing.Color.White;
            this.hmiLedSingle10.Location = new System.Drawing.Point(596, 178);
            this.hmiLedSingle10.MaximumHoldTime = 3000;
            this.hmiLedSingle10.MiddleBorderColor = System.Drawing.Color.Gray;
            this.hmiLedSingle10.MiddleBorderLength = 0;
            this.hmiLedSingle10.MinimumHoldTime = 500;
            this.hmiLedSingle10.Name = "hmiLedSingle10";
            this.hmiLedSingle10.OffColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.hmiLedSingle10.OffGradientColor = System.Drawing.Color.Gray;
            this.hmiLedSingle10.OnColor = System.Drawing.Color.Lime;
            this.hmiLedSingle10.OnGradientColor = System.Drawing.Color.White;
            this.hmiLedSingle10.OuterBorderDarkColor = System.Drawing.Color.DimGray;
            this.hmiLedSingle10.OuterBorderLength = 5;
            this.hmiLedSingle10.OuterBorderLightColor = System.Drawing.Color.White;
            this.hmiLedSingle10.OutputType = HslScada.Controls_Net45.OutputType.MomentarySet;
            this.hmiLedSingle10.PLCAddressClick = "";
            this.hmiLedSingle10.PLCAddressText = "";
            this.hmiLedSingle10.PLCAddressValue = "";
            this.hmiLedSingle10.PLCAddressVisible = "";
            this.hmiLedSingle10.RoundRadius = 30;
            this.hmiLedSingle10.Shape = HslScada.Controls_Binding.Enum.DAS_ShapeStyle.SS_Bottom_Arrow;
            this.hmiLedSingle10.ShinePosition = 0.5F;
            this.hmiLedSingle10.Size = new System.Drawing.Size(154, 110);
            this.hmiLedSingle10.TabIndex = 9;
            this.hmiLedSingle10.Text = "hmiLedSingle10";
            this.hmiLedSingle10.TextPosition = HslScada.Controls_Binding.Enum.DAS_TextPosStyle.TPS_Left;
            this.hmiLedSingle10.TextVisible = false;
            this.hmiLedSingle10.Value = true;
            this.hmiLedSingle10.ValueToWrite = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 504);
            this.Controls.Add(this.hmiLedSingle10);
            this.Controls.Add(this.hmiLedSingle9);
            this.Controls.Add(this.hmiLedSingle8);
            this.Controls.Add(this.hmiLedSingle7);
            this.Controls.Add(this.hmiLedSingle6);
            this.Controls.Add(this.hmiLedSingle5);
            this.Controls.Add(this.hmiLedSingle4);
            this.Controls.Add(this.hmiLedSingle3);
            this.Controls.Add(this.hmiLedSingle2);
            this.Controls.Add(this.hmiLedSingle1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private HslScada.Controls_Binding.Leds.HMILedSingle hmiLedSingle1;
        private HslScada.Controls_Binding.Leds.HMILedSingle hmiLedSingle2;
        private HslScada.Controls_Binding.Leds.HMILedSingle hmiLedSingle3;
        private HslScada.Controls_Binding.Leds.HMILedSingle hmiLedSingle4;
        private HslScada.Controls_Binding.Leds.HMILedSingle hmiLedSingle5;
        private HslScada.Controls_Binding.Leds.HMILedSingle hmiLedSingle6;
        private HslScada.Controls_Binding.Leds.HMILedSingle hmiLedSingle7;
        private HslScada.Controls_Binding.Leds.HMILedSingle hmiLedSingle8;
        private HslScada.Controls_Binding.Leds.HMILedSingle hmiLedSingle9;
        private HslScada.Controls_Binding.Leds.HMILedSingle hmiLedSingle10;
    }
}