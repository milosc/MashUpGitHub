using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bizis.Site.Common.Fetcher;
using Bizis.Site.Car.Common.Model;
using System.Xml.Linq;
using System.Xml;
using System.Xml.XPath;
using Bizis.Site.Common.Utility;

namespace Bizis.Site.Car.Fetcher.Services
{
    public class FetcherCarMaker : FetcherBase<List<car_Makers>>
    {

        public override List<car_Makers> Fetch(CookieWebClient client)
        {
            List<car_Makers> res = new List<car_Makers>();
            string url = "http://www.auto-data.net/en/";
            XDocument xd = GetXml(client, url);

            XmlNamespaceManager r= GetHtmlXmlNamespaceManager("h");
            List<XElement> xmakers = xd.XPathSelectElements("//h:div[@id='main']/h:div[@id='center']/h:a[@class='marki_blok']", r).ToList();

            foreach (var xmaker in xmakers)
            {
                res.Add(_GetMaker(xmaker, r));
            }
            return res;

        }

        private car_Makers _GetMaker(XElement xmaker, XmlNamespaceManager r)
        {
            car_Makers res = new car_Makers();
            res.HasCar = true;

            string href = xmaker.Attribute("href").Value;
            res.RefId = href.Split('=').Last();

            res.Name = TextUtility.TrimWhitespaces(xmaker.Value);
            return res;


        }
    }
}
