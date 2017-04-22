/*
 * User: Mario
 * Date: 22.02.2017
 * Time: 12:20
 */
using System;
using System.Collections.Generic;
using System.Threading;
using System.Globalization;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Text;

namespace HUEston
{
	/// <summary>
	/// Description of HUEFunctions.
	/// </summary>
	public class HUEFunctions
	{
		string bridgeIP;
		string bridgeUser;
		Webservices ws;
		public List<Light> LightList;
		public List<Group> GroupList;
		public volatile string authresponse = String.Empty;
		
		public string devicetype = "{\"devicetype\":\""+appname+"#"+SystemUser+"\"}";
		static string SystemUser = System.Environment.MachineName;
		static string appname = "HUEston";
		
		public HUEFunctions(string ip)
		{
			bridgeIP = ip;
			ws = new Webservices();
		}

		public HUEFunctions(string ip, string user)
		{
			bridgeIP = ip;
			bridgeUser = user;
			ws = new Webservices();
		}


		public bool isHue()
		{
			string xmlResponse;
			
			try
			{
			xmlResponse = ws.getHTMLfromURL("http://"+bridgeIP+"/description.xml").ToLower();
			}
			catch(System.Net.WebException e)
			{
				return false;
			}
				
			if(xmlResponse.IndexOf("hue") != -1)
			{
				return true;
			}
			return false;
		}
		
		public string auth()
		{
			Thread authlooper = new Thread(authloop);
			authlooper.Start();
			
			while(authlooper.IsAlive)
			{}
			
			return authresponse;
				
		}
		
		public void authloop()
		{
			int tickcounter = 0;
			
			while(tickcounter<5)
			{
				string response = ws.postData("http://"+bridgeIP+"/api",devicetype);
				
				if(response.IndexOf("username") != -1)
				{
					authresponse = response;
					return;
				}
				tickcounter++;
				Thread.Sleep(1000);
				
			}
		}

		public int[] extractGroupPrimaries(string json)
		{
			
			List<int> primaries = new List<int>();
			
			for(int i = 1; i<100; i++)
			{
				if(json.IndexOf("\""+i+"\":{") != -1)
				{
					// Bugfix for deleted groups (yes, primary keys will not be shifted, even if the group was deleted)
					
					if(json.IndexOf("not available") != -1)
					{continue;}

					
					primaries.Add(i);
				}
			}
			
			int[] primaryKeys = new int[primaries.Count];
			
			for(int i = 0; i<primaryKeys.Length; i++)
			{
				primaryKeys[i] = primaries[i];
			}
			
			return primaryKeys;
			
			
		}
		
		public int[] extractLightPrimaries(string json)
		{
			
			List<int> primaries = new List<int>();
			
			for(int i = 1; i<100; i++)
			{
				if(json.IndexOf("\""+i+"\"") != -1)
				{	
					primaries.Add(i);
				}
			}
			
			int[] primaryKeys = new int[primaries.Count];
			
			for(int i = 0; i<primaryKeys.Length; i++)
			{
				primaryKeys[i] = primaries[i];
			}
			
			return primaryKeys;
			
			
		}
		
		public string getState(int id)
		{
			// get current json string from the current light id
			string JSONResponse;
			try{
			JSONResponse = ws.getHTMLfromURL("http://"+bridgeIP+"/api/"+bridgeUser+"/lights/"+id);	                  
			}
			catch(System.Net.WebException e)
			{
				return null;
			}	
			return JSONResponse;			
		}
		
		public int extractBri(string json)
		{
			int briStart = json.IndexOf("\"bri\":")+6;
			int briEnd = json.IndexOf(",",briStart);
			int bri = Convert.ToInt32(json.Substring(briStart,briEnd-briStart));
			return bri;                
		}
		
		public string[] extractBasicInfo(int primary, string json)
		{
			string[] basicInfo = new string[3];
			
			int bulbStart = json.IndexOf("\""+primary+"\"");
			
			// type
			int typeStart = json.IndexOf("\"type\":",bulbStart)+8;
			int typeEnd = json.IndexOf('"',typeStart);
			basicInfo[0] = json.Substring(typeStart,typeEnd-typeStart);
			// name
			int nameStart = json.IndexOf("\"name\":",bulbStart)+8;
			int nameEnd =  json.IndexOf('"',nameStart);
			basicInfo[1] = json.Substring(nameStart,nameEnd-nameStart);
			// uniqueid
			int uIDStart = json.IndexOf("\"uniqueid\":",bulbStart)+12;
			int uIDEnd =  json.IndexOf('"',uIDStart);
			basicInfo[2] = json.Substring(uIDStart,uIDEnd-uIDStart);
		
			return basicInfo;
			
		}
		
		public string[] extractGroupInfo(int primary, string json)
		{
			string[] groupInfo = new string[2];
			
			int GroupStart = json.IndexOf("\""+primary+"\"");
			
			int nameStart = json.IndexOf("\"name\":",GroupStart)+8;
			int nameEnd =  json.IndexOf('"',nameStart);
			groupInfo[0] = json.Substring(nameStart,nameEnd-nameStart);			
			
			int lightsStart = json.IndexOf("\"lights\":")+10;
			int lightsEnd = json.IndexOf(']',lightsStart);
			groupInfo[1] = json.Substring(lightsStart,lightsEnd-lightsStart);
			
			return groupInfo;			
			
		}

		public void extractGroupStates(int GID)
		{
			string JSONResponse;
			try{
			JSONResponse = ws.getHTMLfromURL("http://"+bridgeIP+"/api/"+bridgeUser+"/groups/"+GID);	                  
			}
			catch(System.Net.WebException e)
			{
				return;
			}
			Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
			try
			{
			int briStart = JSONResponse.IndexOf("bri")+5;
			int briEnd = JSONResponse.IndexOf(',',briStart);
			
			int bri = Convert.ToInt32(JSONResponse.Substring(briStart,briEnd-briStart));
			
			int onStart = JSONResponse.IndexOf("\"on\":")+5;
			int onEnd = JSONResponse.IndexOf(',',onStart);
			bool start = Convert.ToBoolean(JSONResponse.Substring(onStart,onEnd-onStart));
			
			int xyStart = JSONResponse.IndexOf("\"xy\":[")+6;
			int xyEnd = JSONResponse.IndexOf(']',xyStart);
			
			double x = Convert.ToDouble(JSONResponse.Substring(xyStart,JSONResponse.IndexOf(',',xyStart)-xyStart));
			double y = Convert.ToDouble(JSONResponse.Substring(JSONResponse.IndexOf(',',xyStart)+1,xyEnd-2-JSONResponse.IndexOf(',',xyStart)+1));
			
			int colourmodeStart = JSONResponse.IndexOf("colormode")+12;
			int colourmodeEnd = JSONResponse.IndexOf('"',colourmodeStart);
			
			string colourmode = JSONResponse.Substring(colourmodeStart,colourmodeEnd-colourmodeStart);
			
			int listindex = this.GroupList.FindIndex(id => id.gid == GID);
			this.GroupList[listindex].bri = bri;
			this.GroupList[listindex].on = start;
			this.GroupList[listindex].x = x;
			this.GroupList[listindex].y = y;
			this.GroupList[listindex].colourmode = colourmode;
			this.GroupList[listindex].stateFetch = true;
			}
			catch(FormatException)
			{return;}
			
			
			
			 
			
		}
		
		public string[][] extractState(int primary, string json)
		{
			// determine start offset
			int bulbStart = json.IndexOf("\""+primary+"\"");
			// determine state start offset
			int stateStart = json.IndexOf("\"state\"",bulbStart);
			// determine state end offset
			int stateEnd = json.IndexOf('}',stateStart);
			return null;
			
		}
		
	
		public List<Group> getGroups()
		{
			string JSONResponse;
			try{
			JSONResponse = ws.getHTMLfromURL("http://"+bridgeIP+"/api/"+bridgeUser+"/groups");	                  
			}
			catch(System.Net.WebException e)
			{
				return null;
			}	
			
			int[] groups = extractGroupPrimaries(JSONResponse);
			List<Group> GroupList = new List<Group>();
			GroupList.Add(new Group(0,"All",null));
			
			for(int i = 0; i<groups.Length; i++)
			{
				string[] tempinfo = extractGroupInfo(groups[i],JSONResponse);
				Group temp = new Group(groups[i],tempinfo[0],tempinfo[1]);
				GroupList.Add(temp);
			}			
			
			return GroupList;
		}
		
		public List<Light> getLights()
		{
			string JSONResponse;
			try{
			JSONResponse = ws.getHTMLfromURL("http://"+bridgeIP+"/api/"+bridgeUser+"/lights");	                  
			}
			catch(System.Net.WebException e)
			{
				return null;
			}
			

			int[] lights = extractLightPrimaries(JSONResponse);
			List<Light> LightList = new List<Light>();
			
			for(int i = 0; i<lights.Length; i++)
			{
				string[] tempinfo = extractBasicInfo(lights[i],JSONResponse);
				Light temp = new Light(lights[i],tempinfo[0],tempinfo[1],tempinfo[2]);
				LightList.Add(temp);
			}
			
			
			
			return LightList;		
		}
		
		// Bulb functions		
		public void turnOn(int id)
		{
			ws.putData("http://"+bridgeIP+"/api/"+bridgeUser+"/lights/"+id+"/state","{\"on\":true}");	
		}
		
		public void turnOff(int id)
		{
			ws.putData("http://"+bridgeIP+"/api/"+bridgeUser+"/lights/"+id+"/state","{\"on\":false}");	
		}		 
		
		public void briUP(int id)
		{
			ws.putData("http://"+bridgeIP+"/api/"+bridgeUser+"/lights/"+id+"/state","{\"bri_inc\":50}");
		}
		
		public void briDown(int id)
		{
			ws.putData("http://"+bridgeIP+"/api/"+bridgeUser+"/lights/"+id+"/state","{\"bri_inc\":-50}");
		}
		
		public void setXY(int id, double x, double y)
		{
			ws.putData("http://"+bridgeIP+"/api/"+bridgeUser+"/lights/"+id+"/state","{\"xy\":["+x+","+y+"]}");
		}
		
		public void setBRI(int id, int bri)
		{
			ws.putData("http://"+bridgeIP+"/api/"+bridgeUser+"/lights/"+id+"/state","{\"bri\":"+bri+"}");
		}		
		
		// Group functions
		public void GRPturnOn(int gid)
		{
			ws.putData("http://"+bridgeIP+"/api/"+bridgeUser+"/groups/"+gid+"/action","{\"on\":true}");	
		}
		
		public void GRPturnOff(int gid)
		{
			ws.putData("http://"+bridgeIP+"/api/"+bridgeUser+"/groups/"+gid+"/action","{\"on\":false}");	
		}		 
		
		public void GRPbriUP(int gid)
		{
			ws.putData("http://"+bridgeIP+"/api/"+bridgeUser+"/groups/"+gid+"/action","{\"bri_inc\":50}");
		}
		
		public void GRPbriDown(int gid)
		{
			ws.putData("http://"+bridgeIP+"/api/"+bridgeUser+"/groups/"+gid+"/action","{\"bri_inc\":-50}");
		}

		public void GRPhueInc(int gid)
		{
			ws.putData("http://"+bridgeIP+"/api/"+bridgeUser+"/groups/"+gid+"/action","{\"hue_inc\":1500}");
		}
		
		public void GRPhueDec(int gid)
		{
			ws.putData("http://"+bridgeIP+"/api/"+bridgeUser+"/groups/"+gid+"/action","{\"hue_inc\":-1500}");
		}
		
		public void GRPsatInc(int gid)
		{
			ws.putData("http://"+bridgeIP+"/api/"+bridgeUser+"/groups/"+gid+"/action","{\"sat_inc\":50}");
		}		

		public void GRPsatDec(int gid)
		{
			ws.putData("http://"+bridgeIP+"/api/"+bridgeUser+"/groups/"+gid+"/action","{\"sat_inc\":-50}");
		}

		public void GRPsetCT(int gid, int ct)
		{
			ws.putData("http://"+bridgeIP+"/api/"+bridgeUser+"/groups/"+gid+"/action","{\"ct\":"+ct+"}");
		}
		
		public void GRPsetXY(int gid, double x, double y)
		{
			ws.putData("http://"+bridgeIP+"/api/"+bridgeUser+"/groups/"+gid+"/action","{\"xy\":["+x+","+y+"]}");
		}
		
		public void GRPbriSet(int gid, int bri)
		{
			ws.putData("http://"+bridgeIP+"/api/"+bridgeUser+"/groups/"+gid+"/action","{\"bri\":"+bri+"}");
		}

		public void switchColourDialog(int GID)
		{
				// used for groups
				Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
				ColorDialog colPick = new ColorDialog();
				DialogResult colResult = colPick.ShowDialog();
				if(colResult == DialogResult.OK)
				{
					// this is according to https://github.com/PhilipsHue/PhilipsHueSDK-iOS-OSX/commit/f41091cf671e13fe8c32fcced12604cd31cceaf3			
					Color RGB = colPick.Color;
					double[] rgb = new Double[3]; 
					rgb[0] = Convert.ToDouble(RGB.R);
					rgb[1] = Convert.ToDouble(RGB.G);
					rgb[2] = Convert.ToDouble(RGB.B);
					double a = Convert.ToDouble(RGB.A);
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
					
					this.GRPsetXY(GID,x,y);		
				}		
		}

		public void switchColourDialogID(int ID)
		{
				// used for one bulb
				Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
				ColorDialog colPick = new ColorDialog();
				DialogResult colResult = colPick.ShowDialog();
				if(colResult == DialogResult.OK)
				{
					// this is according to https://github.com/PhilipsHue/PhilipsHueSDK-iOS-OSX/commit/f41091cf671e13fe8c32fcced12604cd31cceaf3			
					Color RGB = colPick.Color;
					double[] rgb = new Double[3]; 
					rgb[0] = Convert.ToDouble(RGB.R);
					rgb[1] = Convert.ToDouble(RGB.G);
					rgb[2] = Convert.ToDouble(RGB.B);
					double a = Convert.ToDouble(RGB.A);
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
					
					this.setXY(ID,x,y);		
				}		
		}			
		
	}
}
