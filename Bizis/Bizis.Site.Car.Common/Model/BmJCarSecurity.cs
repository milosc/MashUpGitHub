using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Bizis.Site.Car.Common.Model
{
    public class BmJCarSecurity
    {
        [JsonProperty(PropertyName = "AbC")] 
        public int AirbagCount { get; set; }

        [JsonProperty(PropertyName = "RDK")]
        public bool HasRDK { get; set; } //nadzor zračnega tlaka v pnevmatikah RDK
        
        [JsonProperty(PropertyName = "RS")]
        public bool HasRainSensor { get; set; } //senzor za dež

        [JsonProperty(PropertyName = "XL")]
        public bool HasXenonL{ get; set; } //xenonski žarometi

        [JsonProperty(PropertyName = "BXL")]
        public bool HasBiXenonL { get; set; } //bi-xenonski žarometi
        
        [JsonProperty(PropertyName = "FL")]
        public bool HasFogL { get; set; } //meglenke

        [JsonProperty(PropertyName = "HuD")]
        public bool HasHeadUpDisplay { get; set; }  //Head-Up display 

        [JsonProperty(PropertyName = "AL")]
        public bool HasAdaptiveL { get; set; } //Adaptive light / dinamično prilagodljivi žarometi

        [JsonProperty(PropertyName = "H3BL")]
        public bool Has3rdBreakL { get; set; } //3. zavorna luč

        [JsonProperty(PropertyName = "LW")]
        public bool HasLightWash { get; set; } //naprava za pranje žarometov

        [JsonProperty(PropertyName = "Alrm")]
        public bool HasAlarm { get; set; } //alarmna naprava

        [JsonProperty(PropertyName = "EB")]
        public bool HasEngineBlockade { get; set; } //blokada motorja

        [JsonProperty(PropertyName = "ESuC")]
        public bool HasEngineStartUpCode { get; set; } //kodno varovan vžig motorja 
    }
}
