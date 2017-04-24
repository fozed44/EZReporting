using System;

namespace EZReporting.Attributes {

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
