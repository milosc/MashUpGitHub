using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bizis.Site.Common.Model;

namespace Bizis.Site.Common.Manager
{
    public class TranslationMng
    {
        public static TranslationMng _Current;
        public static TranslationMng Current
        {
            get 
            {
                if (_Current == null)
                    _Current = new TranslationMng();
                return _Current;
            }
        }

        private Dictionary<string, Translation> _Lang2Trans=new Dictionary<string,Translation>();
        private object _Lock = new object();
        public Translation Get(string lang)
        {
            Translation result;
            lock (_Lock)
            {
                if (_Lang2Trans.TryGetValue(lang, out result))
                    return result;
            }
            result = new Translation(lang);
            lock (_Lock)
            {
                _Lang2Trans[lang] = result;
            }
            return result;
        }
    }
}
