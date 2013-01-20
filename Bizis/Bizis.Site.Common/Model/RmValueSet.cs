using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;
using System.Data;

namespace Bizis.Site.Common.Model
{
    public class RmValueSet<T> : RmValueBase where T: struct
    {
        private SqlDbType? _SqlDbType;
        public SqlDbType SqlDbType 
        { 
            get
            {
                if(!_SqlDbType.HasValue)
                {
                    if (typeof(T) == typeof(byte))
                        _SqlDbType = SqlDbType.TinyInt;
                    else if (typeof(T) == typeof(short))
                        _SqlDbType = SqlDbType.SmallInt;
                    else if (typeof(T) == typeof(int))
                        _SqlDbType = SqlDbType.Int;
                    else if (typeof(T) == typeof(long))
                        _SqlDbType = SqlDbType.BigInt;
                    else
                        throw new NotSupportedException("SqlDbType");
                }
                return _SqlDbType.Value;
            }
        }
        public HashSet<T> Val { get; set; }
        public RmValueSet(string name) : base(name) 
        {
        }
        public RmValueSet(string name, RmBase parent) : base(name, parent) 
        {
        }

        public void FillSql(List<SqlParameter> col, List<string> wheres)
        {
            if (Val == null || Val.Count == 0)
                return;
            if (Val.Count == 1)
            {
                col.Add(new SqlParameter(SqlParam, Val.First()));
                wheres.Add(SqlName + "=" + SqlParam);
            }
            else
            {

                wheres.Add(SqlName + " IN (" + string.Join(",", Val.Select(row=>row.ToString()).ToArray()) + ")");

                //string typeName;
                //List<SqlDataRecord> recs = _GetSqlDataRecords(out typeName);

                //SqlParameter p = new SqlParameter(SqlParam, SqlDbType.Structured);
                //p.Direction = ParameterDirection.Input;
                //p.TypeName = typeName;
                //p.Value = recs;
                //col.Add(p);
                //wheres.Add(SqlName + " IN (" + SqlParam + ")");
            }
        }

        private List<SqlDataRecord> _GetSqlDataRecords(out string typeName)
        {
            List<SqlDataRecord> recs = new List<SqlDataRecord>();
            SqlMetaData[] tvp_definition = { new SqlMetaData("n", SqlDbType) };

            Action<T,SqlDataRecord> set_value;

            switch (SqlDbType)
            {
                case SqlDbType.TinyInt: set_value= (t, r)=>{ r.SetByte(0, Convert.ToByte(t)); }; typeName="tinyint_list_tbltype"; break;
                case SqlDbType.SmallInt: set_value = (t, r) => { r.SetInt16(0, Convert.ToInt16(t)); }; typeName = "smallint_list_tbltype"; break;
                case SqlDbType.Int: set_value = (t, r) => { r.SetInt32(0, Convert.ToInt32(t)); }; typeName = "int_list_tbltype"; break;
                case SqlDbType.BigInt: set_value = (t, r) => { r.SetInt64(0, Convert.ToInt64(t)); }; typeName = "bigint_list_tbltype"; break;
                default: throw new NotSupportedException("SqlDbType");
            }
            foreach (T t in Val)
            {
                SqlDataRecord rec = new SqlDataRecord(tvp_definition);
                set_value(t, rec);
                recs.Add(rec);
            }
            return recs;
        }
    }
}
