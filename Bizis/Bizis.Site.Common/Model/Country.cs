using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bizis.Site.Common.Model
{
    public class Country
    {
        public int CountryId { get; private set; }
        public string Name_en { get; private set; }
        public string Code { get; private set; }
        public bool IsVisible { get; private set; }
        public Country(int countryId, string name_en, string code, bool isVisible)
        {
            CountryId = countryId;
            Name_en = name_en;
            Code = code;
            IsVisible = isVisible;
        }
    }
}
