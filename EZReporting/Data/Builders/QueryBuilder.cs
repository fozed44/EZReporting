using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using EZDataFramework.Framework;
using Verification;

namespace EZReporting.Data.Builders {

    /// <summary>
    //++ QueryBuilder
    ///
    //+  Purpose:
    ///     A simple query string builder that produces a query to retrieve the results of a report
    ///     given a Report object containing the database, schema, and procedure and a dictionary
    ///     of parameters and parameter values that correspond to the parameters in the given report.
    /// </summary>
    public class QueryBuilder {

        #region Fields

        private Report _report;

        #endregion

        #region Public

        public QueryBuilder(Report report) {
            _report = report;
        }

        public string BuildQuery(Dictionary<string, string> @params) {
            var paramString = @params == null ? "" : BuildParamString(@params);
            return $"EXEC {_report.DatabaseName}.{_report.SchemaName}.{_report.ProcName}" + paramString;
        }

        #endregion

        #region Private

        private string BuildParamString(Dictionary<string, string> @params) {
            VerifyParams(@params);
            StringBuilder sb = new StringBuilder();
            foreach(var param in @params) {
                sb.Append($" @{param.Key} = '{param.Value}',");
            }
            return sb.ToString().TrimEnd(',');
        }

        /// <summary>
        /// Verify that each parameter in the report is represented in the input dictionary and that
        /// each parameter in the input dictionary is an actual report parameter.
        /// </summary>
        /// <param name="params"></param>
        [Conditional("DEBUG")]
        private void VerifyParams(Dictionary<string, string> @params) {
            foreach(var param in _report.Parameters) {
                Verify.True(
                    @params.Keys.Contains(param.ParameterName),
                    $"The parameters passed to the QueryStringBuilder do not contain parameter information " +
                    $"for a required parameter ({param.ParameterName})."
                );
            }
            foreach(var param in @params) { 
                Verify.True(
                    _report.Parameters.Select(x => x.ParameterName).Contains(param.Key),
                    $"The parameters passed to the QueryStringBuilder contains a parameter that is not an " +
                    $"actual report parameter ({param.Key})."
                );
            }
        }

        #endregion
    }
}
