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
    public class FetcherCarModel : FetcherBase<List<car_Models>>
    {
        private string _MakerRefId;
        private int _MakerId;

        public FetcherCarModel(string makerRefId, int makerId)
        {
            _MakerRefId = makerRefId;
            _MakerId = makerId;
        }

        public override List<car_Models> Fetch(CookieWebClient client)
        {
            List<car_Models> res = new List<car_Models>();
            string url = string.Format("http://www.auto-data.net/en/?f=showModel&marki_id={0}", _MakerRefId);
            XDocument xd = GetXml(client, url);

            XmlNamespaceManager r = GetHtmlXmlNamespaceManager("h");
            List<XElement> xmodels = xd.XPathSelectElements("//h:div[@id='main']/h:div[@id='center']/h:a[@class='modeli']", r).ToList();

            foreach (var xmodel in xmodels)
            {
                res.Add(_GetModel(xmodel, r));
            }
            return res;
        }

        private car_Models _GetModel(XElement xmodel, XmlNamespaceManager r)
        {
            car_Models res = new car_Models()
            {
                MakerId = _MakerId,
                IsCar = true
            };
            
            string href = xmodel.Attribute("href").Value;
            res.RefId = href.Split('=').Last();

            res.Name = TextUtility.TrimWhitespaces(xmodel.Value);

            return res;
        }
    }
}
