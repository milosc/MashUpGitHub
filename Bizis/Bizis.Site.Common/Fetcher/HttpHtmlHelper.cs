using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Linq;
using System.IO.Compression;
using System.IO;

namespace Bizis.Site.Common.Fetcher
{
    class HttpHtmlHelper
    {
        internal static void SetCommonHeaders(CookieWebClient client, bool post)
        {
            if (post)
                client.Headers["Accept"] = "image/gif, image/jpeg, image/pjpeg, application/x-ms-application, application/vnd.ms-xpsdocument, application/xaml+xml, application/x-ms-xbap, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, application/x-shockwave-flash,";
            else
                client.Headers["Accept"] = "*/*";
            client.Headers["User-Agent"] = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; SLCC1; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; InfoPath.2; .NET4.0C; .NET4.0E)";
            client.Headers["Accept-Encoding"] = "gzip, deflate";
            client.Headers["Accept-Language"] = "sl";
            if (post)
            {
                client.Headers["Pragma"] = "no-cache";
                client.Headers["Content-Type"] = "application/x-www-form-urlencoded";
            }
        }
        internal static XDocument GetResponseHtmlAsXml(CookieWebClient client, byte[] resposeData)
        {
            return GetResponseHtmlAsXml(client, resposeData, Encoding.UTF8);
        }
        internal static XDocument GetResponseHtmlAsXml(CookieWebClient client, byte[] resposeData, Encoding encoding)
        {

            string contentEncoding = client.ResponseHeaders["Content-Encoding"];
            string html;
            if (contentEncoding == "gzip")
            {
                using (MemoryStream s = new MemoryStream(resposeData))
                {
                    using (GZipStream instream = new GZipStream(s, CompressionMode.Decompress))
                    {
                        using (StreamReader reader = new StreamReader(instream, encoding))
                            html = reader.ReadToEnd();
                    }
                }
            }
            else if (contentEncoding == "deflate")
                throw new ApplicationException("Deflate content encoding not supported");
            else
            {
                html = encoding.GetString(resposeData);
            }
            XDocument xd;
            using (StringReader sr = new StringReader(html))
            {
                xd = _FromHtml(sr);
            }
            return xd;
        }

        public static string GetResponseString(CookieWebClient client, byte[] resposeData)
        {
            string contentEncoding = client.ResponseHeaders["Content-Encoding"];
            string html;
            if (contentEncoding == "gzip")
            {
                using (MemoryStream s = new MemoryStream(resposeData))
                {
                    using (GZipStream instream = new GZipStream(s, CompressionMode.Decompress))
                    {
                        using (StreamReader reader = new StreamReader(instream))
                            html = reader.ReadToEnd();
                    }
                }
            }
            else if (contentEncoding == "deflate")
                throw new ApplicationException("Deflate content encoding not supported");
            else
            {
                html = Encoding.UTF8.GetString(resposeData);
            }
            return html;
        }

        internal static string GetViewStateFromHtml(XDocument xd)
        {
            XmlNamespaceManager r = new XmlNamespaceManager(new NameTable());
            r.AddNamespace("h", "http://www.w3.org/1999/xhtml");
            XElement hidden = xd.XPathSelectElement("//h:input[@type='hidden' and @name='__VIEWSTATE']", r);
            if (hidden == null)
                throw new ApplicationException("HttpHtmlHelper.GetViewStateFromHtml MissingViewStateElement XElement:hidden");
            return hidden.Attribute("value").Value;
        }

        private static XDocument _FromHtml(TextReader reader)
        {

            using (Sgml.SgmlReader sgmlR = new Sgml.SgmlReader())
            {
                sgmlR.DocType = "HTML";
                sgmlR.WhitespaceHandling = WhitespaceHandling.All;
                sgmlR.CaseFolding = Sgml.CaseFolding.ToLower;
                sgmlR.InputStream = reader;

                XDocument doc = XDocument.Load(sgmlR);// new XDocument();
                //doc.PreserveWhitespace = true;
                //doc.XmlResolver = null;
                //doc.Load(sgmlR);
                return doc;
            }

        }
    }
}
