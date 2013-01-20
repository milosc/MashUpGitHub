using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bizis.Site.Common.Model;
using System.Data.SqlClient;
using System.Data;

namespace Bizis.Site.Car.Common.Model
{
     
    public class RmAutoFilterSearch
    { 
       

        public RmValueSet<byte> VehicleTypeIds = new RmValueSet<byte>("VehicleTypeId");
        
        public List<RmAutoFilterVariant> Variants;

        public RmValueFromTo<int> Price= new RmValueFromTo<int>("Price");
        public RmValueFromTo<short> Year1Reg = new RmValueFromTo<short>("Year1Reg");
        public RmValueFromTo<int> Km = new RmValueFromTo<int>("Km");
        public RmValueFromTo<int> Kw = new RmValueFromTo<int>("Kw");

        public RmValueNull<short> DoorsId = new RmValueNull<short>("DoorsId");
        public RmValueNull<short> SeatCountId = new RmValueNull<short>("SeatCountId");
        public RmValueNull<byte> GearboxId = new RmValueNull<byte>("GearboxId");

        public RmValueNull<byte> FuelId = new RmValueNull<byte>("FuelId");

        public RmValueNull<bool> IsDamaged = new RmValueNull<bool>("IsDamaged");

        public RmValueNull<DateTime> PublishedFrom = new RmValueNull<DateTime>("Published");
        public RmValueNull<byte> VendorTypeId = new RmValueNull<byte>("VendorTypeId");
        public RmValueNull<byte> SeatColorId = new RmValueNull<byte>("SeatColorId");

        public RmValueSet<byte> ColorIds = new RmValueSet<byte>("ColorId");

        public RmValueSet<byte> OldTypeIds = new RmValueSet<byte>("OldTypeId");

        public RmAutoFilterExtras Extras;


        public string OrderBy = "[Published]";//TODO

        public List<SqlParameter> GetSql(out List<string> wheres)
        {
            List<SqlParameter> ps = new List<SqlParameter>();
            wheres = new List<string>();
            
            VehicleTypeIds.FillSql(ps, wheres);
            _FillSql_Variant(ps, wheres);
            Price.FillSql(ps, wheres);
            Year1Reg.FillSql(ps, wheres);
            Km.FillSql(ps, wheres);
            Kw.FillSql(ps, wheres);
            DoorsId.FillSql(ps, wheres);
            SeatCountId.FillSql(ps, wheres);
            GearboxId.FillSql(ps, wheres);
            FuelId.FillSql(ps, wheres);
            IsDamaged.FillSql(ps, wheres);
            PublishedFrom.FillSql(ps, wheres);
            VendorTypeId.FillSql(ps, wheres);
            SeatColorId.FillSql(ps, wheres);
            ColorIds.FillSql(ps, wheres);
            OldTypeIds.FillSql(ps, wheres);

            if(Extras!=null)
                Extras.FillSql(ps, wheres);
            return ps;
        }

        private void _FillSql_Variant(List<SqlParameter> ps, List<string> wheres)
        {
            if (Variants != null && Variants.Count > 0)
            {
                List<string> wheres_variant_or = new List<string>();
                foreach (var rm in Variants)
                {
                    List<string> wheres_variant = new List<string>();
                    rm.FillSql(ps, wheres_variant);
                    if (wheres_variant.Count > 0)
                        wheres_variant_or.Add("(" + string.Join(" AND ", wheres_variant.ToArray()) + ")");

                }
                if (wheres_variant_or.Count > 0)
                    wheres.Add("(" + string.Join(" OR ", wheres_variant_or.ToArray()) + ")");

            }
        }
    }
}
