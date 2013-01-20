using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bizis.Site.Common.Manager;
using Bizis.Site.Common.Model;

namespace Bizis.Site.Car.Common.Model.Sif
{
    public class Sif_Base<T> : Sif_Base<T, string>
    {
        public Sif_Base(Dictionary<T, string> id2Name_en, string lang, string category, Func<T, string> translate_key)
            : base(id2Name_en, lang, category, translate_key, (v) => v, (orig, translated) => translated)
        {
        }
        public Sif_Base(Dictionary<T, string> id2Name)
            : base(id2Name)
        {
        }
    }


    public class Sif_Base<T, V>
    {

        private object _LockDic = new object();
        private object _LockPairs = new object();

        private Dictionary<T, V> _Id2Name;
        private KeyValuePair<T, V>[] __Pairs;
        private KeyValuePair<T, V>[] _Pairs
        {
            get
            {
                if (__Pairs == null)
                {
                    lock (_LockDic)
                    {
                        __Pairs = _Id2Name.ToArray();
                    }
                }
                return __Pairs;
            }
        }


        public Sif_Base(Dictionary<T, V> id2Value_en, string lang, string category, Func<T, string> translate_key, Func<V, string> translate_value, Func<V, string, V> create_value)
        {
            Translation trans = TranslationMng.Current.Get(lang);
            _Id2Name = id2Value_en.ToDictionary(
                    row => row.Key,
                    row => create_value(row.Value, trans.Translate(translate_key(row.Key), translate_value(row.Value), category))
                    );
        }
        public Sif_Base(Dictionary<T, V> id2Data)
        {
            _Id2Name = id2Data;
        }
        public V GetValue(T id)
        {
            lock (_LockDic)
            {
                return _Id2Name[id];
            }
        }

        public KeyValuePair<T, V>[] GetPairs()
        {
            int length = _Pairs.Length;
            KeyValuePair<T, V>[] result = new KeyValuePair<T, V>[length];
            lock (_LockPairs)
            {
                Array.Copy(_Pairs, result, length); ;
                //return _Pairs.ToArray(); //TODO optimize array copy
            }
            return result;
        }
    }
}
