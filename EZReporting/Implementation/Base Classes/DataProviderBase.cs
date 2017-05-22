
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EZDataFramework.Framework;
using EZReporting.Data.Builders;
using EZReporting.Interface;
using Verification;

namespace EZReporting.Implementation.Base_Classes {

    /// <summary>
    //++ DataProviderBase
    ///
    //+  Purpose:
    ///     Base implementation of IDataProvider.
    /// </summary>
    public class DataProviderBase : IDataProvider {

        #region Fields

        private Report    _report;
        private DataTable _dataTable;

        #endregion

        #region IDataProvider

        public int ColumnCount => _dataTable?.Columns.Count ?? 0;
        public int RowCount    => _dataTable?.Rows.Count    ?? 0;

        public object GetCell(int row, int column) {
            Verify.NotNull<InvalidOperationException>(_dataTable, "No data has been loaded!");
            return _dataTable.Rows[row].Field<object>(column);
        }

        public Type GetColumnType(int column) {
            Verify.NotNull<InvalidOperationException>(_dataTable, "No data has been loaded!");
            Verify.True<InvalidOperationException>(_dataTable.Rows.Count > 0, "Data must be loaded to determine column type!");
            return _dataTable.Columns[column].DataType;
        }

        public void Load(Report report, Dictionary<string, string> @params) {
            _report = report;
            string query = OnGetQuery(_report, @params);
            LoadInternal(query);
        }

        #endregion

        #region Virtual Methods

        protected string OnGetQuery(Report report, Dictionary<string, string> @params) {
            return new QueryBuilder(_report).BuildQuery(@params);
        }

        #endregion

        #region Private

        private void LoadInternal(string query) {
            using(SqlConnection conn = new SqlConnection(_report.ConnectionString.Value))
            using(SqlCommand command = new SqlCommand(query, conn)) {
                conn.Open();
                _dataTable = new DataTable();
                _dataTable.Load(command.ExecuteReader());
            }
        }

        #endregion

    }
}
