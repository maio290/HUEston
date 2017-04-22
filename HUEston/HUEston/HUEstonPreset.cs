/*
 * User: Mario
 * Date: 12.04.2017
 * Time: 21:38
 */
using System;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;
using System.Collections.Generic;
using System.Globalization;

namespace HUEston
{
	/// <summary>
	/// Class for Preset Files and their execution.
	/// </summary>
	public class HUEstonPreset
	{
		
		public string name;
		int sleep;
		public int id;
		public string content;
		HUEFunctions hf;
		
		public HUEstonPreset(string name, int sleep, int id, string content, HUEFunctions hf)
		{
			this.name = name;
			this.sleep = sleep;
			this.id = id;
			this.content = content;
			this.hf = hf;
		}
		
		protected void ExecuteFunction(string[] parameters, string function)
		{
			Type hfType = hf.GetType();
			MethodInfo method = hfType.GetMethod(function);
			ParameterInfo[] pars = method.GetParameters();
			
			object[] objectifiedParameters = new object[parameters.Length];
			
			for(int i = 0; i<parameters.Length; i++)
			{
				objectifiedParameters[i] = SharedFunctions.convertToTypeOf(pars[i].ParameterType.Name,parameters[i]);
				//MessageBox.Show(objectifiedParameters[i].ToString());
			}
			
			method.Invoke(hf,objectifiedParameters);	
		}
		
		protected int findFunction(List<string[]> functionList, string function)
		{
			foreach(string[] functionArray in functionList)
			{
				if(functionArray[0].Equals(function))
				{
					return functionArray.Length-1;
				}
			}
			throw new KeyNotFoundException();
		}
		
		private void executeContent()
		{
			// used for reading doubles properly, since my german layout fails the dots
			Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
			char[] delim = {'|'};		
			string[] contentSplit = content.Split(delim);	
			List<string[]> functionList = getFunctions();
			
			//TODO: Add functionality for non-looping			
			if(contentSplit[0].Equals("loop"))
			{
				while(true)
				{

					for(int i = 1; i<contentSplit.Length; i++)
					{
						
						if(contentSplit[i].Contains("sleep"))
						{
							int customSleep = Convert.ToInt32(contentSplit[i].Substring(contentSplit[i].IndexOf(":")+1));;
							try
							{Thread.Sleep(customSleep);}
							catch(ThreadInterruptedException)
							{return;}
							continue;							
						}
						
						int amountOfCommas = SharedFunctions.qtyInString(contentSplit[i],",");						
						int parameterCount = amountOfCommas+1;
						
						string functionName = contentSplit[i].Substring(0,contentSplit[i].IndexOf(":"));
						string rest = contentSplit[i].Substring(contentSplit[i].IndexOf(":")+1);
						
						char[] functionDelim = {','};
						string[] parameterSplit = rest.Split(functionDelim);
						
						int reflectedParametersCount = -1;
						
						try
						{reflectedParametersCount = findFunction(functionList,functionName);}
						catch(KeyNotFoundException)
						{continue;}
						
						if(reflectedParametersCount == parameterCount)
						{
							ExecuteFunction(parameterSplit,functionName);
						}
						
					}
					try
					{Thread.Sleep(this.sleep);}
					catch(ThreadInterruptedException)
					{return;}
				}
			}
			else
			{
				bool isLoop = false;
				if(content.Contains("loop"))
				{
					isLoop = true;
				}
				// non looping functions are sleeping between each command when set
					for(int i = 0; i<contentSplit.Length; i++)
					{
						if(contentSplit[i].Contains("sleep"))
						{
							int customSleep = Convert.ToInt32(contentSplit[i].Substring(contentSplit[i].IndexOf(":")+1));
							try
							{Thread.Sleep(customSleep);}
							catch(ThreadInterruptedException)
							{return;}
							continue;							
						}
						
						if(contentSplit[i].Equals("loop"))
						{
							int loopIndex = i+1;
							// loop from here
							while(true)
							{
								for(int j = loopIndex; j<contentSplit.Length; j++)
								{
									
									if(contentSplit[j].Contains("sleep"))
									{
										int customSleep = Convert.ToInt32(contentSplit[j].Substring(contentSplit[j].IndexOf(":")+1));
										try
										{Thread.Sleep(customSleep);}
										catch(ThreadInterruptedException)
										{return;}
										continue;							
									}								
									int amountOfCommas = SharedFunctions.qtyInString(contentSplit[j],",");						
									int parameterCount = amountOfCommas+1;
									
									string functionName = contentSplit[j].Substring(0,contentSplit[j].IndexOf(":"));
									string rest = contentSplit[j].Substring(contentSplit[j].IndexOf(":")+1);
									
									char[] functionDelim = {','};
									string[] parameterSplit = rest.Split(functionDelim);
									
									int reflectedParametersCount = -1;
									
									try
									{reflectedParametersCount = findFunction(functionList,functionName);}
									catch(KeyNotFoundException)
									{continue;}
									
									if(reflectedParametersCount == parameterCount)
									{ExecuteFunction(parameterSplit,functionName);}									
								}
								try
								{Thread.Sleep(this.sleep);}
								catch(ThreadInterruptedException)
								{return;}
							}
							
						}
						else
						{
						int amountOfCommas = SharedFunctions.qtyInString(contentSplit[i],",");						
						int parameterCount = amountOfCommas+1;
						
						string functionName = contentSplit[i].Substring(0,contentSplit[i].IndexOf(":"));
						string rest = contentSplit[i].Substring(contentSplit[i].IndexOf(":")+1);
						
						char[] functionDelim = {','};
						string[] parameterSplit = rest.Split(functionDelim);
						
						int reflectedParametersCount = -1;
						
						try
						{reflectedParametersCount = findFunction(functionList,functionName);}
						catch(KeyNotFoundException)
						{continue;}
						
						if(reflectedParametersCount == parameterCount)
						{ExecuteFunction(parameterSplit,functionName);}
						
						if(!isLoop)
						{
						try
						{Thread.Sleep(this.sleep);}
						catch(ThreadInterruptedException)
						{return;}
						}
						}
					}
					
					return;
		
				
			}
			
			
			
		}
		
		
		public Thread getExectueThread()
		{
			return new Thread(this.executeContent);
		}
		
		protected List<string[]> getFunctions()
		{
			List<string[]> functionList = new List<string[]>();
			Type[] hfTypes = Assembly.LoadFrom(Application.ExecutablePath).GetTypes();	
			foreach(Type type in hfTypes)
			{
				if(type.FullName.Equals("HUEston.HUEFunctions"))
				{
					MemberInfo[] methods = type.GetMethods();
					int counter = 0;						
					foreach(MemberInfo info in methods)
					{
						if(counter <= 12)
						{
							counter++;
							continue;
						}
						
						if(info.Name.ToString().Equals("switchColourDialog"))
						{
							break;
						}
						
						string functionName = info.Name.ToString();
						ParameterInfo[] pars = type.GetMethod(info.Name).GetParameters();
						List<string> parameterList = new List<string>();
						
						for(int i = 0; i<pars.Length; i++)
						{
							parameterList.Add(pars[i].ParameterType.Name);	
						}
						
						string[] parameterArray = new string[parameterList.Count+1];
						parameterArray[0] = functionName;
						
						for(int i = 0; i<parameterList.Count; i++)
						{
							parameterArray[i+1] = parameterList[i];
						}
						
						functionList.Add(parameterArray);
						
					}
					
				}
			}

			return functionList;			
		}		
		
	}
}
