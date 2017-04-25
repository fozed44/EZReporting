using System;
using EZReporting.Interface;
using EZReporting.Location;

namespace EZReporting.Implementation {

    /// <summary>
    //++ DefaultFormatter
    ///
    //+  Purpose:
    ///     Default implementation of IFormatter.
    /// </summary>
    [ImplementationDescriptor(category: ImplementationCategory.Formatter, @interface: typeof(IFormatter))]
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
