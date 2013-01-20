using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bizis.Site.Car.Common.Model
{
    public class BmCarModel
    {
        public int MakerId { get; private set; }
        public int ModelId { get; private set; }
        public string Name_en { get; private set; }
        public BmCarModel(int makerId, int modelId, string name_en)
        {
            MakerId = makerId;
            ModelId = modelId;
            Name_en = name_en;
        }
    }
}
