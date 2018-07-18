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
using System.Collections.Generic;
namespace EducationLogDBManager
{

    internal class LogDBManager
    {
        #region Methods
        public static void DeleteLog(int LogID)
        {
            //Database db = NopDataHelper.CreateConnection();
            //DbCommand dbCommand = db.GetStoredProcCommand("Nop_LogDelete");
            //db.AddInParameter(dbCommand, "LogID", DbType.Int32, LogID);
            //int retValue = db.ExecuteNonQuery(dbCommand);
        }

        public static void ClearLog()
        {
            //Database db = NopDataHelper.CreateConnection();
            //DbCommand dbCommand = db.GetStoredProcCommand("Nop_LogClear");
            //int retValue = db.ExecuteNonQuery(dbCommand);
        }

        public static LogCollection GetAllLogs()
        {
            LogCollection logCollection = new LogCollection();
            //Database db = NopDataHelper.CreateConnection();
            //DbCommand dbCommand = db.GetStoredProcCommand("Nop_LogLoadAll");
            //using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            //{
            //    while (dataReader.Read())
            //    {
            //        Log log = new Log();
            //        log.LogID = NopDataHelper.GetInt(dataReader, "LogID");
            //        log.LogTypeID = NopDataHelper.GetInt(dataReader, "LogTypeID");
            //        log.Severity = NopDataHelper.GetInt(dataReader, "Severity");
            //        log.Message = NopDataHelper.GetString(dataReader, "Message");
            //        log.Exception = NopDataHelper.GetString(dataReader, "Exception");
            //        log.IPAddress = NopDataHelper.GetString(dataReader, "IPAddress");
            //        log.CustomerID = NopDataHelper.GetInt(dataReader, "CustomerID");
            //        log.PageURL = NopDataHelper.GetString(dataReader, "PageURL");
            //        log.CreatedOn = NopDataHelper.GetDateTime(dataReader, "CreatedOn");
            //        logCollection.Add(log);
            //    }
            //}

            return logCollection;
        }

        public static Log GetByLogID(int LogID)
        {
            Log log = null;
            //Database db = NopDataHelper.CreateConnection();
            //DbCommand dbCommand = db.GetStoredProcCommand("Nop_LogLoadByPrimaryKey");
            //db.AddInParameter(dbCommand, "LogID", DbType.Int32, LogID);
            //using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            //{
            //    if (dataReader.Read())
            //    {
            //        log = new Log();
            //        log.LogID = NopDataHelper.GetInt(dataReader, "LogID");
            //        log.LogTypeID = NopDataHelper.GetInt(dataReader, "LogTypeID");
            //        log.Severity = NopDataHelper.GetInt(dataReader, "Severity");
            //        log.Message = NopDataHelper.GetString(dataReader, "Message");
            //        log.Exception = NopDataHelper.GetString(dataReader, "Exception");
            //        log.IPAddress = NopDataHelper.GetString(dataReader, "IPAddress");
            //        log.CustomerID = NopDataHelper.GetInt(dataReader, "CustomerID");
            //        log.PageURL = NopDataHelper.GetString(dataReader, "PageURL");
            //        log.CreatedOn = NopDataHelper.GetDateTime(dataReader, "CreatedOn");
            //    }
            //}
            return log;
        }

        public static Log InsertLog(int LogTypeID, int Severity, string Message, string Exception, string IPAddress, int CustomerID, string PageURL, DateTime CreatedOn)
        {
             Log log = null;
            //Database db = NopDataHelper.CreateConnection();
            //DbCommand dbCommand = db.GetStoredProcCommand("Nop_LogInsert");
            //db.AddOutParameter(dbCommand, "LogID", DbType.Int32, 0);
            //db.AddInParameter(dbCommand, "LogTypeID", DbType.Int32, LogTypeID);
            //db.AddInParameter(dbCommand, "Severity", DbType.Int32, Severity);
            //db.AddInParameter(dbCommand, "Message", DbType.String, Message);
            //db.AddInParameter(dbCommand, "Exception", DbType.String, Exception);
            //db.AddInParameter(dbCommand, "IPAddress", DbType.String, IPAddress);
            //db.AddInParameter(dbCommand, "CustomerID", DbType.Int32, CustomerID);
            //db.AddInParameter(dbCommand, "PageURL", DbType.String, PageURL);
            //db.AddInParameter(dbCommand, "CreatedOn", DbType.DateTime, CreatedOn);
            //if (db.ExecuteNonQuery(dbCommand) > 0)
            //{
            //    int LogID = Convert.ToInt32(db.GetParameterValue(dbCommand, "@LogID"));
            //    log = GetByLogID(LogID);
            //}
            return log;
        }
        #endregion
    }
    public abstract class BaseEntity
    {
    }
    public class Log : BaseEntity
    {
        #region Ctor
        /// <summary>
        /// Creates a new instance of the Log class
        /// </summary>
        public Log()
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the log identifier
        /// </summary>
        public int LogID { get; set; }

        /// <summary>
        /// Gets or sets the log type identifier
        /// </summary>
        public int LogTypeID { get; set; }

        /// <summary>
        /// Gets or sets the severity
        /// </summary>
        public int Severity { get; set; }

        /// <summary>
        /// Gets or sets the short message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the full exception
        /// </summary>
        public string Exception { get; set; }

        /// <summary>
        /// Gets or sets the IP address
        /// </summary>
        public string IPAddress { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier
        /// </summary>
        public int CustomerID { get; set; }

        /// <summary>
        /// Gets or sets the page URL
        /// </summary>
        public string PageURL { get; set; }

        /// <summary>
        /// Gets or sets the date and time of instance creation
        /// </summary>
        public DateTime CreatedOn { get; set; }

        #endregion

        //#region Custom Properties

        ///// <summary>
        ///// Gets the customer
        ///// </summary>
        //public Customer Customer
        //{
        //    get
        //    {
        //        return CustomerManager.GetByCustomerID(CustomerID);
        //    }
        //}

        ///// <summary>
        ///// Gets the log type
        ///// </summary>
        //public LogTypeEnum LogType
        //{
        //    get
        //    {
        //        return (LogTypeEnum)LogTypeID;
        //    }
        //}
        //#endregion
    }
    public class LogCollection : BaseEntityCollection<Log>
    {
    }
    public class BaseEntityCollection<T> : List<T> where T : BaseEntity
    {
    }
}