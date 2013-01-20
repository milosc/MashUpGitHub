using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bizis.Site.Car.Common.Model;
using Bizis.Site.Car.Common.Manager;

namespace Bizis.Site.Car.Fetcher.Services
{
    public class CarSifLoader
    {

        public void Load()
        {
            //_TryLoadMakers();

            _TryLoadModels();
        }

        private void _TryLoadModels()
        {
            Dictionary<string, int> refId2MakerId = MakerModelBL.GetRefId2MakerId();
            foreach (var pair in refId2MakerId)
                _TryLoadModels(pair.Key, pair.Value);
        }

        private void _TryLoadModels(string makerRefId, int makerId)
        {
            bool success;
            List<car_Models> models = new FetcherCarModel(makerRefId, makerId).Fetch(out success);
            MakerModelBL.InsertOrUpdate(models);
        }

        private bool _TryLoadMakers()
        {
            bool success;
            List<car_Makers> makers = new FetcherCarMaker().Fetch(out success);
            MakerModelBL.InsertOrUpdate(makers);
            return success;
        }
    }
}
