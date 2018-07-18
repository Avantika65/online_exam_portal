function reset_value1() {
 
    var txtDesig = document.getElementById("txtDesig");
    txtDesig.value = "";
}


function submit_value1() {
    
    var txtDesig = document.getElementById("txtDesig");
    if (txtDesig.value == "") {
        window.alert("Please Declare Skill...");
        txtDesig.focus();
        return false;
    }
   
    Calender_details.Insert_KeySkill(txtDesig.value,fill_Skill);
}
function fill_Skill(result) {
    if (result > 0) {
        reset_value1();
    }
}
function View_All_Onchange() {
    var chk = document.getElementById("chkAll");
    if (chk.checked == true) {
        Calender_details.Bind_Skill_Details(Fill_Recrutment_detail);
    }
    else {
        var element = document.getElementById("xGrid");
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
    var element = document.getElementById("xGrid");
    var trt = element.getElementsByTagName("TR");
    var lnt = trt.length;
    for (var i = 0; i < trt.length; i++) {
        element.deleteRow(i);
        lnt--;
        i--;
    }
    var RecruiterSkill_name = root.getElementsByTagName("RecruiterSkill_name");
    var ID = root.getElementsByTagName("ID");
    var KeySkill = root.getElementsByTagName("KeySkill");

    var tbt = document.createElement("TBODY");
    element.appendChild(tbt);


    if (RecruiterSkill_name.length != 0) {

        var headerRow = document.createElement("TR");
        var th1 = document.createElement("TH");
        th1.appendChild(document.createTextNode("Skill Id"));
        th1.style.height = "30px";
        th1.style.fontSize = "11px";
        th1.style.textAlign = "center";
        th1.style.width = "10%";

        var th2 = document.createElement("TH");
        th2.appendChild(document.createTextNode("KeySkill"));
        th2.style.height = "30px";
        th2.style.fontSize = "11px";
        th2.style.textAlign = "center";
        th2.style.width = "20%";

        var th3 = document.createElement("TH");
        th3.appendChild(document.createTextNode("Delete"));
        th3.style.height = "30px";
        th3.style.fontSize = "11px";
        th3.style.textAlign = "center";
        th3.style.width = "10%";


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
    if (RecruiterSkill_name.length > 0) {

        for (var x = 0; x < RecruiterSkill_name.length; x++) {
            var row = document.createElement("TR");
            var rid = "rc" + x;
            row.setAttribute('id', rid);

            var ID1 = GetInnerText(ID[x]);
            var KeySkill1 = GetInnerText(KeySkill[x]);

            var td1 = document.createElement("TD");
            td1.appendChild(document.createTextNode(ID1));
            td1.style.width = "10%";
            td1.style.textAlign = "center";
            td1.style.fontSize = "11px";
            td1.style.paddingLeft = "5px";

            var td2 = document.createElement("TD");
            td2.appendChild(document.createTextNode(KeySkill1));
            td2.style.width = "20%";
            td2.style.textAlign = "center";
            td2.style.fontSize = "11px";
            td2.style.paddingLeft = "5px";

            var img3 = document.createElement('img');
            img3.style.cursor = "pointer";
            img3.src = "../images/dash_remove_icon.png";
            img3.style.height = "25px";
            img3.style.width = "25px";
            //img3.setAttribute('id', 'img9' + rid);
            img3.setAttribute("onclick", "Delete_onclick('" + ID1 + "');");
            img3.style.display = "block";

            var td3 = document.createElement("TD");
            td3.appendChild(img3);
            td3.style.width = "10%";
            td3.style.textAlign = "Center";
            td3.style.fontSize = "11px";
            td2.style.paddingLeft = "5px";

            row.appendChild(td1);
            row.appendChild(td2);
            row.appendChild(td3);
            tbt.appendChild(row);
        }
    }
}

function Delete_onclick(source) {

    var Confm = confirm("Do You want to delete record");
    if (Confm == true) {
        Calender_details.Delete_Skill(source, Delete_Investment_Type_Master);
        Calender_details.Bind_Skill_Details(Fill_Recrutment_detail);
    }
}
function Delete_Investment_Type_Master() {
    aler("ok");
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
