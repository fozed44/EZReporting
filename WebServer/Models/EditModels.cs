using System;
using System.Collections.Generic;
using EZDataFramework.Framework;
using EZReporting.Interface;

namespace WebServer.Models {
    public class EditModel {
        public Report                                 Report              { get; set; }
        public IEnumerable<ReportColumn>              OutputColumns       { get; set; }
        public IEnumerable<ReportParameter>           Parameters          { get; set; }
        public IEnumerable<ReportColumnCustomization> Customizations      { get; set; }
        public IEnumerable<Type>                      ParameterConverters { get; set; }
        public IEnumerable<Type>                      OutputConverters    { get; set; }
        public IEnumerable<Type>                      Formatters          { get; set; }
    }
}