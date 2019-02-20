using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using WebApplication1.Models;

namespace WebApplication1.Tests
{
    [TestFixture]
    public class DrugOperationsTest
    {
        [Test]
        public void DrugInsertIntoDatabaseTest()
        {
            var po = new DrugOperations();
            var drug = new Drug()
            {
                DrugId = 2,
                DrugName = "Amoxylin",
                DrugType = "Antibiotic",
                AvailableNumber = 30,
                CommonIntake = "High Fever",
            };
            //test CI
            Assert.AreEqual(true, po.DrugInsertIntoDatabase(drug));
        }

        [Test]
        public void GetDrugfromDatabaseTest()
        {
            var po = new DrugOperations();
            Assert.NotNull(po.GetDrugfromDatabase(1));
        }

        [Test]
        public void GetAllDrugsTest()
        {
            var po = new DrugOperations();
            Assert.NotNull(po.GetAllDrugs());
        }
    }
}