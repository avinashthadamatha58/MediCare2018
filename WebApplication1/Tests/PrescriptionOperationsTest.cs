using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework.Internal;
using WebApplication1.Models;

namespace WebApplication1.Tests
{
    [TestFixture]
    public class PrescriptionOperationsTest
    {
        [Test]
       public void PrescriptionInsertIntoDatabaseTest()
        {
            var po = new PrescriptionOperations();
            var prescription = new Prescription()
            {
                PrescriptionId = 1,
                DrugName = "Crocin",
                DrugType = "Tablet",
                Quantity = 30,
                IntakeTimeFrame = "before Breakfast",
                NoOfDays = 7,
                Disease = "Fever"
            };
            //checking automation tests
            Assert.AreEqual(true, po.PrescriptionInsertIntoDatabase(prescription));
        }

        [Test]
        public void GetPrescriptionFromDatabaseTest()
        {
            var po = new PrescriptionOperations();
            Assert.AreEqual("", po.GetPrescriptionfromDatabase(1));
        }
        
        [Test]
        public void GetTest()
        {
            var po = new TestClass();
            Assert.AreEqual(true, po.testGetSql());
        }

        [Test]
        public void GetAllPrescriptionsTest()
        {
            var po = new PrescriptionOperations();
            Assert.AreEqual("", po.GetAllPrescriptions());
        }
    }
}