using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;

public class BlogsaUser
{
    private int _UserID;

    public int UserID
    {
        get { return _UserID; }
        set { _UserID = value; }
    }
    private string _UserName;

    public string UserName
    {
        get { return _UserName; }
        set { _UserName = value; }
    }

    private string _Password;

    public string Password
    {
        get { return _Password; }
        set { _Password = value; }
    }

    private short _State;

    public short State
    {
        get { return _State; }
        set { _State = value; }
    }

    private string _Name;

    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }
    private string _Email;

    public string Email
    {
        get { return _Email; }
        set { _Email = value; }
    }
    private string _WebPage;

    public string WebPage
    {
        get { return _WebPage; }
        set { _WebPage = value; }
    }
    private DateTime? _LastLoginDate;

    public DateTime? LastLoginDate
    {
        get { return _LastLoginDate; }
        set { _LastLoginDate = value; }
    }
    private string _Role;

    public string Role
    {
        get { return _Role; }
        set { _Role = value; }
    }

    private DateTime _CreateDate;

    public DateTime CreateDate
    {
        get { return _CreateDate; }
        set { _CreateDate = value; }
    }
}

public class Users
{
    //public static Hashtable ValidateUser(string UserName, string Password)
    //{
    //    //Hashtable Where = new Hashtable();
    //    //Where.Add("UserName", UserName);
    //    //Where.Add("@1", "AND");
    //    //Where.Add("Password", Password);
    //    //return DBToys.Do.SecurityQuery("Users", Where, "", "*");
    //}

    //public static bool ValidateEmail(string Email)
    //{
    //    //Hashtable Ht = new Hashtable();
    //    //Ht.Add("Email", Email);
    //    //Ht = DBToys.Do.SecurityQuery("Users", Ht, "", "*");
    //    //if ((int)Ht["DataCount"] > 0)
    //    //{
    //    //    return true;
    //    //}
    //    //else
    //    //{
    //    //    return false;
    //    //}
    //}

    //public static List<BlogsaUser> GetUsers(string strWhere)
    //{
    ////    List<BlogsaUser> _Users = new List<BlogsaUser>();
    ////    DataSet ds = DBToys.Do.ExecuteDataset("SELECT * FROM Users" +
    ////(string.IsNullOrEmpty(strWhere) ? "" : " WHERE " + strWhere));
    ////    foreach (DataRow dr in ds.Tables[0].Rows)
    ////    {
    ////        BlogsaUser user = new BlogsaUser();
    ////        FillUser(dr, user);
    ////        _Users.Add(user);
    ////    }
    ////    return _Users;
    //}

    //public static BlogsaUser GetUser(int iUserID)
    //{
    //    //BlogsaUser user = new BlogsaUser();
    //    //DataSet ds = DBToys.Do.ExecuteDataset("SELECT * FROM Settings WHERE Users" + iUserID);
    //    //if (ds != null && ds.Tables[0].Rows.Count > 0)
    //    //{
    //    //    FillUser(ds.Tables[0].Rows[0], user);
    //    //}
    //    //return user;
    //}

    private static void FillUser(DataRow dr, BlogsaUser user)
    {
        user.UserID = Convert.ToInt32(dr["UserID"]);
        user.Email = dr["Email"].ToString();
        user.LastLoginDate = dr["LastLoginDate"] == DBNull.Value ? Convert.ToDateTime(dr["CreateDate"]) : Convert.ToDateTime(dr["LastLoginDate"]);
        user.WebPage = dr["WebPage"].ToString();
        user.Name = dr["Name"].ToString();
        user.UserName = dr["UserName"].ToString();
        user.Role = dr["Role"].ToString();
        user.State = Convert.ToInt16(dr["State"]);
        user.Password = dr["Password"].ToString();
        user.CreateDate = Convert.ToDateTime(dr["CreateDate"]);
    }
}