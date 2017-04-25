
namespace EZReporting.Attributes {

    /// <summary>
    //++ ImplementationCategory
    ///
    //+  Purpose:
    ///     Used as the value of the Category property of an ImplementationDescriptorAttribute.
    ///     The ImplementationCategory describes the category of the implementation and helps
    ///     the UI determine what implementations are available for a particular category.
    /// </summary>
    public enum ImplementationCategory {
        Renderer,
        Converter,
        Formatter,
        DataProvider
    }
}
