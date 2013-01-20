using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Bizis.Site.Car.Common.Model
{
    public class BmJMultimedia
    {
        [JsonProperty(PropertyName = "AR")] 
        public bool HasAvtoradio { get; set; } //        avtoradio:
        [JsonProperty(PropertyName = "ARM")]
        public string AvtoradioModel { get; set; }

        [JsonProperty(PropertyName = "ARCd")]
        public bool HasAvtoradioCD { get; set; } //avtoradio / CD:   :
        [JsonProperty(PropertyName = "ARCdM")]
        public string AvtoradioCDModel { get; set; }

        [JsonProperty(PropertyName = "HiFi")]
        public bool HasHiFi { get; set; } //Hi-Fi ozvočenje:

        [JsonProperty(PropertyName = "HiFiM")]
        public string HiFiModel { get; set; }

        [JsonProperty(PropertyName = "CdSrv")]
        public bool HasCDServer { get; set; } // CD izmenjevalnik / strežnik 

        [JsonProperty(PropertyName = "Mp3")]
        public bool HasMp3 { get; set; } //MP3 predvajalnik

        [JsonProperty(PropertyName = "Dvd")]
        public bool HasDvd { get; set; } //DVD predvajalnik

        [JsonProperty(PropertyName = "Hd")]
        public bool HasHd { get; set; }  //trdi disk za shranjevanje podatkov

        [JsonProperty(PropertyName = "USB")]
        public bool HasUSB { get; set; } //USB priključek (iPod, HD, ...)

        [JsonProperty(PropertyName = "TV")]
        public bool HasTV { get; set; } //TV sprejemnik / tuner 

        [JsonProperty(PropertyName = "MobS")]
        public bool HasMobileSet { get; set; }  // predpriprava za mobilni telefon
        
        [JsonProperty(PropertyName = "CPhn")]
        public bool HasCarPhone { get; set; }  //avtotelefon
        
        [JsonProperty(PropertyName = "TrCmp")]
        public bool HasTravelComp { get; set; }  //potovalni računalnik

        [JsonProperty(PropertyName = "ComPck")]
        public bool HasCommPack { get; set; } //komunikacijski paket

        [JsonProperty(PropertyName = "Nav")]
        public bool HasNavig { get; set; } //navigacija

        [JsonProperty(PropertyName = "NavTv")]
        public bool HasNavigTv { get; set; } //navigacija + TV
    }
}
