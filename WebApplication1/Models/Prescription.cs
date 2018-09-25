using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;

namespace WebApplication1.Models
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }
        public string DrugName { get; set; }

        public float Quantity { get; set; }

        public string DrugType { get; set; }

        public string IntakeTimeFrame { get; set; }

        public string Disease { get; set; }

        public int NoOfDays { get; set; }
    }
}