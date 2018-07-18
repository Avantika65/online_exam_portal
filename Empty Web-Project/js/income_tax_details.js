
function ddl_department_onchange() {
    var ddl_deparment = document.getElementById("ddl_deparment");
    var SelValue = ddl_deparment.options[ddl_deparment.selectedIndex].value;
    var progressBar1 = document.getElementById("progressBar1");
    progressBar1.style.display = "block";
    Income_Tax_Details.Get_Employee_name(SelValue,Fill_emplyee_details_bind);
}

function Fill_emplyee_details_bind(result) {
    var xml = parseXml(result); //pass result string into function for xml conversion.
    if (xml) {
        bindgrid(xml.documentElement); // call the bindgrid method and pass the root element of of xml form in the function.
    }
}

function bindgrid(root) {
    var element = document.getElementById("xGrid");
    var trt = element.getElementsByTagName("TR");
    var lnt = trt.length;
    for (var i = 0; i < trt.length; i++) {
        element.deleteRow(i);
        lnt--;
        i--;
    }

    var Employee_Master = root.getElementsByTagName("Employee_Master");
    var empCode = root.getElementsByTagName("empCode");
    var empname = root.getElementsByTagName("empname");
    var joinDate = root.getElementsByTagName("joinDate");
    var basicSal = root.getElementsByTagName("basicSal");
    var tbt = document.createElement("TBODY");
    element.appendChild(tbt);

    if (Employee_Master.length != 0) {
        var headerRow = document.createElement("TR");
        var th1 = document.createElement("TH");
        th1.appendChild(document.createTextNode("Employee Code"));
        th1.style.height = "30px";
        th1.style.fontSize = "11px";
        th1.style.textAlign = "center";
        th1.style.width = "10%";

        var th2 = document.createElement("TH");
        th2.appendChild(document.createTextNode("Employee Name"));
        th2.style.height = "30px";
        th2.style.fontSize = "11px";
        th2.style.textAlign = "center";
        th2.style.width = "20%";

        var th3 = document.createElement("TH");
        th3.appendChild(document.createTextNode("Joining Date"));
        th3.style.height = "30px";
        th3.style.fontSize = "11px";
        th3.style.textAlign = "center";
        th3.style.width = "10%";

        var th4 = document.createElement("TH");
        th4.appendChild(document.createTextNode("Current Salary"));
        th4.style.height = "30px";
        th4.style.fontSize = "11px";
        th4.style.textAlign = "center";
        th4.style.width = "10%";

        var th5 = document.createElement("TH");
        th5.appendChild(document.createTextNode(""));
        th5.style.height = "30px";
        th5.style.fontSize = "11px";
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
    if (Employee_Master.length > 0) {

        for (var x = 0; x < Employee_Master.length; x++) {
            var row = document.createElement("TR");
            var rid = "rc" + x;
            row.setAttribute('id', rid);

            var empCode1 = GetInnerText(empCode[x]);
            var empname1 = GetInnerText(empname[x]);
            var joinDate1 = GetInnerText(joinDate[x]);
            var basicSal1 = GetInnerText(basicSal[x]);

            var td1 = document.createElement("TD");
            td1.appendChild(document.createTextNode(empCode1));
            td1.style.width = "10%";
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
            td3.appendChild(document.createTextNode(joinDate1));
            td3.style.width = "10%";
            td3.style.textAlign = "left";
            td3.style.fontSize = "11px";
            td3.style.paddingLeft = "5px";

            var td4 = document.createElement("TD");
            td4.appendChild(document.createTextNode(basicSal1));
            td4.style.width = "10%";
            td4.style.textAlign = "right";
            td4.style.fontSize = "11px";
            td4.style.paddingRight = "5px";

            var img1 = document.createElement('img');
            img1.style.cursor = "pointer";
            img1.src = "../images/View-Details-Button.png";
            img1.setAttribute("onclick","onClick1('"+empCode1+"');");

            var td5 = document.createElement("TD");
            td5.appendChild(img1);
            td5.style.width = "10%";
            td5.style.textAlign = "left";
            td5.style.fontSize = "11px";

            row.appendChild(td1);
            row.appendChild(td2);
            row.appendChild(td3);
            row.appendChild(td4);
            row.appendChild(td5);
            tbt.appendChild(row);
        }
    }

    var progressBar1 = document.getElementById("progressBar1");
    progressBar1.style.display = "none";
}

function onClick1(emp) {
    window.location = "income_tex_second.aspx?empval=" + emp + "";
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
