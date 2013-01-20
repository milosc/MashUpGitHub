using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bizis.Site.Car.Common.Manager;

namespace Bizis.Site.Car.Common.Model.Sif
{
    public class Sif_AutoModels
    {
        private static Sif_AutoModels _Current;
        public static Sif_AutoModels Current
        {
            get 
            {
                if (_Current == null)
                    _Current = new Sif_AutoModels();
                return _Current;
            }
        }

        private Dictionary<int, Sif_AutoMakerModels> _Maker2Models;
        private object _Lock = new object();

        public Sif_AutoModels()
        {
            List<BmCarModel> models = MakerModelBL.GetCarModels();

            Dictionary<int, List<BmCarModel>> maker2Model = new Dictionary<int, List<BmCarModel>>();
            foreach (BmCarModel model in models)
            {
                List<BmCarModel> makerModels;
                if (maker2Model.TryGetValue(model.MakerId, out makerModels))
                    makerModels.Add(model);
                else
                    maker2Model[model.MakerId] = new List<BmCarModel>() { model };
            }
            _Maker2Models = maker2Model.ToDictionary(row => row.Key, row => new Sif_AutoMakerModels(row.Value, row.Key));
        }
        public Sif_AutoMakerModels GetModelsByMaker(int makerId)
        {
            lock (_Lock)
            {
                return _Maker2Models[makerId];
            }
        }
    }
}
