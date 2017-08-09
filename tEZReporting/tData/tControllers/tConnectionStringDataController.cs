using System.Linq;
using EZDataFramework.Framework;
using EZReporting.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tEZReporting.Helpers;

namespace tEZReporting.tControllers {
    [TestClass]
    public class tConnectionStringDataController {
        
        [TestMethod]
        public void tGet() {
            try {
                TestReportCreator.EnsureCreated();
                using(var disposerToken = new DataControllerBase.DisposerToken()) {
                    var testReport = ReportDataController.Get("TestReport");
                    var result = ConnectionStringDataController.Get(testReport.ConnectionString.pkID);
                    Assert.IsNotNull(result);
                }
            } finally {
                TestReportCreator.EnsureRemoved();
            }
        }

        [TestMethod]
        public void tGetAll() {
            try {
                TestReportCreator.EnsureCreated();
                using(var dp = new DataControllerBase.DisposerToken()) {
                    var result = ConnectionStringDataController.GetAll();
                    Assert.IsNotNull(result);
                    Assert.IsTrue(result.Count() > 0);
                }
            } finally {
                TestReportCreator.EnsureRemoved();
            }
        }

        [TestMethod]
        public void tAddDelete() {

            // CREATE
            ConnectionString newConnectionString;
            using(var dp = new DataControllerBase.DisposerToken()) {
                newConnectionString = ConnectionStringDataController.AddConnectionString(new ConnectionString {
                    Name  = "UnitTestName",
                    Value = "UnitTestValue"
                }); 
            }

            Assert.IsNotNull(newConnectionString, "Failed to create connection string.");
            Assert.IsTrue(newConnectionString.pkID > 0, "Failed to get a new ID from the new connection string");

            // DELETE
            using(var dp = new DataControllerBase.DisposerToken()) {
                ConnectionStringDataController.DeleteConnectionString(newConnectionString);
            }

            // ENSURE DELETETION
            using(var dp = new DataControllerBase.DisposerToken()) {
                var result = ConnectionStringDataController.Get(newConnectionString.pkID);
                Assert.IsNull(result);
            }
        }
    }
}
