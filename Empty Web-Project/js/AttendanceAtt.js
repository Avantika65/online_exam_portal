window.onload = init;
var result_value;
var session;
var Mname;
var FromDate;
var ToDate;
var Year;
var prevrow = "rc0";
var del_id = "";
var inserted_row_id = "0";
var empidvalue="0";
var employee_code;

function init() {
    PayRoll_Details.Attendance_Page_Load_details(Fill_Payroll_details_bind);
}


function Fill_Payroll_details_bind(result) {
     result_value = result.split('&');
     session=result_value[0];
     Mname=result_value[1];
     FromDate=result_value[2];
     ToDate=result_value[3];
     Year = result_value[4];
    var ddlYear = document.getElementById("ddlYear");
 
    var ddlYear1 = document.getElementById("ddlYear1");

    var ddlMon = document.getElementById("ddlMon");

    var txtWorkDays = document.getElementById("txtWorkDays");
   
    var btnSubmit = document.getElementById("btnSubmit");

    var btnSalCalc = document.getElementById("btnSalCalc");

    if (Number(Mname) >= 3)
    {
        btnSalCalc.disabled = true;        
    }
    else    
    {
        btnSalCalc.disabled = false;
    }

   
    for (var count = ddlYear.options.length - 1; count > -1; count--) {
        ddlYear.options[count] = null;
    }
   
    var val;
    var desc;
    var optionitem1;
    val = "0";
    desc = "----Select----";
    optionitem = new Option(desc, val, false, false);
    optionitem1 = new Option(session, session, false, false);
    ddlYear.options[ddlYear.length] = optionitem;
    ddlYear.options[ddlYear.length] = optionitem1;

    for (var count = ddlYear1.options.length - 1; count > -1; count--) {
        ddlYear1.options[count] = null;
    }
   
    optionitem = new Option(desc, val, false, false);
    ddlYear1.options[ddlYear1.length] = optionitem;

    for (var count = ddlMon.options.length - 1; count > -1; count--) {
        ddlMon.options[count] = null;
    }

    optionitem = new Option(desc, val, false, false);
    ddlMon.options[ddlMon.length] = optionitem;
    ddlMon.focus();
    txtWorkDays.disabled = true;
    btnSubmit.disabled = true;
    ddlYear.value = session;
    ddlYear_onchange();
    ddlYear1_onchange();
}

function ddlYear_onchange() {
    var ddlYear = document.getElementById("ddlYear");
    var ddlYear_value = ddlYear.options[ddlYear.selectedIndex].value;
    var ddlYear1 = document.getElementById("ddlYear1");
    var ddlYear1_value = ddlYear1.options[ddlYear1.selectedIndex].value;
    if (ddlYear_value == "0") {
        this.ddlYear1.options[0].selected = true;
        this.ddlMon.options[0].selected = true;
        this.ddlYear.Focus();
    }
    else {
        for (var count = ddlYear1.options.length - 1; count > -1; count--) {
            ddlYear1.options[count] = null;
        }
        var val;
        var desc;
        var optionitem;
        var optionitem1;
        var optionitem2;
        val = "0";
        desc = "----Select----";
        optionitem = new Option(desc, val, false, false);
        ddlYear1.options[ddlYear1.length] = optionitem;
        var yearval1 = session.substring(0, 4);
     
        if (Year == yearval1)
        {
            optionitem1 = new Option(yearval1, yearval1, false, false);
            ddlYear1.options[ddlYear1.length] = optionitem1;
        }
        else
        {
            var num = Number(Year) - 1;
            optionitem1 = new Option(num, num, false, false);
            ddlYear1.options[ddlYear1.length] = optionitem1;
            optionitem2 = new Option(Year, Year, false, false);
            ddlYear1.options[ddlYear1.length] = optionitem2;
        }

    }
    
    ddlYear.focus();
    var ddlDept = document.getElementById("ddlDept");
    ddlDept.options[0].selected = true;
    var element = document.getElementById("grdEmpSal1");
    var trt = element.getElementsByTagName("TR");
    var lnt = trt.length;
    for (var i = 0; i < trt.length; i++) {
        element.deleteRow(i);
        lnt--;
        i--;
    }
    var txtSearch0 = document.getElementById("txtSearch0");
    txtSearch0.value = "";
    ddlYear1_onchange();
}

function ddlYear1_onchange() {
    var ddlYear = document.getElementById("ddlYear");
    var ddlYear_value = ddlYear.options[ddlYear.selectedIndex].value;
    var ddlYear1 = document.getElementById("ddlYear1");
    var ddlYear1_value = ddlYear1.options[ddlYear1.selectedIndex].value;
    var ddlMon = document.getElementById("ddlMon");
    var btnSalCalc = document.getElementById("btnSalCalc");
    var d = new Date();
    var n = d.getFullYear();
    
    ddlYear1.value = n;  
    if (ddlYear_value == "0") {
        window.alert("Select Session.");
        ddlYear.focus();
        return false;
    }
    else if (ddlYear1_value == "0") {
        ddlYear1.focus();
        return false;
    }
    else {
        var num = 0;
        var str = "";
        if (Number(ddlYear1_value) >= 0) {

            if (ddlYear1_value == session.substring(0, 4)) {

                PayRoll_Details.Get_ddl_month_value(ddlYear1_value, Fill_ddlmonth_bind);
            }
            else {
                PayRoll_Details.Get_ddl_month_value1(ddlYear1_value, Fill_ddlmonth_bind);
                if (ddlMon.options.length == 1) {

                    PayRoll_Details.Get_ddl_month_value2(ddlYear1_value, Fill_ddlmonth_bind);
                    Mname = "13";
                    str = "nn";
                }
            }
            if (btnSalCalc.disabled == false) {

                if (Number(Mname) == 12) {
                    num = 12;
                    ddlMon.value = num;
                }
                else if (Number(Mname) == "13" && str == "nn") {
                    ddlMon.value = "1";
                }
                else {
                    num = Number(Mname) + 1;
                    PayRoll_Details.Get_ddl_month_value2(num, Fill_ddlmonth_bind);
                }
            }
        }
        else {
            ddlYear1.focus();
        }
      
        ddlmon_onchange();
        ddlYear1.focus();
        var ddlDept = document.getElementById("ddlDept");
        ddlDept.options[0].selected = true;
        var element = document.getElementById("grdEmpSal1");
        var trt = element.getElementsByTagName("TR");
        var lnt = trt.length;
        for (var i = 0; i < trt.length; i++) {
            element.deleteRow(i);
            lnt--;
            i--;
        }
        var txtSearch0 = document.getElementById("txtSearch0");
        txtSearch0.value = "";
    }
}

function Fill_ddlmonth_bind(result) {
    var xml = parseXml(result);
    if (xml) {
        bindmonth_dll(xml.documentElement);
    }
}

function bindmonth_dll(DistNode) {
    var ddlMon = document.getElementById("ddlMon");
    for (var count = ddlMon.options.length - 1; count > -1; count--) {
        ddlMon.options[count] = null;
    }
    var val;
    var desc;
    var optionitem;
    val = "0";
    desc = "----Select----";;
    optionitem = new Option(desc, val, false, false);
    ddlMon.options[ddlMon.length] = optionitem;

    var IdNode = DistNode.getElementsByTagName('Id');
    var DescNode = DistNode.getElementsByTagName('MonthN');

    for (var count1 = 0; count1 < IdNode.length; count1++) {
        val = GetInnerText(IdNode[count1]);
        desc = GetInnerText(DescNode[count1]);
        optionitem = new Option(desc, val, false, false);
        ddlMon.options[ddlMon.length] = optionitem;
    }
    ddlMon.options[0].selected = true;
}

function ddlmon_onchange() {

    var ddlYear = document.getElementById("ddlYear");
    var ddlYear_value = ddlYear.options[ddlYear.selectedIndex].value;
    var ddlYear1 = document.getElementById("ddlYear1");
    var ddlYear1_value = ddlYear1.options[ddlYear1.selectedIndex].value;
    var ddlMon = document.getElementById("ddlMon");
    var ddlMon_value = ddlMon.options[ddlMon.selectedIndex].value;
    var txtDate = document.getElementById("txtDate");
    if (ddlYear1_value == "0") {
        window.alert("Select Year.");
        ddlYear1.focus();
        return false;
    }
    else if (ddlMon_value == "0") {
        ddlMon.focus();
    }
    else {
        workingday(ddlMon_value, ddlYear1_value);
        var datefull = ddlYear1_value + "-" + ddlMon_value + "-" + new Date(ddlYear1_value, ddlMon_value, 0).getDate();
        txtDate.value = new Date(datefull).format('dd-MMM-yyyy');
        ddlMon.focus();
        if (empidvalue != "0") {
            F_GridSearch();
        }
        else {
            F_Grid();
        }
    }
}

function F_GridSearch() {
    var ddlDept = document.getElementById("ddlDept");
    var ddlDept_value = ddlDept.options[ddlDept.selectedIndex].value;
    var ddlDesig = document.getElementById("ddlDesig");
    var ddlDesig_value = ddlDesig.options[ddlDesig.selectedIndex].value;
    var txtDate = document.getElementById("txtDate");
    var ddlYear1 = document.getElementById("ddlYear1");
    var ddlYear1_value = ddlYear1.options[ddlYear1.selectedIndex].value;
    var ddlMon = document.getElementById("ddlMon");
    var ddlMon_value = ddlMon.options[ddlMon.selectedIndex].value;
    var ddlMon_txt = ddlMon.options[ddlMon.selectedIndex].text;
    var str = "A";
    if (str != "") {
        PayRoll_Details.Get_Search_employee_grid_month(ddlYear1_value, ddlMon_value, Get_month_details_value);
    }
}

function Get_month_details_value(result) {

    var btnSalCalc = document.getElementById("btnSalCalc");
    var btnSubmit = document.getElementById("btnSubmit");
    var btnDel = document.getElementById("btnDel");
    var ddlDept = document.getElementById("ddlDept");
    var ddlDept_value = ddlDept.options[ddlDept.selectedIndex].value;
    var ddlDesig = document.getElementById("ddlDesig");
    var ddlDesig_value = ddlDesig.options[ddlDesig.selectedIndex].value;
    var txtDate = document.getElementById("txtDate");
    var ddlYear1 = document.getElementById("ddlYear1");
    var ddlYear1_value = ddlYear1.options[ddlYear1.selectedIndex].value;
    var ddlMon = document.getElementById("ddlMon");
    var ddlMon_value = ddlMon.options[ddlMon.selectedIndex].value;
    var ddlMon_txt = ddlMon.options[ddlMon.selectedIndex].text;
    if (result != "") {
        btnSalCalc.disabled = true;
        btnSubmit.disabled = true;
        btnDel.disabled = true;
    }
    else {
        btnSalCalc.disabled = false;
        if (empidvalue != "0") {
            btnSubmit.disabled = false;
        }
        btnDel.disabled = false;
    }
    PayRoll_Details.Get_Search_Grid(ddlYear1_value, ddlMon_value, txtDate.value, empidvalue, ddlMon_txt, ddlDept_value, ddlDesig_value, Fill_searchgrid_bind);
}

function Fill_searchgrid_bind(result) {
    var xml = parseXml(result); //pass result string into function for xml conversion.
    if (xml) {
        bindgrid_search(xml.documentElement); // call the bindgrid method and pass the root element of of xml form in the function.
    }
}

function bindgrid_search(root) {
    var element = document.getElementById("grdEmpSal1");
    var trt = element.getElementsByTagName("TR");
    var lnt = trt.length;
    for (var i = 0; i < trt.length; i++) {
        element.deleteRow(i);
        lnt--;
        i--;
    }
    var Payroll_Attendance = root.getElementsByTagName("Payroll_Attendance");
    var AttID = root.getElementsByTagName("AttID");
    var dept_id = root.getElementsByTagName("dept_id");
    var MName = root.getElementsByTagName("MName");
    var SessionN = root.getElementsByTagName("SessionN");
    var Working = root.getElementsByTagName("Working");
    var Curr_D = root.getElementsByTagName("Curr_D");
    var empID = root.getElementsByTagName("empID");
    var Prs = root.getElementsByTagName("Prs");
    var Abs = root.getElementsByTagName("Abs");
    var Sunday = root.getElementsByTagName("Sunday");
    var Holiday = root.getElementsByTagName("Holiday");
    var OPenL = root.getElementsByTagName("OPenL");
    var Wp = root.getElementsByTagName("Wp");
    var FullL = root.getElementsByTagName("FullL");
    var HBL = root.getElementsByTagName("HBL");
    var HAL = root.getElementsByTagName("HAL");
    var Miss = root.getElementsByTagName("Miss");
    var SLM = root.getElementsByTagName("SLM");
    var SLE = root.getElementsByTagName("SLE");
    var LWApp = root.getElementsByTagName("LWApp");
    var DrL = root.getElementsByTagName("DrL");
    var LWP = root.getElementsByTagName("LWP");
    var CrL = root.getElementsByTagName("CrL");
    var BalL = root.getElementsByTagName("BalL");
    var PaidDays = root.getElementsByTagName("PaidDays");
    var yearN = root.getElementsByTagName("yearN");
    var InstituteID = root.getElementsByTagName("InstituteID");
    var SessionID = root.getElementsByTagName("SessionID");
    var UserID = root.getElementsByTagName("UserID");
    var UEDate = root.getElementsByTagName("UEDate");
    var LateHour = root.getElementsByTagName("LateHour");
    var LateMin = root.getElementsByTagName("LateMin");
    var empname = root.getElementsByTagName("empname");
    var empCode = root.getElementsByTagName("empCode");
    var tbt = document.createElement("TBODY");
    element.appendChild(tbt);

    if (Payroll_Attendance.length > 0) {
        var headerRow = document.createElement("TR");
        var th1 = document.createElement("TH");
        th1.appendChild(document.createTextNode("Emp Code"));
        th1.style.height = "30px";
        th1.style.fontSize = "11px";
        th1.style.textAlign = "center";

        var th2 = document.createElement("TH");
        th2.appendChild(document.createTextNode("Emp Name"));
        th2.style.height = "30px";
        th2.style.fontSize = "11px";
        th2.style.textAlign = "center";
       

        var th3 = document.createElement("TH");
        th3.appendChild(document.createTextNode("Total Days"));
        th3.style.height = "30px";
        th3.style.fontSize = "11px";
        th3.style.textAlign = "center";

        var th17 = document.createElement("TH");
        th17.appendChild(document.createTextNode("Op Leave"));
        th17.style.height = "30px";
        th17.style.fontSize = "11px";
        th17.style.textAlign = "center";


        var th4 = document.createElement("TH");
        th4.appendChild(document.createTextNode("Full Leav"));
        th4.style.height = "30px";
        th4.style.fontSize = "11px";
        th4.style.textAlign = "center";
     

        var th5 = document.createElement("TH");
        th5.appendChild(document.createTextNode("HBL"));
        th5.style.height = "30px";
        th5.style.fontSize = "11px";
        th5.style.textAlign = "center";
       

        var th6 = document.createElement("TH");
        th6.appendChild(document.createTextNode("HAL"));
        th6.style.height = "30px";
        th6.style.fontSize = "11px";
        th6.style.textAlign = "center";
     

        var th7 = document.createElement("TH");
        th7.appendChild(document.createTextNode("MIS"));
        th7.style.height = "30px";
        th7.style.fontSize = "11px";
        th7.style.textAlign = "center";
       

        var th8 = document.createElement("TH");
        th8.appendChild(document.createTextNode("SLM"));
        th8.style.height = "30px";
        th8.style.fontSize = "11px";
        th8.style.textAlign = "center";
    

        var th9 = document.createElement("TH");
        th9.appendChild(document.createTextNode("SLE"));
        th9.style.height = "30px";
        th9.style.fontSize = "11px";
        th9.style.textAlign = "center";

        var th10 = document.createElement("TH");
        th10.appendChild(document.createTextNode("Late Hours"));
        th10.style.height = "30px";
        th10.style.fontSize = "11px";
        th10.style.textAlign = "center";

        var th11 = document.createElement("TH");
        th11.appendChild(document.createTextNode("LWApp"));
        th11.style.height = "30px";
        th11.style.fontSize = "11px";
        th11.style.textAlign = "center";

        var th12 = document.createElement("TH");
        th12.appendChild(document.createTextNode("Dr Leav"));
        th12.style.height = "30px";
        th12.style.fontSize = "11px";
        th12.style.textAlign = "center";

        var th13 = document.createElement("TH");
        th13.appendChild(document.createTextNode("LWP"));
        th13.style.height = "30px";
        th13.style.fontSize = "11px";
        th13.style.textAlign = "center";


        var th14 = document.createElement("TH");
        th14.appendChild(document.createTextNode("Cr Leav"));
        th14.style.height = "30px";
        th14.style.fontSize = "11px";
        th14.style.textAlign = "center";

        var th15 = document.createElement("TH");
        th15.appendChild(document.createTextNode("Bal Leav"));
        th15.style.height = "30px";
        th15.style.fontSize = "11px";
        th15.style.textAlign = "center";

        var th16 = document.createElement("TH");
        th16.appendChild(document.createTextNode("Paid Days"));
        th16.style.height = "30px";
        th16.style.fontSize = "11px";
        th16.style.textAlign = "center";
      

        headerRow.appendChild(th1);
        headerRow.appendChild(th2);
        headerRow.appendChild(th3);
        headerRow.appendChild(th17);
        headerRow.appendChild(th4);
        headerRow.appendChild(th5);
        headerRow.appendChild(th6);
        headerRow.appendChild(th7);
        headerRow.appendChild(th8);
        headerRow.appendChild(th9);
        headerRow.appendChild(th10);
        headerRow.appendChild(th11);
        headerRow.appendChild(th12);
        headerRow.appendChild(th13);
        headerRow.appendChild(th14);
        headerRow.appendChild(th15);
        headerRow.appendChild(th16);
        tbt.appendChild(headerRow);
    }
    else {
     
        var txtDate = document.getElementById("txtDate");
        var ddlYear1 = document.getElementById("ddlYear1");
        var ddlYear1_value = ddlYear1.options[ddlYear1.selectedIndex].value;
        var ddlMon = document.getElementById("ddlMon");
        var ddlMon_value = ddlMon.options[ddlMon.selectedIndex].value;
        PayRoll_Details.Get_Search_employee_grid(ddlYear1_value, ddlMon_value, txtDate.value, empidvalue, fill_Search_employee_grid);
        return false;
    }

    if (Payroll_Attendance.length > 0) {

        for (var x = 0; x < Payroll_Attendance.length; x++) {

            var row = document.createElement("TR");
            row.title = "Click Here for Search details";
            row.style.cursor = "pointer";
            var rid = "rc" + x;
            row.setAttribute('id', rid);

       
            row.setAttribute('onclick', "onClick(this);");
            //row.setAttribute('onmouseover', "onRowMouseOver(this);");
            //row.setAttribute('onmouseout', "onRowMouseOut(this);");
       
            var AttID1 = GetInnerText(AttID[x]);
        
            var dept_id1 = GetInnerText(dept_id[x]);
            var MName1 = GetInnerText(MName[x]);
            var SessionN1 = GetInnerText(SessionN[x]);
            var Working1 = GetInnerText(Working[x]);
            var Curr_D1 = GetInnerText(Curr_D[x]);
            var empID1 = GetInnerText(empID[x]);
            var Prs1 = GetInnerText(Prs[x]);
            var Abs1 = GetInnerText(Abs[x]);
            var Sunday1 = GetInnerText(Sunday[x]);
            var Holiday1 = GetInnerText(Holiday[x]);
            var OPenL1 = GetInnerText(OPenL[x]);
            var Wp1 = GetInnerText(Wp[x]);
            var FullL1 = GetInnerText(FullL[x]);
            var HBL1 = GetInnerText(HBL[x]);
            var HAL1 = GetInnerText(HAL[x]);
            var Miss1 = GetInnerText(Miss[x]);
            var SLM1 = GetInnerText(SLM[x]);
            var SLE1 = GetInnerText(SLE[x]);
            var LWApp1 = GetInnerText(LWApp[x]);
            var DrL1 = GetInnerText(DrL[x]);
            var LWP1 = GetInnerText(LWP[x]);
            var CrL1 = GetInnerText(CrL[x]);
            var BalL1 = GetInnerText(BalL[x]);
            var PaidDays1 = GetInnerText(PaidDays[x]);
            var yearN1 = GetInnerText(yearN[x]);
            var InstituteID1 = GetInnerText(InstituteID[x]);
            var SessionID1 = GetInnerText(SessionID[x]);
            var UserID1 = GetInnerText(UserID[x]);
            var UEDate1 = GetInnerText(UEDate[x]);
            var LateHour1 = GetInnerText(LateHour[x]);
            var LateMin1 = GetInnerText(LateMin[x]);
            var empname1 = GetInnerText(empname[x]);
            var empCode1 = GetInnerText(empCode[x]);

            var td2 = document.createElement("TD");
            td2.appendChild(document.createTextNode(empCode1));
         
            var td3 = document.createElement("TD");
            td3.appendChild(document.createTextNode(empname1));
            var txtWorkDays = document.getElementById("txtWorkDays");

            var td4 = document.createElement("TD");
            td4.appendChild(document.createTextNode(txtWorkDays.value));

            var td5 = document.createElement("TD");
            td5.appendChild(document.createTextNode(OPenL1));

            var td6 = document.createElement("TD");
            td6.appendChild(document.createTextNode(FullL1));

            var td7 = document.createElement("TD");
            td7.appendChild(document.createTextNode(HBL1));

            var td71 = document.createElement("TD");
            td71.appendChild(document.createTextNode(HAL1));

            var td8 = document.createElement("TD");
            td8.appendChild(document.createTextNode(Miss1));

            var td9 = document.createElement("TD");
            td9.appendChild(document.createTextNode(SLM1));

            var td10 = document.createElement("TD");
            td10.appendChild(document.createTextNode(SLE1));

            var td11 = document.createElement("TD");
            td11.appendChild(document.createTextNode(LateHour1 + ':' + LateMin1));

            var td12 = document.createElement("TD");
            td12.appendChild(document.createTextNode(LWApp1));

            var td13 = document.createElement("TD");
            td13.appendChild(document.createTextNode(DrL1));

            var td14 = document.createElement("TD");
            td14.appendChild(document.createTextNode(LWP1));

            var td15 = document.createElement("TD");
            td15.appendChild(document.createTextNode(CrL1));

            var td16 = document.createElement("TD");
            td16.appendChild(document.createTextNode(BalL1));

            var td17 = document.createElement("TD");
            td17.appendChild(document.createTextNode(PaidDays1));
      
            row.appendChild(td2);
            row.appendChild(td3);
            row.appendChild(td4);
            row.appendChild(td5);
            row.appendChild(td6);
            row.appendChild(td7);
            row.appendChild(td71);
            row.appendChild(td8);
            row.appendChild(td9);
            row.appendChild(td10);
            row.appendChild(td11);
            row.appendChild(td12);
            row.appendChild(td13);
            row.appendChild(td14);
            row.appendChild(td15);
            row.appendChild(td16);
            row.appendChild(td17);
            tbt.appendChild(row);
        }
        var footerRow = document.createElement("TR");
        var img1 = document.createElement('img');
        img1.style.cursor = "pointer";
        img1.src = "../images/Icon_35-128.png";
        img1.setAttribute("onclick", "previous_onclick();");
        img1.style.height = "25px";
        img1.style.width = "25px";
        img1.title = "Click Here for Search Details";
        var fh1 = document.createElement("TH");
        fh1.colSpan = "17";
        fh1.style.height = "30px;"
        fh1.style.textAlign = "left";
        fh1.appendChild(img1);
        footerRow.appendChild(fh1);
        tbt.appendChild(footerRow);
    }
}


function fill_Search_employee_grid(result) {

    var xml = parseXml(result); //pass result string into function for xml conversion.
    if (xml) {
        bindgrid_employee_search(xml.documentElement); // call the bindgrid method and pass the root element of of xml form in the function.
    }
}

function bindgrid_employee_search(root) {

    var element = document.getElementById("grdEmpSal1");
    var trt = element.getElementsByTagName("TR");
    var lnt = trt.length;
    for (var i = 0; i < trt.length; i++) {
        element.deleteRow(i);
        lnt--;
        i--;
    }
    var Employee_Master = root.getElementsByTagName("Employee_Master");
    var empId = root.getElementsByTagName("empId");
    var empCode = root.getElementsByTagName("empCode");
    var empName = root.getElementsByTagName("empName");
    var CardNo = root.getElementsByTagName("CardNo");
    var DeptId = root.getElementsByTagName("DeptId");
    var id = root.getElementsByTagName("id");
    var tbt = document.createElement("TBODY");
    element.appendChild(tbt);

    if (Employee_Master.length > 0) {
        var headerRow = document.createElement("TR");
        var th1 = document.createElement("TH");
        th1.appendChild(document.createTextNode("Emp Code"));
        th1.style.height = "30px";
        th1.style.fontSize = "11px";
        th1.style.textAlign = "center";

        var th2 = document.createElement("TH");
        th2.appendChild(document.createTextNode("Emp Name"));
        th2.style.height = "30px";
        th2.style.fontSize = "11px";
        th2.style.textAlign = "center";


        var th3 = document.createElement("TH");
        th3.appendChild(document.createTextNode("Total Days"));
        th3.style.height = "30px";
        th3.style.fontSize = "11px";
        th3.style.textAlign = "center";

        var th31 = document.createElement("TH");
        th31.appendChild(document.createTextNode("Op Leave"));
        th31.style.height = "30px";
        th31.style.fontSize = "11px";
        th31.style.textAlign = "center";


        var th4 = document.createElement("TH");
        th4.appendChild(document.createTextNode("Full Leav"));
        th4.style.height = "30px";
        th4.style.fontSize = "11px";
        th4.style.textAlign = "center";


        var th5 = document.createElement("TH");
        th5.appendChild(document.createTextNode("HBL"));
        th5.style.height = "30px";
        th5.style.fontSize = "11px";
        th5.style.textAlign = "center";


        var th6 = document.createElement("TH");
        th6.appendChild(document.createTextNode("HAL"));
        th6.style.height = "30px";
        th6.style.fontSize = "11px";
        th6.style.textAlign = "center";


        var th7 = document.createElement("TH");
        th7.appendChild(document.createTextNode("MIS"));
        th7.style.height = "30px";
        th7.style.fontSize = "11px";
        th7.style.textAlign = "center";


        var th8 = document.createElement("TH");
        th8.appendChild(document.createTextNode("SLM"));
        th8.style.height = "30px";
        th8.style.fontSize = "11px";
        th8.style.textAlign = "center";


        var th9 = document.createElement("TH");
        th9.appendChild(document.createTextNode("SLE"));
        th9.style.height = "30px";
        th9.style.fontSize = "11px";
        th9.style.textAlign = "center";

        var th10 = document.createElement("TH");
        th10.appendChild(document.createTextNode("Late Hours"));
        th10.style.height = "30px";
        th10.style.fontSize = "11px";
        th10.style.textAlign = "center";

        var th11 = document.createElement("TH");
        th11.appendChild(document.createTextNode("LWApp"));
        th11.style.height = "30px";
        th11.style.fontSize = "11px";
        th11.style.textAlign = "center";

        var th12 = document.createElement("TH");
        th12.appendChild(document.createTextNode("Dr Leav"));
        th12.style.height = "30px";
        th12.style.fontSize = "11px";
        th12.style.textAlign = "center";

        var th13 = document.createElement("TH");
        th13.appendChild(document.createTextNode("LWP"));
        th13.style.height = "30px";
        th13.style.fontSize = "11px";
        th13.style.textAlign = "center";


        var th14 = document.createElement("TH");
        th14.appendChild(document.createTextNode("Cr Leav"));
        th14.style.height = "30px";
        th14.style.fontSize = "11px";
        th14.style.textAlign = "center";

        var th15 = document.createElement("TH");
        th15.appendChild(document.createTextNode("Bal Leav"));
        th15.style.height = "30px";
        th15.style.fontSize = "11px";
        th15.style.textAlign = "center";

        var th16 = document.createElement("TH");
        th16.appendChild(document.createTextNode("Paid Days"));
        th16.style.height = "30px";
        th16.style.fontSize = "11px";
        th16.style.textAlign = "center";


        headerRow.appendChild(th1);
        headerRow.appendChild(th2);
        headerRow.appendChild(th3);
        headerRow.appendChild(th31);
        headerRow.appendChild(th4);
        headerRow.appendChild(th5);
        headerRow.appendChild(th6);
        headerRow.appendChild(th7);
        headerRow.appendChild(th8);
        headerRow.appendChild(th9);
        headerRow.appendChild(th10);
        headerRow.appendChild(th11);
        headerRow.appendChild(th12);
        headerRow.appendChild(th13);
        headerRow.appendChild(th14);
        headerRow.appendChild(th15);
        headerRow.appendChild(th16);
        tbt.appendChild(headerRow);
    }
    if (Employee_Master.length > 0) {

        for (var x = 0; x < Employee_Master.length; x++) {

            var row = document.createElement("TR");
            row.title = "Click Here for Search details";
            row.style.cursor = "pointer";
            var rid = "rc" + x;
            row.setAttribute('id', rid);
            row.setAttribute('onclick', "onClick(this);");
            //row.setAttribute('onmouseover', "onRowMouseOver(this);");
            //row.setAttribute('onmouseout', "onRowMouseOut(this);");
       
            var empname1 = GetInnerText(empName[x]);
            var empCode1 = GetInnerText(empCode[x]);

            var td2 = document.createElement("TD");
            td2.appendChild(document.createTextNode(empCode1));

            var td3 = document.createElement("TD");
            td3.appendChild(document.createTextNode(empname1));
            var txtWorkDays = document.getElementById("txtWorkDays");

            var td4 = document.createElement("TD");
            td4.appendChild(document.createTextNode(""));

            var td5 = document.createElement("TD");
            td5.appendChild(document.createTextNode(""));

            var td6 = document.createElement("TD");
            td6.appendChild(document.createTextNode(""));

            var td7 = document.createElement("TD");
            td7.appendChild(document.createTextNode(""));

            var td8 = document.createElement("TD");
            td8.appendChild(document.createTextNode(""));

            var td9 = document.createElement("TD");
            td9.appendChild(document.createTextNode(""));

            var td10 = document.createElement("TD");
            td10.appendChild(document.createTextNode(""));

            var td11 = document.createElement("TD");
            td11.appendChild(document.createTextNode(""));

            var td12 = document.createElement("TD");
            td12.appendChild(document.createTextNode(""));

            var td13 = document.createElement("TD");
            td13.appendChild(document.createTextNode(""));

            var td14 = document.createElement("TD");
            td14.appendChild(document.createTextNode(""));

            var td15 = document.createElement("TD");
            td15.appendChild(document.createTextNode(""));

            var td16 = document.createElement("TD");
            td16.appendChild(document.createTextNode(""));

            var td17 = document.createElement("TD");
            td17.appendChild(document.createTextNode(""));

            var td18 = document.createElement("TD");
            td18.appendChild(document.createTextNode(""));

            row.appendChild(td2);
            row.appendChild(td3);
            row.appendChild(td4);
            row.appendChild(td5);
            row.appendChild(td6);
            row.appendChild(td7);
            row.appendChild(td8);
            row.appendChild(td9);
            row.appendChild(td10);
            row.appendChild(td11);
            row.appendChild(td12);
            row.appendChild(td13);
            row.appendChild(td14);
            row.appendChild(td15);
            row.appendChild(td16);
            row.appendChild(td17);
            row.appendChild(td18);
            tbt.appendChild(row);
        }
        var footerRow = document.createElement("TR");
        var img1 = document.createElement('img');
        img1.style.cursor = "pointer";
        img1.src = "../images/Icon_35-128.png";
        img1.setAttribute("onclick", "previous_onclick();");
        img1.style.height = "25px";
        img1.style.width = "25px";
        img1.title = "Click Here for Search Details";
        var fh1 = document.createElement("TH");
        fh1.colSpan = "17";
        fh1.style.height = "30px;"
        fh1.style.textAlign = "left";
        fh1.appendChild(img1);
        footerRow.appendChild(fh1);
        tbt.appendChild(footerRow);
    }
}

function F_Grid() {
    var ddlDept = document.getElementById("ddlDept");
    var ddlDept_value = ddlDept.options[ddlDept.selectedIndex].value;
    var ddlDesig = document.getElementById("ddlDesig");
    var ddlDesig_value = ddlDesig.options[ddlDesig.selectedIndex].value;
    var txtDate = document.getElementById("txtDate");
    var ddlYear1 = document.getElementById("ddlYear1");
    var ddlYear1_value = ddlYear1.options[ddlYear1.selectedIndex].value;
    var ddlMon = document.getElementById("ddlMon");
    var ddlMon_value = ddlMon.options[ddlMon.selectedIndex].value;
    var ddlMon_txt = ddlMon.options[ddlMon.selectedIndex].text;
    PayRoll_Details.Get_Search_employee_grid_month(ddlYear1_value, ddlMon_value, Get_month_details_value1);
}
function Get_month_details_value1(result) {
    var btnSalCalc = document.getElementById("btnSalCalc");
    var btnSubmit = document.getElementById("btnSubmit");
    var btnDel = document.getElementById("btnDel");
    var ddlDept = document.getElementById("ddlDept");
    var ddlDept_value = ddlDept.options[ddlDept.selectedIndex].value;
    var ddlDesig = document.getElementById("ddlDesig");
    var ddlDesig_value = ddlDesig.options[ddlDesig.selectedIndex].value;
    var txtDate = document.getElementById("txtDate");
    var ddlYear1 = document.getElementById("ddlYear1");
    var ddlYear1_value = ddlYear1.options[ddlYear1.selectedIndex].value;
    var ddlMon = document.getElementById("ddlMon");
    var ddlMon_value = ddlMon.options[ddlMon.selectedIndex].value;
    var ddlMon_txt = ddlMon.options[ddlMon.selectedIndex].text;
    if (result != "") {
        btnSalCalc.disabled = true;
        btnSubmit.disabled = true;
        btnDel.disabled = true;
    }
    else {
        btnSalCalc.disabled = false;
        if (empidvalue != "0") {
            btnSubmit.disabled = false;
        }
        btnDel.disabled = false;
    }
    PayRoll_Details.Get_Search_Grid1(ddlYear1_value, ddlMon_value, txtDate.value, empidvalue, ddlMon_txt, ddlDept_value, ddlDesig_value, Fill_searchgrid_bind1);
}

function Fill_searchgrid_bind1(result) {
    var xml = parseXml(result); //pass result string into function for xml conversion.
    if (xml) {
        bindgrid_search1(xml.documentElement); // call the bindgrid method and pass the root element of of xml form in the function.
    }

}

function bindgrid_search1(root) {
    var element = document.getElementById("grdEmpSal1");
    var trt = element.getElementsByTagName("TR");
    var lnt = trt.length;
    for (var i = 0; i < trt.length; i++) {
        element.deleteRow(i);
        lnt--;
        i--;
    }
    var Payroll_Attendance = root.getElementsByTagName("Payroll_Attendance");
    var AttID = root.getElementsByTagName("AttID");
    var dept_id = root.getElementsByTagName("dept_id");
    var MName = root.getElementsByTagName("MName");
    var SessionN = root.getElementsByTagName("SessionN");
    var Working = root.getElementsByTagName("Working");
    var Curr_D = root.getElementsByTagName("Curr_D");
    var empID = root.getElementsByTagName("empID");
    var Prs = root.getElementsByTagName("Prs");
    var Abs = root.getElementsByTagName("Abs");
    var Sunday = root.getElementsByTagName("Sunday");
    var Holiday = root.getElementsByTagName("Holiday");
    var OPenL = root.getElementsByTagName("OPenL");
    var Wp = root.getElementsByTagName("Wp");
    var FullL = root.getElementsByTagName("FullL");
    var HBL = root.getElementsByTagName("HBL");
    var HAL = root.getElementsByTagName("HAL");
    var Miss = root.getElementsByTagName("Miss");
    var SLM = root.getElementsByTagName("SLM");
    var SLE = root.getElementsByTagName("SLE");
    var LWApp = root.getElementsByTagName("LWApp");
    var DrL = root.getElementsByTagName("DrL");
    var LWP = root.getElementsByTagName("LWP");
    var CrL = root.getElementsByTagName("CrL");
    var BalL = root.getElementsByTagName("BalL");
    var PaidDays = root.getElementsByTagName("PaidDays");
    var yearN = root.getElementsByTagName("yearN");
    var InstituteID = root.getElementsByTagName("InstituteID");
    var SessionID = root.getElementsByTagName("SessionID");
    var UserID = root.getElementsByTagName("UserID");
    var UEDate = root.getElementsByTagName("UEDate");
    var LateHour = root.getElementsByTagName("LateHour");
    var LateMin = root.getElementsByTagName("LateMin");
    var empname = root.getElementsByTagName("empname");
    var empCode = root.getElementsByTagName("empCode");
    var tbt = document.createElement("TBODY");
    element.appendChild(tbt);

    if (Payroll_Attendance.length > 0) {
        var headerRow = document.createElement("TR");
        var th1 = document.createElement("TH");
        th1.appendChild(document.createTextNode("Emp Code"));
        th1.style.height = "30px";
        th1.style.fontSize = "11px";
        th1.style.textAlign = "center";

        var th2 = document.createElement("TH");
        th2.appendChild(document.createTextNode("Emp Name"));
        th2.style.height = "30px";
        th2.style.fontSize = "11px";
        th2.style.textAlign = "center";


        var th3 = document.createElement("TH");
        th3.appendChild(document.createTextNode("Total Days"));
        th3.style.height = "30px";
        th3.style.fontSize = "11px";
        th3.style.textAlign = "center";

        var th31 = document.createElement("TH");
        th31.appendChild(document.createTextNode("Op Leave"));
        th31.style.height = "30px";
        th31.style.fontSize = "11px";
        th31.style.textAlign = "center";


        var th4 = document.createElement("TH");
        th4.appendChild(document.createTextNode("Full Leav"));
        th4.style.height = "30px";
        th4.style.fontSize = "11px";
        th4.style.textAlign = "center";


        var th5 = document.createElement("TH");
        th5.appendChild(document.createTextNode("HBL"));
        th5.style.height = "30px";
        th5.style.fontSize = "11px";
        th5.style.textAlign = "center";


        var th6 = document.createElement("TH");
        th6.appendChild(document.createTextNode("HAL"));
        th6.style.height = "30px";
        th6.style.fontSize = "11px";
        th6.style.textAlign = "center";


        var th7 = document.createElement("TH");
        th7.appendChild(document.createTextNode("MIS"));
        th7.style.height = "30px";
        th7.style.fontSize = "11px";
        th7.style.textAlign = "center";


        var th8 = document.createElement("TH");
        th8.appendChild(document.createTextNode("SLM"));
        th8.style.height = "30px";
        th8.style.fontSize = "11px";
        th8.style.textAlign = "center";


        var th9 = document.createElement("TH");
        th9.appendChild(document.createTextNode("SLE"));
        th9.style.height = "30px";
        th9.style.fontSize = "11px";
        th9.style.textAlign = "center";

        var th10 = document.createElement("TH");
        th10.appendChild(document.createTextNode("Late Hours"));
        th10.style.height = "30px";
        th10.style.fontSize = "11px";
        th10.style.textAlign = "center";

        var th11 = document.createElement("TH");
        th11.appendChild(document.createTextNode("LWApp"));
        th11.style.height = "30px";
        th11.style.fontSize = "11px";
        th11.style.textAlign = "center";

        var th12 = document.createElement("TH");
        th12.appendChild(document.createTextNode("Dr Leav"));
        th12.style.height = "30px";
        th12.style.fontSize = "11px";
        th12.style.textAlign = "center";

        var th13 = document.createElement("TH");
        th13.appendChild(document.createTextNode("LWP"));
        th13.style.height = "30px";
        th13.style.fontSize = "11px";
        th13.style.textAlign = "center";


        var th14 = document.createElement("TH");
        th14.appendChild(document.createTextNode("Cr Leav"));
        th14.style.height = "30px";
        th14.style.fontSize = "11px";
        th14.style.textAlign = "center";

        var th15 = document.createElement("TH");
        th15.appendChild(document.createTextNode("Bal Leav"));
        th15.style.height = "30px";
        th15.style.fontSize = "11px";
        th15.style.textAlign = "center";

        var th16 = document.createElement("TH");
        th16.appendChild(document.createTextNode("Paid Days"));
        th16.style.height = "30px";
        th16.style.fontSize = "11px";
        th16.style.textAlign = "center";


        headerRow.appendChild(th1);
        headerRow.appendChild(th2);
        headerRow.appendChild(th3);
        headerRow.appendChild(th31);
        headerRow.appendChild(th4);
        headerRow.appendChild(th5);
        headerRow.appendChild(th6);
        headerRow.appendChild(th7);
        headerRow.appendChild(th8);
        headerRow.appendChild(th9);
        headerRow.appendChild(th10);
        headerRow.appendChild(th11);
        headerRow.appendChild(th12);
        headerRow.appendChild(th13);
        headerRow.appendChild(th14);
        headerRow.appendChild(th15);
        headerRow.appendChild(th16);
        tbt.appendChild(headerRow);
    }
    else {
      
        var txtDate = document.getElementById("txtDate");
        var ddlYear1 = document.getElementById("ddlYear1");
        var ddlYear1_value = ddlYear1.options[ddlYear1.selectedIndex].value;
        var ddlMon = document.getElementById("ddlMon");
        var ddlMon_value = ddlMon.options[ddlMon.selectedIndex].value;
        var ddlDept = document.getElementById("ddlDept");
        var ddlDept_value = ddlDept.options[ddlDept.selectedIndex].value;
        var ddlDesig = document.getElementById("ddlDesig");
        var ddlDesig_value = ddlDesig.options[ddlDesig.selectedIndex].value;
        PayRoll_Details.Get_Search_employee_grid1(ddlYear1_value, ddlMon_value, txtDate.value, empidvalue,ddlDept_value,ddlDesig_value, fill_Search_employee_grid);
        return false;
    }

    if (Payroll_Attendance.length > 0) {

        for (var x = 0; x < Payroll_Attendance.length; x++) {

            var row = document.createElement("TR");
            row.title = "Click Here for Search details";
            row.style.cursor = "pointer";
            var rid = "rc" + x;
            row.setAttribute('id', rid);
            row.setAttribute('onclick', "onClick(this);");
            //row.setAttribute('onmouseover', "onRowMouseOver(this);");
            //row.setAttribute('onmouseout', "onRowMouseOut(this);");
          
            var AttID1 = GetInnerText(AttID[x]);

            var dept_id1 = GetInnerText(dept_id[x]);
            var MName1 = GetInnerText(MName[x]);
            var SessionN1 = GetInnerText(SessionN[x]);
            var Working1 = GetInnerText(Working[x]);
            var Curr_D1 = GetInnerText(Curr_D[x]);
            var empID1 = GetInnerText(empID[x]);
            var Prs1 = GetInnerText(Prs[x]);
            var Abs1 = GetInnerText(Abs[x]);
            var Sunday1 = GetInnerText(Sunday[x]);
            var Holiday1 = GetInnerText(Holiday[x]);
            var OPenL1 = GetInnerText(OPenL[x]);
            var Wp1 = GetInnerText(Wp[x]);
            var FullL1 = GetInnerText(FullL[x]);
            var HBL1 = GetInnerText(HBL[x]);
            var HAL1 = GetInnerText(HAL[x]);
            var Miss1 = GetInnerText(Miss[x]);
            var SLM1 = GetInnerText(SLM[x]);
            var SLE1 = GetInnerText(SLE[x]);
            var LWApp1 = GetInnerText(LWApp[x]);
            var DrL1 = GetInnerText(DrL[x]);
            var LWP1 = GetInnerText(LWP[x]);
            var CrL1 = GetInnerText(CrL[x]);
            var BalL1 = GetInnerText(BalL[x]);
            var PaidDays1 = GetInnerText(PaidDays[x]);
            var yearN1 = GetInnerText(yearN[x]);
            var InstituteID1 = GetInnerText(InstituteID[x]);
            var SessionID1 = GetInnerText(SessionID[x]);
            var UserID1 = GetInnerText(UserID[x]);
            var UEDate1 = GetInnerText(UEDate[x]);
            var LateHour1 = GetInnerText(LateHour[x]);
            var LateMin1 = GetInnerText(LateMin[x]);
            var empname1 = GetInnerText(empname[x]);
            var empCode1 = GetInnerText(empCode[x]);

            var td2 = document.createElement("TD");
            td2.appendChild(document.createTextNode(empCode1));

            var td3 = document.createElement("TD");
            td3.appendChild(document.createTextNode(empname1));
            var txtWorkDays = document.getElementById("txtWorkDays");

            var td4 = document.createElement("TD");
            td4.appendChild(document.createTextNode(txtWorkDays.value));

            var td5 = document.createElement("TD");
            td5.appendChild(document.createTextNode(OPenL1));

            var td6 = document.createElement("TD");
            td6.appendChild(document.createTextNode(FullL1));

            var td7 = document.createElement("TD");
            td7.appendChild(document.createTextNode(HBL1));

            var td71 = document.createElement("TD");
            td71.appendChild(document.createTextNode(HAL1));

            var td8 = document.createElement("TD");
            td8.appendChild(document.createTextNode(Miss1));

            var td9 = document.createElement("TD");
            td9.appendChild(document.createTextNode(SLM1));

            var td10 = document.createElement("TD");
            td10.appendChild(document.createTextNode(SLE1));

            var td11 = document.createElement("TD");
            td11.appendChild(document.createTextNode(LateHour1 + ':' + LateMin1));

            var td12 = document.createElement("TD");
            td12.appendChild(document.createTextNode(LWApp1));

            var td13 = document.createElement("TD");
            td13.appendChild(document.createTextNode(DrL1));

            var td14 = document.createElement("TD");
            td14.appendChild(document.createTextNode(LWP1));

            var td15 = document.createElement("TD");
            td15.appendChild(document.createTextNode(CrL1));

            var td16 = document.createElement("TD");
            td16.appendChild(document.createTextNode(BalL1));

            var td17 = document.createElement("TD");
            td17.appendChild(document.createTextNode(PaidDays1));

            row.appendChild(td2);
            row.appendChild(td3);
            row.appendChild(td4);
            row.appendChild(td5);
            row.appendChild(td6);
            row.appendChild(td7);
            row.appendChild(td71);
            row.appendChild(td8);
            row.appendChild(td9);
            row.appendChild(td10);
            row.appendChild(td11);
            row.appendChild(td12);
            row.appendChild(td13);
            row.appendChild(td14);
            row.appendChild(td15);
            row.appendChild(td16);
            row.appendChild(td17);
            tbt.appendChild(row);

      
        }
        var footerRow = document.createElement("TR");
        var img1 = document.createElement('img');
        img1.style.cursor = "pointer";
        img1.src = "../images/Icon_35-128.png";
        img1.setAttribute("onclick", "previous_onclick();");
        img1.style.height = "25px";
        img1.style.width = "25px";
        img1.title = "Click Here for Search Details";
        var fh1 = document.createElement("TH");
        fh1.colSpan = "17";
        fh1.style.height = "30px;"
        fh1.style.textAlign = "left";
        fh1.appendChild(img1);
        footerRow.appendChild(fh1);
        tbt.appendChild(footerRow);
    }
}

function GetScreenCordinates(obj) {
    var p = {};
    p.x = obj.offsetLeft;
    p.y = obj.offsetTop;
    while (obj.offsetParent) {
        p.x = p.x + obj.offsetParent.offsetLeft;
        p.y = p.y + obj.offsetParent.offsetTop;
        if (obj == document.getElementsByTagName("body")[0]) {
            break;
        }
        else {
            obj = obj.offsetParent;
        }
    }
    return p;
}

function get_emplyee_value() {
  
    var txt = document.getElementById("txtSearch0");
    Calender_details.BindEmployee_grid_search(txt.value, Fill_empsearch);
}

function Fill_empsearch(result) {
    var xml = parseXml(result); //pass result string into function for xml conversion.
    if (xml) {
        bindgrid(xml.documentElement); // call the bindgrid method and pass the root element of of xml form in the function.
    }
}

function bindgrid(root) {
    var element = document.getElementById("xgrid");
    var trt = element.getElementsByTagName("TR");
    var lnt = trt.length;
    for (var i = 0; i < trt.length; i++) {
        element.deleteRow(i);
        lnt--;
        i--;
    }
    var employee_master = root.getElementsByTagName("employee_master");
    var empname = root.getElementsByTagName("empname");
    var empcode = root.getElementsByTagName("empcode");
    var empid = root.getElementsByTagName("empid");
    var tbt = document.createElement("TBODY");
    element.appendChild(tbt);

    var txt = document.getElementById("txtSearch0");
    var p = GetScreenCordinates(txt);
    var xval = p.x;
    var yval = p.y;
    var grd_serch = document.getElementById("grd_serch");
    grd_serch.style.display = "block";
    grd_serch.style.left = xval + 2 + 'px';
    grd_serch.style.top = yval + 33 + 'px';
    if (employee_master.length > 0) {
        for (var x = 0; x < employee_master.length; x++) {
            var row = document.createElement("TR");
            row.style.cursor = "pointer";
            var rid = "rc" + x;
            row.setAttribute('id', rid);
            row.setAttribute('onclick', "onClick1(this);");
            row.setAttribute('onmouseover', "onRowMouseOver(this);");
            row.setAttribute('onmouseout', "onRowMouseOut(this);");
            var empname1 = GetInnerText(empname[x]);
            var empcode1 = GetInnerText(empcode[x]);
            var empid1 = GetInnerText(empid[x]);
            var td2 = document.createElement("TD");
            td2.appendChild(document.createTextNode(empname1));
            var td3 = document.createElement("TD");
            td3.appendChild(document.createTextNode(empcode1));
            td3.style.display = "none";
            var td4 = document.createElement("TD");
            td4.appendChild(document.createTextNode(empid1));
            td4.style.display = "none";
            row.appendChild(td2);
            row.appendChild(td3);
            row.appendChild(td4);
            tbt.appendChild(row);
        }

    }
    else {
        var row = document.createElement("TR");
        row.style.cursor = "pointer";
        var rid = "rc" + 1;
        row.setAttribute('id', rid);
        row.setAttribute('onclick', "onClick1(this);");
        row.setAttribute('onmouseover', "onRowMouseOver(this);");
        row.setAttribute('onmouseout', "onRowMouseOut(this);");
        var empname1 = "No Record Found"
        var td2 = document.createElement("TD");
        td2.appendChild(document.createTextNode(empname1));
        row.appendChild(td2);
        tbt.appendChild(row);
    }
}

function onClick1(source) {
    getData(source);
}

function getData(tableRow) {
    var element = document.getElementById("xgrid");
    var trt = element.getElementsByTagName('TR');
    var currow = tableRow.id;
    var trprev = document.getElementById(prevrow);
    if (trprev != null) {
        var tdtag = trprev.getElementsByTagName('TD');

        if (tdtag.length > 0) {
            tdtag[0].style.backgroundColor = "White";
            tdtag[0].style.color = "Black";
        }
    }
    var tds = tableRow.getElementsByTagName("TD");
    tds[0].style.backgroundColor = "#8868CA";
    tds[0].style.color = "Black";
    prevrow = currow;
    if (GetInnerText(tds[0]) == "No Record Found") {
        var lbl_slno = document.getElementById("txtSearch0");
        lbl_slno.value = "";
    }
    else {
        var lbl_slno = document.getElementById("txtSearch0");
        lbl_slno.value = GetInnerText(tds[0]) + " (" + GetInnerText(tds[1]) + ")";
    }
    empidvalue = GetInnerText(tds[2]);
    employee_code = GetInnerText(tds[1]);
    var grd_serch = document.getElementById("grd_serch");
    grd_serch.style.display = "none";
}

function onRowMouseOver(source) {
    var tdt = source.getElementsByTagName('TD');
    for (var i = 0; i < tdt.length; i++) {
        tdt[i].style.backgroundColor = "lightblue";
    }
}

function onRowMouseOut(source) {
    var tdt = source.getElementsByTagName('TD');
    for (var i = 0; i < tdt.length; i++) {
        tdt[i].style.backgroundColor = "white";
    }
}

function workingday(month, year) {
    var txtWorkDays = document.getElementById("txtWorkDays");
    txtWorkDays.value =new Date(year, month, 0).getDate();
}

function department_onchange() {
    var btnSalCalc = document.getElementById("btnSalCalc");
    var btnSubmit = document.getElementById("btnSubmit");
    var btnDel = document.getElementById("btnDel");
    var ddlDept = document.getElementById("ddlDept");
    var ddlDept_value = ddlDept.options[ddlDept.selectedIndex].value;
    var ddlDesig = document.getElementById("ddlDesig");
    var ddlDesig_value = ddlDesig.options[ddlDesig.selectedIndex].value;
    var txtDate = document.getElementById("txtDate");
    var ddlYear1 = document.getElementById("ddlYear1");
    var ddlYear1_value = ddlYear1.options[ddlYear1.selectedIndex].value;
    var ddlMon = document.getElementById("ddlMon");
    var ddlMon_value = ddlMon.options[ddlMon.selectedIndex].value;
    var ddlMon_txt = ddlMon.options[ddlMon.selectedIndex].text;
    var txtSearch0 = document.getElementById("txtSearch0");
    txtSearch0.value = "";
    if (ddlYear1_value == "0") {
        window.alert("Select Year.");
        ddlYear1.focus();
        ddlDept.options[0].selected = true;
        return false;
    }
    else if (ddlMon_value == "0") {
        window.alert("Select Month.");
        ddlMon.focus();
        ddlDept.options[0].selected = true;
        return false;
    }
    else {
        if (ddlDept_value != "0") {
            PayRoll_Details.ddl_bind_desig(ddlDept_value, Fill_ddldesig_bind);
            if (ddlDesig.options.length > 0) {
                ddlDesig.disabled = false;
            }
            F_Grid();
        }
        else {
         
            var ddlDesig = document.getElementById("ddlDesig");
            for (var count = ddlDesig.options.length - 1; count > -1; count--) {
                ddlDesig.options[count] = null;
            }
            var val;
            var desc;
            var optionitem;
            val = "0";
            desc = "----Select----";;
            optionitem = new Option(desc, val, false, false);
            ddlDesig.options[ddlDesig.length] = optionitem;
            
            var element = document.getElementById("grdEmpSal1");
           
            var trt = element.getElementsByTagName("TR");
            var lnt = trt.length;
            for (var j = 0; j < trt.length; j++) {
                element.deleteRow(j);
                lnt--;
                j--;
            }
            
        }
        ddlDept.focus();
    }
}

function Fill_ddldesig_bind(result) {
    var xml = parseXml(result);
    if (xml) {
        binddesig_dll(xml.documentElement);
    }
}

function binddesig_dll(DistNode) {
    var ddlDesig = document.getElementById("ddlDesig");
    for (var count = ddlDesig.options.length - 1; count > -1; count--) {
        ddlDesig.options[count] = null;
    }
    var val;
    var desc;
    var optionitem;
    val = "0";
    desc = "----Select----";;
    optionitem = new Option(desc, val, false, false);
    ddlDesig.options[ddlDesig.length] = optionitem;

    var IdNode = DistNode.getElementsByTagName('DesigId');
    var DescNode = DistNode.getElementsByTagName('Designation');

    for (var count1 = 0; count1 < IdNode.length; count1++) {
        val = GetInnerText(IdNode[count1]);
        desc = GetInnerText(DescNode[count1]);
        optionitem = new Option(desc, val, false, false);
        ddlDesig.options[ddlDesig.length] = optionitem;
    }
    ddlDesig.options[0].selected = true;
}

function desig_onchange() {
    var ddlYear = document.getElementById("ddlYear");
    var ddlYear_value = ddlYear.options[ddlYear.selectedIndex].value;
    var ddlDept = document.getElementById("ddlDept");
    var ddlDept_value = ddlDept.options[ddlDept.selectedIndex].value;
    var ddlDesig = document.getElementById("ddlDesig");
    if (ddlDept_value == "0") {
        window.alert("Select Department.");
        ddlDept.focus();
        return false;
    }
    else {
        F_Grid();
        ddlDesig.focus();
    }
}

function previous_onclick() {
        $find('ModalPopupExtender5').show();
}

function popup_close_click() {
    $find('ModalPopupExtender5').hide();
}

function onClick(source) {
    $find('ModalPopupExtender5').show();
}

function enddate_onchange() {
    var ddlDept1 = document.getElementById("ddlDept1");
    var ddlDept1_value = ddlDept1.options[ddlDept1.selectedIndex].value;
    var ddlDesig1 = document.getElementById("ddlDesig1");
    var ddlDesig1_value = ddlDesig1.options[ddlDesig1.selectedIndex].value;
    var txt_startdate = document.getElementById("txt_startdate");
    var txt_enddate = document.getElementById("txt_enddate");
    var ddlYear1 = document.getElementById("ddlYear1");
    var ddlYear1_value = ddlYear1.options[ddlYear1.selectedIndex].value;

    if (ddlDept1_value == "0") {
        window.alert("Select Department.");
        ddlDept1.focus();
        return false;
    }
    if (ddlDesig1_value == "0") {
        window.alert("Select Designation.");
        ddlDesig1.focus();
        return false;
    }
    if (txt_startdate.value == "") {
        window.alert("Enter From Date.");
        txt_startdate.focus();
        return false;
    }

    PayRoll_Details.bind_grid_find(ddlYear1_value,ddlDept1_value,ddlDesig1_value,txt_startdate.value,txt_enddate.value, Fill_find_employee_details);
}

function Fill_find_employee_details(result) {
    var xml = parseXml(result); //pass result string into function for xml conversion.
    if (xml) {
        bind_find_grid(xml.documentElement); // call the bindgrid method and pass the root element of of xml form in the function.
    }
}

function bind_find_grid(root) {
    var element = document.getElementById("grdEmpSal1");
    var trt = element.getElementsByTagName("TR");
    var lnt = trt.length;
    for (var i = 0; i < trt.length; i++) {
        element.deleteRow(i);
        lnt--;
        i--;
    }
    var Temp_Employee_Payroll_attendance = root.getElementsByTagName("Temp_Employee_Payroll_attendance");
    var Empid = root.getElementsByTagName("Empid");
    var Empcode = root.getElementsByTagName("Empcode");
    var Empname = root.getElementsByTagName("Empname");
    var Total_Days = root.getElementsByTagName("Total_Days");
    var full_leave = root.getElementsByTagName("full_leave");
    var HBL = root.getElementsByTagName("HBL");
    var HAL = root.getElementsByTagName("HAL");
    var MIS = root.getElementsByTagName("MIS");
    var SLM = root.getElementsByTagName("SLM");
    var SLE = root.getElementsByTagName("SLE");
    var LateHours = root.getElementsByTagName("LateHours");
    var LWApp = root.getElementsByTagName("LWApp");
    var DRleave = root.getElementsByTagName("DRleave");
    var LWP = root.getElementsByTagName("LWP");
    var CRleave = root.getElementsByTagName("CRleave");
    var BalLeave = root.getElementsByTagName("BalLeave");
    var PaidDays = root.getElementsByTagName("PaidDays");
    var InstituteId = root.getElementsByTagName("InstituteId");
    var Year = root.getElementsByTagName("Year");
    var Fromdate = root.getElementsByTagName("Fromdate");
    var ToDate = root.getElementsByTagName("ToDate");
    var deptid = root.getElementsByTagName("deptid");
    var desigid = root.getElementsByTagName("desigid");
    var open_leave = root.getElementsByTagName("open_leave");
    var tbt = document.createElement("TBODY");
    element.appendChild(tbt);

    if (Temp_Employee_Payroll_attendance.length > 0) {
        var headerRow = document.createElement("TR");
        var th1 = document.createElement("TH");
        th1.appendChild(document.createTextNode("Emp Code"));
        th1.style.height = "30px";
        th1.style.fontSize = "11px";
        th1.style.textAlign = "center";

        var th2 = document.createElement("TH");
        th2.appendChild(document.createTextNode("Emp Name"));
        th2.style.height = "30px";
        th2.style.fontSize = "11px";
        th2.style.textAlign = "center";


        var th3 = document.createElement("TH");
        th3.appendChild(document.createTextNode("Total Days"));
        th3.style.height = "30px";
        th3.style.fontSize = "11px";
        th3.style.textAlign = "center";

        var th31 = document.createElement("TH");
        th31.appendChild(document.createTextNode("Op Leave"));
        th31.style.height = "30px";
        th31.style.fontSize = "11px";
        th31.style.textAlign = "center";


        var th4 = document.createElement("TH");
        th4.appendChild(document.createTextNode("Full Leav"));
        th4.style.height = "30px";
        th4.style.fontSize = "11px";
        th4.style.textAlign = "center";


        var th5 = document.createElement("TH");
        th5.appendChild(document.createTextNode("HBL"));
        th5.style.height = "30px";
        th5.style.fontSize = "11px";
        th5.style.textAlign = "center";


        var th6 = document.createElement("TH");
        th6.appendChild(document.createTextNode("HAL"));
        th6.style.height = "30px";
        th6.style.fontSize = "11px";
        th6.style.textAlign = "center";


        var th7 = document.createElement("TH");
        th7.appendChild(document.createTextNode("MIS"));
        th7.style.height = "30px";
        th7.style.fontSize = "11px";
        th7.style.textAlign = "center";


        var th8 = document.createElement("TH");
        th8.appendChild(document.createTextNode("SLM"));
        th8.style.height = "30px";
        th8.style.fontSize = "11px";
        th8.style.textAlign = "center";


        var th9 = document.createElement("TH");
        th9.appendChild(document.createTextNode("SLE"));
        th9.style.height = "30px";
        th9.style.fontSize = "11px";
        th9.style.textAlign = "center";

        var th10 = document.createElement("TH");
        th10.appendChild(document.createTextNode("Late Hours"));
        th10.style.height = "30px";
        th10.style.fontSize = "11px";
        th10.style.textAlign = "center";

        var th11 = document.createElement("TH");
        th11.appendChild(document.createTextNode("LWApp"));
        th11.style.height = "30px";
        th11.style.fontSize = "11px";
        th11.style.textAlign = "center";

        var th12 = document.createElement("TH");
        th12.appendChild(document.createTextNode("Dr Leav"));
        th12.style.height = "30px";
        th12.style.fontSize = "11px";
        th12.style.textAlign = "center";

        var th13 = document.createElement("TH");
        th13.appendChild(document.createTextNode("LWP"));
        th13.style.height = "30px";
        th13.style.fontSize = "11px";
        th13.style.textAlign = "center";


        var th14 = document.createElement("TH");
        th14.appendChild(document.createTextNode("Cr Leav"));
        th14.style.height = "30px";
        th14.style.fontSize = "11px";
        th14.style.textAlign = "center";

        var th15 = document.createElement("TH");
        th15.appendChild(document.createTextNode("Bal Leav"));
        th15.style.height = "30px";
        th15.style.fontSize = "11px";
        th15.style.textAlign = "center";

        var th16 = document.createElement("TH");
        th16.appendChild(document.createTextNode("Paid Days"));
        th16.style.height = "30px";
        th16.style.fontSize = "11px";
        th16.style.textAlign = "center";


        headerRow.appendChild(th1);
        headerRow.appendChild(th2);
        headerRow.appendChild(th3);
        headerRow.appendChild(th31);
        headerRow.appendChild(th4);
        headerRow.appendChild(th5);
        headerRow.appendChild(th6);
        headerRow.appendChild(th7);
        headerRow.appendChild(th8);
        headerRow.appendChild(th9);
        headerRow.appendChild(th10);
        headerRow.appendChild(th11);
        headerRow.appendChild(th12);
        headerRow.appendChild(th13);
        headerRow.appendChild(th14);
        headerRow.appendChild(th15);
        headerRow.appendChild(th16);
        tbt.appendChild(headerRow);
    }

    else {
      
        var txtDate = document.getElementById("txtDate");
        var ddlYear1 = document.getElementById("ddlYear1");
        var ddlYear1_value = ddlYear1.options[ddlYear1.selectedIndex].value;
        var ddlMon = document.getElementById("ddlMon");
        var ddlMon_value = ddlMon.options[ddlMon.selectedIndex].value;
        var ddlDept = document.getElementById("ddlDept");
        var ddlDept_value = ddlDept.options[ddlDept.selectedIndex].value;
        var ddlDesig = document.getElementById("ddlDesig");
        var ddlDesig_value = ddlDesig.options[ddlDesig.selectedIndex].value;
        PayRoll_Details.Get_Search_employee_grid1(ddlYear1_value, ddlMon_value, txtDate.value, empidvalue, ddlDept_value, ddlDesig_value, fill_Search_employee_grid);
        return false;
    }

    if (Temp_Employee_Payroll_attendance.length > 0) {

        for (var x = 0; x < Temp_Employee_Payroll_attendance.length; x++) {

            var row = document.createElement("TR");
            row.title = "Click Here for Search details";
            row.style.cursor = "pointer";
            var rid = "rc" + x;
            row.setAttribute('id', rid);
            row.setAttribute('onclick', "onClick(this);");
         
            var Empid1 = GetInnerText(Empid[x]);
      
            var Empcode1 = GetInnerText(Empcode[x]);
            var Empname1 = GetInnerText(Empname[x]);
            var Total_Days1 = GetInnerText(Total_Days[x]);
            var full_leave1 = GetInnerText(full_leave[x]);
     
            var HBL1 = GetInnerText(HBL[x]);
            var HAL1 = GetInnerText(HAL[x]);
       
            //var MIS1 = GetInnerText(MIS[x]);
            //var SLM1 = GetInnerText(SLM[x]);
            //var SLE1 = GetInnerText(SLE[x]);
       
            //var LateHours1 = GetInnerText(LateHours[x]);
            //var LWApp1 = GetInnerText(LWApp[x]);
            //var DRleave1 = GetInnerText(DRleave[x]);
            //var LWP1 = GetInnerText(LWP[x]);
            //var CRleave1 = GetInnerText(CRleave[x]);
            //var BalLeave1 = GetInnerText(BalLeave[x]);
            //var PaidDays1 = GetInnerText(PaidDays[x]);
            //var InstituteId1 = GetInnerText(InstituteId[x]);
            //var Year1 = GetInnerText(Year[x]);
            //var Fromdate1 = GetInnerText(Fromdate[x]);
            //var ToDate1 = GetInnerText(ToDate[x]);
            //var deptid1 = GetInnerText(deptid[x]);
            var open_leave1 = GetInnerText(open_leave[x]);

            var td2 = document.createElement("TD");
            td2.appendChild(document.createTextNode(Empcode1));

            var td3 = document.createElement("TD");
            td3.appendChild(document.createTextNode(Empname1));

            var td4 = document.createElement("TD");
            td4.appendChild(document.createTextNode(Total_Days1));

            var td41 = document.createElement("TD");
            td41.appendChild(document.createTextNode(open_leave1));

            var td5 = document.createElement("TD");
            td5.appendChild(document.createTextNode(full_leave1));

            var td6 = document.createElement("TD");
            td6.appendChild(document.createTextNode(HBL1));

            var td7 = document.createElement("TD");
            td7.appendChild(document.createTextNode(HAL1));

            var td8 = document.createElement("TD");
            td8.appendChild(document.createTextNode(""));

            var td9 = document.createElement("TD");
            td9.appendChild(document.createTextNode(""));

            var td10 = document.createElement("TD");
            td10.appendChild(document.createTextNode(""));

            var td11 = document.createElement("TD");
            td11.appendChild(document.createTextNode(""));

            var td12 = document.createElement("TD");
            td12.appendChild(document.createTextNode(""));

            var td13 = document.createElement("TD");
            td13.appendChild(document.createTextNode(""));

            var td14 = document.createElement("TD");
            td14.appendChild(document.createTextNode(""));

            var td15 = document.createElement("TD");
            td15.appendChild(document.createTextNode(""));

            var td16 = document.createElement("TD");
            td16.appendChild(document.createTextNode(""));

            var td17 = document.createElement("TD");
            td17.appendChild(document.createTextNode(""));

            row.appendChild(td2);
            row.appendChild(td3);
            row.appendChild(td4);
            row.appendChild(td41);
            row.appendChild(td5);
            row.appendChild(td6);
            row.appendChild(td7);
            row.appendChild(td8);
            row.appendChild(td9);
            row.appendChild(td10);
            row.appendChild(td11);
            row.appendChild(td12);
            row.appendChild(td13);
            row.appendChild(td14);
            row.appendChild(td15);
            row.appendChild(td16);
            row.appendChild(td17);
            tbt.appendChild(row);
        }

        var footerRow = document.createElement("TR");
        var img1 = document.createElement('img');
        img1.style.cursor = "pointer";
        img1.src = "../images/Icon_35-128.png";
        img1.setAttribute("onclick", "previous_onclick();");
        img1.style.height = "25px";
        img1.style.width = "25px";
        img1.title = "Click Here For Previous Details";
        var fh1 = document.createElement("TH");
        fh1.colSpan = "17";
        fh1.style.height = "30px;"
        fh1.style.textAlign = "left";
        fh1.appendChild(img1);
        footerRow.appendChild(fh1);
        tbt.appendChild(footerRow);
    }
}

function Reset_onclick() {
    var txtWorkDays = document.getElementById("txtWorkDays");
    txtWorkDays.value = "";
    var ddlYear1 = document.getElementById("ddlYear1");
    ddlYear1.options[0].selected = true;
    var ddlDept = document.getElementById("ddlDept");
    ddlDept.options[0].selected = true;
    var ddlDesig = document.getElementById("ddlDesig");
    ddlDesig.options[0].selected = true;
    var ddlMon = document.getElementById("ddlMon");
    ddlMon.options[0].selected = true;
    var element = document.getElementById("grdEmpSal1");
    var trt = element.getElementsByTagName("TR");
    var lnt = trt.length;
    for (var j = 0; j < trt.length; j++) {
        element.deleteRow(j);
        lnt--;
        j--;
    }
    var btnSubmit = document.getElementById("btnSubmit");
    btnSubmit.disabled = true;
    var txtDate = document.getElementById("txtDate");
    txtDate.value = "";
    var txtSearch0 = document.getElementById("txtSearch0");
    txtSearch0.value = "";
}

function department_onchange1() {
    var ddlDept1 = document.getElementById("ddlDept1");
    var ddlDept1_value = ddlDept1.options[ddlDept1.selectedIndex].value;
    PayRoll_Details.ddl_bind_desig(ddlDept1_value, Fill_ddldesig_bind1);
}

function Fill_ddldesig_bind1(result) {
    var xml = parseXml(result);
    if (xml) {
        binddesig_dll1(xml.documentElement);
    }
}

function binddesig_dll1(DistNode) {
    var ddlDesig1 = document.getElementById("ddlDesig1");
    for (var count = ddlDesig1.options.length - 1; count > -1; count--) {
        ddlDesig1.options[count] = null;
    }
    var val;
    var desc;
    var optionitem;
    val = "0";
    desc = "----Select----";;
    optionitem = new Option(desc, val, false, false);
    ddlDesig1.options[ddlDesig1.length] = optionitem;

    var IdNode = DistNode.getElementsByTagName('DesigId');
    var DescNode = DistNode.getElementsByTagName('Designation');

    for (var count1 = 0; count1 < IdNode.length; count1++) {
        val = GetInnerText(IdNode[count1]);
        desc = GetInnerText(DescNode[count1]);
        optionitem = new Option(desc, val, false, false);
        ddlDesig1.options[ddlDesig1.length] = optionitem;
    }
    ddlDesig1.options[0].selected = true;
}

function desig_onchange1() {
    var ddlDept1 = document.getElementById("ddlDept1");
    var ddlDept1_value = ddlDept1.options[ddlDept1.selectedIndex].value;
    var ddlDesig1 = document.getElementById("ddlDesig1");
    var ddlDesig1_value = ddlDesig1.options[ddlDesig1.selectedIndex].value;
    var txt_startdate = document.getElementById("txt_startdate");
    var txt_enddate = document.getElementById("txt_enddate");
    var ddlYear1 = document.getElementById("ddlYear1");
    var ddlYear1_value = ddlYear1.options[ddlYear1.selectedIndex].value;
    if (ddlDept1_value != "0") {
        if (ddlDesig1_value != "0") {
            if (txt_startdate.value != "") {
                if (txt_enddate.value != "") {
                    PayRoll_Details.bind_grid_find(ddlYear1_value, ddlDept1_value, ddlDesig1_value, txt_startdate.value, txt_enddate.value, Fill_find_employee_details);
                }
            }
        }
    }
}

var parseXml;
if (window.DOMParser) {
    parseXml = function (xmlStr) {
        return (new window.DOMParser()).parseFromString(xmlStr, "text/xml");
    };
}
else if (typeof window.ActiveXObject != "undefined" && new window.ActiveXObject("Microsoft.XMLDOM")) {
    parseXml = function (xmlStr) {
        var xmlDoc = new window.ActiveXObject("Microsoft.XMLDOM");
        xmlDoc.async = "false";
        xmlDoc.loadXML(xmlStr);
        return xmlDoc;
    };
}
else {
    parseXml = function () { return null; }
}
function GetInnerText(node) {
    return (node.textContent || node.innerText || node.text);
}
