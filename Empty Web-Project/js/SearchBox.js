
var SearchBoxID;
var inserted_row_id = "0";
var prevrow = "rc0";
var GetSelectedValue;
function get_Search_value(searchBoxName) {

    SearchBoxID = searchBoxName;
    var txt = document.getElementById(searchBoxName);    
    Calender_details.Bind_search_Records(txt.value, Fill_empsearch);
}

function Fill_empsearch(result) {
    
    var xml = parseXml(result); //pass result string into function for xml conversion.
    if (xml) {
        bindgrid(xml.documentElement); // call the bindgrid method and pass the root element of of xml form in the function.
    }
}

function bindgrid(root) {
    var element = document.getElementById("xgrid");
    var trt = element.getElementsByTagName("TR");
    var lnt = trt.length;
    for (var i = 0; i < trt.length; i++) {
        element.deleteRow(i);
        lnt--;
        i--;
    }
    var employee_master = root.getElementsByTagName("TableName");
    var empname = root.getElementsByTagName("TextName");
    var empcode = root.getElementsByTagName("TextID");
    var tbt = document.createElement("TBODY");
    element.appendChild(tbt);

    var txt = document.getElementById(SearchBoxID);    
    var p = GetScreenCordinates(txt);
    var xval = p.x;
    var yval = p.y;
    var grd_serch = document.getElementById("grd_serch");
    grd_serch.style.display = "block";
    grd_serch.style.left = xval + 2 + 'px';
    grd_serch.style.top = yval + 44 + 'px';
    if (employee_master.length > 0) {
        for (var x = 0; x < employee_master.length; x++) {
            var row = document.createElement("TR");
            row.style.cursor = "pointer";
            var rid = "rc" + x;
            row.setAttribute('id', rid);
            row.setAttribute('onclick', "onClick(this);");
            row.setAttribute('onmouseover', "onRowMouseOver(this);");
            row.setAttribute('onmouseout', "onRowMouseOut(this);");            
            var empname1 = GetInnerText(empname[x]);
            var empcode1 = GetInnerText(empcode[x]);
            
            var td1 = document.createElement("TD");
            td1.appendChild(document.createTextNode(empname1));
            var td2 = document.createElement("TD");
            td2.appendChild(document.createTextNode(empcode1));
            td2.style.display = "none";
            row.appendChild(td1);
            row.appendChild(td2);
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
        var lbl_slno = document.getElementById(SearchBoxID);
        lbl_slno.value = "";
    }
    else {
        var lbl_slno = document.getElementById(SearchBoxID);
        lbl_slno.value = GetInnerText(tds[0]);
        GetSelectedValue = GetInnerText(tds[1]);
        
    }

    document.getElementById("hdnSelectedValueID").value = GetInnerText(tds[1]);   
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


