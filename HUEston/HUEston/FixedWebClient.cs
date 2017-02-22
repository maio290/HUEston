/*
 * User: Mario
 * Date: 22.02.2017
 * Time: 14:17
 */
using System;
using System.Net;

namespace HUEston
{
	/// <summary>
	/// Description of FixedWebClient.
	/// </summary>
  	public class FixedWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri uri)
        {
            WebRequest wR = base.GetWebRequest(uri);
            wR.Timeout = 1000;
            return wR;
        }
    }
}
