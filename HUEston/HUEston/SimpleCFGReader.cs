/*
 * User: Mario
 * Date: 22.02.2017
 * Time: 16:30
 */
using System;
using System.IO;

namespace HUEston
{
	/// <summary>
	/// Description of SimpleCFGReader.
	/// </summary>
	public class SimpleCFGReader
	{
		
		static string cfg = "/config.cfg";
		static string cwd = Directory.GetCurrentDirectory();	
		
		public static string[] readCFG()
		{
			string[] cfgfile = File.ReadAllLines(cwd+cfg);
			
			string[] extractedValues = new string[cfgfile.Length];
			
			
			//IP
			extractedValues[0] = cfgfile[0].Substring(cfgfile[0].IndexOf("=")+1);
			//Username
			extractedValues[1] = cfgfile[1].Substring(cfgfile[1].IndexOf("=")+1);
			
			return extractedValues;
		}
	}
}
