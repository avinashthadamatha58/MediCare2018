using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MyWeather.Model;
using MyWeather.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MyWeather.Services
{
    class MediCareService
    {
        const string GetDrugUri = "http://10.0.2.2:8090/DrugOperations?paramOne=1";
        const string GetDrugUri1 = "http://192.168.43.237:8090/DrugOperations?paramOne=1";

        const string GetAllDrugsfromDatabase = "http://10.0.2.2:8090/DrugOperations";
        const string GetAllDrugsfromDatabase1 = "http://192.168.43.237:8090/DrugOperations";

        const string GetPrescriptionUri = "http://10.0.2.2:8090/PrescriptionOperations?paramOne=1";
        const string GetPrescriptionUri1 = "http://192.168.43.237:8090/PrescriptionOperations?paramOne=1";

        const string GetAllPrescriptionsfromDatabase = "http://10.0.2.2:8090/PrescriptionOperations";
        const string GetAllPrescriptionsfromDatabase1 = "http://192.168.43.237:8090/PrescriptionOperations";


        // const string GetDrugUri = "http://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&units={2}&appid=fc9f6c524fc093759cd28d41fda89a1b";

        public async Task<Drug> GetDrug(int drugId)
        {
            var handler = new HttpClientHandler { Credentials = new NetworkCredential("appriver\\athadamatha", "QazPlm@0958") };
            using (var client = new HttpClient(handler))
            {
                try
                {
                    var json = await client.GetStringAsync(GetDrugUri);

                    if (string.IsNullOrWhiteSpace(json))
                        return null;

                    json = json.Substring(1, json.Length - 2);
                    json = json.Replace("\\", "");
                    JObject.Parse(json);
                    return JsonConvert.DeserializeObject<Drug>(json);
                }
                catch (Exception e)
                {

                    return null;
                }
            }

        }

        public async Task<List<Drug>> GetAllDrugs()
        {
            var handler = new HttpClientHandler { Credentials = new NetworkCredential("appriver\\athadamatha", "QazPlm@0958") };
            using (var client = new HttpClient(handler))
            {
                try
                {
                    var json = await client.GetStringAsync(GetAllDrugsfromDatabase);

                    if (string.IsNullOrWhiteSpace(json))
                        return null;
                    json = json.Substring(1, json.Length - 2);
                    json = json.Replace("\\", "");
                    return JsonConvert.DeserializeObject<List<Drug>>(json);
                }
                catch (Exception e)
                {

                    return null;
                }
            }
        }

        public async Task<Prescription> GetPrescription(int prescriptionId)
        {
            var handler = new HttpClientHandler { Credentials = new NetworkCredential("appriver\\athadamatha", "QazPlm@0958") };
            using (var client = new HttpClient(handler))
            {
                try
                {
                    var json = await client.GetStringAsync(GetPrescriptionUri);

                    if (string.IsNullOrWhiteSpace(json))
                        return null;

                    json = json.Substring(1, json.Length - 2);
                    json = json.Replace("\\", "");
                    JObject.Parse(json);
                    return JsonConvert.DeserializeObject<Prescription>(json);
                }
                catch (Exception e)
                {
                    return null;
                }
            }

        }

        public async Task<List<Prescription>> GetAllPrescriptions()
        {
            var handler = new HttpClientHandler { Credentials = new NetworkCredential("appriver\\athadamatha", "QazPlm@0958") };
            using (var client = new HttpClient(handler))
            {
                try
                {
                    var json = await client.GetStringAsync(GetAllPrescriptionsfromDatabase);

                    if (string.IsNullOrWhiteSpace(json))
                        return null;
                    json = json.Substring(1, json.Length - 2);
                    json = json.Replace("\\", "");
                    return JsonConvert.DeserializeObject<List<Prescription>>(json);
                }
                catch (Exception e)
                {

                    return null;
                }
            }
        }
    }
}
