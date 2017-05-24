using EZDataFramework.Framework;
using System.Linq;

namespace EZReporting.Data {

    /// <summary>
    //++ TableStyleDataController
    ///
    //+  Public:
    ///     Data controller for table styles.
    /// </summary>
    public static class TableStyleDataController {

        /// <summary>
        /// Load a table style from the database.
        /// </summary>
        public static TableStyle LoadTableStyle(int pkID) {
            using(var entities = new EZReportingEntities()) {
                return (from entity in entities.TableStyles
                        where entity.pkID == pkID
                        select entity).FirstOrDefault();
            }
        }

        /// <summary>
        /// Add a table style to the database.
        /// </summary>
        public static TableStyle AddTableStyle(TableStyle tableStyle) {
            using(var entities = new EZReportingEntities()) {
                entities.TableStyles.Add(tableStyle);
                entities.SaveChanges();
                return tableStyle;
            }
        }

        /// <summary>
        /// Delete a table from the database.
        /// </summary>
        public static void DeleteTableStyle(TableStyle tableStyle) {
            using(var entities = new EZReportingEntities()) {
                entities.TableStyles.Remove(tableStyle);
                entities.SaveChanges();
            }
        }

        /// <summary>
        /// Delete a table from the database.
        /// </summary>
        public static void DeleteTableStyle(int pkID) {
            using(var entities = new EZReportingEntities()) {
                var current = entities.TableStyles.Find(pkID);
                if(current == null)
                    return;
                entities.TableStyles.Remove(current);
                entities.SaveChanges();
            }
        }

    }
}
