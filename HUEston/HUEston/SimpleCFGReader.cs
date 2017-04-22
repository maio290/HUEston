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
		string cwd = Directory.GetCurrentDirectory();
		
		public SimpleCFGReader()
		{}
		
		
		
		public string[] readCFG(string cfg)
		{
			string[] cfgfile = File.ReadAllLines(cwd+cfg);
			
			string[] extractedValues = new string[cfgfile.Length];
			

			for(int i = 0; i<cfgfile.Length; i++)
			{
				extractedValues[i] = cfgfile[i].Substring(cfgfile[i].IndexOf("=")+1);
			}
			
			return extractedValues;
		}
	}
}
