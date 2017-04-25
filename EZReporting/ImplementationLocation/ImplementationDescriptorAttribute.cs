using System;

namespace EZReporting.Location {

    /// <summary>
    //++ ImplementationDescriptorAttribute
    ///
    //+  Purpose:
    ///     Used to decorate implementations of renderer, converter, and formatter implementations.
    ///     The Category and Interface properties help the view factory determine which implementation
    ///     of a particular interface to instantiate given a particular report. Also the WebServer 
    ///     uses this attribute information when displaying renderer, formatter, or converter options.
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    sealed class ImplementationDescriptorAttribute : Attribute {

        public ImplementationDescriptorAttribute(ImplementationCategory category, Type @interface) {
            this._category  = category;
            this._interface = @interface;
        }

        private readonly ImplementationCategory _category;
        private readonly Type   _interface;

        public ImplementationCategory Category => _category;
        public Type Interface => _interface;
    }
}
