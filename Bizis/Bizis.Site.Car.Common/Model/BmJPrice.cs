using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Bizis.Site.Car.Common.Model
{
    public class BmJPrice
    {
        [JsonProperty(PropertyName = "P")] 
        public Decimal? Price { get; set; }

        [JsonProperty(PropertyName = "ICD")]
        public bool IsCashDiscount { get; set; } //gotovinski popust
       
        [JsonProperty(PropertyName = "ILP")]
        public bool IsLastPrice { get; set; } //zadnja cena!

        [JsonProperty(PropertyName = "ILS")]
        public bool IsLoanSale { get; set; } //kredit

        [JsonProperty(PropertyName = "IL")]
        public bool IsLeasing { get; set; } //leasing

        [JsonProperty(PropertyName = "ILTO")]
        public bool IsLeasingTakeOver { get; set; } //prevzem leasinga
        
        [JsonProperty(PropertyName = "IOS")]
        public bool IsObrokiSale { get; set; } //prodaja na obroke

        [JsonProperty(PropertyName = "CE")]
        public bool CanExchange { get; set; } //menjava
    }
}
