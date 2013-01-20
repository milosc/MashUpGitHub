using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bizis.Site.Common.Model;

namespace Bizis.Site.Common.Manager
{
    public class CountryMng
    {
        private static Dictionary<int, Country> _Id2Model;
        private static Dictionary<string, Country> _Code2Model;
        private static Country[] _CountriesVisible;
        private static object _LockId2 = new object();
        private static object _LockCode2 = new object();
        private static object _LockVisible = new object();
        static CountryMng()
        {
            List<Country> countries = CountryBL.GetCountries();
            _Id2Model = countries.ToDictionary(row => row.CountryId, row => row);
            _Code2Model = countries.ToDictionary(row => row.Code, row => row);
            _CountriesVisible = countries.Where(row => row.IsVisible).ToArray();
        }
        public static Country GetCountry(int countryId)
        {
            lock (_LockId2)
            {
                return _Id2Model[countryId];
            }
        }
        public static Country GetCountry(string code)
        {
            lock (_LockCode2)
            {
                return _Code2Model[code];
            }
        }
        public static Country[] GetCountriesVisible()
        {
            int length = _CountriesVisible.Length;
            Country[] result = new Country[length];
            lock (_LockVisible)
            {
                Array.Copy(_CountriesVisible, result, length);
            }
            return result;
        }

        internal static Country GetCountryByIp(long ip)
        {
            //TODO cache
            int? countryId = CountryBL.GetCounryIdByIp(ip);
            if (countryId.HasValue)
                return GetCountry(countryId.Value);
            else
                return GetCountry("SI");
        }
    }
}
