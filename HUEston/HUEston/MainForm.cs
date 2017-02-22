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
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			// read config file			
			if(File.Exists("./config.cfg"))
			{
				string[] cfgfile = SimpleCFGReader.readCFG();
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
				
			}
			else
			{
				MessageBox.Show("Please setup HUEston now - we'll try to autodetect the bridge first, if this won't work, you'll have to enter the IP Address manually.","[HUEston] Initial Setup",MessageBoxButtons.OK,MessageBoxIcon.Information);
				Setup setup = new Setup();
				setup.Show();
			}
			
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void BridgeToolStripMenuItemClick(object sender, EventArgs e)
		{
				this.Hide();
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
		}
		
		void BTColSelectClick(object sender, EventArgs e)
		{
			Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
			ColorDialog colPick = new ColorDialog();
			DialogResult colResult = colPick.ShowDialog();
			if(colResult == DialogResult.OK)
			{
				// see http://www.niwa.nu/2013/05/math-behind-colorspace-conversions-rgb-hsl/
				Color RGB = colPick.Color;
				double[] rgb = new Double[3]; 
				rgb[0] = Convert.ToDouble(RGB.R);
				rgb[1] = Convert.ToDouble(RGB.G);
				rgb[2] = Convert.ToDouble(RGB.B);
				double a = Convert.ToDouble(RGB.A);
					
				/*			
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
				

				// this is according to https://github.com/PhilipsHue/PhilipsHueSDK-iOS-OSX/commit/f41091cf671e13fe8c32fcced12604cd31cceaf3
				rgb[0] /= 255D;
				rgb[1] /= 255D;
				rgb[2] /= 255D;

				// fix colours
				for(int i = 0; i<rgb.Length; i++)
				{
					if(rgb[i] > 0.04045D)
					{
						rgb[i] = Math.Pow((rgb[i]+0.55D)/(1.0D+0.055D),2.4D);
					}
					else
					{
						rgb[i] /= 12.92D;
					}
				}

				double X = rgb[0] * 0.649926D + rgb[1] * 0.103455D + rgb[2] * 0.197109D;
			   
				double Y = rgb[0] * 0.234327D + rgb[1] * 0.743075D + rgb[2] * 0.022598D;
			   
				double Z = rgb[0] * 0.0000000D + rgb[1] * 0.053077D + rgb[2] * 1.035763D;
				
				double x = Math.Round(X/(X+Y+Z),3);
				double y = Math.Round(Y/(X+Y+Z),3);
				
				hf.GRPsetXY(hf.GroupList[selGID].gid,x,y);
											
			
				
			}
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
	}
}
