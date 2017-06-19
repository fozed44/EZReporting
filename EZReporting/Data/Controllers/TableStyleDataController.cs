using EZDataFramework.Framework;
using System.Linq;
using System;
using SimpleLogging;
using System.Collections.Generic;

namespace EZReporting.Data {

    /// <summary>
    //++ TableStyleDataController
    ///
    //+  Public:
    ///     Data controller for table styles.
    /// </summary>
    public class TableStyleDataController : DataControllerBase {

        /// <summary>
        /// Load a table style from the database.
        /// </summary>
        public static TableStyle Get(int pkID) {
            return (from   entity in Context.TableStyles
                    where  entity.pkID == pkID
                    select entity).FirstOrDefault();
        }

        /// <summary>
        /// Return all TableStyles.
        /// </summary>
        public static List<TableStyle> GetAll() {
            return (from   entity in Context.TableStyles
                    select entity).ToList();
        }

        /// <summary>
        /// Add a table style to the database.
        /// </summary>
        public static TableStyle AddTableStyle(TableStyle tableStyle) {
            Context.TableStyles.Add(tableStyle);
            Context.SaveChanges();
            Logger.Trace($"Created table style {tableStyle.Name}.");
            return tableStyle;
        }

        /// <summary>
        /// Delete a table from the database.
        /// </summary>
        public static void DeleteTableStyle(TableStyle tableStyle) {
            Context.TableStyles.Attach(tableStyle);
            Context.TableStyles.Remove(tableStyle);
            Context.SaveChanges();
            Logger.Trace($"Deleted table style {tableStyle.Name}.");
        }

        /// <summary>
        /// Delete a table from the database.
        /// </summary>
        public static void DeleteTableStyle(int pkID) {
            var current = Context.TableStyles.Find(pkID);
            if(current == null)
                return;
            Context.TableStyles.Remove(current);
            Context.SaveChanges();
            Logger.Trace($"Deleted table style {current.Name}.");
        }

    }
}
