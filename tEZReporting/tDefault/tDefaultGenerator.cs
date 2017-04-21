using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using EZReporting.Enumeration;
using EZReporting.Default;

namespace tEZReporting.tDefault {
    [TestClass]
    public class tDefaultGenerator {

        private string _tDatabase = "OnlineRisk";
        private string _tSchema = "dbo";
        private string _tProc = "RiskReport";
        private string _tReport = "__testReport";

        [TestInitialize]
        public void tInitialize() {
            EZReporting.Data.ReportDataController.Delete(_tReport);
            EZReporting.Data.ReportDataController.Create(new EZReporting.Data.Report {
                DatabaseName = _tDatabase,
                ProcName     = _tProc,
                SchemaName   = _tSchema,
                ReportName   = _tReport
            });
        }

        [TestCleanup]
        public void tCleanup() {
            EZReporting.Data.ReportDataController.Delete(_tReport);
        }

        [TestMethod]
        public void tGenerateDefaultParameters() {
            var defaults = DefaultsGenerator.GenerateDefaultParameters(_tReport);
            Assert.IsNotNull(defaults);
            Assert.IsTrue(defaults.Count() > 0);
        }

        [TestMethod]
        public void tGenerateDefaultOutputs() {
            var defaults = DefaultsGenerator.GenerateDefaultOutputColumns(_tReport);
            Assert.IsNotNull(defaults);
            Assert.IsTrue(defaults.Count() > 0);
        }

    }
}
