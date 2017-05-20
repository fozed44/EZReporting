using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using EZReporting.Enumeration;
using tEZReporting.Helpers;

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
            var tables = SqlEnumerator.EnumerateTables(TestMetadata.DatabaseName);
            Assert.IsTrue(tables.Count() > 10);
        }

        [TestMethod]
        public void tEnumerateStoredProcs() {
            var procs = SqlEnumerator.EnumerateStoredProcs(TestMetadata.DatabaseName, TestMetadata.SchemaName);
            Assert.IsTrue(procs.Count() > 5);
        }

        [TestMethod]
        public void tEnumerateSchemas() {
            var schemas = SqlEnumerator.EnumerateSchemas(TestMetadata.DatabaseName);
            Assert.IsTrue(schemas.Contains(TestMetadata.SchemaName));
        }

        [TestMethod]
        public void tEnumerateProcedureInputs() {
            var inputs = SqlEnumerator.EnumerateStoredProcInputs(
                TestMetadata.DatabaseName, 
                TestMetadata.SchemaName, 
                TestMetadata.ReportName);
            Assert.IsTrue(inputs.Count() > 2);
        }

        [TestMethod]
        public void tEnumerateProcedureOutputs() {
            var outputs = SqlEnumerator.EnumerateStoredProcOutputs(
                TestMetadata.DatabaseName,
                TestMetadata.SchemaName, 
                TestMetadata.ReportName);
            Assert.IsTrue(outputs.Count() > 2);
        }
    }
}
