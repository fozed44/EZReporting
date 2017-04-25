
using System;

namespace EZReporting.Interface {

    /// <summary>
    //++ IFormatter
    ///
    //+  Purpose:
    ///     An object that takes input data and returns that data formatted in a particular way.
    /// </summary>
    public interface IFormatter {
        Type DataType { get; }
        string Format(object input);
    }
}
