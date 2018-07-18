function reset_value1() {
    var ddlDept = document.getElementById("ddlDept");
    ddlDept.options[0].selected = true;
    var txtJCode = document.getElementById("txtJCode");
    txtJCode.value = "";
    var ddlTitle = document.getElementById("ddlTitle");
    ddlTitle.options[0].selected = true;
    var txtIntrvR = document.getElementById("txtIntrvR");
    txtIntrvR.value = "";
    var txtMPoint = document.getElementById("txtMPoint");
    txtMPoint.value = "";
}


function Sbmt_value() {
   
    var txtIntrvR = document.getElementById("txtIntrvR");
    if (txtIntrvR.value == "") {
        window.alert("Enter Interview Round");
        txtIntrvR.focus();
        return false;
    }
    var txtMPoint = document.getElementById("txtMPoint");
    if (txtMPoint.value == "") {
        window.alert("Enter Maximum Poin");
        txtMPoint.focus();
        return false;
    }
    var ddlDept = document.getElementById("ddlDept");
    var ddlDept1 = ddlDept.options[ddlDept.selectedIndex].value;
    if (ddlDept1 == "0") {
        window.alert("Select Department");
        ddlDept.focus();
        return false;
    }
    
    var ddlTitle = document.getElementById("ddlTitle");
    var ddlTitle1 = ddlTitle.options[ddlTitle.selectedIndex].value;
    if (ddlTitle1 == "0") {
        window.alert("Select Job tittle");
        ddlTitle.focus();
        return false;
    }
    
    Calender_details.insert_intrview_round(txtIntrvR.value, txtMPoint.value, ddlDept1,ddlTitle1,interv_round);
}
function interv_round() {
    reset_value1();
    window.alert("Saved Succesfully");
}


function View_All_Onchange() {
   
    var chk = document.getElementById("chkAll");
    if (chk.checked == true) {
        Calender_details.Bind_InterView_Details(View_All_Vanancy_Detail);
    }
    else {
        var element = document.getElementById("xGrid2");
        var trt = element.getElementsByTagName("TR");
        var lnt = trt.length;
        for (var i = 0; i < trt.length; i++) {
            element.deleteRow(i);
            lnt--;
            i--;
        }
    }

}
function View_All_Vanancy_Detail(result) {
    
    var xml = parseXml(result); //pass result string into function for xml conversion.
    if (xml) {
        bindgrid1(xml.documentElement); // call the bindgrid method and pass the root element of of xml form in the function.
    }
}
function bindgrid1(root) {
   
    var element = document.getElementById("xGrid2");
    var trt = element.getElementsByTagName("TR");
    var lnt = trt.length;
 
    for (var i = 0; i < trt.length; i++) {
        element.deleteRow(i);
        lnt--;
        i--;
    }
    var Add_vacancy = root.getElementsByTagName("View_interView");
    var jobId = root.getElementsByTagName("jobId");
    var jobCode = root.getElementsByTagName("jobCode");
    var jobTitle = root.getElementsByTagName("jobTitle");
    var DepartmentName = root.getElementsByTagName("DepartmentName");
    var interv_R = root.getElementsByTagName("interv_R");
    var maxPoint = root.getElementsByTagName("maxPoint");
    var tbt = document.createElement("TBODY");
    element.appendChild(tbt);

    if (Add_vacancy.length != 0) {
       
        var headerRow = document.createElement("TR");

        var th1 = document.createElement("TH");
        th1.appendChild(document.createTextNode("Job Id "));
        th1.style.height = "30px";
        th1.style.fontSize = "11px";
        th1.style.textAlign = "center";
        th1.style.width = "10%";

        var th2 = document.createElement("TH");
        th2.appendChild(document.createTextNode("Job Code "));
        th2.style.height = "25px";
        th2.style.fontSize = "11px";
        th2.style.textAlign = "center";
        th2.style.width = "20%";

        var th3 = document.createElement("TH");
        th3.appendChild(document.createTextNode("Job Title"));
        th3.style.height = "30px";
        th3.style.fontSize = "11px";
        th3.style.textAlign = "center";
        th3.style.width = "10%";

        var th4 = document.createElement("TH");
        th4.appendChild(document.createTextNode("Department"));
        th4.style.height = "30px";
        th4.style.fontSize = "11px";
        th4.style.textAlign = "center";
        th4.style.width = "10%";

        var th5 = document.createElement("TH");
        th5.appendChild(document.createTextNode("Interview Round"));
        th5.style.height = "30px";
        th5.style.fontSize = "11px";
        th5.style.textAlign = "center";
        th5.style.width = "10%";

        var th6 = document.createElement("TH");
        th6.appendChild(document.createTextNode("Max Point"));
        th6.style.height = "30px";
        th6.style.fontSize = "11px";
        th6.style.textAlign = "center";
        th6.style.width = "10%";

        var th7 = document.createElement("TH");
        th7.appendChild(document.createTextNode("Delete"));
        th7.style.height = "30px";
        th7.style.fontSize = "11px";
        th7.style.textAlign = "center";
        th7.style.width = "10%";

        headerRow.appendChild(th1);
        headerRow.appendChild(th2);
        headerRow.appendChild(th3);
        headerRow.appendChild(th4);
        headerRow.appendChild(th5);
        headerRow.appendChild(th6);
        headerRow.appendChild(th7);
       
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

            var jobId1 = GetInnerText(jobId[x]);
            var jobCode1 = GetInnerText(jobCode[x]);
            var jobTitle1 = GetInnerText(jobTitle[x]);
            var DepartmentName1 = GetInnerText(DepartmentName[x]);
            var interv_R1 = GetInnerText(interv_R[x]);
            var maxPoint1 = GetInnerText(maxPoint[x]);
           

            var td1 = document.createElement("TD");
            td1.appendChild(document.createTextNode(jobId1));
            td1.style.width = "10%";
            td1.style.textAlign = "left";
            td1.style.fontSize = "11px";
            td1.style.paddingLeft = "5px";

            var td2 = document.createElement("TD");
            td2.appendChild(document.createTextNode(jobCode1));
            td2.style.width = "15%";
            td2.style.textAlign = "left";
            td2.style.fontSize = "11px";
            td2.style.paddingLeft = "5px";

            var td3 = document.createElement("TD");
            td3.appendChild(document.createTextNode(jobTitle1));
            td3.style.width = "10%";
            td3.style.textAlign = "left";
            td3.style.fontSize = "11px";
            td3.style.paddingLeft = "5px";

            var td4 = document.createElement("TD");
            td4.appendChild(document.createTextNode(DepartmentName1));
            td4.style.width = "10%";
            td4.style.textAlign = "left";
            td4.style.fontSize = "11px";
            td4.style.paddingRight = "5px";

            var td5 = document.createElement("TD");
            td5.appendChild(document.createTextNode(interv_R1));
            td5.style.width = "10%";
            td5.style.textAlign = "left";
            td5.style.fontSize = "11px";
            td5.style.paddingLeft = "5px";

            var td6 = document.createElement("TD");
            td6.appendChild(document.createTextNode(maxPoint1));
            td6.style.width = "20%";
            td6.style.textAlign = "left";
            td6.style.fontSize = "11px";
            td6.style.paddingLeft = "5px";
            
            var img3 = document.createElement('img');
            img3.style.cursor = "pointer";
            img3.src = "../images/dash_remove_icon.png";
            img3.style.height = "25px";
            img3.style.width = "25px";
            //img3.setAttribute('id', 'img9' + rid);
            img3.setAttribute("onclick", "Delete_onclick('" + jobId1 + "');");
            img3.style.display = "block";

            var td7 = document.createElement("TD");
            td7.appendChild(img3);
            td7.style.width = "50%";
            td7.style.textAlign = "Center";
            td7.style.fontSize = "11px";

            row.appendChild(td1);
            row.appendChild(td2);
            row.appendChild(td3);
            row.appendChild(td4);
            row.appendChild(td5);
            row.appendChild(td6);
            row.appendChild(td7);
           
            tbt.appendChild(row);
        }
    }
}


function Delete_onclick(source) {
   
    var Confm = confirm("Do You want to delete record");
    if (Confm == true) {
        Calender_details.Delete_InterView(source, Delete_Investment_Type_Master);
        Calender_details.Bind_InterView_Details(View_All_Vanancy_Detail);
    }
}
function Delete_Investment_Type_Master() {
   
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
