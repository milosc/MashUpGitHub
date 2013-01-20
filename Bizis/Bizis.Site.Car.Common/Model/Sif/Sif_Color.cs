using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bizis.Site.Common.Manager;
using Bizis.Site.Common.Model;

namespace Bizis.Site.Car.Common.Model.Sif
{
    public class Sif_Color
    {
        private static Dictionary<string, Sif_Color> _Current = new Dictionary<string, Sif_Color>();
        private static object _Lock = new object();
        public static Sif_Color Current(string lang)
        {
            Sif_Color sif;
            lock (_Lock)
            {
                if (_Current.TryGetValue(lang, out sif))
                    return sif;
            }
            sif = new Sif_Color(lang);
            lock (_Lock)
            {
                _Current[lang] = sif;
            }
            return sif;
        }
        public BmColor AnyColor { get; private set; }
        public Sif_Base<byte, BmColor> All { get; private set; }
        public Sif_Base<byte, BmColor> Exterior { get; private set; }
        public Sif_Base<byte, BmColor> Seats { get; private set; }


        
        public Sif_Color(string lang)
        {
            Translation trans = TranslationMng.Current.Get(lang);

            AnyColor =  new BmColor("any", trans.Translate("color_any", "Any color","Colors"));

            Dictionary<byte, BmColor> exterior  = new Dictionary<byte, BmColor>()
            {
                    {1, new BmColor("beige", "Beige") },
                    {2, new BmColor("black", "Black") },
                    {3, new BmColor("blue", "Blue") },
                    {4, new BmColor("brown", "Brown") },
                    {5, new BmColor("gold", "Gold") },
                    {6, new BmColor("green", "Green") },
                    {7, new BmColor("grey", "Grey") },
                    {8, new BmColor("orange", "Orange") },
                    {9, new BmColor("purple", "Purple") },
                    {10, new BmColor("red", "Red") },
                    {11, new BmColor("silver", "Silver") },
                    {12, new BmColor("white", "White") },
                    {13, new BmColor("yellow", "Yellow") },
            };
            Dictionary<byte, BmColor> seats = new Dictionary<byte, BmColor>()
            {
                    {1, new BmColor("beige", "Beige") },
                    {2, new BmColor("black", "Black") },
                    {3, new BmColor("blue", "Blue") },
                    {4, new BmColor("brown", "Brown") },
                    {6, new BmColor("green", "Green") },
                    {7, new BmColor("grey", "Grey") },
                    {10, new BmColor("red", "Red") },
                    {12, new BmColor("white", "White") },
            };
            Dictionary<byte, BmColor> all = exterior;

            All = new Sif_Base<byte, BmColor>(all, lang, "Colors", (t) => "color_" + t, (v) => v.Name, (orig, translated) => new BmColor(orig.Key, translated));
            Seats = new Sif_Base<byte, BmColor>(seats, lang, "Colors", (t) => "color_" + t, (v) => v.Name, (orig, translated) => new BmColor(orig.Key, translated));
            Exterior = new Sif_Base<byte, BmColor>(exterior, lang, "Colors", (t) => "color_" + t, (v) => v.Name, (orig, translated) => new BmColor(orig.Key, translated));
        }
    }
}
