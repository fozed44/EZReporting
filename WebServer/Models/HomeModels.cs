using System.Collections.Generic;
using EZReporting.Data;

namespace WebServer.Models {
    public class HomeModel {
        public IEnumerable<Report> Reports { get; set; }
    }
}