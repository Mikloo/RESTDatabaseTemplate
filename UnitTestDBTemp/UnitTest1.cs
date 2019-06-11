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

            Assert.AreEqual(3, resultat.Count());
        }
    }
}
