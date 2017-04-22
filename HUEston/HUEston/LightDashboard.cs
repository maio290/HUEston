/*
 * User: Mario
 * Date: 28.03.2017
 * Time: 14:04
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace HUEston
{
	/// <summary>
	/// LightDashboard Form
	/// </summary>
	public partial class LightDashboard : Form
	{
		
		HUEFunctions hf;
		TrackBar[] TrackBarList;
		Thread stateLooper;
		
		public LightDashboard(HUEFunctions HF)
		{
			hf = HF;
			InitializeComponent();
			
			TrackBarList = new TrackBar[hf.LightList.Count];
			
			for(int i = 0; i<hf.LightList.Count; i++)
			{
				Button bt = new Button();
				bt.Text = hf.LightList[i].name;
				bt.Tag = "showGroup:"+hf.LightList[i].id;
				bt.AutoSize = true;
				bt.Click += buttonClick;
				
				// add control elements for the room
				
				Button on = new Button();
				on.Text = "On";
				on.Tag = "on:"+hf.LightList[i].id;
				on.AutoSize = true;
				on.BackColor = Color.Green;
				on.ForeColor = Color.White;
				on.Click += buttonClick;
				Button off = new Button();
				off.Text = "Off";
				off.Tag = "off:"+hf.LightList[i].id;
				off.BackColor = Color.Red;
				off.ForeColor = Color.White;
				off.AutoSize = true;
				off.Click += buttonClick;
				
				Button sc = new Button();
				sc.Text = "Colour";
				sc.Tag = "sc:"+hf.LightList[i].id;
				sc.AutoSize = true;
				sc.Click += buttonClick;
				
				// add empty label for new line force
				

				
				Label newLine = new Label();
				newLine.Height = 1;
				newLine.Width = FLPLights.Width;
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
				brightness.Tag = "BRI:"+hf.LightList[i].id;
				brightness.Scroll += briChange;
				TrackBarList[i] = brightness;

				//hf.extractGroupStates(hf.LightList[i].id);
				
				FLPLights.Controls.Add(bt);
				FLPLights.Controls.Add(on);
				FLPLights.Controls.Add(off);
				FLPLights.Controls.Add(sc);
				FLPLights.Controls.Add(newLine);
				FLPLights.Controls.Add(brightness);
				FLPLights.Controls.Add(newLine);
			}
			FLPLights.HorizontalScroll.Maximum = 0;
			FLPLights.VerticalScroll.Visible = false;
			FLPLights.AutoScroll = true;
			stateLooper = new Thread(stateLoop);
			stateLooper.Start();			
			
			
			
		}
		
		private void buttonClick(object sender, EventArgs e)
		{
			Button clicked = (Button)sender;
			string functionRAW = Convert.ToString(clicked.Tag);
	
			string function =  functionRAW.Substring(0,functionRAW.IndexOf(":"));
			int ID = Convert.ToInt32(functionRAW.Substring(functionRAW.IndexOf(":")+1));
			
			switch(function)
			{
				case "showGroup":
				break;
				case "sc":
				hf.switchColourDialogID(ID);
				break;
				case "on":
				hf.turnOn(ID);
				break;
				case "off":
				hf.turnOff(ID);
				break;
					
			}
			
		}
		
		private void stateLoop()
		{
			while(true)
			{
				for(int i = 0; i<hf.LightList.Count; i++)
				{
					string json = hf.getState(hf.LightList[i].id);
					if(TrackBarList[i].InvokeRequired)
					{
						// which is always true
						TrackBarList[i].Invoke((MethodInvoker) delegate{TrackBarList[i].Value = hf.extractBri(json);});
					}
				}
				Thread.Sleep(1000);
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
				hf.setBRI(GID,changed.Value);
				break;
					
			}
			
		}
		
		
		void LightDashboardFormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{stateLooper.Abort();}
			catch(ThreadInterruptedException){}			
		}
	}
}
