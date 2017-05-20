using EZDataFramework.Framework;

namespace EZReporting.Interface {

    /// <summary>
    //++ IRenderer
    ///
    //+  Purpose:
    ///     Interface for implementation to render a report to a string containing the HTML rendering
    ///     of the report.
    /// </summary>
    public interface IRenderer {

        /// <summary>
        /// Renders the report to a string containing the HTML rendering of the report.
        /// </summary>
        /// <param name="report">
        /// The report to render.
        /// </param>
        /// <param name="userID">
        /// The userID of the user for which to render the report. Each user can have her own customizations
        /// for each report.
        /// </param>
        /// <returns>
        /// A string that is the HTML rendering of the report.
        /// </returns>
        string Render(Report report, int userID);

        /// <summary>
        /// Can this implementation render this report?
        /// </summary>
        /// <param name="report">
        /// The report to check to determine if the implementation is capable of rendering.
        /// </param>
        /// <returns>
        /// True if the implementation can render the report, otherwise, false.
        /// </returns>
        bool CanRender(Report report);
    }
}
