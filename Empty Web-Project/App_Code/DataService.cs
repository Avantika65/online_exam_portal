using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;
using System.Runtime.Serialization;
using System.Data.SqlClient;

//public abstract class BaseEntity
//{
//}

//[Serializable]
//[DataContract]
//public class Product : BaseEntity
//{
//    [DataMember]
//    public int ID { get; set; }

//    [DataMember]
//    public string Product_Name{ get; set; }

//    [DataMember]
//    public string Requester { get; set; }

//    [DataMember]
//    public int Quantity { get; set; }

//    [DataMember]
//    public String Date { get; set; }

//    [DataMember]
//    public Boolean Is_Read { get; set; }
    
//}

//public class PagedResult<T> where T : BaseEntity
//{
//    public int Total;
//    public List<T> Rows;
//}

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService()]
public class DataService : System.Web.Services.WebService
{
    private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString;

    //private static readonly string BPOConnectionString = ConfigurationManager.ConnectionStrings["bpoLiveConnection"].ConnectionString;

    public DataService()
    {
    }

    [WebMethod(EnableSession=true), ScriptMethod]
    public DataMember.PagedResult<DataMember.Product> GetProductList(int start, int max, string sortColumn, string sortOrder, string cond)
    {
        string cond1 = "";
        string deptid = "";
        if (cond != "")
        {
            System.Array acond = cond.Split('|');
            cond1 = acond.GetValue(0).ToString();
            deptid = acond.GetValue(1).ToString();
        }
        string Cond_SQL = string.Empty;
        if (max == 0)
        {
            max = 10;
        }

        if (string.IsNullOrEmpty(sortColumn))
        {
            sortColumn = "ID";
        }

        if (string.IsNullOrEmpty(sortOrder))
        {
            sortOrder = "DESC";
        }
        if (cond != string.Empty)
        {
            Cond_SQL = cond1;
            if (cond1 == "A")
            {
                Cond_SQL = "True";
            }
            if (cond1 == "NA")
            {
                Cond_SQL = "False";
            }
        }
        else
        {
            cond1 = "NPP";
        }
        //string SQL = "Select DISTINCT [ID],[Requester],([Prod_Name]+' Quantity:'+cast(Qty as nvarchar)) as Prod_Name,[Qty],convert(nvarchar,IndentDate,109) as IndentDate,Is_Read,case indentstatus WHEN 'P' THEN 'Pending' WHEN 'C' THEN 'Closed' ELSE 'New' END AS Status From ( " +
        //                       "select Indent.ID,dbo.ConcateName(first_name,middle_name,last_name) as Requester,(Prod_Name+' ['+Prod_code+']') as Prod_Name,Qty,IndentDate,Is_Read,indent.indentstatus, " +
        //                       "ROW_NUMBER() OVER (ORDER BY Indent.ID DESC) AS [RowIndex] " +
        //                       "from Indent,Client_Regs,Prod_Manager,college " +
        //                       "where	prod_manager.Ctrl_Id = indent.Ctrl_Id and " +
        //                        " prod_manager.instid = indent.instid and " +
        //                       "Client_Regs.id=Indent.userid and " +
        //                       "college.collegeid=Indent.instid and " +
        //                       "college.collegeid=Client_Regs.instid and " +
        //                       "college.collegeid={4} AND " + Cond_SQL + ") as rec " +
        //                       "where ([RowIndex] > {2}) AND ([RowIndex] <= ({2} + {3})) " +
        //                       "SELECT COUNT(ID) FROM [Indent] WHERE " + Cond_SQL + "";

        int total = 0;
        List<DataMember.Product> list = new List<DataMember.Product>();
                
        SqlCommand com = null;
        //SqlCommand com1 = null;
        
        using (SqlConnection con = new SqlConnection(ConnectionString))
        {
            con.Open();

            //com1 = new SqlCommand("select departmentid from iemployeeaction_vw where userid=" + Int32.Parse(Session["uid"].ToString()), con);
            //SqlDataReader drd = com1.ExecuteReader();

            //while (drd.Read())
            //{
            //    if (deptid != "")
            //    {
            //        deptid = deptid + "," + drd[0].ToString();
            //    }
            //    else
            //    {
            //        deptid = drd[0].ToString();
            //    }
            //}
            //if (deptid != "")
            //{
            //    deptid = "(" + deptid + ")";
            //}
            //else
            //{
            //    deptid = "(0)";
            //}

            //drd.Close();
            com = new SqlCommand();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", cond1);
            com.Parameters.AddWithValue("start", start);
            com.Parameters.AddWithValue("max", max);
            com.Parameters.AddWithValue("Condition", Cond_SQL);
            com.Parameters.AddWithValue("InstId", Int32.Parse(Session["instID"].ToString()));
            com.Parameters.AddWithValue("deptid", deptid);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Indent_Box";
            SqlDataReader Sreader = com.ExecuteReader();
            while (Sreader.Read())
            {
                DataMember.Product p = BuildProduct(Sreader);
                list.Add(p);
            }
        }
        //using (IDbConnection cnn = CreateConnection())
        //{
        //    using (IDbCommand cmd = cnn.CreateCommand())
        //    {
        //        //cmd.CommandText = string.Format(SQL, sortColumn, sortOrder, start, max, Session["InstId"].ToString());
        //        //cmd.CreateParameter();
        //        //cmd.CommandType = CommandType.StoredProcedure;
        //        //cmd.Parameters.Add(sta
        //        //cmd.CommandText = "SP_Indent_Box";
        //        using (IDataReader rdr = cmd.ExecuteReader())
        //        {
        //            while (rdr.Read())
        //            {
        //                DataMember.Product p = BuildProduct(rdr);

        //                list.Add(p);
        //            }

        //            if ((rdr.NextResult()) && (rdr.Read()))
        //            {
        //                total = rdr.GetInt32(0);
        //            }
        //        }
        //    }
        //}

        if ((list.Count == 0))
        {
            return null;
        }

        DataMember.PagedResult<DataMember.Product> result = new DataMember.PagedResult<DataMember.Product>();

        result.Rows = list;
        result.Total = total;

        return result;
    }

    [WebMethod(EnableSession = true), ScriptMethod]
    public DataMember.PagedResult<DataMember.Product> GetProductListadm(int start, int max, string sortColumn, string sortOrder, string cond)
    {
        string Cond_SQL = string.Empty;
        if (max == 0)
        {
            max = 10;
        }

        if (string.IsNullOrEmpty(sortColumn))
        {
            sortColumn = "ID";
        }

        if (string.IsNullOrEmpty(sortOrder))
        {
            sortOrder = "DESC";
        }
        if (cond != string.Empty)
        {
            Cond_SQL = cond;
            if (cond == "A")
            {
                Cond_SQL = "True";
            }
            if (cond == "NA")
            {
                Cond_SQL = "False";
            }
        }
        else
        {
            cond = "Al";
        }
        
        int total = 0;
        List<DataMember.Product> list = new List<DataMember.Product>();

        SqlCommand com = null;
        SqlCommand com1 = null;
        using (SqlConnection con = new SqlConnection(ConnectionString))
        {
            con.Open();

            com1 = new SqlCommand("select deptid from iemployeeusers_vw where userid=" + Int32.Parse(Session["uid"].ToString()), con);
            object retdid = com1.ExecuteScalar();
            int rval = retdid != null ? int.Parse(retdid.ToString()) : 0;

            com = new SqlCommand();
            com.Connection = con;
            com.Parameters.AddWithValue("flag", cond);
            com.Parameters.AddWithValue("start", start);
            com.Parameters.AddWithValue("max", max);
            com.Parameters.AddWithValue("Condition", Cond_SQL);
            com.Parameters.AddWithValue("InstId", Int32.Parse(Session["instID"].ToString()));
            com.Parameters.AddWithValue("deptid", rval);
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SP_Indent_Boxadm";
            SqlDataReader Sreader = com.ExecuteReader();
            while (Sreader.Read())
            {
                DataMember.Product p = BuildProduct(Sreader);
                list.Add(p);
            }
        }
        
        if ((list.Count == 0))
        {
            return null;
        }

        DataMember.PagedResult<DataMember.Product> result = new DataMember.PagedResult<DataMember.Product>();

        result.Rows = list;
        result.Total = total;

        return result;
    }

    private static DataMember.Product BuildProduct(SqlDataReader reader)
    {
        DataMember.Product product = new DataMember.Product();

        product.ID = reader.IsDBNull(0) ? int.MinValue : reader.GetInt32(0);
        product.Requester = reader.IsDBNull(1) ? string.Empty : reader.GetString(1).Trim();
        product.Product_Name = reader.IsDBNull(2) ? string.Empty : reader.GetString(2).Trim();
        product.Quantity = reader.IsDBNull(3) ? Decimal.MinValue : reader.GetDecimal(3);
        product.Date = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
        product.Is_Read = (Boolean) reader.GetValue(5);
        product.Status = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
        product.IndentId = reader.IsDBNull(7) ? int.MinValue : reader.GetInt32(7);
        return product;
    }

    private static IDbConnection CreateConnection()
    {
        IDbConnection cnn = new System.Data.SqlClient.SqlConnection(ConnectionString);
        cnn.Open();

        return cnn;
    }

    [WebMethod(EnableSession = true), ScriptMethod]
    public void Update_Intent(Int32 IndentID)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["FeesManagementConn"].ConnectionString);
        con.Open();
        SqlCommand com = null;
        com = new SqlCommand();
        com.Connection = con;
        string SQL= "UPDATE Indent SET Is_Read = 'True' WHERE ID = '"+IndentID+"' AND InstId = '"+Int32.Parse(Session["instId"].ToString())+"'";
        com.CommandType = CommandType.Text;
        com.CommandText = SQL;
        com.ExecuteNonQuery();
    }

    [WebMethod(EnableSession = true), ScriptMethod]
    public DataMember.PagedResult<DataMember.RFQDetails> GetRFQDetails(int start, int max, string sortColumn, string sortOrder)
    {
        if (max == 0)
        {
            max = 10;
        }

        if (string.IsNullOrEmpty(sortColumn))
        {
            sortColumn = "ID";
        }

        if (string.IsNullOrEmpty(sortOrder))
        {
            sortOrder = "DESC";
        }

        string SQL = " Select [ID], [RFQNo],convert(nvarchar,RFQDate,109) as RFQDate, [vendor_name],[filename],[filetype],id_vendor From ( " +
                               " select Rfq_mst.[ID], Rfq_mst.[RFQNo],convert(nvarchar,Rfq_mst.RFQDate,109) as RFQDate,AddRelation.[vendor_name], RFQFileInfo.[filename],RFQFileInfo.[filetype],AddRelation.id_vendor, " +
                               " ROW_NUMBER() OVER (ORDER BY Rfq_mst.RFQDate DESC) AS [RowIndex] " +
                               " from Rfq_mst,RFQ_Child,college,Pur_Req_Child,pur_request,AddRelation,RFQFileInfo " +
                               " where RFQ_mst.id = RFQ_Child.RFQId and RFQ_mst.instid = RFQ_Child.instid and " +
                               " RFQ_Child.prid = Pur_Req_Child.Id and RFQ_Child.instid = Pur_Req_Child.instid and " +
                               " RFQ_mst.id = RFQFileInfo.RFQNo and RFQ_mst.instid = RFQFileInfo.instid and " +
                               " AddRelation.id_vendor = RFQFileInfo.supplierid and AddRelation.instid = RFQFileInfo.instid and " +
                               " Pur_Req_Child.pr_mst_id = pur_request.Id and Pur_Req_Child.instid = pur_request.instid and " +
                               " RFQ_Child.supplierid = AddRelation.id_vendor and RFQ_Child.instid = AddRelation.instid and " +
                               " college.collegeid=Rfq_mst.instid and " +
                               " college.collegeid=Pur_Req_Child.instid and " +
                               " college.collegeid=RFQ_Child.instid and " +
                               " college.collegeid=pur_request.instid and " +
                               " college.collegeid=AddRelation.instid and " +
                               " college.collegeid={4} GROUP BY Rfq_mst.[ID], Rfq_mst.[RFQNo],Rfq_mst.RFQDate, [vendor_name],[filename],[filetype],AddRelation.id_vendor) as rec " +
                               " where ([RowIndex] > {2}) AND ([RowIndex] <= ({2} + {3})) " +
                               " SELECT COUNT(ID) FROM [Rfq_mst]";
        int total = 0;
        List<DataMember.RFQDetails> list = new List<DataMember.RFQDetails>();

        using (IDbConnection cnn = CreateConnection())
        {
            using (IDbCommand cmd = cnn.CreateCommand())
            {
                cmd.CommandText = string.Format(SQL, sortColumn, sortOrder, start, max, Session["InstId"].ToString());

                using (IDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        DataMember.RFQDetails p = BuildRFQ(rdr);

                        list.Add(p);
                    }

                    if ((rdr.NextResult()) && (rdr.Read()))
                    {
                        total = rdr.GetInt32(0);
                    }
                }
            }
        }

        if ((list.Count == 0) || (total == 0))
        {
            return null;
        }

        DataMember.PagedResult<DataMember.RFQDetails> result = new DataMember.PagedResult<DataMember.RFQDetails>();

        result.Rows = list;
        result.Total = total;

        return result;
    }

    private static DataMember.RFQDetails BuildRFQ(IDataReader reader)
    {
        DataMember.RFQDetails RFQ = new DataMember.RFQDetails();

        RFQ.ID = reader.IsDBNull(0) ? int.MinValue : reader.GetInt32(0);
        RFQ.RFQNo = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
        RFQ.RFQDate = reader.IsDBNull(2) ? string.Empty : reader.GetString(2).Trim();
        //RFQ.ProductName = reader.IsDBNull(1) ? string.Empty : reader.GetString(3).Trim(); 
        RFQ.Supplier = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
        RFQ.Filename = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
        RFQ.Filetype = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
        RFQ.SupplierID = reader.IsDBNull(6) ? int.MinValue : reader.GetInt32(6);
        return RFQ;
    }
}

