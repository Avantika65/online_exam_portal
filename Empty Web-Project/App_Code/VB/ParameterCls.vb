Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System
Public Class ParameterCls
    Public Enum Reg_Test
        reg_id_1
        reg_date_2
        form_type_3
        form_no_4
        first_name_5
        middle_name_6
        last_name_7
        gender_8
        category_id_9
        dateofbirth_10
        Phone_11
        address_12
        city_id_13
        class_id_14
        prgramme_id_15
        dept_id_16
        test_date_17
        stream_id_18
        receipt_no_21
        cash_chq_dd_22
        chq_dd_no_23
        chq_dd_date_24
        bank_name_25
        amount_26
        entry_date_27
        session_year_28
        user_id_29
        email_31
        mode_pay_32
        isAuditRequired_34
        inst_ID_35
        reg_GID
        St_Image
        Age
        C_dis
        P_dis
        W_need
        P_stream
        M_Name
        F_Name
        reg_id
        Ex_Passed
        Board
        RollN
        P_Year
        Marks
        Per_age
        Schlor_Code
        flag
        Doc_id
        Reciept
        R_Date
    End Enum
    Public Enum ScholarMaster
        scholar_id_1
        Schlor_Code_2
        first_name_3
        middle_name_4
        last_name_5
        dateofbirth_6
        per_address_7
        per_city_id_8
        per_state_id_9
        per_country_id_10
        cur_address_11
        cur_city_id_12
        cur_State_id_13
        cur_country_id_14
        email_15
        Alter_email_16
        gender_17
        caste_category_id_18
        nationality_19
        Last_given_exam_20
        Ent_Year_21
        Percentage_22
        Status_23
        phone_24
        School_name_25
        University_name_26
        University_allot_no_27
        mobile_28
        reg_type_29
        reg_no_30
        student_image_31
        id_1
        scholar_id_2
        Relationship_3
        BS_Scholar_id_4
        BS_enroll_id_5
        flag_6
        id_2
        FileName_3
        FilePath_4
        Stu_Doc_Type_5
        Stu_Doc_Enroll_No_6
        flag_7
    End Enum
    Public Enum AdmissionInfo
        AdmissionInfo_id_1
        Enrollment_2
        Enrollment_date_3
        Scholar_id_4
        Dept_id_5
        Program_id_6
        Stream_id_7
        ClassYS_id_8
        Section_id_9
        Session_year_10
        User_id_11
        Entry_date_12
        Flag_13
        isAuditRequired_14
        reg_id_15
        inst_ID_16
        BatchNo_id_17
        reg_GID
    End Enum
    Public Enum Ad_Info_Registration
        AdmissionInfo_Regis_1
        Enrollment_2
        Enrollment_date_3
        Scholar_id_4
        Dept_id_5
        Program_id_6
        Stream_id_7
        Session_year_8
        User_id_9
        inst_ID_10
        wef_date_11
        universityenrollment_no_12
        tempuniversityenroll_id_13
        reg_id
        reg_GID
        Flag_14
    End Enum
    Public Enum Ad_Info_Registration_C
        AdmissionInfo_Regis_1
        ClassYS_id_2
        Section_id_3
        BatchNo_id_4
        wef_date_5
        Enrollment_6
        AdmissionInfo_Regis_child_7
        Flag_8
    End Enum
    Public Enum Department
        dept_id_1
        dept_name_2
        dept_shortname_3
        entry_date_4
        user_id_5
        session_year_6
        flag_7
        isAuditRequired_8
        inst_ID_9
    End Enum
    Public Enum ProgramCourse
        prg_id_1
        prg_name_2
        prg_shortname_3
        entry_date_4
        user_id_5
        session_year_6
        flag_7
        inst_ID_9
        ProgT_ID_10
        dept_id_11
        totalSem_12
        isAuditRequired_8
    End Enum
    Public Enum Semester
        class_id
        class_name
        class_code
        entry_date
        user_id
        session_year
        flag
        isAuditRequired
        inst_ID
        dept_id
        prg_id
        startDate
        endDate
        progT_id
    End Enum
    Public Enum Subjects
        subject_id_1
        subject_code_2
        subject_name_3
        entry_date_5
        user_id_6
        session_year_7
        flag_8
        isAuditRequired_9
        inst_ID_10
        NP_Daily_11
        NP_Week_12
        TotP_13
        TotM_14
        MInter_15
        MExter_16
        MinM_17
        Weight_18
        MinInter_19
        MinExter_20
        Subtype_21
        dept_id_22
    End Enum
    Public Enum SubjectPaper
        paper_id_1
        paperCode_2
        paperName_3
        paperType_4
        entry_date_5
        user_id_6
        session_year_7
        flag_8
        isAuditRequired_9
        inst_ID_10
        NP_Daily_11
        NP_Week_12
        TotP_13
        TotM_14
        MInter_15
        MExter_16
        MinM_17
        Weight_18
        MinInter_19
        MinExter_20
        subject_id_21
    End Enum
    Public Enum ChequeBounce
        <ComponentModel.Description("ID")> _
        ID
        <ComponentModel.Description("Trans_ID")> _
        Trans_ID
        <ComponentModel.Description("Cheque_No")> _
      Cheque_No
        <ComponentModel.Description("Date_M")> _
      Date_M
        <ComponentModel.Description("Status")> _
      Status
        <ComponentModel.Description("Reason")> _
      Reason
        <ComponentModel.Description("Session")> _
        Session
        <ComponentModel.Description("P_through")> _
      P_through
        <ComponentModel.Description("P_Mode")> _
      P_Mode
        <ComponentModel.Description("Slip_No")> _
      Slip_No
        <ComponentModel.Description("CreditCard_No")> _
      CreditCard_No
        <ComponentModel.Description("Ch_Date")> _
      Ch_Date
        <ComponentModel.Description("Bank_Name")> _
      Bank_Name
        <ComponentModel.Description("Amount")> _
      Amount
    End Enum
 
    Public Enum ChequeNew
        <ComponentModel.Description("Trans_ID")> _
        Trans_ID
        <ComponentModel.Description("Cheque_No")> _
      Cheque_No
        <ComponentModel.Description("NCheque_No")> _
      Date_M
        <ComponentModel.Description("Access_Amt")> _
      Access_Amt
        <ComponentModel.Description("NDate")> _
      NDate
        <ComponentModel.Description("P_Mode")> _
        P_Mode
        <ComponentModel.Description("Amount")> _
        Amount
        <ComponentModel.Description("Bank")> _
       Bank
    End Enum
    Public Enum Refund
        <ComponentModel.Description("FR_ID")> _
        FR_ID
        <ComponentModel.Description("Trans_ID")> _
      Trans_ID
        <ComponentModel.Description("Apply_Date")> _
      Apply_Date
        <ComponentModel.Description("Reason")> _
      Reason
        <ComponentModel.Description("Status")> _
      Status
        <ComponentModel.Description("Doc_ID")> _
        Doc_ID
        <ComponentModel.Description("Doc_Path")> _
        Doc_Path
        <ComponentModel.Description("File_Name")> _
       File_Name
    End Enum
    Public Enum StudentInformation
        <ComponentModel.Description("scholar_id")> _
        scholarID
        <ComponentModel.Description("Schlor_Code")> _
        SchlorCode
        <ComponentModel.Description("first_name")> _
        FirstName
        <ComponentModel.Description("middle_name")> _
        MiddleName
        <ComponentModel.Description("last_name")> _
        last_name
        <ComponentModel.Description("dateofbirth")> _
        dateofbirth
        <ComponentModel.Description("per_address")> _
        AddressP
        <ComponentModel.Description("per_city_id")> _
        CityP
        <ComponentModel.Description("per_state_id")> _
        StateP
        <ComponentModel.Description("per_country_id")> _
        CountryP
        <ComponentModel.Description("cur_address")> _
        AddressC
        <ComponentModel.Description("cur_city_id")> _
        CityC
        <ComponentModel.Description("cur_State_id")> _
        StateC
        <ComponentModel.Description("cur_country_id")> _
        CountryC
        <ComponentModel.Description("email")> _
        Email
        <ComponentModel.Description("Alter_email")> _
        Alter_email
        <ComponentModel.Description("gender")> _
        Gender
        <ComponentModel.Description("caste_category_id")> _
        CastID
        <ComponentModel.Description("nationality")> _
        Nationality
        <ComponentModel.Description("Last_given_exam")> _
        ExamLast
        <ComponentModel.Description("Ent_Year")> _
        Entrance_Year
        <ComponentModel.Description("Percentage")> _
        Percentage
        <ComponentModel.Description("Status")> _
        Status
        <ComponentModel.Description("phone")> _
        Phone
        <ComponentModel.Description("School_name")> _
        SchoolName
        <ComponentModel.Description("University_name")> _
        UniversityName
        <ComponentModel.Description("University_allot_no")> _
        UniAllotNo
        <ComponentModel.Description("mobile")> _
        Mobile
        <ComponentModel.Description("reg_type")> _
        RegType
        <ComponentModel.Description("reg_no")> _
        RegNo
        <ComponentModel.Description("student_image")> _
        Student_Image
        <ComponentModel.Description("Previous_scholar_id")> _
        ScIDPrevious
        <ComponentModel.Description("pre_school_Name")> _
        SNPrevious
        <ComponentModel.Description("Pre_School_Address")> _
        SNPreAddress
        <ComponentModel.Description("Previous_school_City_id")> _
        CityPS
        <ComponentModel.Description("Previous_school_State_id")> _
        PreSStateID
        <ComponentModel.Description("Previous_school_Country_id")> _
        PreSCountryID
        <ComponentModel.Description("Previous_Sch_phone")> _
        PreSPhone
        <ComponentModel.Description("Previous_Sch_email")> _
         PreSEmail
        <ComponentModel.Description("Previous_Sch_website")> _
        PreSWebsite
        <ComponentModel.Description("Previous_Sch_Recognition")> _
        PreSRecognition
        <ComponentModel.Description("Previous_Sch_LastExam")> _
        PreSLastExam
        <ComponentModel.Description("Previous_Sch_Year")> _
        PreSYear
        <ComponentModel.Description("Previous_Sch_Percentage")> _
        PreSPercentage
        <ComponentModel.Description("Previous_Sch_Status")> _
        PreSStatus
        <ComponentModel.Description("Previous_Sch_University")> _
        PreSUniversity
        <ComponentModel.Description("Stu_Doc_EnrollMent")> _
        SDEnroll
        <ComponentModel.Description("Father_Name")> _
        FName
        <ComponentModel.Description("Father_Qualifiaction")> _
        FQualifiaction
        <ComponentModel.Description("Father_occupation")> _
        FOccupation
        <ComponentModel.Description("Father_dept")> _
        FDept
        <ComponentModel.Description("Father_designation")> _
        FDesignation
        <ComponentModel.Description("Father_Income")> _
        FIncome
        <ComponentModel.Description("Father_Office_addr")> _
        FOAddress
        <ComponentModel.Description("Father_Office_city_id")> _
        FOcityID
        <ComponentModel.Description("Father_Office_state_id")> _
        FOStateID
        <ComponentModel.Description("Father_Office_Country_id")> _
        FOCountryID
        <ComponentModel.Description("Father_Phone")> _
        FPhone
        <ComponentModel.Description("Father_Mobile")> _
        FMobile
        <ComponentModel.Description("Father_Email")> _
        FEmail
        <ComponentModel.Description("Mother_Name")> _
        MName
        <ComponentModel.Description("Mother_Qualifiaction")> _
        MQualifiaction
        <ComponentModel.Description("Mother_occupation")> _
        MOccupation
        <ComponentModel.Description("Mother_dept")> _
        MDept
        <ComponentModel.Description("Mother_designation")> _
        MDesignation
        <ComponentModel.Description("Mother_Income")> _
        MIncome
        <ComponentModel.Description("Mother_Office_addr")> _
         MOAddress
        <ComponentModel.Description("Mother_Office_city_id")> _
       MOCityID
        <ComponentModel.Description("Mother_Office_State_id")> _
       MOStateID
        <ComponentModel.Description("Mother_Office_country_id")> _
       MOCountryID
        <ComponentModel.Description("Mother_Phone")> _
       MPhone
        <ComponentModel.Description("Mother_Mobile")> _
       MMobile
        <ComponentModel.Description("Mother_Email")> _
       MEmail
        <ComponentModel.Description("BS_Scholar_Id")> _
       BSScholarID
        <ComponentModel.Description("BS_Enroll_Id")> _
       BSEnrollID
        <ComponentModel.Description("BS_Relationship")> _
        BSRelationship
        <ComponentModel.Description("blood_group")> _
        BGroup
        <ComponentModel.Description("height")> _
        Height
        <ComponentModel.Description("weight")> _
         Weight
        <ComponentModel.Description("dieases")> _
        Dieases
        <ComponentModel.Description("eye_sight_info")> _
        EyeSInfo
        <ComponentModel.Description("session_year")> _
        Session_Y
        <ComponentModel.Description("user_id")> _
        UserID
        <ComponentModel.Description("Login_id")> _
        LoginID
        <ComponentModel.Description("Saltvc")> _
        Saltvc
        <ComponentModel.Description("Password")> _
        Password
        <ComponentModel.Description("C_dis")> _
        C_dis
        <ComponentModel.Description("P_dis")> _
        P_dis
        <ComponentModel.Description("Scat_ID")> _
        Scat_ID
        <ComponentModel.Description("EntEx")> _
        EntEx
        <ComponentModel.Description("Roll")> _
        Roll
        <ComponentModel.Description("Cmerit")> _
        Cmerit
        <ComponentModel.Description("MeritP")> _
        MeritP
        <ComponentModel.Description("FHInfo")> _
        FHInfo
    End Enum
    Public Enum FApproval
        <ComponentModel.Description("Trans_ID")> _
            Trans_ID
        <ComponentModel.Description("Receipt_No")> _
       Receipt_No
        <ComponentModel.Description("Receipt_Date")> _
       Receipt_Date
        <ComponentModel.Description("P_through")> _
       P_through
        <ComponentModel.Description("P_Mode")> _
       P_Mode
        <ComponentModel.Description("Slip_No")> _
       Slip_No
        <ComponentModel.Description("Cheque_No")> _
       Cheque_No
        <ComponentModel.Description("CreditCard_No")> _
       CreditCard_No
        <ComponentModel.Description("Ch_Date")> _
       Ch_Date
        <ComponentModel.Description("Bank_Name")> _
       Bank_Name
        <ComponentModel.Description("Amount")> _
       Amount
        <ComponentModel.Description("Status")> _
       Status
        <ComponentModel.Description("Fr_ID")> _
       Fr_ID
        <ComponentModel.Description("Remark")> _
       Remark

    End Enum
    Public Enum _Institute
        <ComponentModel.Description("Id")> _
        Id
        <ComponentModel.Description("insname")> _
        insname
        <ComponentModel.Description("ShortName")> _
        ShortName
        <ComponentModel.Description("Country")> _
        Country
        <ComponentModel.Description("state")> _
        state
        <ComponentModel.Description("city")> _
        city
        <ComponentModel.Description("District")> _
        District
        <ComponentModel.Description("EsYear")> _
        EsYear
        <ComponentModel.Description("CollegeCategory")> _
        CollegeCategory
        <ComponentModel.Description("Principal")> _
        Principal
        <ComponentModel.Description("CollegeStatus")> _
        CollegeStatus
        <ComponentModel.Description("ResiAddress")> _
        ResiAddress
        <ComponentModel.Description("Phone")> _
        Phone
        <ComponentModel.Description("OfficeNo")> _
        OfficeNo
        <ComponentModel.Description("ResiNo")> _
        ResiNo
        <ComponentModel.Description("Pincode")> _
        pincode
        <ComponentModel.Description("Email")> _
        Email
        <ComponentModel.Description("Fax")> _
        fax
        <ComponentModel.Description("website")> _
        website
        <ComponentModel.Description("DistrictArea")> _
        DistrictArea
        <ComponentModel.Description("StatusPG")> _
        StatusPG
        <ComponentModel.Description("FacultiesName")> _
        FacultiesName
        <ComponentModel.Description("NoOfTeachers")> _
        NoOfTeachers
        <ComponentModel.Description("Datefrom")> _
        Datefrom
        <ComponentModel.Description("Grade")> _
        Grade
        <ComponentModel.Description("Yearfrom")> _
        Yearfrom
        <ComponentModel.Description("fb")> _
        fb
        <ComponentModel.Description("user_id")> _
        user_id
        <ComponentModel.Description("inst_ID")> _
        inst_ID
        <ComponentModel.Description("session_year")> _
        session_year
        <ComponentModel.Description("Date_R")> _
        Date_R
        <ComponentModel.Description("flag")> _
               flag
        <ComponentModel.Description("instLogo")> _
                       instLogo
    End Enum
    Public Enum _Research_P
        <ComponentModel.Description("Id")> _
        Id
        <ComponentModel.Description("Author_N")> _
        Author_N
        <ComponentModel.Description("Dept")> _
        Dept
        <ComponentModel.Description("Title")> _
        Title
        <ComponentModel.Description("Journal_N")> _
        Journal_N
        <ComponentModel.Description("Volume")> _
        Volume
        <ComponentModel.Description("flag")> _
        flag
        <ComponentModel.Description("PP")> _
        PP
        <ComponentModel.Description("Date_R")> _
        Date_R
        <ComponentModel.Description("Inst_ID")> _
        Inst_ID
        
    End Enum

    Public Enum _Project_R
        <ComponentModel.Description("Id")> _
        Id
        <ComponentModel.Description("Tech_N")> _
        Tech_N
        <ComponentModel.Description("Dept")> _
        Dept
        <ComponentModel.Description("Title")> _
        Title
        <ComponentModel.Description("Fund_Agen")> _
        Fund_Agen
        <ComponentModel.Description("Duration")> _
        Duration
        <ComponentModel.Description("flag")> _
        flag
        <ComponentModel.Description("Amt_San   ")> _
        Amt_San
        <ComponentModel.Description("Date_R")> _
        Date_R
        <ComponentModel.Description("Inst_ID")> _
        Inst_ID

    End Enum

    Public Enum _Workshop_O
        <ComponentModel.Description("Id")> _
        Id
        <ComponentModel.Description("Dept_N")> _
        Dept_N
        <ComponentModel.Description("Title")> _
        Title
        <ComponentModel.Description("Fund_Agen")> _
        Fund_Agen
        <ComponentModel.Description("Amt_Sanc")> _
        Amt_Sanc
        <ComponentModel.Description("Date_R")> _
        Date_R
        <ComponentModel.Description("From_T")> _
        From_T
        <ComponentModel.Description("To_T")> _
        To_T
        <ComponentModel.Description("Participant_N")> _
        Participant_N
        <ComponentModel.Description("flag")> _
        flag
        <ComponentModel.Description("Type")> _
        Type
        <ComponentModel.Description("Inst_ID")> _
        Inst_ID

    End Enum

    Public Enum _Workshop_A
        <ComponentModel.Description("Id")> _
        Id
        <ComponentModel.Description("Teacher_N")> _
        Teacher_N
        <ComponentModel.Description("Department")> _
        Department
        <ComponentModel.Description("Title")> _
        Title
        <ComponentModel.Description("Place")> _
        Place
        <ComponentModel.Description("Date_R")> _
        Date_R
        <ComponentModel.Description("From_T")> _
        From_T
        <ComponentModel.Description("To_T")> _
        To_T
        <ComponentModel.Description("Org_N")> _
        Org_N
        <ComponentModel.Description("Typ_R")> _
        Typ_R
        <ComponentModel.Description("flag")> _
        flag
        <ComponentModel.Description("Inst_ID")> _
        Inst_ID

    End Enum


    Public Enum _PhD_A
        <ComponentModel.Description("Id")> _
        Id
        <ComponentModel.Description("Supervisor_N")> _
        Supervisor_N
        <ComponentModel.Description("Department")> _
        Department
        <ComponentModel.Description("Research_N")> _
        Research_N
        <ComponentModel.Description("Thesis_T")> _
        Thesis_T
        <ComponentModel.Description("Award_Yr")> _
        Award_Yr
        <ComponentModel.Description("Date_R")> _
        Date_R
        <ComponentModel.Description("flag")> _
        flag
        <ComponentModel.Description("Inst_ID")> _
        Inst_ID

    End Enum


    Public Enum _Book_W
        <ComponentModel.Description("Id")> _
        Id
        <ComponentModel.Description("Teacher_N  ")> _
        Teacher_N
        <ComponentModel.Description("Department")> _
        Department
        <ComponentModel.Description("Book_N")> _
        Book_N
        <ComponentModel.Description("Publisher")> _
        Publisher
        <ComponentModel.Description("Publication_Yr")> _
        Publication_Yr
        <ComponentModel.Description("Date_R")> _
        Date_R
        <ComponentModel.Description("flag")> _
        flag
        <ComponentModel.Description("Inst_ID")> _
        Inst_ID

    End Enum

    Public Enum _Curri_A
        <ComponentModel.Description("Id")> _
        Id
        <ComponentModel.Description("Event_N")> _
        Event_N
        <ComponentModel.Description("Date_R")> _
        Date_R
        <ComponentModel.Description("From_T")> _
        From_T
        <ComponentModel.Description("To_T")> _
        To_T
        <ComponentModel.Description("PartiColg")> _
        PartiColg
        <ComponentModel.Description("Name")> _
        Name
        <ComponentModel.Description("flag")> _
        flag
        <ComponentModel.Description("Inst_ID")> _
        Inst_ID

    End Enum

    Public Enum _Culture_A
        <ComponentModel.Description("Id")> _
        Id
        <ComponentModel.Description("Student_N")> _
        Student_N
        <ComponentModel.Description("Medal_N")> _
        Medal_N
        <ComponentModel.Description("Meet")> _
        Meet
        <ComponentModel.Description("Date_R")> _
        Date_R
        <ComponentModel.Description("flag")> _
        flag
        <ComponentModel.Description("Inst_ID")> _
        Inst_ID

    End Enum
    Public Enum _Acad_A
        <ComponentModel.Description("Id")> _
        Id
        <ComponentModel.Description("Student_N")> _
        Student_N
        <ComponentModel.Description("Medal_N")> _
        Medal_N
        <ComponentModel.Description("Levels")> _
        Levels
        <ComponentModel.Description("Date_R")> _
        Date_R
        <ComponentModel.Description("flag")> _
        flag
        <ComponentModel.Description("Inst_ID")> _
        Inst_ID

    End Enum
    Public Enum _Assesment
        <ComponentModel.Description("ID")> _
        ID
        <ComponentModel.Description("Ass_ID")> _
        Ass_ID
        <ComponentModel.Description("Exam_ID")> _
        Exam_ID
        <ComponentModel.Description("Inst_ID")> _
      Inst_ID
        <ComponentModel.Description("Session")> _
        Session
       
    End Enum
    Public Enum _Assesment_C
        <ComponentModel.Description("Exam_ID")> _
       ID
        <ComponentModel.Description("Prog_ID")> _
       Prog_ID
        <ComponentModel.Description("Sem_ID")> _
       Sem_ID
        <ComponentModel.Description("Ass_Code")> _
       Ass_Code
        <ComponentModel.Description("Paper_ID")> _
       Paper_ID
        <ComponentModel.Description("Type")> _
        Type
        <ComponentModel.Description("Subject_ID")> _
      SubjectID
        <ComponentModel.Description("Description")> _
      Description
    End Enum
    Public Enum _FeeHead
        <ComponentModel.Description("fee_id")> _
        FeeID
        <ComponentModel.Description("fee_name")> _
       FeeName
        <ComponentModel.Description("applicable")> _
       Applicable
        <ComponentModel.Description("account_head_id")> _
       AccountHead
        <ComponentModel.Description("default_amt")> _
       DefaultAmt
        <ComponentModel.Description("default_frequency_id")> _
       FrequencyID
        <ComponentModel.Description("entry_date")> _
       EntryDate
        <ComponentModel.Description("user_id")> _
       UserID
        <ComponentModel.Description("session_year")> _
       Session
        <ComponentModel.Description("flag")> _
       Flag
        <ComponentModel.Description("inst_ID")> _
       InstID
        <ComponentModel.Description("fee_shortname")> _
       FeeSName
        <ComponentModel.Description("fee_code")> _
       FeeCode
        <ComponentModel.Description("wef_date")> _
       WefDate
        <ComponentModel.Description("f_Type")> _
       FeeType
        <ComponentModel.Description("Due_Date")> _
        DueDate
    End Enum
    Public Enum _GradeMaster
        <ComponentModel.Description("Grade_ID")> _
        GradeID
        <ComponentModel.Description("Abbr")> _
       Abbreviation
        <ComponentModel.Description("Eqv_Division")> _
       Division
        <ComponentModel.Description("WEF_Date")> _
       WefDate
        <ComponentModel.Description("P_From")> _
       PFrom
        <ComponentModel.Description("P_To")> _
       PTo
        <ComponentModel.Description("Scheme_ID")> _
       SchemeID

    End Enum
   
    Public Enum _resource
        <ComponentModel.Description("Id")> _
        Id
        <ComponentModel.Description("ResType")> _
        ResType
        <ComponentModel.Description("ResName")> _
        ResName
        <ComponentModel.Description("Capacity")> _
        Capacity
        <ComponentModel.Description("Loc")> _
        Loc
        <ComponentModel.Description("Description")> _
        Description
        <ComponentModel.Description("UnderPossess")> _
        UnderPossess
        <ComponentModel.Description("AdminisBy")> _
        AdminisBy
        <ComponentModel.Description("flag")> _
        flag
    End Enum
    Public Enum _UserDetails
        <ComponentModel.Description("ID")> _
        ID
        <ComponentModel.Description("usertype")> _
       usertype
        <ComponentModel.Description("userid")> _
       userid
        <ComponentModel.Description("password")> _
       password
        <ComponentModel.Description("ins_id")> _
       ins_id
        <ComponentModel.Description("SaltVc")> _
       SaltVc
        <ComponentModel.Description("Status")> _
       Status
        <ComponentModel.Description("Emp_id")> _
       Emp_id
        <ComponentModel.Description("ipaddress")> _
       ipaddress
        <ComponentModel.Description("fromdate")> _
              fromdate
        <ComponentModel.Description("todate")> _
       todate
    End Enum
    Public Enum _AcdSession
        <ComponentModel.Description("AcademicSession")> _
        AcademicSession
        <ComponentModel.Description("StartDate")> _
       StartDate
        <ComponentModel.Description("Enddate")> _
       Enddate
        <ComponentModel.Description("OtherLeterCurrentPosition")> _
       OtherLeterCurrentPosition
        <ComponentModel.Description("Id")> _
       Id
        <ComponentModel.Description("instID")> _
       instID
        <ComponentModel.Description("flg")> _
       flg
    End Enum
    Public Enum _Loc
        <ComponentModel.Description("Id")> _
        Id
        <ComponentModel.Description("Id")> _
        Res_id
        <ComponentModel.Description("Locatn")> _
        Locatn
        <ComponentModel.Description("Build")> _
 Build
        <ComponentModel.Description("Almirah")> _
Almirah
        <ComponentModel.Description("Flor")> _
   Flor
        <ComponentModel.Description("Rak")> _
 Rak
        <ComponentModel.Description("Description")> _
Description
        <ComponentModel.Description("flag")> _
   flag
    End Enum
    Public Enum _CurrentStats
        <ComponentModel.Description("Id")> _
        Id
        <ComponentModel.Description("Status")> _
        Status
        <ComponentModel.Description("RDat")> _
        RDat
        <ComponentModel.Description("RTim")> _
        RTim
        <ComponentModel.Description("Declre")> _
        Declre
        <ComponentModel.Description("Remark")> _
        Remark
        <ComponentModel.Description("flag")> _
        flag
    End Enum

    Public Enum _Warrnt
        <ComponentModel.Description("Id")> _
        Id
        <ComponentModel.Description("Id")> _
        Res_id
        <ComponentModel.Description("Vendr")> _
        Vendr
        <ComponentModel.Description("RDat")> _
        RDat
        <ComponentModel.Description("TDat")> _
        TDat
        <ComponentModel.Description("Amout")> _
        Amout
        <ComponentModel.Description("Atach")> _
        Atach
        <ComponentModel.Description("Remark")> _
        Remark
        <ComponentModel.Description("RType")> _
        RType
        <ComponentModel.Description("flag")> _
        flag
    End Enum

    Public Enum _Utili
        <ComponentModel.Description("Id")> _
        Id
        <ComponentModel.Description("Usr")> _
        Usr
        <ComponentModel.Description("RDat")> _
        RDat
        <ComponentModel.Description("FTim")> _
        FTim
        <ComponentModel.Description("TTim")> _
        TTim
        <ComponentModel.Description("Remark")> _
        Remark
        <ComponentModel.Description("RType")> _
        RType
        <ComponentModel.Description("flag")> _
        flag
    End Enum

    Public Enum _ChangLoc
        <ComponentModel.Description("Id")> _
        Id
        <ComponentModel.Description("Location")> _
        Location
        <ComponentModel.Description("RDat")> _
        RDat
        <ComponentModel.Description("Remark")> _
        Remark
        <ComponentModel.Description("flag")> _
        flag
    End Enum

    Public Enum _Resrv
        <ComponentModel.Description("Id")> _
        Id
        <ComponentModel.Description("Vendr")> _
        Vendr
        <ComponentModel.Description("RDat")> _
        RDat
        <ComponentModel.Description("TDat")> _
        TDat
        <ComponentModel.Description("Amout")> _
        Amout
        <ComponentModel.Description("Atach")> _
        Atach
        <ComponentModel.Description("Remark")> _
        Remark
        <ComponentModel.Description("RType")> _
        RType
        <ComponentModel.Description("flag")> _
        flag
    End Enum

    Public Enum _ResAval
        <ComponentModel.Description("Id")> _
        Id
        <ComponentModel.Description("Vendr")> _
        Vendr
        <ComponentModel.Description("RDat")> _
        RDat
        <ComponentModel.Description("TDat")> _
        TDat
        <ComponentModel.Description("Amout")> _
        Amout
        <ComponentModel.Description("Atach")> _
        Atach
        <ComponentModel.Description("Remark")> _
        Remark
        <ComponentModel.Description("RType")> _
        RType
        <ComponentModel.Description("flag")> _
        flag
    End Enum
    Public Enum FacultyEval
        <ComponentModel.Description("ID")> _
               ID
        <ComponentModel.Description("Emp_id")> _
       Emp_id
        <ComponentModel.Description("Student_ID")> _
       Student_ID
        <ComponentModel.Description("Prg_ID")> _
       Prg_ID
        <ComponentModel.Description("Inst_ID")> _
       Inst_ID
        <ComponentModel.Description("Session")> _
       Session
        <ComponentModel.Description("Rank_Type")> _
       Rank_Type
        <ComponentModel.Description("Ques_ID")> _
              Ques_ID
        <ComponentModel.Description("Subject_ID")> _
      Subject_ID
        <ComponentModel.Description("Rate")> _
      Rate
    End Enum
    Public Enum Subpaper
        <ComponentModel.Description("id")> _
        id
        <ComponentModel.Description("subject_name")> _
        subject_name
        <ComponentModel.Description("paper")> _
        paper
        <ComponentModel.Description("intro")> _
        intro
        <ComponentModel.Description("object")> _
        _object
        <ComponentModel.Description("Reading")> _
        reading
        <ComponentModel.Description("refer")> _
        refer
        <ComponentModel.Description("Inst_ID")> _
        Inst_ID
        <ComponentModel.Description("user_ID")> _
         user_ID
        <ComponentModel.Description("Session_year")> _
        Session_year
        <ComponentModel.Description("flag")> _
        flag

    End Enum
 Public Enum _syllabs
        <ComponentModel.Description("Id")> _
        Id
        <ComponentModel.Description("DeptID")> _
        DeptID
        <ComponentModel.Description("CourseName")> _
        CourseName
        <ComponentModel.Description("Clas")> _
        Clas
        <ComponentModel.Description("SubType")> _
        SubType
        <ComponentModel.Description("SubName")> _
        SubName
        <ComponentModel.Description("Topic")> _
        Topic
        <ComponentModel.Description("Untopic")> _
        Untopic
        <ComponentModel.Description("Day")> _
        Day
        <ComponentModel.Description("Typeofperiod")> _
        typeofperoid
        <ComponentModel.Description("StartD")> _
        StartD
        <ComponentModel.Description("flag")> _
        flag
        <ComponentModel.Description("Untopic_id")> _
        untopic_id

    End Enum
    Public Enum _SyllabsC
        <ComponentModel.Description("Id")> _
        Id
        <ComponentModel.Description("SubId")> _
        SubId
        <ComponentModel.Description("subject_id")> _
        subject_id
        <ComponentModel.Description("Top")> _
        Top
        <ComponentModel.Description("Untopic")> _
        untopic
        <ComponentModel.Description("Instructor")> _
        Instructor
        <ComponentModel.Description("Periods")> _
        Periods
        <ComponentModel.Description("Typeofperiod")> _
        typeofperiod
        <ComponentModel.Description("SDate")> _
        SDate
        <ComponentModel.Description("CompletionD")> _
        CompletionD
        <ComponentModel.Description("Remark")> _
        Remark
        <ComponentModel.Description("flag")> _
        flag
    End Enum
    Public Enum _Intrvw
        <ComponentModel.Description("Id")> _
        Id
        <ComponentModel.Description("RegCod")> _
        RegCod
        <ComponentModel.Description("LateSubDat")> _
        LateSubDat
        <ComponentModel.Description("Mark")> _
        Mark
        <ComponentModel.Description("AdmisAllow")> _
        AdmisAllow
        <ComponentModel.Description("DocID")> _
        DocID
        <ComponentModel.Description("DocName")> _
        DocName
        <ComponentModel.Description("Stats")> _
        Stats
        <ComponentModel.Description("flag")> _
        flag
    End Enum
    Public Enum _comp
        <ComponentModel.Description("Id")> _
        Id
        <ComponentModel.Description("CompName")> _
        CompName
        <ComponentModel.Description("VisitPerson")> _
        VisitPerson
        <ComponentModel.Description("Phone")> _
        Phone
        <ComponentModel.Description("Email")> _
        Email
        <ComponentModel.Description("WebSite")> _
        WebSite
        <ComponentModel.Description("VisitDate")> _
        VisitDate
        <ComponentModel.Description("Time")> _
        Time
        <ComponentModel.Description("flag")> _
        flag
    End Enum

    Public Enum _Res
        <ComponentModel.Description("Id")> _
        Id
        <ComponentModel.Description("ResourceTyp")> _
        ResourceTyp
        <ComponentModel.Description("ResourceCod")> _
        ResourceCod
        <ComponentModel.Description("flag")> _
        flag
    End Enum
    Public Enum _TimeTable
        <ComponentModel.Description("Scheme_ID")> _
              Scheme_ID
        <ComponentModel.Description("Format_ID")> _
              Format_ID
        <ComponentModel.Description("Sart_Time")> _
              Sart_Time
        <ComponentModel.Description("End_Time")> _
              End_Time
        <ComponentModel.Description("Lunch_Time")> _
              Lunch_Time
        <ComponentModel.Description("Lunch_End")> _
              Lunch_End
        <ComponentModel.Description("Total_Period")> _
              Total_Period
        <ComponentModel.Description("Total_Pract")> _
              Total_Pract
        <ComponentModel.Description("Lunch_After")> _
              Lunch_After
        <ComponentModel.Description("Exclude_W")> _
              Exclude_W
        <ComponentModel.Description("Inst_ID")> _
              Inst_ID
        <ComponentModel.Description("Session")> _
              Session
        <ComponentModel.Description("Period_Len")> _
              Period_Len
    End Enum
    Public Enum _UtilM
        <ComponentModel.Description("Id")> _
        Id
        <ComponentModel.Description("UtilityN")> _
        UtilityN
        <ComponentModel.Description("UtilityC")> _
        UtilityC
        <ComponentModel.Description("UtilWEF")> _
        UtilWEF
        <ComponentModel.Description("TypeOfQuarter")> _
        TypeOfQuarter
        <ComponentModel.Description("MinChrge")> _
        MinChrge
        <ComponentModel.Description("UnitRate")> _
        UnitRate
        <ComponentModel.Description("ServiceTax")> _
        ServiceTax
        <ComponentModel.Description("CessChrge")> _
        CessChrge
        <ComponentModel.Description("flag")> _
        flag
    End Enum
    Public Enum _UtiliS
        <ComponentModel.Description("Id")> _
        Id
        <ComponentModel.Description("UtilityN")> _
        UtilityN
        <ComponentModel.Description("UtilityC")> _
        UtilityC
        <ComponentModel.Description("UtilWEF")> _
        UtilWEF
        <ComponentModel.Description("FDate")> _
        FDate
        <ComponentModel.Description("TDate")> _
        TDate
        <ComponentModel.Description("Remark")> _
        Remark
        <ComponentModel.Description("flag")> _
        flag
    End Enum
    Public Enum _UtiliSUse
        <ComponentModel.Description("Id")> _
        Id
        <ComponentModel.Description("Deptmnt")> _
        Deptmnt
        <ComponentModel.Description("Employee")> _
        Employee
        <ComponentModel.Description("Utility")> _
        Utility
        <ComponentModel.Description("UnitCode")> _
        UnitCode
        <ComponentModel.Description("Unit")> _
        Unit
        <ComponentModel.Description("UnitRate")> _
        UnitRate
        <ComponentModel.Description("Amont")> _
        Amont
        <ComponentModel.Description("flag")> _
        flag
    End Enum
    Public Enum _compDB
        <ComponentModel.Description("Id")> _
        Id
        <ComponentModel.Description("CompName")> _
        CompName
        <ComponentModel.Description("Directr")> _
        Directr
        <ComponentModel.Description("Phone")> _
        Phone
        <ComponentModel.Description("WebSite")> _
        WebSite
        <ComponentModel.Description("Addres")> _
        Addres
        <ComponentModel.Description("Descript")> _
        Descript
        <ComponentModel.Description("flag")> _
        flag
    End Enum
    Public Enum _FeeTrans
        <ComponentModel.Description("FeeheadTransaction_id")> _
           FHeadTrans
        <ComponentModel.Description("fee_id_")> _
          Fee_id
        <ComponentModel.Description("stream_id")> _
          Stream_id
        <ComponentModel.Description("prg_id")> _
          Prg_id
        <ComponentModel.Description("category_id")> _
          Category_id
        <ComponentModel.Description("gender")> _
          Gender
        <ComponentModel.Description("class_id")> _
          Class_id
        <ComponentModel.Description("section_id")> _
         Section_id
        <ComponentModel.Description("student")> _
         Student
        <ComponentModel.Description("entry_date")> _
          Entry_date
        <ComponentModel.Description("uid")> _
          Uid
        <ComponentModel.Description("session_year")> _
         Session_year
        <ComponentModel.Description("flag")> _
          Flag
        <ComponentModel.Description("isAuditRequired")> _
         IsAuditRequired
        <ComponentModel.Description("document_no")> _
          DocN
        <ComponentModel.Description("amount")> _
          Amount
        <ComponentModel.Description("inst_ID")> _
          Inst_ID
        <ComponentModel.Description("effective_date")> _
          Effective_date
        <ComponentModel.Description("scholar_id")> _
          Scholar_id
        <ComponentModel.Description("enrollment_id")> _
          Enrollment_id
        <ComponentModel.Description("fee_scheduleing_id")> _
           Fee_scheduleing_id
        <ComponentModel.Description("FeeAssementCode")> _
          FeeAssementCode
        <ComponentModel.Description("IncludeFee")> _
         IncludeFee
    End Enum
    Public Enum _FeeTransC
        <ComponentModel.Description("Fee_HeadTran_Id")> _
                  Fee_HeadTran_Id
        <ComponentModel.Description("Fee_Head_Id")> _
                 Fee_Id
        <ComponentModel.Description("Fee_Month")> _
                 Fee_Month
        <ComponentModel.Description("Amount")> _
                 Amount
        <ComponentModel.Description("Trans_Date")> _
                 Trans_Date
        <ComponentModel.Description("Flag")> _
                 Flag
        <ComponentModel.Description("Session_year")> _
                 Session_year
        <ComponentModel.Description("user_id")> _
                 user_id
        <ComponentModel.Description("Ins_id")> _
                 Ins_id
        <ComponentModel.Description("f")> _
                 f
    End Enum
End Class
