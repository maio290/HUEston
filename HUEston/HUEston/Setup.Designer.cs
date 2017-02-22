/*
 * User: Mario
 * Date: 22.02.2017
 * Time: 13:43
 */
namespace HUEston
{
	partial class Setup
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setup));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.LBResponse = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.BTCheckIP = new System.Windows.Forms.Button();
			this.TBID = new System.Windows.Forms.TextBox();
			this.TBIP = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.BTAcquireUsername = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.LBResponse);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.BTCheckIP);
			this.groupBox1.Controls.Add(this.TBID);
			this.groupBox1.Controls.Add(this.TBIP);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(472, 109);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Bridge Config";
			// 
			// LBResponse
			// 
			this.LBResponse.Location = new System.Drawing.Point(219, 44);
			this.LBResponse.Name = "LBResponse";
			this.LBResponse.Size = new System.Drawing.Size(55, 23);
			this.LBResponse.TabIndex = 6;
			this.LBResponse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(165, 43);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(58, 25);
			this.label3.TabIndex = 5;
			this.label3.Text = "Response:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// BTCheckIP
			// 
			this.BTCheckIP.Location = new System.Drawing.Point(84, 44);
			this.BTCheckIP.Name = "BTCheckIP";
			this.BTCheckIP.Size = new System.Drawing.Size(75, 23);
			this.BTCheckIP.TabIndex = 4;
			this.BTCheckIP.Text = "Check IP";
			this.BTCheckIP.UseVisualStyleBackColor = true;
			this.BTCheckIP.Click += new System.EventHandler(this.BTCheckIPClick);
			// 
			// TBID
			// 
			this.TBID.Location = new System.Drawing.Point(84, 73);
			this.TBID.Name = "TBID";
			this.TBID.ReadOnly = true;
			this.TBID.Size = new System.Drawing.Size(374, 20);
			this.TBID.TabIndex = 3;
			// 
			// TBIP
			// 
			this.TBIP.Location = new System.Drawing.Point(84, 18);
			this.TBIP.Name = "TBIP";
			this.TBIP.Size = new System.Drawing.Size(374, 20);
			this.TBIP.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 70);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "ID:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "IP:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BTAcquireUsername
			// 
			this.BTAcquireUsername.Location = new System.Drawing.Point(12, 127);
			this.BTAcquireUsername.Name = "BTAcquireUsername";
			this.BTAcquireUsername.Size = new System.Drawing.Size(466, 32);
			this.BTAcquireUsername.TabIndex = 1;
			this.BTAcquireUsername.Text = "Acquire Username";
			this.BTAcquireUsername.UseVisualStyleBackColor = true;
			this.BTAcquireUsername.Click += new System.EventHandler(this.BTAcquireUsernameClick);
			// 
			// Setup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(498, 183);
			this.Controls.Add(this.BTAcquireUsername);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Setup";
			this.ShowInTaskbar = false;
			this.Text = "Setup";
			this.TopMost = true;
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SetupFormClosed);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button BTAcquireUsername;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox TBIP;
		private System.Windows.Forms.TextBox TBID;
		private System.Windows.Forms.Button BTCheckIP;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label LBResponse;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
