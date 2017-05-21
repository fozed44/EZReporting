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
            Assert.IsTrue(dbs.Count() > 0);
        }

        [TestMethod]
        public void tEnumerateTables() {
            var tables = SqlEnumerator.EnumerateTables(TestMetadata.DatabaseName);
            Assert.IsTrue(tables.Count() > 0);
        }

        [TestMethod]
        public void tEnumerateStoredProcs() {
            var procs = SqlEnumerator.EnumerateStoredProcs(TestMetadata.DatabaseName, TestMetadata.SchemaName);
            Assert.IsTrue(procs.Count() > 0);
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
                TestMetadata.ProcName);
            Assert.IsTrue(inputs.Count() > 0);
        }

        /// <summary>
        /// Test SqlEnumerate.EnumerateStoredProcInputs, make sure that all required parameter data
        /// is enumerated.
        /// </summary>
        [TestMethod]
        public void tCheckEnumeratedProcProperties() {
            var inputs = SqlEnumerator.EnumerateStoredProcInputs(
                TestMetadata.DatabaseName, 
                TestMetadata.SchemaName, 
                TestMetadata.ProcName);
            foreach(var input in inputs) {
                Assert.IsTrue(!string.IsNullOrEmpty(input.DataType));
                Assert.IsTrue(!string.IsNullOrEmpty(input.Name));
            }
        }

        [TestMethod]
        public void tEnumerateProcedureOutputs() {
            var outputs = SqlEnumerator.EnumerateStoredProcOutputs(
                TestMetadata.DatabaseName,
                TestMetadata.SchemaName, 
                TestMetadata.ProcName);
            Assert.IsTrue(outputs.Count() > 0);
        }

        [TestMethod]
        public void tCheckEnumeratedProcOutputs() {
            var outputs = SqlEnumerator.EnumerateStoredProcOutputs(
                TestMetadata.DatabaseName,
                TestMetadata.SchemaName,
                TestMetadata.ProcName);
            foreach(var output in outputs) {
                Assert.IsTrue(!string.IsNullOrEmpty(output.Name));
                Assert.IsTrue(!string.IsNullOrEmpty(output.Type));
            }
        }
    }
}
