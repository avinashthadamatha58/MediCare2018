using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MyWeather.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MyWeather.Services
{
    public class MediCareService
    {
        const string GetDrugUri = "http://10.0.2.2:8090/DrugOperations?paramOne=1";
        const string GetDrugUri1 = "http://192.168.43.237:8070/DrugOperations?paramOne=1";

        const string GetAllDrugsfromDatabase = "http://10.0.2.2:8090/DrugOperations";
        const string GetAllDrugsfromDatabase1 = "http://192.168.43.237:8070/DrugOperations";

        const string GetPrescriptionUri = "http://10.0.2.2:8090/PrescriptionOperations?paramOne=1";
        const string GetPrescriptionUri1 = "http://192.168.43.237:8070/PrescriptionOperations?paramOne=1";

        const string GetAllPrescriptionsfromDatabase = "http://10.0.2.2:8090/PrescriptionOperations";
        const string GetAllPrescriptionsfromDatabase1 = "http://192.168.43.237:8070/PrescriptionOperations";


        // const string GetDrugUri = "http://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&units={2}&appid=fc9f6c524fc093759cd28d41fda89a1b";

        public async Task<Drug> GetDrug(int drugId)
        {
            var handler = new HttpClientHandler { Credentials = new NetworkCredential("appriver\\athadamatha", "QazPlm@0958") };
            using (var client = new HttpClient(handler))
            {
                try
                {
                    var json = await client.GetStringAsync(GetDrugUri1);

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
                    var json = await client.GetStringAsync(GetAllDrugsfromDatabase1);

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
                    var json = await client.GetStringAsync(GetPrescriptionUri1);

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
                    var json = await client.GetStringAsync(GetAllPrescriptionsfromDatabase1);

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
    class JobsAndTriggers
    {
        public string jobIdentityKey { get; set; }
        public string TriggerIdentityKey { get; set; }
        public string jobData_MethodName { get; set; }
        public int ScheduleIntervalInSec { get; set; }
    }
    //class Program
    //{
    //    public static Drug lapaki { get; set; }

    //   public void TriggerJob()
    //    {
    //        List<JobsAndTriggers> LstobjJobsAndTriggers = new List<JobsAndTriggers>();
    //        LstobjJobsAndTriggers.Add(new JobsAndTriggers { jobIdentityKey = "JOB1", TriggerIdentityKey = "TRIGGER1", jobData_MethodName = "JOB1_METHOD()", ScheduleIntervalInSec = 5 });
    //        LstobjJobsAndTriggers.Add(new JobsAndTriggers { jobIdentityKey = "JOB2", TriggerIdentityKey = "TRIGGER2", jobData_MethodName = "JOB2_METHOD()", ScheduleIntervalInSec = 10 });


    //        TestDemoJob1(LstobjJobsAndTriggers).GetAwaiter().GetResult();

    //    }
    //    public static async Task TestDemoJob1(List<JobsAndTriggers> lstJobsAndTriggers)

    //    {

    //        IScheduler scheduler;
    //        IJobDetail job = null;
    //        ITrigger trigger = null;

    //        var schedulerFactory = new StdSchedulerFactory();

    //        scheduler = schedulerFactory.GetScheduler().Result;

    //        scheduler.Start().Wait();

    //        foreach (var JobandTrigger in lstJobsAndTriggers)
    //        {

    //            //  int ScheduleIntervalInSec = 1;//job will run every minute

    //            JobKey jobKey = JobKey.Create(JobandTrigger.jobIdentityKey);



    //            job = JobBuilder.Create<DemoJob1>().
    //               WithIdentity(jobKey)
    //               .UsingJobData("MethodName", JobandTrigger.jobData_MethodName)
    //               .Build();



    //            trigger = TriggerBuilder.Create()

    //            .WithIdentity(JobandTrigger.TriggerIdentityKey)

    //            .StartNow()

    //            .WithSimpleSchedule(x => x.WithIntervalInSeconds(JobandTrigger.ScheduleIntervalInSec).WithRepeatCount(1)
    //            // .RepeatForever()
    //            )

    //            .Build();

    //            await scheduler.ScheduleJob(job, trigger);

    //        }



    //    }
    //}
    //public class DemoJob1 : IJob

    //{

    //    public Task Execute(IJobExecutionContext context)

    //    {

    //        //simple task, the job just prints current datetime in console

    //        //return Task.Run(() => {

    //        //    //Console.WriteLine(DateTime.Now.ToString());

    //        //});
    //        Program.lapaki = new MediCareService().GetDrug(1).GetAwaiter().GetResult();
    //        JobKey key = context.JobDetail.Key;

    //        JobDataMap dataMap = context.JobDetail.JobDataMap;

    //        //string MethodName = dataMap.GetString("MethodName");
    //        //Console.WriteLine(DateTime.Now.ToString() + " " + MethodName);

    //        return Task.FromResult(0);

    //    }

    //}
}
