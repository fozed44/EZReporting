using System.Linq;
using System;
using System.Collections.Generic;
using System.Reflection;
using EZReporting.Interface;
using EZReporting.Implementation;

namespace EZReporting.Location {

    /// <summary>
    //++ ImplementationEnumerator
    ///
    //+  Purpose:
    ///     Enumerates implementations that are decorated with an ImplementationDescriptorAttribute
    ///     based on either a category or the interface the implementation implements.
    /// </summary>
    public static class ImplementationEnumerator {

        #region Public

        /// <summary>
        /// Enumerates all types that have a ImplementationDescriptor whose category property == 'property'
        /// </summary>
        /// <param name="category">
        /// The category of implementation for which to enumerate.
        /// </param>
        /// <returns>
        /// An enumeration of all types that are decorated with an ImplementationDescriptor whose
        /// category property == 'property'
        /// </returns>
        public static IEnumerable<Type> Locate(ImplementationCategory category) {
            return from type in GetDescriptedTypes()
                   where type.GetCustomAttribute<ImplementationDescriptorAttribute>().Category == category
                   select type;
        }
        /// <summary>
        /// Locate all types that are decorated with an ImplementationDescriptor with a value of 
        /// 'forInterface' for the @interface property of that descriptor.
        /// </summary>
        /// <param name="forInterface">
        /// The interface for which to enumerate implementations.
        /// </param>
        /// <returns>
        /// An enumeration of all types that are decorated with an ImplementationDescriptor whose
        /// @interface property value is 'forInterface'.
        /// </returns>
        public static IEnumerable<Type> Locate(Type forInterface) {
            return from type in GetDescriptedTypes()
                   where type.GetCustomAttribute<ImplementationDescriptorAttribute>().Interface == forInterface
                   select type;
        }

        /// <summary>
        /// Locates a type implementing interface 'T' with the name 'name'.
        /// </summary>
        /// <typeparam name="T">
        /// An Interface that the returned type must implement.
        /// </typeparam>
        /// <param name="name">
        /// The name of the type returned.
        /// </param>
        /// <returns>
        /// An instantiated object implementing interface 'T' with the name 'name'.
        /// </returns>
        public static T Locate<T>(string name) {
            var o = Locate(typeof(T))
                   .Where(x => x.Name == name)
                   .FirstOrDefault();

            if(o == null)
                o = GetDefaultImplementation(typeof(T));

            return (T)Activator.CreateInstance(o);
        }

        #endregion

        #region Private

        /// <summary>
        /// Enumerate all types in the current assembly that are decorated with an ImplementationDescriptor.
        /// </summary>
        private static IEnumerable<Type> GetDescriptedTypes() {
            foreach(var type in Assembly.GetExecutingAssembly().ExportedTypes) {
                if(Attribute.IsDefined(type, typeof(ImplementationDescriptorAttribute)))
                    yield return type;
            }
        }

        /// <summary>
        /// Return the default implementation type for the specified interface.
        /// </summary>
        private static Type GetDefaultImplementation(Type interfaceType) {
            if(interfaceType == typeof(IDataProvider))
                return typeof(DefaultDataProvider);
            if(interfaceType == typeof(IRenderer))
                return typeof(DefaultRenderer);
            if(interfaceType == typeof(IFormatter))
                return typeof(DefaultFormatter);
            if(interfaceType == typeof(IConverter))
                return typeof(DefaultConverter);
            throw new ArgumentException($"Invalid interface type ({interfaceType.Name}).");
        }        

        #endregion
    }
}
