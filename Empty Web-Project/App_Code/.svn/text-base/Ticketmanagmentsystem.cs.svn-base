using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.ComponentModel;
using System.Configuration;
using System.Net.Mail;
using NewDAL;
using System.Web.Script.Services;
using System.Collections.Generic;
using System.Data.SqlClient;
using MSS;
using System.Data;
[ServiceContract(Namespace = "")]
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class Ticketmanagmentsystem
{
    DBManager objDB;
	// Add [WebGet] attribute to use HTTP GET
	[OperationContract]
    public List<Ticket.TicketSetting> searchCustomers(string searchText)
    {
        objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.CreateParameters(1);
        objDB.AddParameters(0, "ID", Int32.Parse(searchText), DbType.Int32);
       SqlDataReader dr = (SqlDataReader)objDB.ExecuteReader(CommandType.StoredProcedure, "Ticketsetting_Search");
       var listOfCustomerItems = new List<Ticket.TicketSetting>();
        if (dr.Read())
        {
            var item = new Ticket.TicketSetting();
            item.ID = int.Parse(dr[0].ToString());
            item.Name = dr[1].ToString();
            item.Email = dr[2].ToString();
            item.Utype = dr[3].ToString();
            item.RModule = dr[4].ToString();
            item.RAuthority = dr[5].ToString();
            item.RDuration = dr[6].ToString();
            item.CanReport = dr[7].ToString();
            item.CanChat = dr[8].ToString();
            listOfCustomerItems.Add(item);
        }
        objDB.DataReader.Close();
        objDB.Connection.Close();
        //var dataContext = new Data.NorthwindDataContext();
        //foreach (var result in dataContext.SearchCustomers(searchText))
        //{
        //    var item = new Data.CustomerItem();
        //    item.CustomerID = result.CustomerID;
        //    item.ContactName = result.ContactName;
        //    listOfCustomerItems.Add(item);
        //}
        return listOfCustomerItems;
    }
    [OperationContract]
    public List<Ticket.TicketSetting> FillAuthority()
    {
        objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        DataTable dt=new DataTable();
        dt = objDB.ExecuteTable(CommandType.Text, "Select distinct Rauthority from ticket_setting");
        var listOfCustomerItems = new List<Ticket.TicketSetting>();
        int i;
        var itemS = new Ticket.TicketSetting();
        itemS.RAuthority = "---Select---";
        listOfCustomerItems.Add(itemS);
        for (i = 0; i <= dt.Rows.Count - 1; i++)
        {
            var item = new Ticket.TicketSetting();
            item.RAuthority = dt.Rows[i].ItemArray[0].ToString();
            listOfCustomerItems.Add(item);
        }
        return listOfCustomerItems;
    }
    [OperationContract]
    public string InsertTSetting(Ticket.TicketSetting tsv)
    {
        NewDAL.DBManager objDB = new DBManager();
        objDB.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;
        objDB.DBManager(DataAccessLayer.DataProvider.SqlServer, objDB.ConnectionString);
        objDB.Open();
        objDB.BeginTransaction();
        string retv = "";
        try
        {
            objDB.CreateParameters(11);
            objDB.AddParameters(0, "ID", tsv.ID, DbType.Int32);
            objDB.AddParameters(1, "Name", tsv.Name, DbType.String);
            objDB.AddParameters(2, "Email", tsv.Email, DbType.String);
            objDB.AddParameters(3, "UType", tsv.Utype, DbType.String);
            objDB.AddParameters(4, "RModule", tsv.RModule, DbType.String);
            objDB.AddParameters(5, "Rauthority", tsv.RAuthority, DbType.String);
            objDB.AddParameters(6, "Duration", tsv.RDuration, DbType.String);
            objDB.AddParameters(7, "CanReport", tsv.CanReport, DbType.String);
            objDB.AddParameters(8, "CanChat", tsv.CanChat, DbType.String);
            objDB.AddParameters(9, "Status", "1", DbType.String);
            objDB.AddParameters(10, "flag", "N", DbType.String);
            objDB.ExecuteNonQuery(CommandType.StoredProcedure, "TicketsettingIN");
            objDB.Transaction.Commit();
            retv = "Record saved.";
        }
        catch
        {
            objDB.Transaction.Rollback();
            retv = "Unable to saved.";
        }
        return retv;
    }
}
