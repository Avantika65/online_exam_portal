window.onload = init;

var Profile;
function init() {
    
    var ddlProfile = document.getElementById("ddlProfile");
    var ddlProfile1 = ddlProfile.options[ddlProfile.selectedIndex].value;

    Calender_details.Bind_Qualification_value(ddlProfile1, Fill_Quali_details);
//    var progressBar1 = document.getElementById("progressBar1");
//    progressBar1.style.display = "block";
//    Income_Tax_Details.Get_Investment_Type_Master(Fill_Investment_Type_Master);
}

function reset_value1() {
    var ddlEmpTitle = document.getElementById("ddlEmpTitle");
    ddlEmpTitle.options[0].selected = true;
    var ddlProfile = document.getElementById("ddlProfile");
    ddlProfile.options[0].selected = true;
    var txtEmpName = document.getElementById("txtEmpName");
    txtEmpName.value = "";
    var txtLastName = document.getElementById("txtLastName");
    txtLastName.value = "";
    var txtDOB = document.getElementById("txtDOB");
    txtDOB.value = "";
    var txtFatherNm = document.getElementById("txtFatherNm");
    txtFatherNm.value = "";
    var ddlReligion = document.getElementById("ddlReligion");
    ddlReligion.options[0].selected = true;
    var ddlSex = document.getElementById("ddlSex");
    ddlSex.options[0].selected = true;
    var ddlDept = document.getElementById("ddlDept");
    ddlDept.options[0].selected = true;
    var ddlDesig = document.getElementById("ddlDesig");
    ddlDesig.options[0].selected = true;
    var ddlExp = document.getElementById("ddlExp");
    ddlExp.options[0].selected = true;
    var ddlEduc = document.getElementById("ddlEduc");
    ddlEduc.options[0].selected = true;
    var marks = document.getElementById("marks");
    marks.value = "";
    var emailAddress = document.getElementById("emailAddress");
    emailAddress.value = "";
    var Address = document.getElementById("Address");
    Address.value = "";
    var mobileno = document.getElementById("mobileno");
    mobileno.value = "";
}

function Fill_Value() {
    var ddlProfile = document.getElementById("ddlProfile");
    var ddlProfile1 = ddlProfile.options[ddlProfile.selectedIndex].value;
   
    Calender_details.Bind_Qualification_value(ddlProfile1, Fill_Quali_details);
}
function Fill_Quali_details(result) {
    var xml = parseXml(result);
    if (xml) {
        bind_Qualification_dll(xml.documentElement);
    }
}
function bind_Qualification_dll(DistNode) {
    var ddlEduc = document.getElementById("ddlEduc");
    for (var count = ddlEduc.options.length - 1; count > -1; count--) {
        ddlEduc.options[count] = null;
    }
    var val;
    var desc;
    var optionitem;
    val = "0";
    desc = "----Select----"; ;
    optionitem = new Option(desc, val, false, false);
    ddlEduc.options[ddlEduc.length] = optionitem;
    var IdNode = DistNode.getElementsByTagName('qualId');
    var DescNode = DistNode.getElementsByTagName('ProfName');

    for (var count1 = 0; count1 < IdNode.length; count1++) {
        val = GetInnerText(IdNode[count1]);
        desc = GetInnerText(DescNode[count1]);
        optionitem = new Option(desc, val, false, false);
        ddlEduc.options[ddlEduc.length] = optionitem;
    }
    ddlEduc.options[0].selected = true;
}
function Fill_State() {
    var ddlCount = document.getElementById("ddlCount");
    var ddlCount1 = ddlCount.options[ddlCount.selectedIndex].value;
    Calender_details.Bind_State_value(ddlCount1, Fill_State_details);

}
function Fill_State_details(result) {
    var xml = parseXml(result);
    if (xml) {
        bind_State_dll(xml.documentElement);
    }
}
function bind_State_dll(DistNode) {
    var ddlStateL1 = document.getElementById("ddlStateL");
    for (var count = ddlStateL.options.length - 1; count > -1; count--) {
        ddlStateL.options[count] = null;
    }
    var val;
    var desc;
    var optionitem;
    val = "0";
    desc = "----Select----"; ;
    optionitem = new Option(desc, val, false, false);
    ddlStateL.options[ddlStateL.length] = optionitem;
    var IdNode = DistNode.getElementsByTagName('StateId');
    var DescNode = DistNode.getElementsByTagName('StateName');

    for (var count1 = 0; count1 < IdNode.length; count1++) {
        val = GetInnerText(IdNode[count1]);
        desc = GetInnerText(DescNode[count1]);
        optionitem = new Option(desc, val, false, false);
        ddlStateL.options[ddlStateL.length] = optionitem;
    }
    ddlStateL.options[0].selected = true;
}


function Fill_City() {
    var ddlStateL = document.getElementById("ddlStateL");
    var ddlStateL1 = ddlCount.options[ddlStateL.selectedIndex].value;
    Calender_details.Bind_City_value(ddlStateL1, Fill_City_details);

}
function Fill_City_details(result) {
    var xml = parseXml(result);
    if (xml) {
        bind_city_dll(xml.documentElement);
    }
}
function bind_city_dll(DistNode) {
    var ddlCityL = document.getElementById("ddlCityL");
    for (var count = ddlCityL.options.length - 1; count > -1; count--) {
        ddlCityL.options[count] = null;
    }
    var val;
    var desc;
    var optionitem;
    val = "0";
    desc = "----Select----"; ;
    optionitem = new Option(desc, val, false, false);
    ddlCityL.options[ddlCityL.length] = optionitem;
    var IdNode = DistNode.getElementsByTagName('CityId');
    var DescNode = DistNode.getElementsByTagName('CityName');

    for (var count1 = 0; count1 < IdNode.length; count1++) {
        val = GetInnerText(IdNode[count1]);
        desc = GetInnerText(DescNode[count1]);
        optionitem = new Option(desc, val, false, false);
        ddlCityL.options[ddlCityL.length] = optionitem;
    }
    ddlCityL.options[0].selected = true;
}


function Fill_State1() {
    var ddlCountryL0 = document.getElementById("ddlCountryL0");
    var ddlCountryL01 = ddlCount.options[ddlCountryL0.selectedIndex].value;
    Calender_details.Bind_State_value1(ddlCountryL01, Fill_State_details1);

}
function Fill_State_details1(result) {
    var xml = parseXml(result);
    if (xml) {
        bind_State_dll1(xml.documentElement);
       
    }
}
function bind_State_dll1(DistNode) {
    var ddlStateL0 = document.getElementById("ddlStateL0");
    for (var count = ddlStateL0.options.length - 1; count > -1; count--) {
        ddlStateL0.options[count] = null;
    }
    var val;
    var desc;
    var optionitem;
    val = "0";
    desc = "----Select----"; ;
    optionitem = new Option(desc, val, false, false);
    ddlStateL0.options[ddlStateL0.length] = optionitem;
    var IdNode = DistNode.getElementsByTagName('StateId');
    var DescNode = DistNode.getElementsByTagName('StateName');

    for (var count1 = 0; count1 < IdNode.length; count1++) {
        val = GetInnerText(IdNode[count1]);
        desc = GetInnerText(DescNode[count1]);
        optionitem = new Option(desc, val, false, false);
        ddlStateL0.options[ddlStateL0.length] = optionitem;
    }
    ddlStateL0.options[0].selected = true;
}

function Fill_City2() {
    var ddlStateL0 = document.getElementById("ddlStateL0");
    var ddlStateL01 = ddlCount.options[ddlStateL0.selectedIndex].value;
    Calender_details.Bind_City_value1(ddlStateL01, Fill_City_details2);

}
function Fill_City_details2(result) {
    var xml = parseXml(result);
    if (xml) {
        bind_city_dll2(xml.documentElement);
    }
}
function bind_city_dll2(DistNode) {
    var ddlCityL0 = document.getElementById("ddlCityL0");
    for (var count = ddlCityL0.options.length - 1; count > -1; count--) {
        ddlCityL0.options[count] = null;
    }
    var val;
    var desc;
    var optionitem;
    val = "0";
    desc = "----Select----"; ;
    optionitem = new Option(desc, val, false, false);
    ddlCityL0.options[ddlCityL0.length] = optionitem;
    var IdNode = DistNode.getElementsByTagName('CityId');
    var DescNode = DistNode.getElementsByTagName('CityName');

    for (var count1 = 0; count1 < IdNode.length; count1++) {
        val = GetInnerText(IdNode[count1]);
        desc = GetInnerText(DescNode[count1]);
        optionitem = new Option(desc, val, false, false);
        ddlCityL0.options[ddlCityL0.length] = optionitem;
    }
    ddlCityL0.options[0].selected = true;
}


////////////////////////////////////////////////////-----------------------Submit---------------------------------------/////////////////////////////////////
function submit_value1() {
    

    var ddlEmpTitle = document.getElementById("ddlEmpTitle");
    var ddlEmpTitle1 = ddlEmpTitle.options[ddlEmpTitle.selectedIndex].value;
    if (ddlEmpTitle1 == "0") {
        window.alert("Please select Title....");
        ddlEmpTitle.focus();
        return false;
    }        
 var ddlProfile = document.getElementById("ddlProfile");
    var ddlProfile1 = ddlProfile.options[ddlProfile.selectedIndex].value;
    if (ddlProfile1 == "0") {
        window.alert("Please select Job Profile....");
        ddlProfile.focus();
        return false;
    }
    var txtEmpName = document.getElementById("txtEmpName");
    if (txtEmpName.value == "") {
        window.alert("Please Enter Emp Name...");
        txtEmpName.focus();
        return false;
    }
    var txtLastName = document.getElementById("txtLastName");
    if (txtLastName.value == "") {
        window.alert("Please Enter Last Name...");
        txtLastName.focus();
        return false;
    }
    var txtDOB = document.getElementById("txtDOB");
    if (txtDOB.value == "") {
        window.alert("Please Enter Your Date Of Birth...");
        txtDOB.focus();
        return false;
    }
    var txtFatherNm = document.getElementById("txtFatherNm");
    if (txtFatherNm.value == "") {
        window.alert("Please Enter Your Father's Name...");
        txtFatherNm.focus();
        return false;
    }
    var ddlReligion = document.getElementById("ddlReligion");
    var ddlReligion1 = ddlReligion.options[ddlReligion.selectedIndex].value;
    if (ddlReligion1 == "0") {
        window.alert("Please select Religion....");
        ddlReligion.focus();
        return false;
    }        
    var ddlSex = document.getElementById("ddlSex");
    var ddlSex1 = ddlSex.options[ddlSex.selectedIndex].value;
    if (ddlSex1 == "0") {
        window.alert("Please select Gender....");
        ddlSex.focus();
        return false;
    }

    var ddlExp = document.getElementById("ddlExp");
    //var ddlExp1 = ddlExp.options[ddlExp.selectedIndex].value;
    var ddlExp1 = 7;
    if (ddlExp1 == "0") {
        window.alert("Please select Wokr Exp.  ....");
        ddlExp.focus();
        return false;
    }

    var ddlEduc = document.getElementById("ddlEduc");
    var ddlEduc1 = ddlEduc.options[ddlEduc.selectedIndex].value;
    if (ddlEduc1 == "0") {
        window.alert("Please select Last Qualification....");
        ddlEduc.focus();
        return false;
    }
    var marks = document.getElementById("marks");
    if (marks.value == "") {
        window.alert("Please Enter Marks %...");
        marks.focus();
        return false;
        }
    var Path = document.getElementById('lblResumeupload').innerText;
    if (Path == "") {
        window.alert("Please Upload Resume...");
        return false;
    }
    

//-------------------------

     var Address = document.getElementById("txtLocalAdd");
     if (Address.value == "") {
            window.alert("Please Enter Your Address...");
            Address.focus();
            return false;
    }
     var ddlCount = document.getElementById("ddlCount");
    var ddlCount1 = ddlCount.options[ddlCount.selectedIndex].value;
    if (ddlCount1 == "0") {
        window.alert("Please select Country....");
        ddlCount.focus();
        return false;
    }
     var ddlStateL = document.getElementById("ddlStateL");
    var ddlStateL1 = ddlStateL.options[ddlStateL.selectedIndex].value;
    if (ddlStateL1 == "0") {
        window.alert("Please select State....");
        ddlStateL.focus();
        return false;
    }
     var ddlCityL = document.getElementById("ddlCityL");
    var ddlCityL1 = ddlCityL.options[ddlCityL.selectedIndex].value;
    if (ddlCityL1 == "0") {
        window.alert("Please select City....");
        ddlCityL.focus();
        return false;
    }
    var emailAddress = document.getElementById("emailAddress");
    if (emailAddress.value == "") {
        window.alert("Please Enter Your Email-Address...");
        emailAddress.focus();
        return false;
    }
    var mobileno = document.getElementById("txtMobile");
    if (mobileno.value == "") {
        window.alert("Please Enter Your Mobile Number...");
        mobileno.focus();
        return false;
    }
    var Phone_no = document.getElementById("txtPhone");
    if (Phone_no.value == "") {
        window.alert("Please Enter Your Mobile Number...");
        txtPhone.focus();
        return false;
    }
    var zip_code = document.getElementById("txtZipL");
    if (zip_code.value == "") {
        window.alert("Please Enter Your zip code...");
        txtZipL.focus();
        return false;
    }

    //-------------------------LOCAL ADD----------------------

    var L_Address = document.getElementById("txtLocalAdd0");
    if (L_Address.value == "") {
        window.alert("Please Enter Your Address...");
        txtLocalAdd0.focus();
        return false;
    }
      var ddlCountryL0 = document.getElementById("ddlCountryL0");
    var ddlCountryL02 = ddlCountryL0.options[ddlCountryL0.selectedIndex].value;
    if (ddlCountryL02 == "0") {
        window.alert("Please select Country....");
        ddlCountryL0.focus();
        return false;
    }
     var ddlStateL0 = document.getElementById("ddlStateL0");
    var ddlStateL02 = ddlStateL0.options[ddlStateL0.selectedIndex].value;
    if (ddlStateL02 == "0") {
        window.alert("Please select State....");
        ddlStateL0.focus();
        return false;
    }
     var ddlCityL0 = document.getElementById("ddlCityL0");
    var ddlCityL02 = ddlCityL0.options[ddlCityL0.selectedIndex].value;
    if (ddlCityL02 == "0") {
        window.alert("Please select City....");
        ddlCityL0.focus();
        return false;
    }
    var L_emailAddress = document.getElementById("emailAddress0");
    if (L_emailAddress.value == "") {
        window.alert("Please Enter Your Email-Address...");
        emailAddress.focus();
        return false;
    }
    var L_mobileno = document.getElementById("txtMobile0");
    if (L_mobileno.value == "") {
        window.alert("Please Enter Your Mobile Number...");
        mobileno.focus();
        return false;
    }
    var L_Phone_no = document.getElementById("txtPhone0");
    if (L_Phone_no.value == "") {
        window.alert("Please Enter Your Phone No...");
        txtPhone0.focus();
        return false;
    }
    var L_zip_code = document.getElementById("txtZipL0");
    if (L_zip_code.value == "") {
        window.alert("Please Enter Your zip code...");
        txtZipL0.focus();
        return false;
       

    }
    Calender_details.Insert_EmpWalkin_Details(ddlProfile1, txtEmpName.value, txtLastName.value, txtDOB.value, txtFatherNm.value, ddlReligion1, ddlSex1, ddlExp1, ddlEduc1, marks.value,Path, Address.value, ddlCount1, ddlStateL1, ddlCityL1, emailAddress.value, mobileno.value, Phone_no.value, zip_code.value, L_Address.value, ddlCountryL02, ddlStateL02, ddlCityL02, L_emailAddress.value, L_mobileno.value, L_Phone_no.value, L_zip_code.value, fill_Walkin);
}
function fill_Walkin(result) {
    if (result > 0) {
       
        reset_value1();
    }
}

/////////////////////////Filling Grid-------------------------///////////////////////////////


function View_All_Onchange() {
    

    var chk = document.getElementById("chkAll");
    if (chk.checked == true) {
    
        Calender_details.Bind_Emp_Walk_In_Details(Fill_Wlkin_detail);
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


function Fill_Wlkin_detail(result) {
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
    var Emp_WalkIn3 = root.getElementsByTagName("EmpFilterView");
    var title = root.getElementsByTagName("title");
    var Firstname = root.getElementsByTagName("Firstname");
    var Qualification = root.getElementsByTagName("Qualification");
    var fatherName = root.getElementsByTagName("fatherName");
    var DOB = root.getElementsByTagName("DOB");
    var Exp = root.getElementsByTagName("Exp");
    var Email = root.getElementsByTagName("Email");
    var Address = root.getElementsByTagName("Address");
    var Mobileno = root.getElementsByTagName("Mobileno");
   
    var tbt = document.createElement("TBODY");
    element.appendChild(tbt);
  
    if (Emp_WalkIn3.length != 0) {

        var headerRow = document.createElement("TR");
        var th1 = document.createElement("TH");
        th1.appendChild(document.createTextNode("Job Title"));
        th1.style.height = "30px";
        th1.style.fontSize = "11px";
        th1.style.textAlign = "center";
        th1.style.width = "10%";

        var th2 = document.createElement("TH");
        th2.appendChild(document.createTextNode("First Name"));
        th2.style.height = "30px";
        th2.style.fontSize = "11px";
        th2.style.textAlign = "center";
        th2.style.width = "12%";

        var th3 = document.createElement("TH");
        th3.appendChild(document.createTextNode("Qualification"));
        th3.style.height = "30px";
        th3.style.fontSize = "11px";
        th3.style.textAlign = "center";
        th3.style.width = "10%";

        var th4 = document.createElement("TH");
        th4.appendChild(document.createTextNode("Father's Name"));
        th4.style.height = "30px";
        th4.style.fontSize = "11px";
        th4.style.textAlign = "center";
        th4.style.width = "10%";

        var th5 = document.createElement("TH");
        th5.appendChild(document.createTextNode("Date Of Birth"));
        th5.style.height = "30px";
        th5.style.fontSize = "11px";
        th5.style.textAlign = "center";
        th5.style.width = "10%";

        var th6 = document.createElement("TH");
        th6.appendChild(document.createTextNode("Work Experience(in years)"));
        th6.style.height = "30px";
        th6.style.fontSize = "11px";
        th6.style.textAlign = "center";
        th6.style.width = "13%";

        var th7 = document.createElement("TH");
        th7.appendChild(document.createTextNode("Email Address"));
        th7.style.height = "30px";
        th7.style.fontSize = "11px";
        th7.style.textAlign = "center";
        th7.style.width = "10%";

        var th8 = document.createElement("TH");
        th8.appendChild(document.createTextNode("Permanent Address"));
        th8.style.height = "30px";
        th8.style.fontSize = "11px";
        th8.style.textAlign = "center";
        th8.style.width = "10%";

        var th9 = document.createElement("TH");
        th9.appendChild(document.createTextNode("Mobile Number"));
        th9.style.height = "30px";
        th9.style.fontSize = "11px";
        th9.style.textAlign = "center";
        th9.style.width = "10%";

        headerRow.appendChild(th1);
        headerRow.appendChild(th2);
        headerRow.appendChild(th3);
        headerRow.appendChild(th4);
        headerRow.appendChild(th5);
        headerRow.appendChild(th6);
        headerRow.appendChild(th7);
        headerRow.appendChild(th8);
        headerRow.appendChild(th9);

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
    if (Emp_WalkIn3.length > 0) {

        for (var x = 0; x < Emp_WalkIn3.length; x++) {
            var row = document.createElement("TR");
            var rid = "rc" + x;
            row.setAttribute('id', rid); 

            var title1 = GetInnerText(title[x]);
            var Firstname1 = GetInnerText(Firstname[x]);
            var Qualification1 = GetInnerText(Qualification[x]);
            var fatherName1 = GetInnerText(fatherName[x]);
            var DOB1 = GetInnerText(DOB[x]);
            var Exp1 = GetInnerText(Exp[x]);
            var Email1 = GetInnerText(Email[x]);
            var Address1 = GetInnerText(Address[x]);
            var Mobileno1 = GetInnerText(Mobileno[x]);
           

            var td1 = document.createElement("TD");
            td1.appendChild(document.createTextNode(title1));
            td1.style.width = "10%";
            td1.style.textAlign = "left";
            td1.style.fontSize = "11px";
            td1.style.paddingLeft = "5px";

            var td2 = document.createElement("TD");
            td2.appendChild(document.createTextNode(Firstname1));
            td2.style.width = "10%";
            td2.style.textAlign = "left";
            td2.style.fontSize = "11px";
            td2.style.paddingLeft = "5px";

            var td3 = document.createElement("TD");
            td3.appendChild(document.createTextNode(Qualification1));
            td3.style.width = "10%";
            td3.style.textAlign = "left";
            td3.style.fontSize = "11px";
            td3.style.paddingLeft = "5px";       


            var td4 = document.createElement("TD");
            td4.appendChild(document.createTextNode(fatherName1));
            td4.style.width = "10%";
            td4.style.textAlign = "left";
            td4.style.fontSize = "11px";
            td4.style.paddingRight = "5px";

            var td5 = document.createElement("TD");
            td5.appendChild(document.createTextNode(DOB1));
            td5.style.width = "10%";
            td5.style.textAlign = "left";
            td5.style.fontSize = "11px";
            td5.style.paddingRight = "5px";

            var td6 = document.createElement("TD");
            td6.appendChild(document.createTextNode(Exp1));
            td6.style.width = "10%";
            td6.style.textAlign = "left";
            td6.style.fontSize = "11px";
            td6.style.paddingRight = "5px";

            var td7 = document.createElement("TD");
            td7.appendChild(document.createTextNode(Email1));
            td7.style.width = "10%";
            td7.style.textAlign = "left";
            td7.style.fontSize = "11px";
            td7.style.paddingRight = "5px";

            var td8 = document.createElement("TD");
            td8.appendChild(document.createTextNode(Address1));
            td8.style.width = "10%";
            td8.style.textAlign = "left";
            td8.style.fontSize = "11px";
            td8.style.paddingRight = "5px";
          
            var td9 = document.createElement("TD");
            td9.appendChild(document.createTextNode(Mobileno1));
            td9.style.width = "10%";
            td9.style.textAlign = "left";
            td9.style.fontSize = "11px";
            td9.style.paddingRight = "5px";

            row.appendChild(td1);
            row.appendChild(td2);
            row.appendChild(td3);
            row.appendChild(td4);
            row.appendChild(td5);
            row.appendChild(td6);
            row.appendChild(td7);
            row.appendChild(td8);
            row.appendChild(td9);

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
