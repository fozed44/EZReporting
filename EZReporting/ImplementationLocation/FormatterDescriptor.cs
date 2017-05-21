using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZReporting.Interface;

namespace EZReporting.Location {
    /// <summary>
    //++ FormatterDescriptorAttribute
    ///
    //+  Purpose:
    ///     Metadata that helps locate formatters based on source or target types. Also included
    ///     is a display name property that the WebServer can use to display the formatter.
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    sealed class FormatterDescriptorAttribute : ImplementationDescriptorAttribute {

        public FormatterDescriptorAttribute(Type sourceType, Type targetType, string displayName)
            : base(ImplementationCategory.Formatter, typeof(IFormatter), displayName) {
            _sourceType = sourceType;
            _targetType  = targetType;
        }

        private readonly Type   _sourceType;
        private readonly Type   _targetType;

        public Type SourceType    => _sourceType;
        public Type TargetType    => _targetType;
    }
}
