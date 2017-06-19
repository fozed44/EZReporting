using System.Collections.Generic;
using System.Linq;
using EZDataFramework.Framework;
using SimpleLogging;

namespace EZReporting.Data {

    /// <summary>
    //++ ConnectionStringDataController
    ///
    //+  Purpose:
    ///     Data controller for connection strings.
    /// </summary>
    public class ConnectionStringDataController : DataControllerBase {

        #region Public

        /// <summary>
        /// Retrieve a connection string from the database.
        /// </summary>
        public static ConnectionString Get(int id) {
            return (from   entity in Context.ConnectionStrings
                    where  entity.pkID == id
                    select entity).FirstOrDefault();
        }

        /// <summary>
        /// Returns all available connection strings.
        /// </summary>
        public static List<ConnectionString> GetAll() {
            return (from   entity in Context.ConnectionStrings
                    select entity).ToList();
        }

        /// <summary>
        /// Add a connection string to the database.
        /// </summary>
        public static ConnectionString AddConnectionString(ConnectionString connectionString) {
            Context.ConnectionStrings.Add(connectionString);
            Context.SaveChanges();
            Logger.Trace($"Added ConnectionString {connectionString.Name}.");
            return connectionString;
        }

        /// <summary>
        /// Delete a connection string from the database.
        /// </summary>
        public static void DeleteConnectionString(int id) {
            var current = Context.ConnectionStrings.Find(id);
            if(current == null)
                return;
            Context.ConnectionStrings.Remove(current);
            Context.SaveChanges();
            Logger.Trace($"Deleted ConnectionString {current.Name}.");
        }

        /// <summary>
        /// Delete a connection string from the database.
        /// </summary>
        public static void DeleteConnectionString(ConnectionString connectionString) {
            Context.ConnectionStrings.Attach(connectionString);
            Context.ConnectionStrings.Remove(connectionString);
            Context.SaveChanges();
            Logger.Trace($"Deleted ConnectionString {connectionString.Name}.");
        }

        #endregion

    }
}
