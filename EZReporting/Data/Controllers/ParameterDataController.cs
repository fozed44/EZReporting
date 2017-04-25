﻿using System.Collections.Generic;
using DataFramework.Framework;
using System.Linq;

namespace EZReporting.Data {

    /// <summary>
    //++ ParameterDataController
    ///
    //+  Purpose:
    ///     Retrieve and store parameter data in EZReporting.dbo.ReportParameter.
    /// </summary>
    public static class ParameterDataController {

        /// <summary>
        /// Enumerate EZReporting.Data.ReportParameter objects for each parameter in the specified
        /// report.
        /// </summary>
        /// <param name="report">
        /// The report for which the parameter data should be retrieved.
        /// </param>
        /// <returns>
        /// An enumeration containing the parameter data for the specified report.
        /// </returns>
        public static IEnumerable<ReportParameter> GetParameters(Report report) {
            using(var context = new EZReportingEntities()) {
                return (from entity in context.ReportParameters
                        where entity.fkReport == report.pkID
                        select entity).ToList().Select(x => new ReportParameter(x));
            }
        }

    }
}
