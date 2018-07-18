

function Fill_Panel_Grid_Temp() {
    var ddlProfile = document.getElementById("ddlProfile");
    var ddlProfile1 = ddlProfile.options[ddlProfile.selectedIndex].value;
    var ddlMem = document.getElementById("ddlMem");
    var ddlMem1 = ddlMem.options[ddlMem.selectedIndex].value;
    if (ddlProfile1 != "0" && ddlMem1 != "0") {
        Calender_details.InsertPanelMember_Temp(ddlProfile1, ddlMem1, Fill_Vacancy);
    }
}

function Fill_Vacancy(result1) {
    var ddlProfile = document.getElementById("ddlProfile");
    var ddlProfile1 = ddlProfile.options[ddlProfile.selectedIndex].value;
    Calender_details.GetPanel_Member(ddlProfile1, Fill_Panel);
}
function Fill_Panel(result) {
    var xml = parseXml(result); //pass result string into function for xml conversion.
    if (xml) {
        bindgrid2(xml.documentElement); // call the bindgrid method and pass the root element of of xml form in the function.
    }
}
function bindgrid2(root) {
    var element = document.getElementById("xGrid2");
    var trt = element.getElementsByTagName("TR");
    var lnt = trt.length;
    for (var i = 0; i < trt.length; i++) {
        element.deleteRow(i);
        lnt--;
        i--;
    }
    var Add_vacancy = root.getElementsByTagName("temp_panel_member_view");
    var Job_Code = root.getElementsByTagName("title");
    var Job_Profile = root.getElementsByTagName("empName");
    var tbt = document.createElement("TBODY");
    element.appendChild(tbt);

    if (Add_vacancy.length != 0) {
        var headerRow = document.createElement("TR");

        var th1 = document.createElement("TH");
        th1.appendChild(document.createTextNode("Job Profile"));
        th1.style.height = "30px";
        th1.style.fontSize = "11px";
        th1.style.textAlign = "center";
        th1.style.width = "10%";

        var th2 = document.createElement("TH");
        th2.appendChild(document.createTextNode("Panel Member Name"));
        th2.style.height = "30px";
        th2.style.fontSize = "11px";
        th2.style.textAlign = "center";
        th2.style.width = "20%";

        headerRow.appendChild(th1);
        headerRow.appendChild(th2);
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
    if (Add_vacancy.length > 0) {
        for (var x = 0; x < Add_vacancy.length; x++) {
            var row = document.createElement("TR");
            var rid = "rc" + x;
            row.setAttribute('id', rid);



            var Job_Code1 = GetInnerText(Job_Code[x]);
            var Job_Profile1 = GetInnerText(Job_Profile[x]);
            


            var td1 = document.createElement("TD");
            td1.appendChild(document.createTextNode(Job_Code1));
            td1.style.width = "10%";
            td1.style.textAlign = "left";
            td1.style.fontSize = "11px";
            td1.style.paddingLeft = "5px";

            var td2 = document.createElement("TD");
            td2.appendChild(document.createTextNode(Job_Profile1));
            td2.style.width = "20%";
            td2.style.textAlign = "left";
            td2.style.fontSize = "11px";
            td2.style.paddingLeft = "5px";

           
            row.appendChild(td1);
            row.appendChild(td2);
            tbt.appendChild(row);
        }
    }
}


function View_All_Onchange() {
    var chk = document.getElementById("Checkbox2");
    if (chk.checked == true) {
        Calender_details.Bind_Panel_Details(View_All_Panel_Detail);
        return false;
    }
    else {
        var element14 = document.getElementById("xGrid1");
        var trt = element14.getElementsByTagName("TR");
        var lnt = trt.length;
        for (var i = 0; i < trt.length; i++) {
            element.deleteRow(i);
            lnt--;
            i--;
        }
    }
}

function View_All_Panel_Detail(result) {
   
    var xml = parseXml(result); //pass result string into function for xml conversion.
    if (xml) {
        bindgrid1(xml.documentElement); // call the bindgrid method and pass the root element of of xml form in the function.
    }
}
function bindgrid1(root) {
    
    var element3 = document.getElementById("xGrid1");
    var trt = element3.getElementsByTagName("TR");
    var lnt = trt.length;
    for (var i = 0; i < trt.length; i++) {
        element3.deleteRow(i);
        lnt--;
        i--;
    }
    var Div1 = document.getElementById("Div1");
    Div1.style.display = "block";
    var Hr_Panel_member = root.getElementsByTagName("Hr_Panel_member_view");
    var jobtitle = root.getElementsByTagName("title");
    var empName = root.getElementsByTagName("empName");
    var Designation = root.getElementsByTagName("Designation");
    var tbt = document.createElement("TBODY");
    element3.appendChild(tbt);
    
    if (Hr_Panel_member.length != 0) {
        var headerRow = document.createElement("TR");
        var th1 = document.createElement("TH");
        th1.appendChild(document.createTextNode("Job Title"));
        th1.style.height = "30px";
        th1.style.fontSize = "11px";
        th1.style.textAlign = "center";
        th1.style.width = "30%";

        var th2 = document.createElement("TH");
        th2.appendChild(document.createTextNode("Employee Name"));
        th2.style.height = "30px";
        th2.style.fontSize = "11px";
        th2.style.textAlign = "center";
        th2.style.width = "30%";

        var th3 = document.createElement("TH");
        th3.appendChild(document.createTextNode("Designation"));
        th3.style.height = "30px";
        th3.style.fontSize = "11px";
        th3.style.textAlign = "center";
        th3.style.width = "30%";


        headerRow.appendChild(th1);
        headerRow.appendChild(th2);
        headerRow.appendChild(th3);


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
    if (Hr_Panel_member.length > 0) {

       
        for (var x = 0; x < Hr_Panel_member.length; x++) {
            var row = document.createElement("TR");
            var rid = "rc" + x;
            row.setAttribute('id', rid);

            var jobTitle1 = GetInnerText(jobtitle[x]);
            var empName1 = GetInnerText(empName[x]);
            var Designation1 = GetInnerText(Designation[x]);
           

            var td1 = document.createElement("TD");
            td1.appendChild(document.createTextNode(jobTitle1));
            td1.style.width = "30%";
            td1.style.textAlign = "left";
            td1.style.fontSize = "11px";
            td1.style.paddingLeft = "5px";

            var td2 = document.createElement("TD");
            td2.appendChild(document.createTextNode(empName1));
            td2.style.width = "30%";
            td2.style.textAlign = "left";
            td2.style.fontSize = "11px";
            td2.style.paddingLeft = "5px";

            var td3 = document.createElement("TD");
            td3.appendChild(document.createTextNode(Designation1));
            td3.style.width = "30%";
            td3.style.textAlign = "left";
            td3.style.fontSize = "11px";
            td3.style.paddingLeft = "5px";

            row.appendChild(td1);
            row.appendChild(td2);
            row.appendChild(td3);
            tbt.appendChild(row);
        }
    }
}


function reset_value1() {
    var ddlProfile = document.getElementById("ddlProfile");
    ddlProfile.options[0].selected = true;
    var ddlMem = document.getElementById("ddlMem");
    ddlMem.options[0].selected = true;
}

function Add_Value() {
    
    var ddlProfile = document.getElementById("ddlProfile");
    var SelValueProfile = ddlProfile.options[ddlProfile.selectedIndex].value;
    if (SelValueProfile == "0") {
        window.alert("Please select Job Profile....");
        ddlProfile.focus();
        return false;
    }
   
    var ddlMem = document.getElementById("ddlMem");
    var SelValueMem = ddlMem.options[ddlMem.selectedIndex].value;
    if (SelValueMem == "0") {
        window.alert("Please select Members....");
        ddlMem.focus();
        return false;
    }
   
    Calender_details.Add_Value_Member(Add_Member);
}

function Add_Member(result) {
 
    if (result > 0) {
        reset_value1();
        var element1 = document.getElementById("xGrid2");
        element1.style.display = "none";

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
