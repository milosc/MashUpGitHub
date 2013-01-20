using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Bizis.Site.Common.Fetcher
{
    public class CookieWebClient : WebClient
    {
        public CookieWebClient()
        {
            _CookieContainer = new CookieContainer();

        }
        public CookieWebClient(CookieContainer cookieContainer)
        {
            _CookieContainer = cookieContainer;

        }
        public CookieContainer CookieContainer
        {
            get { return _CookieContainer; }
        }
        private CookieContainer _CookieContainer = new CookieContainer();

        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);
            if (request is HttpWebRequest)
            {
                (request as HttpWebRequest).CookieContainer = _CookieContainer;
                (request as HttpWebRequest).KeepAlive = true;
            }
            return request;
        }
    }
}
