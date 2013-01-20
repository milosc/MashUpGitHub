using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bizis.Common.DL.MsSql;
using Bizis.Site.Car.Common.Model;
using System.Data.SqlClient;

namespace Bizis.Site.Car.Common.Manager
{
    class AutoDL: DbContext
    {
        public AutoDL(DbTransaction t)
            : base(t)
        { }

        internal List<RmAutoSearchItem> GetSearchList(int page, int pageSize, RmAutoFilterSearch req, out int countAll)
        {
            countAll = 0;
            List<string> wheres;
            List<RmAutoSearchItem> res = new List<RmAutoSearchItem>();
            List<SqlParameter> ps = req.GetSql(out wheres);
            string rowNo=string.Format("ROW_NUMBER() Over (Order By {0}) As Row", req.OrderBy);
            string with = "WITH e_CarAds AS ("
                + " SELECT " + rowNo + ",[CarAdId],[MakerId],[ModelId],[Variant],[Price],[Year1Reg],[VendorId],[Km],[Kw],[Ccm],[FuelId],[VendorTypeId],[IsDamaged],[JShortFeatures],[Published]"
                + " FROM [dbo].[car_CarAds]"
                +  (wheres.Count>0 ?  (" WHERE " + string.Join(" AND ", wheres.ToArray())) : string.Empty)
                +")";

            string sql = with + "SELECT * FROM e_CarAds"
                    + " WHERE row BETWEEN (@page * @pageSize) + 1 AND (@page+1) * @pageSize";

            using (SqlCommand command = base.CreateCommand(sql))
            {
                command.Parameters.AddRange(ps.ToArray());
                command.Parameters.AddWithValue("@page", page);
                command.Parameters.AddWithValue("@pageSize", pageSize);
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        RmAutoSearchItem item = new RmAutoSearchItem()
                        {
                            CarAdOId = dr.GetInt64(1),
                            MakerId = dr.GetInt32(2),
                            ModelId = dr.GetInt32(3),
                            Variant = dr[4] as string,
                            Price = dr[5] == DBNull.Value ? (int?)null : dr.GetInt32(5),
                            Year1Reg = dr.GetInt16(6),
                            VendorId = dr.GetInt64(7),
                            Km = dr.GetInt32(8),
                            Kw = dr.GetInt32(9),
                            Ccm = dr[10] == DBNull.Value ? (int?)null : dr.GetInt32(10),
                            FuelId = dr.GetByte(11),
                            VendorTypeId = dr.GetByte(12),
                            IsDamaged = dr[13] == DBNull.Value ? (bool?)null : dr.GetBoolean(13),
                            JShortFeatures = dr[14] as string,
                             Published = dr.GetDateTime(15)
                        };
                        res.Add(item);
                    }
                }
            }
            return res;
        }
    }
}
