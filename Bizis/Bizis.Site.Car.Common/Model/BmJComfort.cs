using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Bizis.Site.Car.Common.Model
{
    public class BmJComfort
    {
        [JsonProperty(PropertyName = "Wd")] 
        public bool HasWood { get; set; } //        leseni dodatki notranjosti
        
        [JsonProperty(PropertyName = "ALU")] 
        public bool HasALU { get; set; } //ALU dodatki notranjosti

        [JsonProperty(PropertyName = "SmkPk")] 
        public bool HasSmokePackage { get; set; }//paket za kadilce

        [JsonProperty(PropertyName = "SpSt")]
        public bool HasSportSeat { get; set; }//sedeži: športni

        [JsonProperty(PropertyName = "CoSt")]
        public bool HasComfortSeat { get; set; } //sedeži: komfortni

        [JsonProperty(PropertyName = "OrSt")]
        public bool HasOrthopedicSeat { get; set; }//sedeži: ortopedski

        [JsonProperty(PropertyName = "StsH")]
        public bool HasSeatSetHeight { get; set; }//sedeži: nastavitev po višini

        [JsonProperty(PropertyName = "StsE")]
        public bool HasSeatSetByElect { get; set; }//sedeži: el. nastavitev

        [JsonProperty(PropertyName = "StsM")]
        public bool HasSeatMemory { get; set; } //sedeži: paket Memory 

        [JsonProperty(PropertyName = "StH")]
        public bool HasSeatHeating { get; set; } //sedeži: gretje

        [JsonProperty(PropertyName = "StC")]
        public bool HasSeatCooling { get; set; } //sedeži: hlajenje / ventilacija

        [JsonProperty(PropertyName = "ArRs")]
        public bool HasArmRest { get; set; } //sredinski naslon za roko med sedeži

        //-------------------------------------------

        [JsonProperty(PropertyName = "KlM")]
        public bool HasKlimaManual { get; set; } // klimatska naprava - ročna

        [JsonProperty(PropertyName = "KlA")]
        public bool HasKlimaAutomatic { get; set; }  //avtomatska klimatska naprava 

        [JsonProperty(PropertyName = "TWin")]
        public bool HasTintedWindows { get; set; } //tonirana stekla
        
        [JsonProperty(PropertyName = "WinFEl")]
        public bool HasWindowsFrontElectric { get; set; } //električni pomik prednjih stekel

        [JsonProperty(PropertyName = "WinBEl")]
        public bool HasWindowsBackElectric { get; set; } //električni pomik prednjih in zadnjih stekel

        [JsonProperty(PropertyName = "OMEl")]
        public bool HasOuterMirrorsElectric { get; set; }  //el. nastavljiva zunanja ogledala

        [JsonProperty(PropertyName = "OMH")]
        public bool HasOuterMirrorsHeating { get; set; }  //ogrevanje zunanjih ogledal

        [JsonProperty(PropertyName = "OMECl")]
        public bool HasOuterMirrorsElectrCollapsable { get; set; } //el. zložljiva zunanja ogledala

        [JsonProperty(PropertyName = "CLck")]
        public bool HasCentralLocking { get; set; } //centralno zaklepanje

        [JsonProperty(PropertyName = "CLckR")]
        public bool HasCentralLockingByRemote { get; set; } //centralno zaklepanje z dalj. upravljanjem

        [JsonProperty(PropertyName = "ElP")]
        public bool HasElectroPackage { get; set; } // električni paket

        [JsonProperty(PropertyName = "SWsH")]
        public bool HasStWheelSetByHeight { get; set; }//nastavljiv volan po višini

        [JsonProperty(PropertyName = "SWsD")]
        public bool HasStWheelSetByDepth { get; set; } //nastavljiv volan po globini

        [JsonProperty(PropertyName = "S")]
        public bool HasServo { get; set; } //servo volan

        [JsonProperty(PropertyName = "SWL")]
        public bool HasStWheelLeather { get; set; }  //volanski obroč oblečen v usnje

        [JsonProperty(PropertyName = "SWMf")]
        public bool HasStWheelMultiFunc { get; set; } //multifunkcijski volan

        [JsonProperty(PropertyName = "SWSp")]
        public bool HasStWheelSport { get; set; } // športni volan

        [JsonProperty(PropertyName = "KyG")]
        public bool HasKeylessGo { get; set; }  //Keyless Go

        [JsonProperty(PropertyName = "T")]
        public bool HasTempomat { get; set; }  //tempomat

        [JsonProperty(PropertyName = "TAd")]
        public bool HasTempomatAdv { get; set; }  //tempomat / Adaptive Cruise Control / Distronic

        [JsonProperty(PropertyName = "WinBS")]
        public bool HasBackWindowShading { get; set; } //senčni rolo za zadnje steklo
    }
}
