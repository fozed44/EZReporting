using System.Collections.Generic;
using EZDataFramework.Framework;

namespace WebServer.Models {
    public class EditModel {
        public string ReportName { get; set; }
        public IEnumerable<ReportColumn> OutputColumns { get; set; }
        public IEnumerable<ReportParameter>    Parameters    { get; set; }
        public IEnumerable<ReportColumnCustomization> Customizations { get; set; }
    }
}