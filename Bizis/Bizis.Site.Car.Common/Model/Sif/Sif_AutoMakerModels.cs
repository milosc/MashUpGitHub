using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bizis.Site.Car.Common.Model.Sif
{
    public class Sif_AutoMakerModels :Sif_Base<int>
    {
        public int MakerId { get; private set; }

        public Sif_AutoMakerModels(List<BmCarModel> models, int makerId)
            : base(models.ToDictionary(row => row.ModelId, row => row.Name_en), "en", "Auto model", (t) => "car_Model_" + makerId+ "_" + t) 
        {
            MakerId = makerId;
        }

    }
}
