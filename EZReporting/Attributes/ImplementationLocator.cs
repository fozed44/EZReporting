using System.Linq;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace EZReporting.Attributes {
    public class ImplementationLocator {

        #region Public

        public IEnumerable<Type> Locate(ImplementationCategory category) {
            return from type in GetDescriptedTypes()
                   where type.GetCustomAttribute<ImplementationDescriptorAttribute>().Category == category
                   select type;
        }

        public IEnumerable<Type> Locate(Type forInterface) {
            return from type in GetDescriptedTypes()
                   where type.GetCustomAttribute<ImplementationDescriptorAttribute>().Interface == forInterface
                   select type;
        }

        #endregion

        #region Private

        private IEnumerable<Type> GetDescriptedTypes() {
            foreach(var type in Assembly.GetExecutingAssembly().ExportedTypes) {
                if(Attribute.IsDefined(type, typeof(ImplementationDescriptorAttribute)))
                    yield return type;
            }
        }

        #endregion
    }
}
