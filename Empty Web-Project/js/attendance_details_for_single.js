
function bind_attendace_data_emp(empid) {
    var prog = document.getElementById("event_popup3");
    prog.style.display = "block";
    Calender_details.bind_attendace_data_emp(empid, valuenumber);
}
function valuenumber(result) {
    var frmvalue = document.getElementById('ctl00_ContentPlaceHolder1_Div4').innerHTML = result;
    var prog = document.getElementById("event_popup3");
    prog.style.display = "none";
}
function close_popup() {
    var tp = document.getElementById('event_popup2')
    tp.style.display = "none";
}


function close_popup_notification() {

    var tp = document.getElementById('modal_popup_leave')
    tp.style.display = "none";
}
function show_leave_popup() {
    var tp = document.getElementById('Leave_popup')
    tp.style.top = "20%";
    tp.style.left = "10%";
    tp.style.display = "block";
}
function Leave_popup_close() {
    var tp = document.getElementById('Leave_popup')
    tp.style.display = "none";
}

function Get_Full_salary_details() {
    var tp = document.getElementById('modal_popup_salary')
    tp.style.display = "block";
    tp.style.top = "10%";
    tp.style.left = "10%";
    tp.style.display = "block";
    Calender_details.bind_Employee_Salary_Details_single(get_Salary_details);
}

function get_Salary_details(result) {

    if (result == "0") {
        var mypoup = document.getElementById('modal_popup_salary');
        mypoup.innerHTML = "";
        mypoup.style.display = "none";
    }
    else {
        var mypoup = document.getElementById('modal_popup_salary');
        mypoup.innerHTML = result;
    }
}

function close_popup_notification_sal() {
    var mypoup = document.getElementById('modal_popup_salary');
    mypoup.innerHTML = "";
    mypoup.style.display = "none";
}

function rowClick(val) {

    var tp = document.getElementById('modal_popup_leave')
    tp.style.display = "block";
    tp.style.top = "5%";
    tp.style.left = "10%";
    tp.style.display = "block";
    Calender_details.bind_Employee_Leave_Notifications_single(val, fill_leave_notification);
}

function rowClick1(val) {
    location.href = "Employee_personal_Details.aspx?empcode='" + val + "'&type=emp";
}

function fill_leave_notification(result) {
    var xml = parseXml(result); //pass result string into function for xml conversion.
    if (xml) {
        bindgrid_leave_notification(xml.documentElement); // call the bindgrid method and pass the root element of of xml form in the function.
    }
}

function bindgrid_leave_notification(root) {
    var rejectid_val = document.getElementById("rejectid_val");
    rejectid_val.style.display = "none";
    var element = document.getElementById("mGrid1");
    var trt = element.getElementsByTagName("TR");
    var lnt = trt.length;
    for (var i = 0; i < trt.length; i++) {
        element.deleteRow(i);
        lnt--;
        i--;
    }

    var Emp_Leave_Record_dtlschld = root.getElementsByTagName("Emp_Leave_Record_dtlschld");
    var EmpCode = root.getElementsByTagName("EmpCode");
    var LeaveDate = root.getElementsByTagName("LeaveDate");
    var Application_No = root.getElementsByTagName("Application_No");
    var LeaveId = root.getElementsByTagName("LeaveId");
    var Leave_Type = root.getElementsByTagName("Leave_Type");
    var AuthorityId = root.getElementsByTagName("AuthorityId");
    var LeaveHead = root.getElementsByTagName("LeaveHead");
    var empname = root.getElementsByTagName("empname");
    var DepartmentName = root.getElementsByTagName("DepartmentName");
    var SessionId = root.getElementsByTagName("SessionId");
    var Status = root.getElementsByTagName("Status");
    var tbt = document.createElement("TBODY");
    element.appendChild(tbt);

    var EmpCode2 = GetInnerText(EmpCode[0]);
    var SessionId2 = GetInnerText(SessionId[0]);
    var empname2 = GetInnerText(empname[0]);
    var Label4 = document.getElementById("ctl00_ContentPlaceHolder1_Label4");
    var Label10 = document.getElementById("ctl00_ContentPlaceHolder1_Label10");
    var Label11 = document.getElementById("ctl00_ContentPlaceHolder1_Label11");
    Label4.innerText ="Emp Code :"+ EmpCode2;
    Label4.textContent ="Emp Code :" + EmpCode2;
    Label10.innerText ="Emp Name :"+ empname2;
    Label10.textContent ="Emp Name :" + empname2
    Label11.innerText ="Session :"+ SessionId2;
    Label11.textContent = "Session :" + SessionId2;
    if (Emp_Leave_Record_dtlschld.length != 0) {
    }
    else {
        var blankRow = document.createElement("TR");
        var blanktd = document.createElement("TD");
        blanktd.style.verticalAlign = "middle";
        blanktd.style.textAlign = "center";
        blanktd.style.width = "80%";
        var img = document.createElement("img");
        img.src = "../images/no_data.png";
        blanktd.appendChild(img);
        blankRow.appendChild(blanktd);
        tbt.appendChild(blankRow);
    }
    if (Emp_Leave_Record_dtlschld.length > 0) {
        for (var x = 0; x < Emp_Leave_Record_dtlschld.length; x++) {
            var row = document.createElement("TR");
            var rid = "rc" + x;
            row.setAttribute('id', rid);

            var EmpCode1 = GetInnerText(EmpCode[x]);
            var LeaveDate1 = GetInnerText(LeaveDate[x]);
            var Application_No1 = GetInnerText(Application_No[x]);
            var LeaveId1 = GetInnerText(LeaveId[x]);
            var Leave_Type1 = GetInnerText(Leave_Type[x]);
            var AuthorityId1 = GetInnerText(AuthorityId[x]);
            var LeaveHead1 = GetInnerText(LeaveHead[x]);

            var td1 = document.createElement("TD");
            td1.appendChild(document.createTextNode(Application_No1));
            td1.style.width = "20%";
            td1.style.textAlign = "left";
            td1.style.fontSize = "11px";
           

            var td2 = document.createElement("TD");
            td2.appendChild(document.createTextNode(LeaveDate1));
            td2.style.width = "20%";
            td2.style.textAlign = "left";
            td2.style.fontSize = "11px";
           

            var td3 = document.createElement("TD");
            td3.appendChild(document.createTextNode(LeaveId1));
            td3.style.width = "20%";
            td3.style.textAlign = "left";
            td3.style.fontSize = "11px";
         

            var td4 = document.createElement("TD");
            td4.appendChild(document.createTextNode(Leave_Type1));
            td4.style.width = "20%";
            td4.style.textAlign = "left";
            td4.style.fontSize = "11px";
          

            var main_mi1 = document.createElement("input");
            main_mi1.setAttribute('type', 'checkbox');
            main_mi1.setAttribute('value', '');
            main_mi1.setAttribute('id', 'check' + rid);
            var td5 = document.createElement("TD");
            td5.appendChild(main_mi1);
            td5.style.width = "20%";
            td5.style.textAlign = "center";
            td5.style.fontSize = "11px";

            var td6 = document.createElement("TD");
            td6.appendChild(document.createTextNode(EmpCode1));
            td6.style.width = "20%";
            td6.style.textAlign = "left";
            td6.style.fontSize = "11px";
            td6.style.display = "none";

            row.appendChild(td1);
            row.appendChild(td2);
            row.appendChild(td3);
            row.appendChild(td4);
            row.appendChild(td6);
            row.appendChild(td5);
            tbt.appendChild(row);
        }
    }

}


function leave_approve() {
    var element = document.getElementById("mGrid1");
    var rejectid_val = document.getElementById("rejectid_val");
    rejectid_val.style.display = "none";
    var trt = element.getElementsByTagName("TR");
    var lnt = trt.length;
    var arr1 = new Array(lnt);
    var arr2 = new Array(lnt);
    var arr3 = new Array(lnt);
    var arr4 = new Array(lnt);
    var val = 0;
    for (var i = 0; i < trt.length; i++) {
        var checkbox1 = document.getElementById("checkrc" + i);
        if (checkbox1.checked == true) {
            var tds = element.rows[i].cells[0].innerHTML;
            var tds1 = element.rows[i].cells[1].innerHTML;
            var tds2 = element.rows[i].cells[2].innerHTML;
            var tds3 = element.rows[i].cells[3].innerHTML;
            var tds4 = element.rows[i].cells[4].innerHTML;
            arr1[val] = tds;
            arr2[val] = tds1;
            arr3[val] = tds2;
            arr4[val] = tds4;
            val = Number(val)+1;
        }
    }
    Calender_details.update_leave_deails(arr4, arr2, arr3, fill_approve_notification);
}

function leave_reject() {
    var element = document.getElementById("mGrid1");
    var trt = element.getElementsByTagName("TR");
    var lnt = trt.length;
    var arr1 = new Array(lnt);
    var arr2 = new Array(lnt);
    var arr3 = new Array(lnt);
    var arr4 = new Array(lnt);
    var val = 0;
    for (var i = 0; i < trt.length; i++) {
        var checkbox1 = document.getElementById("checkrc" + i);
        if (checkbox1.checked == true) {
            var tds = element.rows[i].cells[0].innerHTML;
            var tds1 = element.rows[i].cells[1].innerHTML;
            var tds2 = element.rows[i].cells[2].innerHTML;
            var tds3 = element.rows[i].cells[3].innerHTML;
            var tds4 = element.rows[i].cells[4].innerHTML;
            arr1[val] = tds;
            arr2[val] = tds1;
            arr3[val] = tds2;
            arr4[val] = tds4;
            val = Number(val) + 1;
        }
    }
    var rejectid_val = document.getElementById("rejectid_val");
    rejectid_val.style.display = "block";
    var rjedt = document.getElementById("rjedt");
    if (rjedt.value == "") {
        window.alert("Enter leave reject reason.");
        rjedt.focus();
        return false;
    }
    Calender_details.update_leave_reject_deails(arr4, arr2, arr3,rjedt.value, fill_reject_notification);
}

function fill_approve_notification(result) {
    if (result != "0") {
        var tp = document.getElementById('modal_popup_leave')
        tp.innerHTML = "";
        tp.style.display = "none";
        GetCurrentTime();
    }

}

function fill_reject_notification(result) {
    if (result != "0") {
        var tp = document.getElementById('modal_popup_leave')
        tp.innerHTML = "";
        tp.style.display = "none";
        GetCurrentTime();
    }
}

function GetCurrentTime() {
    __doPostBack("<%=UpdatePanel41.UniqueID %>", "");
}

function check_full_total_leave(val) {

    var new_vale = val.substring(41, 50);
    var atten = new_vale.split('_');
    var atten1 = atten[0].split('l');
    var get_value = document.getElementById("ctl00_ContentPlaceHolder1_Grd_attendance_ctl" + atten1[1] + "_Label31").innerHTML;

}

function check_half_leave(val) {

    var new_vale = val.substring(41, 50);
    var atten = new_vale.split('_');
    var atten1 = atten[0].split('l');
    var Status = 'Leave';
    var leave_type_val = 'Half Leave';
    var get_value = document.getElementById("ctl00_ContentPlaceHolder1_Grd_attendance_ctl" + atten1[1] + "_Label31").innerHTML;
    var mypoup = document.getElementById('event_popup2');
    mypoup.style.top = "5%";
    mypoup.style.left = "10%";
    mypoup.style.display = "block";

    Calender_details.bind_single_leave_details(get_value, leave_type_val, Status, fill_leave_details);
}

function fill_leave_details(result) {
    if (result == "0") {
        var mypoup = document.getElementById('event_popup2');
        mypoup.innerHTML = "";
        mypoup.style.display = "none";
    }
    else {
        var mypoup = document.getElementById('event_popup2');
        mypoup.innerHTML = result;

    }

}

function check_full_leave(val) {
    var new_vale = val.substring(41, 50);
    var atten = new_vale.split('_');
    var atten1 = atten[0].split('l');
    var Status = 'Leave';
    var leave_type_val = 'Full Leave';
    var get_value = document.getElementById("ctl00_ContentPlaceHolder1_Grd_attendance_ctl" + atten1[1] + "_Label31").innerHTML;
    var mypoup = document.getElementById('event_popup2');
    mypoup.style.top = "5%";
    mypoup.style.left = "10%";
    mypoup.style.display = "block";
    Calender_details.bind_single_leave_details(get_value, leave_type_val, Status, fill_leave_details);
}

function check_half_reject_leave(val) {
    var new_vale = val.substring(41, 50);
    var atten = new_vale.split('_');
    var atten1 = atten[0].split('l');
    var Status = 'Reject';
    var leave_type_val = 'Half Leave';
    var get_value = document.getElementById("ctl00_ContentPlaceHolder1_Grd_attendance_ctl" + atten1[1] + "_Label31").innerHTML;
    var mypoup = document.getElementById('event_popup2');
    mypoup.style.top = "5%";
    mypoup.style.left = "10%";
    mypoup.style.display = "block";
    Calender_details.bind_single_leave_details(get_value, leave_type_val, Status, fill_leave_details);

}

function rowOver(valeue1) {
    aler("ok");
}

function rowout(valeue1) {
    aler("ok");
}


function check_full_reject_leave(val) {
    var new_vale = val.substring(41, 50);
    var atten = new_vale.split('_');
    var atten1 = atten[0].split('l');
    var Status = 'Reject';
    var leave_type_val = 'Full Leave';
    var get_value = document.getElementById("ctl00_ContentPlaceHolder1_Grd_attendance_ctl" + atten1[1] + "_Label31").innerHTML;
    var mypoup = document.getElementById('event_popup2');
    mypoup.style.top = "5%";
    mypoup.style.left = "10%";
    mypoup.style.display = "block";
    Calender_details.bind_single_leave_details(get_value, leave_type_val, Status, fill_leave_details);

}

function check_half_pending_leave(val) {
    var new_vale = val.substring(41, 50);
    var atten = new_vale.split('_');
    var atten1 = atten[0].split('l');

    var Status = 'Forward';
    var leave_type_val = 'Half Leave';
    var get_value = document.getElementById("ctl00_ContentPlaceHolder1_Grd_attendance_ctl" + atten1[1] + "_Label31").innerHTML;
    var mypoup = document.getElementById('event_popup2');
    mypoup.style.top = "5%";
    mypoup.style.left = "10%";
    mypoup.style.display = "block";
    Calender_details.bind_single_leave_details(get_value, leave_type_val, Status, fill_leave_details);

}

function check_full_pending_leave(val) {
    var new_vale = val.substring(41, 50);
    var atten = new_vale.split('_');
    var atten1 = atten[0].split('l');
    var Status = 'Forward';
    var leave_type_val = 'Full Leave';
    var get_value = document.getElementById("ctl00_ContentPlaceHolder1_Grd_attendance_ctl" + atten1[1] + "_Label31").innerHTML;
    var mypoup = document.getElementById('event_popup2');
    mypoup.style.top = "5%";
    mypoup.style.left = "10%";
    mypoup.style.display = "block";
    Calender_details.bind_single_leave_details(get_value, leave_type_val, Status, fill_leave_details);

}

function check_half_cancel_leave(val) {
    var new_vale = val.substring(41, 50);
    var atten = new_vale.split('_');
    var atten1 = atten[0].split('l');
    var Status = 'Cancel';
    var leave_type_val = 'Half Leave';
    var get_value = document.getElementById("ctl00_ContentPlaceHolder1_Grd_attendance_ctl" + atten1[1] + "_Label31").innerHTML;
    var mypoup = document.getElementById('event_popup2');
    mypoup.style.top = "5%";
    mypoup.style.left = "10%";
    mypoup.style.display = "block";
    Calender_details.bind_single_leave_details(get_value, leave_type_val, Status, fill_leave_details);

}

function check_full_cancel_leave(val) {
    var new_vale = val.substring(41, 50);
    var atten = new_vale.split('_');
    var atten1 = atten[0].split('l');
    var Status = 'Calcel';
    var leave_type_val = 'Full Leave';
    var get_value = document.getElementById("ctl00_ContentPlaceHolder1_Grd_attendance_ctl" + atten1[1] + "_Label31").innerHTML;
    var mypoup = document.getElementById('event_popup2');
    mypoup.style.top = "5%";
    mypoup.style.left = "10%";
    mypoup.style.display = "block";
    Calender_details.bind_single_leave_details(get_value, leave_type_val, Status, fill_leave_details);

}

function check_full_get_leave(val) {
    var new_vale = val.substring(41, 50);
    var atten = new_vale.split('_');
    var atten1 = atten[0].split('l');
    var get_value = document.getElementById("ctl00_ContentPlaceHolder1_Grd_attendance_ctl" + atten1[1] + "_Label31").innerHTML;

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

