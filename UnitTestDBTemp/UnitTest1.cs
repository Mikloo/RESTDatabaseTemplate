using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RESTDatabaseTemplate;
using RESTDatabaseTemplate.Controllers;

namespace UnitTestDBTemp
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DBTempsController dbTemps = new DBTempsController();

            var resultat = dbTemps.GetDBTempById(1).Id;
            
            Assert.AreEqual(1, resultat);
        }

        [TestMethod]
        public void TestMethod11()
        {
            DBTempsController dbTemps = new DBTempsController();

            var resultat = dbTemps.GetAllTemp();

            Assert.AreEqual(2, resultat.Count());
        }

        [TestMethod]
        public void addd()
        {
            DBTempsController dbTemps = new DBTempsController();

            DBTemp me = new DBTemp("Mikailll", "LLLLLLL");

            var resultat = dbTemps.AddDBTemp(me);

            var resultat1 = dbTemps.GetAllTemp();

            Assert.AreEqual(3, resultat1.Count());

        }

        [TestMethod]
        public void put()
        {
            DBTempsController dbTemps = new DBTempsController();

            DBTemp me = new DBTemp("Greek", "Godx");

            var resultat = dbTemps.UpdateDBTemp(4, me);

            var resultat3 = dbTemps.GetDBTempById(4).LastName;

            Assert.AreEqual("Godx", resultat3);

        }
    }
}
