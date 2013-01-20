using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Bizis.Site.Common.Model
{
    public class RmValueFromTo<T> where T:struct
    {

        public string Name { get; private set; }
        private string _SqlName;
        public string SqlName
        {
            get
            {
                
                if (_SqlName == null)
                    _SqlName = "[" + Name + "]";
                return _SqlName;
            }

        }
        private string _SqlParamTo;
        public string SqlParamTo
        {
            get
            {

                if (_SqlParamTo == null)
                    _SqlParamTo = "@" + Name+"_to";
                return _SqlParamTo;
            }

        }
        private string _SqlParamFrom;
        public string SqlParamFrom
        {
            get
            {

                if (_SqlParamFrom == null)
                    _SqlParamFrom = "@" + Name + "_from";
                return _SqlParamFrom;
            }

        }
        public Nullable<T> From { get; set; }
        public Nullable<T> To { get; set; }

        public RmValueFromTo(string name)
        {
            Name = name;
        }

        public void FillSql(List<SqlParameter> col, List<string> wheres)
        {
            if (From.HasValue)
            {
                col.Add(new SqlParameter(SqlParamFrom, From.Value));
                wheres.Add(SqlName + ">=" + SqlParamFrom);
            }
            if (To.HasValue)
            {
                col.Add(new SqlParameter(SqlParamTo, To.Value));
                wheres.Add(SqlName + "<=" + SqlParamTo);
            }
        }
    }
}
