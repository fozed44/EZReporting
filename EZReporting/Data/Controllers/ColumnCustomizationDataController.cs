using System.Collections.Generic;
using System.Linq;
using EZDataFramework.Framework;

namespace EZReporting.Data {

    /// <summary>
    //++ ColumnCustomizationDataController
    ///
    //+  Purpose:
    ///     Enumerates column customization data for each column in a particular report.
    /// </summary>
    public class ColumnCustomizationDataController : DataControllerBase {

        private ColumnCustomizationDataController() { }

        public static List<ReportColumnCustomization> GetColumns(Report report) {
            using(var context = new EZReportingEntities()) {
                return (from column in context.Columns
                        join columnCustomization in context.ColumnCustomizations
                        on column.pkID equals columnCustomization.fkReportColumn
                        where column.fkReport == report.pkID
                        select columnCustomization).ToList();
            }
        }

    }
}
