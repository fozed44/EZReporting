using System;
using EZReporting.Interface;
using EZReporting.Location;

namespace EZReporting.Implementation {

    /// <summary>
    //++ DefaultDataProvider
    ///
    //+  Purpose:
    ///     The DefaultDataProvider is the default implementation of IDataProvider.
    /// </summary>
    [ImplementationDescriptor(category: ImplementationCategory.DataProvider, @interface: typeof(IDataProvider))]
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
