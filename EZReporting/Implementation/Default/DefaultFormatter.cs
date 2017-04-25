
using System;
using EZReporting.Interface;

namespace EZReporting.Implementation {

    /// <summary>
    //++ DefaultFormatter
    ///
    //+  Purpose:
    ///     Default implementation of IFormatter.
    /// </summary>
    public class DefaultFormatter : IFormatter {

        #region IFormatter

        public Type DataType {
            get {
                throw new NotImplementedException();
            }
        }

        string IFormatter.Format(object input) {
            return input.ToString();
        }


        #endregion
    }
}
