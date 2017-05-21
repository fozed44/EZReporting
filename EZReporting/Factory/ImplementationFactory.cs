using System;
using System.Collections.Generic;
using System.Linq;
using EZDataFramework.Framework;
using EZReporting.Data;
using EZReporting.Enumeration;
using EZReporting.Implementation;
using EZReporting.Interface;
using EZReporting.Location;

namespace EZReporting.Factory {

    /// <summary>
    //++ ImplementationFactory
    ///
    //+  Purpose:
    ///     Generates a complete rendered that can render a particular report.
    /// </summary>
    public static class ImplementationFactory {

        #region Public
        
        public static IDataProvider GetDataProvider(Report report) {
            if(string.IsNullOrEmpty(report.Renderer)
            || report.Renderer == "DefaultRenderer") {
                return Activator.CreateInstance<DefaultDataProvider>();
            }
            throw new ArgumentException(
                $"No data provider for a renderer of type {report.Renderer} could be created (Report ID: {report.pkID})."
            );
        }

        public static IRenderer GetRenderer(Report report) {
            return ImplementationEnumerator.Locate<IRenderer>(report.Renderer);
        }

        public static IFormatter GetFormatter(Report report, int columnIndex) {
            var columns = ColumnDataController.GetColumns(report);
            return GetFormatterForColumn(columns, columnIndex);
        }

        public static IEnumerable<IFormatter> GetFormatters(Report report) {
            return ColumnDataController
                    .GetColumns(report)
                    .Select(x => ImplementationEnumerator.Locate<IFormatter>(x.Formatter));
        }

        public static IConverter GetConverter(Report report, int columnIndex) {
            var columns = ColumnDataController.GetColumns(report);
            return GetConverterForColumn(columns, columnIndex);
        }

        public static IEnumerable<IConverter> GetConverters(Report report) {
            return ColumnDataController
                    .GetColumns(report)
                    .Select(x => ImplementationEnumerator.Locate<IConverter>(x.Converter));
        }

        #endregion

        #region Private

        private static IFormatter GetFormatterForColumn(IEnumerable<ReportColumn> columns, int columnIndex) {
            if(columnIndex < 0 || columnIndex >= columns.Count())
                throw new ArgumentException($"columnIndex ({columnIndex}) is out of range.");
            var column = columns.ElementAt(columnIndex);
            return ImplementationEnumerator.Locate<IFormatter>(column.Formatter);
        }

        private static IConverter GetConverterForColumn(IEnumerable<ReportColumn> columns, int columnIndex) {
            if(columnIndex < 0 || columnIndex >= columns.Count())
                throw new ArgumentException($"columnIndex ({columnIndex}) is out of range.");
            var column = columns.ElementAt(columnIndex);
            return ImplementationEnumerator.Locate<IConverter>(column.Converter);
        }

        private static ReportColumnCustomization GetCustomization(ReportColumn forColumn) {
            using(var context = new EZDataFramework.Framework.EZReportingEntities()) {
                var columnCustomization = (from entity in context.ColumnCustomizations
                                           where entity.fkReportColumn == forColumn.pkID
                                           select entity).FirstOrDefault();
                if(columnCustomization == null) return null;
                return columnCustomization;
            }
        }        

        #endregion

    }
}
