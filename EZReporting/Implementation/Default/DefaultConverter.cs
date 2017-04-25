using System;
using EZReporting.Interface;
using EZReporting.Location;

namespace EZReporting.Implementation {

    /// <summary>
    //++ DefaultConverter
    /// 
    //+  Purpose:
    ///     Default IConverter implementation. Does no actual conversion. (Converts object to object).
    /// </summary>
    [ImplementationDescriptor(category: ImplementationCategory.Converter, @interface: typeof(IConverter))]
    public class DefaultConverter : IConverter {
        public Type Source {
            get { return typeof(object); }
        }

        public Type Target {
            get { return typeof(object); }
        }

        public object Convert(object source) {
            return source;
        }

        public T Convert<S, T>(S source) {
            if(typeof(T) != typeof(object))
                throw new ArgumentException($"Type argument T is not type object. (DefaultConverter) (T = {typeof(T).Name}).");
            if(typeof(S) != typeof(object))
                throw new ArgumentException($"Type argument S is not type object. (DefaultConverter) (S = {typeof(S).Name}).");
            return (T)(object)(source);
        }
    }
}
