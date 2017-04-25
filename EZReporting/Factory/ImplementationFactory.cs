
using System;
using System.Collections.Generic;
using EZReporting.Data;
using EZReporting.Enumeration;
using EZReporting.Implementation;
using EZReporting.Interface;

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
            if(string.IsNullOrEmpty(report.Renderer)
            || report.Renderer == "DefaultRenderer") {
                return Activator.CreateInstance<DefaultRenderer>();
            }
            throw new ArgumentException(
               $"No renderer of type {report.Renderer} could be created (Report ID: {report.pkID})."
            );
        }

        public static IFormatter GetFormatter(Report report, int columnIndex) {
            return (IFormatter)Activator.CreateInstance(GetFormatterForColumn(report, columnIndex));
        }

        public static IEnumerable<IFormatter> GetFormatters(Report report) {
            var columns = ColumnDataController.GetColumns(report);
            var result  = new List<IFormatter>();
            foreach(var column in columns) {
                column.
            }
        }

        public static IConverter GetConverter(Report report, int columnIndex) {
            return (IConverter)Activator.CreateInstance(GetConverterForColumn(report, columnIndex));
        }

        public static IEnumerable<IConverter> GetConverters(Report report) {

        }

        #endregion

        #region Private

        private static Type GetFormatterForColumn(Report report, int columnIndex) {

        }

        private static Type GetConverterForColumn(Report report, int columnIndex) {

        }

        #endregion
    }
}
