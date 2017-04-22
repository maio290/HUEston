/*
 * User: Mario
 * Date: 22.04.2017
 * Time: 05:35
 */
namespace HUEston
{
	partial class PresetDashboard
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PresetDashboard));
			this.FLPPreset = new System.Windows.Forms.FlowLayoutPanel();
			this.SuspendLayout();
			// 
			// FLPPreset
			// 
			this.FLPPreset.Location = new System.Drawing.Point(12, 12);
			this.FLPPreset.Name = "FLPPreset";
			this.FLPPreset.Size = new System.Drawing.Size(468, 530);
			this.FLPPreset.TabIndex = 0;
			// 
			// PresetDashboard
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(492, 554);
			this.Controls.Add(this.FLPPreset);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "PresetDashboard";
			this.Text = "HUEston - Preset Dashboard";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PresetDashboardFormClosing);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.FlowLayoutPanel FLPPreset;
	}
}
