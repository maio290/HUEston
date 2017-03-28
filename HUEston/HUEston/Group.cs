/*
 * User: Mario
 * Date: 22.02.2017
 * Time: 18:23
 */
using System;

namespace HUEston
{
	/// <summary>
	/// Description of Group.
	/// </summary>
	public class Group
	{
		public string bulbs;
		public int gid { get; set; }
		public string name { get; set; }
		public string colourmode;
		public int bri;
		public bool on;
		public int hue;
		public double x;
		public double y;
		public bool stateFetch = false;
		
		
		public Group(int gid, string name, string assignedBulbs)
		{
			this.gid = gid;
			this.name = name;			
			this.bulbs = assignedBulbs;
		}
		
		
	}
}
