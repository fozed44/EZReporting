using System.Collections.Generic;
using System.Linq;
using DataFramework.Framework;
using EZReporting.Enumeration;

namespace EZReporting.Data {

    /// <summary>
    //++ ReportDataController
    ///
    //+  Purpose:
    ///     Methods used to CRUD report objects in EZReporting.dbo.Database
    /// </summary>
    public static class ReportDataController {

        #region Public

        /// <summary>
        /// Test database.schema.procedure to see if a matching record exists.
        /// </summary>
        /// <param name="database">The name of the database.</param>
        /// <param name="schema">The name of the schema</param>
        /// <param name="procedure">The name of the procedure</param>
        /// <returns>
        /// True if datavase.schema.procedure exists, false otherwise.
        /// </returns>
        public static bool Exists(string database, string schema, string procedure) {
            using(var context = new EZReportingEntities()) {
                var current = from entity in context.Reports
                              where entity.DatabaseName == database
                                 && entity.SchemaName   == schema
                                 && entity.ProcName     == procedure
                              select entity;
                return current.Count() > 0;
            }
        }

        /// <summary>
        /// Search the Reports table for a record with a ReportName field of 'reportName'
        /// </summary>
        /// <param name="reportName">The name of the report to search for.</param>
        /// <returns>
        /// True if a record exists for the given reportName, otherwise, false.
        /// </returns>
        public static bool Exists(string reportName) {
            using(var context = new EZReportingEntities()) {
                var current = from entity in context.Reports
                              where entity.ReportName == reportName
                              select entity;
                return current.Count() > 0;
            }
        }

        /// <summary>
        /// Create a new report.
        /// </summary>
        /// <param name="report">
        /// The report object filled with the report meta data.
        /// </param>
        public static void Create(Report report) {
            using(var context = new EZReportingEntities()) {
                context.Reports.Add(report.ToFramework());
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes the report with 'reportName'.
        /// </summary>
        /// <param name="reportName">
        /// The name of the report to delete.
        /// </param>
        public static void Delete(string reportName) {
            using(var context = new EZReportingEntities()) {
                var current = (from entity in context.Reports
                               where entity.ReportName == reportName
                               select entity).FirstOrDefault();
                if(current == null)
                    return;
                context.Reports.Remove(current);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Retrieve a Report object for a report with the name of 'reportName'.
        /// </summary>
        /// <param name="reportName">The name of the report to get.</param>
        /// <returns>
        /// If a report exists with the given name, the method return a Report object containing the
        /// meta data of the report. Otherwise the method returns false.
        /// </returns>
        public static Report Get(string reportName) {
            using(var context = new EZReportingEntities()) {
                var current = (from entity in context.Reports
                               where entity.ReportName == reportName
                               select entity).FirstOrDefault();

                if(current == null)
                    return null;

                return new Report(current);
            }
        }

        /// <summary>
        /// Retrieves an enumerable of all of the reports in EZReporting.dbo.Report.
        /// </summary>
        /// <returns>
        /// An IEnumeralbe of all of the reports in EZreporting.dbo.Report.
        /// </returns>
        public static IEnumerable<Report> GetAll() {
            List<DataFramework.Framework.Report> result;
            using(var context = new EZReportingEntities()) {
                result = (from entity in context.Reports
                              select entity).ToList();
            }
            foreach(var convert in result.Select(x => new Report(x)))
                yield return convert;
        }

        #endregion

        #region Private

            #region Insert

        /// <summary>
        /// Inserts default parameter data into EZReporting.dbo.ReportParameter.
        /// </summary>
        private static void InsertDefaultInputData(EZReportingEntities context, Report report) {
            var defaults = SqlEnumerator.EnumerateStoredProcInputs(report.DatabaseName, report.SchemaName, report.ProcName);
            foreach(var input in defaults) {
                context.ReportParameters.Add(new DataFramework.Framework.ReportParameter {
                    fkReport      = report.pkID,
                    ParameterName = input.Name,
                    DisplayName   = input.Name,
                    DBType        = input.DataType,
                    Flags         = 0
                });
            }
            context.SaveChanges();
        }

        /// <summary>
        /// Insert default output column data into EZReporting.dbo.ReportOutputColumn.
        /// </summary>
        private static void InsertDefaultOutputData(EZReportingEntities context, Report report) {
            var defaults = SqlEnumerator.EnumerateStoredProcOutputs(report.DatabaseName, report.SchemaName, report.ProcName);
            foreach(var column in defaults) {
                context.ReportOutputColumns.Add(new DataFramework.Framework.ReportOutputColumn {
                    fkReport   = report.pkID,
                    ColumnName = column.Name,
                    DBType     = column.Type,
                    Flags      = 0
                });
            }
            context.SaveChanges();
        }

            #endregion

            #region Delete

        private static void DeleteColumnData(EZReportingEntities context, Report report) {
            var toDelete = context.ReportOutputColumns.Where(x => x.fkReport == report.pkID);
            context.ReportOutputColumns.RemoveRange(toDelete);
        }

        private static void DeleteInputData(EZReportingEntities context, Report report) {
            var toDelete = context.ReportParameters.Where(x => x.fkReport == report.pkID);
            context.ReportParameters.RemoveRange(toDelete);
        }

        private static void DeleteCustomColumnData(EZReportingEntities context, Report report) {
            var toDelete = context.ReportOutputColumnCustomizations.Where(x => x.fkColumn)
        }

            #endregion

        #endregion

    }
}
