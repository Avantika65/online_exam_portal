function reset_value1() {
    var ddlDept = document.getElementById("ddlDept");
    ddlDept.options[0].selected = true;
    var txtTitle = document.getElementById("txtTitle");
    txtTitle.value = "";
    var TextBox1 = document.getElementById("TextBox1");
    TextBox1.value = "";
    var txtResp = document.getElementById("txtResp");
    txtResp.value = "";
    var txtTExp = document.getElementById("txtTExp");
    txtTExp.value = "";
    var txtFromExp = document.getElementById("txtFromExp");
    txtFromExp.value = "";
    var txtVac = document.getElementById("txtVac");
    txtVac.value = "";
    var txtDateA = document.getElementById("txtDateA");
    txtDateA.value = "";
    var txtDateL = document.getElementById("txtDateL");
    txtDateL.value = "";
    var chkQual = document.getElementById("chkQual");
    chkQual.checked = false;
    var txtPerc = document.getElementById("txtPerc");
    txtPerc.value = "";
    var ChkSkill = document.getElementById("ChkSkill");
    ChkSkill.checked = false;
    var ddlDesig = document.getElementById("ddlDesig");
    ddlDesig.options[0].selected = true;
    var ddlGrade = document.getElementById("ddlGrade");
    ddlGrade.options[0].selected = true;
    var ddlGrade0 = document.getElementById("ddlGrade0");
    ddlGrade0.options[0].selected = true;
    var element = document.getElementById("xGrid1");
    var trt = element.getElementsByTagName("TR");
    var lnt = trt.length;
    for (var i = 0; i < trt.length; i++) {
        element.deleteRow(i);
        lnt--;
        i--;
    }
}

//////////////////////////////////////////// Submit/////////////////////////


function submit_value1() {
    var txtTitle = document.getElementById("txtTitle");
    if (txtTitle.value == "") {
        window.alert("Please Enter Job Profile Name...");
        txtTitle.focus();
        return false;
    }
   
    var ddlDept = document.getElementById("ddlDept");
    var SelValueDept = ddlDept.options[ddlDept.selectedIndex].value;
    if (SelValueDept == "0") {
        window.alert("Please select Department....");
        ddlDept.focus();
        return false;
    }
    var ddlDesig = document.getElementById("ddlDesig");
    var SelValueDesig = ddlDesig.options[ddlDesig.selectedIndex].value;
    if (SelValueDesig == "0") {
        window.alert("Please select Designation....");
        ddlDesig.focus();
        return false;
    }
    var ddlGrade = document.getElementById("ddlGrade");
    var SelValueGrade = ddlGrade.options[ddlGrade.selectedIndex].value;
    if (SelValueGrade == "0") {
        window.alert("Please Declare Salary From....");
        ddlGrade.focus();
        return false;
    }

    var ddlGrade0 = document.getElementById("ddlGrade0");
    var SelValue0 = ddlGrade0.options[ddlGrade0.selectedIndex].value;
    if (SelValue0 == "0") {
        window.alert("Please Declare Salary To....");
        ddlGrade0.focus();
        return false;
    }

    var TextBox1 = document.getElementById("TextBox1");
    if (TextBox1.value == "") {
        window.alert("Define Maximum Age...");
        TextBox1.focus();
        return false;
    }
    var txtResp = document.getElementById("txtResp");
    if (txtResp.value == "") {
        window.alert("Please Enter Job Responsibility...");
        txtResp.focus();
        return false;
    }
    var txtTExp = document.getElementById("txtTExp");
    if (txtTExp.value == "") {
        window.alert("Please Enter Min Experience.....");
        txtTExp.focus();
        return false;
    }
    var txtFromExp = document.getElementById("txtFromExp");
    if (txtFromExp.value == "") {
        window.alert("Please Enter Max Experience...");
        txtFromExp.focus();
        return false;
    } 
    var txtVac = document.getElementById("txtVac");
    if (txtVac.value == "") {
        window.alert("Please Enter Total Vacancy...");
        txtVac.focus();
        return false;
    }
    var txtDateA = document.getElementById("txtDateA");
    if (txtDateA.value == "") {
        window.alert("Please Enter Start Date ...");
        txtDateA.focus();
        return false;
    }
    var txtDateL = document.getElementById("txtDateL");
    if (txtDateL.value == "") {
        window.alert("Please Enter End Date...");
        txtDateL.focus();
        return false;
    }
    var ddlqua = document.getElementById("ddlqua");
    var SelValueddlqua = ddlqua.options[ddlqua.selectedIndex].value;
    if (SelValueddlqua == "0") {
        window.alert("Please Declare Last Qualification....");
        ddlqua.focus();
        return false;
    }
     var txtPerc = document.getElementById("txtPerc");
     if (txtPerc.value == "") {
         window.alert("Please Enter Min Marks %...");
         txtPerc.focus();
         return false;
     }
     var val = "";
     var skill = document.getElementById("ChkSkill");
     var radio = skill.getElementsByTagName("input");
     for (var i = 0; i < radio.length; i++) {
         if (radio[i].checked == true) {
             val = val + radio[i].value + ',';
         }
     }
     
     var valuelbl = "df";
     var valuetxt = "cc";
     var grid = document.getElementById("grdOrderUpdate");
     var rows = grid.getElementsByTagName('tr');
     for (var x = 0; x < rows.length; x++) {
         var td = rows[x].cells[0].getElementsByTagName('input');
         var td1 = rows[x].cells[1].getElementsByTagName('span');
          
                 //valuelbl = valuelbl + td[x].innerHTML + ',';
                 
             }
         
     
//     var chk = grid.getElementsByTagName("input");
//     var lbll = grid.getElementsByTagName("span");
//     for (var i = 0; i < chk.length; i++) {
//         if (chk[i].type == "text") {
//             if (chk[i].value != "") {
//                 valuelbl = valuelbl + lbll[i].innerHTML + ',';
//                 valuetxt = valuetxt + chk[i].value + ',';
//             }
//         }
//     }

     Calender_details.Add_Vacancy(txtTitle.value, SelValueDept, SelValueDesig, SelValueGrade, SelValue0, TextBox1.value, txtResp.value, txtTExp.value, txtFromExp.value, txtVac.value, txtDateA.value, txtDateL.value, SelValueddlqua, txtPerc.value, status, val, valuelbl, valuetxt, Fill_Vacancy);
}
function Fill_Vacancy(result) {
    if (result > 0) {
        reset_value1();
    }
}






function Fill_Designation(){
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

//////////////////////////////////////////////checkbox////////////////////////////
function View_All_Onchange() {

    var chk = document.getElementById("chkAll");
    if (chk.checked == true) {
        Calender_details.Bind_Vacancy_Details(View_All_Vanancy_Detail);
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

function View_All_Vanancy_Detail(result) {
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
    var Add_vacancy = root.getElementsByTagName("Add_vacancy");
    var jobCode = root.getElementsByTagName("jobCode");
    var title = root.getElementsByTagName("title");
    var Designation = root.getElementsByTagName("Designation");
    var DepartmentName = root.getElementsByTagName("DepartmentName");
    var Salary_From = root.getElementsByTagName("Salary_From");
    var Salary_To = root.getElementsByTagName("Salary_To");
    var Min_Exper = root.getElementsByTagName("Min_Exper");
    var responsibility = root.getElementsByTagName("responsibility");
    var tVacancy = root.getElementsByTagName("tVacancy");
    var aDate = root.getElementsByTagName("aDate");
    var lDate = root.getElementsByTagName("lDate");
    var percentage = root.getElementsByTagName("percentage");
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
        th2.appendChild(document.createTextNode("Job Title"));
        th2.style.height = "25px";
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
        th5.appendChild(document.createTextNode("Salary From(in Rs)"));
        th5.style.height = "30px";
        th5.style.fontSize = "11px";
        th5.style.textAlign = "center";
        th5.style.width = "10%";

        var th6 = document.createElement("TH");
        th6.appendChild(document.createTextNode("Salary To(in Rs)"));
        th6.style.height = "30px";
        th6.style.fontSize = "11px";
        th6.style.textAlign = "center";
        th6.style.width = "10%";

        var th7 = document.createElement("TH");
        th7.appendChild(document.createTextNode("Min Experience"));
        th7.style.height = "30px";
        th7.style.fontSize = "11px";
        th7.style.textAlign = "center";
        th7.style.width = "10%";

        var th8 = document.createElement("TH");
        th8.appendChild(document.createTextNode("Responsibility"));
        th8.style.height = "30px";
        th8.style.fontSize = "11px";
        th8.style.textAlign = "center";
        th8.style.width = "10%";

        var th9 = document.createElement("TH");
        th9.appendChild(document.createTextNode("Total Vacancy"));
        th9.style.height = "30px";
        th9.style.fontSize = "11px";
        th9.style.textAlign = "center";
        th9.style.width = "10%";

        var th10 = document.createElement("TH");
        th10.appendChild(document.createTextNode("Start Date"));
        th10.style.height = "30px";
        th10.style.fontSize = "11px";
        th10.style.textAlign = "center";
        th10.style.width = "10%";

        var th11 = document.createElement("TH");
        th11.appendChild(document.createTextNode("End Date"));
        th11.style.height = "30px";
        th11.style.fontSize = "11px";
        th11.style.textAlign = "center";
        th11.style.width = "10%";

        var th12 = document.createElement("TH");
        th12.appendChild(document.createTextNode("Min Percentage"));
        th12.style.height = "30px";
        th12.style.fontSize = "11px";
        th12.style.textAlign = "center";
        th12.style.width = "10%";

        var th13 = document.createElement("TH");
        th13.appendChild(document.createTextNode("Delete"));
        th13.style.height = "30px";
        th13.style.fontSize = "11px";
        th13.style.textAlign = "center";
        th13.style.width = "10%";

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
        headerRow.appendChild(th12);
        headerRow.appendChild(th13);


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

            var jobCode1 = GetInnerText(jobCode[x]);
            var title1 = GetInnerText(title[x]);
            var Designation1 = GetInnerText(Designation[x]);
            var DepartmentName1 = GetInnerText(DepartmentName[x]);
            var Salary_From1 = GetInnerText(Salary_From[x]);
            var Salary_To1 = GetInnerText(Salary_To[x]);
            var Min_Exper1 = GetInnerText(Min_Exper[x]);
            var responsibility1 = GetInnerText(responsibility[x]);
            var tVacancy1 = GetInnerText(tVacancy[x]);
            var aDate1 = GetInnerText(aDate[x]);
            var lDate1 = GetInnerText(lDate[x]);
            var percentage1 = GetInnerText(percentage[x]);

            var td1 = document.createElement("TD");
            td1.appendChild(document.createTextNode(jobCode1));
            td1.style.width = "10%";
            td1.style.textAlign = "left";
            td1.style.fontSize = "11px";
            td1.style.paddingLeft = "5px";

            var td2 = document.createElement("TD");
            td2.appendChild(document.createTextNode(title1));
            td2.style.width = "15%";
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
            td5.appendChild(document.createTextNode(Salary_From1));
            td5.style.width = "10%";
            td5.style.textAlign = "left";
            td5.style.fontSize = "11px";
            td5.style.paddingLeft = "5px";

            var td6 = document.createElement("TD");
            td6.appendChild(document.createTextNode(Salary_To1));
            td6.style.width = "20%";
            td6.style.textAlign = "left";
            td6.style.fontSize = "11px";
            td6.style.paddingLeft = "5px";

            var td7 = document.createElement("TD");
            td7.appendChild(document.createTextNode(Min_Exper1));
            td7.style.width = "10%";
            td7.style.textAlign = "left";
            td7.style.fontSize = "11px";
            td7.style.paddingLeft = "5px";

            var td8 = document.createElement("TD");
            td8.appendChild(document.createTextNode(responsibility1));
            td8.style.width = "10%";
            td8.style.textAlign = "left";
            td8.style.fontSize = "11px";
            td8.style.paddingRight = "5px";

            var td9 = document.createElement("TD");
            td9.appendChild(document.createTextNode(tVacancy1));
            td9.style.width = "10%";
            td9.style.textAlign = "left";
            td9.style.fontSize = "11px";
            td9.style.paddingLeft = "5px";

            var td10 = document.createElement("TD");
            td10.appendChild(document.createTextNode(aDate1));
            td10.style.width = "20%";
            td10.style.textAlign = "left";
            td10.style.fontSize = "11px";
            td10.style.paddingLeft = "5px";

            var td11 = document.createElement("TD");
            td11.appendChild(document.createTextNode(lDate1));
            td11.style.width = "10%";
            td11.style.textAlign = "left";
            td11.style.fontSize = "11px";
            td11.style.paddingLeft = "5px";

            var td12 = document.createElement("TD");
            td12.appendChild(document.createTextNode(percentage1));
            td12.style.width = "10%";
            td12.style.textAlign = "left";
            td12.style.fontSize = "11px";
            td12.style.paddingRight = "5px";


            var img3 = document.createElement('img');
            img3.style.cursor = "pointer";
            img3.src = "../images/dash_remove_icon.png";
            img3.style.height = "25px";
            img3.style.width = "25px";
            //img3.setAttribute('id', 'img9' + rid);
            img3.setAttribute("onclick", "Delete_onclick('" + jobCode1 + "');");
            img3.style.display = "block";

            var td13 = document.createElement("TD");
            td13.appendChild(img3);
            td13.style.width = "50%";
            td13.style.textAlign = "Center";
            td13.style.fontSize = "11px";

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
            row.appendChild(td12);
            row.appendChild(td13);

            tbt.appendChild(row);
        }
    }
}


function Delete_onclick(source) {
    
    var Confm = confirm("Do You want to delete record");
    if (Confm == true) {
        Calender_details.Delete_Vacancy(source, Delete_Investment_Type_Master);
        Calender_details.Bind_Vacancy_Details(View_All_Vanancy_Detail);
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
