using EZDataFramework.Framework;
using System.Linq;
using System.Collections.Generic;

namespace EZReporting.Data {

    /// <summary>
    //++ ColumnDataController
    ///
    //+  Purpose:
    ///     Get column data for the columns in a particular report.
    /// </summary>
    public class ColumnDataController : DataControllerBase {

        #region Public

        /// <summary>
        /// Return an enumerable containing ReportColumn for each column in 'report'.
        /// </summary>
        /// <param name="report">
        /// Meta-data for the report for which report data will be returned.
        /// </param>
        /// <returns>
        /// An enumerable containing ReportColumn objects describing the meta-data for each
        /// column in the report.
        /// </returns>
        public static IEnumerable<ReportColumn> GetColumns(Report report) {            
            using(var context = new EZReportingEntities()) {
                return (from column in context.Columns
                        where column.fkReport == report.pkID
                        select column).ToList();
            }
        }

        #endregion

    }
}
