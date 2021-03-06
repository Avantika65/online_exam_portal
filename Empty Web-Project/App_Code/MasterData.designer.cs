﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;



[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="EduSuite")]
public partial class MasterDataDataContext : System.Data.Linq.DataContext
{
	
	private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
	
  #region Extensibility Method Definitions
  partial void OnCreated();
  #endregion
	
	public MasterDataDataContext() : 
			base(global::System.Configuration.ConfigurationManager.ConnectionStrings["EduSuiteConnectionString1"].ConnectionString, mappingSource)
	{
		OnCreated();
	}
	
	public MasterDataDataContext(string connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public MasterDataDataContext(System.Data.IDbConnection connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public MasterDataDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public MasterDataDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public System.Data.Linq.Table<CourseM> CourseMs
	{
		get
		{
			return this.GetTable<CourseM>();
		}
	}
	
	public System.Data.Linq.Table<Session> Sessions
	{
		get
		{
			return this.GetTable<Session>();
		}
	}
	
	public System.Data.Linq.Table<City> Cities
	{
		get
		{
			return this.GetTable<City>();
		}
	}
	
	private void InsertCourseM(CourseM obj)
	{
		this.GetCourse(((System.Nullable<int>)(obj.InstituteID)));
	}
	
	private void InsertCity(City obj)
	{
		this.FillCity();
	}
	
	[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetCourse")]
	public ISingleResult<GetCourseResult> GetCourse([global::System.Data.Linq.Mapping.ParameterAttribute(Name="InstituteID", DbType="Int")] System.Nullable<int> instituteID)
	{
		IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), instituteID);
		return ((ISingleResult<GetCourseResult>)(result.ReturnValue));
	}
	
	[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.FillCity")]
	public ISingleResult<FillCityResult> FillCity()
	{
		IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
		return ((ISingleResult<FillCityResult>)(result.ReturnValue));
	}
	
	[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetCourseBatch")]
	public ISingleResult<GetCourseBatchResult> GetCourseBatch([global::System.Data.Linq.Mapping.ParameterAttribute(Name="InstituteID", DbType="Int")] System.Nullable<int> instituteID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="CourseID", DbType="Int")] System.Nullable<int> courseID)
	{
		IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), instituteID, courseID);
		return ((ISingleResult<GetCourseBatchResult>)(result.ReturnValue));
	}
	
	[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetSemester")]
	public ISingleResult<GetSemesterResult> GetSemester([global::System.Data.Linq.Mapping.ParameterAttribute(Name="CourseID", DbType="Int")] System.Nullable<int> courseID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Batch", DbType="NVarChar(50)")] string batch, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Type", DbType="NVarChar(1)")] System.Nullable<char> type)
	{
		IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), courseID, batch, type);
		return ((ISingleResult<GetSemesterResult>)(result.ReturnValue));
	}
	
	[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetSession")]
	public ISingleResult<GetSessionResult> GetSession([global::System.Data.Linq.Mapping.ParameterAttribute(Name="BatchID", DbType="NVarChar(50)")] string batchID, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> instituteid)
	{
		IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), batchID, instituteid);
		return ((ISingleResult<GetSessionResult>)(result.ReturnValue));
	}
	
	[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetYear")]
	public ISingleResult<GetYearResult> GetYear([global::System.Data.Linq.Mapping.ParameterAttribute(Name="CourseID", DbType="Int")] System.Nullable<int> courseID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Batch", DbType="NVarChar(50)")] string batch, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Type", DbType="NVarChar(1)")] System.Nullable<char> type)
	{
		IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), courseID, batch, type);
		return ((ISingleResult<GetYearResult>)(result.ReturnValue));
	}
	
	[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetInstitute")]
	public ISingleResult<GetInstituteResult> GetInstitute()
	{
		IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
		return ((ISingleResult<GetInstituteResult>)(result.ReturnValue));
	}
	
	[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.FillYear_Semester")]
	public ISingleResult<FillYear_SemesterResult> FillYear_Semester([global::System.Data.Linq.Mapping.ParameterAttribute(Name="CourseID", DbType="Int")] System.Nullable<int> courseID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Batch", DbType="NVarChar(50)")] string batch, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Session", DbType="NVarChar(50)")] string session)
	{
		IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), courseID, batch, session);
		return ((ISingleResult<FillYear_SemesterResult>)(result.ReturnValue));
	}
	
	[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.FillSemesterByYear")]
	public ISingleResult<FillSemesterByYearResult> FillSemesterByYear([global::System.Data.Linq.Mapping.ParameterAttribute(Name="CourseID", DbType="Int")] System.Nullable<int> courseID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Batch", DbType="NVarChar(50)")] string batch, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Session", DbType="NVarChar(50)")] string session, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="YearID", DbType="NVarChar(50)")] string yearID)
	{
		IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), courseID, batch, session, yearID);
		return ((ISingleResult<FillSemesterByYearResult>)(result.ReturnValue));
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Course")]
public partial class CourseM
{
	
	private int _CourseId;
	
	private string _CourseName;
	
	private string _ShortName;
	
	private string _CourseNature;
	
	private System.Nullable<int> _CourseDuration;
	
	private System.Nullable<int> _SpecialisationID;
	
	private System.Nullable<int> _InstituteID;
	
	private string _Active;
	
	private string _Type;
	
	private string _DepartmentID;
	
	private System.Nullable<int> _NOS;
	
	private System.Nullable<int> _EXS;
	
	public CourseM()
	{
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CourseId", DbType="Int NOT NULL")]
	public int CourseId
	{
		get
		{
			return this._CourseId;
		}
		set
		{
			if ((this._CourseId != value))
			{
				this._CourseId = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CourseName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
	public string CourseName
	{
		get
		{
			return this._CourseName;
		}
		set
		{
			if ((this._CourseName != value))
			{
				this._CourseName = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ShortName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
	public string ShortName
	{
		get
		{
			return this._ShortName;
		}
		set
		{
			if ((this._ShortName != value))
			{
				this._ShortName = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CourseNature", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
	public string CourseNature
	{
		get
		{
			return this._CourseNature;
		}
		set
		{
			if ((this._CourseNature != value))
			{
				this._CourseNature = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CourseDuration", DbType="Int")]
	public System.Nullable<int> CourseDuration
	{
		get
		{
			return this._CourseDuration;
		}
		set
		{
			if ((this._CourseDuration != value))
			{
				this._CourseDuration = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SpecialisationID", DbType="Int")]
	public System.Nullable<int> SpecialisationID
	{
		get
		{
			return this._SpecialisationID;
		}
		set
		{
			if ((this._SpecialisationID != value))
			{
				this._SpecialisationID = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InstituteID", DbType="Int")]
	public System.Nullable<int> InstituteID
	{
		get
		{
			return this._InstituteID;
		}
		set
		{
			if ((this._InstituteID != value))
			{
				this._InstituteID = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Active", DbType="NVarChar(10)")]
	public string Active
	{
		get
		{
			return this._Active;
		}
		set
		{
			if ((this._Active != value))
			{
				this._Active = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Type", DbType="NVarChar(10)")]
	public string Type
	{
		get
		{
			return this._Type;
		}
		set
		{
			if ((this._Type != value))
			{
				this._Type = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DepartmentID", DbType="NVarChar(50)")]
	public string DepartmentID
	{
		get
		{
			return this._DepartmentID;
		}
		set
		{
			if ((this._DepartmentID != value))
			{
				this._DepartmentID = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NOS", DbType="Int")]
	public System.Nullable<int> NOS
	{
		get
		{
			return this._NOS;
		}
		set
		{
			if ((this._NOS != value))
			{
				this._NOS = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EXS", DbType="Int")]
	public System.Nullable<int> EXS
	{
		get
		{
			return this._EXS;
		}
		set
		{
			if ((this._EXS != value))
			{
				this._EXS = value;
			}
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Session")]
public partial class Session
{
	
	private int _SessionID;
	
	private string _Session1;
	
	private System.Nullable<System.DateTime> _StartDate;
	
	private System.Nullable<System.DateTime> _EndDate;
	
	private System.Nullable<int> _InstID;
	
	private string _Active;
	
	public Session()
	{
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SessionID", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
	public int SessionID
	{
		get
		{
			return this._SessionID;
		}
		set
		{
			if ((this._SessionID != value))
			{
				this._SessionID = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Name="Session", Storage="_Session1", DbType="NVarChar(50)")]
	public string Session1
	{
		get
		{
			return this._Session1;
		}
		set
		{
			if ((this._Session1 != value))
			{
				this._Session1 = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StartDate", DbType="DateTime")]
	public System.Nullable<System.DateTime> StartDate
	{
		get
		{
			return this._StartDate;
		}
		set
		{
			if ((this._StartDate != value))
			{
				this._StartDate = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EndDate", DbType="DateTime")]
	public System.Nullable<System.DateTime> EndDate
	{
		get
		{
			return this._EndDate;
		}
		set
		{
			if ((this._EndDate != value))
			{
				this._EndDate = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InstID", DbType="Int")]
	public System.Nullable<int> InstID
	{
		get
		{
			return this._InstID;
		}
		set
		{
			if ((this._InstID != value))
			{
				this._InstID = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Active", DbType="NVarChar(50)")]
	public string Active
	{
		get
		{
			return this._Active;
		}
		set
		{
			if ((this._Active != value))
			{
				this._Active = value;
			}
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.City")]
public partial class City
{
	
	private int _CityId;
	
	private string _CityName;
	
	private int _StateID;
	
	private string _UName;
	
	private System.Nullable<System.DateTime> _UEntDt;
	
	public City()
	{
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CityId", DbType="Int NOT NULL")]
	public int CityId
	{
		get
		{
			return this._CityId;
		}
		set
		{
			if ((this._CityId != value))
			{
				this._CityId = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CityName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
	public string CityName
	{
		get
		{
			return this._CityName;
		}
		set
		{
			if ((this._CityName != value))
			{
				this._CityName = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StateID", DbType="Int NOT NULL")]
	public int StateID
	{
		get
		{
			return this._StateID;
		}
		set
		{
			if ((this._StateID != value))
			{
				this._StateID = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UName", DbType="VarChar(10)")]
	public string UName
	{
		get
		{
			return this._UName;
		}
		set
		{
			if ((this._UName != value))
			{
				this._UName = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UEntDt", DbType="DateTime")]
	public System.Nullable<System.DateTime> UEntDt
	{
		get
		{
			return this._UEntDt;
		}
		set
		{
			if ((this._UEntDt != value))
			{
				this._UEntDt = value;
			}
		}
	}
}

public partial class State : City
{
	
	private int _StateId;
	
	private int _CountryId;
	
	private string _StateName;
	
	private string _UName;
	
	private System.Nullable<System.DateTime> _UEntDt;
	
	public State()
	{
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StateId", DbType="Int NOT NULL")]
	public int StateId
	{
		get
		{
			return this._StateId;
		}
		set
		{
			if ((this._StateId != value))
			{
				this._StateId = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CountryId", DbType="Int NOT NULL")]
	public int CountryId
	{
		get
		{
			return this._CountryId;
		}
		set
		{
			if ((this._CountryId != value))
			{
				this._CountryId = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StateName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
	public string StateName
	{
		get
		{
			return this._StateName;
		}
		set
		{
			if ((this._StateName != value))
			{
				this._StateName = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UName", DbType="VarChar(10)")]
	public string UName
	{
		get
		{
			return this._UName;
		}
		set
		{
			if ((this._UName != value))
			{
				this._UName = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UEntDt", DbType="DateTime")]
	public System.Nullable<System.DateTime> UEntDt
	{
		get
		{
			return this._UEntDt;
		}
		set
		{
			if ((this._UEntDt != value))
			{
				this._UEntDt = value;
			}
		}
	}
}

public partial class Country : State
{
	
	private int _CountryId;
	
	private string _CountryName;
	
	private string _UName;
	
	private System.Nullable<System.DateTime> _UEntDt;
	
	public Country()
	{
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CountryId", DbType="Int NOT NULL")]
	public int CountryId
	{
		get
		{
			return this._CountryId;
		}
		set
		{
			if ((this._CountryId != value))
			{
				this._CountryId = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CountryName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
	public string CountryName
	{
		get
		{
			return this._CountryName;
		}
		set
		{
			if ((this._CountryName != value))
			{
				this._CountryName = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UName", DbType="VarChar(10)")]
	public string UName
	{
		get
		{
			return this._UName;
		}
		set
		{
			if ((this._UName != value))
			{
				this._UName = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UEntDt", DbType="DateTime")]
	public System.Nullable<System.DateTime> UEntDt
	{
		get
		{
			return this._UEntDt;
		}
		set
		{
			if ((this._UEntDt != value))
			{
				this._UEntDt = value;
			}
		}
	}
}

public partial class GetCourseResult
{
	
	private int _courseid;
	
	private string _coursename;
	
	public GetCourseResult()
	{
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_courseid", DbType="Int NOT NULL")]
	public int courseid
	{
		get
		{
			return this._courseid;
		}
		set
		{
			if ((this._courseid != value))
			{
				this._courseid = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_coursename", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
	public string coursename
	{
		get
		{
			return this._coursename;
		}
		set
		{
			if ((this._coursename != value))
			{
				this._coursename = value;
			}
		}
	}
}

public partial class FillCityResult
{
	
	private int _CityId;
	
	private string _CityName;
	
	public FillCityResult()
	{
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CityId", DbType="Int NOT NULL")]
	public int CityId
	{
		get
		{
			return this._CityId;
		}
		set
		{
			if ((this._CityId != value))
			{
				this._CityId = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CityName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
	public string CityName
	{
		get
		{
			return this._CityName;
		}
		set
		{
			if ((this._CityName != value))
			{
				this._CityName = value;
			}
		}
	}
}

public partial class GetCourseBatchResult
{
	
	private string _Batchcode;
	
	public GetCourseBatchResult()
	{
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Batchcode", DbType="VarChar(10)")]
	public string Batchcode
	{
		get
		{
			return this._Batchcode;
		}
		set
		{
			if ((this._Batchcode != value))
			{
				this._Batchcode = value;
			}
		}
	}
}

public partial class GetSemesterResult
{
	
	private int _Semestern;
	
	private int _Semesterid;
	
	public GetSemesterResult()
	{
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Semestern", DbType="Int NOT NULL")]
	public int Semestern
	{
		get
		{
			return this._Semestern;
		}
		set
		{
			if ((this._Semestern != value))
			{
				this._Semestern = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Semesterid", DbType="Int NOT NULL")]
	public int Semesterid
	{
		get
		{
			return this._Semesterid;
		}
		set
		{
			if ((this._Semesterid != value))
			{
				this._Semesterid = value;
			}
		}
	}
}

public partial class GetSessionResult
{
	
	private string _sessionyear;
	
	public GetSessionResult()
	{
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sessionyear", DbType="NVarChar(100)")]
	public string sessionyear
	{
		get
		{
			return this._sessionyear;
		}
		set
		{
			if ((this._sessionyear != value))
			{
				this._sessionyear = value;
			}
		}
	}
}

public partial class GetYearResult
{
	
	private string _Yr;
	
	private int _yearid;
	
	public GetYearResult()
	{
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Yr", DbType="NVarChar(57)")]
	public string Yr
	{
		get
		{
			return this._Yr;
		}
		set
		{
			if ((this._Yr != value))
			{
				this._Yr = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_yearid", DbType="Int NOT NULL")]
	public int yearid
	{
		get
		{
			return this._yearid;
		}
		set
		{
			if ((this._yearid != value))
			{
				this._yearid = value;
			}
		}
	}
}

public partial class GetInstituteResult
{
	
	private string _Collegeid;
	
	private string _collegename;
	
	public GetInstituteResult()
	{
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Collegeid", DbType="VarChar(2) NOT NULL", CanBeNull=false)]
	public string Collegeid
	{
		get
		{
			return this._Collegeid;
		}
		set
		{
			if ((this._Collegeid != value))
			{
				this._Collegeid = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_collegename", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
	public string collegename
	{
		get
		{
			return this._collegename;
		}
		set
		{
			if ((this._collegename != value))
			{
				this._collegename = value;
			}
		}
	}
}

public partial class FillYear_SemesterResult
{
	
	private string _Yr;
	
	private string _yearid;
	
	public FillYear_SemesterResult()
	{
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Yr", DbType="NVarChar(57)")]
	public string Yr
	{
		get
		{
			return this._Yr;
		}
		set
		{
			if ((this._Yr != value))
			{
				this._Yr = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_yearid", DbType="NVarChar(50)")]
	public string yearid
	{
		get
		{
			return this._yearid;
		}
		set
		{
			if ((this._yearid != value))
			{
				this._yearid = value;
			}
		}
	}
}

public partial class FillSemesterByYearResult
{
	
	private string _Semester;
	
	private int _SemesterID;
	
	public FillSemesterByYearResult()
	{
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Semester", DbType="NVarChar(57)")]
	public string Semester
	{
		get
		{
			return this._Semester;
		}
		set
		{
			if ((this._Semester != value))
			{
				this._Semester = value;
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SemesterID", DbType="Int NOT NULL")]
	public int SemesterID
	{
		get
		{
			return this._SemesterID;
		}
		set
		{
			if ((this._SemesterID != value))
			{
				this._SemesterID = value;
			}
		}
	}
}
#pragma warning restore 1591
