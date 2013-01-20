using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Bizis.Site.Car.Common.Model
{
    public class BmJUnderCarriage
    {
        [JsonProperty(PropertyName = "ALU")]
        public bool HasALUFelt { get; set; } //lahka (ALU) platišča:  
        
        [JsonProperty(PropertyName = "ALUM")]
        public string ALUFeltModel { get; set; } //lahka (ALU) platišča: 

        [JsonProperty(PropertyName = "ABS")]
        public bool HasABS { get; set; } // zavorni sistem ABS

        [JsonProperty(PropertyName = "BAS")]
        public bool HasBAS { get; set; } // pomoč pri zaviranju BAS

        [JsonProperty(PropertyName = "ASD")]
        public bool HasASD { get; set; } //samodejna zapora diferenciala ASD

        [JsonProperty(PropertyName = "ESP")]
        public bool HasESP { get; set; } //elektronski program stabilnosti ESP

        [JsonProperty(PropertyName = "EDC")]
        public bool HasEDC { get; set; } //elektronski nadzor blažilnikov EDC

        [JsonProperty(PropertyName = "RH")]
        public bool HasRegHeight { get; set; } //regulacija nivoja podvozja

        [JsonProperty(PropertyName = "H4x4")]
        public bool Has4x4 { get; set; } //        štirikolesni pogon (4x4 / 4WD / Quattro...)

        [JsonProperty(PropertyName = "ASR")]
        public bool HasASR { get; set; } //regulacija zdrsa pogonskih koles ASR / DTC

        [JsonProperty(PropertyName = "ETS")]
        public bool HasETS { get; set; } //elektronski sistem za boljši oprijem koles ETS

        [JsonProperty(PropertyName = "Sprt")]
        public bool HasSport { get; set; } // športno podvozje

        [JsonProperty(PropertyName = "ABC")]
        public bool HasABC { get; set; }//aktivno vzmetenje ABC - Active Body Control
    }
}
