/*
 * User: Mario
 * Date: 22.04.2017
 * Time: 05:35
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;

namespace HUEston
{
	/// <summary>
	/// Description of PresetDashboard.
	/// </summary>
	public partial class PresetDashboard : Form
	{
		List<HUEstonPreset> presetList;
		Thread[] threadArray;
		Thread stateLooper;
		List<Button> buttonList;
		Button[] referenceList;
		public PresetDashboard(List<HUEstonPreset> pl, Thread[] ta, Button[] ra)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			this.presetList = pl;
			this.threadArray = ta;
			this.buttonList = new List<Button>();
			this.referenceList = ra;
			
			
			for(int i = 0; i<presetList.Count; i++)
			{
				Button bt = new Button();
				bt.Text = presetList[i].name;
				bt.Tag = presetList[i].id-1;
				bt.AutoSize = true;
				bt.Click += buttonClick;
				buttonList.Add(bt);
				threadArray[i] = presetList[i].getExectueThread();
				if(threadArray[i].IsAlive && presetList[i].content.Contains("loop"))
				{
					bt.ForeColor = Color.Green;
				}
				FLPPreset.Controls.Add(bt);
			}
			
			FLPPreset.HorizontalScroll.Maximum = 0;
			FLPPreset.VerticalScroll.Visible = false;
			FLPPreset.AutoScroll = true;	
			stateLooper = new Thread(stateLoop);
			stateLooper.Start();						
			
		}
		
		private void buttonClick(object sender, EventArgs e)
		{
			Button clicked = (Button)sender;
			
			int id = Convert.ToInt32(clicked.Tag);
			if(!threadArray[id].IsAlive || threadArray[id].ThreadState == ThreadState.Stopped)
			{
				threadArray[id] = presetList[id].getExectueThread();
				if(presetList[0].content.Contains("loop"))
				{
					clicked.ForeColor  = Color.Green;
				}
				threadArray[id].Start();
			}
			else
			{
				try
				{threadArray[id].Abort();}
				catch(ThreadInterruptedException)
				{}
				threadArray[id].Join();
				
				if(presetList[0].content.Contains("loop"))
				{
					clicked.ForeColor  = Color.Red;
				}				
			}		
				
		}

		private void stateLoop()
		{
			while(true)
			{
				for(int i = 0; i<threadArray.Length; i++)
				{
					if(threadArray[i].IsAlive)
					{
						if(i<=5)
						{
							referenceList[i].ForeColor = Color.Green;
						}
						buttonList[i].ForeColor = Color.Green;
					}
					else
					{
						if(i<=5)
						{
							referenceList[i].ForeColor = Color.Red;
						}						
						buttonList[i].ForeColor = Color.Red;
					}
				}
				Thread.Sleep(1000);
			}
		}			
		
		
		void PresetDashboardFormClosing(object sender, FormClosingEventArgs e)
		{
		
			try
			{stateLooper.Abort();}
			catch(ThreadInterruptedException){}
								
		}
	}
}
