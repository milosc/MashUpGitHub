using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bizis.Site.Car.Common.Model.Sif;
using Bizis.Site.Common.Model;
using System.Web.Routing;

namespace Bizis.Site.Car.Areas.auto.Models
{
    public class VmAutoModel
    {
        public VmValue<int?> MakerId { get; private set; }
        public VmValue<int?> ModelId { get; private set; }

        public int? No { get; private set; }
        protected string NoPostFix { get; private set; }

        private List<SelectListItem> _Makers;
        public List<SelectListItem> Makers
        {
            get 
            {
                if (_Makers == null)
                {
                    _Makers = new List<SelectListItem>() { new SelectListItem() { Value = string.Empty, Text = string.Empty, Selected = !MakerId.Val.HasValue } };
                    var makers = Sif_AutoMakers.Current.GetPairs()
                        .Select(row => new SelectListItem() { Value = row.Key.ToString(), Text = row.Value, Selected = (MakerId.Val == row.Key) })
                        .ToList();
                    _Makers.AddRange(makers); 
                }
                return _Makers;
            }
        }
        private List<SelectListItem> _Models;
        public List<SelectListItem> Models
        {
            get
            {
                if (_Models == null)
                {
                    _Models = new List<SelectListItem>() { new SelectListItem() { Value = string.Empty, Text = string.Empty, Selected = !ModelId.Val.HasValue } };

                    if (ModelId.Val.HasValue)
                    {
                        var models = Sif_AutoModels.Current.GetModelsByMaker(MakerId.Val.Value).GetPairs()
                            .Select(row => new SelectListItem() { Value = row.Key.ToString(), Text = row.Value, Selected = (ModelId.Val == row.Key) })
                            .ToList();
                        _Models.AddRange(models);
                    }
                }
                return _Makers;
            }
        }
        public VmAutoModel(int? no)
        {
            NoPostFix = no.HasValue ? no.Value.ToString() : string.Empty;
            ModelId = new VmValue<int?>("model" + NoPostFix);
            MakerId = new VmValue<int?>("make" + NoPostFix);

        }

        internal virtual void FillQueryString(RouteValueDictionary r)
        {
            if (MakerId.Val.HasValue)
            {
                r.Add(MakerId.Name, MakerId.Val);
                if(ModelId.Val.HasValue)
                    r.Add(ModelId.Name, ModelId.Val);
            }
        }
    }
}