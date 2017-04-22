/*
 * User: Mario
 * Date: 12.04.2017
 * Time: 22:23
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace HUEston
{
	/// <summary>
	/// Description of TextboxForm.
	/// </summary>
	public partial class TextboxForm : Form
	{
		int mode;
		HUEFunctions hf;
		public TextboxForm(int mode, HUEFunctions hf)
		{
			
			this.mode = mode;
			this.hf = hf;
			
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			this.updateTextbox();
		}
		
		protected string getFunctions()
		{
			string ret = "";
			Type[] hfTypes = Assembly.LoadFrom(Application.ExecutablePath).GetTypes();
			ret += "This is a full list of all callable functions: \r\n\r\n";			
			foreach(Type type in hfTypes)
			{
				//ret += type.FullName+"\r\n";
				if(type.FullName.Equals("HUEston.HUEFunctions"))
				{
					MemberInfo[] methods = type.GetMethods();
					int counter = 0;						
					foreach(MemberInfo info in methods)
					{
						if(counter <= 13)
						{
							counter++;
							continue;
						}
						
						if(info.Name.ToString().Equals("switchColourDialog"))
						{
							break;
						}
						
						ret += info.Name.ToString();
						ParameterInfo[] pars = type.GetMethod(info.Name).GetParameters();
						ret += "(";
						for(int i = 0; i<pars.Length; i++)
						{
							ret += pars[i].ParameterType.Name+" "+pars[i].Name;
							
							if(i != pars.Length-1)
							{
								ret += ",";
							}
							
						}
						ret += ")\r\n\r\n";
						
						
						
					}
					
				}
			}

			return ret;			
		}
		
		protected void updateTextbox()
		{
			switch(mode)
			{
				case 1:
					// groups
					TBInfo.Text += "You can use the following GroupIDs for group-based functions:\r\n\r\n";
					foreach(Group grp in hf.GroupList)
					{
						TBInfo.Text += "Group:	"+grp.name+"\r\n"+"	GID:	"+grp.gid+"\r\n"+"	Assinged Bulbs:	"+grp.bulbs+"\r\n\r\n";
					}
					break;
				case 2:
					// lights
					TBInfo.Text += "You can use the following LightIDs for light-based functions:\r\n\r\n";
					foreach(Light light in hf.LightList)
					{
						TBInfo.Text += "Light:	"+light.name+"\r\n"+"	ID:	"+light.id+"\r\n\r\n";
					}					
					break;
				case 3:
					//all
					TBInfo.Text += "You can use the following GroupIDs for group-based functions:\r\n\r\n";
					foreach(Group grp in hf.GroupList)
					{
						TBInfo.Text += "Group:	"+grp.name+"\r\n"+"	GID:	"+grp.gid+"\r\n"+"	Assigned Bulbs:	"+grp.bulbs+"\r\n\r\n";
					}					
					TBInfo.Text += "You can use the following LightIDs for light-based functions:\r\n\r\n";
					foreach(Light light in hf.LightList)
					{
						TBInfo.Text += "Light:	"+light.name+"\r\n"+"	ID:	"+light.id+"\r\n\r\n";
					}
					TBInfo.Text += getFunctions();					
					break;
				case 4:
					// functions
					TBInfo.Text += getFunctions();
					break;					
			}
		}
		
		
		
		void BTSaveClick(object sender, EventArgs e)
		{
			SaveFileDialog sf = new SaveFileDialog();
			sf.DefaultExt = "txt";
			sf.InitialDirectory = Application.StartupPath;
			sf.Filter =  "Text files (*.txt)|*.txt|All files (*.*)|*.*";
			sf.FileName = "HUEStonExtract";
			sf.CreatePrompt = true;
			DialogResult result = sf.ShowDialog();
			
			if(result == DialogResult.OK)
			{
				if(!File.Exists(sf.FileName))
				{
					File.Create(sf.FileName);
				}
				File.AppendAllText(sf.FileName,TBInfo.Text);
			}
			
		}
	}
}
