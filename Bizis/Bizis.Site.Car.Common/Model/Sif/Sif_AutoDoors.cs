using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bizis.Site.Car.Common.Model.Sif
{
    public class Sif_AutoDoors 
    {
        private static Sif_AutoDoors _Current;
        public static Sif_AutoDoors Current
        {
            get 
            {
                if (_Current == null)
                    _Current = new Sif_AutoDoors();
                return _Current;
            }
        }

        public Sif_Base<short> All {get; private set;}
        public Sif_Base<short> Filter { get; private set; }
        public readonly short MaxCount = 10;
        public readonly short MinCount = 1;
        public Sif_AutoDoors()
        {
            List<short> counting = new List<short>(MaxCount);
            for (short i = MinCount; i <= MaxCount; i++)
                counting.Add(i);

            Dictionary<short, string> filter = new Dictionary<short, string>()
            {
                {23,"2/3"},
                {45,"4/5"},
                {67,"6/7"}
            };
            Dictionary<short, string> all = counting.ToDictionary(row => row, row => row.ToString());
            foreach (var pair in filter)
                all.Add(pair.Key, pair.Value);
            All = new Sif_Base<short>(all);
            Filter = new Sif_Base<short>(filter);


        }
    }
}
