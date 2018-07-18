function reset_value1() {

    var txtDesig = document.getElementById("txtDesig");
    txtDesig.value = "";
   
}


////////////////////////////////Submit//////////////////////////////////

function submit_value1() {

    var txtDesig = document.getElementById("txtDesig");
    if (txtDesig.value == "") {
        window.alert("Please Enter Test Name...");
        txtDesig.focus();
        return false;
    }

    Calender_details.Insert_Test_Name(txtDesig.value,fill_Test_Name);
}
function fill_Test_Name(result) {
    if (result > 0) {
        reset_value1();
    }
}

///////////////////////////////////End Submit////////////////////


function View_All_Test() {

    var chk = document.getElementById("Checkbox2");
    if (chk.checked == true) {
        
        Calender_details.Bind_Test_Name(Fill_All_TestName);
    }
    else {
        var element = document.getElementById("xgrid");
        var trt = element.getElementsByTagName("TR");
        var lnt = trt.length;
        for (var i = 0; i < trt.length; i++) {
            element.deleteRow(i);
            lnt--;
            i--;
        }
    }
}


function Fill_All_TestName(result) {

    var xml = parseXml(result); //pass result string into function for xml conversion.
    if (xml) {
        bindgrid1(xml.documentElement); // call the bindgrid method and pass the root element of of xml form in the function.
    }
}
function bindgrid1(root) {

    var element = document.getElementById("xgrid");
    
    var trt = element.getElementsByTagName("TR");
    var lnt = trt.length;
    for (var i = 0; i < trt.length; i++) {
        element.deleteRow(i);
        lnt--;
        i--;
    }

    var RecruiterTestSeries1 = root.getElementsByTagName("RecruiterTestSeries1");
    var id = root.getElementsByTagName("id");
    var TestName = root.getElementsByTagName("TestName");
    var SessionId = root.getElementsByTagName("SessionId");
    var InstId = root.getElementsByTagName("InstId");
    var tbt = document.createElement("TBODY");
    element.appendChild(tbt);



    if (RecruiterTestSeries1.length != 0) {


        var headerRow = document.createElement("TR");
        var th1 = document.createElement("TH");
        th1.appendChild(document.createTextNode("Test id"));
        th1.style.height = "30px";
        th1.style.fontSize = "11px";
        th1.style.textAlign = "Left";
        th1.style.width = "10%";

        var th2 = document.createElement("TH");
        th2.appendChild(document.createTextNode("Test Name"));
        th2.style.height = "30px";
        th2.style.fontSize = "11px";
        th2.style.textAlign = "Left";
        th2.style.width = "20%";

        var th3 = document.createElement("TH");
        th3.appendChild(document.createTextNode("Year"));
        th3.style.height = "30px";
        th3.style.fontSize = "11px";
        th3.style.textAlign = "Left";
        th3.style.width = "10%";

        var th4 = document.createElement("TH");
        th4.appendChild(document.createTextNode("Inst Id"));
        th4.style.height = "30px";
        th4.style.fontSize = "11px";
        th4.style.textAlign = "Left";
        th4.style.width = "10%";

        var th5 = document.createElement("TH");
        th5.appendChild(document.createTextNode("Delete"));
        th5.style.height = "30px";
        th5.style.fontSize = "11px";
        th5.style.textAlign = "Left";
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
    if (RecruiterTestSeries1.length > 0) {

        for (var x = 0; x < RecruiterTestSeries1.length; x++) {
            var row = document.createElement("TR");
            var rid = "rc" + x;
            row.setAttribute('id', rid);

            var id1 = GetInnerText(id[x]);
            var TestName1 = GetInnerText(TestName[x]);
            var SessionId1 = GetInnerText(SessionId[x]);
            var InstId1 = GetInnerText(InstId[x]);

            var td1 = document.createElement("TD");
            td1.appendChild(document.createTextNode(id1));
            td1.style.width = "10%";
            td1.style.textAlign = "left";
            td1.style.fontSize = "11px";
            td1.style.paddingLeft = "5px";

            var td2 = document.createElement("TD");
            td2.appendChild(document.createTextNode(TestName1));
            td2.style.width = "20%";
            td2.style.textAlign = "left";
            td2.style.fontSize = "11px";
            td2.style.paddingLeft = "5px";

            var td3 = document.createElement("TD");
            td3.appendChild(document.createTextNode(SessionId1));
            td3.style.width = "10%";
            td3.style.textAlign = "left";
            td3.style.fontSize = "11px";
            td3.style.paddingLeft = "5px";

            var td4 = document.createElement("TD");
            td4.appendChild(document.createTextNode(InstId1));
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
            img3.setAttribute("onclick", "Delete_onclick('" + id1 + "');");
            img3.style.display = "block";

            var td5 = document.createElement("TD");
            td5.appendChild(img3);
            td5.style.width = "10%";
            td5.style.textAlign = "Center";
            td5.style.fontSize = "11px";

            row.appendChild(td1);
            row.appendChild(td2);
            row.appendChild(td3);
            row.appendChild(td4);
            row.appendChild(td5);

            tbt.appendChild(row);
        }
    }
}

function Delete_onclick(source) {
   
    var Confm = confirm("Do You want to delete record");
    if (Confm == true) {
        Calender_details.Delete_TEST(source, Delete_Investment_Type_Master);
        Calender_details.Bind_Test_Name(Fill_All_TestName);
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
