using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bizis.Common.Diagnostics;
using System.Web;
using System.Xml.Linq;
using Bizis.Site.Common.Diagnostics;
using System.Xml;
using System.Net;

namespace Bizis.Site.Common.Fetcher
{
    public abstract class FetcherBase<T>
    {

        protected static ErrorReportingService ErrorRep = new ErrorReportingService();
        static FetcherBase()
        {
            ServicePointManager.Expect100Continue = false;
        }



        public string Referer { get; protected set; }
        public Encoding ContentEncoding { get; protected set; }
        public FetcherBase(Encoding contentEncoding)
        {
            ContentEncoding = contentEncoding;
        }
        public FetcherBase()
        {
            ContentEncoding = Encoding.UTF8;
        }
        public abstract T Fetch(CookieWebClient client);
        
        protected XmlNamespaceManager GetHtmlXmlNamespaceManager(string prefix)
        {
            XmlNamespaceManager r = new XmlNamespaceManager(new NameTable());
            r.AddNamespace(prefix, "http://www.w3.org/1999/xhtml");
            return r;
        }

        public byte[] GetRaw(CookieWebClient client, string urlGet)
        {
            HttpHtmlHelper.SetCommonHeaders(client, false);
            Uri uri = new Uri(urlGet);

            client.Headers["host"] = uri.Host;
            if (!string.IsNullOrEmpty(Referer))
                client.Headers["Referer"] = Referer;
            
            byte[] responseData = client.DownloadData(uri);
            return responseData;
        }
        public XDocument GetXml(CookieWebClient client, string urlGet)
        {
            byte[] responseData = GetRaw(client, urlGet);//Referer
            return HttpHtmlHelper.GetResponseHtmlAsXml(client, responseData, ContentEncoding);
        }
        public XDocument PostXml(CookieWebClient client, string urlPost, string postData)
        {
            byte[] postDataArray = Encoding.UTF8.GetBytes(postData);
            HttpHtmlHelper.SetCommonHeaders(client, true);
            if(string.IsNullOrEmpty(Referer))
                throw new ApplicationException("Missing referer on post");
            Uri uri = new Uri(urlPost);
            client.Headers["Referer"] = Referer;
            client.Headers["host"] = uri.Host;
            byte[] responseData= client.UploadData(urlPost, "POST", postDataArray);
            return HttpHtmlHelper.GetResponseHtmlAsXml(client, responseData, ContentEncoding);
        }
        public T Fetch(out bool success)
        {

            success = false;
            T result;
            try
            {
                //Log.WriteLine(string.Format("SearchBase.DoSearch BEGIN Site:{0} SearchId:{1} CarMaker:{2} CarType:{3} isTruck:{4}"
                //    , SiteName, Filter.SearchId, Filter.MakerName, Filter.TypeName, IsTruckFilter));
                using (CookieWebClient client = new CookieWebClient())
                {
                    
                    result = Fetch(client);
                }

                //Log.WriteLine(string.Format("SearchBase.DoSearch END Site:{0} SearchId:{1} CarMaker:{2} CarType:{3} AdsCount:{4} isTruck:{5}"
                //    , SiteName, Filter.SearchId, Filter.MakerName, Filter.TypeName, result.Count, IsTruckFilter));
                success = true;
            }
            catch (Exception ex)
            {
                result = default(T); //new List<Ad>();
                string msg = "Fetch failed";
                //string msg = string.Format("SearchBase.DoSearch ERROR Site:{0} SearchId:{1} CarMaker:{2} CarType:{3} isTruck:{4}"
                //    , SiteName, Filter.SearchId, Filter.MakerName, Filter.TypeName, IsTruckFilter);
                ErrorRep.ReportError(msg, ex);
            }

            return result;
        }
    }
}
