/*
 * User: Mario
 * Date: 22.02.2017
 * Time: 13:43
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HUEston
{
	/// <summary>
	/// Setupform for the Bridge
	/// </summary>
	public partial class Setup : Form
	{
		
		bool lockAcquire = false;
		
		public Setup()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			GetIP service = new GetIP(1);
			
			if(service.id.Length != 0)
			{
				MessageBox.Show("Detected HUE Bridge with IP: "+service.ip,"[HUEston] HUE Bridge detected!",MessageBoxButtons.OK,MessageBoxIcon.Information);
				TBIP.Text = service.ip;
				TBID.Text = service.id;
			}
			
			
			
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void BTCheckIPClick(object sender, EventArgs e)
		{
			if(TBIP.Text.Length == 0)
			{
				MessageBox.Show("Please enter an IP-Address!","[HUEston] No IP-Address",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
			else
			{
					HUEFunctions hf = new HUEFunctions(TBIP.Text);
					bool isHue = hf.isHue();
					
					if(!isHue)
					{
						LBResponse.Text = "not ok";
						lockAcquire = true;
						LBResponse.ForeColor = Color.Red;
						TBID.Text = "";
						
						
					}
					else
					{
						LBResponse.Text = "OK";
						lockAcquire = false;
						LBResponse.ForeColor = Color.Green;
						TBID.Text = "";
					}
			}
		}
		
		void BTAcquireUsernameClick(object sender, EventArgs e)
		{
			
			if(TBIP.Text.Equals(String.Empty))
			{
				MessageBox.Show("Please enter an IP-Address!","[HUEston] No IP-Address",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
			else
			{
				if(lockAcquire)
				{
					if(MessageBox.Show("HUE Bridge wasn't detected under the IP-Address: "+TBIP.Text+" - do you want to continue anyway?","[HUEston] Error while detecting Bridge",MessageBoxButtons.OKCancel,MessageBoxIcon.Error) != DialogResult.OK)
					{
						return;
					}
				}
				
				// Begin AUTH Process with HUE Bridge
				HUEFunctions hf = new HUEFunctions(TBIP.Text);
				hf.auth();
				
				if(hf.authresponse.Equals(String.Empty))
				{
					MessageBox.Show("Failed to auth user after 5 seconds - please press the Button on your Bridge first!","[HUEston] Error while acquiring username",MessageBoxButtons.OK,MessageBoxIcon.Error);
					return;
				}
				else
				{
					string usernameJSON = hf.authresponse;
					
					int usernameStart = usernameJSON.IndexOf("username")+11;
					int usernameEnd = usernameJSON.IndexOf('"',usernameStart);
					
					string username = usernameJSON.Substring(usernameStart,usernameEnd-usernameStart);

					SimpleCFGWriter cfg = new SimpleCFGWriter(TBIP.Text,username);
					this.Dispose();
					
				}
				
				
			}
			
		}
		
		void SetupFormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Restart();
		}
	}
}
