using System;
using System.Linq;
using EZDataFramework.Framework;
using Verification;
using SimpleLogging;

namespace EZReporting.Data {

    /// <summary>
    //++ GlobalDataInitializer
    ///
    //+  Purpose:
    ///     Handle initialization tasks that must be complete before any data controller
    ///     methods are used.
    /// </summary>
    public static class GlobalDataInitializer {

        #region Fields
        
        private static bool _initialized = false;

        #endregion

        #region Public

        public static void GlobalInitialize() {
            if(_initialized) {
                Logger.Error("GlobalDataInitializer::GlobalInitialize has already executed!");
                throw new InvalidOperationException("GlobalDataInitializer::GlobalInitialize has already executed!");
            } else {
                _initialized = true;
                EnsureAlignmentDataExists();
                Logger.InitializeDefaultFileProvider(Global.LogFilePath, Global.LogFileFilename, Global.LoggerLevel);
                Logger.Info("GlobalDataInitializer::GlobalInitialize - Initialization complete.");
            }
        }

        #endregion

        #region Private

        private static void EnsureAlignmentDataExists() {
            using(var context = new EZReportingEntities()) {

                var center = context.Alignments.Where(x => x.DisplayName == "center");
                var right  = context.Alignments.Where(x => x.DisplayName == "right");
                var left   = context.Alignments.Where(x => x.DisplayName == "left");


                if(center.Count() < 1)
                    context.Alignments.Add(
                        new Alignment {
                            Css = "text-align:center;",
                            DisplayName = "center"
                        }
                    );

                if(left.Count() < 1)
                    context.Alignments.Add(
                        new Alignment {
                            Css = "text-align:left;",
                            DisplayName = "left"
                        }
                    );

                if(right.Count() < 1)
                    context.Alignments.Add(
                        new Alignment {
                            Css = "text-align:right;",
                            DisplayName = "right"
                        }
                    );

                context.SaveChanges();
            }
        }        

        #endregion
    }
}
