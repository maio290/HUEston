/*
 * User: Mario
 * Date: 23.02.2017
 * Time: 09:29
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace HUEston
{
	/// <summary>
	/// Description of RoomDashboard.
	/// </summary>
	public partial class RoomDashboard : Form
	{
		
		
		HUEFunctions hf;
		TrackBar[] TrackBarList;
		Thread stateLooper;
		public RoomDashboard(HUEFunctions HF)
		{
			hf = HF;
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			TrackBarList = new TrackBar[hf.GroupList.Count];
			
			for(int i = 0; i<hf.GroupList.Count; i++)
			{
				Button bt = new Button();
				bt.Text = hf.GroupList[i].name;
				bt.Tag = "showGroup:"+hf.GroupList[i].gid;
				bt.AutoSize = true;
				bt.Click += buttonClick;
				
				// add control elements for the room
				
				Button on = new Button();
				on.Text = "On";
				on.Tag = "on:"+hf.GroupList[i].gid;
				on.AutoSize = true;
				on.BackColor = Color.Green;
				on.ForeColor = Color.White;
				on.Click += buttonClick;
				Button off = new Button();
				off.Text = "Off";
				off.Tag = "off:"+hf.GroupList[i].gid;
				off.BackColor = Color.Red;
				off.ForeColor = Color.White;
				off.AutoSize = true;
				off.Click += buttonClick;
				
				Button sc = new Button();
				sc.Text = "Colour";
				sc.Tag = "sc:"+hf.GroupList[i].gid;
				sc.AutoSize = true;
				sc.Click += buttonClick;
				
				// add empty label for new line force
				

				
				Label newLine = new Label();
				newLine.Height = 1;
				newLine.Width = FLPRooms.Width;
				newLine.AutoSize = false;
				
				
				
				TrackBar brightness = new TrackBar();
				brightness.Width = 325; 
				brightness.Maximum = 254;
				brightness.Minimum = 1;
				brightness.TickFrequency = 25;
				brightness.LargeChange = 50;
				brightness.SmallChange = 25;
				brightness.TabIndex = 0;
				brightness.TickStyle = System.Windows.Forms.TickStyle.None;
				brightness.Tag = "BRI:"+hf.GroupList[i].gid;
				brightness.Scroll += briChange;
				TrackBarList[i] = brightness;

				hf.extractGroupStates(hf.GroupList[i].gid);
				
				FLPRooms.Controls.Add(bt);
				FLPRooms.Controls.Add(on);
				FLPRooms.Controls.Add(off);
				FLPRooms.Controls.Add(sc);
				FLPRooms.Controls.Add(newLine);
				FLPRooms.Controls.Add(brightness);
				FLPRooms.Controls.Add(newLine);
			}
			FLPRooms.HorizontalScroll.Maximum = 0;
			FLPRooms.VerticalScroll.Visible = false;
			FLPRooms.AutoScroll = true;
			stateLooper = new Thread(stateLoop);
			stateLooper.Start();
			
			
		}
		
		private void buttonClick(object sender, EventArgs e)
		{
			Button clicked = (Button)sender;
			string functionRAW = Convert.ToString(clicked.Tag);
	
			string function =  functionRAW.Substring(0,functionRAW.IndexOf(":"));
			int GID = Convert.ToInt32(functionRAW.Substring(functionRAW.IndexOf(":")+1));
			
			switch(function)
			{
				case "showGroup":
				break;
				case "sc":
				hf.switchColourDialog(GID);
				break;
				case "on":
				hf.GRPturnOn(GID);
				break;
				case "off":
				hf.GRPturnOff(GID);
				break;
					
			}
			
		}
		
		private void briChange(object sender, EventArgs e)
		{
			TrackBar changed = (TrackBar)sender;
			string functionRAW = Convert.ToString(changed.Tag);
	
			string function =  functionRAW.Substring(0,functionRAW.IndexOf(":"));
			int GID = Convert.ToInt32(functionRAW.Substring(functionRAW.IndexOf(":")+1));
			
			switch(function)
			{
				case "BRI":
				hf.GRPbriSet(GID,changed.Value);
				break;
					
			}
			
		}

		private void stateLoop()
		{
			while(true)
			{
				for(int i = 0; i<hf.GroupList.Count; i++)
				{
					hf.extractGroupStates(hf.GroupList[i].gid);
					if(hf.GroupList[i].stateFetch)
					{
						if(TrackBarList[i].InvokeRequired)
						{
							// which is always true
							TrackBarList[i].Invoke((MethodInvoker) delegate{TrackBarList[i].Value = hf.GroupList[i].bri;});
						}
					}
				}
				Thread.Sleep(1000);
			}
		}
		
		

		
		void RoomDashboardFormClosing(object sender, FormClosingEventArgs e)
		{

			try
			{stateLooper.Abort();}
			catch(ThreadInterruptedException){}
			
		}
	}
}
