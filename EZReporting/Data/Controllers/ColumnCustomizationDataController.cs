using System.Collections.Generic;
using System.Linq;
using DataFramework.Framework;

namespace EZReporting.Data {

    /// <summary>
    //++ ColumnCustomizationDataController
    ///
    //+  Purpose:
    ///     Enumerates column customization data for each column in a particular report.
    /// </summary>
    public static class ColumnCustomizationDataController {

        public static IEnumerable<ReportOutputColumnCustomization> GetColumns(Report report) {
            using(var context = new EZReportingEntities()) {
                return (from column in context.ReportOutputColumns
                        join columnCustomization in context.ReportOutputColumnCustomizations
                        on column.pkID equals columnCustomization.fkColumn
                        where column.fkReport == report.pkID
                        select columnCustomization).Select(x => new EZReporting.Data.ReportOutputColumnCustomization(x));
            }
        }

    }
}
