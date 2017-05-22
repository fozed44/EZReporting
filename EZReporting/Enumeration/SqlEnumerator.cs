using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EZReporting.Default;
using System.Linq;

namespace EZReporting.Enumeration {

    /// <summary>
    //++ SqlEnumerator
    ///
    //+  Purpose:
    ///     To retrieve information from a MSSQL server. The static class has methods to enumerate
    ///     databases, tables, stored procedures, and the inputs and outputs of stored procedures.
    ///
    //+  Note:
    ///     The server name that is queried is determined either by the valued of the 'Server'
    ///     connection string defined in the webconfig or appconfig, or if that is not present
    ///     the methods will default to DBSERV using integrated security.
    /// </summary>
    public static class SqlEnumerator {

        #region Public

        /// <summary>
        /// Enumerate the databases in a MSSQL instance.
        /// </summary>
        /// <returns>
        /// An enumeration of strings representing the names of the databases in the server.
        /// </returns>
        public static IEnumerable<string> EnumerateDatabases() {
            var result = new List<string>();
            using(var con = new SqlConnection(Defaults.SafeServerConString)) {
                con.Open();
                DataTable databases = con.GetSchema("Databases");
                foreach(DataRow database in databases.Rows)
                    result.Add(database.Field<string>("database_name"));
            }
            return result;
        }

        /// <summary>
        /// Enumerate the tables in a database.
        /// </summary>
        /// <param name="database">
        /// The name of the database for which the tables should be enumerated
        /// </param>
        /// <returns>
        /// An enumeration of strings representing the tables in the specified database.
        /// </returns>
        public static IEnumerable<string> EnumerateTables(string database) {
            var result = new List<string>();
            var SQL = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES ORDER BY TABLE_NAME ASC";
            using(var con = new SqlConnection(Defaults.SafeServerConString)) {
                con.Open();
                con.ChangeDatabase(database);
                using(var command = new SqlCommand(SQL, con)) {
                    using(var reader = command.ExecuteReader()) {
                        while(reader.Read())
                            result.Add((string)reader["TABLE_NAME"]);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Enumerates the stored procedures available in database.schema
        /// </summary>
        /// <param name="database">
        /// The name of the database to be searched.
        /// </param>
        /// <param name="schema">
        /// The name of the schema within the specified database to be searched.
        /// </param>
        /// <returns>
        /// An enumeration of strings containing the names of the stored procedures in database.schema
        /// </returns>
        public static IEnumerable<string> EnumerateStoredProcs(string database, string schema) {
            var result = new List<string>();
            var SQL = $"SELECT PR.NAME FROM {database}.SYS.PROCEDURES PR INNER JOIN " +
                      $"{database}.SYS.SCHEMAS S ON PR.SCHEMA_ID = S.SCHEMA_ID " +
                      $"WHERE S.NAME = '{schema}' ORDER BY PR.NAME ASC";
            using(var con = new SqlConnection(Defaults.SafeServerConString)) {
                con.Open();
                con.ChangeDatabase(database);
                using(var command = new SqlCommand(SQL, con)) {
                    using(var reader = command.ExecuteReader()) {
                        while(reader.Read())
                            result.Add((string)reader["NAME"]);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Enumerate the schemas in the given database.
        /// </summary>
        /// <param name="database">
        /// The database that should be searched.
        /// </param>
        /// <returns>
        /// An enumeration of schemas available in the given database.
        /// </returns>
        public static IEnumerable<string> EnumerateSchemas(string database) {
            var result = new List<string>();
            using(var con = new SqlConnection(Defaults.SafeServerConString)) {
                con.Open();
                con.ChangeDatabase(database);
                using(var command = new SqlCommand("SELECT NAME FROM SYS.SCHEMAS", con)) {
                    using(var reader = command.ExecuteReader()) {
                        while(reader.Read())
                            result.Add((string)reader["NAME"]);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Enumerate the inputs for a particular stored procedure.
        /// </summary>
        /// <param name="database">
        /// The name of the database containing the stored procedure.
        /// </param>
        /// <param name="schema">
        /// The name of the schema within the given database containing the stored procedure.
        /// </param>
        /// <param name="proc">
        /// The name of the procedure.
        /// </param>
        /// <returns>
        /// An enumeration of 'EnumeratedInput' objects containing information about the inputs to
        /// database.schema.procedure
        /// </returns>
        public static IEnumerable<EnumeratedInput> EnumerateStoredProcInputs(string database, string schema, string proc) {
            var result = new List<EnumeratedInput>();
            var SQL = $"SELECT SCHEMA_NAME(SCHEMA_ID)AS[Schema], " +
                      $"SO.name AS[ObjectName], " +
                      $"SO.Type_Desc AS[ObjectType(UDF/SP)], " +
                      $"P.parameter_id AS[ParameterID], " +
                      $"P.name AS[ParameterName], " +
                      $"TYPE_NAME(P.user_type_id) AS[ParameterDataType], " +
                      $"P.max_length AS[ParameterMaxBytes], " +
                      $"P.is_output AS[IsOutPutParameter] " +
                      $"FROM sys.objects AS SO " +
                      $"INNER JOIN sys.parameters AS P " +
                      $"ON SO.OBJECT_ID = P.OBJECT_ID " +
                      $"WHERE SO.OBJECT_ID IN(SELECT OBJECT_ID " +
                      $"FROM sys.objects " +
                      $"WHERE TYPE IN('P', 'FN')) AND " +
                      $"SCHEMA_NAME(SCHEMA_ID) = '{schema}' AND " +
                      $"SO.name = '{proc}' " +
                      $"ORDER BY[Schema], SO.name, P.parameter_id";
            using(var con = new SqlConnection(Defaults.SafeServerConString)) {
                con.Open();
                con.ChangeDatabase(database);
                using(var command = new SqlCommand(SQL, con)) {
                    using(var reader = command.ExecuteReader()) {
                        while(reader.Read())
                            result.Add(new EnumeratedInput {
                                Name              = (string)reader["ParameterName"],
                                DataType          = (string)reader["ParameterDataType"],
                                MaxBytes          = (Int16)reader["ParameterMaxBytes"],
                                ID                = (Int32)reader["ParameterID"],
                                IsOutputParameter = (bool)reader["IsOutPutParameter"]
                            });

                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Enumerate the outputs to a particular stored procedure.
        /// </summary>
        /// <param name="database">
        /// The name of the database containing the stored procedure.
        /// </param>
        /// <param name="schema">
        /// The name of the schema within the given database containing the stored procedure.
        /// </param>
        /// <param name="proc">
        /// The name of the procedure for which to enumerate the outputs.
        /// </param>
        /// <returns>
        /// An enumeration of 'EnumeratedOutput' objects containing information about the outputs of
        /// database.schema.procedure.
        /// </returns>
        public static IEnumerable<EnumeratedOutput> EnumerateStoredProcOutputs(string database, string schema, string proc) {
            var result = new List<EnumeratedOutput>();
            var SQL = GetOutputEnumerationQuery(database, schema, proc);
            using(var con = new SqlConnection(Defaults.SafeServerConString)) {
                con.Open();
                con.ChangeDatabase(database);
                using(var command = new SqlCommand(SQL, con)) {
                    using(var reader = command.ExecuteReader()) {
                        for(int i = 0; i < reader.FieldCount; i++) {
                            result.Add(new EnumeratedOutput {
                                Name = reader.GetName(i),
                                Type = reader.GetDataTypeName(i)
                            });
                        }
                    }
                }
            }
            return result;
        }

        #endregion

        #region Private

        /// <summary>
        /// Builds a query string that is used by the EnumerateStoredProcOutpus method to retrieve an
        /// null set valued result of database.schema.proc
        /// </summary>
        private static string GetOutputEnumerationQuery(string database, string schema, string proc) {
            var inputs = EnumerateStoredProcInputs(database, schema, proc);
            return $"SET FMTONLY ON; " +
                   $"\nEXEC {database}.{schema}.{proc} {GetOutputEnumerationQueryInputs(inputs)}";
        }

        private static string GetOutputEnumerationQueryInputs(IEnumerable<EnumeratedInput> inputs) {
            return inputs.Count() > 0
                        ? string.Join(" = NULL, ", inputs.Select(x => x.Name)) + " = NULL"
                        : "";
        }

        #endregion

    }
}