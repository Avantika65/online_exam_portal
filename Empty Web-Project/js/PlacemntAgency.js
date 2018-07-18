

function country_onchange() {
    var ddlCountryP = document.getElementById("ddlCountry");
    var ddlCountryP_value1 = ddlCountry.options[ddlCountry.selectedIndex].value;
    Calender_details.BindState_value(ddlCountryP_value1, Fill_State);
}
function Fill_State(result) {
    var xml = parseXml(result);
    if (xml) {
        bindstate_dll(xml.documentElement);
    }
}
function bindstate_dll(DistNode) {
    var ddlStateP = document.getElementById("ddlState");
    for (var count = ddlState.options.length - 1; count > -1; count--) {
        ddlState.options[count] = null;
    }
    var val;
    var desc;
    var optionitem;
    val = "0";
    desc = "----Select----"; ;
    optionitem = new Option(desc, val, false, false);
    ddlState.options[ddlState.length] = optionitem;
    var IdNode = DistNode.getElementsByTagName('StateId');
    var DescNode = DistNode.getElementsByTagName('StateName');
    for (var count1 = 0; count1 < IdNode.length; count1++) {
        val = GetInnerText(IdNode[count1]);
        desc = GetInnerText(DescNode[count1]);
        optionitem = new Option(desc, val, false, false);
        ddlState.options[ddlState.length] = optionitem;
    }
    ddlState.options[0].selected = true;
}
function state_onchange() {
    var ddlStateP = document.getElementById("ddlState");
    var ddlStateP_value1 = ddlState.options[ddlState.selectedIndex].value;
    Calender_details.Bindcity_value(ddlStateP_value1, Fill_City);
}
function Fill_City(result) {
    var xml = parseXml(result);
    if (xml) {
        bindcity_dll(xml.documentElement);
    }
}
function bindcity_dll(DistNode) {
    var ddlCityP = document.getElementById("ddlCityP");
    for (var count = ddlCityP.options.length - 1; count > -1; count--) {
        ddlCityP.options[count] = null;
    }
    var val;
    var desc;
    var optionitem;
    val = "0";
    desc = "----Select----"; ;
    optionitem = new Option(desc, val, false, false);
    ddlCityP.options[ddlCityP.length] = optionitem;
    var IdNode = DistNode.getElementsByTagName('CityId');
    var DescNode = DistNode.getElementsByTagName('CityName');
    for (var count1 = 0; count1 < IdNode.length; count1++) {
        val = GetInnerText(IdNode[count1]);
        desc = GetInnerText(DescNode[count1]);
        optionitem = new Option(desc, val, false, false);
        ddlCityP.options[ddlCityP.length] = optionitem;
    }
    ddlCityP.options[0].selected = true;
}






function reset_value1() {
    var ddlCountry = document.getElementById("ddlCountry");
    ddlCountry.options[0].selected = true;
    var txtAgncyN = document.getElementById("txtAgncyN");
    txtAgncyN.value = "";
    var txtAdd = document.getElementById("txtAdd");
    txtAdd.value = "";
    var ddlState = document.getElementById("ddlState");
    ddlState.options[0].selected = true;
    var ddlCityP = document.getElementById("ddlCityP");
    ddlCityP.options[0].selected = true;
    var txtZip = document.getElementById("txtZip");
    txtZip.value = "";
    var txtContP = document.getElementById("txtContP");
    txtContP.value = "";
    var txtEmail = document.getElementById("txtEmail");
    txtEmail.value = "";
    var txtPh = document.getElementById("txtPh");
    txtPh.value = "";
    var txtMobP = document.getElementById("txtMobP");
    txtMobP.value = "";
    var ddlMedType = document.getElementById("ddlMedType");
    ddlMedType.options[0].selected = true;
}


function submit_value1() {
    
 var txtAgncyN = document.getElementById("txtAgncyN");
    if (txtAgncyN.value == "") {
        window.alert("Please Enter Agency Name...");
        txtAgncyN.focus();
        return false;
    }
     var txtAdd = document.getElementById("txtAdd");
    if (txtAdd.value == "") {
        window.alert("Please Enter Agency Address...");
        txtAdd.focus();
        return false;
    }
    var ddlCountry = document.getElementById("ddlCountry");
    var ddlCountry1 = ddlCountry.options[ddlCountry.selectedIndex].value;
    if (ddlCountry1 == "0") {
        window.alert("Please select Country....");
        ddlCountry.focus();
        return false;
    }
     var ddlState = document.getElementById("ddlState");
    var ddlState1 = ddlState.options[ddlState.selectedIndex].value;
    if (ddlState1 == "0") {
        window.alert("Please select State....");
        ddlState.focus();
        return false;
    }
    var ddlCityP = document.getElementById("ddlCityP");
    var ddlCity1 = ddlCityP.options[ddlCityP.selectedIndex].value;
    if (ddlCity1 == "0") {
        window.alert("Please select City....");
        ddlCity.focus();
        return false;
    }
     var txtZip = document.getElementById("txtZip");
    if (txtZip.value == "") {
        window.alert("Please Enter Zipcode...");
        txtZip.focus();
        return false;
    }
     var txtContP = document.getElementById("txtContP");
    if (txtContP.value == "") {
        window.alert("Please Enter Contact Person Name...");
        txtContP.focus();
        return false;
    }
     var txtEmail = document.getElementById("txtEmail");
    if (txtEmail.value == "") {
        window.alert("Please Enter Email Address...");
        txtEmail.focus();
        return false;
    }
     var txtPh = document.getElementById("txtPh");
    if (txtPh.value == "") {
        window.alert("Please Enter Phone Number...");
        txtPh.focus();
        return false;
    }
     var txtMobP = document.getElementById("txtMobP");
    if (txtMobP.value == "") {
        window.alert("Please Enter Mobile Number...");
        txtMobP.focus();
        return false;
    }
    var ddlMedType = document.getElementById("ddlMedType");
    var ddlMedType1 = ddlMedType.options[ddlMedType.selectedIndex].value;
    if (ddlMedType1 == "0") {
        window.alert("Please select Media Type....");
        ddlMedType.focus();
        return false;
    }
   
    Calender_details.Insert_Placement_Agency(txtAgncyN.value, txtAdd.value, ddlCountry1, ddlState1, ddlCity1, txtZip.value, txtContP.value, txtEmail.value, txtPh.value, txtMobP.value, ddlMedType1, fill_Placement_Agency);
}
function fill_Placement_Agency(result) {
    if (result > 0) {
        window.alert("Saved Successfully..");

        reset_value1();
    }
   
}
//////////////////////////////////////////////////////////////////////
function View_All_Onchange() {
    var chk = document.getElementById("chkAll");
    if (chk.checked == true) {
        Calender_details.Bind_All_Placement(Fill_PlacementDetail);
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
function Fill_PlacementDetail(result) {
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
    var Placement_Agency = root.getElementsByTagName("Placement_Agency");
    var Agency_ID = root.getElementsByTagName("id");
    var AgencyName = root.getElementsByTagName("AgencyName");
    var ContactPersonName = root.getElementsByTagName("ContactPersonName");
    var AgencyAdd = root.getElementsByTagName("AgencyAdd");
    var CountryName = root.getElementsByTagName("CountryName");
    var StateName = root.getElementsByTagName("StateName");
    var CityName = root.getElementsByTagName("CityName");
    var PhoneNumber = root.getElementsByTagName("PhoneNumber");
    var Email = root.getElementsByTagName("Email");
    var MediaName = root.getElementsByTagName("MediaName");
    var tbt = document.createElement("TBODY");
    element.appendChild(tbt);
    if (Placement_Agency.length != 0) {

        var headerRow = document.createElement("TR");
        var th1 = document.createElement("TH");
        th1.appendChild(document.createTextNode("Agency Name"));
        th1.style.height = "30px";
        th1.style.fontSize = "11px";
        th1.style.textAlign = "center";
        th1.style.width = "10%";

        var th2 = document.createElement("TH");
        th2.appendChild(document.createTextNode("Contact Person Name"));
        th2.style.height = "30px";
        th2.style.fontSize = "11px";
        th2.style.textAlign = "center";
        th2.style.width = "20%";

        var th3 = document.createElement("TH");
        th3.appendChild(document.createTextNode("Agency Address"));
        th3.style.height = "30px";
        th3.style.fontSize = "11px";
        th3.style.textAlign = "center";
        th3.style.width = "10%";

        var th4 = document.createElement("TH");
        th4.appendChild(document.createTextNode("Country"));
        th4.style.height = "30px";
        th4.style.fontSize = "11px";
        th4.style.textAlign = "center";
        th4.style.width = "10%";

        var th5 = document.createElement("TH");
        th5.appendChild(document.createTextNode("State"));
        th5.style.height = "30px";
        th5.style.fontSize = "11px";
        th5.style.textAlign = "center";
        th5.style.width = "10%";

        var th6 = document.createElement("TH");
        th6.appendChild(document.createTextNode("City"));
        th6.style.height = "30px";
        th6.style.fontSize = "11px";
        th6.style.textAlign = "center";
        th6.style.width = "20%";

        var th7 = document.createElement("TH");
        th7.appendChild(document.createTextNode("Phone"));
        th7.style.height = "30px";
        th7.style.fontSize = "11px";
        th7.style.textAlign = "center";
        th7.style.width = "10%";

        var th8 = document.createElement("TH");
        th8.appendChild(document.createTextNode("Email Address"));
        th8.style.height = "30px";
        th8.style.fontSize = "11px";
        th8.style.textAlign = "center";
        th8.style.width = "10%";

        var th9 = document.createElement("TH");
        th9.appendChild(document.createTextNode("Media Name"));
        th9.style.height = "30px";
        th9.style.fontSize = "11px";
        th9.style.textAlign = "center";
        th9.style.width = "10%";

        var th10 = document.createElement("TH");
        th10.appendChild(document.createTextNode("Delete"));
        th10.style.height = "30px";
        th10.style.fontSize = "11px";
        th10.style.textAlign = "center";
        th10.style.width = "10%";

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
    if (Placement_Agency.length > 0) {

        for (var x = 0; x < Placement_Agency.length; x++) {
            var row = document.createElement("TR");
            var rid = "rc" + x;
            row.setAttribute('id', rid);

            var AgencyName1 = GetInnerText(AgencyName[x]);
            var Agency_ID1 = GetInnerText(Agency_ID[x]);
            var ContactPersonName1 = GetInnerText(ContactPersonName[x]);
            var AgencyAdd1 = GetInnerText(AgencyAdd[x]);
            var CountryName1 = GetInnerText(CountryName[x]);
            var StateName1 = GetInnerText(StateName[x]);
            var CityName1 = GetInnerText(CityName[x]);
            var PhoneNumber1 = GetInnerText(PhoneNumber[x]);
            var Email1 = GetInnerText(Email[x]);
            var MediaName1 = GetInnerText(MediaName[x]);

            var td1 = document.createElement("TD");
            td1.appendChild(document.createTextNode(AgencyName1));
            td1.style.width = "10%";
            td1.style.textAlign = "left";
            td1.style.fontSize = "11px";
            td1.style.paddingLeft = "5px";

            var td2 = document.createElement("TD");
            td2.appendChild(document.createTextNode(ContactPersonName1));
            td2.style.width = "20%";
            td2.style.textAlign = "left";
            td2.style.fontSize = "11px";
            td2.style.paddingLeft = "5px";

            var td3 = document.createElement("TD");
            td3.appendChild(document.createTextNode(AgencyAdd1));
            td3.style.width = "10%";
            td3.style.textAlign = "left";
            td3.style.fontSize = "11px";
            td3.style.paddingLeft = "5px";

            var td4 = document.createElement("TD");
            td4.appendChild(document.createTextNode(CountryName1));
            td4.style.width = "10%";
            td4.style.textAlign = "left";
            td4.style.fontSize = "11px";
            td4.style.paddingRight = "5px";

            var td5 = document.createElement("TD");
            td5.appendChild(document.createTextNode(StateName1));
            td5.style.width = "10%";
            td5.style.textAlign = "left";
            td5.style.fontSize = "11px";
            td5.style.paddingLeft = "5px";

            var td6 = document.createElement("TD");
            td6.appendChild(document.createTextNode(CityName1));
            td6.style.width = "20%";
            td6.style.textAlign = "left";
            td6.style.fontSize = "11px";
            td6.style.paddingLeft = "5px";

            var td7 = document.createElement("TD");
            td7.appendChild(document.createTextNode(PhoneNumber1));
            td7.style.width = "10%";
            td7.style.textAlign = "left";
            td7.style.fontSize = "11px";
            td7.style.paddingLeft = "5px";

            var td8 = document.createElement("TD");
            td8.appendChild(document.createTextNode(Email1));
            td8.style.width = "10%";
            td8.style.textAlign = "left";
            td8.style.fontSize = "11px";
            td8.style.paddingRight = "5px";

            var td9 = document.createElement("TD");
            td9.appendChild(document.createTextNode(MediaName1));
            td9.style.width = "10%";
            td9.style.textAlign = "left";
            td9.style.fontSize = "11px";
            td9.style.paddingRight = "5px";

            var img3 = document.createElement('img');
            img3.style.cursor = "pointer";
            img3.src = "../images/dash_remove_icon.png";
            img3.style.height = "25px";
            img3.style.width = "25px";
            //img3.setAttribute('id', 'img9' + rid);
            img3.setAttribute("onclick", "Delete_onclick('" + Agency_ID1 + "');");
            img3.style.display = "block";

            var td10 = document.createElement("TD");
            td10.appendChild(img3);
            td10.style.width = "10%";
            td10.style.textAlign = "Center";
            td10.style.fontSize = "11px";
            td10.style.paddingRight = "5px";

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

            tbt.appendChild(row);
        }
    }
}

function Delete_onclick(source) {
   
    var Confm = confirm("Do You want to delete record");
    if (Confm == true) {
        Calender_details.Delete_Agency(source, Delete_Investment_Type_Master);
        Calender_details.Bind_All_Placement(Fill_PlacementDetail);
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
