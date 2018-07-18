var days = new Array('Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday');
var months = new Array('January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December');
var day_name = new Array();
var monthname = new Array();
var leavename = new Array();
var yearName = new Array();

var new_month;
var new_year;
var new_date;
var new_day;
var new_firstDay;
var dis_value;
var dis_value1;
var holiday_valu = "";
var todo_list = "";
var cur_year = "";
//window.onload = writeCalendar1;

window.onload = lnk;

function lnk() {
    var now = new Date();
    var year = now.getFullYear();
    var calender = document.getElementById("insert_calender");
    var Calender1 = document.getElementById("DivCalender");
    Calender_details.hodiday_detail(year, getdata1);
}
function bind_month_value1() {
    Calender_details.bind_attendace_data(valuenumber);
}

function valuenumber(result) {
    var frmvalue = document.getElementById('Div4').innerHTML = result;
    var frmvalue = document.getElementById('bind_share').innerHTML = "";
    Calender_details.Bindshare_value_onload(fill_result_value_inserted_new);
}

function fill_result_value_inserted_new(result) {
    var TextBox2 = document.getElementById("ctl00_ContentPlaceHolder1_TextBox2");
    TextBox2.value = "";
    var frmvalue = document.getElementById('bind_share').innerHTML = result;
    frmvalue.scrollTop = 9999999;
    writeCalendar1();
}
function writeCalendar1() {
    var Dates = '';
    var Dates1 = '';
    var d = new Date();
    var month = d.getMonth() + 1;
    var date = d.getDate();
    var length = getLength(month);
    var day = d.getDay();
    var year = d.getFullYear();
    d.setDate(1);
    var firstDay = d.getDay();
    writeCalendar(month, date, length, day, year, firstDay);
}
function writeCalendar(month1, date1, length1, day1, year1, firstDay1) {
    var holi_val = '';
    var holi_val1 = '';
    new_month = month1;
    new_year = year1;
    new_date = date1;
    new_day = day1;
    document.getElementById('insert_calender').innerHTML = "";
    var Dates = '';
    var Dates1 = '';
    var month = month1;
    var date = date1;
    var length = length1;
    var day = day1;
    var year = year1;
    var firstDay = firstDay1;

    document.getElementById('head_month').innerHTML = months[month - 1] + ' ' + year;
    Dates1 += '<table style="border: 1px groove #C0C0C0;  width:100%;" cellpadding=0 cellspacing=0>';
    for (i = 0; i < days.length; i++) {
        Dates1 += '<th style="text-align:center; width:10%; border: 1px groove #C0C0C0;">' + days[i].substring(0, 3) + '</th>';
    }
    Dates1 += '<tr>';
    for (j = 0; j < 42; j++) {
        var displayNum = (j - firstDay + 1);


        if (j < firstDay) {
            Dates1 += '<td class="empty" style="width:10%; height:50px; text-align:center; border: 1px groove #C0C0C0;"> </td>';
        } else if (displayNum == date1) {

            Dates1 += '<td id="' + displayNum + '" class="date"  style="width:10%; height:50px; text-align:center; border: 1px groove #C0C0C0;" onclick="getvalue(this);" >' + displayNum + '</td>';
        } else if (displayNum > length) {
            Dates1 += '<td> </td>';
        } else {
            dis_value = displayNum;
            dis_value1 = Number(displayNum);
            holi_val = '';

            for (var l = 0; l < day_name.length; l++) {

                if (displayNum == day_name[l] && month1 == monthname[l] && leavename[l] == "SUNDAY") {

                    holi_val = leavename[l];
                }
                else if (displayNum == day_name[l] && month1 == monthname[l] && leavename[l] != "SUNDAY" && year == yearName[l]) {
                    holi_val = leavename[l];
                }
            }
            
           
            if (holi_val == '') {
               
                Dates1 += '<td class="days" style="width:10%; height:50px; text-align:center;border: 1px groove #C0C0C0;" name="dt" onclick="getvalue(this);" id="dt' + displayNum + '">' + displayNum + '</td>';
            }
            else {
                Dates1 += '<td class="days" style="width:10%; height:50px; text-align:center;background-color:Red;color: #FFFFFF; border: 1px groove #C0C0C0;" name="dt" onclick="getvalue(this);" id="dt' + displayNum + '">' + displayNum + ' <br/><div ;">' + holi_val + ' </div></td>';
            }
        }
        if (j % 7 == 6) {
            Dates1 += '</tr>';
        }
    }
    Dates1 += '</table>';

    var frmvalue = document.getElementById('insert_calender').innerHTML = Dates1;
}

function getLength(month) {
    switch (month) {
        case 2:
            if ((this.dateObject.getFullYear() % 4 == 0 && this.dateObject.getFullYear() % 100 != 0) || this.dateObject.getFullYear() % 400 == 0)
                return 29;
            else
                return 28;
        case 4:
            return 30;
        case 6:
            return 30;
        case 9:
            return 30;
        case 11:
            return 30
        default:
            return 31;
    }
}
function getLength1(month, year) {
    switch (month) {
        case 2:
            if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
                return 29;
            else
                return 28;
        case 4:
            return 30;
        case 6:
            return 30;
        case 9:
            return 30;
        case 11:
            return 30
        default:
            return 31;
    }
}
var d1 = new Date();
var month2 = d1.getMonth() + 1
var year2;
function next_click() {
    Calender_details.hodiday_detail('2015', getdata);
}

function previous_click() {

    var d = new Date();
    var month = d.getMonth() + 1;
    var date = d.getDate();
    var day = d.getDay();
    var year = d.getFullYear();
    d.setDate(1);
    var firstDay = d.getDay();
    d.setDate(date);

    month2 = Number(month2) - 1;
    if (year2 > year) {
        year = year2;
    }
    else if (year2 < year) {
        year = year2;
    }
    else {
        year2 = year;
    }
    var length = getLength1(month2, year2);
    var date_value1 = getFormattedDate1(month2, 1, year2);
    var d2 = new Date(date_value1);
    var date_value = d2.getDate();
    var day_value = d2.getDay();
    var year_value = d2.getFullYear();
    d2.setDate(1);
    var firstDay_value = d2.getDay();

    if (month == month2) {
        writeCalendar(month2, date, length, day_value, year_value, firstDay_value);
    }
    else {
        writeCalendar(month2, date_value, length, day_value, year_value, firstDay_value);
    }
}

function getFormattedDate(month_val, date_val, year_val) {
    if (month_val > 12) {
        month_val = 1;
        month2 = 1;
        year_val = Number(year_val) + 1;
        year2 = year_val;
    }
    return (month_val) + '/' + date_val + '/' + year_val;
}

function getFormattedDate1(month_val, date_val, year_val) {
    if (month_val < 1) {
        month_val = 12;
        month2 = 12;
        year_val = Number(year_val) - 1;
        year2 = year_val;
    }
    return month_val + '/' + date_val + '/' + year_val;
}

function getvalue(e) {
    new_date = e.innerText;
    new_date = e.textContent;
    var tp = document.getElementById('event_popup')
    tp.style.display = "block";
    tp.style.top = "50%";
    tp.style.left = "35%";
    tp.style.backgroundColor = '#2f7ed8';
}

function save_details() {
    var txt_val = document.getElementById('ctl00_ContentPlaceHolder1_TextBox1')
    var full_date = new_year + "/" + new_month + "/" + new_date;
    Calender_details.inser_hodiday_details_show(txt_val.value, full_date, full_date, get_holiday_value_inserted);
    var tp = document.getElementById('event_popup')
    tp.style.display = "none";
}

function close_popup() {
    var tp = document.getElementById('event_popup')
    tp.style.display = "none";
    var txt_val = document.getElementById('ctl00_ContentPlaceHolder1_TextBox1')
    txt_val.value = "";

}

function getdata(result) {


    var xml = parseXml(result); //pass result string into function for xml conversion.
    if (xml) {
        get_holiday_value(xml.documentElement); // call the bindgrid method and pass the root element of of xml form in the function.
    }

}

function get_holiday_value(root) {
    var day = root.getElementsByTagName("DAY");
    var month = root.getElementsByTagName("MONTH");
    var leave = root.getElementsByTagName("LeaveName");
    var y = root.getElementsByTagName("year");
    for (var x = 0; x < day.length; x++) {
        day_name[x] = GetInnerText(day[x]);
        monthname[x] = GetInnerText(month[x]);
        leavename[x] = GetInnerText(leave[x]);
        yearName[x] = GetInnerText(y[x]);
    }

    var d = new Date();
    var month = d.getMonth() + 1;
    var date = d.getDate();
    var day = d.getDay();
    var year = d.getFullYear();
    d.setDate(1);
    var firstDay = d.getDay();
    d.setDate(date);
    month2 = Number(month2) + 1;

    if (year2 > year) {
        year = year2;
    }
    else if (year2 < year) {
        year = year2;
    }
    else {
        year2 = year;
    }
    var length = getLength1(month2, year2);
    var date_value1 = getFormattedDate(month2, 1, year2);
    var d2 = new Date(date_value1);
    var date_value = d2.getDate();
    var day_value = d2.getDay();
    var year_value = d2.getFullYear();
    d2.setDate(1);
    var firstDay_value = d2.getDay();
    if (month == month2) {

        writeCalendar(month2, date, length, day_value, year_value, firstDay_value);
    }
    else {

        writeCalendar(month2, date_value, length, day_value, year_value, firstDay_value);
    }

}


function getdata1(result) {


    var xml = parseXml(result); //pass result string into function for xml conversion.
    if (xml) {
        get_holiday_valueFist(xml.documentElement); // call the bindgrid method and pass the root element of of xml form in the function.
    }

}


function get_holiday_valueFist(root) {

    var day = root.getElementsByTagName("DAY");
    var month = root.getElementsByTagName("MONTH");
    var leave = root.getElementsByTagName("LeaveName");
    for (var x = 0; x < day.length; x++) {

        day_name[x] = GetInnerText(day[x]);
        monthname[x] = GetInnerText(month[x]);
        leavename[x] = GetInnerText(leave[x]);
       

    }

    var d = new Date();
    var month = d.getMonth();
    var date = d.getDate();
    var day = d.getDay();
    var year = d.getFullYear();
    d.setDate(1);
    var firstDay = d.getDay();
    d.setDate(date);

    month2 = Number(month2);
    if (year2 > year) {
        year = year2;
    }
    else if (year2 < year) {
        year = year2;
    }
    else {
        year2 = year;
    }
    var length = getLength1(month2, year2);
    var date_value1 = getFormattedDate1(month2, 1, year2);
    var d2 = new Date(date_value1);
    var date_value = d2.getDate();
    var day_value = d2.getDay();
    var year_value = d2.getFullYear();
    d2.setDate(1);
    var firstDay_value = d2.getDay();

    if (month == month2) {
        writeCalendar(month2, date, length, day_value, year_value, firstDay_value);
    }
    else {
        writeCalendar(month2, date_value, length, day_value, year_value, firstDay_value);
    }
}



function get_holiday_value1(result) {
    if (result == "") {
        todo_list = "";
    }
    else {
        todo_list = result;
    }
}
function get_div_value(val) {

}

function get_holiday_value_inserted(result) {
    if (result == "1") {
        var length = getLength1(new_month, new_year);
        var date_value1 = getFormattedDate1(new_month, 1, new_year);
        var d2 = new Date(date_value1);
        d2.setDate(1);
        var firstDay_value = d2.getDay();
        writeCalendar1();
    }
}

function check_value(subjectid, instituteid, sessionid, empid, courseid, batchid, semid, value) {

    var mypoup = document.getElementById('event_popup1');
    mypoup.style.top = "5%";
    mypoup.style.left = "25%";
    mypoup.style.display = "block";
    Calender_details.get_Student_attendance_details_show(subjectid, instituteid, sessionid, empid, courseid, batchid, semid, value, Get_Details_popup);
}

function Get_Details_popup(result) {
    var mypoup = document.getElementById('event_popup1');
    mypoup.innerHTML = result;
}

function check_value1() {
    var mypoup = document.getElementById("event_popup1");
    mypoup.style.display = "none";
}

function check_value_exam(suject, instiid, sessionid, empid, courseid, examtype, value1) {
    var mypoup = document.getElementById('event_popup1');
    mypoup.style.top = "35%";
    mypoup.style.left = "23%";
    mypoup.style.display = "block";
    if (examtype == "Attendance" || examtype == "0") {
        Calender_details.get_Student_examination_attendance_details_show(suject, instiid, sessionid, empid, courseid, value1, Get_Details_popup1);
    }
    else {
        Calender_details.get_Student_examination_exam_details_show(suject, instiid, sessionid, empid, courseid, value1, Get_Details_popup2);
    }
}

function Get_Details_popup1(result) {

    var mypoup = document.getElementById('event_popup1');
    mypoup.innerHTML = result;
}

function Get_Details_popup2(result) {

    var mypoup = document.getElementById('event_popup1');
    mypoup.innerHTML = result;
}

function check_value_exam1() {
    var mypoup = document.getElementById("event_popup1");
    mypoup.style.display = "none";
}

function bind_value_according() {

    var ddl_share_type = document.getElementById("ctl00_ContentPlaceHolder1_ddl_share_type");
    var ddl_share_type_value1 = ddl_share_type.options[ddl_share_type.selectedIndex].value;
    var Label22 = document.getElementById("ctl00_ContentPlaceHolder1_Label22");
    var ddl_detail_type = document.getElementById("ctl00_ContentPlaceHolder1_ddl_detail_type");
    if (ddl_share_type_value1 == "1") {
        ddl_detail_type.style.display = "block";
        Label22.style.display = "block";
        Label22.innerText = "Faculty Name";
        Label22.textContext = "Faculty Name";
    }
    if (ddl_share_type_value1 == "2") {

        ddl_detail_type.style.display = "block";
        Label22.style.display = "block";
        Label22.innerText = "Student Group";
        Label22.textContext = "Student Group";
    }
    if (ddl_share_type_value1 == "0") {
        ddl_detail_type.style.display = "none";
        Label22.style.display = "none";
    }
    if (ddl_share_type_value1 != "0") {
        Calender_details.Bindgroup_value(ddl_share_type_value1, fill_group_type);
    }
}

function fill_group_type(result) {
    var xml = parseXml(result);
    if (xml) {
        bindgroup_dll(xml.documentElement);
    }
}

function bindgroup_dll(DistNode) {

    var ddl_detail_type = document.getElementById("ctl00_ContentPlaceHolder1_ddl_detail_type");
    for (var count = ddl_detail_type.options.length - 1; count > -1; count--) {
        ddl_detail_type.options[count] = null;
    }
    var val;
    var desc;
    var optionitem;
    var ddl_share_type = document.getElementById("ctl00_ContentPlaceHolder1_ddl_share_type");
    var ddl_share_type_value1 = ddl_share_type.options[ddl_share_type.selectedIndex].value;
    if (ddl_share_type_value1 == "1") {
        var IdNode = DistNode.getElementsByTagName('empId');
        var DescNode = DistNode.getElementsByTagName('empname');
    }
    else {
        var IdNode = DistNode.getElementsByTagName('Batch_ID');
        var DescNode = DistNode.getElementsByTagName('Batch_Name');
    }

    for (var count1 = 0; count1 < IdNode.length; count1++) {
        val = GetInnerText(IdNode[count1]);
        desc = GetInnerText(DescNode[count1]);
        optionitem = new Option(desc, val, false, false);
        ddl_detail_type.options[ddl_detail_type.length] = optionitem;
    }
}

function doClick(e) {
    var ddl_share_type = document.getElementById("ctl00_ContentPlaceHolder1_ddl_share_type");
    var ddl_share_type_value1 = ddl_share_type.options[ddl_share_type.selectedIndex].value;
    var ddl_detail_type = document.getElementById("ctl00_ContentPlaceHolder1_ddl_detail_type");
    var ddl_detail_type_value1 = ddl_detail_type.options[ddl_detail_type.selectedIndex].value;
    var TextBox2 = document.getElementById("ctl00_ContentPlaceHolder1_TextBox2");
    if (e.keyCode == 13) {
        if (TextBox2.value != "" && ddl_share_type_value1 != "0") {

            var frmvalue = document.getElementById('bind_share').innerHTML = "";
            Calender_details.inser_share_group_details_show(ddl_share_type_value1, ddl_detail_type_value1, TextBox2.value, fill_result_value_inserted);
        }
    }
}

function fill_result_value_inserted(result) {
    var TextBox2 = document.getElementById("ctl00_ContentPlaceHolder1_TextBox2");
    TextBox2.value = "";
    var frmvalue = document.getElementById('bind_share').innerHTML = result;
    frmvalue.scrollTop = frmvalue.scrollHeight;
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
function close_popup() {
    var mypoup = document.getElementById('event_popup2');
    mypoup.style.display = "none";
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


function subtopic_Function() {

}

