using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bizis.Site.Common.Manager;

namespace Bizis.Site.Common.Model
{
    public class Translation
    {

        private Dictionary<string, string> _Key2Text;
        private object _Lock = new object();
        public string Lang { get; private set; }
         
        public Translation(string lang)
        {
            Lang = lang;
            _Key2Text = TranslationBL.GetByLang(lang);
        }
        public string Translate(string key, string text, string category)
        {

            if (string.IsNullOrWhiteSpace(text))
                return text;
            string result;
            lock (_Lock)
            {
                if (_Key2Text.TryGetValue(key, out result))
                    return result;
            }
            
            TranslationBL.EnsureTranslation(Lang, key, text, category ?? "common", out result);
            lock (_Lock)
            {
                if (_Key2Text.TryGetValue(key, out result))
                    return result;
                else
                    _Key2Text[key] = result;
            }
            return result;
        }

    }
}
