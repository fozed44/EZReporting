using DataFramework.Framework;
using System.Linq;
using System.Collections.Generic;

namespace EZReporting.Data {

    /// <summary>
    //++ ColumnDataController
    ///
    //+  Purpose:
    ///     Get column data for the columns in a particular report.
    /// </summary>
    public static class ColumnDataController {

        #region Public

        /// <summary>
        /// Return an enumerable containing ReportOutputColumn for each column in 'report'.
        /// </summary>
        /// <param name="report">
        /// Meta-data for the report for which report data will be returned.
        /// </param>
        /// <returns>
        /// An enumerable containing ReportOutputColumn objects describing the meta-data for each
        /// column in the report.
        /// </returns>
        public static IEnumerable<ReportOutputColumn> GetColumns(Report report) {            
            using(var context = new EZReportingEntities()) {
                return (from column in context.ReportOutputColumns
                        where column.fkReport == report.pkID
                        select column).ToList().Select(x => new EZReporting.Data.ReportOutputColumn(x));
            }
        }

        #endregion

    }
}
