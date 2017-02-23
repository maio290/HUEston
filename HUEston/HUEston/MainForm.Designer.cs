/*
 * Created by SharpDevelop.
 * User: Mario
 * Date: 22.02.2017
 * Time: 11:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace HUEston
{
	partial class MainForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.SSLampQTY = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
			this.SSRoomQTY = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.overviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.roomsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lampsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dashboardToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.scenesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.bridgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.presetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button6 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.BTBriDown = new System.Windows.Forms.Button();
			this.BTBriUP = new System.Windows.Forms.Button();
			this.BTOff = new System.Windows.Forms.Button();
			this.BTOn = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.TBBridgeUser = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.TBBridgeIP = new System.Windows.Forms.TextBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.CBRooms = new System.Windows.Forms.ComboBox();
			this.BSCBRooms = new System.Windows.Forms.BindingSource(this.components);
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.BTCold = new System.Windows.Forms.Button();
			this.BTNeutral = new System.Windows.Forms.Button();
			this.BTWarm = new System.Windows.Forms.Button();
			this.BTDecHue = new System.Windows.Forms.Button();
			this.BTIncHue = new System.Windows.Forms.Button();
			this.BTDecSat = new System.Windows.Forms.Button();
			this.BTIncSat = new System.Windows.Forms.Button();
			this.BTColSelect = new System.Windows.Forms.Button();
			this.statusStrip1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.BSCBRooms)).BeginInit();
			this.groupBox5.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripStatusLabel1,
									this.SSLampQTY,
									this.toolStripStatusLabel2,
									this.toolStripStatusLabel3,
									this.SSRoomQTY});
			this.statusStrip1.Location = new System.Drawing.Point(0, 552);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(512, 22);
			this.statusStrip1.TabIndex = 0;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(106, 17);
			this.toolStripStatusLabel1.Text = "Amount of Lamps:";
			// 
			// SSLampQTY
			// 
			this.SSLampQTY.Name = "SSLampQTY";
			this.SSLampQTY.Size = new System.Drawing.Size(118, 17);
			this.SSLampQTY.Text = "toolStripStatusLabel2";
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(10, 17);
			this.toolStripStatusLabel2.Text = "|";
			// 
			// toolStripStatusLabel3
			// 
			this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
			this.toolStripStatusLabel3.Size = new System.Drawing.Size(108, 17);
			this.toolStripStatusLabel3.Text = "Amount of Rooms:";
			// 
			// SSRoomQTY
			// 
			this.SSRoomQTY.Name = "SSRoomQTY";
			this.SSRoomQTY.Size = new System.Drawing.Size(118, 17);
			this.SSRoomQTY.Text = "toolStripStatusLabel4";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.overviewToolStripMenuItem,
									this.roomsToolStripMenuItem,
									this.lampsToolStripMenuItem,
									this.scenesToolStripMenuItem,
									this.configToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(512, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// overviewToolStripMenuItem
			// 
			this.overviewToolStripMenuItem.Name = "overviewToolStripMenuItem";
			this.overviewToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
			this.overviewToolStripMenuItem.Text = "Overview";
			// 
			// roomsToolStripMenuItem
			// 
			this.roomsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.dashboardToolStripMenuItem});
			this.roomsToolStripMenuItem.Name = "roomsToolStripMenuItem";
			this.roomsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
			this.roomsToolStripMenuItem.Text = "Rooms";
			// 
			// dashboardToolStripMenuItem
			// 
			this.dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
			this.dashboardToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
			this.dashboardToolStripMenuItem.Text = "Dashboard";
			this.dashboardToolStripMenuItem.Click += new System.EventHandler(this.DashboardToolStripMenuItemClick);
			// 
			// lampsToolStripMenuItem
			// 
			this.lampsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.dashboardToolStripMenuItem1});
			this.lampsToolStripMenuItem.Name = "lampsToolStripMenuItem";
			this.lampsToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
			this.lampsToolStripMenuItem.Text = "Lamps";
			// 
			// dashboardToolStripMenuItem1
			// 
			this.dashboardToolStripMenuItem1.Name = "dashboardToolStripMenuItem1";
			this.dashboardToolStripMenuItem1.Size = new System.Drawing.Size(131, 22);
			this.dashboardToolStripMenuItem1.Text = "Dashboard";
			// 
			// scenesToolStripMenuItem
			// 
			this.scenesToolStripMenuItem.Name = "scenesToolStripMenuItem";
			this.scenesToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
			this.scenesToolStripMenuItem.Text = "Scenes";
			// 
			// configToolStripMenuItem
			// 
			this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.bridgeToolStripMenuItem,
									this.presetsToolStripMenuItem});
			this.configToolStripMenuItem.Name = "configToolStripMenuItem";
			this.configToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
			this.configToolStripMenuItem.Text = "Config";
			// 
			// bridgeToolStripMenuItem
			// 
			this.bridgeToolStripMenuItem.Name = "bridgeToolStripMenuItem";
			this.bridgeToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.bridgeToolStripMenuItem.Text = "Bridge";
			this.bridgeToolStripMenuItem.Click += new System.EventHandler(this.BridgeToolStripMenuItemClick);
			// 
			// presetsToolStripMenuItem
			// 
			this.presetsToolStripMenuItem.Name = "presetsToolStripMenuItem";
			this.presetsToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.presetsToolStripMenuItem.Text = "Presets";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.button6);
			this.groupBox1.Controls.Add(this.button5);
			this.groupBox1.Controls.Add(this.button4);
			this.groupBox1.Controls.Add(this.button3);
			this.groupBox1.Controls.Add(this.button2);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Location = new System.Drawing.Point(12, 184);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(488, 59);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Presets";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(407, 19);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(75, 23);
			this.button6.TabIndex = 5;
			this.button6.Text = "button6";
			this.button6.UseVisualStyleBackColor = true;
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(330, 19);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(75, 23);
			this.button5.TabIndex = 4;
			this.button5.Text = "button5";
			this.button5.UseVisualStyleBackColor = true;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(249, 19);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 3;
			this.button4.Text = "button4";
			this.button4.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(168, 19);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 2;
			this.button3.Text = "button3";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(87, 19);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 1;
			this.button2.Text = "button2";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(6, 19);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.BTBriDown);
			this.groupBox2.Controls.Add(this.BTBriUP);
			this.groupBox2.Controls.Add(this.BTOff);
			this.groupBox2.Controls.Add(this.BTOn);
			this.groupBox2.Location = new System.Drawing.Point(12, 27);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(175, 151);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Power Options";
			// 
			// BTBriDown
			// 
			this.BTBriDown.Location = new System.Drawing.Point(6, 86);
			this.BTBriDown.Name = "BTBriDown";
			this.BTBriDown.Size = new System.Drawing.Size(156, 23);
			this.BTBriDown.TabIndex = 3;
			this.BTBriDown.Text = "Brightness Down";
			this.BTBriDown.UseVisualStyleBackColor = true;
			this.BTBriDown.Click += new System.EventHandler(this.BTBriDownClick);
			// 
			// BTBriUP
			// 
			this.BTBriUP.Location = new System.Drawing.Point(6, 57);
			this.BTBriUP.Name = "BTBriUP";
			this.BTBriUP.Size = new System.Drawing.Size(156, 23);
			this.BTBriUP.TabIndex = 2;
			this.BTBriUP.Text = "Brightness Up";
			this.BTBriUP.UseVisualStyleBackColor = true;
			this.BTBriUP.Click += new System.EventHandler(this.BTBriUPClick);
			// 
			// BTOff
			// 
			this.BTOff.Location = new System.Drawing.Point(6, 115);
			this.BTOff.Name = "BTOff";
			this.BTOff.Size = new System.Drawing.Size(156, 30);
			this.BTOff.TabIndex = 1;
			this.BTOff.Text = "Off";
			this.BTOff.UseVisualStyleBackColor = true;
			this.BTOff.Click += new System.EventHandler(this.BTOffClick);
			// 
			// BTOn
			// 
			this.BTOn.Location = new System.Drawing.Point(6, 19);
			this.BTOn.Name = "BTOn";
			this.BTOn.Size = new System.Drawing.Size(156, 32);
			this.BTOn.TabIndex = 0;
			this.BTOn.Text = "On";
			this.BTOn.UseVisualStyleBackColor = true;
			this.BTOn.Click += new System.EventHandler(this.BTOnClick);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.TBBridgeUser);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.TBBridgeIP);
			this.groupBox3.Location = new System.Drawing.Point(193, 27);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(307, 80);
			this.groupBox3.TabIndex = 4;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Quick Info";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "User:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// TBBridgeUser
			// 
			this.TBBridgeUser.Location = new System.Drawing.Point(68, 51);
			this.TBBridgeUser.Name = "TBBridgeUser";
			this.TBBridgeUser.ReadOnly = true;
			this.TBBridgeUser.Size = new System.Drawing.Size(233, 20);
			this.TBBridgeUser.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(50, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Bridge:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// TBBridgeIP
			// 
			this.TBBridgeIP.Location = new System.Drawing.Point(68, 17);
			this.TBBridgeIP.Name = "TBBridgeIP";
			this.TBBridgeIP.ReadOnly = true;
			this.TBBridgeIP.Size = new System.Drawing.Size(233, 20);
			this.TBBridgeIP.TabIndex = 0;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.label3);
			this.groupBox4.Controls.Add(this.CBRooms);
			this.groupBox4.Location = new System.Drawing.Point(193, 113);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(301, 65);
			this.groupBox4.TabIndex = 5;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Room Selector";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(0, 27);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(62, 23);
			this.label3.TabIndex = 1;
			this.label3.Text = "Room:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// CBRooms
			// 
			this.CBRooms.FormattingEnabled = true;
			this.CBRooms.Location = new System.Drawing.Point(68, 29);
			this.CBRooms.Name = "CBRooms";
			this.CBRooms.Size = new System.Drawing.Size(227, 21);
			this.CBRooms.TabIndex = 0;
			this.CBRooms.SelectedIndexChanged += new System.EventHandler(this.CBRoomsSelectedIndexChanged);
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.BTCold);
			this.groupBox5.Controls.Add(this.BTNeutral);
			this.groupBox5.Controls.Add(this.BTWarm);
			this.groupBox5.Controls.Add(this.BTDecHue);
			this.groupBox5.Controls.Add(this.BTIncHue);
			this.groupBox5.Controls.Add(this.BTDecSat);
			this.groupBox5.Controls.Add(this.BTIncSat);
			this.groupBox5.Controls.Add(this.BTColSelect);
			this.groupBox5.Location = new System.Drawing.Point(18, 249);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(482, 300);
			this.groupBox5.TabIndex = 6;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Light Options";
			// 
			// BTCold
			// 
			this.BTCold.Location = new System.Drawing.Point(319, 166);
			this.BTCold.Name = "BTCold";
			this.BTCold.Size = new System.Drawing.Size(151, 43);
			this.BTCold.TabIndex = 7;
			this.BTCold.Text = "Cold (153)";
			this.BTCold.UseVisualStyleBackColor = true;
			this.BTCold.Click += new System.EventHandler(this.BTColdClick);
			// 
			// BTNeutral
			// 
			this.BTNeutral.Location = new System.Drawing.Point(155, 166);
			this.BTNeutral.Name = "BTNeutral";
			this.BTNeutral.Size = new System.Drawing.Size(163, 43);
			this.BTNeutral.TabIndex = 6;
			this.BTNeutral.Text = "Neutral (250)";
			this.BTNeutral.UseVisualStyleBackColor = true;
			this.BTNeutral.Click += new System.EventHandler(this.BTNeutralClick);
			// 
			// BTWarm
			// 
			this.BTWarm.Location = new System.Drawing.Point(6, 166);
			this.BTWarm.Name = "BTWarm";
			this.BTWarm.Size = new System.Drawing.Size(150, 43);
			this.BTWarm.TabIndex = 5;
			this.BTWarm.Text = "Warm (450)";
			this.BTWarm.UseVisualStyleBackColor = true;
			this.BTWarm.Click += new System.EventHandler(this.BTWarmClick);
			// 
			// BTDecHue
			// 
			this.BTDecHue.Location = new System.Drawing.Point(239, 117);
			this.BTDecHue.Name = "BTDecHue";
			this.BTDecHue.Size = new System.Drawing.Size(231, 43);
			this.BTDecHue.TabIndex = 4;
			this.BTDecHue.Text = "Deacrease HUE";
			this.BTDecHue.UseVisualStyleBackColor = true;
			this.BTDecHue.Click += new System.EventHandler(this.BTDecHueClick);
			// 
			// BTIncHue
			// 
			this.BTIncHue.Location = new System.Drawing.Point(6, 117);
			this.BTIncHue.Name = "BTIncHue";
			this.BTIncHue.Size = new System.Drawing.Size(231, 43);
			this.BTIncHue.TabIndex = 3;
			this.BTIncHue.Text = "Increase HUE";
			this.BTIncHue.UseVisualStyleBackColor = true;
			this.BTIncHue.Click += new System.EventHandler(this.BTIncHueClick);
			// 
			// BTDecSat
			// 
			this.BTDecSat.Location = new System.Drawing.Point(239, 68);
			this.BTDecSat.Name = "BTDecSat";
			this.BTDecSat.Size = new System.Drawing.Size(231, 43);
			this.BTDecSat.TabIndex = 2;
			this.BTDecSat.Text = "Decrease Saturation";
			this.BTDecSat.UseVisualStyleBackColor = true;
			this.BTDecSat.Click += new System.EventHandler(this.BTDecSatClick);
			// 
			// BTIncSat
			// 
			this.BTIncSat.Location = new System.Drawing.Point(6, 68);
			this.BTIncSat.Name = "BTIncSat";
			this.BTIncSat.Size = new System.Drawing.Size(231, 43);
			this.BTIncSat.TabIndex = 1;
			this.BTIncSat.Text = "Increase Saturation";
			this.BTIncSat.UseVisualStyleBackColor = true;
			this.BTIncSat.Click += new System.EventHandler(this.BTIncSatClick);
			// 
			// BTColSelect
			// 
			this.BTColSelect.Location = new System.Drawing.Point(6, 19);
			this.BTColSelect.Name = "BTColSelect";
			this.BTColSelect.Size = new System.Drawing.Size(464, 43);
			this.BTColSelect.TabIndex = 0;
			this.BTColSelect.Text = "Select Colour";
			this.BTColSelect.UseVisualStyleBackColor = true;
			this.BTColSelect.Click += new System.EventHandler(this.BTColSelectClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(512, 574);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "HUEston";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.BSCBRooms)).EndInit();
			this.groupBox5.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem scenesToolStripMenuItem;
		private System.Windows.Forms.Button BTColSelect;
		private System.Windows.Forms.Button BTIncSat;
		private System.Windows.Forms.Button BTDecSat;
		private System.Windows.Forms.Button BTIncHue;
		private System.Windows.Forms.Button BTDecHue;
		private System.Windows.Forms.Button BTWarm;
		private System.Windows.Forms.Button BTNeutral;
		private System.Windows.Forms.Button BTCold;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.BindingSource BSCBRooms;
		private System.Windows.Forms.ComboBox CBRooms;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.TextBox TBBridgeUser;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ToolStripMenuItem presetsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem bridgeToolStripMenuItem;
		private System.Windows.Forms.TextBox TBBridgeIP;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button BTOn;
		private System.Windows.Forms.Button BTOff;
		private System.Windows.Forms.Button BTBriUP;
		private System.Windows.Forms.Button BTBriDown;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem lampsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem roomsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem overviewToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripStatusLabel SSRoomQTY;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.ToolStripStatusLabel SSLampQTY;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.StatusStrip statusStrip1;
	}
}
