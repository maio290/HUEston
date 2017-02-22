/*
 * User: Mario
 * Date: 22.02.2017
 * Time: 17:11
 */
using System;

namespace HUEston
{
	/// <summary>
	/// Description of Light.
	/// </summary>
	public class Light
	{
	
		public int id;
		public string type;
		public string name;
		public string uid;
		
		public Light(int id, string type, string name, string uid)
		{
			this.id = id;
			this.type = type;
			this.name = name;
			this.uid = uid;
		}
	}
}
