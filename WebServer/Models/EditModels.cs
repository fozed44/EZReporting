using System.Collections.Generic;
using EZReporting.Data;

namespace WebServer.Models {
    public class EditModel {
        public string ReportName { get; set; }
        public IEnumerable<ReportOutputColumn> OutputColumns { get; set; }
        public IEnumerable<ReportParameter>    Parameters    { get; set; }
        public IEnumerable<ReportOutputColumnCustomization> Customizations { get; set; }
    }
}