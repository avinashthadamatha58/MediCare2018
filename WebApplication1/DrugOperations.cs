using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApplication1.AppData;
using WebApplication1.Models;

namespace WebApplication1
{
    public class DrugOperations
    {
        public bool DrugInsertIntoDatabase(Drug drug)
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
                        "INSERT INTO Drugs " +
                        "([drugId], [drugName],  [availableNumber], [drugType], [commonInTake]) " +
                        "VALUES(@drugId, @drugName, @availableNumber, @drugType, @commonInTake)";

                    // add named parameters
                    cmd.Parameters.AddRange(new SqlParameter[]
                    {
                        new SqlParameter("@drugId", drug.DrugId),
                        new SqlParameter("@drugName", drug.DrugName),
                        new SqlParameter("@availableNumber", drug.AvailableNumber),
                        new SqlParameter("@drugType", drug.DrugType),
                        new SqlParameter("@commonInTake", drug.CommonIntake),

                    });

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }

            return false;
        }

        public Drug GetDrugfromDatabase(int drugId)
        {
            string jsonObject = String.Empty;
            var connString1 = new Connection();
            using (SqlConnection conn = new SqlConnection(connString1.connString))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from Drugs where drugId='" + drugId + "'", conn))
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
                    var voila = JsonConvert.DeserializeObject<Drug>(jsonObject);
                    return voila;
                }
            }
        }

        public List<Drug> GetAllDrugs()
        {
            string jsonObject = String.Empty;
            string finalObject = string.Empty;
            var connString1 = new Connection();
            using (SqlConnection conn = new SqlConnection(connString1.connString))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from Drugs", conn))
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

                    var voila = new List<Drug>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        var dtr = new DataTable();
                        dtr = dr.Table.Clone();
                        dtr.ImportRow(dr);
                        jsonObject = JsonConvert.SerializeObject(dtr);
                        jsonObject = jsonObject.Substring(1, jsonObject.Length - 2);
                        JObject.Parse(jsonObject);
                        //finalObject += jsonObject + ",";
                        voila.Add(JsonConvert.DeserializeObject<Drug>(jsonObject));
                    }

                    return voila;
                }
            }
        }
    }
}