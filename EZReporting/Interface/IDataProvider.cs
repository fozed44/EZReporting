
using System;

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
        Type GetColumnType(int column);
        object GetCell(int row, int column);
    }
}
