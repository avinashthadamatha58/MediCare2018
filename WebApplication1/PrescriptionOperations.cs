using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApplication1.AppData;
using WebApplication1.Models;

namespace WebApplication1
{
    public class PrescriptionOperations
    {
        public bool PrescriptionInsertIntoDatabase(Prescription prescription)
        {
            var connString = new Connection();
            using (SqlConnection conn = new SqlConnection(connString.connString))
            {
                conn.Open();

                // DbCommand also implements IDisposable
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    // create command with placeholders
                    cmd.CommandText =
                        "INSERT INTO Prescriptions " +
                        "([prescriptionId], [drugName],  [quantity], [drugType], [intakeTimeFrame], [disease], [noOfDays]) " +
                        "VALUES(@prescriptionId, @drugName, @quantity, @drugType, @intakeTimeFrame, @disease, @noOfDays)";

                    // add named parameters
                    cmd.Parameters.AddRange(new SqlParameter[]
                    {
                        new SqlParameter("@prescriptionId", prescription.PrescriptionId),
                        new SqlParameter("@drugName", prescription.DrugName),
                        new SqlParameter("@quantity", prescription.Quantity),
                        new SqlParameter("@drugType", prescription.DrugType),
                        new SqlParameter("@intakeTimeFrame", prescription.IntakeTimeFrame),
                        new SqlParameter("@disease", prescription.Disease),
                        new SqlParameter("@noOfDays", prescription.NoOfDays),

                    });

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }

            return false;
        }
        
        public Prescription GetPrescriptionfromDatabase(int prescriptionId)
        {
            string jsonObject = String.Empty;
            var connString1 = new Connection();
            using (SqlConnection conn = new SqlConnection(connString1.connString))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from Prescriptions where prescriptionId='" + prescriptionId + "'", conn))
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    cmd.ExecuteScalar();
                    var reader = cmd.ExecuteReader();
                    
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    
                    jsonObject = JsonConvert.SerializeObject(dt);
                    jsonObject = jsonObject.Substring(1, jsonObject.Length - 2);
                    JObject.Parse(jsonObject);
                    var voila = JsonConvert.DeserializeObject<Prescription>(jsonObject);
                    return voila;
                }
            }
        }

        public List<Prescription> GetAllPrescriptions()
        {
            string jsonObject = String.Empty;
            string finalObject = string.Empty;
            var connString1 = new Connection();
            using (SqlConnection conn = new SqlConnection(connString1.connString))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from Prescriptions", conn))
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    cmd.ExecuteScalar();
                    var reader = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    //DataTable datatagble = new DataTable();
                    //DataRow[] datarow = datatagble.Select("Your string");
                    //DataTable dt1 = datarow.CopyToDataTable();
                    var dtr = new DataTable();

                    foreach (DataRow dr in dt.Rows)
                    {
                        dtr.ImportRow(dr);
                        jsonObject = JsonConvert.SerializeObject(dtr);
                        jsonObject = jsonObject.Substring(1, jsonObject.Length - 2);
                        JObject.Parse(jsonObject);
                        finalObject += jsonObject + ",";
                    }
                    
                    var voila = JsonConvert.DeserializeObject<List<Prescription>>(jsonObject);
                    return voila;
                }
            }
        }
    }
}