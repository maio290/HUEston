/*
 * User: Mario
 * Date: 23.02.2017
 * Time: 09:29
 */
namespace HUEston
{
	partial class RoomDashboard
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomDashboard));
			this.FLPRooms = new System.Windows.Forms.FlowLayoutPanel();
			this.SuspendLayout();
			// 
			// FLPRooms
			// 
			this.FLPRooms.Location = new System.Drawing.Point(12, 12);
			this.FLPRooms.Name = "FLPRooms";
			this.FLPRooms.Size = new System.Drawing.Size(478, 527);
			this.FLPRooms.TabIndex = 9;
			// 
			// RoomDashboard
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(502, 564);
			this.Controls.Add(this.FLPRooms);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "RoomDashboard";
			this.Text = "HUEston - Room Dashboard";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RoomDashboardFormClosing);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.FlowLayoutPanel FLPRooms;
	}
}
