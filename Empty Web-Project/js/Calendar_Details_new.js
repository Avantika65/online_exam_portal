var days = new Array('Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday');
var months = new Array('January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December');

var new_month;
var new_year;
var new_date;
var new_day;
var new_firstDay;
var dis_value;
var dis_value1;
var holiday_valu = "";
var todo_list = "";

window.onload = writeCalendar1;
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
    Dates1 += '<table style="border: 1px groove #C0C0C0;" cellpadding=0 cellspacing=0>';
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

            Calender_details.hodiday_details_show(month1, Number(displayNum) + 1, year1, get_holiday_value);
            if (holiday_valu == "" && todo_list == "") {
                Dates1 += '<td class="days" style="width:10%; height:50px; text-align:center; border: 1px groove #C0C0C0;" name="dt" onclick="getvalue(this);" id="dt' + displayNum + '">' + displayNum + '</td>';
            }
            else if (holiday_valu.toUpperCase() == "SUNDAY" && todo_list == "") {
                Dates1 += '<td class="days" style="width:10%; height:50px; text-align:center; background-color:Red; border: 1px groove #C0C0C0;" name="dt" onclick="getvalue(this);" id="dt' + displayNum + '">' + displayNum + ' </td>';
            }

            else if (holiday_valu.toUpperCase() != "SUNDAY" && todo_list == "" && holiday_valu.toUpperCase() != "") {
                Dates1 += '<td class="days" style="width:10%; height:50px; text-align:center; border: 1px groove #C0C0C0;" name="dt" onclick="getvalue(this);" id="dt' + displayNum + '">' + displayNum + ' <br/><div style="background-color:Red;">' + holiday_valu + '</div></td>';
            }

            else if (holiday_valu.toUpperCase() == "" && todo_list != "") {
                Dates1 += '<td class="days" style="width:10%; height:50px; text-align:center; border: 1px groove #C0C0C0;" name="dt" onclick="getvalue(this);" id="dt' + displayNum + '">' + displayNum + ' <br/><div style="background-color:Red;">' + todo_list + '</div></td>';
            }

            else if (holiday_valu.toUpperCase() == "SUNDAY" && todo_list != "") {
                Dates1 += '<td class="days" style="width:10%;; height:50px; text-align:center; border: 1px groove #C0C0C0;" name="dt" onclick="getvalue(this);" id="dt' + displayNum + '">' + displayNum + ' <br/><div style="background-color:Red;">' + todo_list + '</div></td>';
            }
            else if (holiday_valu.toUpperCase() != "SUNDAY" && todo_list != "") {
                Dates1 += '<td class="days" style="width:10%; height:50px; text-align:center; border: 1px groove #C0C0C0;" name="dt" onclick="getvalue(this);" id="dt' + displayNum + '">' + displayNum + ' <br/><div style="background-color:Red;">' + todo_list + '<br/>' + holiday_valu + ' </div></td>';
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

function get_holiday_value(result) {
    if (result == "") {
        holiday_valu = "";
    }
    else {
        holiday_valu = result;
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

function check_value(subjectid, instituteid, sessionid, empid, courseid, batchid, semid) {
    var mypoup = document.getElementById('event_popup1');
    mypoup.style.top = "5%";
    mypoup.style.left = "25%";
    mypoup.style.display = "block";
    Calender_details.get_Student_attendance_details_show(subjectid, instituteid, sessionid, empid, courseid, batchid, semid, Get_Details_popup);
}

function Get_Details_popup(result) {
    var mypoup = document.getElementById('event_popup1');
    mypoup.innerHTML = result;
}

function check_value1() {
    var mypoup = document.getElementById("event_popup1");
    mypoup.style.display = "none";
}

function check_value_exam(suject, instiid, sessionid, empid, courseid, examtype) {
    var mypoup = document.getElementById('event_popup1');
    mypoup.style.top = "40%";
    mypoup.style.left = "25%";
    mypoup.style.display = "block";
    if (examtype == "Attendance" || examtype == "0") {
        Calender_details.get_Student_examination_attendance_details_show(suject, instiid, sessionid, empid, courseid, Get_Details_popup1);
    }
    else {
        Calender_details.get_Student_examination_exam_details_show(suject, instiid, sessionid, empid, courseid, Get_Details_popup2);
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

function Subject_Function() {
    var ddlsubject = document.getElementById("ddlsubject");
    var ddlsubject_value1 = ddlsubject.options[ddlsubject.selectedIndex].value;
    Calender_details.BindTopic_value(ddlsubject_value1, Fill_topic);
}

function Fill_topic(result) {
    var xml = parseXml(result);
    if (xml) {
        bindtopic_dll(xml.documentElement);
    }
}

function bindtopic_dll(DistNode) {

    var ddltopic1 = document.getElementById("ddltopic");
    for (var count = ddltopic1.options.length - 1; count > -1; count--) {
        ddltopic1.options[count] = null;
    }

    var val;
    var desc;
    var optionitem;
    var IdNode = DistNode.getElementsByTagName('TopicId');
    var DescNode = DistNode.getElementsByTagName('TopicName');

    for (var count1 = 0; count1 < IdNode.length; count1++) {
        val = GetInnerText(IdNode[count1]);
        desc = GetInnerText(DescNode[count1]);
        optionitem = new Option(desc, val, false, false);
        ddltopic1.options[ddltopic1.length] = optionitem;
    }
}


function Topic_Function() {
    var ddlsubject = document.getElementById("ddlsubject");
    var ddlsubject_value1 = ddlsubject.options[ddlsubject.selectedIndex].value;
    var ddltopic1 = document.getElementById("ddltopic");
    var ddltopic1_value1 = ddltopic1.options[ddltopic1.selectedIndex].value;
    Calender_details.BindSubTopic_value(ddlsubject_value1, ddltopic1_value1, Sub_Fill_topic);
}

function Sub_Fill_topic(result) {
    var xml = parseXml(result);
    if (xml) {
        bindsubtopic_dll(xml.documentElement);
    }
}

function bindsubtopic_dll(DistNode1) {
    var ddlsubtopic1 = document.getElementById("ddlsubtopic");
    for (var count = ddlsubtopic1.options.length - 1; count > -1; count--) {
        ddlsubtopic1.options[count] = null;
    }
   
    var val;
    var desc; 
    var optionitem;
    var IdNode = DistNode1.getElementsByTagName('SubTopicID');
    var DescNode = DistNode1.getElementsByTagName('SubTopicName');

    for (var count1 = 0; count1 < IdNode.length; count1++) {
        val = GetInnerText(IdNode[count1]);
        desc = GetInnerText(DescNode[count1]);
       
        optionitem = new Option(desc, val, false, false);
        ddlsubtopic1.options[ddlsubtopic1.length] = optionitem;
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




function subtopic_Function() {

}
