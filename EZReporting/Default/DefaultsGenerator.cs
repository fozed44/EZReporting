using System;
using System.Collections.Generic;
using System.Linq;
using EZReporting.Data;
using EZReporting.Enumeration;

namespace EZReporting.Default {

    public static class DefaultsGenerator {

        public static IEnumerable<ReportParameter> GenerateDefaultParameters(string reportName) {
            var metaData = ReportDataController.Get(reportName);

            if(metaData == null)
                throw new ArgumentException($"Data for the report '{reportName}' could not be found.");

            var @params = SqlEnumerator.EnumerateStoredProcInputs(
                            metaData.DatabaseName,
                            metaData.SchemaName,
                            metaData.ProcName
                          );

            if(@params == null)
                throw new ArgumentException($"Parameter data for the report '{reportName}' could not be found.");

            return @params.Select(x => new Data.ReportParameter {
                ParameterName = x.Name,
                DisplayName   = x.Name,
                DBType        = x.DataType,
                fkReport      = metaData.pkID,
                Flags         = 0
            });
        }

        public static IEnumerable<ReportOutputColumn> GenerateDefaultOutputColumns(string reportName) {
            var metaData = ReportDataController.Get(reportName);

            if(metaData == null)
                throw new ArgumentException($"Data for the report '{reportName}' could not be found.");

            var outputs = SqlEnumerator.EnumerateStoredProcOutputs(
                                metaData.DatabaseName,
                                metaData.SchemaName,
                                metaData.ProcName
                          );

            if(outputs == null)
                throw new ArgumentException($"Output column data for the report '{reportName}' could not be found.");

            return outputs.Select(x => new ReportOutputColumn {
                ColumnName = x.Name,
                DBType     = x.Type,
                fkReport   = metaData.pkID,
                Flags      = 0
            });
        }
    }
}
