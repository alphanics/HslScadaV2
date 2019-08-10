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
            this.mushroomButton1 = new HslScada.Controls_Net45.MushroomButton();
            this.SuspendLayout();
            // 
            // mushroomButton1
            // 
            this.mushroomButton1.LegendPlate = HslScada.Controls_Net45.MushroomButton.LegendPlates.Large;
            this.mushroomButton1.Location = new System.Drawing.Point(367, 36);
            this.mushroomButton1.Name = "mushroomButton1";
            this.mushroomButton1.OutputType = HslScada.Controls_Net45.MushroomButton.OutputTypes.MomentarySet;
            this.mushroomButton1.Size = new System.Drawing.Size(274, 401);
            this.mushroomButton1.TabIndex = 0;
            this.mushroomButton1.Text = "mushroomButton1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 504);
            this.Controls.Add(this.mushroomButton1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private HslScada.Controls_Net45.MushroomButton mushroomButton1;
    }
}