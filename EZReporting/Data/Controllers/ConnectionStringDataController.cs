using System.Linq;
using EZDataFramework.Framework;

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
        public static ConnectionString GetConnectionString(int id) {
            return (from   entity in Context.ConnectionStrings
                    where  entity.pkID == id
                    select entity).FirstOrDefault();
        }

        /// <summary>
        /// Add a connection string to the database.
        /// </summary>
        public static ConnectionString AddConnectionString(ConnectionString connectionString) {
            Context.ConnectionStrings.Add(connectionString);
            Context.SaveChanges();
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
        }

        /// <summary>
        /// Delete a connection string from the database.
        /// </summary>
        public static void DeleteConnectionString(ConnectionString connectionString) {
            Context.ConnectionStrings.Attach(connectionString);
            Context.ConnectionStrings.Remove(connectionString);
            Context.SaveChanges();
        }

        #endregion

    }
}
