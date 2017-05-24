using System.Linq;
using EZDataFramework.Framework;

namespace EZReporting.Data {

    /// <summary>
    //++ ConnectionStringDataController
    ///
    //+  Purpose:
    ///     Data controller for connection strings.
    /// </summary>
    public static class ConnectionStringDataController {

        #region Public

        /// <summary>
        /// Retrieve a connection string from the database.
        /// </summary>
        public static ConnectionString GetConnectionString(int id) {
            using(var entities = new EZReportingEntities()) {
                return (from   entity in entities.ConnectionStrings
                        where  entity.pkID == id
                        select entity).FirstOrDefault();
            }
        }

        /// <summary>
        /// Add a connection string to the database.
        /// </summary>
        public static ConnectionString AddConnectionString(ConnectionString connectionString) {
            using(var entities = new EZReportingEntities()) {
                entities.ConnectionStrings.Add(connectionString);
                entities.SaveChanges();
                return connectionString;
            }
        }

        /// <summary>
        /// Delete a connection string from the database.
        /// </summary>
        public static void DeleteConnectionString(int id) {
            using(var entities = new EZReportingEntities()) {
                var current = entities.ConnectionStrings.Find(id);
                if(current == null)
                    return;
                entities.ConnectionStrings.Remove(current);
                entities.SaveChanges();
            }
        }

        /// <summary>
        /// Delete a connection string from the database.
        /// </summary>
        public static void DeleteConnectionString(ConnectionString connectionString) {
            using(var entities = new EZReportingEntities()) {
                entities.ConnectionStrings.Remove(connectionString);
                entities.SaveChanges();
            }
        }

        #endregion

    }
}
