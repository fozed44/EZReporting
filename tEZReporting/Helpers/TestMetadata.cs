﻿
namespace tEZReporting.Helpers {
    public class TestMetadata {

        public const string DatabaseName = "ExclusiveSavers";
        public const string SchemaName = "dbo";
        public const string ReportName = "TestReport";

        /// <summary>
        //! Note!!
        /// ProceName needs to be the name of a stored procedure that is in
        /// DatabaseName.SchemaName that has BOTH inputs AND outputs!!!!
        /// </summary>
        public const string ProcName = "GetContactInfoForContact";
    }
}
