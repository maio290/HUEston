/*
 * User: Mario
 * Date: 22.02.2017
 * Time: 15:59
 */
using System;
using System.IO;

namespace HUEston
{
	/// <summary>
	/// Simple Config Writer
	/// </summary>
	public class SimpleCFGWriter
	{
		static string cfg = "/config.cfg";
		static string cwd = Directory.GetCurrentDirectory();
		
		public SimpleCFGWriter(string ip, string username)
		{
			StreamWriter strWrite = new StreamWriter(cwd+cfg,false);
			strWrite.WriteLine("ip="+ip);
			strWrite.WriteLine("username="+username);
			strWrite.Close();
		}
		

	}
}
