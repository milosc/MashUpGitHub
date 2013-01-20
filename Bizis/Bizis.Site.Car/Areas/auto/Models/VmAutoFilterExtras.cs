using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bizis.Site.Common.Model;
using System.Web.Routing;
using Bizis.Site.Car.Common.Model;

namespace Bizis.Site.Car.Areas.auto.Models
{
    public class VmAutoFilterExtras
    {
        public VmValue<bool> HasABS { get; private set; }
        public VmValue<bool> HasESP { get; private set; }
        public VmValue<bool> HasAirbag { get; private set; }
        public VmValue<bool> HasKlima { get; private set; }
        public VmValue<bool> HasAutoKlima { get; private set; }
        public VmValue<bool> HasSeatHeating { get; private set; }
        public VmValue<bool> HasElWin { get; private set; }
        public VmValue<bool> HasCentrLock { get; private set; }
        public VmValue<bool> HasSunRoof { get; private set; }
        public VmValue<bool> HasServo { get; private set; }
        public VmValue<bool> HasTempomat { get; private set; }
        public VmValue<bool> HasNavig { get; private set; }
        public VmValue<bool> HasXenonL { get; private set; }
        public VmValue<bool> HasLeather { get; private set; }
        public VmValue<bool> HasAluFelt { get; private set; }
        public VmValue<bool> Has4x4 { get; private set; }
        public VmValue<bool> HasTowbar { get; private set; }
        public VmValue<bool> HasGarage { get; private set; }
        public VmValue<bool> Is1Owner { get; private set; }
        public VmValue<bool> HasServisBook { get; private set; }
        public VmValue<bool> CanExchange { get; private set; }

        public VmContext Context { get; private set; }
        public VmAutoFilterExtras(VmContext context)
        {
            Context = context;
            HasABS = new VmValue<bool>("abs");
            HasESP = new VmValue<bool>("esp");
            HasAirbag = new VmValue<bool>("airbag");
            HasKlima = new VmValue<bool>("klima");
            HasAutoKlima = new VmValue<bool>("aklima");
            HasSeatHeating = new VmValue<bool>("seat_heating");
            HasElWin = new VmValue<bool>("el_win");
            HasCentrLock = new VmValue<bool>("cntr_lock");
            HasSunRoof = new VmValue<bool>("sunroof");
            HasServo = new VmValue<bool>("servo");
            HasTempomat = new VmValue<bool>("tempomat");
            HasNavig = new VmValue<bool>("navig");
            HasXenonL = new VmValue<bool>("xenon");
            HasLeather = new VmValue<bool>("leather");
            HasAluFelt = new VmValue<bool>("alu");
            Has4x4 = new VmValue<bool>("is4x4");
            HasTowbar = new VmValue<bool>("towbar");
            HasGarage = new VmValue<bool>("garage");
            Is1Owner = new VmValue<bool>("owner1");
            HasServisBook = new VmValue<bool>("sbook");
            CanExchange = new VmValue<bool>("canexchg");
        }
        internal RmAutoFilterExtras GetRequestModel()
        {
            RmAutoFilterExtras r = new RmAutoFilterExtras();
            r.HasABS.Val = HasABS.Val;
            r.HasESP.Val = HasESP.Val;
            r.HasAirbag.Val = HasAirbag.Val;
            r.HasKlima.Val = HasKlima.Val;
            r.HasAutoKlima.Val = HasAutoKlima.Val;
            r.HasSeatHeating.Val = HasSeatHeating.Val;
            r.HasElWin.Val = HasElWin.Val;
            r.HasCentrLock.Val = HasCentrLock.Val;
            r.HasSunRoof.Val = HasSunRoof.Val;
            r.HasServo.Val = HasServo.Val;
            r.HasTempomat.Val = HasTempomat.Val;
            r.HasNavig.Val = HasNavig.Val;
            r.HasXenonL.Val = HasXenonL.Val;
            r.HasLeather.Val = HasLeather.Val;
            r.HasAluFelt.Val = HasAluFelt.Val;
            r.Has4x4.Val = Has4x4.Val;
            r.HasTowbar.Val = HasTowbar.Val;
            r.HasGarage.Val = HasGarage.Val;
            r.Is1Owner.Val = Is1Owner.Val;
            r.HasServisBook.Val = HasServisBook.Val;
            r.CanExchange.Val = CanExchange.Val;
            return r;
            
        }
        internal void FillQueryString(RouteValueDictionary r)
        {
            _Fill(r, HasABS);
            _Fill(r, HasESP);
            _Fill(r, HasAirbag);
            _Fill(r, HasKlima);
            _Fill(r, HasAutoKlima);
            _Fill(r, HasSeatHeating);
            _Fill(r, HasElWin);
            _Fill(r, HasCentrLock);
            _Fill(r, HasSunRoof);
            _Fill(r, HasServo);
            _Fill(r, HasTempomat);
            _Fill(r, HasNavig);
            _Fill(r, HasXenonL);
            _Fill(r, HasLeather);
            _Fill(r, HasAluFelt);
            _Fill(r, HasTowbar);
            _Fill(r, HasGarage);
            _Fill(r, Is1Owner);
            _Fill(r, HasServisBook);
            _Fill(r, CanExchange);
        }

        private void _Fill(RouteValueDictionary r, VmValue<bool> v)
        {
            if (v.Val)
                r.Add(v.Name, v.Val);
        }

        
    }
}