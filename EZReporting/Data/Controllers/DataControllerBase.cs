
using System;
using System.Web;
using EZDataFramework.Framework;
using Verification;

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

        private const string CONTEXT_KEY = "__ez_context";

        public class DisposerToken : IDisposable {

            public DisposerToken() {
                var currentContext = _usingHttp
                                        ? (EZReportingEntities)HttpContext.Current.Items[CONTEXT_KEY]
                                        : _threadContext;
                Verify.True(currentContext == null, "A context already exists for this thread or HttpContext.");
                if(_usingHttp)
                    HttpContext.Current.Items[CONTEXT_KEY] = new EZReportingEntities();
                else
                    _threadContext = new EZReportingEntities();
            }

            bool _disposed = false;

            ~DisposerToken() {
                Verify.True(_disposed, $"{nameof(DataControllerBase)}.{nameof(DisposerToken)} not disposed!");
            }

            public void Dispose() {
                if(_usingHttp) {
                    var context = (EZReportingEntities)HttpContext.Current.Items[CONTEXT_KEY];
                    if(context != null)
                        context.Dispose();
                    HttpContext.Current.Items[CONTEXT_KEY] = null;
                } else {
                    if(_threadContext != null)
                        _threadContext.Dispose();
                    _threadContext = null;
                }
                _disposed = true;
            }
        }
        
        [ThreadStatic]
        private static EZReportingEntities _threadContext;

        private static bool _usingHttp;

        protected static EZReportingEntities Context {
            get {
                EZReportingEntities context;
                if(_usingHttp)
                    context = (EZReportingEntities)HttpContext.Current.Items[CONTEXT_KEY];
                else
                    context = _threadContext;
#if(DEBUG)
                Verify.NotNull(context, "A EZReportingEntities context does not exist.");
#endif
                return context;
            }
        }

        static DataControllerBase() {
            _usingHttp = HttpContext.Current != null;
            GlobalDataInitializer.GlobalInitialize();
        }

        public static void SaveChanges() {
            Context.SaveChanges();
        }

    }
}
