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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.hmiDigitalPanelMeter1 = new AdvancedScada.Controls.AHMI.DigitalDisplay.HMIDigitalPanelMeter();
            this.hmiLabel1 = new AdvancedScada.Controls.AHMI.Display.HMILabel();
            this.hmiSevenSegment21 = new AdvancedScada.Controls.AHMI.SevenSegment.HMISevenSegment2();
            this.analogValueDisplay1 = new AdvancedScada.Controls.AHMI.Display.AnalogValueDisplay();
            this.hmiInverter1 = new AdvancedScada.Controls.AHMI.Inverter.HMIInverter();
            this.hmIbutton1 = new AdvancedScada.Controls.HslControls.ButtonAll.HMIbutton();
            this.hmiGauge1 = new AdvancedScada.Controls.HslControls.Gauge.HMIGauge();
            this.hmiMotor1 = new AdvancedScada.Controls.HslControls.Motor.HMIMotor();
            this.hmiPipeLine1 = new AdvancedScada.Controls.HslControls.Pipe.HMIPipeLine();
            this.hmiBottle1 = new AdvancedScada.Controls.HslControls.TankAll.HMIBottle();
            this.hmiValves1 = new AdvancedScada.Controls.HslControls.Valves.HMIValves();
            this.SuspendLayout();
            // 
            // hmiDigitalPanelMeter1
            // 
            this.hmiDigitalPanelMeter1.BackColor = System.Drawing.Color.Transparent;
            this.hmiDigitalPanelMeter1.DecimalPosition = 0;
            this.hmiDigitalPanelMeter1.ForeColor = System.Drawing.Color.LightGray;
            this.hmiDigitalPanelMeter1.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiDigitalPanelMeter1.KeypadMaxValue = 0D;
            this.hmiDigitalPanelMeter1.KeypadMinValue = 0D;
            this.hmiDigitalPanelMeter1.KeypadScaleFactor = 1D;
            this.hmiDigitalPanelMeter1.KeypadText = null;
            this.hmiDigitalPanelMeter1.KeypadWidth = 300;
            this.hmiDigitalPanelMeter1.Location = new System.Drawing.Point(325, 17);
            this.hmiDigitalPanelMeter1.Name = "hmiDigitalPanelMeter1";
            this.hmiDigitalPanelMeter1.NumberOfDigits = 5;
            this.hmiDigitalPanelMeter1.PLCAddressKeypad = "CH1.PLC1.DataBlock1.TAG00002";
            this.hmiDigitalPanelMeter1.PLCAddressText = "CH1.PLC1.DataBlock1.TAG00002";
            this.hmiDigitalPanelMeter1.PLCAddressValue = "CH1.PLC1.DataBlock1.TAG00002";
            this.hmiDigitalPanelMeter1.PLCAddressVisible = "";
            this.hmiDigitalPanelMeter1.Resolution = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.hmiDigitalPanelMeter1.Size = new System.Drawing.Size(217, 94);
            this.hmiDigitalPanelMeter1.TabIndex = 1;
            this.hmiDigitalPanelMeter1.Text = "hmiDigitalPanelMeter1";
            this.hmiDigitalPanelMeter1.Value = 0D;
            this.hmiDigitalPanelMeter1.ValueScaleFactor = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.hmiDigitalPanelMeter1.ValueScaleOffset = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // hmiLabel1
            // 
            this.hmiLabel1.BackColor = System.Drawing.Color.White;
            this.hmiLabel1.BooleanDisplay = AdvancedScada.Controls.AHMI.Display.HMILabel.BooleanDisplayOption.TrueFalse;
            this.hmiLabel1.DisplayAsTime = false;
            this.hmiLabel1.ForeColor = System.Drawing.Color.Black;
            this.hmiLabel1.Highlight = false;
            this.hmiLabel1.HighlightColor = System.Drawing.Color.Red;
            this.hmiLabel1.HighlightForeColor = System.Drawing.Color.White;
            this.hmiLabel1.HighlightKeyCharacter = "!";
            this.hmiLabel1.InterpretValueAsBCD = false;
            this.hmiLabel1.KeypadAlphanumeric = false;
            this.hmiLabel1.KeypadFont = new System.Drawing.Font("Arial", 10F);
            this.hmiLabel1.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiLabel1.KeypadMaxValue = 0D;
            this.hmiLabel1.KeypadMinValue = 0D;
            this.hmiLabel1.KeypadScaleFactor = 1D;
            this.hmiLabel1.KeypadShowCurrentValue = false;
            this.hmiLabel1.KeypadText = null;
            this.hmiLabel1.KeypadWidth = 400;
            this.hmiLabel1.Location = new System.Drawing.Point(15, 17);
            this.hmiLabel1.Name = "hmiLabel1";
            this.hmiLabel1.NumericFormat = null;
            this.hmiLabel1.PLCAddressKeypad = "CH1.PLC1.DataBlock1.TAG00001";
            this.hmiLabel1.PLCAddressValue = "CH1.PLC1.DataBlock1.TAG00001";
            this.hmiLabel1.Size = new System.Drawing.Size(164, 50);
            this.hmiLabel1.TabIndex = 0;
            this.hmiLabel1.Text = "BasicLabel";
            this.hmiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hmiLabel1.Value = "BasicLabel";
            this.hmiLabel1.ValueLeftPadCharacter = ' ';
            this.hmiLabel1.ValueLeftPadLength = 0;
            this.hmiLabel1.ValuePrefix = null;
            this.hmiLabel1.ValueScaleFactor = 1D;
            this.hmiLabel1.ValueSuffix = null;
            this.hmiLabel1.ValueToSubtractFrom = 0F;
            // 
            // hmiSevenSegment21
            // 
            this.hmiSevenSegment21.BackColor = System.Drawing.Color.Transparent;
            this.hmiSevenSegment21.DecimalPosition = 0;
            this.hmiSevenSegment21.ForecolorHighLimitValue = 999999D;
            this.hmiSevenSegment21.ForeColorInLimits = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.hmiSevenSegment21.ForecolorLowLimitValue = -999999D;
            this.hmiSevenSegment21.ForeColorOverHighLimit = System.Drawing.Color.Red;
            this.hmiSevenSegment21.ForeColorUnderLowLimit = System.Drawing.Color.Yellow;
            this.hmiSevenSegment21.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.hmiSevenSegment21.KeypadMaxValue = 0D;
            this.hmiSevenSegment21.KeypadMinValue = 0D;
            this.hmiSevenSegment21.KeypadScaleFactor = 1D;
            this.hmiSevenSegment21.KeypadText = null;
            this.hmiSevenSegment21.KeypadWidth = 300;
            this.hmiSevenSegment21.Location = new System.Drawing.Point(219, 169);
            this.hmiSevenSegment21.Name = "hmiSevenSegment21";
            this.hmiSevenSegment21.NumberOfDigits = 5;
            this.hmiSevenSegment21.PLCAddressForecolorHighLimitValue = " ";
            this.hmiSevenSegment21.PLCAddressForecolorLowLimitValue = null;
            this.hmiSevenSegment21.PLCAddressKeypad = "CH1.PLC1.DataBlock1.TAG00003";
            this.hmiSevenSegment21.PLCAddressText = "CH1.PLC1.DataBlock1.TAG00003";
            this.hmiSevenSegment21.PLCAddressValue = "CH1.PLC1.DataBlock1.TAG00003";
            this.hmiSevenSegment21.PLCAddressVisible = "";
            this.hmiSevenSegment21.ResolutionOfLastDigit = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.hmiSevenSegment21.ShowOffSegments = true;
            this.hmiSevenSegment21.Size = new System.Drawing.Size(292, 76);
            this.hmiSevenSegment21.TabIndex = 2;
            this.hmiSevenSegment21.Text = "hmiSevenSegment21";
            this.hmiSevenSegment21.Value = 0D;
            // 
            // analogValueDisplay1
            // 
            this.analogValueDisplay1.AutoSize = true;
            this.analogValueDisplay1.ForeColor = System.Drawing.Color.White;
            this.analogValueDisplay1.ForeColorInLimits = System.Drawing.Color.White;
            this.analogValueDisplay1.ForeColorOverLimit = System.Drawing.Color.Red;
            this.analogValueDisplay1.ForeColorUnderLimit = System.Drawing.Color.Yellow;
            this.analogValueDisplay1.KeypadFontColor = System.Drawing.Color.WhiteSmoke;
            this.analogValueDisplay1.KeypadMaxValue = 0D;
            this.analogValueDisplay1.KeypadMinValue = 0D;
            this.analogValueDisplay1.KeypadPasscode = null;
            this.analogValueDisplay1.KeypadScaleFactor = 1D;
            this.analogValueDisplay1.KeypadText = null;
            this.analogValueDisplay1.KeypadWidth = 300;
            this.analogValueDisplay1.Location = new System.Drawing.Point(21, 89);
            this.analogValueDisplay1.Name = "analogValueDisplay1";
            this.analogValueDisplay1.NumericFormat = null;
            this.analogValueDisplay1.PLCAddressKeypad = "";
            this.analogValueDisplay1.PLCAddressValue = null;
            this.analogValueDisplay1.PLCAddressValueLimitLower = null;
            this.analogValueDisplay1.PLCAddressValueLimitUpper = null;
            this.analogValueDisplay1.PLCAddressVisible = null;
            this.analogValueDisplay1.ShowValue = true;
            this.analogValueDisplay1.Size = new System.Drawing.Size(31, 13);
            this.analogValueDisplay1.TabIndex = 3;
            this.analogValueDisplay1.Text = "0000";
            this.analogValueDisplay1.Value = "0000";
            this.analogValueDisplay1.ValueLimitLower = -999999D;
            this.analogValueDisplay1.ValueLimitUpper = 999999D;
            this.analogValueDisplay1.ValuePrefix = null;
            this.analogValueDisplay1.ValueSuffix = null;
            this.analogValueDisplay1.VisibleControl = AdvancedScada.Controls.AHMI.Display.AnalogValueDisplay.VisibleControlOptions.Always;
            // 
            // hmiInverter1
            // 
            this.hmiInverter1.DecimalPosition = 0;
            this.hmiInverter1.ForeColor = System.Drawing.Color.LightGray;
            this.hmiInverter1.LegendText = "Text";
            this.hmiInverter1.Location = new System.Drawing.Point(194, 17);
            this.hmiInverter1.Name = "hmiInverter1";
            this.hmiInverter1.NumberOfDigits = 4;
            this.hmiInverter1.Resolution = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.hmiInverter1.Size = new System.Drawing.Size(125, 108);
            this.hmiInverter1.TabIndex = 4;
            this.hmiInverter1.Text = "hmiInverter1";
            this.hmiInverter1.Value = 9999F;
            // 
            // hmIbutton1
            // 
            this.hmIbutton1.BackColor = System.Drawing.Color.LightGray;
            this.hmIbutton1.CustomerInformation = null;
            this.hmIbutton1.ForeColor = System.Drawing.Color.Black;
            this.hmIbutton1.ForeColorAlternate = System.Drawing.Color.Black;
            this.hmIbutton1.Highlight = false;
            this.hmIbutton1.HighlightColor = System.Drawing.Color.Green;
            this.hmIbutton1.Location = new System.Drawing.Point(15, 123);
            this.hmIbutton1.MaximumHoldTime = 3000;
            this.hmIbutton1.MinimumHoldTime = 500;
            this.hmIbutton1.Name = "hmIbutton1";
            this.hmIbutton1.OutputType = AdvancedHMI.Controls_Net45.OutputType.MomentarySet;
            this.hmIbutton1.PLCAddressClick = "";
            this.hmIbutton1.PLCAddressEnabled = "";
            this.hmIbutton1.PLCAddressHighlightX = "";
            this.hmIbutton1.PLCAddressSelectTextAlternate = "";
            this.hmIbutton1.PLCAddressVisible = "";
            this.hmIbutton1.SelectTextAlternate = false;
            this.hmIbutton1.Size = new System.Drawing.Size(163, 57);
            this.hmIbutton1.TabIndex = 5;
            this.hmIbutton1.Text = "hmIbutton1";
            this.hmIbutton1.TextAlternate = null;
            this.hmIbutton1.Value = null;
            this.hmIbutton1.ValueToWrite = 0;
            // 
            // hmiGauge1
            // 
            this.hmiGauge1.Location = new System.Drawing.Point(14, 203);
            this.hmiGauge1.Name = "hmiGauge1";
            this.hmiGauge1.OutputType = AdvancedHMI.Controls_Net45.OutputType.MomentarySet;
            this.hmiGauge1.PLCAddressText = "";
            this.hmiGauge1.PLCAddressValue = "";
            this.hmiGauge1.PLCAddressVisible = "";
            this.hmiGauge1.Size = new System.Drawing.Size(215, 132);
            this.hmiGauge1.TabIndex = 6;
            // 
            // hmiMotor1
            // 
            this.hmiMotor1.CenterColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.hmiMotor1.EdgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(91)))), ((int)(((byte)(96)))));
            this.hmiMotor1.Location = new System.Drawing.Point(266, 259);
            this.hmiMotor1.MaximumHoldTime = 3000;
            this.hmiMotor1.MinimumHoldTime = 500;
            this.hmiMotor1.Name = "hmiMotor1";
            this.hmiMotor1.OutputType = AdvancedHMI.Controls_Net45.OutputType.MomentarySet;
            this.hmiMotor1.PLCAddressClick = "";
            this.hmiMotor1.PLCAddressText = "";
            this.hmiMotor1.PLCAddressValue = "";
            this.hmiMotor1.PLCAddressVisible = "";
            this.hmiMotor1.SelactadMotorColor = AdvancedScada.Controls.MotorColor.Red;
            this.hmiMotor1.Size = new System.Drawing.Size(218, 75);
            this.hmiMotor1.TabIndex = 7;
            this.hmiMotor1.Text = "hmiMotor1";
            this.hmiMotor1.Value = false;
            this.hmiMotor1.ValueToWrite = 0;
            // 
            // hmiPipeLine1
            // 
            this.hmiPipeLine1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hmiPipeLine1.BackgroundImage")));
            this.hmiPipeLine1.Location = new System.Drawing.Point(149, 362);
            this.hmiPipeLine1.MaximumHoldTime = 3000;
            this.hmiPipeLine1.MinimumHoldTime = 500;
            this.hmiPipeLine1.MoveSpeed = 1F;
            this.hmiPipeLine1.Name = "hmiPipeLine1";
            this.hmiPipeLine1.OutputType = AdvancedHMI.Controls_Net45.OutputType.MomentarySet;
            this.hmiPipeLine1.PipeLineActive = true;
            this.hmiPipeLine1.PLCAddressClick = "";
            this.hmiPipeLine1.PLCAddressText = "";
            this.hmiPipeLine1.PLCAddressValue = "CH1.PLC1.DataBlock2.TAG00021";
            this.hmiPipeLine1.PLCAddressVisible = "";
            this.hmiPipeLine1.Size = new System.Drawing.Size(393, 38);
            this.hmiPipeLine1.TabIndex = 8;
            this.hmiPipeLine1.Value = true;
            this.hmiPipeLine1.ValueToWrite = 0;
            // 
            // hmiBottle1
            // 
            this.hmiBottle1.BackColorCenter = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.hmiBottle1.BackColorEdge = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(196)))), ((int)(((byte)(216)))));
            this.hmiBottle1.BackColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(232)))), ((int)(((byte)(244)))));
            this.hmiBottle1.ForeColorCenter = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(221)))), ((int)(((byte)(98)))));
            this.hmiBottle1.ForeColorEdge = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(190)))), ((int)(((byte)(77)))));
            this.hmiBottle1.ForeColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(245)))), ((int)(((byte)(139)))));
            this.hmiBottle1.Location = new System.Drawing.Point(18, 330);
            this.hmiBottle1.Name = "hmiBottle1";
            this.hmiBottle1.OutputType = AdvancedHMI.Controls_Net45.OutputType.MomentarySet;
            this.hmiBottle1.PLCAddressText = "";
            this.hmiBottle1.PLCAddressValue = "";
            this.hmiBottle1.PLCAddressVisible = "";
            this.hmiBottle1.Size = new System.Drawing.Size(109, 152);
            this.hmiBottle1.TabIndex = 9;
            this.hmiBottle1.Value = 50D;
            // 
            // hmiValves1
            // 
            this.hmiValves1.EdgeColor = System.Drawing.Color.Gray;
            this.hmiValves1.Location = new System.Drawing.Point(178, 411);
            this.hmiValves1.MaximumHoldTime = 3000;
            this.hmiValves1.MinimumHoldTime = 500;
            this.hmiValves1.Name = "hmiValves1";
            this.hmiValves1.OutputType = AdvancedHMI.Controls_Net45.OutputType.MomentarySet;
            this.hmiValves1.PLCAddressClick = "";
            this.hmiValves1.PLCAddressText = "";
            this.hmiValves1.PLCAddressValue = "";
            this.hmiValves1.PLCAddressVisible = "";
            this.hmiValves1.SelactadMotorColor = AdvancedScada.Controls.MotorColor.Green;
            this.hmiValves1.Size = new System.Drawing.Size(229, 70);
            this.hmiValves1.TabIndex = 10;
            this.hmiValves1.Text = "hmiValves1";
            this.hmiValves1.Value = false;
            this.hmiValves1.ValueToWrite = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 504);
            this.Controls.Add(this.hmiValves1);
            this.Controls.Add(this.hmiBottle1);
            this.Controls.Add(this.hmiPipeLine1);
            this.Controls.Add(this.hmiMotor1);
            this.Controls.Add(this.hmiGauge1);
            this.Controls.Add(this.hmIbutton1);
            this.Controls.Add(this.hmiInverter1);
            this.Controls.Add(this.analogValueDisplay1);
            this.Controls.Add(this.hmiSevenSegment21);
            this.Controls.Add(this.hmiDigitalPanelMeter1);
            this.Controls.Add(this.hmiLabel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HMILabel hmiLabel1;
        private HMIDigitalPanelMeter hmiDigitalPanelMeter1;
        private HMISevenSegment2 hmiSevenSegment21;
        private AnalogValueDisplay analogValueDisplay1;
        private Controls.AHMI.Inverter.HMIInverter hmiInverter1;
        private Controls.HslControls.ButtonAll.HMIbutton hmIbutton1;
        private Controls.HslControls.Gauge.HMIGauge hmiGauge1;
        private Controls.HslControls.Motor.HMIMotor hmiMotor1;
        private Controls.HslControls.Pipe.HMIPipeLine hmiPipeLine1;
        private Controls.HslControls.TankAll.HMIBottle hmiBottle1;
        private Controls.HslControls.Valves.HMIValves hmiValves1;
    }
}