/*
 * User: Mario
 * Date: 22.02.2017
 * Time: 12:20
 */
using System;
using System.Collections.Generic;
using System.Threading;
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
			ws.putData("http://"+bridgeIP+"/api/"+bridgeUser+"/groups/"+gid+"/action","{\"hue_inc\":50}");
		}
		
		public void GRPhueDec(int gid)
		{
			ws.putData("http://"+bridgeIP+"/api/"+bridgeUser+"/groups/"+gid+"/action","{\"hue_inc\":-50}");
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
	}
}
