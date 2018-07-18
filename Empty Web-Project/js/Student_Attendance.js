//FillDropDown.....
function Fill_DropDown() {
   
    var ddlDept = document.getElementById("ddlSession");
    var ddlDept1 = ddlDept.options[ddlDept.selectedIndex].value;
    Calender_details.Bind_Semester(ddlDept1, Fill_Designation_details);
}
function Fill_Designation_details(result) {
   
    var xml = parseXml(result);
    if (xml) {
        bind_Designation_dll(xml.documentElement);
    }
}

function bind_Designation_dll(DistNode) {
   
    var ddlDesig = document.getElementById("DdlSem");
    for (var count = ddlDesig.options.length - 1; count > -1; count--) {
        ddlDesig.options[count] = null;
    }
    var val;
    var desc;
    var optionitem;
    val = "0";
    desc = "----Select----"; ;
    optionitem = new Option(desc, val, false, false);
    ddlDesig.options[ddlDesig.length] = optionitem;
    var IdNode = DistNode.getElementsByTagName('SID');
    var DescNode = DistNode.getElementsByTagName('CourseYear');

    for (var count1 = 0; count1 < IdNode.length; count1++) {
        val = GetInnerText(IdNode[count1]);
        desc = GetInnerText(DescNode[count1]);
        optionitem = new Option(desc, val, false, false);
        ddlDesig.options[ddlDesig.length] = optionitem;
    }
    ddlDesig.options[0].selected = true;
}

function Fill_Grid() {
   
    var grid = document.getElementById("dicsub");
    var div = document.getElementById("Div1");

    grid.style.display = "none";
    var ddlSession = document.getElementById("ddlSession");
    var Sessionid = ddlSession.options[ddlSession.selectedIndex].value;
    var ddlSem = document.getElementById("DdlSem");
    var Semid = ddlSem.options[ddlSem.selectedIndex].value;
    Calender_details.Bind_SemesterGrid(Sessionid, Semid, Get_Details_popup);
}


function Get_Details_popup(result) {

    if (result == "") {
        
        var mypoup = document.getElementById('event_popup1');
        var trt = mypoup.getElementsByTagName("TR");
        var lnt = trt.length;
     
        for (var i = 0; i < trt.length; i++) {
            mypoup.removeChild(mypoup.childNodes[i]);
            lnt--;
            
        }
        mypoup.style.display = "block";
        var tbt = document.createElement("TBODY");
        mypoup.appendChild(tbt);
        var blankRow = document.createElement("TR");
        var blanktd = document.createElement("TD");
        blanktd.style.verticalAlign = "middle";
        
        blanktd.style.textAlign = "center";
        blanktd.style.width = "10%";
        var img = document.createElement("img");
        img.src = "../images/no_data.png";
        blanktd.appendChild(img);
        blankRow.appendChild(blanktd);
        tbt.appendChild(blankRow);
    }
    else {


       
        var mypoup = document.getElementById('event_popup1');
       
        mypoup.style.display = "block";
        mypoup.innerHTML = result;
    }
}
function Fill_Vacancy(result) {
   
    var xml = parseXml(result); //pass result string into function for xml conversion.
    if (xml) {
        bindgrid1(xml.documentElement); // call the bindgrid method and pass the root element of of xml form in the function.
    }
}



function bindgrid1(root) {
    
    var element = document.getElementById("xGrid1");
    var trt = element.getElementsByTagName("TR");
    var lnt = trt.length;
    for (var i = 0; i < trt.length; i++) {
        element.deleteRow(i);
        lnt--;
        i--;
    }
    var value = root.getElementsByTagName("student_attendance_view");

    var subjectName = root.getElementsByTagName("subjectname");

   
    var tbt = document.createElement("TBODY");
    element.appendChild(tbt);

    if (value.length != 0) {

        var headerRow = document.createElement("TR");

        var th1 = document.createElement("TH");
        th1.appendChild(document.createTextNode("Subject Name"));
        th1.style.height = "30px";
        th1.style.fontSize = "11px";
        th1.style.color = "#990000";

        th1.style.textAlign = "center";
        th1.style.width = "10%";

        var th2 = document.createElement("TH");
        th2.appendChild(document.createTextNode("Total Lecture"));
        th2.style.height = "30px";
        th2.style.fontSize = "11px";
        th2.style.color = "#990000";
        th2.style.textAlign = "center";
        th2.style.width = "10%";

        var th3 = document.createElement("TH");
        th3.appendChild(document.createTextNode("Lecture Attend"));
        th3.style.height = "30px";
        th3.style.fontSize = "11px";
        th3.style.color = "#990000";
        th3.style.textAlign = "center";
        th3.style.width = "10%";

        var th4 = document.createElement("TH");
        th4.appendChild(document.createTextNode("Class Average"));
        th4.style.height = "30px";
        th4.style.fontSize = "11px";
        th4.style.color = "#990000";
        th4.style.textAlign = "center";
        th4.style.width = "10%";

        var th5 = document.createElement("TH");
        th5.appendChild(document.createTextNode("Class Position"));
        th5.style.height = "30px";
        th5.style.fontSize = "11px";
        th5.style.color = "#990000";
        th5.style.textAlign = "center";
        th5.style.width = "10%";

        headerRow.appendChild(th1);
        headerRow.appendChild(th2);
        headerRow.appendChild(th3);
        headerRow.appendChild(th4);
        headerRow.appendChild(th5);


        tbt.appendChild(headerRow);
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
    if (value.length > 0) {
        for (var x = 0; x < value.length; x++) {
            var row = document.createElement("TR");
            var rid = "rc" + x;
            row.setAttribute('id', rid);

            var Subjectname1 = GetInnerText(subjectName[x]);
            var Job_Profile1 = "35";
            var lec_Att = "20";
            var class_av = "40";
            var class_pos = "30"

            var td1 = document.createElement("TD");
            td1.appendChild(document.createTextNode(Subjectname1));
            td1.style.width = "10%";
            td1.style.textAlign = "left";
            td1.style.fontSize = "11px";
            td1.style.paddingLeft = "5px";

            var td2 = document.createElement("TD");
            td2.appendChild(document.createTextNode(Job_Profile1));
            td2.style.width = "10%";
            td2.style.textAlign = "left";
            td2.style.fontSize = "11px";
            td2.style.paddingLeft = "5px";

            var td3 = document.createElement("TD");
            td3.appendChild(document.createTextNode(lec_Att));
            td3.style.width = "10%";
            td3.style.textAlign = "left";
            td3.style.fontSize = "11px";
            td3.style.paddingLeft = "5px";

            var td4 = document.createElement("TD");
            td4.appendChild(document.createTextNode(class_av));
            td4.style.width = "10%";
            td4.style.textAlign = "left";
            td4.style.fontSize = "11px";
            td4.style.paddingRight = "5px";

            var td5 = document.createElement("TD");
            td5.appendChild(document.createTextNode(class_pos));
            td5.style.width = "10%";
            td5.style.textAlign = "left";
            td5.style.fontSize = "11px";
            td5.style.paddingRight = "5px";


            row.appendChild(td1);
            row.appendChild(td2);
            row.appendChild(td3);
            row.appendChild(td4);
            row.appendChild(td5);

            tbt.appendChild(row);
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