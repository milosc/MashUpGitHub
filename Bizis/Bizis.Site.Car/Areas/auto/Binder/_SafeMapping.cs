using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bizis.Site.Car.Areas.auto.Binder
{
    public class _SafeMapping
    {
        static _SafeMapping()
        {
            Dictionary<string, string> key2Description = new Dictionary<string, string>()
            {
                {"t", "VehicleType" },
                {"model", "Model" },
                {"make", "Maker" },
                {"var", "Variant"},
                {"p_min", "Price min"},
                {"p_max", "Price max"},
                {"p_no", "Price show with no price"},
                {"km_min", "Km min"},
                {"km_max", "Km max"},
                {"kw_min", "Kw min"},
                {"kw_max", "Kw max"},
                {"ccm_min", "ccm min"},
                {"ccm_max", "ccm max"},
                {"reg1_min", "year 1.reg min"},
                {"reg1_max", "year 1.reg max"},
                {"seat_count","seat_count"},
                {"doors","doors  count"},
                {"gearbox", "gearbox"},
                {"fuel", "fuel"},
                {"isdamage", "isdamage"},
                {"pub_days", "ad published since days"},
                {"vendor", "vendor type"},

                {"abs", "HasABS"},
                {"esp", "HasESP"},
                {"airbag", "HasAirbag"},
                {"klima", "HasKlima"},
                {"aklima", "HasAutoKlima"},
                {"seat_heating", "HasSeatHeating"},
                {"el_win", "HasElWin"},
                {"cntr_lock", "HasCentrLock"},
                {"sunroof", "HasSunRoof"},
                {"servo", "HasServo"},
                {"tempomat", "HasTempomat"},
                {"navig", "HasNavig"},
                {"xenon", "XenonL"},
                {"leather", "HasLeather"},
                {"alu", "HasAluFelt"},
                {"is4x4", "Has4x4"},
                {"towbar", "HasTowbar"},
                {"garage", "HasGarage"},
                {"owner1", "Is1Owner"},
                {"sbook", "HasServisBook"},
                {"canexchg", "CanExchange"},
                {"c","Exterior color"},
                
                {"ot","Old type (new, used, test,..)"},
                {"seat_col","seat_color"}

            };
        }
    }
}