/*
 * User: Mario
 * Date: 22.04.2017
 * Time: 02:33
 */
using System;
using System.Windows.Forms;

namespace HUEston
{
	/// <summary>
	/// Description of SharedFunctions.
	/// </summary>
	public class SharedFunctions
	{

		public static int qtyInString(string str, string search)
		{
			int qty = 0;
			int offset = 0;
			
			while(str.IndexOf(search,offset) != -1)
			{
				qty++;
				offset = str.IndexOf(search,offset)+1;
			}
			return qty;	
		}
		
		public static object convertToTypeOf(string type, string variable)
		{
			// Ensure you handle the object properly!
			switch(type.ToLower())
			{
				case("string"):
					return variable;
				case("int32"):
					return Convert.ToInt32(variable);
				case("double"):
					return Convert.ToDouble(variable);
				case("float"):
					return Convert.ToSingle(variable);
			}
			
			return null;
		}
		
	}
}
