using System;
using System.Data;
using EZReporting.Interface;
using EZReporting.Location;
using Verification;

namespace EZReporting.Implementation.Converters {

    [ConverterDescriptor(
        new DbType[] {
            DbType.String,
            DbType.StringFixedLength,
            DbType.AnsiStringFixedLength,
            DbType.AnsiString
        },
        typeof(int),
        "String To Integer"
    )]
    public class StringToIntegerConverter : IConverter {

        public Type Source { get { return typeof(string); } }

        public Type Target { get { return typeof(int); } }

        public object Convert(object source) {
            Verify.True<ArgumentException>(source.GetType() == typeof(string), $"{nameof(source)} is not of type string.");
            int result = 0;
            if(!int.TryParse((string)source, out result))
                SimpleLogging.Logger.Error($"{nameof(source)}, (value: {source}) is not parsable as int. Zero was returned.");
            return result;
        }

        public T Convert<S, T>(S source) {         
            Verify.True<ArgumentException>(typeof(S) == typeof(string), $"{nameof(source)} is not of type string.");
            int result = 0;
            if(!int.TryParse((string)(object)source, out result))
                SimpleLogging.Logger.Error($"{nameof(source)}, (value: {source}) is not parsable as int. Zero was returned.");
            return (T)(object)result;
        }
    }
}
