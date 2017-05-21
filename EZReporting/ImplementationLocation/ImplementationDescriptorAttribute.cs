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
    class ImplementationDescriptorAttribute : Attribute {

        public ImplementationDescriptorAttribute(ImplementationCategory category, Type @interface, string displayName) {
            this._category    = category;
            this._interface   = @interface;
            this._displayName = displayName;
        }

        private readonly ImplementationCategory _category;
        private readonly Type   _interface;
        private readonly string _displayName;

        public ImplementationCategory Category => _category;
        public Type Interface =>  _interface;        
    }
}
