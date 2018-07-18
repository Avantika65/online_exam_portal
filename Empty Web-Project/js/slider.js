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


function firetgt(uri) {
    debugger;
    close_panel();
    document.getElementById("iftarget").src = uri.replace('../', '');
}


function open_panel() {
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

        writeCalendar(month, date, length, day_value, year_value, firstDay_value);
    }
    else {

        writeCalendar(month, date_value, length, day_value, year_value, firstDay_value);
    }
slideIt();
var a = document.getElementById("SliderPanel");

a.setAttribute("id","SliderPanel1");
a.setAttribute("onclick","close_panel()");
}

function slideIt()
{
	var slidingDiv = document.getElementById("slider");
	var stopPosition = -200;
	
	if (parseInt(slidingDiv.style.right) < stopPosition )
	{
		slidingDiv.style.right = parseInt(slidingDiv.style.right) + 2 + "px";
		setTimeout(slideIt, 1);	
	}
}
	
function close_panel(){
slideIn();
a=document.getElementById("SliderPanel1");
a.setAttribute("id","SliderPanel");
a.setAttribute("onclick","open_panel()");
}

function slideIn()
{
	var slidingDiv = document.getElementById("slider");
	var stopPosition = -500;
	
	if (parseInt(slidingDiv.style.right) > stopPosition )
	{
		slidingDiv.style.right = parseInt(slidingDiv.style.right) - 2 + "px";
		setTimeout(slideIn, 1);	
	}
}

function writeCalendar(month1, date1, length1, day1, year1, firstDay1) {
    var holi_val = '';
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


                }

                else if (displayNum == day_name[l] && month1 == monthname[l] && leavename[l] != "SUNDAY" && year == yearName[l]) {

                    holi_val = leavename[l];
                }
            }
            if (holi_val == '')
                Dates1 += '<td class="days" style="width:10%; height:50px; text-align:center;border: 1px groove #C0C0C0;" name="dt" onclick="getvalue(this);" id="dt' + displayNum + '">' + displayNum + '</td>';
            else
                Dates1 += '<td class="days" style="width:10%; height:50px; text-align:center;background-color:Red;color: #FFFFFF; border: 1px groove #C0C0C0;" name="dt" onclick="getvalue(this);" id="dt' + displayNum + '">' + displayNum + ' <br/><div ;">' + holi_val + ' </div></td>';

        }
        if (j % 7 == 6) {
            Dates1 += '</tr>';
        }
    }
    Dates1 += '</table>';

    var frmvalue = document.getElementById('insert_calender').innerHTML = Dates1;


}