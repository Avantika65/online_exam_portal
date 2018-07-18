using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using NewDAL;
using System.Data;
[ServiceContract(Namespace = "")]
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class HostelSVC
{
	// To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
	// To create an operation that returns XML,
	//     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
	//     and include the following line in the operation body:
	//         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";

    [Serializable]
    [DataContract]
    public class HostelListDM
    {
        [DataMember]
        public int ResidenseID { get; set; }
        [DataMember]
        public string ResidenseName { get; set; }
    }
    [Serializable]
    [DataContract]
    public class HostelFloorListDM
    {
        [DataMember]
        public int CategoryID { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
    }
    [Serializable]
    [DataContract]
    public class HostelRoomListDM
    {
        [DataMember]
        public int RoomQtrID { get; set; }
        [DataMember]
        public string Room_Qtr_No { get; set; }
    }
    [Serializable]
    [DataContract]
    public class HostelRoomDetailDM
    {
        [DataMember]
        public int Bed_Capacity { get; set; }
        [DataMember]
        public int Alloted_Room { get; set; }
        [DataMember]
        public string RoomT_N { get; set; }
    }
    [Serializable]
    [DataContract]
    public class HostelRoomRateDM
    {
        [DataMember]
        public decimal  Rate { get; set; }
        [DataMember]
        public DateTime  Fromdate { get; set; }
        [DataMember]
        public DateTime Todate { get; set; }
        [DataMember]
        public int RoomChild_ID { get; set; }
        [DataMember]
        public int RoomType { get; set; }
        [DataMember]
        public decimal NoOfDays { get; set; }
        [DataMember]
        public decimal AmountToPay { get; set; }
    }
    [Serializable]
    [DataContract]
    public class AllotmentMasterDM
    {
        [DataMember]
        public int AllotmentID { get; set; }
        [DataMember]
        public string AllotmentNo { get; set; }
        [DataMember]
        public int StudentID { get; set; }
        [DataMember]
        public int InstituteID { get; set; }
        [DataMember]
        public string SessionID { get; set; }
        [DataMember]
        public bool IsCancelled { get; set; }
        [DataMember]
        public bool IsExtended { get; set; }
        [DataMember]
        public string  UName { get; set; }
        [DataMember]
        public DateTime  UEntDate { get; set; }
   }
    [Serializable]
    [DataContract]
    public class AllotmentChildDM
    {
        [DataMember]
        public int ACID { get; set; }
        [DataMember]
        public string AllotmentID { get; set; }
        [DataMember]
        public int RoomID { get; set; }
        [DataMember]
        public int BedNo { get; set; }
        [DataMember]
        public int StudentID { get; set; }
        [DataMember]
        public string BedPosition { get; set; }
        [DataMember]
        public DateTime AllotFrom { get; set; }
        [DataMember]
        public DateTime AllotTo { get; set; }
        [DataMember]
        public decimal UnclearedDays { get; set; }
        [DataMember]
        public decimal AllotDays { get; set; }
        [DataMember]
        public decimal RemainDays { get; set; }
        [DataMember]
        public string Status { get; set; }
  }
    [DataContract]
    public class AllotmentRateChildDM
    {
        [DataMember]
        public int ARSID { get; set; }
        [DataMember]
        public string AllotmentID { get; set; }
        [DataMember]
        public int ACID { get; set; }
        [DataMember]
        public int RateID { get; set; }
        [DataMember]
        public DateTime RateFrom { get; set; }
        [DataMember]
        public DateTime RateTo { get; set; }
        [DataMember]
        public decimal AmountToPay { get; set; }
        [DataMember]
        public decimal Rate { get; set; }
        [DataMember]
        public decimal RateDays { get; set; }
        [DataMember]
        public decimal BalanceAmt { get; set; }
        [DataMember]
        public int counter { get; set; }
        [DataMember]
        public int StudentID { get; set; }
        [DataMember]
        public decimal UnclearedDays { get; set; }
    }
    [DataContract]
    public class ReAllotmentDM
    {
       [DataMember]
        public int AllotmentID { get; set; }
        [DataMember]
        public string  AllotmentNo { get; set; }
        [DataMember]
        public DateTime ReallocationFrom { get; set; }
        [DataMember]
        public int StudentID { get; set; }
        [DataMember]
        public int RoomID { get; set; }
        [DataMember]
        public decimal AllotDays { get; set; }
  }
    [Serializable]
    [DataContract]
    public class RoomDetailDM
    {
        [DataMember]
        public int BedNo { get; set; }
       [DataMember]
        public string BedPosition { get; set; }
    }
    [Serializable]
    [DataContract]
    public class DueDateDM
    {
        [DataMember]
        public DateTime  DueDate { get; set; }
        [DataMember]
        public int IsPaid { get; set; }
   }
    [DataContract]
    public class FeeDetailDM
    {
        [DataMember]
        public int AllotmentID { get; set; }
        [DataMember]
        public int ARSID { get; set; }
        [DataMember]
        public int ACID { get; set; }
        [DataMember]
        public DateTime  AllotFrom { get; set; }
        [DataMember]
        public DateTime AllotTo { get; set; }
        [DataMember]
        public int RateID { get; set; }
        [DataMember]
        public decimal  Rate { get; set; }
        [DataMember]
        public decimal RateDays { get; set; }
        [DataMember]
        public decimal AmountToPay { get; set; }
        [DataMember]
        public decimal Balance { get; set; }
        [DataMember]
        public DateTime PaidFrom { get; set; }
        [DataMember]
        public DateTime PaidTo { get; set; }
        [DataMember]
        public int Qstatus { get; set; }
    }
    [DataContract]
    public class FeeRecordDM
    {
        [DataMember]
        public int AllotmentID { get; set; }
        [DataMember]
        public string  StudentID { get; set; }
    }
    [DataContract]
    public class FeeDepositeHostelMDM
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int AllotmentID { get; set; }
        [DataMember]
        public int StudentID { get; set; }
        [DataMember]
        public string  RCNO { get; set; }
        [DataMember]
        public DateTime ReceiptDate { get; set; }
        [DataMember]
        public int InstituteID { get; set; }
        [DataMember]
        public string  SessionID { get; set; }
        [DataMember]
        public string UName { get; set; }
        [DataMember]
        public DateTime UEntDate { get; set; }
    }

    [DataContract]
    public class FeeDepositeHostelCDM
    {
        [DataMember]
        public int StudentID { get; set; }
        [DataMember]
        public string  RCNO { get; set; }
        [DataMember]
        public decimal PaidAmt { get; set; }
        [DataMember]
        public DateTime PaidFrom { get; set; }
        [DataMember]
        public DateTime PaidTo { get; set; }
        [DataMember]
        public decimal PayDays { get; set; }
        [DataMember]
        public int IsRemaining { get; set; }
        [DataMember]
        public int RateID { get; set; }
        [DataMember]
        public decimal Payable { get; set; }
        [DataMember]
        public decimal Balance { get; set; }
        [DataMember]
        public int ACID { get; set; }
        [DataMember]
        public int ARSID { get; set; }
        [DataMember]
        public string AllotmentNo { get; set; }
        [DataMember]
        public decimal UnclearedDays { get; set; }
        [DataMember]
        public decimal UnclearedAmt { get; set; }
        [DataMember]
        public string PMode { get; set; }
        [DataMember]
        public DateTime Pdate { get; set; }
        [DataMember]
        public string Pno { get; set; }
    }



    [DataContract]
    public class HostelReciptDM
    {
        [DataMember]
        public string ReceiptNo { get; set; }
        [DataMember]
        public string StudentID { get; set; }
        [DataMember]
        public string StudentName { get; set; }
        [DataMember]
        public DateTime TranDate { get; set; }
        [DataMember]
        public string FatherName { get; set; }
        [DataMember]
        public string AllotmentNo { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Particular { get; set; }
        [DataMember]
        public decimal Hostelamt { get; set; }
        [DataMember]
        public string ChequeNo { get; set; }
        [DataMember]
        public string ChequeAmt { get; set; }
        [DataMember]
        public string DraftNo { get; set; }
        [DataMember]
        public string DraftAmt { get; set; }
        [DataMember]
        public string Cash { get; set; }
        [DataMember]
        public string Suminfigure { get; set; }
        [DataMember]
        public DateTime PeriodFrom { get; set; }
        [DataMember]
        public DateTime PeriodTo { get; set; }
    }

    [DataContract]
    public class FeeReceiptDM
    {
        //[DataMember]
        //public int StudentID { get; set; }
        [DataMember]
        public string RCNO { get; set; }
    }

    [OperationContract]
    public List<FeeReceiptDM> FillHLReceipt(string studentid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        var receipt = new List<FeeReceiptDM>();
        IDataReader dr = objDB.ExecuteReader(CommandType.Text, "Select distinct  rcno as rcno From HL_FeeDepositMast where studentid='" + studentid + "'");
        while (dr.Read())
        {
            var item = new FeeReceiptDM();
            item.RCNO = Education.DataHelper.GetString(dr, "RCNO");
            
            receipt.Add(item);
        }
        return receipt;
    }

    [OperationContract]
    public List<HostelListDM> FillHostel(string str)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        var itemret =new  List<HostelListDM>();
        IDataReader dr = objDB.ExecuteReader(CommandType.Text, "Select distinct ResidenseID,ResidenseName From Master_Hostel_Residense");
        while (dr.Read())
        {
            var item = new HostelListDM();
            item.ResidenseID = Education.DataHelper.GetInt(dr, "ResidenseID");
            item.ResidenseName = Education.DataHelper.GetString (dr, "ResidenseName");
            itemret.Add(item);
        }
            return itemret;
    }
    [OperationContract]
    public List<HostelFloorListDM> FillHostelFloor(int ResidenseID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        var itemret = new List<HostelFloorListDM>();
        IDataReader dr = objDB.ExecuteReader(CommandType.Text, "Select CategoryName,CategoryID From Master_Hostel_Category where ResidenseID='" + ResidenseID + "'");
        while (dr.Read())
        {
            var item = new HostelFloorListDM();
            item.CategoryID = Education.DataHelper.GetInt(dr, "CategoryID");
            item.CategoryName = Education.DataHelper.GetString(dr, "CategoryName");
            itemret.Add(item);
        }
        return itemret;
    }
    [OperationContract]
    public List<HostelRoomListDM> FillHostelRoom(int hostelID,int FloorID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        var itemret = new List<HostelRoomListDM>();
        IDataReader dr = objDB.ExecuteReader(CommandType.Text, "Select distinct RoomQtrID,Room_Qtr_No from Room_Quarter_Master where CategoryID='" + FloorID + "' and ResiID='" + hostelID + "' and  (Bed_Capacity > Alloted_Room)");
        while (dr.Read())
        {
            var item = new HostelRoomListDM();
            item.RoomQtrID = Education.DataHelper.GetInt(dr, "RoomQtrID");
            item.Room_Qtr_No = Education.DataHelper.GetString(dr, "Room_Qtr_No");
            itemret.Add(item);
        }
        return itemret;
    }

    [OperationContract]
    public  HostelRoomDetailDM  GetHostelRoomDetail(int hostelID, int FloorID, int RoomID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        var item = new HostelRoomDetailDM();
        IDataReader dr = objDB.ExecuteReader(CommandType.Text, "SELECT   Room_Quarter_Master.Bed_Capacity ,Room_Quarter_Master.Alloted_Room,RoomType_m.RoomT_N  FROM    Room_Quarter_Master INNER JOIN RoomType_m ON dbo.Room_Quarter_Master.RoomType = dbo.RoomType_m.RoomTypeID AND dbo.Room_Quarter_Master.ResiID = dbo.RoomType_m.Hostel_ID where CategoryID='" + FloorID + "' and ResiID='" + hostelID + "' and RoomQtrID=" + RoomID);
        try
        {
            if (dr.Read())
            {
                item.Bed_Capacity = Education.DataHelper.GetInt(dr, "Bed_Capacity");
                item.Alloted_Room = Education.DataHelper.GetInt(dr, "Alloted_Room");
                item.RoomT_N = Education.DataHelper.GetString(dr, "RoomT_N");
            }
        }
        finally
        {
            dr.Close();
            dr.Dispose();
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return item;
    }

    [OperationContract]
    public List<HostelRoomRateDM> GetHostelRoomRate(int hostelID, int FloorID, int RoomID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        var itemret = new List<HostelRoomRateDM>();
        IDataReader dr = objDB.ExecuteReader(CommandType.Text, "SELECT DISTINCT RoomT_child.FromDate, RoomT_child.Todate, RoomT_child.Rate, RoomT_child.RoomChild_ID, Room_Quarter_Master.RoomType,Room_Quarter_Master.ResiID  FROM  Room_Quarter_Master INNER JOIN RoomT_child ON Room_Quarter_Master.RoomTypeChild = RoomT_child.RoomChild_ID where Room_Quarter_Master.CategoryID='" + FloorID + "' and Room_Quarter_Master.ResiID='" + hostelID + "' and Room_Quarter_Master.RoomQtrID=" + RoomID);
        try
        {
            while(dr.Read())
            {
                var item = new HostelRoomRateDM();
                item.Rate = Education.DataHelper.GetDecimal(dr, "Rate");
                item.Fromdate = Education.DataHelper.GetDateTime(dr, "Fromdate");
                item.Todate = Education.DataHelper.GetDateTime(dr, "Todate");
                item.RoomChild_ID = Education.DataHelper.GetInt(dr, "RoomChild_ID");
                item.RoomType = Education.DataHelper.GetInt(dr, "RoomType");
                item.NoOfDays = 0;
                item.AmountToPay = 0;
                itemret.Add(item);
            }
        }
        finally
        {
            dr.Close();
            dr.Dispose();
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return itemret;
    }

    [OperationContract]
    public List<HostelRoomRateDM> GetHostelRoomRate(int RoomID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        var itemret = new List<HostelRoomRateDM>();
        IDataReader dr = objDB.ExecuteReader(CommandType.Text, "SELECT DISTINCT RoomT_child.FromDate, RoomT_child.Todate, RoomT_child.Rate, RoomT_child.RoomChild_ID, Room_Quarter_Master.RoomType,Room_Quarter_Master.ResiID  FROM  Room_Quarter_Master INNER JOIN RoomT_child ON Room_Quarter_Master.RoomTypeChild = RoomT_child.RoomChild_ID where   Room_Quarter_Master.RoomQtrID=" + RoomID);
        try
        {
            while (dr.Read())
            {
                var item = new HostelRoomRateDM();
                item.Rate = Education.DataHelper.GetDecimal(dr, "Rate");
                item.Fromdate = Education.DataHelper.GetDateTime(dr, "Fromdate");
                item.Todate = Education.DataHelper.GetDateTime(dr, "Todate");
                item.RoomChild_ID = Education.DataHelper.GetInt(dr, "RoomChild_ID");
                item.RoomType = Education.DataHelper.GetInt(dr, "RoomType");
                item.NoOfDays = 0;
                item.AmountToPay = 0;
                itemret.Add(item);
            }
        }
        finally
        {
            dr.Close();
            dr.Dispose();
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return itemret;
    }


    [OperationContract]
    public string InsertAllotmentHostel(HostelSVC.AllotmentMasterDM mdm, HostelSVC.AllotmentChildDM cdm, List<HostelSVC.AllotmentRateChildDM> rcdm)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string rc = "Record saved";
        try
        {
            objDB.CreateParameters(10);
            objDB.AddParameters(0, "AllotmentID", mdm.AllotmentID, DbType.Int16);
            objDB.AddParameters(1, "AllotmentNo", mdm.AllotmentNo, DbType.String);
            objDB.AddParameters(2, "StudentID", mdm.StudentID, DbType.Int16);
            objDB.AddParameters(3, "InstituteID", mdm.InstituteID, DbType.Int16);
            objDB.AddParameters(4, "SessionID", mdm.SessionID, DbType.String);
            objDB.AddParameters(5, "IsCancelled", mdm.IsCancelled, DbType.Boolean);
            objDB.AddParameters(6, "IsExtended", mdm.IsExtended, DbType.Boolean);
            objDB.AddParameters(7, "UName", mdm.UName, DbType.String);
            objDB.AddParameters(8, "UEntDate", mdm.UEntDate, DbType.DateTime);
            objDB.AddParameters(9, "retAllotmentID", 0, DbType.Int16, ParameterDirection.Output);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "InsertAllotmentMaster");
            string allid = objDB.Parameters[9].Value.ToString();
            objDB.CreateParameters(12);
            objDB.AddParameters(0, "ACID", cdm.ACID, DbType.Int16);
            objDB.AddParameters(1, "StudentID", mdm.StudentID, DbType.Int16);
            objDB.AddParameters(2, "AllotmentID", allid, DbType.String);
            objDB.AddParameters(3, "RoomID", cdm.RoomID, DbType.Int16);
            objDB.AddParameters(4, "BedNo", cdm.BedNo, DbType.Int16);
            objDB.AddParameters(5, "BedPosition", cdm.BedPosition, DbType.String);
            objDB.AddParameters(6, "AllotFrom", cdm.AllotFrom, DbType.DateTime);
            objDB.AddParameters(7, "AllotTo", cdm.AllotTo, DbType.DateTime);
            objDB.AddParameters(8, "AllotDays", cdm.AllotDays, DbType.Decimal);
            objDB.AddParameters(9, "RemainDays", cdm.RemainDays, DbType.Decimal);
            objDB.AddParameters(10, "Status", cdm.Status, DbType.String);
            objDB.AddParameters(11, "retACID", 0, DbType.Int16, ParameterDirection.Output);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "InsertAllotmentChild");
            string ACID = objDB.Parameters[11].Value.ToString();
            foreach (HostelSVC.AllotmentRateChildDM c in rcdm)
            {
                objDB.CreateParameters(12);
                objDB.AddParameters(0, "ARSID", c.ARSID, DbType.Int16);
                objDB.AddParameters(1, "AllotmentID", allid, DbType.String);
                objDB.AddParameters(2, "ACID", ACID, DbType.Int16);
                objDB.AddParameters(3, "RateID", c.RateID, DbType.Int16);
                objDB.AddParameters(4, "RateFrom", c.RateFrom, DbType.DateTime);
                objDB.AddParameters(5, "RateTo", c.RateTo, DbType.DateTime);
                objDB.AddParameters(6, "AmountToPay", c.AmountToPay, DbType.Decimal);
                objDB.AddParameters(7, "Rate", c.Rate, DbType.Decimal);
                objDB.AddParameters(8, "RateDays", c.RateDays, DbType.Decimal);
                objDB.AddParameters(9, "BalanceAmt", c.BalanceAmt, DbType.Decimal);
                objDB.AddParameters(10, "counter", c.counter, DbType.Int16);
                objDB.AddParameters(11, "StudentID", c.StudentID, DbType.Int16);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "InsertAllotementRate");
            }

            objDB.Transaction.Commit();
        }
        catch (Exception ex)
        {
            rc = ex.Message.ToString();
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return rc;
    }


    [OperationContract]
    public string InsertReAllotmentHostel(HostelSVC.AllotmentChildDM cdm, List<HostelSVC.AllotmentRateChildDM> rcdm)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string rc = "Record saved";
        try
        {
            objDB.CreateParameters(12);
            objDB.AddParameters(0, "ACID", cdm.ACID, DbType.Int16);
            objDB.AddParameters(1, "StudentID", cdm.StudentID, DbType.Int32);
            objDB.AddParameters(2, "AllotmentID", cdm.AllotmentID, DbType.String);
            objDB.AddParameters(3, "RoomID", cdm.RoomID, DbType.Int16);
            objDB.AddParameters(4, "BedNo", cdm.BedNo, DbType.Int16);
            objDB.AddParameters(5, "BedPosition", cdm.BedPosition, DbType.String);
            objDB.AddParameters(6, "AllotFrom", cdm.AllotFrom, DbType.DateTime);
            objDB.AddParameters(7, "AllotTo", cdm.AllotTo, DbType.DateTime);
            objDB.AddParameters(8, "AllotDays", cdm.AllotDays, DbType.Decimal);
            objDB.AddParameters(9, "RemainDays", cdm.UnclearedDays, DbType.Decimal);
            objDB.AddParameters(10, "Status", cdm.Status, DbType.String);
            objDB.AddParameters(11, "retACID", 0, DbType.Int16, ParameterDirection.Output);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "InsertAllotmentChild");
            string ACID = objDB.Parameters[11].Value.ToString();
            foreach (HostelSVC.AllotmentRateChildDM c in rcdm)
            {
                objDB.CreateParameters(12);
                objDB.AddParameters(0, "ARSID", c.ARSID, DbType.Int16);
                objDB.AddParameters(1, "AllotmentID", c.AllotmentID, DbType.String);
                objDB.AddParameters(2, "ACID", c.ACID, DbType.Int16);
                objDB.AddParameters(3, "RateID", c.RateID, DbType.Int16);
                objDB.AddParameters(4, "RateFrom", c.RateFrom, DbType.DateTime);
                objDB.AddParameters(5, "RateTo", c.RateTo, DbType.DateTime);
                objDB.AddParameters(6, "AmountToPay", c.AmountToPay, DbType.Decimal);
                objDB.AddParameters(7, "Rate", c.Rate, DbType.Decimal);
                objDB.AddParameters(8, "RateDays", c.RateDays, DbType.Decimal);
                objDB.AddParameters(9, "BalanceAmt", c.BalanceAmt, DbType.Decimal);
                objDB.AddParameters(10, "counter", c.counter, DbType.Int16);
                objDB.AddParameters(11, "StudentID ", c.StudentID, DbType.Int16);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "InsertAllotementRate");
            }

            objDB.Transaction.Commit();
        }
        catch (Exception ex)
        {
            rc = ex.Message.ToString();
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return rc;
    }

    [OperationContract]
    public ReAllotmentDM ReallotDetails(int StudentlID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        var item = new ReAllotmentDM();
        IDataReader dr = objDB.ExecuteReader(CommandType.Text, "SELECT    cast(HL_AllotmentChild.RoomID as int) as RoomID, HL_RoomAllotmentMast.AllotmentID,dbo.HL_RoomAllotmentMast.StudentID, dbo.HL_AllotmentChild.AllotTo, dbo.HL_RoomAllotmentMast.AllotmentNo  FROM   HL_RoomAllotmentMast INNER JOIN      HL_AllotmentChild ON dbo.HL_RoomAllotmentMast.AllotmentID = dbo.HL_AllotmentChild.AllotmentID where  HL_RoomAllotmentMast.studentid=" + StudentlID);
        try
        {
            while (dr.Read())
            {
                item.AllotmentID = Education.DataHelper.GetInt(dr, "AllotmentID");
                item.ReallocationFrom = Education.DataHelper.GetDateTime(dr, "AllotTo");
                item.StudentID = Education.DataHelper.GetInt(dr, "StudentID");
                item.AllotmentNo = Education.DataHelper.GetString(dr, "AllotmentNo");
                item.RoomID = Education.DataHelper.GetInt(dr, "RoomID");
          }
        }
        finally
        {
            dr.Close();
            dr.Dispose();
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return item;
    }
    [OperationContract]
    public RoomDetailDM GetHostelRoomDetailByAllotmentID(string AllotmentNo)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        var item = new RoomDetailDM();
        IDataReader dr = objDB.ExecuteReader(CommandType.Text, "select distinct bedno,bedposition from hl_allotmentchild where AllotmentID='" + AllotmentNo + "'");
        try
        {
            if (dr.Read())
            {
                //int h = Education.DataHelper.GetString(dr, "BedNo");
                //item.BedNo = h;
                item.BedNo = Convert.ToInt16(Education.DataHelper.GetString(dr, "BedNo"));
                item.BedPosition = Education.DataHelper.GetString(dr, "BedPosition");
            }
        }
        finally
        {
            dr.Close();
            dr.Dispose();
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return item;
    }

    [OperationContract]
    public DueDateDM GetDueDateByStudentID(int StudentID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        var item = new DueDateDM();
        objDB.CreateParameters(3);
        objDB.AddParameters(0, "StudentID", StudentID, DbType.Int32);
        objDB.AddParameters(1, "duedate", DateTime.Now, DbType.DateTime,ParameterDirection.Output);
        objDB.AddParameters(2, "IsPaid", 0, DbType.Int16, ParameterDirection.Output);
        IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "DueDateHostel");
        try
        {
            if (dr.Read())
            {
                item.DueDate = Convert.ToDateTime(dr[0].ToString());
                item.IsPaid = int.Parse(dr[1].ToString());
            }
        }
        finally
        {
            dr.Close();
            dr.Dispose();
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return item;
    }


    [OperationContract]
    public List<FeeDetailDM>   GetHostelFeeDetailByStudentID(int StudentID)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "StudentID", StudentID, DbType.Int32);
        IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "Get_HF_Detail");
        var retitem = new List<FeeDetailDM>();
        try
        {
            while (dr.Read())
            {
                var item = new FeeDetailDM();
                item.AllotFrom = Education.DataHelper.GetDateTime(dr, "AllotFrom");
                item.AllotTo = Education.DataHelper.GetDateTime(dr, "AllotTo");
                item.AllotmentID = Education.DataHelper.GetInt(dr, "AllotmentID");
                item.ACID = Education.DataHelper.GetInt(dr, "ACID");
                item.ARSID = Education.DataHelper.GetInt(dr, "ARSID");
                item.RateID = Education.DataHelper.GetInt(dr, "RateID");
                item.Rate = Education.DataHelper.GetDecimal(dr, "Rate");
                item.RateDays = Education.DataHelper.GetDecimal(dr, "RateDays");
                item.AmountToPay = Education.DataHelper.GetDecimal(dr, "AmountToPay");
                item.Balance = Education.DataHelper.GetDecimal(dr, "BalanceAmt");
                retitem.Add(item);
            }
        }
        finally
        {
            dr.Close();
            dr.Dispose();
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return retitem;
    }

    [OperationContract]
    public List<FeeDetailDM> GetHostelFeeDetailPaidByStudentID(int StudentID, DateTime Transdate)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "StudentID", StudentID, DbType.Int32);
        objDB.AddParameters(1, "TransDate", Transdate, DbType.DateTime);
        IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "Get_HF_DetailAfterPay");
        var retitem = new List<FeeDetailDM>();
        try
        {
            while (dr.Read())
            {
                var item = new FeeDetailDM();
                item.AllotFrom = Education.DataHelper.GetDateTime(dr, "AllotFrom");
                item.AllotTo = Education.DataHelper.GetDateTime(dr, "AllotTo");
                item.AllotmentID = Education.DataHelper.GetInt(dr, "AllotmentID");
                item.ACID = Education.DataHelper.GetInt(dr, "ACID");
                item.ARSID = Education.DataHelper.GetInt(dr, "ARSID");
                item.RateID = Education.DataHelper.GetInt(dr, "RateID");
                item.Rate = Education.DataHelper.GetDecimal(dr, "Rate");
                item.RateDays = Education.DataHelper.GetDecimal(dr, "RateDays");
                item.AmountToPay = Education.DataHelper.GetDecimal(dr, "AmountToPay");
                item.Balance = Education.DataHelper.GetDecimal(dr, "BalanceAmt");
                item.PaidFrom = Education.DataHelper.GetDateTime(dr, "PaidFrom");
                item.PaidTo = Education.DataHelper.GetDateTime(dr, "PaidTo");
                item.Qstatus = Education.DataHelper.GetInt(dr, "Qstatus");
                retitem.Add(item);
            }
        }
        finally
        {
            dr.Close();
            dr.Dispose();
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return retitem;
    }

    [OperationContract]
    public List<FeeDetailDM> GetHostelFeeDetailPaidByStudentIDOver(int StudentID, DateTime Transdate)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(2);
        objDB.AddParameters(0, "StudentID", StudentID, DbType.Int32);
        objDB.AddParameters(1, "TransDate", Transdate, DbType.DateTime);
        IDataReader dr = objDB.ExecuteReader(CommandType.StoredProcedure, "Get_HF_DetailAfterOver");
        var retitem = new List<FeeDetailDM>();
        try
        {
            while (dr.Read())
            {
                var item = new FeeDetailDM();
                item.AllotFrom = Education.DataHelper.GetDateTime(dr, "AllotFrom");
                item.AllotTo = Education.DataHelper.GetDateTime(dr, "AllotTo");
                item.AllotmentID = Education.DataHelper.GetInt(dr, "AllotmentID");
                item.ACID = Education.DataHelper.GetInt(dr, "ACID");
                item.ARSID = Education.DataHelper.GetInt(dr, "ARSID");
                item.RateID = Education.DataHelper.GetInt(dr, "RateID");
                item.Rate = Education.DataHelper.GetDecimal(dr, "Rate");
                item.RateDays = Education.DataHelper.GetDecimal(dr, "RateDays");
                item.AmountToPay = Education.DataHelper.GetDecimal(dr, "AmountToPay");
                item.Balance = Education.DataHelper.GetDecimal(dr, "BalanceAmt");
                item.PaidFrom = Education.DataHelper.GetDateTime(dr, "PaidFrom");
                item.PaidTo = Education.DataHelper.GetDateTime(dr, "PaidTo");
                item.Qstatus = Education.DataHelper.GetInt(dr, "Qstatus");
                retitem.Add(item);
            }
        }
        finally
        {
            dr.Close();
            dr.Dispose();
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return retitem;
    }

    [OperationContract]
    public string  Insert_FeeDepositeHostel(HostelSVC.FeeDepositeHostelMDM objMDM,List< HostelSVC.FeeDepositeHostelCDM> objCMDM)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        string retv = "";
        objDB.BeginTransaction();
        try
        {
            objDB.CreateParameters(9);
            objDB.AddParameters(0, "ID", objMDM.ID, DbType.Int32);
            objDB.AddParameters(1, "AllotmentID", objMDM.AllotmentID, DbType.Int32);
            objDB.AddParameters(2, "StudentID", objMDM.StudentID, DbType.Int32);
            objDB.AddParameters(3, "RCNO", objMDM.RCNO, DbType.String);
            objDB.AddParameters(4, "ReceiptDate", objMDM.ReceiptDate, DbType.DateTime);
            objDB.AddParameters(5, "InstituteID", objMDM.InstituteID, DbType.Int16);
            objDB.AddParameters(6, "SessionID", objMDM.SessionID, DbType.String);
            objDB.AddParameters(7, "UName", objMDM.UName, DbType.String);
            objDB.AddParameters(8, "UEntDate", objMDM.UEntDate, DbType.DateTime);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "HL_FeeDeposite");
            foreach (HostelSVC.FeeDepositeHostelCDM d in objCMDM)
            {
                objDB.CreateParameters(18);
                objDB.AddParameters(0, "studentID", d.StudentID, DbType.Int32);
                objDB.AddParameters(1, "RCNO", d.RCNO, DbType.String);
                objDB.AddParameters(2, "PaidAmt", d.PaidAmt.ToString("00.0000000000"), DbType.Decimal);
                objDB.AddParameters(3, "PaidFrom", d.PaidFrom, DbType.DateTime);
                objDB.AddParameters(4, "PaidTo", d.PaidTo, DbType.DateTime);
                objDB.AddParameters(5, "PayDays", d.PayDays.ToString("00.0000000000"), DbType.Decimal);
                objDB.AddParameters(6, "IsRemaining", d.IsRemaining, DbType.Int32);
                objDB.AddParameters(7, "RateID", d.RateID, DbType.Int32);
                objDB.AddParameters(8, "Payable", d.Payable.ToString("00.0000000000"), DbType.Decimal);
                objDB.AddParameters(9, "Balance", d.Balance.ToString("00.0000000000"), DbType.Decimal);
                objDB.AddParameters(10, "ACID", d.ACID, DbType.Int32);
                objDB.AddParameters(11, "ARSID", d.ARSID, DbType.Int32);
                objDB.AddParameters(12, "AllotmentNo", d.AllotmentNo, DbType.String);
                objDB.AddParameters(13, "UnclearedDays", d.UnclearedDays.ToString("00.0000000000"), DbType.Decimal);
                objDB.AddParameters(14, "UnclearedAmt", d.UnclearedAmt.ToString("00.0000000000"), DbType.Decimal);
                objDB.AddParameters(15, "PMode", d.PMode, DbType.String);
                objDB.AddParameters(16, "Pdate", d.Pdate, DbType.DateTime);
                objDB.AddParameters(17, "PNo", d.Pno, DbType.String);
                objDB.ExecuteNonQuery(CommandType.StoredProcedure, "HL_FeeDepositeChild");
            }
            objDB.Transaction.Commit();
            retv = "Record saved";
        }
        catch(Exception ex)
        {
            objDB.Transaction.Rollback();
            retv = ex.Message.ToString();
        }
        finally
        {
            objDB.Connection.Close();
            objDB.Dispose();
        }
        return retv;
    }



    [OperationContract]
    public string InsertHostelRecipt(HostelSVC.HostelReciptDM HRDM)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string rc = "Record saved";
        try
        {
            objDB.CreateParameters(17);
            objDB.AddParameters(0, "ReceiptNo", HRDM.ReceiptNo, DbType.String);
            objDB.AddParameters(1, "StudentID", HRDM.StudentID, DbType.String);
            objDB.AddParameters(2, "StudentName", HRDM.StudentName, DbType.String);
            objDB.AddParameters(3, "TranDate", HRDM.TranDate, DbType.DateTime);
            objDB.AddParameters(4, "FatherName", HRDM.FatherName, DbType.String);
            objDB.AddParameters(5, "AllotmentNo", HRDM.AllotmentNo, DbType.String);
            objDB.AddParameters(6, "Address", HRDM.Address, DbType.String);
            objDB.AddParameters(7, "Particular", HRDM.Particular, DbType.String);
            objDB.AddParameters(8, "Hostelamt", HRDM.Hostelamt, DbType.Decimal);
            objDB.AddParameters(9, "ChequeNo", HRDM.ChequeNo, DbType.String);
            objDB.AddParameters(10, "ChequeAmt", HRDM.ChequeAmt, DbType.String);
            objDB.AddParameters(11, "DraftNo", HRDM.DraftNo, DbType.String);
            objDB.AddParameters(12, "DraftAmt", HRDM.DraftAmt, DbType.String);
            objDB.AddParameters(13, "Cash", HRDM.Cash, DbType.String);
            objDB.AddParameters(14, "Suminfigure", HRDM.Suminfigure, DbType.String);
            objDB.AddParameters(15, "PeriodFrom", HRDM.PeriodFrom, DbType.DateTime);
            objDB.AddParameters(16, "PeriodTo", HRDM.PeriodTo, DbType.DateTime);

            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "InsertHostelRecipt");

            objDB.Transaction.Commit();
        }
        catch (Exception ex)
        {
            rc = ex.Message.ToString();
        }
        finally
        {

            objDB.Connection.Close();
            objDB.Dispose();
        }
        return rc;
    }


    public DataTable FillReceipt(string rcno)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.Text, "SELECT * from HL_HostelRecipt where ReceiptNo in('"+rcno+"')");
        objDB.Connection.Close();
        objDB.Dispose();
        return dt;
    }


    public DataTable FillGVDetaiP(int studentid)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        DataTable dt = new DataTable();
        dt = objDB.ExecuteTable(CommandType.Text, "SELECT HL_FeeDepositionChild.studentID, HL_FeeDepositionChild.RCNO, HL_FeeDepositionChild.PaidAmt, HL_FeeDepositionChild.PaidFrom, HL_FeeDepositionChild.PaidTo, HL_FeeDepositionChild.PayDays, RoomT_child.Rate FROM HL_FeeDepositionChild INNER JOIN RoomT_child ON HL_FeeDepositionChild.RateID = RoomT_child.RoomChild_ID where studentID='" + studentid + "'");
        objDB.Connection.Close();
        objDB.Dispose();
        return dt;
    }
}
