using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Bizis.Site.Common.Model
{
    public class RmValueNull<T>: RmValueBase where T:struct
    {
        public T? Val { get; set; }
        public RmValueNull(string name) : base(name) { }
        public RmValueNull(string name, RmBase parent) : base(name, parent) { }

        public void FillSql(List<SqlParameter> ps, List<string> wheres)
        {
            if (Val.HasValue)
            {
                ps.Add(new SqlParameter(SqlParam, Val.Value));
                wheres.Add(SqlName + "=" + SqlParam);
            }
        }
    }
}
