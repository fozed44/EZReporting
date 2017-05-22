
using System;
using System.Collections.Generic;
using EZDataFramework.Framework;

namespace EZReporting.Interface {

    /// <summary>
    //++ IDataProvider
    ///
    //+  Purpose:
    ///     An object that implements the IDataProvider interface provides the Row/Column data and
    ///     data for each individual cell.
    /// </summary>
    public interface IDataProvider {
        int RowCount    { get; }
        int ColumnCount { get; }

        void   Load(Report report, Dictionary<string, string> @params);
        Type   GetColumnType(int column);
        object GetCell(int row, int column);
    }
}
