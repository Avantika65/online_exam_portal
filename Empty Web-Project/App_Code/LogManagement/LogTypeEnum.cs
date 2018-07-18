using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
namespace EducationLog
{
    /// <summary>
    /// Summary description for LogTypeEnum
    /// </summary>
    public enum LogTypeEnum : int
    {
        /// <summary>
        /// Unknown log item type
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Customer error log item type
        /// </summary>
        CustomerError = 1,
        /// <summary>
        /// Mail error log item type
        /// </summary>
        MailError = 2,
        /// <summary>
        /// Order error log item type
        /// </summary>
        OrderError = 3,
        /// <summary>
        /// Administration area log item type
        /// </summary>
        AdministrationArea = 4,
        /// <summary>
        /// Misc error log item type
        /// </summary>
        MiscError = 5,
    }
}