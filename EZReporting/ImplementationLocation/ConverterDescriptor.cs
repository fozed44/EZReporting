using System;
using System.Collections.Generic;
using System.Data;
using EZReporting.Interface;

namespace EZReporting.Location {

    /// <summary>
    //++ ConverterDescriptorAttribute
    ///
    //+  Purpose:
    ///     Metadata that helps locate converters based on source or target types. Also included
    ///     is a display name property that the WebServer can use to display the converter.
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    sealed class ConverterDescriptorAttribute : ImplementationDescriptorAttribute {

        public ConverterDescriptorAttribute(DbType[] sourceTypes, Type targetType, string displayName) 
            : base (ImplementationCategory.Converter, typeof(IConverter), displayName ){
            _sourceTypes = sourceTypes;
            _targetType  = targetType;
        }

        private readonly DbType[] _sourceTypes;
        private readonly Type _targetType;

        public DbType[] SourceTypes => _sourceTypes;
        public Type TargetType  => _targetType;
    }
}
