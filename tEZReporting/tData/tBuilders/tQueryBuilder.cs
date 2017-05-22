using System.Collections.Generic;
using EZDataFramework.Framework;
using EZReporting.Data.Builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tEZReporting.tData.tBuilders {

    [TestClass]
    public class tQueryBuilder {

        #region Fields

        private static Report _FakeReport_NoParams;
        private static Report _FakeReport_OneParam;
        private static Report _FakeReport_ThreeParams;

        #endregion

        #region Initialize

        [ClassInitialize]
        public static void tInit(TestContext context) {
            _FakeReport_NoParams = new Report {
                DatabaseName = "Database",
                SchemaName = "Schema",
                ProcName = "Proc",
                Parameters = new List<ReportParameter>()
            };

            _FakeReport_OneParam = new Report {
                DatabaseName = "Database",
                SchemaName = "Schema",
                ProcName = "Proc",
                Parameters = new List<ReportParameter> {
                    new ReportParameter {
                        ParameterName = "Param1"
                    }
                }
            };

            _FakeReport_ThreeParams = new Report {
                DatabaseName = "Database",
                SchemaName = "Schema",
                ProcName = "Proc",
                Parameters = new List<ReportParameter> {
                    new ReportParameter { ParameterName = "Param1" },
                    new ReportParameter { ParameterName = "Param2" },
                    new ReportParameter { ParameterName = "Param3" }
                }
            };
            
        }

        #endregion

        [TestMethod]
        public void tBuildQuery_ProcHasNoParams() {
            var queryBuilder = new QueryBuilder(_FakeReport_NoParams);
            var query = queryBuilder.BuildQuery(null);
            Assert.AreEqual("EXEC Database.Schema.Proc", query);
        }

        [TestMethod]
        public void tBuildQuery_ProcHasOneParam() {
            var queryBuilder = new QueryBuilder(_FakeReport_OneParam);
            var query = queryBuilder.BuildQuery(
                new Dictionary<string, string> {
                    { "Param1", "Param1Value" }
                }
            );
            Assert.AreEqual("EXEC Database.Schema.Proc @Param1 = 'Param1Value'", query);
        }

        [TestMethod]
        public void tBuildQuery_ProcHasThreeParams() {
            var queryBuilder = new QueryBuilder(_FakeReport_ThreeParams);
            var query = queryBuilder.BuildQuery( 
                new Dictionary<string, string> {
                    { "Param1", "Param1Value" },
                    { "Param2", "Param2Value" },
                    { "Param3", "Param3Value" }
                }
            );
            Assert.AreEqual(
                "EXEC Database.Schema.Proc @Param1 = 'Param1Value', @Param2 = 'Param2Value', @Param3 = 'Param3Value'", 
                query
            );
        }
    }
}
