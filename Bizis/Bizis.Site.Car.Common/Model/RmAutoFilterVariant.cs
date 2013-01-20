using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bizis.Site.Common.Model;
using System.Data.SqlClient;

namespace Bizis.Site.Car.Common.Model
{
    public class RmAutoFilterVariant : RmAutoFilterModel
    {
        public RmValueString Variant {get; private set;}

        public RmAutoFilterVariant(int? no)
            : base(no)
        {
            Variant = new RmValueString("Variant", this);
        }
        public override bool IsValidAndNotEmpty 
        {
            get
            {
                if (!base.IsValidAndNotEmpty)
                    return false;
                if (!ModelId.Val.HasValue && !string.IsNullOrEmpty(Variant.Val))
                    return false;
                return true;
            }
        }

        public override void FillSql(List<SqlParameter> ps, List<string> wheres)
        {
            base.FillSql(ps, wheres);
        }
    }
}
