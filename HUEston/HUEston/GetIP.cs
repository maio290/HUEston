/*
 * Created by SharpDevelop.
 * User: Mario
 * Date: 22.02.2017
 * Time: 12:04
 */
using System;

namespace HUEston
{
	/// <summary>
	/// Class to get the IP of your HUE Bridge
	/// </summary>
	public class GetIP
	{
		public string id;
		public string ip;
		
		public GetIP(int method)
		{
			Webservices ws = new Webservices();
			
			switch(method)
			{
				case 1:
					// Using Philips Broker Server Discover Process
					string response = ws.getHTMLfromURL("http://www.meethue.com/api/nupnp");

					try
					{
					// extract device ID
					int id_start = response.IndexOf(":")+2;
					int id_end = response.IndexOf(",",id_start)-1;
					id = response.Substring(id_start,id_end-id_start);
					
					// extract IP
					
					int ip_start = response.IndexOf(":",id_end)+2;
					int ip_end = response.IndexOf("}",ip_start)-1;
					ip = response.Substring(ip_start,ip_end-ip_start);
					}
					catch(ArgumentOutOfRangeException e)
					{
						
					}
					
					
						break;
				
			}
			
		}
	}
}
