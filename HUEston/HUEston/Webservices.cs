/*
 * User: Mario
 * Date: 22.02.2017
 * Time: 12:07
 */
using System;
using System.Net;
using System.IO;
using System.Text;

using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace HUEston
{
	/// <summary>
	/// Description of Webservices.
	/// </summary>
	public class Webservices
	{
		public Webservices()
		{
			
		}
		
		
		public string getHTMLfromURL(string URL)
		{
			using(WebClient cl = new FixedWebClient())
			{
				return cl.DownloadString(URL);
			}
		}
		
		public string postData(string URL, string body)
		{
			// modification of http://stackoverflow.com/a/17535912
		    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
		    byte[] bytes;
		    bytes = Encoding.UTF8.GetBytes(body);
		    request.ContentType = "application/json; encoding='utf-8'";
		    request.ContentLength = bytes.Length;
		    request.Method = "POST";
		    Stream requestStream = request.GetRequestStream();
		    requestStream.Write(bytes, 0, bytes.Length);
		    requestStream.Close();
		    HttpWebResponse response;
		    response = (HttpWebResponse)request.GetResponse();
		    if (response.StatusCode == HttpStatusCode.OK)
		    {
		        Stream responseStream = response.GetResponseStream();
		        string responseStr = new StreamReader(responseStream).ReadToEnd();
		        return responseStr;
		    }
		    return null;
		}		
		
		public string putData(string URL, string body)
		{
			// modification of http://stackoverflow.com/a/17535912
		    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
		    byte[] bytes;
		    bytes = Encoding.UTF8.GetBytes(body);
		    request.ContentType = "application/json; encoding='utf-8'";
		    request.ContentLength = bytes.Length;
		    request.Method = "PUT";
		    Stream requestStream = request.GetRequestStream();
		    requestStream.Write(bytes, 0, bytes.Length);
		    requestStream.Close();
		    HttpWebResponse response;
		    response = (HttpWebResponse)request.GetResponse();
		    if (response.StatusCode == HttpStatusCode.OK)
		    {
		        Stream responseStream = response.GetResponseStream();
		        string responseStr = new StreamReader(responseStream).ReadToEnd();
		        return responseStr;
		    }
		    return null;
		}			
	}
}
