using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWeather.Model
{
    public class Drug
    {
        [JsonProperty("DrugId")]
        public int DrugId { get; set; }
        [JsonProperty("DrugName")]
        public string DrugName { get; set; }
        [JsonProperty("DrugType")]
        public string DrugType { get; set; }
        [JsonProperty("CommonInTake")]
        public string CommonIntake { get; set; }
        [JsonProperty("AvailableNumber")]
        public int AvailableNumber { get; set; }

        [JsonIgnore]
        public string AvailableNumberDisplay => $"Quantity: "+ AvailableNumber;
        [JsonIgnore]
        public string DisplayDrugType => $"Type: "+ DrugType;
        [JsonIgnore]
        public string DisplayIcon => $"https://66.media.tumblr.com/7962d174c704296d22ffa5f299bcc8a6/tumblr_nhmirmXf531tndwljo1_500.png";
    }

    public class Prescription
    {
        [JsonProperty("PrescriptionId")]
        public int PrescriptionId { get; set; }
        [JsonProperty("DrugName")]
        public string DrugName { get; set; }
        [JsonProperty("Quantity")]
        public float Quantity { get; set; }
        [JsonProperty("DrugType")]
        public string DrugType { get; set; }
        [JsonProperty("IntakeTimeFrame")]
        public string IntakeTimeFrame { get; set; }
        [JsonProperty("Disease")]
        public string Disease { get; set; }
        [JsonProperty("NoOfDays")]
        public int NoOfDays { get; set; }

        [JsonIgnore]
        public string PrescriptionDrugNameDisplay => $"Prescribed Drug Name: " + DrugName;
        [JsonIgnore]
        public string PDisplayDrugType => $"Type: " + DrugType; 
        [JsonIgnore]
        public string PDisplayIntakeTimeFrame => $"Intake: " + IntakeTimeFrame;  
        [JsonIgnore]
        public string PDisplayNumberOfDays => $"Number of Days: " + NoOfDays;
        [JsonIgnore]
        public string DisplayIcon => $"http://files.softicons.com/download/culture-icons/sharingan-icons-1.5-by-harenome-razanajato/png/48x48/sasuke.png";
    }
}
