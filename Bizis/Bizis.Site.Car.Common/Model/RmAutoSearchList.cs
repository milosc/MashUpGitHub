using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bizis.Site.Car.Common.Model
{
    public class RmAutoSearchList
    {

        private List<RmAutoSearchItem> _Items;
        public List<RmAutoSearchItem> Items
        {
            get 
            {
                if (_Items == null)
                    _Items = new List<RmAutoSearchItem>();
                return _Items;
            }
        }

    }
}
