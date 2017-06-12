﻿using System.Linq;
using EZDataFramework.Framework;
using Verification;

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
            Verify.False(_initialized, "GlobalDataInitializer::GlobalInitialize has already executed!");
            _initialized = true;
            EnsureAlignmentDataExists();
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
