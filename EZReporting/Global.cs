
using System;
using SimpleLogging;

namespace EZReporting {

    /// <summary>
    //++ Global
    ///
    //+  Purpose:
    ///     Global constants.
    /// </summary>
    public class Global {

        /// <summary>
        /// Logging
        /// </summary>
        public static readonly LogLevel LoggerLevel     = LogLevel.Trace;
        public static readonly string   LogFilePath     = @"C:\Temp\";
        public static readonly string   LogFileFilename = 
            $"EZReporting__{DateTime.Now.ToShortDateString().Replace('/','_')}__" + 
            $"{DateTime.Now.Hour}_{DateTime.Now.Minute}_{DateTime.Now.Second}.log";
    }
}
