using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Bizis.Site.Common.Model
{
    public class RmValue<T> : RmValueBase where T : struct
    {
        public T Val { get; set; }
        public RmValue(string name) : base(name) { }
        public RmValue(string name, RmBase parent) : base(name, parent) { }

        public void FillSql(List<SqlParameter> ps, List<string> wheres)
        {
            ps.Add(new SqlParameter(SqlParam, Val));
            wheres.Add(SqlName + "=" + SqlParam);
        }
    }
}
