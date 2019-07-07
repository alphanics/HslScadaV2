using System.ComponentModel;
using System.IO;
using AdvancedHMIControls;
 using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdvancedHMIControls
{
	[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	public partial class AlarmSummay : System.Windows.Forms.UserControl
	{
		//UserControl overrides dispose to clean up the component list.
		//<System.Diagnostics.DebuggerNonUserCode()>
		//Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		//    Try
		//        If disposing AndAlso components IsNot Nothing Then
		//            components.Dispose()
		//        End If
		//    Finally
		//        MyBase.Dispose(disposing)
		//    End Try
		//End Sub

		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;

		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.  
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.ListView1 = new System.Windows.Forms.ListView();
			this.SuspendLayout();
			//
			//ListView1
			//
			this.ListView1.BackColor = System.Drawing.Color.White;
			this.ListView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ListView1.Font = new System.Drawing.Font("Tahoma", 12.0F);
			this.ListView1.Location = new System.Drawing.Point(0, 0);
			this.ListView1.Name = "ListView1";
			this.ListView1.Size = new System.Drawing.Size(657, 332);
			this.ListView1.TabIndex = 1;
			this.ListView1.UseCompatibleStateImageBehavior = false;
			//
			//AlarmSummay
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.ListView1);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Tahoma", 8.0F);
			this.Name = "AlarmSummay";
			this.Size = new System.Drawing.Size(657, 332);
			this.ResumeLayout(false);

//INSTANT C# NOTE: Converted design-time event handler wireups:
			base.Load += new System.EventHandler(AlarmSummay_Load);
		}

		internal ListView ListView1;
	}

}