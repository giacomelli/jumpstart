using System;
using System.Net;

namespace Giacomelli.JumpStart
{
	/// <summary>
	/// WebClient extended to be used by jumpstart.
	/// </summary>
	internal class Downloader : WebClient
	{
		/// <summary>
		/// Gets the web request.
		/// </summary>
		/// <returns>The web request.</returns>
		/// <param name="address">Address.</param>
		protected override WebRequest GetWebRequest(Uri address)
		{
			var request = base.GetWebRequest(address) as HttpWebRequest;
			request.AllowAutoRedirect = true;

			return request;
		}
	}
}

