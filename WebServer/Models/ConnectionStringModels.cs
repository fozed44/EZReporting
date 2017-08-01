using System.Collections.Generic;
using EZDataFramework.Framework;

namespace WebServer.Models {
    public class ConnectionStringViewModel {
        public IEnumerable<ConnectionString> ConnectionStrings { get; set; }
    }
}