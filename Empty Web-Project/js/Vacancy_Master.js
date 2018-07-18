function Fill_Vacancy_Grid() {
   
    var ddlProfile = document.getElementById("ddlProfile");
    var ddlProfile1 = ddlProfile.options[ddlProfile.selectedIndex].value;
    if (ddlProfile1 != "0") {
        Calender_details.Bind_Vacancy(ddlProfile1, Fill_Vacancy);
    }
    else {
       
        var element = document.getElementById("xGrid1");
        var trt = element.getElementsByTagName("TR");
        var lnt = trt.length;
        for (var i = 0; i < trt.length; i++) {
            element.deleteRow(i);
            lnt--;
            i--;
        }
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
    var Add_vacancy = root.getElementsByTagName("Add_Vacancy_New_View");
    var Job_Code = root.getElementsByTagName("Job_Code");
    var Job_Profile = root.getElementsByTagName("Job_Profile");
    var Designation = root.getElementsByTagName("Designation");
    var DepartmentName = root.getElementsByTagName("DepartmentName");
    var MIn_Exp = root.getElementsByTagName("MIn_Exp");
    var Total_Vacancy = root.getElementsByTagName("Total_Vacancy");
    var Start_Date = root.getElementsByTagName("Start_Date");
    var End_Date = root.getElementsByTagName("End_Date");
    var Qualification = root.getElementsByTagName("Qualification");
    var Min_Per = root.getElementsByTagName("Min_Per");
    var Current_Status = root.getElementsByTagName("Current_Status");
    var tbt = document.createElement("TBODY");
    element.appendChild(tbt);

    if (Add_vacancy.length != 0) {
        var headerRow = document.createElement("TR");

        var th1 = document.createElement("TH");
        th1.appendChild(document.createTextNode("Job Code"));
        th1.style.height = "30px";
        th1.style.fontSize = "11px";
        th1.style.textAlign = "center";
        th1.style.width = "10%";

        var th2 = document.createElement("TH");
        th2.appendChild(document.createTextNode("Job Profile"));
        th2.style.height = "30px";
        th2.style.fontSize = "11px";
        th2.style.textAlign = "center";
        th2.style.width = "20%";

        var th3 = document.createElement("TH");
        th3.appendChild(document.createTextNode("Designation"));
        th3.style.height = "30px";
        th3.style.fontSize = "11px";
        th3.style.textAlign = "center";
        th3.style.width = "10%";

        var th4 = document.createElement("TH");
        th4.appendChild(document.createTextNode("Department Name"));
        th4.style.height = "30px";
        th4.style.fontSize = "11px";
        th4.style.textAlign = "center";
        th4.style.width = "10%";

        var th5 = document.createElement("TH");
        th5.appendChild(document.createTextNode("Minimum Experience(in years)"));
        th5.style.height = "30px";
        th5.style.fontSize = "11px";
        th5.style.textAlign = "center";
        th5.style.width = "10%";

        var th6 = document.createElement("TH");
        th6.appendChild(document.createTextNode("Total Vacancy"));
        th6.style.height = "30px";
        th6.style.fontSize = "11px";
        th6.style.textAlign = "center";
        th6.style.width = "10%";

        var th7 = document.createElement("TH");
        th7.appendChild(document.createTextNode("Start Date"));
        th7.style.height = "30px";
        th7.style.fontSize = "11px";
        th7.style.textAlign = "center";
        th7.style.width = "10%";

        var th8 = document.createElement("TH");
        th8.appendChild(document.createTextNode("Last Date"));
        th8.style.height = "30px";
        th8.style.fontSize = "11px";
        th8.style.textAlign = "center";
        th8.style.width = "10%";

        var th9 = document.createElement("TH");
        th9.appendChild(document.createTextNode("Qualification"));
        th9.style.height = "30px";
        th9.style.fontSize = "11px";
        th9.style.textAlign = "center";
        th9.style.width = "10%";

        var th10 = document.createElement("TH");
        th10.appendChild(document.createTextNode("Marks Percentage (in %)"));
        th10.style.height = "30px";
        th10.style.fontSize = "11px";
        th10.style.textAlign = "center";
        th10.style.width = "10%";

        var th11 = document.createElement("TH");
        th11.appendChild(document.createTextNode("Current Vacancy Status"));
        th11.style.height = "30px";
        th11.style.fontSize = "11px";
        th11.style.backColour = "red";
        th11.style.textAlign = "center";
        th11.style.width = "10%";

      
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
            var Designation1 = GetInnerText(Designation[x]);
            var DepartmentName1 = GetInnerText(DepartmentName[x]);
            var MIn_Exp1 = GetInnerText(MIn_Exp[x]);
            var Total_Vacancy1 = GetInnerText(Total_Vacancy[x]);
            var Start_Date1 = GetInnerText(Start_Date[x]);
            var End_Date1 = GetInnerText(End_Date[x]);
            var Qualification1 = GetInnerText(Qualification[x]);
            var Min_Per1 = GetInnerText(Min_Per[x]);
            var Current_Status1 = GetInnerText(Current_Status[x]);
       

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

            var td3 = document.createElement("TD");
            td3.appendChild(document.createTextNode(Designation1));
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
            td5.appendChild(document.createTextNode(MIn_Exp1));
            td5.style.width = "10%";
            td5.style.textAlign = "left";
            td5.style.fontSize = "11px";
            td5.style.paddingLeft = "5px";

            var td6 = document.createElement("TD");
            td6.appendChild(document.createTextNode(Total_Vacancy1));
            td6.style.width = "20%";
            td6.style.textAlign = "left";
            td6.style.fontSize = "11px";
            td6.style.paddingLeft = "5px";

            var td7 = document.createElement("TD");
            td7.appendChild(document.createTextNode(Start_Date1));
            td7.style.width = "10%";
            td7.style.textAlign = "left";
            td7.style.fontSize = "11px";
            td7.style.paddingLeft = "5px";

            var td8 = document.createElement("TD");
            td8.appendChild(document.createTextNode(End_Date1));
            td8.style.width = "10%";
            td8.style.textAlign = "left";
            td8.style.fontSize = "11px";
            td8.style.paddingRight = "5px";

            var td9 = document.createElement("TD");
            td9.appendChild(document.createTextNode(Qualification1));
            td9.style.width = "10%";
            td9.style.textAlign = "left";
            td9.style.fontSize = "11px";
            td9.style.paddingLeft = "5px";

            var td10 = document.createElement("TD");
            td10.appendChild(document.createTextNode(Min_Per1));
            td10.style.width = "20%";
            td10.style.textAlign = "left";
            td10.style.fontSize = "11px";
            td10.style.paddingLeft = "5px";

            var td11 = document.createElement("TD");
            td11.appendChild(document.createTextNode(Current_Status1));
            td11.style.width = "10%";
            td11.style.textAlign = "left";
            td11.style.fontSize = "11px";
            td11.style.paddingLeft = "5px";

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
