


function Fill_Designation() {
    var ddlDept = document.getElementById("ddlDept");
    var ddlDept1 = ddlDept.options[ddlDept.selectedIndex].value;
    Calender_details.Bind_Designation_value(ddlDept1, Fill_Designation_details);
}

function Fill_Designation_details(result) {
    var xml = parseXml(result);
    if (xml) {
        bind_Designation_dll(xml.documentElement);
    }
}
function bind_Designation_dll(DistNode) {
    var ddlDesig = document.getElementById("ddlDesig");
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




function Bind_Filter_Candidate_Grid() {
 
    var ddlProfile = document.getElementById("ddlProfile");

    var ddlProfile1 = ddlProfile.options[ddlProfile.selectedIndex].value;
   
    Calender_details.Bind_FilterCandidate_Grid(ddlProfile1, Fill_Designation_details);
}
function Fill_Designation_details(result) {
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
    var Emp_WalkIn3 = root.getElementsByTagName("EmpFilterView");
    var title = root.getElementsByTagName("title");
    var Firstname = root.getElementsByTagName("Firstname");
    var lastname = root.getElementsByTagName("lastname");
    var fatherName = root.getElementsByTagName("fatherName");
    var DOB = root.getElementsByTagName("DOB");
    var WorkInYear = root.getElementsByTagName("WorkInYear");
    var Email = root.getElementsByTagName("Email");
    var Address = root.getElementsByTagName("Address");
    var Mobileno = root.getElementsByTagName("Mobileno");
    var tbt = document.createElement("TBODY");
    element.appendChild(tbt);

    if (Emp_WalkIn3.length != 0) {

        var headerRow = document.createElement("TR");
        var th1 = document.createElement("TH");
        th1.appendChild(document.createTextNode("Job Title"));
        th1.style.height = "30px";
        th1.style.fontSize = "11px";
        th1.style.textAlign = "center";
        th1.style.width = "10%";

        var th2 = document.createElement("TH");
        th2.appendChild(document.createTextNode("First Name"));
        th2.style.height = "30px";
        th2.style.fontSize = "11px";
        th2.style.textAlign = "center";
        th2.style.width = "20%";

        var th3 = document.createElement("TH");
        th3.appendChild(document.createTextNode("Last Name"));
        th3.style.height = "30px";
        th3.style.fontSize = "11px";
        th3.style.textAlign = "center";
        th3.style.width = "10%";

        var th4 = document.createElement("TH");
        th4.appendChild(document.createTextNode("Father's Name"));
        th4.style.height = "30px";
        th4.style.fontSize = "11px";
        th4.style.textAlign = "center";
        th4.style.width = "10%";

        var th5 = document.createElement("TH");
        th5.appendChild(document.createTextNode("Date Of Birth"));
        th5.style.height = "30px";
        th5.style.fontSize = "11px";
        th5.style.textAlign = "center";
        th5.style.width = "10%";

        var th6 = document.createElement("TH");
        th6.appendChild(document.createTextNode("Working Experience(in years)"));
        th6.style.height = "30px";
        th6.style.fontSize = "11px";
        th6.style.textAlign = "center";
        th6.style.width = "20%";

        var th7 = document.createElement("TH");
        th7.appendChild(document.createTextNode("Email Address"));
        th7.style.height = "30px";
        th7.style.fontSize = "11px";
        th7.style.textAlign = "center";
        th7.style.width = "10%";

        var th8 = document.createElement("TH");
        th8.appendChild(document.createTextNode("Permanent Address"));
        th8.style.height = "30px";
        th8.style.fontSize = "11px";
        th8.style.textAlign = "center";
        th8.style.width = "10%";

        var th9 = document.createElement("TH");
        th9.appendChild(document.createTextNode("Mobile Number"));
        th9.style.height = "30px";
        th9.style.fontSize = "11px";
        th9.style.textAlign = "center";
        th9.style.width = "10%";

        headerRow.appendChild(th1);
        headerRow.appendChild(th2);
        headerRow.appendChild(th3);
        headerRow.appendChild(th4);
        headerRow.appendChild(th5);
        headerRow.appendChild(th6);
        headerRow.appendChild(th7);
        headerRow.appendChild(th8);
        headerRow.appendChild(th9);

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
    if (Emp_WalkIn3.length > 0) {

        for (var x = 0; x < Emp_WalkIn3.length; x++) {
            var row = document.createElement("TR");
            var rid = "rc" + x;
            row.setAttribute('id', rid);

            var title1 = GetInnerText(title[x]);
            var Firstname1 = GetInnerText(Firstname[x]);
            var lastname1 = GetInnerText(lastname[x]);
            var fatherName1 = GetInnerText(fatherName[x]);
            var DOB1 = GetInnerText(DOB[x]);
            var WorkInYear1 = GetInnerText(WorkInYear[x]);
            var Email1 = GetInnerText(Email[x]);
            var Address1 = GetInnerText(Address[x]);
            var Mobileno1 = GetInnerText(Mobileno[x]);

            var td1 = document.createElement("TD");
            td1.appendChild(document.createTextNode(title1));
            td1.style.width = "10%";
            td1.style.textAlign = "left";
            td1.style.fontSize = "11px";
            td1.style.paddingLeft = "5px";

            var td2 = document.createElement("TD");
            td2.appendChild(document.createTextNode(Firstname1));
            td2.style.width = "20%";
            td2.style.textAlign = "left";
            td2.style.fontSize = "11px";
            td2.style.paddingLeft = "5px";

            var td3 = document.createElement("TD");
            td3.appendChild(document.createTextNode(lastname1));
            td3.style.width = "10%";
            td3.style.textAlign = "left";
            td3.style.fontSize = "11px";
            td3.style.paddingLeft = "5px";


            var td4 = document.createElement("TD");
            td4.appendChild(document.createTextNode(fatherName1));
            td4.style.width = "10%";
            td4.style.textAlign = "left";
            td4.style.fontSize = "11px";
            td4.style.paddingRight = "5px";

            var td5 = document.createElement("TD");
            td5.appendChild(document.createTextNode(DOB1));
            td5.style.width = "10%";
            td5.style.textAlign = "left";
            td5.style.fontSize = "11px";
            td5.style.paddingRight = "5px";

            var td6 = document.createElement("TD");
            td6.appendChild(document.createTextNode(WorkInYear1));
            td6.style.width = "10%";
            td6.style.textAlign = "left";
            td6.style.fontSize = "11px";
            td6.style.paddingRight = "5px";

            var td7 = document.createElement("TD");
            td7.appendChild(document.createTextNode(Email1));
            td7.style.width = "10%";
            td7.style.textAlign = "left";
            td7.style.fontSize = "11px";
            td7.style.paddingRight = "5px";

            var td8 = document.createElement("TD");
            td8.appendChild(document.createTextNode(Address1));
            td8.style.width = "10%";
            td8.style.textAlign = "left";
            td8.style.fontSize = "11px";
            td8.style.paddingRight = "5px";

            var td9 = document.createElement("TD");
            td9.appendChild(document.createTextNode(Mobileno1));
            td9.style.width = "10%";
            td9.style.textAlign = "left";
            td9.style.fontSize = "11px";
            td9.style.paddingRight = "5px";

            row.appendChild(td1);
            row.appendChild(td2);
            row.appendChild(td3);
            row.appendChild(td4);
            row.appendChild(td5);
            row.appendChild(td6);
            row.appendChild(td7);
            row.appendChild(td8);
            row.appendChild(td9);

            tbt.appendChild(row);
        }
    }
}






function Fill_Designation() {
    
    var ddlDept = document.getElementById("ddlDept");
    var ddlDept1 = ddlDept.options[ddlDept.selectedIndex].value;
    Calender_details.Bind_Designation_value(ddlDept1, Fill_Designation_details);
}

function Fill_Designation_details(result) {
    var xml = parseXml(result);
    if (xml) {
        bind_Designation_dll(xml.documentElement);
    }
}
function bind_Designation_dll(DistNode) {
    var ddlDesig = document.getElementById("ddlDesig");

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
