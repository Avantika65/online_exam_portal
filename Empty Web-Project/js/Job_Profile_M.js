var src;
var prevrow = "rc0";
var del_id = "";
var inserted_row_id = "0";
var empidvalue;
var employee_code;
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

function View_All_Onchange() {

    var chk = document.getElementById("chkAll");
    if (chk.checked == true) {
        Calender_details.Bind_Details(Fill_Recrutment_detail);
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
    }
}


function Fill_Recrutment_detail(result) {
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

    var job_prifile_M = root.getElementsByTagName("Department_1");
    var job_prifile_ID = root.getElementsByTagName("id");
    var Department = root.getElementsByTagName("Department");
    var Recruting_Department = root.getElementsByTagName("Recruting_Department");
    var Designation = root.getElementsByTagName("Designation");
    var Recruting_Authority = root.getElementsByTagName("Recruting_Authority");
    var tbt = document.createElement("TBODY");
    element.appendChild(tbt);


    if (job_prifile_M.length != 0) {

        var headerRow = document.createElement("TR");
        var th1 = document.createElement("TH");
        th1.appendChild(document.createTextNode("Department"));
        th1.style.height = "30px";
        th1.style.fontSize = "11px";
        th1.style.textAlign = "center";
        th1.style.width = "10%";

        var th2 = document.createElement("TH");
        th2.appendChild(document.createTextNode("Recruting Department"));
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
        th4.appendChild(document.createTextNode("Recruting Authority"));
        th4.style.height = "30px";
        th4.style.fontSize = "11px";
        th4.style.textAlign = "center";
        th4.style.width = "10%";

        var th5 = document.createElement("TH");
        th5.appendChild(document.createTextNode("Delete"));
        th5.style.height = "22px";
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
    if (job_prifile_M.length > 0) {

        for (var x = 0; x < job_prifile_M.length; x++) {
            var row = document.createElement("TR");
            var rid = "rc" + x;
            row.setAttribute('id', rid);

            var Department1 = GetInnerText(Department[x]);
            var job_prifile_ID1 = GetInnerText(job_prifile_ID[x]);
            var Recruting_Department1 = GetInnerText(Recruting_Department[x]);
            var Designation1 = GetInnerText(Designation[x]);
            var Recruting_Authority1 = GetInnerText(Recruting_Authority[x]);

            var td1 = document.createElement("TD");
            td1.appendChild(document.createTextNode(Department1));
            td1.style.width = "10%";
            td1.style.textAlign = "left";
            td1.style.fontSize = "11px";
            td1.style.paddingLeft = "5px";

            var td2 = document.createElement("TD");
            td2.appendChild(document.createTextNode(Recruting_Department1));
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
            td4.appendChild(document.createTextNode(Recruting_Authority1));
            td4.style.width = "10%";
            td4.style.textAlign = "left";
            td4.style.fontSize = "11px";
            td4.style.paddingRight = "5px";

            var img3 = document.createElement('img');
            img3.style.cursor = "pointer";
            img3.src = "../images/dash_remove_icon.png";
            img3.style.height = "25px";
            img3.style.width = "25px";
            //img3.setAttribute('id', 'img9' + rid);
            img3.setAttribute("onclick", "Delete_onclick('" + job_prifile_ID1 + "');");
            img3.style.display = "block";

            var td5 = document.createElement("TD");
            td5.appendChild(img3);
            td5.style.width = "6%";
            td5.style.Align = "Center";
            td5.style.fontSize = "11px";
            td5.style.padding = "5px";

            row.appendChild(td1);
            row.appendChild(td2);
            row.appendChild(td3);
            row.appendChild(td4);
            row.appendChild(td5);

            tbt.appendChild(row);
        }
    }
}
////////////////////////////////Delete/////////////////////////////////////////////
function Delete_onclick(source) {
    
    var Confm = confirm("Do You want to delete record");
    if (Confm == true) {
        Calender_details.Delete_R_Athority(source, Delete_Investment_Type_Master);
        Calender_details.Bind_Details(Fill_Recrutment_detail);
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

////////////////////////////////////////End Checkbox/////////////////////////

////////////////////// Searching///////////////////////////////////////


function get_emplyee_value(Search) {
    src=Search;
    var txt = document.getElementById(src);

    Calender_details.BindEmployee_grid_search(txt.value, Fill_empsearch);
}

function Fill_empsearch(result) {
    var xml = parseXml(result); //pass result string into function for xml conversion.
    if (xml) {
        bindgrid(xml.documentElement, inserted_row_id); // call the bindgrid method and pass the root element of of xml form in the function.
    }
}
function bindgrid(root, index) {
    var element = document.getElementById("xgrid");
    var trt = element.getElementsByTagName("TR");
    var lnt = trt.length;
    for (var i = 0; i < trt.length; i++) {
        element.deleteRow(i);
        lnt--;
        i--;
    }

    var employee_master = root.getElementsByTagName("employee_master");
    var empname = root.getElementsByTagName("empname");
    var empcode = root.getElementsByTagName("empcode");
    var empid = root.getElementsByTagName("empid");
    var tbt = document.createElement("TBODY");
    element.appendChild(tbt);

    var txt = document.getElementById(src);
    var p = GetScreenCordinates(txt);
    var xval = p.x;
    var yval = p.y;
    var grd_serch = document.getElementById("grd_serch");
    grd_serch.style.display = "block";
    grd_serch.style.left = xval + 2 + 'px';
    grd_serch.style.top = yval + 33 + 'px';
    if (employee_master.length > 0) {
        for (var x = 0; x < employee_master.length; x++) {
            var row = document.createElement("TR");
            var rid = "rc" + x;
            row.setAttribute('id', rid);
            row.setAttribute('onclick', "onClick(this);");
            row.setAttribute('onmouseover', "onRowMouseOver(this);");
            row.setAttribute('onmouseout', "onRowMouseOut(this);");
            var empname1 = GetInnerText(empname[x]);
            var empcode1 = GetInnerText(empcode[x]);
            var empid1 = GetInnerText(empid[x]);
            var td2 = document.createElement("TD");
            td2.appendChild(document.createTextNode(empname1));
            var td3 = document.createElement("TD");
            td3.appendChild(document.createTextNode(empcode1));
            td3.style.display = "none";
            var td4 = document.createElement("TD");
            td4.appendChild(document.createTextNode(empid1));
            td4.style.display = "none";
            row.appendChild(td2);
            row.appendChild(td3);
            row.appendChild(td4);
            tbt.appendChild(row);
        }

    }
    else {
        var row = document.createElement("TR");
        var rid = "rc" + 1;
        row.setAttribute('id', rid);
        row.setAttribute('onclick', "onClick(this);");
        row.setAttribute('onmouseover', "onRowMouseOver(this);");
        row.setAttribute('onmouseout', "onRowMouseOut(this);");
        var empname1 = "No Record Found"
        var td2 = document.createElement("TD");
        td2.appendChild(document.createTextNode(empname1));
        row.appendChild(td2);
        tbt.appendChild(row);
    }
}

function onClick(source) {
    getData(source);
}

function getData(tableRow) {
    var element = document.getElementById("xgrid");
    var trt = element.getElementsByTagName('TR');
    var currow = tableRow.id;
    var trprev = document.getElementById(prevrow);
    if (trprev != null) {
        var tdtag = trprev.getElementsByTagName('TD');

        if (tdtag.length > 0) {
            tdtag[0].style.backgroundColor = "White";
            tdtag[0].style.color = "Black";
        }
    }
    var tds = tableRow.getElementsByTagName("TD");
    tds[0].style.backgroundColor = "#8868CA";
    tds[0].style.color = "Black";
    prevrow = currow;
    if (GetInnerText(tds[0]) == "No Record Found") {
        var lbl_slno = document.getElementById(src);
        lbl_slno.value = "";
    }
    else {
        var lbl_slno = document.getElementById(src);
        lbl_slno.value = GetInnerText(tds[0]) + " (" + GetInnerText(tds[1]) + ")";
    }
    empidvalue = GetInnerText(tds[2]);

    var grd_serch = document.getElementById("grd_serch");
    grd_serch.style.display = "none";
}

function onRowMouseOver(source) {
    var tdt = source.getElementsByTagName('TD');
    for (var i = 0; i < tdt.length; i++) {
        tdt[i].style.backgroundColor = "lightblue";
    }
}



function onRowMouseOut(source) {
    var tdt = source.getElementsByTagName('TD');
    for (var i = 0; i < tdt.length; i++) {
        tdt[i].style.backgroundColor = "white";
    }
}

function GetScreenCordinates(obj) {
    var p = {};
    p.x = obj.offsetLeft;
    p.y = obj.offsetTop;
    while (obj.offsetParent) {
        p.x = p.x + obj.offsetParent.offsetLeft;
        p.y = p.y + obj.offsetParent.offsetTop;
        if (obj == document.getElementsByTagName("body")[0]) {
            break;
        }
        else {
            obj = obj.offsetParent;
        }
    }
    return p;
}

//////////////////////////Searching END//////////////////////////////////////

//////////////////////////// Reset//////////////////////////////////////////////
function reset_value1() {
    var ddlEmpTitle = document.getElementById("ddlDept");
    ddlDept.options[0].selected = true;
    var empnam = document.getElementById("ddlDesig");
    ddlDesig.options[0].selected = true;
    var txtEmpName = document.getElementById("ddlRDept");
    ddlRDept.options[0].selected = true;
    var emplastnm = document.getElementById("txtSearch0");
    txtSearch0.value = "";
    var element = document.getElementById("xGrid1");
    var trt = element.getElementsByTagName("TR");
    var lnt = trt.length;
    for (var i = 0; i < trt.length; i++) {
        element.deleteRow(i);
        lnt--;
        i--;
    } 
}
    

//////////////////////////// Reset END//////////////////////////////////////////////
//////////////////////////////////////////// Submit/////////////////////////


function submit_value1() {
   
    var ddlDept = document.getElementById("ddlDept");
    var SelValue = ddlDept.options[ddlDept.selectedIndex].value;
    if (SelValue == "0") {
        window.alert("Please select Department....");
        ddlDept.focus();
        return false;
    }
    var ddlDesig = document.getElementById("ddlDesig");
    var SelValue1 = ddlDesig.options[ddlDesig.selectedIndex].value;
    if (SelValue1 == "0") {
        window.alert("Please select Designation....");
        ddlDesig.focus();
        return false;
    }
    var ddlRDept = document.getElementById("ddlRDept");
    var SelValue2 = ddlRDept.options[ddlRDept.selectedIndex].value;
    if (SelValue2 == "0") {
        window.alert("Please select Recruting Department....");
        ddlRDept.focus();
        return false;
    }
    var txtSearch0 = document.getElementById("txtSearch0");
    if (txtSearch0.value == "") {
        window.alert("Please Select Recruting Authority...");
        txtSearch0.focus();
        return false;
    }
    Calender_details.Insert_Recructing_Authority_Master(SelValue, SelValue1, SelValue2, empidvalue, fill_Recrutment_Authority);
}
function fill_Recrutment_Authority(result) {
    if (result > 0) {
        reset_value1();
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
