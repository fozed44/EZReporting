using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using EZReporting.Enumeration;

namespace tEZReporting.tWebServer {
    [TestClass]
    public class tSqlEnumerator {

        [TestMethod]
        public void tEnumerateDatabases() {
            var dbs = SqlEnumerator.EnumerateDatabases();
            Assert.IsTrue(dbs.Count() > 10);
        }

        [TestMethod]
        public void tEnumerateTables() {
            var tables = SqlEnumerator.EnumerateTables("OnlineRisk");
            Assert.IsTrue(tables.Count() > 10);
        }

        [TestMethod]
        public void tEnumerateStoredProcs() {
            var procs = SqlEnumerator.EnumerateStoredProcs("Elevate", "Authentication");
            Assert.IsTrue(procs.Count() > 5);
        }

        [TestMethod]
        public void tEnumerateSchemas() {
            var schemas = SqlEnumerator.EnumerateSchemas("Elevate");
            Assert.IsTrue(schemas.Contains("dbo"));
        }

        [TestMethod]
        public void tEnumerateProcedureInputs() {
            var inputs = SqlEnumerator.EnumerateStoredProcInputs("OnlineRisk", "dbo", "RiskReport");
            Assert.IsTrue(inputs.Count() > 2);
        }

        [TestMethod]
        public void tEnumerateProcedureOutputs() {
            var outputs = SqlEnumerator.EnumerateStoredProcOutputs("OnlineRisk", "dbo", "RiskReport");
            Assert.IsTrue(outputs.Count() > 2);
        }
    }
}
