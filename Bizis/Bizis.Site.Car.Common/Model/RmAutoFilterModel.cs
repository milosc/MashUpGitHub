using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bizis.Site.Common.Model;
using System.Data.SqlClient;

namespace Bizis.Site.Car.Common.Model
{
    public class RmAutoFilterModel:RmBase
    {
        public RmValueNull<int> MakerId { get; private set; }
        public RmValueNull<int> ModelId { get; private set; }

        public virtual bool IsValidAndNotEmpty
        {
            get
            {
                if (!MakerId.Val.HasValue)
                    return false;
                return true;
            }
        }

        public RmAutoFilterModel(int? no)
            : base(no)
        {
            MakerId = new RmValueNull<int>("MakerId", this);
            ModelId = new RmValueNull<int>("ModelId", this);
        }

        public virtual void FillSql(List<SqlParameter> ps, List<string> wheres)
        {
            MakerId.FillSql(ps, wheres);
            ModelId.FillSql(ps, wheres);
        }
    }
}
