
using System;
using EZReporting.Interface;

namespace EZReporting.Implementation {

    /// <summary>
    //++ DefaultDataProvider
    ///
    //+  Purpose:
    ///     The DefaultDataProvider is the default implementation of IDataProvider.
    /// </summary>
    public class DefaultDataProvider : IDataProvider {

        #region IDataProvider

        public int ColumnCount {
            get {
                throw new NotImplementedException();
            }
        }

        public int RowCount {
            get {
                throw new NotImplementedException();
            }
        }

        public object GetCell(int row, int column) {
            throw new NotImplementedException();
        }

        public Type GetColumnType(int column) {
            throw new NotImplementedException();
        }

        #endregion
    }
}
