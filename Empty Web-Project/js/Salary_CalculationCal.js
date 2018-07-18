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
var empidvalue;
var employee_code;
 
function init() {
    PayRoll_Details.Salary_Page_Load_details(Fill_Payroll_details_bind);
}

function Fill_Payroll_details_bind(result) {
    result_value = result.split('&');
    session = result_value[0];
    Mname = result_value[1];
    FromDate = result_value[2];
    ToDate = result_value[3];
    Year = result_value[4];
    var ddlYear = document.getElementById("ddlYear");

    var ddlYear1 = document.getElementById("ddlYear1");

    var ddlMon = document.getElementById("ddlMon");

    var txtWorkDays = document.getElementById("txtWorkDays");

    var btnSubmit = document.getElementById("btnSubmit");

    var btnSalCalc = document.getElementById("btnSalCalc");

    if (Number(Mname) >= 3) {
        btnSalCalc.disabled = true;
    }
    else {
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

        if (Year == yearval1) {
            optionitem1 = new Option(yearval1, yearval1, false, false);
            ddlYear1.options[ddlYear1.length] = optionitem1;
        }
        else {
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
        ddlMon.options[0].selected = true;
        return false;
    }
    else if (ddlMon_value == "0") {
        ddlMon.options[0].selected = true;
        ddlMon.focus();
    }
    else {
      
        workingday(ddlMon_value, ddlYear1_value);
        var datefull = ddlYear1_value + "-" + ddlMon_value + "-" + new Date(ddlYear1_value, ddlMon_value, 0).getDate();
        if (empidvalue != "0") {
            F_GridSearch();
        }
        else {
            F_Grid();
        }
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
    var ddlDept = document.getElementById("ddlDept");
    var ddlDept_value = ddlDept.options[ddlDept.selectedIndex].value;
    var ddlDesig = document.getElementById("ddlDesig");
    var ddlDesig_value = ddlDesig.options[ddlDesig.selectedIndex].value;
    var txt = document.getElementById("txtSearch0");
    PayRoll_Details.BindEmployee_grid_search_new(txt.value, ddlDept_value, ddlDesig_value, Fill_empsearch);
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

    var ddlYear1 = document.getElementById("ddlYear1");
    var ddlYear1_value = ddlYear1.options[ddlYear1.selectedIndex].value;
    var ddlMon = document.getElementById("ddlMon");
    var ddlMon_value = ddlMon.options[ddlMon.selectedIndex].value;
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
    get_value_employe_salary();
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
    txtWorkDays.value = new Date(year, month, 0).getDate();
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
    desc = "----Select----";
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
    PayRoll_Details.Get_Search_employee_Salary_grid(ddlYear1_value, ddlMon_value,ddlMon_txt, empidvalue, Fill_Employee_Salary_grid_bind);
}
function Fill_Employee_Salary_grid_bind(result) {
    var xml = parseXml(result); //pass result string into function for xml conversion.
    if (xml) {
        bindEmployee_salary_grid(xml.documentElement); // call the bindgrid method and pass the root element of of xml form in the function.
    }
}

function bindEmployee_salary_grid(root) {

    var element = document.getElementById("grdEmpSal1");
    var trt = element.getElementsByTagName("TR");
    var lnt = trt.length;
    for (var i = 0; i < trt.length; i++) {
        element.deleteRow(i);
        lnt--;
        i--;
    }

    var Temp_Employee_Wage_type_Salary = root.getElementsByTagName("Temp_Employee_Wage_type_Salary");
    var empid = root.getElementsByTagName("empid");
    var empcode = root.getElementsByTagName("empcode");
    var empname = root.getElementsByTagName("empname");
    var AdditionalAllowance = root.getElementsByTagName("AdditionalAllowance");
    var Advance = root.getElementsByTagName("Advance");
    var ArrearsExtras = root.getElementsByTagName("ArrearsExtras");
    var Basic = root.getElementsByTagName("Basic");
    var Conveyance = root.getElementsByTagName("Conveyance");
    var DA = root.getElementsByTagName("DA");
    var DARDeduction = root.getElementsByTagName("DARDeduction");
    var ESI = root.getElementsByTagName("ESI");
    var ExtraAllw = root.getElementsByTagName("ExtraAllw");
    var ExtraDeduct = root.getElementsByTagName("ExtraDeduct");
    var Hostel = root.getElementsByTagName("Hostel");
    var HRA = root.getElementsByTagName("HRA");
    var Insurance = root.getElementsByTagName("Insurance");
    var LateHoursDeduction = root.getElementsByTagName("LateHoursDeduction");
    var MealVoucher = root.getElementsByTagName("MealVoucher");
    var Other = root.getElementsByTagName("Other");
    var Othersadvance = root.getElementsByTagName("Othersadvance");
    var PF = root.getElementsByTagName("PF");
    var Phone = root.getElementsByTagName("Phone");
    var ProfessionalDevelopment = root.getElementsByTagName("ProfessionalDevelopment");
    var SpecialAllowance = root.getElementsByTagName("SpecialAllowance");
    var TDS = root.getElementsByTagName("TDS");
    var VARIABLEPERFORMANCEINCENTIVE = root.getElementsByTagName("VARIABLEPERFORMANCEINCENTIVE");
    var Mothname = root.getElementsByTagName("Mothname");
    var Mothid = root.getElementsByTagName("Mothid");
    var Year = root.getElementsByTagName("Year");
    var basicid = root.getElementsByTagName("basicid");
    var instiid = root.getElementsByTagName("instiid");
    var MedicalAllowance = root.getElementsByTagName("MedicalAllowance");
    var SalesIncentives = root.getElementsByTagName("SalesIncentives");
    var TotA = root.getElementsByTagName("TotA");
    var Totd = root.getElementsByTagName("Totd");
    var Totv = root.getElementsByTagName("Totv");
    var Netsal = root.getElementsByTagName("Netsal");
    var Atten = root.getElementsByTagName("Atten");
    var PayMode = root.getElementsByTagName("PayMode");
    
    var tbt = document.createElement("TBODY");
    element.appendChild(tbt);
    if (Temp_Employee_Wage_type_Salary.length > 0) {
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
        th3.appendChild(document.createTextNode("Atten"));
        th3.style.height = "30px";
        th3.style.fontSize = "11px";
        th3.style.textAlign = "center";

        var th4 = document.createElement("TH");
        th4.appendChild(document.createTextNode("Basic"));
        th4.style.height = "30px";
        th4.style.fontSize = "11px";
        th4.style.textAlign = "center";

        var th5 = document.createElement("TH");
        th5.appendChild(document.createTextNode("DA"));
        th5.style.height = "30px";
        th5.style.fontSize = "11px";
        th5.style.textAlign = "center";

        var th6 = document.createElement("TH");
        th6.appendChild(document.createTextNode("HRA"));
        th6.style.height = "30px";
        th6.style.fontSize = "11px";
        th6.style.textAlign = "center";

        var th7 = document.createElement("TH");
        th7.appendChild(document.createTextNode("Conv"));
        th7.style.height = "30px";
        th7.style.fontSize = "11px";
        th7.style.textAlign = "center";

        var th8 = document.createElement("TH");
        th8.appendChild(document.createTextNode("Med Allow"));
        th8.style.height = "30px";
        th8.style.fontSize = "11px";
        th8.style.textAlign = "center";

        var th9 = document.createElement("TH");
        th9.appendChild(document.createTextNode("Phone"));
        th9.style.height = "30px";
        th9.style.fontSize = "11px";
        th9.style.textAlign = "center";

        var th10 = document.createElement("TH");
        th10.appendChild(document.createTextNode("Meal Voucher"));
        th10.style.height = "30px";
        th10.style.fontSize = "11px";
        th10.style.textAlign = "center";

        var th11 = document.createElement("TH");
        th11.appendChild(document.createTextNode("Sales Incentives"));
        th11.style.height = "30px";
        th11.style.fontSize = "11px";
        th11.style.textAlign = "center";

        var th12 = document.createElement("TH");
        th12.appendChild(document.createTextNode("Add Allow"));
        th12.style.height = "30px";
        th12.style.fontSize = "11px";
        th12.style.textAlign = "center";

        var th13 = document.createElement("TH");
        th13.appendChild(document.createTextNode("Arrears/ Extras"));
        th13.style.height = "30px";
        th13.style.fontSize = "11px";
        th13.style.textAlign = "center";

        var th14 = document.createElement("TH");
        th14.appendChild(document.createTextNode("Special Allow"));
        th14.style.height = "30px";
        th14.style.fontSize = "11px";
        th14.style.textAlign = "center";

        var th15 = document.createElement("TH");
        th15.appendChild(document.createTextNode("Prof Devel"));
        th15.style.height = "30px";
        th15.style.fontSize = "11px";
        th15.style.textAlign = "center";

        var th16 = document.createElement("TH");
        th16.appendChild(document.createTextNode("PF"));
        th16.style.height = "30px";
        th16.style.fontSize = "11px";
        th16.style.textAlign = "center";

        var th17 = document.createElement("TH");
        th17.appendChild(document.createTextNode("ESI"));
        th17.style.height = "30px";
        th17.style.fontSize = "11px";
        th17.style.textAlign = "center";

        var th18 = document.createElement("TH");
        th18.appendChild(document.createTextNode("TDS"));
        th18.style.height = "30px";
        th18.style.fontSize = "11px";
        th18.style.textAlign = "center";

        var th19 = document.createElement("TH");
        th19.appendChild(document.createTextNode("Advance"));
        th19.style.height = "30px";
        th19.style.fontSize = "11px";
        th19.style.textAlign = "center";

        var th20 = document.createElement("TH");
        th20.appendChild(document.createTextNode("Extra Deduct"));
        th20.style.height = "30px";
        th20.style.fontSize = "11px";
        th20.style.textAlign = "center";

        var th21 = document.createElement("TH");
        th21.appendChild(document.createTextNode("DAR Ded"));
        th21.style.height = "30px";
        th21.style.fontSize = "11px";
        th21.style.textAlign = "center";

        var th22 = document.createElement("TH");
        th22.appendChild(document.createTextNode("Late Hours Ded"));
        th22.style.height = "30px";
        th22.style.fontSize = "11px";
        th22.style.textAlign = "center";

        var th23 = document.createElement("TH");
        th23.appendChild(document.createTextNode("Insu"));
        th23.style.height = "30px";
        th23.style.fontSize = "11px";
        th23.style.textAlign = "center";

        var th24 = document.createElement("TH");
        th24.appendChild(document.createTextNode("Total Allow"));
        th24.style.height = "30px";
        th24.style.fontSize = "11px";
        th24.style.textAlign = "center";

        var th25 = document.createElement("TH");
        th25.appendChild(document.createTextNode("Total Deduction"));
        th25.style.height = "30px";
        th25.style.fontSize = "11px";
        th25.style.textAlign = "center";

        var th26 = document.createElement("TH");
        th26.appendChild(document.createTextNode("Net Salary"));
        th26.style.height = "30px";
        th26.style.fontSize = "11px";
        th26.style.textAlign = "center";

        var th27 = document.createElement("TH");
        th27.appendChild(document.createTextNode("Payment Mode"));
        th27.style.height = "30px";
        th27.style.fontSize = "11px";
        th27.style.textAlign = "center";

        headerRow.appendChild(th1);
        headerRow.appendChild(th2);
        headerRow.appendChild(th3);
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
        headerRow.appendChild(th17);
        headerRow.appendChild(th18);
        headerRow.appendChild(th19);
        headerRow.appendChild(th20);
        headerRow.appendChild(th21);
        headerRow.appendChild(th22);
        headerRow.appendChild(th23);
        headerRow.appendChild(th24);
        headerRow.appendChild(th25);
        headerRow.appendChild(th26);
        headerRow.appendChild(th27);
        tbt.appendChild(headerRow);
    }
    else {

    }
    
    if (Temp_Employee_Wage_type_Salary.length > 0) {

        for (var x = 0; x <= Temp_Employee_Wage_type_Salary.length; x++) {
            var row = document.createElement("TR");
            row.title = "Click Here for Search details";
            row.style.cursor = "pointer";
            var rid = "rc" + x;
            row.setAttribute('id', rid);
            row.setAttribute('onclick', "onClick(this);");  
          
            var empid1 = GetInnerText(empid[x]);
            var empcode1 = GetInnerText(empcode[x]);
            var empname1 = GetInnerText(empname[x]);
     
            var AdditionalAllowance1 = GetInnerText(AdditionalAllowance[x]);
            var Advance1 = GetInnerText(Advance[x]);
            var ArrearsExtras1 = GetInnerText(ArrearsExtras[x]);
            
            var Basic1 = GetInnerText(Basic[x]);

         
            var Conveyance1 = GetInnerText(Conveyance[x]);
            var DA1 = GetInnerText(DA[x]);
            var DARDeduction1 = GetInnerText(DARDeduction[x]);
            var ESI1 = GetInnerText(ESI[x]);
            var ExtraAllw1 = GetInnerText(ExtraAllw[x]);
            var ExtraDeduct1 = GetInnerText(ExtraDeduct[x]);
            var Hostel1 = GetInnerText(Hostel[x]);
            var HRA1 = GetInnerText(HRA[x]);
            var Insurance1 = GetInnerText(Insurance[x]);
            var LateHoursDeduction1 = GetInnerText(LateHoursDeduction[x]);
            var MealVoucher1 = GetInnerText(MealVoucher[x]);
            var Other1 = GetInnerText(Other[x]);
            var Othersadvance1 = GetInnerText(Othersadvance[x]);
            var PF1 = GetInnerText(PF[x]);
            var Phone1 = GetInnerText(Phone[x]);
            var ProfessionalDevelopment1 = GetInnerText(ProfessionalDevelopment[x]);
            var SpecialAllowance1 = GetInnerText(SpecialAllowance[x]);
            var TDS1 = GetInnerText(TDS[x]);
            var VARIABLEPERFORMANCEINCENTIVE1 = GetInnerText(VARIABLEPERFORMANCEINCENTIVE[x]);
            var Mothname1 = GetInnerText(Mothname[x]);
            var Mothid1 = GetInnerText(Mothid[x]);
     
            var Year1 = GetInnerText(Year[x]);
         
            var basicid1 = GetInnerText(basicid[x]);
            var instiid1 = GetInnerText(instiid[x]);
         
            var MedicalAllowance1 = GetInnerText(MedicalAllowance[x]);
            var SalesIncentives1 = GetInnerText(SalesIncentives[x]);
           
            var TotA1 = GetInnerText(TotA[x]);
            var Totd1 = GetInnerText(Totd[x]);
            var Totv1 = GetInnerText(Totv[x]);
            var Netsal1 = GetInnerText(Netsal[x]);
            var Atten1 = GetInnerText(Atten[x]);
            var PayMode1 = GetInnerText(PayMode[x]);

            var td1 = document.createElement("TD");
            td1.appendChild(document.createTextNode(empcode1));

            var td2 = document.createElement("TD");
            td2.appendChild(document.createTextNode(empname1));

            var td3 = document.createElement("TD");
            td3.appendChild(document.createTextNode(Atten1));

            var td4 = document.createElement("TD");
            td4.appendChild(document.createTextNode(Basic1));

            var td5 = document.createElement("TD");
            td5.appendChild(document.createTextNode(DA1));

            var td6 = document.createElement("TD");
            td6.appendChild(document.createTextNode(HRA1));

            var td7 = document.createElement("TD");
            td7.appendChild(document.createTextNode(Conveyance1));

            var td8 = document.createElement("TD");
            td8.appendChild(document.createTextNode(MedicalAllowance1));

            var td9 = document.createElement("TD");
            td9.appendChild(document.createTextNode(Phone1));

            var td10 = document.createElement("TD");
            td10.appendChild(document.createTextNode(MealVoucher1));

            var td11 = document.createElement("TD");
            td11.appendChild(document.createTextNode(SalesIncentives1));

            var td12 = document.createElement("TD");
            td12.appendChild(document.createTextNode(AdditionalAllowance1));

            var td13 = document.createElement("TD");
            td13.appendChild(document.createTextNode(ArrearsExtras1));

            var td14 = document.createElement("TD");
            td14.appendChild(document.createTextNode(SpecialAllowance1));

            var td15 = document.createElement("TD");
            td15.appendChild(document.createTextNode(ProfessionalDevelopment1));

            var td16 = document.createElement("TD");
            td16.appendChild(document.createTextNode(PF1));

            var td17= document.createElement("TD");
            td17.appendChild(document.createTextNode(ESI1));

            var td18 = document.createElement("TD");
            td18.appendChild(document.createTextNode(TDS1));

            var td19 = document.createElement("TD");
            td19.appendChild(document.createTextNode(Advance1));

            var td20 = document.createElement("TD");
            td20.appendChild(document.createTextNode(ExtraDeduct1));

            var td21 = document.createElement("TD");
            td21.appendChild(document.createTextNode(DARDeduction1));

            var td22 = document.createElement("TD");
            td22.appendChild(document.createTextNode(LateHoursDeduction1));

            var td23 = document.createElement("TD");
            td23.appendChild(document.createTextNode(Insurance1));

            var td24 = document.createElement("TD");
            td24.appendChild(document.createTextNode(TotA1));


            var td25 = document.createElement("TD");
            td25.appendChild(document.createTextNode(Totd1));

            var td26 = document.createElement("TD");
            td26.appendChild(document.createTextNode(Netsal1));

            var td27 = document.createElement("TD");
            td27.appendChild(document.createTextNode(PayMode1));

            row.appendChild(td1);
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
            row.appendChild(td19);
            row.appendChild(td20);
            row.appendChild(td21);
            row.appendChild(td22);
            row.appendChild(td23);
            row.appendChild(td24);
            row.appendChild(td25);
            row.appendChild(td26);
            row.appendChild(td27);
            tbt.appendChild(row);

        }
    }
    
}

function get_Value_employee_change() {
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
 
        PayRoll_Details.Get_Search_employee_grid_month(ddlYear1_value, ddlMon_value, Get_month_details_value);
  
}

function get_value_employe_salary() {
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
    PayRoll_Details.Get_Search_employee_Salary_grid(ddlYear1_value, ddlMon_value, ddlMon_txt, empidvalue, Fill_Employee_Salary_grid_bind);
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
    var str = "A";
    if (str != "") {
        PayRoll_Details.Get_Search_employee_grid_month(ddlYear1_value, ddlMon_value, Get_month_details_value1);
    }
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
    PayRoll_Details.Get_Search_employee_Salary_grid_emp(ddlYear1_value, ddlMon_value, ddlMon_txt, ddlDept_value,ddlDesig_value, Fill_Employee_Salary_grid_bind);
}

function desigantion_onchange() {
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
    PayRoll_Details.Get_Search_employee_Salary_grid_emp(ddlYear1_value, ddlMon_value, ddlMon_txt, ddlDept_value, ddlDesig_value, Fill_Employee_Salary_grid_bind);
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



