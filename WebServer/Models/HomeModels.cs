using System.Collections.Generic;
using EZDataFramework.Framework;

namespace WebServer.Models {
    public class HomeModel {
        public IEnumerable<Report> Reports { get; set; }
    }
}