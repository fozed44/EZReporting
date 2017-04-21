using System.Configuration;

namespace EZReporting.Default {

    public static class Defaults {

        public static string SafeServerConString =>
            ConfigurationManager.ConnectionStrings["Server"]?.ConnectionString ??
                "Data Source=DBSERV; Integrated Security=True;";

    }
}
