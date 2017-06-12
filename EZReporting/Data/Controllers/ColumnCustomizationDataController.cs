﻿using System.Collections.Generic;
using System.Linq;
using EZDataFramework.Framework;

namespace EZReporting.Data {

    /// <summary>
    //++ ColumnCustomizationDataController
    ///
    //+  Purpose:
    ///     Enumerates column customization data for each column in a particular report.
    /// </summary>
    public class ColumnCustomizationDataController : DataControllerBase {

        private ColumnCustomizationDataController() { }

        public static List<ReportColumnCustomization> GetColumns(Report report) {
            return (from column in Context.Columns
                    join columnCustomization in Context.ColumnCustomizations
                    on column.pkID equals columnCustomization.fkReportColumn
                    where column.fkReport == report.pkID
                    select columnCustomization).ToList();
        }

    }
}
