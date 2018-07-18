﻿using System;
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
using System.Runtime.Serialization;

/// <summary>
/// Summary description for Transport
/// </summary>
public class TransportDM
{

    [Serializable]
    [DataContract]
    public class TransportSectionDM
    {
        [DataMember]
        public int SectionID { get; set; }
        [DataMember]
        public string Section_Name { get; set; }
        [DataMember]
        public string Short_Name { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public DateTime UEDate { get; set; }
        [DataMember]
        public string U_Name { get; set; }
        [DataMember]
        public string Flag { get; set; }
    }

    [Serializable]
    [DataContract]
    public class VehicalRegistrationDM
    {
        [DataMember]
        public int Vehical_ID { get; set; }
        [DataMember]
        public string Vehical_No { get; set; }
        [DataMember]
        public string Vehical_Class { get; set; }
        [DataMember]
        public string Chassis_No { get; set; }
        [DataMember]
        public string Engine_No { get; set; }
        [DataMember]
        public string Makers_Name { get; set; }
        [DataMember]
        public DateTime Registration_Date { get; set; }
        [DataMember]
        public int Manufacture_Year { get; set; }
        [DataMember]
        public string Color { get; set; }
        [DataMember]
        public string Hourse_Power { get; set; }
        [DataMember]
        public string Fuel_Used { get; set; }
        [DataMember]
        public int Capacity { get; set; }
        [DataMember]
        public string Owner_Name { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Contact_No { get; set; }
        [DataMember]
        public string Policy_No { get; set; }
        [DataMember]
        public DateTime Valid_From { get; set; }
        [DataMember]
        public DateTime Valid_To { get; set; }
        [DataMember]
        public DateTime UEDate { get; set; }
        [DataMember]
        public string U_Name { get; set; }
        [DataMember]
        public int Flag { get; set; }
        [DataMember]
        public int Section_ID { get; set; }
        [DataMember]
        public int Reg_Type { get; set; }

    }

    [Serializable]
    [DataContract]
    public class RemarkMDM
    {
        [DataMember]
        public int RemarkID { get; set; }
        [DataMember]
        public string Remark { get; set; }
        [DataMember]
        public string Flag { get; set; }

    }
    [Serializable]
    [DataContract]
    public class DriverMasterDM
    {
        [DataMember]
        public int Driver_ID { get; set; }
        [DataMember]
        public string F_Name { get; set; }
        [DataMember]
        public string M_Name { get; set; }
        [DataMember]
        public string L_Name { get; set; }
        [DataMember]
        public DateTime DOB { get; set; }
        [DataMember]
        public DateTime DOJ { get; set; }
        [DataMember]
        public string Licence_Num { get; set; }
        [DataMember]
        public DateTime Licence_Valid { get; set; }
        [DataMember]
        public string Contact_Num { get; set; }
        [DataMember]
        public DateTime UEDate { get; set; }
        [DataMember]
        public string U_Name { get; set; }
        [DataMember]
        public byte[] Photo { get; set; }
        [DataMember]
        public int Flag { get; set; }
        [DataMember]
        public int Section_ID { get; set; }
    }
    [Serializable]
    [DataContract]
    public class RouteMasterDM
    {
        [DataMember]
        public int RouteID { get; set; }
        [DataMember]
        public string Route_Name { get; set; }
        [DataMember]
        public string Short_Name { get; set; }
        [DataMember]
        public DateTime UEDate { get; set; }
        [DataMember]
        public string UEtime { get; set; }
        [DataMember]
        public string Flag { get; set; }
    }

    [Serializable]
    [DataContract]
    public class RouteSequenceCDM
    {

        [DataMember]
        public int SeqID { get; set; }
        [DataMember]
        public int RouteID { get; set; }
        [DataMember]
        public int Seq_No { get; set; }
        [DataMember]
        public int Distance { get; set; }
        [DataMember]
        public int Flag { get; set; }
        [DataMember]
        public int retSeqID { get; set; }
    }

    [DataContract]
    public class RouteSequenceMDM
    {

        [DataMember]
        public int SeqID { get; set; }
        [DataMember]
        public string Seq_Code { get; set; }
        [DataMember]
        public decimal Fair_Charges { get; set; }
        [DataMember]
        public int Section_ID { get; set; }
        [DataMember]
        public int Vehical_ID { get; set; }
        [DataMember]
        public DateTime UEDate { get; set; }
        [DataMember]
        public string U_Name { get; set; }
        [DataMember]
        public int Flag { get; set; }
    }

    [DataContract]
    public class VehicleAvailibilityDM
    {

        [DataMember]
        public string Vehicle_Num { get; set; }
        [DataMember]
        public int Driver_Name { get; set; }
        [DataMember]
        public string Route_Path { get; set; }
        [DataMember]
        public DateTime UEDate { get; set; }
        [DataMember]
        public string UEtime { get; set; }

    }
    [DataContract]
    public class VehicleBuspassDM
    {
        [DataMember]
        public int BPassID { get; set; }
        [DataMember]
        public string Pass_Num { get; set; }
        [DataMember]
        public string PIssueTo { get; set; }
        [DataMember]
        public string MemberName { get; set; }
        [DataMember]
        public DateTime BPDate { get; set; }
        [DataMember]
        public string BPTime { get; set; }
        [DataMember]
        public int Route_Path { get; set; }
        [DataMember]
        public int Vehical_ID { get; set; }
        [DataMember]
        public DateTime Valid_From { get; set; }
        [DataMember]
        public DateTime Valid_To { get; set; }
        [DataMember]
        public string flag { get; set; }

    }
    [DataContract]
    public class VehicleBuspasschildDM
    {
        [DataMember]
        public int BPCHID { get; set; }
        [DataMember]
        public int BPassID { get; set; }
        [DataMember]
        public string Valid_From { get; set; }
        [DataMember]
        public string Valid_To { get; set; }
        [DataMember]
        public string Charges { get; set; }
        [DataMember]
        public string Total_Charge { get; set; }
        [DataMember]
        public string flag { get; set; }

    }

    [DataContract]
    public class VehicleCheckinMDM
    {

        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public DateTime UEDate { get; set; }
        [DataMember]
        public string UEtime { get; set; }

    }
    [DataContract]
    public class VehicleCheckinSDM
    {

        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string Time { get; set; }
        [DataMember]
        public string Vehicle_Num { get; set; }
        [DataMember]
        public string Route_Path { get; set; }
        [DataMember]
        public string Time_Check { get; set; }
        [DataMember]
        public string Check_In { get; set; }
        [DataMember]
        public DateTime UEDate { get; set; }
        [DataMember]
        public string UEtime { get; set; }

    }
    [DataContract]
    public class VehicleCheckoutDM
    {

        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string Time { get; set; }
        [DataMember]
        public string Vehicle_Num { get; set; }
        [DataMember]
        public string Route_Path { get; set; }
        [DataMember]
        public string Driver_FName { get; set; }
        [DataMember]
        public string Driver_MName { get; set; }
        [DataMember]
        public string Driver_LName { get; set; }
        [DataMember]
        public DateTime Deprature_Time { get; set; }
        [DataMember]
        public DateTime UEDate { get; set; }
        [DataMember]
        public string UEtime { get; set; }

    }

    [Serializable]
    [DataContract]
    public class VehicleScheduleDMM
    {
        [DataMember]
        public int Schedule_ID { get; set; }
        [DataMember]
        public int Route_ID { get; set; }
        [DataMember]
        public int Vehicel_ID { get; set; }
        [DataMember]
        public int MonthID { get; set; }
        [DataMember]
        public int Syear { get; set; }
        [DataMember]
        public int Default_Time_Hr { get; set; }
        [DataMember]
        public int Default_Time_Min { get; set; }
        [DataMember]
        public string Default_Time_TT { get; set; }
        [DataMember]
        public int ReSch_Duration { get; set; }
        [DataMember]
        public int ReSch_Time { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public string U_Name { get; set; }
        [DataMember]
        public DateTime UE_Date { get; set; }
        [DataMember]
        public string Flag { get; set; }
    }

    [Serializable]
    [DataContract]
    public class VehicleScheduleDMC
    {
        [DataMember]
        public int Schedule_ID { get; set; }
        [DataMember]
        public DateTime SDate { get; set; }
        [DataMember]
        public string SDay { get; set; }
        [DataMember]
        public string S_Time { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public string Flag { get; set; }

    }

    [DataContract]
    public class VehicleStandPassDM
    {

        [DataMember]
        public int VehicleID { get; set; }
        [DataMember]
        public string Vehicle_Num { get; set; }
        [DataMember]
        public string Registered_Name { get; set; }
        [DataMember]
        public string Contact_Num { get; set; }
        [DataMember]
        public string Charges { get; set; }
        [DataMember]
        public string Valid_from { get; set; }
        [DataMember]
        public string Valid_to { get; set; }
        [DataMember]
        public string Expired { get; set; }
        [DataMember]
        public string Cencelled { get; set; }
        [DataMember]
        public string Renew { get; set; }
        [DataMember]
        public string Total_amount { get; set; }
        [DataMember]
        public string Pay_mode { get; set; }
        [DataMember]
        public string flag { get; set; }

    }
    [Serializable]
    [DataContract]
    public class VehicleStandPassChildDM
    {
        [DataMember]
        public int VSPCID { get; set; }
        [DataMember]
        public int VehicleID { get; set; }
        [DataMember]
        public string VehicleNo { get; set; }
        [DataMember]
        public DateTime FromDate { get; set; }
        [DataMember]
        public DateTime ToDate { get; set; }
        [DataMember]
        public decimal TotalCharges { get; set; }
        [DataMember]
        public decimal Charges { get; set; }
        [DataMember]
        public string flag { get; set; }
    }
    [Serializable]
    [DataContract]
    public class VehicleNoFill
    {
        [DataMember]
        public int Vehical_ID { get; set; }
        [DataMember]
        public string Vehical_No { get; set; }
    }
    [Serializable]
    [DataContract]
    public class VehicleScheduleChartDate
    {
        [DataMember]
        public DateTime ScheduleDate { get; set; }
    }
    [Serializable]
    [DataContract]
    public class VehicleScheduleChartTime
    {
        [DataMember]
        public string ScheduleTime { get; set; }
    }
    [Serializable]
    [DataContract]
    public class VehicleScheduleList
    {
        [DataMember]
        public string VehicleNo { get; set; }
    }

    [DataContract]
    public class ManufactureMasterDM
    {
        [DataMember]
        public int ManufactureID { get; set; }
        [DataMember]
        public string Manufacture_Name { get; set; }
        [DataMember]
        public string flag { get; set; }
    }

    [DataContract]
    public class VendorMasterDM
    {
        [DataMember]
        public int VendorID { get; set; }
        [DataMember]
        public string Vendor_Name { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Contact_Num { get; set; }
        [DataMember]
        public string flag { get; set; }
    }

    [DataContract]
    public class FuelTypeDM
    {
        [DataMember]
        public int FuelID { get; set; }
        [DataMember]
        public string Fuel_Type { get; set; }
        [DataMember]
        public string Short_Name { get; set; }
        [DataMember]
        public string Measuring_Unit { get; set; }
        [DataMember]
        public string flag { get; set; }
    }

    [DataContract]
    public class FuelChargeDM
    {
        [DataMember]
        public int TypeID { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string Charge { get; set; }
        [DataMember]
        public DateTime Wef_Date { get; set; }
        [DataMember]
        public string flag { get; set; }
    }

    [DataContract]
    public class PartListMasterDM
    {
        [DataMember]
        public int PartID { get; set; }
        [DataMember]
        public string Part_Name { get; set; }
        [DataMember]
        public string Vendor { get; set; }
        [DataMember]
        public string Manufacturer { get; set; }
        [DataMember]
        public string Cost { get; set; }
        [DataMember]
        public DateTime Wef_Date { get; set; }
        [DataMember]
        public string Remark { get; set; }
        [DataMember]
        public string flag { get; set; }
    }

    [DataContract]
    public class ServiceListMasterDM
    {
        [DataMember]
        public int SreviceID { get; set; }
        [DataMember]
        public string Service_Name { get; set; }
        [DataMember]
        public string Frequency { get; set; }
        [DataMember]
        public string Frequency_Type { get; set; }
        [DataMember]
        public DateTime Frequency_Date { get; set; }
        [DataMember]
        public string Frequency_Limit { get; set; }        
        [DataMember]
        public string flag { get; set; }
    }
}