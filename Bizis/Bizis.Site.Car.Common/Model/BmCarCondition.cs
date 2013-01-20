using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Bizis.Site.Car.Common.Model
{
    public class BmCarCondition
    {
        public short? Year { get; set; }
        public short Year1Reg { get; set; }
        public DateTime? MonthFirstReg { get; set; }
        public DateTime? MonthTechReview { get; set; }
        public int Km { get; set; }
        public int? OldTypeId { get; set; } //novo, testno, rabljeno, oldtimer
        public int? PreservedId { get; set; }

        public bool Is1Owner { get; set; }
        public bool Is2Owner { get; set; }
        public bool HasServisBook { get; set; }
        public bool HasGarage { get; set; } //garažiran
        public bool IsDamaged { get; set; }
    }
}
