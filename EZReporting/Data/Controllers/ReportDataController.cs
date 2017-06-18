using System.Collections.Generic;
using System.Linq;
using EZDataFramework.Framework;
using EZReporting.Enumeration;

namespace EZReporting.Data {

    /// <summary>
    //++ ReportDataController
    ///
    //+  Purpose:
    ///     Methods used to CRUD report objects in EZReporting.dbo.Database
    /// </summary>
    public class ReportDataController : DataControllerBase {

        #region Public

        /// <summary>
        /// Search the Reports table for a record with a ReportName field of 'reportName'
        /// </summary>
        /// <param name="reportName">The name of the report to search for.</param>
        /// <returns>
        /// True if a record exists for the given reportName, otherwise, false.
        /// </returns>
        public static bool Exists(string reportName) {
            var current = from entity in Context.Reports
                          where entity.ReportName == reportName
                          select entity;
            return current.Count() > 0;
        }

        /// <summary>
        /// Create a new report.
        /// </summary>
        /// <param name="report">
        /// The report object filled with the report meta data.
        /// </param>
        public static Report Create(Report report) {
            Context.Reports.Add(report);
            InsertDefaultInputData(Context, report);
            InsertDefaultOutputData(Context, report);
            Context.SaveChanges();
            return report;
        }

        /// <summary>
        /// Deletes the report with 'reportName'. All column and parameter data is also deleted.
        /// </summary>
        /// <param name="reportName">
        /// The name of the report to delete.
        /// </param>
        public static void Delete(string reportName) {
            var current = (from entity in Context.Reports
                            where entity.ReportName == reportName
                            select entity).FirstOrDefault();
            if(current == null)
                return;
            DeleteCustomColumnData(current);
            DeleteColumnData(current);
            DeleteInputData(current);
            Context.Reports.Remove(current);
            Context.SaveChanges();
        }

        /// <summary>
        /// Deletes the report. All column and parameter data is also deleted.
        /// </summary>
        /// <param name="report">
        /// The report to be deleted.
        /// </param>
        public static void Delete(Report report) {
            DeleteCustomColumnData(report);
            DeleteColumnData(report);
            DeleteInputData(report);
            Context.Reports.Attach(report);
            Context.Reports.Remove(report);
            Context.SaveChanges();
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
            var current = (from entity in Context.Reports
                            where entity.ReportName == reportName
                            select entity).FirstOrDefault();

            if(current == null)
                return null;

            return current;
        }

        /// <summary>
        /// Retrieves an enumerable of all of the reports in EZReporting.dbo.Report.
        /// </summary>
        /// <returns>
        /// An IEnumeralbe of all of the reports in EZreporting.dbo.Report.
        /// </returns>
        public static IEnumerable<Report> GetAll() {
            return (from entity in Context.Reports
                    select entity).ToList();
        }

        #endregion

        #region Private

            #region Insert

        /// <summary>
        /// Inserts default parameter data into EZReporting.dbo.ReportParameter.
        /// </summary>
        private static void InsertDefaultInputData(EZReportingEntities Context, Report report) {
            var defaults = SqlEnumerator.EnumerateStoredProcInputs(report.DatabaseName, report.SchemaName, report.ProcName);
            foreach(var input in defaults) {
                Context.Parameters.Add(new EZDataFramework.Framework.ReportParameter {
                    fkReport      = report.pkID,
                    ParameterName = input.Name,
                    DisplayName   = input.Name,
                    DBType        = input.DataType,
                    Flags         = 0
                });
            }
        }

        /// <summary>
        /// Insert default output column data into EZReporting.dbo.ReportColumn.
        /// </summary>
        private static void InsertDefaultOutputData(EZReportingEntities Context, EZDataFramework.Framework.Report report) {
            var defaults = SqlEnumerator.EnumerateStoredProcOutputs(report.DatabaseName, report.SchemaName, report.ProcName);
            foreach(var column in defaults) {
                Context.Columns.Add(new EZDataFramework.Framework.ReportColumn {
                    fkReport   = report.pkID,
                    ColumnName = column.Name,
                    fkAlignment  = AlignmentDataController.GetAlignment("none").First().pkID,
                    Formatter  = null,
                    Converter  = null,
                    DBType     = column.Type
                });
            }
        }

            #endregion

            #region Delete

        /// <summary>
        /// Remove all column data from EZReporting.dbo.ReportColumn for the specified report.
        /// </summary>
        private static void DeleteColumnData(Report report) {
            var toDelete = Context.Columns.Where(x => x.fkReport == report.pkID);
            Context.Columns.RemoveRange(toDelete);
        }

        /// <summary>
        /// Remove all parameter data from EZReporting.dbo.Parameter for the specified report.
        /// </summary>
        private static void DeleteInputData(Report report) {
            var toDelete = Context.Parameters.Where(x => x.fkReport == report.pkID);
            Context.Parameters.RemoveRange(toDelete);
        }

        /// <summary>
        /// Remove all column customizations from EZReporting.dbo.ReportColumnCustomization
        /// for the specified report.
        /// </summary>
        private static void DeleteCustomColumnData(Report report) {
            var columns = Context.Columns.Where(x => x.fkReport == report.pkID);
            var toDelete = new List<EZDataFramework.Framework.ReportColumnCustomization>();
            foreach(var column in columns) {
                var customizations = 
                    Context.ColumnCustomizations.Where(x => x.fkReportColumn == column.pkID)
                    .ToList();
                if(customizations.Count != 0)
                    toDelete.AddRange(customizations);
            }
            if(toDelete.Count > 0)
                Context.ColumnCustomizations.RemoveRange(toDelete);
        }

            #endregion

        #endregion

    }
}
