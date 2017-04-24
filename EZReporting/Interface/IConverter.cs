
using System;

namespace EZReporting.Interface {

    /// <summary>
    //++ IConverter
    ///
    //+  Purpose:
    ///     Interface for an object that converts one datatype to another. Converters can be used
    ///     on a report column to convert the data for that column from one datatype to another.
    /// </summary>
    public interface IConverter {
        Type Source { get; }
        Type Target { get; }
        T Convert<S, T>(S source);
        object Convert(object source);
    }
}
