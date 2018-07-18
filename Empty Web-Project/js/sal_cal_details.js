function show_salary_details() {
    var ddlYear = document.getElementById("ddlYear");
    var ddlYear_value = ddlYear.options[ddlYear.selectedIndex].value;
    var ddlYear1 = document.getElementById("ddlYear1");
    var ddlYear1_value = ddlYear1.options[ddlYear1.selectedIndex].value;
    var ddlMon = document.getElementById("ddlMon");
    var ddlMon_value = ddlMon.options[ddlMon.selectedIndex].text;
    var ddlDept = document.getElementById("ddlDept");
    var ddlDept_value = ddlDept.options[ddlDept.selectedIndex].value;
    var ddlDesig = document.getElementById("ddlDesig");
    var ddlDesig_value = ddlDesig.options[ddlDesig.selectedIndex].value;
    var txtSearch = document.getElementById("txtSearch0");
    var search_val = "";
    var search_val1 = "";
    if (txtSearch.value != "") {
        search_val = txtSearch.value.split('(');
        search_val1 = search_val[1].split(')');
    }
    else {
        search_val1 = "0";
    }
    var des_valu = "";
    if (ddlDesig_value == "---Select---") {
        des_valu = "0";
    }
    else {
        des_valu = ddlDesig_value;
    }

    Calender_details.Bind_Employee_Salary_Details_view(ddlYear_value, ddlYear1_value, ddlMon_value, ddlDept_value, des_valu, search_val1, Fill_Wlkin_detail);
}
function Fill_Wlkin_detail(result) {
    var xml = parseXml(result); //pass result string into function for xml conversion.
    if (xml) {
        bindgrid1(xml.documentElement); // call the bindgrid method and pass the root element of of xml form in the function.
    }
}

function bindgrid1(root) {
    var element = document.getElementById("bind_emp_sal");
    var trt = element.getElementsByTagName("TR");
    var lnt = trt.length;
    for (var i = 0; i < trt.length; i++) {
        element.deleteRow(i);
        lnt--;
        i--;
    }
    var PaySalaryDet_C = root.getElementsByTagName("PaySalaryDet_C");
    var EmpCode = root.getElementsByTagName("EmpCode");
    var empname = root.getElementsByTagName("empname");
    var BasicSal = root.getElementsByTagName("BasicSal");
    var NetSal = root.getElementsByTagName("NetSal");
    var L_ded = root.getElementsByTagName("L_ded");
    var TotA = root.getElementsByTagName("TotA");
    var Reason = root.getElementsByTagName("Reason");
    var Mname = root.getElementsByTagName("Mname");
    var MainID = root.getElementsByTagName("MainID");
    var holdRej = root.getElementsByTagName("holdRej");
    var TotD = root.getElementsByTagName("TotD");
    var TotV = root.getElementsByTagName("TotV");
    var Sanccode = root.getElementsByTagName("Sanccode");
    var Atten = root.getElementsByTagName("Atten");

    var tbt = document.createElement("TBODY");
    element.appendChild(tbt);

    if (PaySalaryDet_C.length != 0) {

        var headerRow = document.createElement("TR");
        var th1 = document.createElement("TH");
        th1.appendChild(document.createTextNode("EmpCode"));
        th1.style.height = "30px";
        th1.style.fontSize = "11px";
        th1.style.textAlign = "center";
        th1.style.width = "15%";

        var th2 = document.createElement("TH");
        th2.appendChild(document.createTextNode("Employee Name"));
        th2.style.height = "30px";
        th2.style.fontSize = "11px";
        th2.style.textAlign = "center";
        th2.style.width = "20%";

        var th3 = document.createElement("TH");
        th3.appendChild(document.createTextNode("Basic Salary"));
        th3.style.height = "30px";
        th3.style.fontSize = "11px";
        th3.style.textAlign = "center";
        th3.style.width = "10%";

        var th4 = document.createElement("TH");
        th4.appendChild(document.createTextNode("Total Deduction"));
        th4.style.height = "30px";
        th4.style.fontSize = "11px";
        th4.style.textAlign = "center";
        th4.style.width = "10%";

        var th5 = document.createElement("TH");
        th5.appendChild(document.createTextNode("Net Salary"));
        th5.style.height = "30px";
        th5.style.fontSize = "11px";
        th5.style.textAlign = "center";
        th5.style.width = "10%";

        var th6 = document.createElement("TH");
        th6.appendChild(document.createTextNode("Salary Status"));
        th6.style.height = "30px";
        th6.style.fontSize = "11px";
        th6.style.textAlign = "center";
        th6.style.width = "10%";

        var th7 = document.createElement("TH");
        th7.appendChild(document.createTextNode("Reason"));
        th7.style.height = "30px";
        th7.style.fontSize = "11px";
        th7.style.textAlign = "center";
        th7.style.width = "25%";


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
    if (PaySalaryDet_C.length > 0) {

        for (var x = 0; x < PaySalaryDet_C.length; x++) {
            var row = document.createElement("TR");
            var rid = "rc" + x;
            row.setAttribute('id', rid);

            var EmpCode1 = GetInnerText(EmpCode[x]);
            var empname1 = GetInnerText(empname[x]);
            var BasicSal1 = GetInnerText(BasicSal[x]);
            var TotD1 = GetInnerText(TotD[x]);
            var NetSal1 = GetInnerText(NetSal[x]);
            var holdRej1 = GetInnerText(holdRej[x]);
            var Reason1 = GetInnerText(Reason[x]);
            var valueun = "";
            if (Reason1 == "undefined") {
                valueun = "";
            }
            else {
                valueun = Reason1;
            }

            if (Reason1 == "") {
                valueun = "";
            }
            else {
                valueun = Reason1;
            }
            if (Reason1 == undefined) {
                valueun = "";
            }
            else {
                valueun = Reason1;
            }



            var td1 = document.createElement("TD");
            td1.appendChild(document.createTextNode(EmpCode1));
            td1.style.width = "15%";
            td1.style.textAlign = "left";
            td1.style.fontSize = "11px";
            td1.style.paddingLeft = "5px";

            var td2 = document.createElement("TD");
            td2.appendChild(document.createTextNode(empname1));
            td2.style.width = "20%";
            td2.style.textAlign = "left";
            td2.style.fontSize = "11px";
            td2.style.paddingLeft = "5px";

            var td3 = document.createElement("TD");
            td3.appendChild(document.createTextNode(BasicSal1));
            td3.style.width = "10%";
            td3.style.textAlign = "left";
            td3.style.fontSize = "11px";
            td3.style.paddingLeft = "5px";


            var td4 = document.createElement("TD");
            td4.appendChild(document.createTextNode(TotD1));
            td4.style.width = "10%";
            td4.style.textAlign = "left";
            td4.style.fontSize = "11px";
            td4.style.paddingRight = "5px";

            var td5 = document.createElement("TD");
            td5.appendChild(document.createTextNode(NetSal1));
            td5.style.width = "10%";
            td5.style.textAlign = "left";
            td5.style.fontSize = "11px";
            td5.style.paddingRight = "5px";

            var value = "";
            if (holdRej1 == "R") {
                value = "Release";
            }
            else {
                value = "Hold";
            }

            var td6 = document.createElement("TD");
            td6.appendChild(document.createTextNode(value));
            td6.style.width = "10%";
            td6.style.textAlign = "left";
            td6.style.fontSize = "11px";
            td6.style.paddingRight = "5px";

            var td7 = document.createElement("TD");
            td7.appendChild(document.createTextNode(valueun));
            td7.style.width = "25%";
            td7.style.textAlign = "left";
            td7.style.fontSize = "11px";
            td7.style.paddingRight = "5px";


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
    $find('ModalPopupExtender5').show();

}
function employee_salary_onclick() {
    $find('ModalPopupExtender5').hide();
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