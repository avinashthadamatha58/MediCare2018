using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PrescriptionOperationsController: ApiController
    {
        public string Get([FromUri]int paramOne)
        {
            PrescriptionOperations prescriptionOperations = new PrescriptionOperations();
            return prescriptionOperations.GetPrescriptionfromDatabase(paramOne);

        }
        public string Get()
        {
            PrescriptionOperations prescriptionOperations = new PrescriptionOperations();
            return prescriptionOperations.GetAllPrescriptions();
        }

        public bool Put([FromBody]Prescription prescription)
        {
            PrescriptionOperations prescriptionOperations = new PrescriptionOperations();
            return prescriptionOperations.PrescriptionInsertIntoDatabase(prescription);
        }
    }
}