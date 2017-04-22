/*
 * Created by SharpDevelop.
 * User: Mario
 * Date: 22.02.2017
 * Time: 11:58
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Globalization;

namespace HUEston
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		HUEFunctions hf;
		int selGID = 0;
		List<HUEstonPreset> presetList = new List<HUEstonPreset>();
		Thread[] presetArray;
		Button[] referencePresetButtons = new Button[6];
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			
			SimpleCFGReader configReader = new SimpleCFGReader();
			
			// read config file			
			if(File.Exists("./config.cfg"))
			{
				string[] cfgfile = configReader.readCFG("./config.cfg");
				TBBridgeIP.Text = cfgfile[0];
				TBBridgeUser.Text = cfgfile[1];
				// construct HUEFunctions class with read values
				hf = new HUEFunctions(cfgfile[0],cfgfile[1]);
				// acquire all lights
				hf.LightList = hf.getLights();
				hf.GroupList = hf.getGroups();
				SSLampQTY.Text = hf.LightList.Count.ToString();
				BSCBRooms.DataSource = hf.GroupList;
				SSRoomQTY.Text = (hf.GroupList.Count-1).ToString();
				CBRooms.DisplayMember = "name";
				CBRooms.ValueMember = "gid";
				CBRooms.DataSource = BSCBRooms.DataSource;
				CBRooms.BindingContext = this.BindingContext;
				
					// load presets
					if(File.Exists("./presets.cfg"))
					{
						string[] rawPresets = configReader.readCFG("./presets.cfg");
						
						
						// each preset consists of four lines: id, name, sleep, commands
						// check if file is corrups by modulo and zero
						
						if(rawPresets.Length%4 != 0 || rawPresets.Length == 0)
						{
							MessageBox.Show("Your preset config file is corrupt, please check your preset.cfg!","[HUEston] Presetfile corrupt",MessageBoxButtons.OK,MessageBoxIcon.Error);
						}
						
						int additionalArrayIndexer = 0;
						presetArray = new Thread[rawPresets.Length/4];
						
						
						// fix for dirty coding style, since exceptions would be thrown if the buttons were available
						if(presetArray.Length < 6)
						{
							for(int i = presetArray.Length+1; i<=6; i++)
							{
								switch(i)
								{
									case 1:
										BTPreset1.Hide();
										break;
									case 2:
										BTPreset2.Hide();
										break;
									case 3:
										BTPreset3.Hide();
										break;
									case 4:
										BTPreset4.Hide();
										break;
									case 5:
										BTPreset5.Hide();
										break;
									case 6:
										BTPreset6.Hide();
										break;
								}
							}
						}
						
						for(int i = 0; i<rawPresets.Length; i=i+4)
						{
							int id = Convert.ToInt32(rawPresets[i].Substring(0,rawPresets[i].IndexOf(":")));
							string name = rawPresets[i+1].Substring(rawPresets[i+1].IndexOf(":")+1);
							int sleep = Convert.ToInt32(rawPresets[i+2].Substring(rawPresets[i+2].IndexOf(":")+1));
							string commands = rawPresets[i+3].Substring(rawPresets[i+3].IndexOf(":")+1);
							
							HUEstonPreset tempPreset = new HUEstonPreset(name,sleep,id,commands,hf);
							presetList.Add(tempPreset);
							presetArray[additionalArrayIndexer] = tempPreset.getExectueThread();
								
							// this is a little bit dirty, but the buttons are hardcoded here by design, not the best decision, but cba to change it at this state
								
								switch(++additionalArrayIndexer)
								{
								case 1:
									BTPreset1.Text = name;
									break;
								case 2:
									BTPreset2.Text = name;
									break;
								case 3:
									BTPreset3.Text = name;
									break;
								case 4:
									BTPreset4.Text = name;
									break;
								case 5:
									BTPreset5.Text = name;
									break;
								case 6:
									BTPreset6.Text = name;
									break;
								}	
						}
						
						
					}
					else
					{
						// for testing and demonstration:
						HUEstonPreset preset1 = new HUEstonPreset("Colour Loop",1000,1,"loop|GRPhueIncManual:1,250",hf);
						presetList.Add(preset1);
						presetArray = new Thread[1];
						presetArray[0] = preset1.getExectueThread();
						BTPreset1.Text = preset1.name;
						BTPreset2.Hide();
						BTPreset3.Hide();
						BTPreset4.Hide();
						BTPreset5.Hide();
						BTPreset6.Hide();
					}
					
						SSPresetQTY.Text = presetList.Count.ToString();
						referencePresetButtons[0] = BTPreset1;
						referencePresetButtons[1] = BTPreset2;
						referencePresetButtons[2] = BTPreset3;
						referencePresetButtons[3] = BTPreset4;
						referencePresetButtons[4] = BTPreset5;
						referencePresetButtons[5] = BTPreset6;
					
				
			}
			else
			{
				this.WindowState = FormWindowState.Minimized;
				this.ShowInTaskbar = false;
				MessageBox.Show("Please setup HUEston now - we'll try to autodetect the bridge first, if this won't work, you'll have to enter the IP Address manually.","[HUEston] Initial Setup",MessageBoxButtons.OK,MessageBoxIcon.Information);
				Setup setup = new Setup();
				setup.Show();
				
			}
		}
		
		void BridgeToolStripMenuItemClick(object sender, EventArgs e)
		{
				Setup setup = new Setup();
				setup.Show();
		}
		
		void BTOnClick(object sender, EventArgs e)
		{
			hf.GRPturnOn(hf.GroupList[selGID].gid);		
		}
		
		void BTOffClick(object sender, EventArgs e)
		{
			hf.GRPturnOff(hf.GroupList[selGID].gid);	
		}
			
		
		void BTBriUPClick(object sender, EventArgs e)
		{
			hf.GRPbriUP(hf.GroupList[selGID].gid);		
		}
		
		void BTBriDownClick(object sender, EventArgs e)
		{
			hf.GRPbriDown(hf.GroupList[selGID].gid);
		}
		
		void CBRoomsSelectedIndexChanged(object sender, EventArgs e)
		{
			selGID =  Convert.ToInt32(CBRooms.SelectedValue.ToString());
			selGID =  hf.GroupList.FindIndex(id => id.gid == selGID);
		}
		
		void BTColSelectClick(object sender, EventArgs e)
		{
				hf.switchColourDialog(selGID);
				/*
 				see http://www.niwa.nu/2013/05/math-behind-colorspace-conversions-rgb-hsl/			
				double min = 256;
				double max = -1;
				int maxIndex;
				
				for(int i = 0; i<rgb.Length; i++)
				{
					min = Math.Min(rgb[i],min);
					max = Math.Max(rgb[i],max);
					if(Math.Equals(max,rgb[i]))
					{
						maxIndex = i;
					}
				}
				
				double luminance = (max+min)/2.00D;
				double sat = 0;
				
				if(!Math.Equals(min,max))
				{
					if(luminance <= 0.5)
					{
						sat = (max-min)/(max+min);
					}
					else
					{
						sat = (max-min)/(2.0-max-min);
					}
				}
				
				double hue = 0.00;
				
				switch(maxIndex)
				{
					case 1:
					// red is max
					hue = (rgb[1]-rgb[2])/(max-min);
					break;
					case 2:
					// green is max
					hue = 2.0D+(rgb[2]-rgb[0})/(max-min);
					break;
					case 3: 
					// blue is max
					hue = 4.0D+(rgb[0]-rgb[1])/(max-min);
					break;
				}
				if(hue < 0)
				{
					hue += 360;
				}
				hue = hue*60;
				*/		
			
		}
		
		void BTIncSatClick(object sender, EventArgs e)
		{
			hf.GRPsatInc(hf.GroupList[selGID].gid);
		}
		
		void BTDecSatClick(object sender, EventArgs e)
		{
			hf.GRPsatDec(hf.GroupList[selGID].gid);
		}
		
		void BTIncHueClick(object sender, EventArgs e)
		{
			hf.GRPhueInc(hf.GroupList[selGID].gid);
		}
		
		void BTDecHueClick(object sender, EventArgs e)
		{
			hf.GRPhueDec(hf.GroupList[selGID].gid);
		}
		
		void BTWarmClick(object sender, EventArgs e)
		{
			hf.GRPsetCT(hf.GroupList[selGID].gid,450);
		}
		
		void BTNeutralClick(object sender, EventArgs e)
		{
			hf.GRPsetCT(hf.GroupList[selGID].gid,250);
		}
		
		void BTColdClick(object sender, EventArgs e)
		{
			hf.GRPsetCT(hf.GroupList[selGID].gid,153);
		}
		
		void DashboardToolStripMenuItemClick(object sender, EventArgs e)
		{
			RoomDashboard RD = new RoomDashboard(hf);
			RD.Show();
		}
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			for(int i = 0; i<presetArray.Length; i++)
			{
				try
				{presetArray[i].Abort();}
				catch(ThreadInterruptedException)
				{}
			}
			Application.Exit();
		}
		
		void DashboardToolStripMenuItem1Click(object sender, EventArgs e)
		{
			LightDashboard LD = new LightDashboard(hf);
			LD.Show();
			
		}
		
		void AboutToolStripMenuItemClick(object sender, EventArgs e)
		{
			MessageBox.Show("HUEston Version 0.55 - 22.04.2017 - written by Mario-Luca Hoffmann \nhttps://github.com/maio290/HUEston","HUEston - About",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}
		

		
		void BTPreset1Click(object sender, EventArgs e)
		{
			if(!presetArray[0].IsAlive || presetArray[0].ThreadState == ThreadState.Stopped)
			{
				presetArray[0] = presetList[0].getExectueThread();
				if(presetList[0].content.Contains("loop"))
				{
					BTPreset1.ForeColor  = Color.Green;
				}
				presetArray[0].Start();
			}
			else
			{
				try
				{presetArray[0].Abort();}
				catch(ThreadInterruptedException)
				{}
				presetArray[0].Join();
				
				if(presetList[0].content.Contains("loop"))
				{
					BTPreset1.ForeColor  = Color.Red;
				}				
			}
		}
		
		void ShowGroupsToolStripMenuItemClick(object sender, EventArgs e)
		{
			TextboxForm tb = new TextboxForm(1,hf);
			tb.Show();
		}
		
		void ShowLightsToolStripMenuItemClick(object sender, EventArgs e)
		{
			TextboxForm tb = new TextboxForm(2,hf);
			tb.Show();
		}

		
		void ShowAllToolStripMenuItemClick(object sender, EventArgs e)
		{
			TextboxForm tb = new TextboxForm(3,hf);
			tb.Show();
		}
		
		void ShowFunctionsToolStripMenuItemClick(object sender, EventArgs e)
		{
			TextboxForm tb = new TextboxForm(4,hf);
			tb.Show();
		}

		
		void BuildPresetToolStripMenuItemClick(object sender, EventArgs e)
		{
			
		}
		
		void BTPreset2Click(object sender, EventArgs e)
		{
			if(!presetArray[1].IsAlive || presetArray[1].ThreadState == ThreadState.Stopped)
			{
				presetArray[1] = presetList[1].getExectueThread();
				
				if(presetList[1].content.Contains("loop"))
				{BTPreset2.ForeColor  = Color.Green;}
				
				presetArray[1].Start();
				presetArray[1].Join();
			}
			else
			{
				try
				{presetArray[1].Abort();}
				catch(ThreadInterruptedException)
				{}
				presetArray[1].Join();
				if(presetList[1].content.Contains("loop"))
				{BTPreset2.ForeColor  = Color.Red;}
			}			
		}
		
		void BTPreset3Click(object sender, EventArgs e)
		{
			if(!presetArray[2].IsAlive || presetArray[2].ThreadState == ThreadState.Stopped)
			{
				presetArray[2] = presetList[2].getExectueThread();
				if(presetList[2].content.Contains("loop"))
				{BTPreset3.ForeColor  = Color.Green;}
				presetArray[2].Start();
			}
			else
			{
				try
				{presetArray[2].Abort();}
				catch(ThreadInterruptedException)
				{}
				presetArray[2].Join();
				if(presetList[2].content.Contains("loop"))
				{BTPreset3.ForeColor  = Color.Red;}
			}			
		}
		
		void BTPreset4Click(object sender, EventArgs e)
		{
			if(!presetArray[3].IsAlive || presetArray[3].ThreadState == ThreadState.Stopped)
			{
				presetArray[3] = presetList[3].getExectueThread();
				if(presetList[3].content.Contains("loop"))
				{BTPreset4.ForeColor  = Color.Green;}
				presetArray[3].Start();
			}
			else
			{
				try
				{presetArray[3].Abort();}
				catch(ThreadInterruptedException)
				{}
				presetArray[3].Join();
				if(presetList[3].content.Contains("loop"))
				{BTPreset4.ForeColor  = Color.Red;}
			}			
		}
		
		void BTPreset5Click(object sender, EventArgs e)
		{
			if(!presetArray[4].IsAlive || presetArray[4].ThreadState == ThreadState.Stopped)
			{
				presetArray[4] = presetList[4].getExectueThread();
				if(presetList[4].content.Contains("loop"))
				{BTPreset5.ForeColor  = Color.Green;}
				presetArray[4].Start();
			}
			else
			{
				try
				{presetArray[4].Abort();}
				catch(ThreadInterruptedException)
				{}
				presetArray[4].Join();
				if(presetList[4].content.Contains("loop"))
				{BTPreset5.ForeColor  = Color.Red;}
			}			
		}
		
		void BTPreset6Click(object sender, EventArgs e)
		{
			if(!presetArray[5].IsAlive || presetArray[5].ThreadState == ThreadState.Stopped)
			{
				presetArray[5] = presetList[5].getExectueThread();
				if(presetList[5].content.Contains("loop"))
				{BTPreset6.ForeColor  = Color.Green;}
				presetArray[5].Start();
			}
			else
			{
				try
				{presetArray[5].Abort();}
				catch(ThreadInterruptedException)
				{}
				presetArray[5].Join();
				if(presetList[5].content.Contains("loop"))
				{BTPreset6.ForeColor  = Color.Red;}
			}			
		}
		
		void DashboardToolStripMenuItem2Click(object sender, EventArgs e)
		{
			PresetDashboard pd = new PresetDashboard(presetList,presetArray,referencePresetButtons);
			pd.Show();
		}
	}
}
