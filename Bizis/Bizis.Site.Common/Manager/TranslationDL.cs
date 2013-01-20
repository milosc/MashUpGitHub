using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bizis.Common.DL.MsSql;
using System.Data.SqlClient;

namespace Bizis.Site.Common.Manager
{
    class TranslationDL : DbContext
    {
        public TranslationDL(DbTransaction t)
            : base(t)
        { }


        internal Dictionary<string, string> GetByLang(string lang)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            string sql = @"SELECT [Key],[Text] FROM [dbo].[com_Translations] WHERE [Language]=@lang";
            using (SqlCommand command = base.CreateCommand(sql))
            {
                command.Parameters.AddWithValue("@lang", lang);
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                        result.Add(dr.GetString(0), dr.GetString(1));
                }
            }
            return result;
        }

        internal bool TryGetAndLock(string lang, string key, out string text)
        {
            text = null;
            string sql = @"SELECT [Text] FROM [dbo].[com_Translations] WITH (UPDLOCK, HOLDLOCK) WHERE [Language]=@lang AND [Key]=@key";
            using (SqlCommand command = base.CreateCommand(sql))
            {
                command.Parameters.AddWithValue("@lang", lang);
                command.Parameters.AddWithValue("@key", key);
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        text = dr.GetString(0);
                        return true;
                    }
                }
            }
            return false;
        }

        internal void Insert(string lang, string key, string text, string category)
        {
            string sql = @"INSERT INTO [dbo].[com_Translations]"
                        + "([Key],[Language],[Text],[Category]) VALUES(@key, @lang, @text, @category)";
            using (SqlCommand command = base.CreateCommand(sql))
            {
                command.Parameters.AddWithValue("@key", key);
                command.Parameters.AddWithValue("@lang", lang);
                command.Parameters.AddWithValue("@text", text);
                command.Parameters.AddWithValue("@category", category);
                command.ExecuteNonQuery();
            }
        }
    }
}
