using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bizis.Common.DL.MsSql;
using System.Data.SqlClient;
using Bizis.Site.Car.Common.Model;

namespace Bizis.Site.Car.Common.Manager
{
    class MakerModelDL: DbContext
    {
        public MakerModelDL(DbTransaction t)
            : base(t)
        { }

        internal Dictionary<int, string> GetCarMakers()
        {
            Dictionary<int, string> result = new Dictionary<int, string>();
            string sql = @"SELECT [MakerId],[Name] FROM [dbo].[car_Makers] WHERE [HasCar]=1";
            using (SqlCommand command = base.CreateCommand(sql))
            {
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                        result.Add(dr.GetInt32(0), dr.GetString(1));
                }
            }
            return result;
        }

        internal Dictionary<int, string> GetCarModels(int makerId)
        {
            Dictionary<int, string> result = new Dictionary<int, string>();
            string sql = @"SELECT [ModelId],[Name] FROM [dbo].[car_Models] WHERE [MakerId]=@makerId AND [IsCar]=1";
            using (SqlCommand command = base.CreateCommand(sql))
            {
                command.Parameters.AddWithValue("@makerId", makerId);
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                        result.Add(dr.GetInt32(0), dr.GetString(1));
                }
            }
            return result;
        }

        internal List<BmCarModel> GetCarModels()
        {
            List<BmCarModel> result = new List<BmCarModel>();
            string sql = @"SELECT [ModelId],[Name],[MakerId] FROM [dbo].[car_Models] WHERE [IsCar]=1";
            using (SqlCommand command = base.CreateCommand(sql))
            {
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int modelId = dr.GetInt32(0);
                        string name = dr.GetString(1);
                        int makerId = dr.GetInt32(2);
                        result.Add(new BmCarModel(makerId, modelId, name)) ;
                    }
                }
            }
            return result;
        }
    }
}
