using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bizis.Site.Car.Common.Model.Sif
{
    public class SifLangStore<S> 
    {
        private Dictionary<string, S> _Lang2Sif = new Dictionary<string,S>();
        private object _Lock = new object();

        public S Get(string lang, Func<S> create)
        {
            S sif;
            lock (_Lock)
            {
                if (_Lang2Sif.TryGetValue(lang, out sif))
                    return sif;
            }
            sif = create();
            lock (_Lock)
            {
                _Lang2Sif[lang] = sif;
            }
            return sif;
        }
    }
}
