using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DrugOperationsController : ApiController
    {
        public string Get([FromUri]int paramOne)
        {
            DrugOperations drugOperations = new DrugOperations();
            return drugOperations.GetDrugfromDatabase(paramOne);
        }
        public string Get()
        {
            DrugOperations drugOperations = new DrugOperations();
           return drugOperations.GetAllDrugs();
        }

        public bool Put([FromBody]Drug drug)
        {
            DrugOperations drugOperations = new DrugOperations();
            return drugOperations.DrugInsertIntoDatabase(drug);
        }
    }
}