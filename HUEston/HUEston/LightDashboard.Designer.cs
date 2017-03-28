/*
 * User: Mario
 * Date: 28.03.2017
 * Time: 14:04
 */
namespace HUEston
{
	partial class LightDashboard
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LightDashboard));
			this.FLPLights = new System.Windows.Forms.FlowLayoutPanel();
			this.SuspendLayout();
			// 
			// FLPLights
			// 
			this.FLPLights.Location = new System.Drawing.Point(7, 14);
			this.FLPLights.Name = "FLPLights";
			this.FLPLights.Size = new System.Drawing.Size(478, 527);
			this.FLPLights.TabIndex = 10;
			// 
			// LightDashboard
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(492, 554);
			this.Controls.Add(this.FLPLights);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "LightDashboard";
			this.Text = "HUEston - Light Dashboard";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LightDashboardFormClosing);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.FlowLayoutPanel FLPLights;
	}
}
