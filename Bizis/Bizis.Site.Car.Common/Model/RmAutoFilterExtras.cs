using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bizis.Site.Common.Model;
using System.Data.SqlClient;

namespace Bizis.Site.Car.Common.Model
{
    public class RmAutoFilterExtras
    {
        public RmValue<bool> HasABS = new RmValue<bool>("HasABS");
        public RmValue<bool> HasESP = new RmValue<bool>("HasESP");
        public RmValue<bool> HasAirbag = new RmValue<bool>("HasAirbag");
        public RmValue<bool> HasKlima = new RmValue<bool>("HasKlima");
        public RmValue<bool> HasAutoKlima = new RmValue<bool>("HasAutoKlima");
        public RmValue<bool> HasSeatHeating = new RmValue<bool>("HasSeatHeating");
        public RmValue<bool> HasElWin = new RmValue<bool>("HasElWin");
        public RmValue<bool> HasCentrLock = new RmValue<bool>("HasCentrLock");
        public RmValue<bool> HasSunRoof = new RmValue<bool>("HasSunRoof");
        public RmValue<bool> HasServo = new RmValue<bool>("HasServo");
        public RmValue<bool> HasTempomat = new RmValue<bool>("HasTempomat");
        public RmValue<bool> HasNavig = new RmValue<bool>("HasNavig");
        public RmValue<bool> HasXenonL = new RmValue<bool>("HasXenonL");
        public RmValue<bool> HasLeather = new RmValue<bool>("HasLeather");
        public RmValue<bool> HasAluFelt = new RmValue<bool>("HasAluFelt");
        public RmValue<bool> Has4x4 = new RmValue<bool>("Has4x4");
        public RmValue<bool> HasTowbar = new RmValue<bool>("HasTowbar");
        public RmValue<bool> HasGarage = new RmValue<bool>("HasGarage");
        public RmValue<bool> Is1Owner = new RmValue<bool>("Is1Owner");
        public RmValue<bool> HasServisBook = new RmValue<bool>("HasServisBook");
        public RmValue<bool> CanExchange = new RmValue<bool>("CanExchange");

        internal void FillSql(List<SqlParameter> ps, List<string> wheres)
        {
            if (HasABS.Val) HasABS.FillSql(ps, wheres);
            if (HasESP.Val) HasESP.FillSql(ps, wheres);
            if (HasAirbag.Val) HasAirbag.FillSql(ps, wheres);
            if (HasKlima.Val) HasKlima.FillSql(ps, wheres);
            if (HasAutoKlima.Val) HasAutoKlima.FillSql(ps, wheres);
            if (HasSeatHeating.Val) HasSeatHeating.FillSql(ps, wheres);
            if (HasElWin.Val) HasElWin.FillSql(ps, wheres);
            if (HasCentrLock.Val) HasCentrLock.FillSql(ps, wheres);
            if (HasSunRoof.Val) HasSunRoof.FillSql(ps, wheres);
            if (HasServo.Val) HasServo.FillSql(ps, wheres);
            if (HasTempomat.Val) HasTempomat.FillSql(ps, wheres);
            if (HasNavig.Val) HasNavig.FillSql(ps, wheres);
            if (HasXenonL.Val) HasXenonL.FillSql(ps, wheres);
            if (HasLeather.Val) HasLeather.FillSql(ps, wheres);
            if (HasAluFelt.Val) HasAluFelt.FillSql(ps, wheres);
            if (Has4x4.Val) Has4x4.FillSql(ps, wheres);
            if (HasTowbar.Val) HasTowbar.FillSql(ps, wheres);
            if (HasGarage.Val) HasGarage.FillSql(ps, wheres);
            if (Is1Owner.Val) Is1Owner.FillSql(ps, wheres);
            if (HasServisBook.Val) HasServisBook.FillSql(ps, wheres);
            if (CanExchange.Val) CanExchange.FillSql(ps, wheres);
        }
    }
}
