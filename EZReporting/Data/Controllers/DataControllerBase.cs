
namespace EZReporting.Data {

    /// <summary>
    //++ DataControllerBase
    ///
    //+  Purpose:
    ///     Force the GlobalDataInitializer.GlobalInitialize method to be called before any methods
    ///     on any data controller are executed.
    ///     
    //+  Remarks:
    //!     ALL DATA CONTROLLERS MUST INHERIT FROM THIS BASE CLASS
    ///     In order to make sure that initialization takes place before any method on any data controller
    ///     is executed, every data controller must inherit from DataControllerBase.
    /// </summary>
    public class DataControllerBase {

        static DataControllerBase() {
            GlobalDataInitializer.GlobalInitialize();
        }

    }
}
