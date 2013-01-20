using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bizis.Common.DL.MsSql;
using Bizis.Site.Common.Properties;

namespace Bizis.Site.Common.Manager
{
    class TranslationBL
    {

        public static Dictionary<string, string> GetByLang(string lang)
        {
            Dictionary<string, string>  result;
            using (DbTransaction t = new DbTransaction(Settings.Default.SiteCommonConnectionString, System.Data.IsolationLevel.ReadUncommitted))
            {
                t.Begin();
                result = new TranslationDL(t).GetByLang(lang);
                t.Commit();
            }
            return result;

        }

        internal static void EnsureTranslation(string lang, string key, string text_en, string category, out string result)
        {
            using (DbTransaction t = new DbTransaction(Settings.Default.SiteCommonConnectionString, System.Data.IsolationLevel.ReadCommitted))
            {
                TranslationDL dl = new TranslationDL(t);
                t.Begin();
                if (dl.TryGetAndLock(lang, key, out result))
                    return;
                dl.Insert(lang, key, text_en, category); //TODO Try catch
                
                t.Commit();
                result = text_en;
            }
        }
    }
}
