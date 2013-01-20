using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Bizis.Site.Common.Model
{
    public class RmValueString : RmValueBase
    {
        public string Val { get; set; }
        public RmValueString (string name) : base(name) { }
        public RmValueString(string name, RmBase parent) : base(name, parent) { }


        public void FillSql(List<SqlParameter> ps, List<string> wheres)
        {
            if (!string.IsNullOrEmpty(Val))
            {
                ps.Add(new SqlParameter(SqlParam, Val));
                wheres.Add(SqlName + "=" + SqlParam);
            }
        }
    }
}
