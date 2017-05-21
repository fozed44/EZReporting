using System;
using System.Data;
using EZReporting.Interface;
using EZReporting.Location;

namespace EZReporting.Implementation {

    /// <summary>
    //++ DefaultConverter
    /// 
    //+  Purpose:
    ///     Default IConverter implementation. Does no actual conversion. (Converts object to object).
    /// </summary>
    [ConverterDescriptor(
        new DbType[] {
            DbType.AnsiString,
            DbType.AnsiStringFixedLength,
            DbType.Binary,
            DbType.Boolean,
            DbType.Byte,
            DbType.Currency,
            DbType.Date,
            DbType.DateTime,
            DbType.DateTime2,
            DbType.DateTimeOffset,
            DbType.Decimal,
            DbType.Double,
            DbType.Guid,
            DbType.Int16,
            DbType.Int32,
            DbType.Int64,
            DbType.Object,
            DbType.SByte,
            DbType.Single,
            DbType.String,
            DbType.StringFixedLength,
            DbType.Time,
            DbType.UInt16,
            DbType.UInt32,
            DbType.UInt64,
            DbType.VarNumeric,
            DbType.Xml
        },
        typeof(object),
        "Default"
    )]
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
