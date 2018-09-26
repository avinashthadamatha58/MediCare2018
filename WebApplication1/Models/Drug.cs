using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Drug
    {
        public int DrugId { get; set; }
        public string DrugName { get; set; }
        public string DrugType { get; set; }
        public string CommonIntake { get; set; }
        public int AvailableNumber { get; set; }
    }
}