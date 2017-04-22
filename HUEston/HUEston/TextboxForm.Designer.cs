/*
 * User: Mario
 * Date: 12.04.2017
 * Time: 22:23
 */
namespace HUEston
{
	partial class TextboxForm
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
			this.TBInfo = new System.Windows.Forms.TextBox();
			this.BTSave = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// TBInfo
			// 
			this.TBInfo.Location = new System.Drawing.Point(12, 12);
			this.TBInfo.Multiline = true;
			this.TBInfo.Name = "TBInfo";
			this.TBInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TBInfo.Size = new System.Drawing.Size(774, 351);
			this.TBInfo.TabIndex = 0;
			// 
			// BTSave
			// 
			this.BTSave.Location = new System.Drawing.Point(12, 378);
			this.BTSave.Name = "BTSave";
			this.BTSave.Size = new System.Drawing.Size(774, 23);
			this.BTSave.TabIndex = 1;
			this.BTSave.Text = "Save to File";
			this.BTSave.UseVisualStyleBackColor = true;
			this.BTSave.Click += new System.EventHandler(this.BTSaveClick);
			// 
			// TextboxForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(798, 411);
			this.Controls.Add(this.BTSave);
			this.Controls.Add(this.TBInfo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "TextboxForm";
			this.Text = "HUEston - Information Window";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button BTSave;
		private System.Windows.Forms.TextBox TBInfo;
	}
}
