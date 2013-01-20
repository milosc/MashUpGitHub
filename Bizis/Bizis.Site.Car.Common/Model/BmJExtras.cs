using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Bizis.Site.Car.Common.Model
{
    public class BmJExtras
    {
        [JsonProperty(PropertyName = "SB12")]
        public bool CanSplitBench1_2 { get; set; } //        deljiva zad.klop 1/2 - 1/2

        [JsonProperty(PropertyName = "SB13")]
        public bool CanSplitBench1_3 { get; set; } //deljiva zad.klop 1/3 - 2/3

        [JsonProperty(PropertyName = "IsoF")]
        public bool HasIsofix { get; set; }  //Isofix sistem za pritrditev sedeža

        [JsonProperty(PropertyName = "ChStI")]
        public bool HasChildSeatInteg { get; set; }  //integrirani otroški sedež

        [JsonProperty(PropertyName = "SkBg")]
        public bool HasSkiBag { get; set; }  //vreča za smuči

        [JsonProperty(PropertyName = "CgNt")]
        public bool HasCargoNet { get; set; }  //mrežasta pregrada tovornega prostora
        
        [JsonProperty(PropertyName = "CgRl")]
        public bool HasCargoRoll { get; set; }  //rolo prtljažnega prostora

        [JsonProperty(PropertyName = "Tow")]
        public bool HasTowbar { get; set; }  //vlečna kljuka

        [JsonProperty(PropertyName = "RR")]
        public bool HasRoofRails { get; set; }  //strešne sani

        [JsonProperty(PropertyName = "PDC")]
        public bool HasPDC { get; set; }  //parkirni senzorji PDC

    }
}
