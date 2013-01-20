using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bizis.Common.DL.MsSql;
using Bizis.Site.Common.Model;
using System.Data.SqlClient;

namespace Bizis.Site.Common.Manager
{
    class CountryDL: DbContext
    {
        public CountryDL(DbTransaction t)
            : base(t)
        { }



        internal List<Country> GetCountries()
        {
            List<Country> result = new List<Country>();
            string sql = @"SELECT [CountryId],[Name],[Code],[IsVisible]"
                        +" FROM [dbo].[com_Countries]";
            using (SqlCommand command = base.CreateCommand(sql))
            {
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int countryId = dr.GetInt32(0);
                        string name_en = dr.GetString(1);
                        string code = dr.GetString(2);
                        bool isVisible = dr.GetBoolean(3);
                        result.Add(new Country(countryId, name_en, code, isVisible));
                    }
                }
            }
            return result;
        }


        internal int? GetCounryIdByIp(long ip)
        {
            string sql = @"SELECT TOP 1 [CountryId]"
                        +" FROM [dbo].[com_Ip2C] WHERE [IpFrom]<=@ip AND [IpTo]>=@ip ";
            using (SqlCommand command = base.CreateCommand(sql))
            {
                command.Parameters.AddWithValue("@ip", ip);
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    if (dr.Read())
                        return dr.GetInt32(0);
                    else
                        return null;
                }
            }
        }
    }
}
