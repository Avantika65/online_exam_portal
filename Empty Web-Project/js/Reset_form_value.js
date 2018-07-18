var prevrow = "rc0";
var del_id = "";
var inserted_row_id = "0";
var empidvalue;
var employee_code;
var empidinserted;

function showUploadConfirmation() {
    clearContents();
}

function clearContents() {
    var AsyncFileUpload = document.getElementById("AsyncFileUpload1");
    var txts = AsyncFileUpload.getElementsByTagName("input");
    for (var i = 0; i < txts.length; i++) {
        if (txts[i].type == "text") {
            txts[i].value = "";
            txts[i].style.backgroundColor = "white";
        }
    }
}

function reset_value1() {
  var ddlEmpTitle = document.getElementById("ddlEmpTitle");
    ddlEmpTitle.options[0].selected=true;
    var empnam = document.getElementById("txtEmpID");
    empnam.value = "";
    var txtEmpName = document.getElementById("txtEmpName");
     txtEmpName.value="";
    var emplastnm = document.getElementById("txtLastName");
    emplastnm.value = "";
    var txtMobL = document.getElementById("txtMobL");
    txtMobL.value = "";
    var txtEmailL = document.getElementById("txtEmailL");
    txtEmailL.value = "";
    var ddlEmpCat = document.getElementById("ddlEmpCat");
    ddlEmpCat.options[0].selected = true;
}

function submit_value1() {
    var ddlEmpTitle = document.getElementById("ddlEmpTitle");
    var SelValue = ddlEmpTitle.options[ddlEmpTitle.selectedIndex].value;
    if (SelValue == "0") {
        window.alert("Employee Title must not be null.");
        ddlEmpTitle.focus();
        return false;
    }

    var txtEmpName = document.getElementById("txtEmpName");
    if (txtEmpName.value == "") {
        window.alert("First Name must not be null.");
        txtEmpName.focus();
        return false;
    }

    var txtMobL = document.getElementById("txtMobL");
    if (txtMobL.value == "") {
        window.alert("Mobile Number must not be null.");
        txtMobL.focus();
        return false;
    }
    if (txtMobL.value.length != 10) {
        window.alert("Enter Valid Mobile Number");
        txtMobL.value = "";
        txtMobL.focus();
        return false;
    }
    var value = Number(txtMobL.value);
    if (Math.floor(value) != value) {
        window.alert("Mobile Number must not be string.");
        txtMobL.value = "";
        txtMobL.focus();
        return false;
    }

    var txtEmailL = document.getElementById("txtEmailL");
    if (txtEmailL.value != "")
     {
          var reg = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
          if (reg.test(txtEmailL.value) == false) {
              window.alert("Enter Valid Email Id.");
              txtEmailL.value = "";
              txtEmailL.focus();
              return false;
     }

    }

    var ddlEmpCat = document.getElementById("ddlEmpCat");
    var SelValue1 = ddlEmpCat.options[ddlEmpCat.selectedIndex].value;
    var SelValue2 = ddlEmpCat.options[ddlEmpCat.selectedIndex].text;
    if (SelValue1 == "0") {
        window.alert("Select Employee Category.");
        ddlEmpCat.value = "";
        ddlEmpCat.focus();
        return false;
    }
    var Offerid = document.getElementById("lblOfferLetterID");
    var OfferletterID = Offerid.innerText;
    OfferletterID = Offerid.textContent;
    var emplastnm = document.getElementById("txtLastName");
    Calender_details.Insert_Employee_Details(txtEmpName.value, emplastnm.value, txtMobL.value, txtEmailL.value, SelValue, SelValue2, OfferletterID, Fill_emplyee_details_bind);
}

function Fill_emplyee_details_bind(result) {

    if (result > 0) {
        empidvalue = Number(result);
        var empprofile1 = document.getElementById("empprofile1");
        var profile1 = document.getElementById("profile1");
        profile1.style.borderColor = "#868A08";
        profile1.style.backgroundColor = "#D7DF01";
        profile1.style.color = "#8A0808";
        var profileline1 = document.getElementById("profileline1");
        profileline1.style.borderColor = "#868A08";
        profileline1.style.backgroundColor = "#D7DF01";
        empprofile1.style.display = "none";
        var empprofile2 = document.getElementById("empprofile2");
        empprofile2.style.display = "block";
        var Div6 = document.getElementById("Div6");
        Div6.style.display = "none";
        var Div7 = document.getElementById("Div7");
        Div7.style.display = "none";
        var Div8 = document.getElementById("Div8");
        Div8.style.display = "none";
        var sv1 = document.getElementById("sv1");
        sv1.style.display = "none";
        var rs2 = document.getElementById("rs2");
        rs2.style.display = "none";
        //Calender_details.Bindcontrol_profile(result, Fill_emplyee_details_control);
    }
}

function submit_value2() {

    var txtFatherNm = document.getElementById("txtFatherNm");
    if (txtFatherNm.value == "") {
        window.alert("Father Name must not be null.");
        txtFatherNm.focus();
        return false;
    }
    var txtMotherNm = document.getElementById("Txt_Motnhername");
    if (txtMotherNm.value == "") {
        window.alert("Mother Name must not be null.");
        txtMotherNm.focus();
        return false;
    }

    var txtDOB = document.getElementById("txtDOB");
    if (txtDOB.value == "") {
        window.alert("Date Of Birth must not be null.");
        txtDOB.focus();
        return false;
    }

    var ddlSex = document.getElementById("ddlSex");
    var SelValue = ddlSex.options[ddlSex.selectedIndex].value;
    if (SelValue == "0") {
        window.alert("Gender must not be null.");
        ddlSex.focus();
        return false;

    }
    var ddlReligion = document.getElementById("ddlReligion");
    var SelValue1 = ddlReligion.options[ddlReligion.selectedIndex].value;
    if (SelValue1 == "0") {
        window.alert("Religion must not be null.");
        ddlReligion.focus();
        return false;

    }
    var ddlMartStatus = document.getElementById("ddlMartStatus");
    var SelValue2 = ddlMartStatus.options[ddlMartStatus.selectedIndex].value;
    if (SelValue2 == "0") {
        window.alert("Marital Status must not be null.");
        ddlMartStatus.focus();
        return false;

    }
    var ddlNationality = document.getElementById("ddlNationality");
    var SelValue3 = ddlNationality.options[ddlNationality.selectedIndex].value;
    if (SelValue3 == "0") {
        window.alert("Nationality must not be null.");
        ddlNationality.focus();
        return false;
    }

    var ddlBloodGrp = document.getElementById("ddlBloodGrp");
    var SelValue10 = ddlBloodGrp.options[ddlBloodGrp.selectedIndex].value;
    var txtSpouse = document.getElementById("txtSpouse");
    var txtPan = document.getElementById("txtPan");

    Calender_details.update_Employee_Details_personal(empidvalue, SelValue10, txtFatherNm.value, txtDOB.value, SelValue, SelValue1, SelValue2, SelValue3,txtSpouse.value,txtMotherNm.value,txtPan.value, Fill_emplyee_details_bind_personal);
}
    
function Fill_emplyee_details_bind_personal(result) {
    if (result > 0) {
        var empprofile1 = document.getElementById("empprofile1");
        var profile1 = document.getElementById("profile1");
        profile1.style.borderColor = "#868A08";
        profile1.style.backgroundColor = "#D7DF01";
        profile1.style.color = "#8A0808";
        var profile2 = document.getElementById("Profile2");
        profile2.style.borderColor = "#868A08";
        profile2.style.backgroundColor = "#D7DF01";
        profile2.style.color = "#8A0808";
        var profileline1 = document.getElementById("profileline1");
        profileline1.style.borderColor = "#868A08";
        profileline1.style.backgroundColor = "#D7DF01";
        var Div1 = document.getElementById("Div1");
        Div1.style.borderColor = "#868A08";
        Div1.style.backgroundColor = "#D7DF01";
        empprofile1.style.display = "none";
        var empprofile2 = document.getElementById("empprofile2");
        empprofile2.style.display = "none";
        var Div6 = document.getElementById("Div6");
        Div6.style.display = "block";
        var Div7 = document.getElementById("Div7");
        Div7.style.display = "none";
        var Div8 = document.getElementById("Div8");
        Div8.style.display = "none";
        var sv1 = document.getElementById("sv1");
        sv1.style.display = "none";
        var rs2 = document.getElementById("rs2");
        rs2.style.display = "none";
        var sv2 = document.getElementById("sv2");
        sv2.style.display = "none";
        var rs3 = document.getElementById("rs3");
        rs3.style.display = "none";
        var sub_val1 = document.getElementById("sub_val1");
        sub_val1.style.display = "none";
        
    }
}

function reset_value2() {
    var txtFatherNm = document.getElementById("txtFatherNm");
    txtFatherNm.value = "";
    var ddlSex = document.getElementById("ddlSex");
    ddlSex.options[0].selected = true;
    var ddlReligion = document.getElementById("ddlReligion");
    ddlReligion.options[0].selected = true;
    var ddlMartStatus = document.getElementById("ddlMartStatus");
    ddlMartStatus.options[0].selected = true;
    var ddlNationality = document.getElementById("ddlNationality");
    ddlNationality.options[0].selected = true;
    var txtSpouse = document.getElementById("txtSpouse");
    txtSpouse.value = "";
}

function submit_value3() {
    var txtWEDAcademic = document.getElementById("txtWEDAcademic");
    if (txtWEDAcademic.value == "") {
        window.alert("W.E.D must not be null.");
        txtWEDAcademic.focus();
        return false;
    }

    var ddl_qulification = document.getElementById("ddl_qulification");
    var SelValue3 = ddl_qulification.options[ddl_qulification.selectedIndex].value;
    var SelValue5 = ddl_qulification.options[ddl_qulification.selectedIndex].text;
    if (SelValue3 == "0") {
        window.alert("Qualification must not be null.");
        ddl_qulification.focus();
        return false;
    }
    var TxtCourse = document.getElementById("TxtCourse");
    if (TxtCourse.value == "") {
        window.alert("Stream / Course must not be null.");
        TxtCourse.focus();
        return false;
    }

    var TxtUni = document.getElementById("TxtUni");
    if (TxtUni.value == "") {
        window.alert("Board / University must not be null.");
        TxtUni.focus();
        return false;
    }
    var TxtYP = document.getElementById("TxtYP");
    if (TxtYP.value == "") {
        window.alert("Year of Passing must not be null.");
        TxtYP.focus();
        return false;
    }
    var TxtPer = document.getElementById("TxtPer");
    var TxtGrade = document.getElementById("TxtGrade");
    var image = "";
    Calender_details.Insert_Employee_academic_Details(empidvalue, txtWEDAcademic.value, TxtCourse.value, TxtUni.value, TxtYP.value, TxtPer.value, TxtGrade.value, image, SelValue5, Fill_emplyee_details_bind_academic);

}

function Fill_emplyee_details_bind_academic(result) {
    if (result == 'Record Saved successfully.') {
        Calender_details.Get_Employee_academic_Details(empidvalue, Get_emplyee_details_bind_academic);
    }
    else {
        window.alert(result);
    }
}

function Get_emplyee_details_bind_academic(result) {
    var sub_val1 = document.getElementById("sub_val1");
    var grid = document.getElementById("grid");
    grid.innerHTML = result;
    var txtWEDAcademic = document.getElementById("txtWEDAcademic");
    txtWEDAcademic.value = "";
    txtWEDAcademic.focus();
    var TxtPer = document.getElementById("TxtPer");
    TxtPer.value = "";
    var TxtGrade = document.getElementById("TxtGrade");
    TxtGrade.value = "";
    var ddl_qulification = document.getElementById("ddl_qulification");
    ddl_qulification.options[0].selected = true;
    var TxtCourse = document.getElementById("TxtCourse");
    TxtCourse.value = "";
    var TxtYP = document.getElementById("TxtYP");
    TxtYP.value = "";
    var TxtUni = document.getElementById("TxtUni");
    TxtUni.value = "";
    sub_val1.style.display = "block";
}


function submit_value4() {
    Calender_details.update_Employee_academic_save(empidvalue, update_emplyee_academic);
}

function update_emplyee_academic(result) {

    if (result > 0) {
        var empprofile1 = document.getElementById("empprofile1");
        empprofile1.style.display = "none";
        var profile1 = document.getElementById("profile1");
        profile1.style.borderColor = "#868A08";
        profile1.style.backgroundColor = "#D7DF01";
        profile1.style.color = "#8A0808";
        var profile2 = document.getElementById("Profile2");
        profile2.style.borderColor = "#868A08";
        profile2.style.backgroundColor = "#D7DF01";
        profile2.style.color = "#8A0808";
        var profileline1 = document.getElementById("profileline1");
        profileline1.style.borderColor = "#868A08";
        profileline1.style.backgroundColor = "#D7DF01";
        var Div1 = document.getElementById("Div1");
        Div1.style.borderColor = "#868A08";
        Div1.style.backgroundColor = "#D7DF01";
        var profile3 = document.getElementById("profile3");
        profile3.style.borderColor = "#868A08";
        profile3.style.backgroundColor = "#D7DF01";
        profile3.style.color = "#8A0808";
        var Div2 = document.getElementById("Div2");
        Div2.style.borderColor = "#868A08";
        Div2.style.backgroundColor = "#D7DF01";
        var empprofile2 = document.getElementById("empprofile2");
        empprofile2.style.display = "none";
        var Div6 = document.getElementById("Div6");
        Div6.style.display = "none";
        var Div7 = document.getElementById("Div7");
        Div7.style.display = "block";
        var Div8 = document.getElementById("Div8");
        Div8.style.display = "none";
        var sv1 = document.getElementById("sv1");
        sv1.style.display = "none";
        var rs2 = document.getElementById("rs2");
        rs2.style.display = "none";
        var sv2 = document.getElementById("sv2");
        sv2.style.display = "none";
        var rs3 = document.getElementById("rs3");
        rs3.style.display = "none";
        var academic_sv1 = document.getElementById("academic_sv1");
        academic_sv1.style.display = "none";
        var academic_rs1 = document.getElementById("academic_rs1");
        academic_rs1.style.display = "none";
        var sub_val1 = document.getElementById("sub_val1");
        sub_val1.style.display = "none";
    }
}


function reset_value3() {
    var txtWEDAcademic = document.getElementById("txtWEDAcademic");
    txtWEDAcademic.value = "";
    var ddl_qulification = document.getElementById("ddl_qulification");
    ddl_qulification.options[0].selected = true;
    var TxtCourse = document.getElementById("TxtCourse");
    TxtCourse.value = "";
    var TxtUni = document.getElementById("TxtUni");
    TxtUni.value = "";
    var TxtYP = document.getElementById("TxtYP");
    TxtYP.value = "";
}

function submit_value5() {
    var ddl_year = document.getElementById("ddl_year");
    var SelValue3 = ddl_year.options[ddl_year.selectedIndex].value;
    if (SelValue3 == "0") {
        window.alert("Year must not be null.");
        ddl_qulification.focus();
        return false;
    }

    var ddl_month = document.getElementById("ddl_month");
    var SelValue4 = ddl_month.options[ddl_month.selectedIndex].value;
    if (SelValue4 == "0") {
        window.alert("Month must not be null.");
        ddl_month.focus();
        return false;
    }

    var txt_key_skill = document.getElementById("txt_key_skill");
    if (txt_key_skill.value == "") {
        window.alert("Key Skill must not be null.");
        txt_key_skill.focus();
        return false;
    }

    var txt_headline = document.getElementById("txt_headline");
    if (txt_headline.value == "") {
        window.alert("Profile Headline must not be null.");
        txt_headline.focus();
        return false;
    }

    var ddl_industry = document.getElementById("ddl_industry");
    var SelValue5 = ddl_industry.options[ddl_industry.selectedIndex].value;
    if (SelValue5 == "0") {
        window.alert("Company Industry must not be null.");
        ddl_month.focus();
        return false;
    }

    var ddl_function = document.getElementById("ddl_function");
    var SelValue6 = ddl_function.options[ddl_function.selectedIndex].value;
    if (SelValue6 == "0") {
        window.alert("Functional Area must not be null.");
        ddl_month.focus();
        return false;
    }
    var image = "";
    Calender_details.insert_Employee_Details_exeperience(empidvalue, txt_key_skill.value, txt_headline.value, SelValue5, SelValue6, image, SelValue3, SelValue4, Fill_emplyee_details_bind_exeperience);
}

function Fill_emplyee_details_bind_exeperience(result) {
    if (result == 'Record Saved successfully.') {
        var empprofile1 = document.getElementById("empprofile1");
        empprofile1.style.display = "none";
        var profile1 = document.getElementById("profile1");
        profile1.style.borderColor = "#868A08";
        profile1.style.backgroundColor = "#D7DF01";
        profile1.style.color = "#8A0808";
        var profile2 = document.getElementById("Profile2");
        profile2.style.borderColor = "#868A08";
        profile2.style.backgroundColor = "#D7DF01";
        profile2.style.color = "#8A0808";
        var profileline1 = document.getElementById("profileline1");
        profileline1.style.borderColor = "#868A08";
        profileline1.style.backgroundColor = "#D7DF01";
        var Div1 = document.getElementById("Div1");
        Div1.style.borderColor = "#868A08";
        Div1.style.backgroundColor = "#D7DF01";
        var profile3 = document.getElementById("profile3");
        profile3.style.borderColor = "#868A08";
        profile3.style.backgroundColor = "#D7DF01";
        profile3.style.color = "#8A0808";
        var Div2 = document.getElementById("Div2");
        Div2.style.borderColor = "#868A08";
        Div2.style.backgroundColor = "#D7DF01";
        var profile4 = document.getElementById("profile4");
        profile4.style.borderColor = "#868A08";
        profile4.style.backgroundColor = "#D7DF01";
        profile4.style.color = "#8A0808";
        var Div3 = document.getElementById("Div3");
        Div3.style.borderColor = "#868A08";
        Div3.style.backgroundColor = "#D7DF01";
        var empprofile2 = document.getElementById("empprofile2");
        empprofile2.style.display = "none";
        var Div6 = document.getElementById("Div6");
        Div6.style.display = "none";
        var Div7 = document.getElementById("Div7");
        Div7.style.display = "none";
        var Div8 = document.getElementById("Div8");
        Div8.style.display = "block";
        var sv1 = document.getElementById("sv1");
        sv1.style.display = "none";
        var rs2 = document.getElementById("rs2");
        rs2.style.display = "none";
        var sv2 = document.getElementById("sv2");
        sv2.style.display = "none";
        var rs3 = document.getElementById("rs3");
        rs3.style.display = "none";
        var academic_sv1 = document.getElementById("academic_sv1");
        academic_sv1.style.display = "none";
        var academic_rs1 = document.getElementById("academic_rs1");
        academic_rs1.style.display = "none";
        var sub_val1 = document.getElementById("sub_val1");
        sub_val1.style.display = "none";
        var exeperice_sv1 = document.getElementById("exeperice_sv1");
        exeperice_sv1.style.display = "none";
        var exeperice_rs1 = document.getElementById("exeperice_rs1");
        exeperice_rs1.style.display = "none";
    }
    else {
    
        window.alert(result);
    }
}

function reset_value5() {
    var ddl_year = document.getElementById("ddl_year");
    ddl_year.options[0].selected = true;
    var ddl_month = document.getElementById("ddl_month");
    ddl_month.options[0].selected = true;
    var txt_key_skill = document.getElementById("txt_key_skill");
    txt_key_skill.value = "";
    var txt_headline = document.getElementById("txt_headline");
    txt_headline.value = "";
    var ddl_industry = document.getElementById("ddl_industry");
    ddl_industry.options[0].selected = true;
    var ddl_function = document.getElementById("ddl_function");
    ddl_function.options[0].selected = true;
}

function submit_value7() {

    var txtPermAdd = document.getElementById("txtPermAdd");
    if (txtPermAdd.value == "") {
        window.alert("Permanent Address must not be null.");
        txt_headline.focus();
        return false;
    }
    var ddlCountryP = document.getElementById("ddlCountryP");
    var SelValue6 = ddlCountryP.options[ddlCountryP.selectedIndex].value;
    if (SelValue6 == "0") {
        window.alert("Country must not be null.");
        ddlCountryP.focus();
        return false;
    }

    var ddlStateP = document.getElementById("ddlStateP");
    var SelValue7 = ddlStateP.options[ddlStateP.selectedIndex].value;
    if (SelValue7 == "0") {
        window.alert("State must not be null.");
        ddlStateP.focus();
        return false;
    }

    var ddlCityP = document.getElementById("ddlCityP");
    var SelValue8 = ddlCityP.options[ddlCityP.selectedIndex].value;
    if (SelValue8 == "0") {
        window.alert("City must not be null.");
        ddlCityP.focus();
        return false;
    }

    var txtZipP = document.getElementById("txtZipP");
    if (txtZipP.value == "") {
        window.alert("ZipCode must not be null.");
        txtZipP.focus();
        return false;
    }
    var txtEmailP = document.getElementById("txtEmailP");
    if (txtEmailP.value != "") {
        var reg = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
        if (reg.test(txtEmailP.value) == false) {
            window.alert("Enter Valid Email Id.");
            txtEmailP.value = "";
            txtEmailP.focus();
            return false;
        }
     
    }

    var txt_phaddl = document.getElementById("txt_phaddl");
    if (txt_phaddl.value == "") {
        window.alert("Local Address must not be null.");
        txt_phaddl.focus();
        return false;
    }

    var ddl_countryl = document.getElementById("ddl_countryl");
    var SelValue9 = ddl_countryl.options[ddl_countryl.selectedIndex].value;
    if (SelValue9 == "0") {
        window.alert("Country must not be null.");
        ddl_countryl.focus();
        return false;
    }

    var ddl_statel = document.getElementById("ddl_statel");
    var SelValue10 = ddl_statel.options[ddl_statel.selectedIndex].value;
    if (SelValue10 == "0") {
        window.alert("State must not be null.");
        ddl_statel.focus();
        return false;
    }

    var ddl_cityl = document.getElementById("ddl_cityl");
    var SelValue11 = ddl_cityl.options[ddl_cityl.selectedIndex].value;
    if (SelValue11 == "0") {
        window.alert("City must not be null.");
        ddl_cityl.focus();
        return false;
    }
    var txt_zipcodel = document.getElementById("txt_zipcodel");
    if (txt_zipcodel.value == "") {
        window.alert("ZipCode must not be null.");
        txt_zipcodel.focus();
        return false;
    }

    var txt_emailidl = document.getElementById("txt_emailidl");
    if (txt_emailidl.value != "") {
        var reg = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
        if (reg.test(txt_emailidl.value)==false) {
            window.alert("Enter Valid Email Id.");
            txt_emailidl.value = "";
            txt_emailidl.focus();
            return false;
        }
    }
    var sameas="N";
    var txtPhP = document.getElementById("txtPhP");
    var txtEmailP = document.getElementById("txtEmailP");
    var txtMobP = document.getElementById("txtMobP");
    var TextBox5 = document.getElementById("TextBox5");
    var TextBox7 = document.getElementById("TextBox7");
    var chkAddr = document.getElementById("chkAddr");
    if (chkAddr.checked == true) {
        sameas = "Y";
    }
    else {
        sameas = "N";
    }
    Calender_details.Insert_employee_address_details(empidvalue, txtPermAdd.value, SelValue6, SelValue7, SelValue8, txtZipP.value, txtPhP.value, txtEmailP.value,txtMobP.value,txt_phaddl.value,SelValue9,SelValue10,SelValue11,txt_zipcodel.value,TextBox5.value,txt_emailidl.value,TextBox7.value,sameas, Fill_emplyee_details_bind_address);
}

function Fill_emplyee_details_bind_address(result) {
    if (result == 'Record Saved successfully.') {
        var empprofile1 = document.getElementById("empprofile1");
        empprofile1.style.display = "none";
        var profile1 = document.getElementById("profile1");
        profile1.style.borderColor = "#868A08";
        profile1.style.backgroundColor = "#D7DF01";
        profile1.style.color = "#8A0808";
        var profile2 = document.getElementById("Profile2");
        profile2.style.borderColor = "#868A08";
        profile2.style.backgroundColor = "#D7DF01";
        profile2.style.color = "#8A0808";
        var profileline1 = document.getElementById("profileline1");
        profileline1.style.borderColor = "#868A08";
        profileline1.style.backgroundColor = "#D7DF01";
        var Div1 = document.getElementById("Div1");
        Div1.style.borderColor = "#868A08";
        Div1.style.backgroundColor = "#D7DF01";
        var profile3 = document.getElementById("profile3");
        profile3.style.borderColor = "#868A08";
        profile3.style.backgroundColor = "#D7DF01";
        profile3.style.color = "#8A0808";
        var Div2 = document.getElementById("Div2");
        Div2.style.borderColor = "#868A08";
        Div2.style.backgroundColor = "#D7DF01";
        var profile4 = document.getElementById("profile4");
        profile4.style.borderColor = "#868A08";
        profile4.style.backgroundColor = "#D7DF01";
        profile4.style.color = "#8A0808";
        var Div3 = document.getElementById("Div3");
        Div3.style.borderColor = "#868A08";
        Div3.style.backgroundColor = "#D7DF01";
        var Profile5 = document.getElementById("Profile5");
        Profile5.style.borderColor = "#868A08";
        Profile5.style.backgroundColor = "#D7DF01";
        Profile5.style.color = "#8A0808";
        var Div4 = document.getElementById("Div4");
        Div4.style.borderColor = "#868A08";
        Div4.style.backgroundColor = "#D7DF01";
        var empprofile2 = document.getElementById("empprofile2");
        empprofile2.style.display = "none";
        var Div6 = document.getElementById("Div6");
        Div6.style.display = "none";
        var Div7 = document.getElementById("Div7");
        Div7.style.display = "none";
        var Div8 = document.getElementById("Div8");
        Div8.style.display = "none";
        var Div_confirmation = document.getElementById("Div_confirmation");
        Div_confirmation.style.display = "block";
        var sv1 = document.getElementById("sv1");
        sv1.style.display = "none";
        var rs2 = document.getElementById("rs2");
        rs2.style.display = "none";
        var sv2 = document.getElementById("sv2");
        sv2.style.display = "none";
        var rs3 = document.getElementById("rs3");
        rs3.style.display = "none";
        var academic_sv1 = document.getElementById("academic_sv1");
        academic_sv1.style.display = "none";
        var academic_rs1 = document.getElementById("academic_rs1");
        academic_rs1.style.display = "none";
        var sub_val1 = document.getElementById("sub_val1");
        sub_val1.style.display = "none";
        var exeperice_sv1 = document.getElementById("exeperice_sv1");
        exeperice_sv1.style.display = "none";
        var exeperice_rs1 = document.getElementById("exeperice_rs1");
        exeperice_rs1.style.display = "none";
        var address_sv1 = document.getElementById("address_sv1");
        address_sv1.style.display = "none";
        var address_rs1 = document.getElementById("address_rs1");
        address_rs1.style.display = "none";
        Calender_details.Bindcontrol_profile(empidvalue, Fill_emplyee_details_control);
    }
}

function Fill_emplyee_details_control(result) {
    var xml = parseXml(result)
    if (xml) {
        bind_Controls(xml.documentElement);
    }
}

function bind_Controls(root) {
  
    var lbl_empName = document.getElementById("lbl_empName");
    var lbl_empcode = document.getElementById("lbl_empcode");
    var lbl_mobile = document.getElementById("lbl_mobile");
    var lbl_email = document.getElementById("lbl_email");
    var lbl_birth = document.getElementById("lbl_birth");
    var lbl_bldgroup = document.getElementById("lbl_bldgroup");
    var lbl_fathernm = document.getElementById("lbl_fathernm");
    var lbl_gender = document.getElementById("lbl_gender");
    var lbl_martial = document.getElementById("lbl_martial");
    var lbl_religion = document.getElementById("lbl_religion");

    var rb_radio = document.getElementById("rb_radio");
    var lbl_address = document.getElementById("lbl_address");
    var lbl_country = document.getElementById("lbl_country");
    var lbl_state = document.getElementById("lbl_state");
    var lbl_city1 = document.getElementById("lbl_city1");
    var lbl_zipcode = document.getElementById("lbl_zipcode");
    var lbl_phone = document.getElementById("lbl_phone");
    var lbl_experience = document.getElementById("lbl_experience");
    var lbl_keyskills = document.getElementById("lbl_keyskills");
    var lbl_healine = document.getElementById("lbl_healine");
    var lbl_industry = document.getElementById("lbl_industry");
    var lbl_functional = document.getElementById("lbl_functional");
    var lbl_download = document.getElementById("lbl_download");
    var txt_joindate = document.getElementById("txt_joindate");
    var txt_confirmation = document.getElementById("txt_confirmation");
    var ddlEmpType = document.getElementById("ddlEmpType");
    var ddlModeOAppl = document.getElementById("ddlModeOAppl");


    var Temp_Employee_Details_Entry = root.getElementsByTagName("Temp_Employee_Details_Entry");
    var empname = root.getElementsByTagName("empname");
    var sex = root.getElementsByTagName("sex");
    var dob = root.getElementsByTagName("dob");
    var meritalStatus = root.getElementsByTagName("meritalStatus");
    var religion = root.getElementsByTagName("religion");
    var nationality = root.getElementsByTagName("nationality");
    var spouseName = root.getElementsByTagName("spouseName");
    var fatherName = root.getElementsByTagName("fatherName");
    var permAdd = root.getElementsByTagName("permAdd");
    var zipcode = root.getElementsByTagName("zipcode");
    var phone = root.getElementsByTagName("phone");
    var email = root.getElementsByTagName("email");
    var mobile = root.getElementsByTagName("mobile");
    var bloodGroup = root.getElementsByTagName("bloodGroup");
    var titleEmp = root.getElementsByTagName("titleEmp");
    var Empid = root.getElementsByTagName("Empid");
    var academic_record = root.getElementsByTagName("academic_record");
    var pEmail = root.getElementsByTagName("pEmail");
    var pMobile = root.getElementsByTagName("pMobile");
    var same_as_per = root.getElementsByTagName("same_as_per");
    var key_skill = root.getElementsByTagName("key_skill");
    var profile_hd = root.getElementsByTagName("profile_hd");
    var resume_path = root.getElementsByTagName("resume_path");
    var exe_year = root.getElementsByTagName("exe_year");
    var exe_month = root.getElementsByTagName("exe_month");
    var CountryName = root.getElementsByTagName("CountryName");
    var StateName = root.getElementsByTagName("StateName");
    var CityName = root.getElementsByTagName("CityName");
    var funcation_name = root.getElementsByTagName("funcation_name");
    var Industry_name = root.getElementsByTagName("Industry_name");
    var modeAppl = root.getElementsByTagName("modeAppl");
    var referedby = root.getElementsByTagName("referedby");
    var joinDate = root.getElementsByTagName("joinDate");

    if (Temp_Employee_Details_Entry.length > 0) {

        lbl_empName.innerText = GetInnerText(empname[0]);
        lbl_empName.textContext = GetInnerText(empname[0]);
        lbl_mobile.innerText = GetInnerText(mobile[0]);
        lbl_mobile.textContext = GetInnerText(mobile[0]);
        lbl_email.innerText = GetInnerText(email[0]);
        lbl_email.textContext = GetInnerText(email[0]);
        lbl_birth.innerText = GetInnerText(dob[0]);
        lbl_birth.textContext = GetInnerText(dob[0]);
        lbl_bldgroup.innerText = GetInnerText(bloodGroup[0]);
        lbl_bldgroup.textContext = GetInnerText(bloodGroup[0]);
        lbl_fathernm.innerText = GetInnerText(fatherName[0]);
        lbl_fathernm.textContext = GetInnerText(fatherName[0]);
        lbl_gender.innerText = GetInnerText(sex[0]);
        lbl_gender.textContext = GetInnerText(sex[0]);
        lbl_martial.innerText = GetInnerText(meritalStatus[0]);
        lbl_martial.textContext = GetInnerText(meritalStatus[0]);
        lbl_religion.innerText = GetInnerText(religion[0]);
        lbl_religion.textContext = GetInnerText(religion[0]);
        lbl_address.innerText = GetInnerText(permAdd[0]);
        lbl_address.textContext = GetInnerText(permAdd[0]);
        lbl_country.innerText = GetInnerText(CountryName[0]);
        lbl_country.textContext = GetInnerText(CountryName[0]);
        lbl_state.innerText = GetInnerText(StateName[0]);
        lbl_state.textContext = GetInnerText(StateName[0]);
        lbl_city1.innerText = GetInnerText(CityName[0]);
        lbl_city1.textContext = GetInnerText(CityName[0]);
        lbl_zipcode.innerText = GetInnerText(zipcode[0]);
        lbl_zipcode.textContext = GetInnerText(zipcode[0]);
        lbl_phone.innerText = GetInnerText(phone[0]);
        lbl_phone.textContext = GetInnerText(phone[0]);
        if (GetInnerText(exe_year[0]) == 'F') {
            lbl_experience.innerText = "Fresher";
            lbl_experience.textContext = "Fresher";
        }
        else {
            lbl_experience.innerText = GetInnerText(exe_year[0]) + " Years " + GetInnerText(exe_month[0]) + " Months";
            lbl_experience.textContext = GetInnerText(exe_year[0]) + " Years " + GetInnerText(exe_month[0]) + " Months";
        }
        lbl_keyskills.innerText = GetInnerText(key_skill[0]);
        lbl_keyskills.textContext = GetInnerText(key_skill[0]);
        lbl_healine.innerText = GetInnerText(profile_hd[0]);
        lbl_healine.textContext = GetInnerText(profile_hd[0]);
        lbl_industry.innerText = GetInnerText(Industry_name[0]);
        lbl_industry.textContext = GetInnerText(Industry_name[0]);
        lbl_functional.innerText = GetInnerText(funcation_name[0]);
        lbl_functional.textContext = GetInnerText(funcation_name[0]);
    }

    Calender_details.Bindcontrol_academic(empidvalue, Fill_emplyee_academic_control);
}


function Fill_emplyee_academic_control(result) {
    var xml = parseXml(result)
    if (xml) {
        bind_Controls_academic(xml.documentElement);
    }
}

function bind_Controls_academic(root) {
    var lbl_wed = document.getElementById("lbl_wed");
    var lbl_quali = document.getElementById("lbl_quali");
    var lbl_strm = document.getElementById("lbl_strm");
    var lbl_board = document.getElementById("lbl_board");
    var lbl_year = document.getElementById("lbl_year");
    var lbl_percentage = document.getElementById("lbl_percentage");
    var lbl_grade = document.getElementById("lbl_grade");

    var temp_employee_academic_details = root.getElementsByTagName("temp_employee_academic_details");
    var wed = root.getElementsByTagName("wed");
    var course = root.getElementsByTagName("course");
    var year = root.getElementsByTagName("year");
    var university = root.getElementsByTagName("university");
    var grade = root.getElementsByTagName("grade");
    var marks = root.getElementsByTagName("marks");
    var image_doc = root.getElementsByTagName("image_doc");
    var qulification = root.getElementsByTagName("qulification");
    if (temp_employee_academic_details.length > 0) {

        lbl_wed.innerText = GetInnerText(wed[0]);
        lbl_wed.textContext = GetInnerText(wed[0]);
        lbl_quali.innerText = GetInnerText(qulification[0]);
        lbl_quali.textContext = GetInnerText(qulification[0]);
        lbl_strm.innerText = GetInnerText(course[0]);
        lbl_strm.textContext = GetInnerText(course[0]);
        lbl_board.innerText = GetInnerText(university[0]);
        lbl_board.textContext = GetInnerText(university[0]);
        lbl_year.innerText = GetInnerText(year[0]);
        lbl_year.textContext = GetInnerText(year[0]);
        lbl_percentage.innerText = GetInnerText(marks[0]);
        lbl_percentage.textContext = GetInnerText(marks[0]);
        lbl_grade.innerText = GetInnerText(grade[0]);
        lbl_grade.textContext = GetInnerText(grade[0]);

    }

}

function rb_radio_onchange() {
    var rb_radio = document.getElementById("rb_radio");
    var radio = rb_radio.getElementsByTagName("input");
    var getvalue = "";

    if (radio[0].checked == true) {
        getvalue = "P";
    }
    else {
        getvalue = "L";
    }
    Calender_details.Bindcontrol_address(getvalue,empidvalue, Fill_emplyee_address_control);
}

function Fill_emplyee_address_control(result) {
    var xml = parseXml(result)
    if (xml) {
        bind_emplyee_address_control(xml.documentElement);
    }
}

function bind_emplyee_address_control(root) {

    var lbl_address = document.getElementById("lbl_address");
    var lbl_country = document.getElementById("lbl_country");
    var lbl_state = document.getElementById("lbl_state");
    var lbl_city1 = document.getElementById("lbl_city1");
    var lbl_zipcode = document.getElementById("lbl_zipcode");
    var lbl_phone = document.getElementById("lbl_phone");

    var Temp_Employee_Details_Entry = root.getElementsByTagName("Temp_Employee_Details_Entry");
    var permAdd = root.getElementsByTagName("permAdd");
    var zipcode = root.getElementsByTagName("zipcode");
    var phone = root.getElementsByTagName("phone");
    var email = root.getElementsByTagName("pEmail");
    var mobile = root.getElementsByTagName("pMobile");
    var CountryName = root.getElementsByTagName("CountryName");
    var StateName = root.getElementsByTagName("StateName");
    var CityName = root.getElementsByTagName("CityName");
    if (Temp_Employee_Details_Entry.length > 0) {

        lbl_address.innerText = GetInnerText(permAdd[0]);
        lbl_address.textContext = GetInnerText(permAdd[0]);
        lbl_country.innerText = GetInnerText(CountryName[0]);
        lbl_country.textContext = GetInnerText(CountryName[0]);
        lbl_state.innerText = GetInnerText(StateName[0]);
        lbl_state.textContext = GetInnerText(StateName[0]);
        lbl_city1.innerText = GetInnerText(CityName[0]);
        lbl_city1.textContext = GetInnerText(CityName[0]);
        lbl_zipcode.innerText = GetInnerText(zipcode[0]);
        lbl_zipcode.textContext = GetInnerText(zipcode[0]);
        lbl_phone.innerText = GetInnerText(phone[0]);
        lbl_phone.textContext = GetInnerText(phone[0]);
    }
}

function reset_value7() {
    var txtPermAdd = document.getElementById("txtPermAdd");
    txtPermAdd.value = "";
    var ddlCountryP = document.getElementById("ddlCountryP");
    ddlCountryP.options[0].selected = true;
    var ddlStateP = document.getElementById("ddlStateP");
    ddlStateP.options[0].selected = true;
    var ddlCityP = document.getElementById("ddlCityP");
    ddlCityP.options[0].selected = true;
    var txtZipP = document.getElementById("txtZipP");
    txtZipP.value = "";
    var txtPhP = document.getElementById("txtPhP");
    txtPhP.value = "";
    var txtEmailP = document.getElementById("txtEmailP");
    txtEmailP.value = "";
    var txtMobP = document.getElementById("txtMobP");
    txtMobP.value = "";
    var txt_phaddl = document.getElementById("txt_phaddl");
    txt_phaddl.value = "";
    var ddl_countryl = document.getElementById("ddl_countryl");
    ddl_countryl.options[0].selected = true;
    var ddl_statel = document.getElementById("ddl_statel");
    ddl_statel.options[0].selected = true;
    var ddl_cityl = document.getElementById("ddl_cityl");
    ddl_cityl.options[0].selected = true;
    var txt_zipcodel = document.getElementById("txt_zipcodel");
    txt_zipcodel.value = "";
    var TextBox5 = document.getElementById("TextBox5");
    TextBox5.value = "";
    var txt_emailidl = document.getElementById("txt_emailidl");
    txt_emailidl.value = "";
    var TextBox7 = document.getElementById("TextBox7");
    TextBox7.value = "";
}

function submit_value8() {

    
    var ddlEmpType = document.getElementById("ddlEmpType");
    var SelValue10 = ddlEmpType.options[ddlEmpType.selectedIndex].value;
    if (SelValue10 == "0") {
        window.alert("Select Employee Type.");
        ddlEmpType.focus();
        return false;
    }

    var ddlModeOAppl = document.getElementById("ddlModeOAppl");
    var SelValue11 = ddlModeOAppl.options[ddlModeOAppl.selectedIndex].value;
    var SelValue12 = ddlModeOAppl.options[ddlModeOAppl.selectedIndex].text;
    if (SelValue11 == "0") {
        window.alert("Select Mode of Application.");
        ddlModeOAppl.focus();
        return false;
    } 
    var txtRefBy = document.getElementById("txtRefBy");
    if (SelValue12 == "Reference") {
        if (txtRefBy.value = "") {
            window.alert("Reference details must not be null");
            txtRefBy.focus();
            return false;
        }
    }

    var txt_joindate = document.getElementById("txt_joindate");
    if (txt_joindate.value == "") {
        window.alert("Joining date must not be null.");
        txt_joindate.focus();
        return false;
    }

    var txt_confirmation = document.getElementById("txt_confirmation");
    if (txt_confirmation.value == "") {
        window.alert("Confirmation date must not be null.");
        txt_confirmation.focus();
        return false;
    }
    var ddlNature = document.getElementById("ddlNature");
    var ddlNature_SelValue11 = ddlNature.options[ddlNature.selectedIndex].value;
    if (ddlNature_SelValue11 == "0") {
        window.alert("Select Nature of Employee.");
        ddlNature.focus();
        return false;
    }

    var ddldept = document.getElementById("ddldept");
    var ddldept_SelValue11 = ddldept.options[ddldept.selectedIndex].value;
    if (ddldept_SelValue11 == "0") {
        window.alert("Select Department of Employee.");
        ddldept.focus();
        return false;
    }

    var ddlDesig = document.getElementById("ddlDesig");
    var ddlDesig_SelValue11 = ddlDesig.options[ddlDesig.selectedIndex].value;
    if (ddlDesig_SelValue11 == "0") {
        window.alert("Select Designation of Employee.");
        ddldept.focus();
        return false;
    }

    var ddlAuthority = document.getElementById("ddlAuthority");
    var ddlAuthority_SelValue11 = ddlAuthority.options[ddlAuthority.selectedIndex].value;
    if (ddlAuthority_SelValue11 == "0") {
        window.alert("Select Reporting Authority of Employee.");
        ddlAuthority.focus();
        return false;
    }
    var txtEmpName = document.getElementById("txtEmpName");
    Calender_details.Insert_employee_details_final(SelValue10, SelValue11,txt_joindate.value, empidvalue,txt_confirmation.value,txtRefBy.value,txtEmpName.value,ddlNature_SelValue11,ddldept_SelValue11,ddlDesig_SelValue11,ddlAuthority_SelValue11, Fill_emplyee_final_details);
}

function Fill_emplyee_final_details(result) {
    if (result != "0") {
        var empprofile1 = document.getElementById("empprofile1");
        empprofile1.style.display = "none";
        var profile1 = document.getElementById("profile1");
        profile1.style.borderColor = "#868A08";
        profile1.style.backgroundColor = "#D7DF01";
        profile1.style.color = "#8A0808";
        var profile2 = document.getElementById("Profile2");
        profile2.style.borderColor = "#868A08";
        profile2.style.backgroundColor = "#D7DF01";
        profile2.style.color = "#8A0808";
        var profileline1 = document.getElementById("profileline1");
        profileline1.style.borderColor = "#868A08";
        profileline1.style.backgroundColor = "#D7DF01";
        var Div1 = document.getElementById("Div1");
        Div1.style.borderColor = "#868A08";
        Div1.style.backgroundColor = "#D7DF01";
        var profile3 = document.getElementById("profile3");
        profile3.style.borderColor = "#868A08";
        profile3.style.backgroundColor = "#D7DF01";
        profile3.style.color = "#8A0808";
        var Div2 = document.getElementById("Div2");
        Div2.style.borderColor = "#868A08";
        Div2.style.backgroundColor = "#D7DF01";
        var profile4 = document.getElementById("profile4");
        profile4.style.borderColor = "#868A08";
        profile4.style.backgroundColor = "#D7DF01";
        profile4.style.color = "#8A0808";
        var Div3 = document.getElementById("Div3");
        Div3.style.borderColor = "#868A08";
        Div3.style.backgroundColor = "#D7DF01";
        var Profile5 = document.getElementById("Profile5");
        Profile5.style.borderColor = "#868A08";
        Profile5.style.backgroundColor = "#D7DF01";
        Profile5.style.color = "#8A0808";
        var Div4 = document.getElementById("Div4");
        Div4.style.borderColor = "#868A08";
        Div4.style.backgroundColor = "#D7DF01";
        var Profile7 = document.getElementById("Profile7");
        Profile7.style.borderColor = "#868A08";
        Profile7.style.backgroundColor = "#D7DF01";
        Profile7.style.color = "#8A0808";
        var empprofile2 = document.getElementById("empprofile2");
        empprofile2.style.display = "none";
        var Div6 = document.getElementById("Div6");
        Div6.style.display = "none";
        var Div7 = document.getElementById("Div7");
        Div7.style.display = "none";
        var Div8 = document.getElementById("Div8");
        Div8.style.display = "none";
        var Div_confirmation = document.getElementById("Div_confirmation");
        Div_confirmation.style.display = "none";
        var sv1 = document.getElementById("sv1");
        sv1.style.display = "none";
        var rs2 = document.getElementById("rs2");
        rs2.style.display = "none";
        var sv2 = document.getElementById("sv2");
        sv2.style.display = "none";
        var rs3 = document.getElementById("rs3");
        rs3.style.display = "none";
        var academic_sv1 = document.getElementById("academic_sv1");
        academic_sv1.style.display = "none";
        var academic_rs1 = document.getElementById("academic_rs1");
        academic_rs1.style.display = "none";
        var sub_val1 = document.getElementById("sub_val1");
        sub_val1.style.display = "none";
        var exeperice_sv1 = document.getElementById("exeperice_sv1");
        exeperice_sv1.style.display = "none";
        var exeperice_rs1 = document.getElementById("exeperice_rs1");
        exeperice_rs1.style.display = "none";
        var address_sv1 = document.getElementById("address_sv1");
        address_sv1.style.display = "none";
        var address_rs1 = document.getElementById("address_rs1");
        address_rs1.style.display = "none";
        var Img1 = document.getElementById("Img1");
        Img1.style.display = "none";
        var valkloe = result.split('&');
        employee_code = valkloe[0];
        empidinserted = valkloe[1];
        alert("Record saved successfully and Employee Code: " + employee_code);
        var employee_profile_div = document.getElementById("employee_profile_div");
        employee_profile_div.style.display = "none";
        var employee_joining_details = document.getElementById("employee_joining_details");
        employee_joining_details.style.display = "block";
        var div_basic_salary_details = document.getElementById("div_basic_salary_details");
        div_basic_salary_details.style.display = "block";
    }
}

function application_mode() {
    var ddlModeOAppl = document.getElementById("ddlModeOAppl");
    var SelValue11 = ddlModeOAppl.options[ddlModeOAppl.selectedIndex].value;
    var SelValue12 = ddlModeOAppl.options[ddlModeOAppl.selectedIndex].text;
    var txtRefBy = document.getElementById("txtRefBy");
    if (SelValue12 == "Direct") {
        txtRefBy.disabled = true;
    }
    else {
        txtRefBy.disabled = false;
        txtRefBy.focus();
    }
}

function submit_value9() {
    var txtWED = document.getElementById("txtWED");
    var CheckHod = document.getElementById("CheckHod");
    var rdbPayperiod = document.getElementById("rdbPayperiod");
    var txtBasic = document.getElementById("txtBasic");
    var ddlGrade = document.getElementById("ddlGrade");
    var ddlGrade_SelValue11 = ddlGrade.options[ddlGrade.selectedIndex].value;
    var ddlAuthority = document.getElementById("ddlAuthority");
    var ddlAuthority_SelValue11 = ddlAuthority.options[ddlAuthority.selectedIndex].value;
    var txtPF = document.getElementById("txtPF");
    var txtESI = document.getElementById("txtESI");
    var txtSearch0 = document.getElementById("txtSearch0");
    var ddlDesig = document.getElementById("ddlDesig");
    var ddlDesig_SelValue11 = ddlDesig.options[ddlDesig.selectedIndex].value;
    var ddldept = document.getElementById("ddldept");
    var ddldept_SelValue11 = ddldept.options[ddldept.selectedIndex].value;
    var CheckDG = document.getElementById("CheckDG");
    var DG = "";
    if (txtWED.value == "") {
        window.alert("Enter Wed Date.");
        txtWED.focus();
        return false;
    }
    var valueeie = "";
    var txtRefBy = document.getElementById("txtRefBy");
    if (CheckHod.checked == true) {
        valueeie = "YES";
    }
    else {
        valueeie = "NO";
    }
    var radio = rdbPayperiod.getElementsByTagName("input");
    var rb_value="";
    if (radio[0].checked == true) {
        rb_value = "M";
    }
    if (radio[1].checked == true) {
        rb_value = "S";
    }
    if (radio[2].checked == true) {
        rb_value = "W";
    }
    if (radio[3].checked == true) {
        rb_value = "D";
    }

    if (txtSearch0.value == "") {
        window.alert("Search Employee.");
        txtSearch0.focus();
        return false;
    }
    if (ddlGrade_SelValue11 == "0") {
        window.alert("Search Employee Grade.");
        ddlGrade.focus();
        return false;
    }
    var stat_val = "C";
    var overTimehour = "0";
    var overTimeminute = "0";
    var halfDayhour = "0";
    var halfDayminute = "0";
    var lateHour = "0";
    var lateMin = "0";
    if (CheckDG.checked == true) {
        DG = "Yes";
    }
    else {
        DG = "No";
    }
    Calender_details.insert_employee_basic_Salary(empidinserted, txtWED.value, ddldept_SelValue11, ddlDesig_SelValue11, rb_value, txtBasic.value, overTimehour, overTimeminute, halfDayhour, halfDayminute,ddlGrade_SelValue11,lateHour,lateMin,txtPF.value,txtESI.value, ddlAuthority_SelValue11, empidvalue,valueeie,DG, Fill_emplyee_Salary_details);
}

function Fill_emplyee_Salary_details(result) {
    if (result > 0) {
        var Div15 = document.getElementById("Div15");
        Div15.style.borderColor = "#868A08";
        Div15.style.backgroundColor = "#D7DF01";
        Div15.style.color = "#8A0808";
        var Div16 = document.getElementById("Div16");
        Div16.style.borderColor = "#868A08";
        Div16.style.backgroundColor = "#D7DF01";
        var div_basic_salary_details = document.getElementById("div_basic_salary_details");
        div_basic_salary_details.style.display = "none";
        var Img2 = document.getElementById("Img2");
        Img2.style.display = "none";
        var Img3 = document.getElementById("Img3");
        Img3.style.display = "none";
        var div_timing_details = document.getElementById("div_timing_details");
        div_timing_details.style.display = "block";
    }
}

function reset_value9() {
    var txtWED = document.getElementById("txtWED");
    txtWED.value = "";
    var CheckHod = document.getElementById("CheckHod");
 
    var rdbPayperiod = document.getElementById("rdbPayperiod");
    var txtBasic = document.getElementById("txtBasic");
    txtBasic.value = "";
    var ddlGrade = document.getElementById("ddlGrade");
    ddlGrade.options[0].selected = true;
    var txtPF = document.getElementById("txtPF");
    txtPF.value = "";
    var txtESI = document.getElementById("txtESI");
    txtESI.value = "";
    var txtSearch0 = document.getElementById("txtSearch0");
    txtSearch0.value = "";
}

function submit_value10() {
    var txtWEDTiming = document.getElementById("txtWEDTiming");
    if (txtWEDTiming.value == "") {
        window.alert("Enter Wed Date.");
        txtWED.focus();
        return false;
    }

    var RdbPunch = document.getElementById("RdbPunch");
    var radio = RdbPunch.getElementsByTagName("input");
    var valueeie = "";

    if (radio[0].checked == true) {
        valueeie = "Once";
    }
    if (radio[1].checked == true) {
        valueeie = "Twice";
    }

    var ddlInHr = document.getElementById("ddlInHr");
    var ddlInHr_SelValue11 = ddlInHr.options[ddlInHr.selectedIndex].value;
    var ddlInHr_SelText = ddlInHr.options[ddlInHr.selectedIndex].text;
    if (ddlInHr_SelText == "Select") {
        window.alert("Select Office In Hour");
        ddlInHr.focus();
        return false;
    }

    var ddlInMin = document.getElementById("ddlInMin");
    var ddlInMin_SelValue11 = ddlInMin.options[ddlInMin.selectedIndex].value;
    var ddlInMin_Seltext = ddlInMin.options[ddlInMin.selectedIndex].text;
    if (ddlInMin_Seltext == "Select") {
        window.alert("Select Office In Minute");
        ddlInMin.focus();
        return false;
    }

    var ddlInSec = document.getElementById("ddlInSec");
    var ddlInSec_SelValue11 = ddlInSec.options[ddlInSec.selectedIndex].value;
    var ddlInSec_Seltext = ddlInSec.options[ddlInSec.selectedIndex].text;
    if (ddlInSec_Seltext == "Select") {
        window.alert("Select Office In Second");
        ddlInSec.focus();
        return false;
    }

    var ddlOutHr = document.getElementById("ddlOutHr");
    var ddlOutHr_SelValue11 = ddlOutHr.options[ddlOutHr.selectedIndex].value;
    var ddlOutHr_Seltext = ddlOutHr.options[ddlOutHr.selectedIndex].text;
    if (ddlOutHr_Seltext == "Select") {
        window.alert("Select Office Out Hour");
        ddlOutHr.focus();
        return false;
    }

    var ddlOutMin = document.getElementById("ddlOutMin");
    var ddlOutMin_SelValue11 = ddlOutMin.options[ddlOutMin.selectedIndex].value;
    var ddlOutMin_SelText = ddlOutMin.options[ddlOutMin.selectedIndex].text;
    if (ddlOutMin_SelText == "Select") {
        window.alert("Select Office Out Minute");
        ddlOutMin.focus();
        return false;
    }

    var ddlOutSecd = document.getElementById("ddlOutSecd");
    var ddlOutSecd_SelValue11 = ddlOutSecd.options[ddlOutSecd.selectedIndex].value;
    var ddlOutSecd_SelText = ddlOutSecd.options[ddlOutSecd.selectedIndex].text;
    if (ddlOutSecd_SelText == "Select") {
        window.alert("Select Office Out Second");
        ddlOutSecd.focus();
        return false;
    }

    Calender_details.insert_employee_Timing_details(empidinserted, txtWED.value, ddlInHr_SelText, ddlInMin_Seltext, ddlInSec_Seltext, ddlOutHr_Seltext, ddlOutMin_SelText, ddlOutSecd_SelText, valueeie, Fill_emplyee_timing_details);
}

function Fill_emplyee_timing_details(result) {
    if (result != 0) {
        var Div15 = document.getElementById("Div15");
        Div15.style.borderColor = "#868A08";
        Div15.style.backgroundColor = "#D7DF01";
        Div15.style.color = "#8A0808";
        var Div16 = document.getElementById("Div16");
        Div16.style.borderColor = "#868A08";
        Div16.style.backgroundColor = "#D7DF01";
        var div_basic_salary_details = document.getElementById("div_basic_salary_details");
        div_basic_salary_details.style.display = "none";
        var Img2 = document.getElementById("Img2");
        Img2.style.display = "none";
        var Img3 = document.getElementById("Img3");
        Img3.style.display = "none";
        var div_timing_details = document.getElementById("div_timing_details");
        div_timing_details.style.display = "none";
        var Div15 = document.getElementById("Div17");
        Div15.style.borderColor = "#868A08";
        Div15.style.backgroundColor = "#D7DF01";
        Div15.style.color = "#8A0808";
        var Img4 = document.getElementById("Img4");
        Img4.style.display = "none";
        var Img3 = document.getElementById("Img3");
        Img3.style.display = "none";
        var nominee_details = document.getElementById("nominee_details");
        nominee_details.style.display = "block";
      
    }
}

function reset_value10() {
    var txtWEDTiming = document.getElementById("txtWEDTiming");
    txtWEDTiming.value = "";
    var RdbPunch = document.getElementById("RdbPunch");
    var ddlInHr = document.getElementById("ddlInHr");
    ddlInHr.options[0].selected = true;
    var ddlInMin = document.getElementById("ddlInMin");
    ddlInMin.options[0].selected = true;
    var ddlInSec = document.getElementById("ddlInSec");
    ddlInSec.options[0].selected = true;
    var ddlOutHr = document.getElementById("ddlOutHr");
    ddlOutHr.options[0].selected = true;
    var ddlOutMin = document.getElementById("ddlOutMin");
    ddlOutMin.options[0].selected = true;
    var ddlOutSecd = document.getElementById("ddlOutSecd");
    ddlOutSecd.options[0].selected = true;
}
function submit_value11() {
    var txt_NomineeNm = document.getElementById("txt_NomineeNm");
    if (txt_NomineeNm.value == "") {
        window.alert("Enter Nominee Name.");
        txt_NomineeNm.focus();
        return false;
    }

    var txtNm_relation = document.getElementById("txtNm_relation");
    if (txtNm_relation.value == "") {
        window.alert("Enter Nominee Relation.");
        txtNm_relation.focus();
        return false;
    }

    var txtnm_Address = document.getElementById("txtnm_Address");
    if (txtnm_Address.value == "") {
        window.alert("Enter Nominee Address.");
        txtnm_Address.focus();
        return false;
    }

    var txt_nm_age = document.getElementById("txt_nm_age");
    if (txt_nm_age.value == "") {
        window.alert("Enter Nominee Date of Birth.");
        txt_nm_age.focus();
        return false;
    }

    var txtnm_bank = document.getElementById("txtnm_bank");
    if (txtnm_bank.value == "") {
        window.alert("Enter Bank Name.");
        txtnm_bank.focus();
        return false;
    }

    var txtnm_actno = document.getElementById("txtnm_actno");
    if (txtnm_actno.value == "") {
        window.alert("Enter Bank Account Number.");
        txtnm_actno.focus();
        return false;
    }

    var txtNm_ifsc = document.getElementById("txtNm_ifsc");
    if (txtNm_ifsc.value == "") {
        window.alert("Enter Bank IFSC Code.");
        txtNm_ifsc.focus();
        return false;
    }

    Calender_details.insert_emloyee_nominee_details(empidinserted,txt_NomineeNm.value, txtNm_relation.value, txtnm_Address.value, txt_nm_age.value, txtnm_bank.value,txtnm_actno.value, txtNm_ifsc.value, Fill_emplyee_nominee_details);
}

function Fill_emplyee_nominee_details(result) {
    if (result > 0) {
        var Div15 = document.getElementById("Div15");
        Div15.style.borderColor = "#868A08";
        Div15.style.backgroundColor = "#D7DF01";
        Div15.style.color = "#8A0808";
        var Div16 = document.getElementById("Div16");
        Div16.style.borderColor = "#868A08";
        Div16.style.backgroundColor = "#D7DF01";
        var div_basic_salary_details = document.getElementById("div_basic_salary_details");
        div_basic_salary_details.style.display = "none";
        var Img2 = document.getElementById("Img2");
        Img2.style.display = "none";
        var Img3 = document.getElementById("Img3");
        Img3.style.display = "none";
        var div_timing_details = document.getElementById("div_timing_details");
        div_timing_details.style.display = "none";
        var Div17 = document.getElementById("Div17");
        Div17.style.borderColor = "#868A08";
        Div17.style.backgroundColor = "#D7DF01";
        Div17.style.color = "#8A0808";
        var Img4 = document.getElementById("Img4");
        Img4.style.display = "none";
        var Img3 = document.getElementById("Img3");
        Img3.style.display = "none";
        Img3.style.display = "none";
        var nominee_details = document.getElementById("nominee_details");
        nominee_details.style.display = "none";
        var Div18 = document.getElementById("Div18");
        Div18.style.borderColor = "#868A08";
        Div18.style.backgroundColor = "#D7DF01";
        var Div19 = document.getElementById("Div19");
        Div19.style.borderColor = "#868A08";
        Div19.style.backgroundColor = "#D7DF01";
        Div19.style.color = "#8A0808";
        var btn_nominee_sv = document.getElementById("btn_nominee_sv");
        btn_nominee_sv.style.display = "none";
        var btn_nominee_rs = document.getElementById("btn_nominee_rs");
        btn_nominee_rs.style.display = "none";
        var Bank_Details = document.getElementById("Bank_Details");
        Bank_Details.style.display = "block";
        var txt_BankName = document.getElementById("txt_BankName");
        txt_BankName.focus();
       
    }
}

function reset_value11() {
    var txt_NomineeNm = document.getElementById("txt_NomineeNm");
    txt_NomineeNm.value = "";
    var txtNm_relation = document.getElementById("txtNm_relation");
    txtNm_relation.value = "";
    var txtnm_Address = document.getElementById("txtnm_Address");
    txtnm_Address.value = "";
    var txt_nm_age = document.getElementById("txt_nm_age");
    txt_nm_age.value = "";
    var txtnm_bank = document.getElementById("txtnm_bank");
    txtnm_bank.value = "";
    var txtnm_actno = document.getElementById("txtnm_actno");
    txtnm_actno.value = "";
    var txtNm_ifsc = document.getElementById("txtNm_ifsc");
    txtNm_ifsc.value = "";
}

function submit_value12() {
    var txt_BankName = document.getElementById("txt_BankName");
    if (txt_BankName.value == "") {
        window.alert("Enter Bank Name.");
        txt_BankName.focus();
        return false;
    }

    var txt_branchName = document.getElementById("txt_branchName");
    if (txt_branchName.value == "") {
        window.alert("Enter Bank Branch Name.");
        txt_branchName.focus();
        return false;
    }

    var txt_IFSCCode = document.getElementById("txt_IFSCCode");
    if (txt_IFSCCode.value == "") {
        window.alert("Enter IFSC Code.");
        txt_IFSCCode.focus();
        return false;
    }

    var txt_AccountNo = document.getElementById("txt_AccountNo");
    if (txt_AccountNo.value == "") {
        window.alert("Enter Account Number.");
        txt_AccountNo.focus();
        return false;
    }

    Calender_details.insert_emloyee_bank_details(empidinserted, txt_BankName.value, txt_branchName.value, txt_IFSCCode.value, txt_AccountNo.value,  Fill_emplyee_bank_details);
}

function Fill_emplyee_bank_details(result) {
    if (result > 0) {

        location.href = "NewEmpMaster.aspx";
    }
}

function reset_value12() {
    var txt_BankName = document.getElementById("txt_BankName");
    txt_BankName.value = "";
    var txt_branchName = document.getElementById("txt_branchName");
    txt_branchName.value = "";
    var txt_IFSCCode = document.getElementById("txt_IFSCCode");
    txt_IFSCCode.value = "";
    var txt_AccountNo = document.getElementById("txt_AccountNo");
    txt_AccountNo.value = "";
}


function isNumber(evt) {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    return true;
}

    function onlyAlphabets(e, t) {
        try {
            if (window.event) {
                var charCode = window.event.keyCode;
            }
            else if (e) {
                var charCode = e.which;
            }
            else { return true; }
            if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123))
                return true;
            else
                return false;
        }
        catch (err) {
            alert(err.Description);
        }
    }

    function show_profile1() {
        var empprofile1 = document.getElementById("empprofile1");
        empprofile1.style.display = "block";
        var empprofile2 = document.getElementById("empprofile2");
        empprofile2.style.display = "none";
        var Div6 = document.getElementById("Div6");
        Div6.style.display = "none";
        var Div7 = document.getElementById("Div7");
        Div7.style.display = "none";
        var Div8 = document.getElementById("Div8");
        Div8.style.display = "none";
        var Div_confirmation = document.getElementById("Div_confirmation");
        Div_confirmation.style.display = "none";
        var ddlEmpTitle = document.getElementById("ddlEmpTitle");
        ddlEmpTitle.focus();
        var div_basic_salary_details = document.getElementById("div_basic_salary_details");
        div_basic_salary_details.style.display = "none";
        var div_timing_details = document.getElementById("div_timing_details");
        div_timing_details.style.display = "none";
        var nominee_details = document.getElementById("nominee_details");
        nominee_details.style.display = "none";
        var Bank_Details = document.getElementById("Bank_Details");
        Bank_Details.style.display = "none";
    }

    function show_profile2() {
        var empprofile1 = document.getElementById("empprofile1");
        empprofile1.style.display = "none";
        var empprofile2 = document.getElementById("empprofile2");
        empprofile2.style.display = "block";
        var Div6 = document.getElementById("Div6");
        Div6.style.display = "none";
        var Div7 = document.getElementById("Div7");
        Div7.style.display = "none";
        var Div8 = document.getElementById("Div8");
        Div8.style.display = "none";
        var Div_confirmation = document.getElementById("Div_confirmation");
        Div_confirmation.style.display = "none";
        var ddlBloodGrp = document.getElementById("ddlBloodGrp");
        ddlBloodGrp.focus();
        var div_basic_salary_details = document.getElementById("div_basic_salary_details");
        div_basic_salary_details.style.display = "none";
        var div_timing_details = document.getElementById("div_timing_details");
        div_timing_details.style.display = "none";
        var nominee_details = document.getElementById("nominee_details");
        nominee_details.style.display = "none";
        var Bank_Details = document.getElementById("Bank_Details");
        Bank_Details.style.display = "none";
    

    }

    function show_profile3() {
        var empprofile1 = document.getElementById("empprofile1");
        empprofile1.style.display = "none";
        var empprofile2 = document.getElementById("empprofile2");
        empprofile2.style.display = "none";
        var Div6 = document.getElementById("Div6");
        Div6.style.display = "block";
        var Div7 = document.getElementById("Div7");
        Div7.style.display = "none";
        var Div8 = document.getElementById("Div8");
        Div8.style.display = "none";
        var Div_confirmation = document.getElementById("Div_confirmation");
        Div_confirmation.style.display = "none";
        var txtWEDAcademic = document.getElementById("txtWEDAcademic");
        txtWEDAcademic.focus();
        var div_basic_salary_details = document.getElementById("div_basic_salary_details");
        div_basic_salary_details.style.display = "none";
        var div_timing_details = document.getElementById("div_timing_details");
        div_timing_details.style.display = "none";
        var nominee_details = document.getElementById("nominee_details");
        nominee_details.style.display = "none";
        var Bank_Details = document.getElementById("Bank_Details");
        Bank_Details.style.display = "none";
    }

    function show_profile4() {
        var empprofile1 = document.getElementById("empprofile1");
        empprofile1.style.display = "none";
        var empprofile2 = document.getElementById("empprofile2");
        empprofile2.style.display = "none";
        var Div6 = document.getElementById("Div6");
        Div6.style.display = "none";
        var Div7 = document.getElementById("Div7");
        Div7.style.display = "block";
        var Div8 = document.getElementById("Div8");
        Div8.style.display = "none";
        var Div_confirmation = document.getElementById("Div_confirmation");
        Div_confirmation.style.display = "none";
        var ddl_year = document.getElementById("ddl_year");
        ddl_year.focus();
        var div_basic_salary_details = document.getElementById("div_basic_salary_details");
        div_basic_salary_details.style.display = "none";
        var div_timing_details = document.getElementById("div_timing_details");
        div_timing_details.style.display = "none";
        var nominee_details = document.getElementById("nominee_details");
        nominee_details.style.display = "none";
        var Bank_Details = document.getElementById("Bank_Details");
        Bank_Details.style.display = "none";
    }

    function show_profile5() {
        var empprofile1 = document.getElementById("empprofile1");
        empprofile1.style.display = "none";
        var empprofile2 = document.getElementById("empprofile2");
        empprofile2.style.display = "none";
        var Div6 = document.getElementById("Div6");
        Div6.style.display = "none";
        var Div7 = document.getElementById("Div7");
        Div7.style.display = "none";
        var Div8 = document.getElementById("Div8");
        Div8.style.display = "block";
        var Div_confirmation = document.getElementById("Div_confirmation");
        Div_confirmation.style.display = "none";
        var txtPermAdd = document.getElementById("txtPermAdd");
        txtPermAdd.focus();
        var div_basic_salary_details = document.getElementById("div_basic_salary_details");
        div_basic_salary_details.style.display = "none";
        var div_timing_details = document.getElementById("div_timing_details");
        div_timing_details.style.display = "none";
        var nominee_details = document.getElementById("nominee_details");
        nominee_details.style.display = "none";
        var Bank_Details = document.getElementById("Bank_Details");
        Bank_Details.style.display = "none";
    }

    function show_profile7() {
        var empprofile1 = document.getElementById("empprofile1");
        empprofile1.style.display = "none";
        var empprofile2 = document.getElementById("empprofile2");
        empprofile2.style.display = "none";
        var Div6 = document.getElementById("Div6");
        Div6.style.display = "none";
        var Div7 = document.getElementById("Div7");
        Div7.style.display = "none";
        var Div8 = document.getElementById("Div8");
        Div8.style.display = "none";
        var Div_confirmation = document.getElementById("Div_confirmation");
        Div_confirmation.style.display = "block";
        var div_basic_salary_details = document.getElementById("div_basic_salary_details");
        div_basic_salary_details.style.display = "none";
        var div_timing_details = document.getElementById("div_timing_details");
        div_timing_details.style.display = "none";
        var nominee_details = document.getElementById("nominee_details");
        nominee_details.style.display = "none";
        var Bank_Details = document.getElementById("Bank_Details");
        Bank_Details.style.display = "none";
    }

    function show_profile8() {
        var empprofile1 = document.getElementById("empprofile1");
        empprofile1.style.display = "none";
        var empprofile2 = document.getElementById("empprofile2");
        empprofile2.style.display = "none";
        var Div6 = document.getElementById("Div6");
        Div6.style.display = "none";
        var Div7 = document.getElementById("Div7");
        Div7.style.display = "none";
        var Div8 = document.getElementById("Div8");
        Div8.style.display = "none";
        var Div_confirmation = document.getElementById("Div_confirmation");
        Div_confirmation.style.display = "none";
        var div_basic_salary_details = document.getElementById("div_basic_salary_details");
        div_basic_salary_details.style.display = "block";

        var txtWED = document.getElementById("txtWED");
        txtWED.focus();
        var div_timing_details = document.getElementById("div_timing_details");
        div_timing_details.style.display = "none";
        var Bank_Details = document.getElementById("Bank_Details");
        Bank_Details.style.display = "none";
        var nominee_details = document.getElementById("nominee_details");
        nominee_details.style.display = "none";

    }

    function show_profile9() {
        var empprofile1 = document.getElementById("empprofile1");
        empprofile1.style.display = "none";
        var empprofile2 = document.getElementById("empprofile2");
        empprofile2.style.display = "none";
        var Div6 = document.getElementById("Div6");
        Div6.style.display = "none";
        var Div7 = document.getElementById("Div7");
        Div7.style.display = "none";
        var Div8 = document.getElementById("Div8");
        Div8.style.display = "none";
        var Div_confirmation = document.getElementById("Div_confirmation");
        Div_confirmation.style.display = "none";
        var div_basic_salary_details = document.getElementById("div_basic_salary_details");
        div_basic_salary_details.style.display = "none";
        var div_timing_details = document.getElementById("div_timing_details");
        div_timing_details.style.display = "block";
        var nominee_details = document.getElementById("nominee_details");
        nominee_details.style.display = "none";
        var Bank_Details = document.getElementById("Bank_Details");
        Bank_Details.style.display = "none";
        var txtWEDTiming = document.getElementById("txtWEDTiming");
        txtWEDTiming.focus();
        
    }
    function show_profile10() {
        var empprofile1 = document.getElementById("empprofile1");
        empprofile1.style.display = "none";
        var empprofile2 = document.getElementById("empprofile2");
        empprofile2.style.display = "none";
        var Div6 = document.getElementById("Div6");
        Div6.style.display = "none";
        var Div7 = document.getElementById("Div7");
        Div7.style.display = "none";
        var Div8 = document.getElementById("Div8");
        Div8.style.display = "none";
        var Div_confirmation = document.getElementById("Div_confirmation");
        Div_confirmation.style.display = "none";
        var div_basic_salary_details = document.getElementById("div_basic_salary_details");
        div_basic_salary_details.style.display = "none";
        var div_timing_details = document.getElementById("div_timing_details");
        div_timing_details.style.display = "none";
        var nominee_details = document.getElementById("nominee_details");
        nominee_details.style.display = "block";
        var Bank_Details = document.getElementById("Bank_Details");
        Bank_Details.style.display = "none";
        var txt_NomineeNm = document.getElementById("txt_NomineeNm");
        txt_NomineeNm.focus();
    }

    function show_profile11() {
        var empprofile1 = document.getElementById("empprofile1");
        empprofile1.style.display = "none";
        var empprofile2 = document.getElementById("empprofile2");
        empprofile2.style.display = "none";
        var Div6 = document.getElementById("Div6");
        Div6.style.display = "none";
        var Div7 = document.getElementById("Div7");
        Div7.style.display = "none";
        var Div8 = document.getElementById("Div8");
        Div8.style.display = "none";
        var Div_confirmation = document.getElementById("Div_confirmation");
        Div_confirmation.style.display = "none";
        var div_basic_salary_details = document.getElementById("div_basic_salary_details");
        div_basic_salary_details.style.display = "none";
        var div_timing_details = document.getElementById("div_timing_details");
        div_timing_details.style.display = "none";
        var nominee_details = document.getElementById("nominee_details");
        nominee_details.style.display = "none";
        var Bank_Details = document.getElementById("Bank_Details");
        Bank_Details.style.display = "block";
        var txt_BankName = document.getElementById("txt_BankName");
        txt_BankName.focus();
    }

    function country_onchange() {
        var ddlCountryP = document.getElementById("ddlCountryP");
        var ddlCountryP_value1 = ddlCountryP.options[ddlCountryP.selectedIndex].value;
        Calender_details.BindState_value(ddlCountryP_value1, Fill_State);
    }

    function Fill_State(result) {
        var xml = parseXml(result);
        if (xml) {
            bindstate_dll(xml.documentElement);
        }
    }

    function bindstate_dll(DistNode) {

        var ddlStateP = document.getElementById("ddlStateP");
        for (var count = ddlStateP.options.length - 1; count > -1; count--) {
            ddlStateP.options[count] = null;
        }
        var val;
        var desc;
        var optionitem;
        val = "0";
        desc = "----Select----"; ;
        optionitem = new Option(desc, val, false, false);
        ddlStateP.options[ddlStateP.length] = optionitem;

        var IdNode = DistNode.getElementsByTagName('StateId');
        var DescNode = DistNode.getElementsByTagName('StateName');

        for (var count1 = 0; count1 < IdNode.length; count1++) {
            val = GetInnerText(IdNode[count1]);
            desc = GetInnerText(DescNode[count1]);
            optionitem = new Option(desc, val, false, false);
            ddlStateP.options[ddlStateP.length] = optionitem;
        }

        ddlStateP.options[0].selected = true;
    }

    function state_onchange() {
        var ddlStateP = document.getElementById("ddlStateP");
        var ddlStateP_value1 = ddlStateP.options[ddlStateP.selectedIndex].value;
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

    function country_onchange1() {
        var ddl_countryl = document.getElementById("ddl_countryl");
        var ddl_countryl_value1 = ddl_countryl.options[ddl_countryl.selectedIndex].value;
        Calender_details.BindState_value(ddl_countryl_value1, Fill_State1);
    }

    function Fill_State1(result) {
        var xml = parseXml(result);
        if (xml) {
            bindstate_dll1(xml.documentElement);
        }
    }

    function bindstate_dll1(DistNode) {

        var ddl_statel = document.getElementById("ddl_statel");
        for (var count = ddl_statel.options.length - 1; count > -1; count--) {
            ddl_statel.options[count] = null;
        }
        var val;
        var desc;
        var optionitem;
        val = "0";
        desc = "----Select----"; ;
        optionitem = new Option(desc, val, false, false);
        ddl_statel.options[ddl_statel.length] = optionitem;

        var IdNode = DistNode.getElementsByTagName('StateId');
        var DescNode = DistNode.getElementsByTagName('StateName');

        for (var count1 = 0; count1 < IdNode.length; count1++) {
            val = GetInnerText(IdNode[count1]);
            desc = GetInnerText(DescNode[count1]);
            optionitem = new Option(desc, val, false, false);
            ddl_statel.options[ddl_statel.length] = optionitem;
        }
        ddl_statel.options[0].selected = true;
    }

    function state_onchange1() {
        var ddl_statel = document.getElementById("ddl_statel");
        var ddl_statel_value1 = ddl_statel.options[ddl_statel.selectedIndex].value;
        Calender_details.Bindcity_value(ddl_statel_value1, Fill_City1);
    }
    function Fill_City1(result) {
        var xml = parseXml(result);
        if (xml) {
            bindcity_dll1(xml.documentElement);
        }
    }

    function bindcity_dll1(DistNode) {

        var ddl_cityl = document.getElementById("ddl_cityl");
        for (var count = ddl_cityl.options.length - 1; count > -1; count--) {
            ddl_cityl.options[count] = null;
        }
        var val;
        var desc;
        var optionitem;
        val = "0";
        desc = "----Select----"; ;
        optionitem = new Option(desc, val, false, false);
        ddl_cityl.options[ddl_cityl.length] = optionitem;
        var IdNode = DistNode.getElementsByTagName('CityId');
        var DescNode = DistNode.getElementsByTagName('CityName');

        for (var count1 = 0; count1 < IdNode.length; count1++) {
            val = GetInnerText(IdNode[count1]);
            desc = GetInnerText(DescNode[count1]);
            optionitem = new Option(desc, val, false, false);
            ddl_cityl.options[ddl_cityl.length] = optionitem;
        }
        ddl_cityl.options[0].selected = true;
    }

    function address_onchage() {

        var chkAddr = document.getElementById("chkAddr");
        var txtPermAdd = document.getElementById("txtPermAdd");
        var txt_phaddl = document.getElementById("txt_phaddl");
        var txtZipP = document.getElementById("txtZipP");
        var txt_zipcodel = document.getElementById("txt_zipcodel");
        var txtPhP = document.getElementById("txtPhP");
        var TextBox5 = document.getElementById("TextBox5");
        var txtEmailP = document.getElementById("txtEmailP");
        var txt_emailidl = document.getElementById("txt_emailidl");
        var txtMobP = document.getElementById("txtMobP");
        var TextBox7 = document.getElementById("TextBox7");
        var ddlCountryP = document.getElementById("ddlCountryP");
        var ddlCountryP_value1 = ddlCountryP.selectedIndex;
        var ddlCountryP_value2 = ddlCountryP.options[ddlCountryP.selectedIndex].value;
        var ddl_countryl = document.getElementById("ddl_countryl");
        var ddl_cityl = document.getElementById("ddl_cityl");
        var ddl_statel = document.getElementById("ddl_statel");

        if (chkAddr.checked == true) {
            txt_phaddl.value = txtPermAdd.value;
            txt_zipcodel.value = txtZipP.value;
            TextBox5.value = txtPhP.value;
            txt_emailidl.value = txtEmailP.value;
            TextBox7.value = txtMobP.value;
            ddl_countryl.options[ddlCountryP_value1].selected = true;
            if (ddl_countryl_value2 != "0") {
                var ddl_countryl_value2 = ddl_countryl.options[ddl_countryl.selectedIndex].value;
                Calender_details.BindState_value(ddl_countryl_value2, Fill_State2);
            }
        }
        else {
            txt_phaddl.value = "";
            ddl_countryl.options[0].selected = true;
            ddl_statel.options[0].selected = true;
            ddl_cityl.options[0].selected = true;
            txt_zipcodel.value = "";
            TextBox5.value = "";
            txt_emailidl.value = "";
            TextBox7.value = ""
        }
    }

    function Fill_State2(result) {
        var xml = parseXml(result);
        if (xml) {
            bindstate_dll2(xml.documentElement);
        }
    }

    function bindstate_dll2(DistNode) {

        var ddl_statel = document.getElementById("ddl_statel");
        for (var count = ddl_statel.options.length - 1; count > -1; count--) {
            ddl_statel.options[count] = null;
        }
        var val;
        var desc;
        var optionitem;
        val = "0";
        desc = "----Select----"; ;
        optionitem = new Option(desc, val, false, false);
        ddl_statel.options[ddl_statel.length] = optionitem;

        var IdNode = DistNode.getElementsByTagName('StateId');
        var DescNode = DistNode.getElementsByTagName('StateName');

        for (var count1 = 0; count1 < IdNode.length; count1++) {
            val = GetInnerText(IdNode[count1]);
            desc = GetInnerText(DescNode[count1]);
            optionitem = new Option(desc, val, false, false);
            ddl_statel.options[ddl_statel.length] = optionitem;
        }
        var ddlStateP = document.getElementById("ddlStateP");
        var ddlStateP_value1 = ddlStateP.selectedIndex;
        ddl_statel.options[ddlStateP_value1].selected = true;
        var ddl_statel_value1 = ddl_statel.options[ddl_statel.selectedIndex].value;
        if (ddl_statel_value1 != "0") {
            Calender_details.Bindcity_value(ddl_statel_value1, Fill_City2);
        }
    }

    function Fill_City2(result) {
        var xml = parseXml(result);
        if (xml) {
            bindcity_dll2(xml.documentElement);
        }
    }

    function bindcity_dll2(DistNode) {

        var ddl_cityl = document.getElementById("ddl_cityl");
        for (var count = ddl_cityl.options.length - 1; count > -1; count--) {
            ddl_cityl.options[count] = null;
        }
        var val;
        var desc;
        var optionitem;
        val = "0";
        desc = "----Select----"; ;
        optionitem = new Option(desc, val, false, false);
        ddl_cityl.options[ddl_cityl.length] = optionitem;
        var IdNode = DistNode.getElementsByTagName('CityId');
        var DescNode = DistNode.getElementsByTagName('CityName');

        for (var count1 = 0; count1 < IdNode.length; count1++) {
            val = GetInnerText(IdNode[count1]);
            desc = GetInnerText(DescNode[count1]);
            optionitem = new Option(desc, val, false, false);
            ddl_cityl.options[ddl_cityl.length] = optionitem;
        }
        var ddlCityP = document.getElementById("ddlCityP");
        var ddlCityP_value1 = ddlCityP.selectedIndex;
        ddl_cityl.options[ddlCityP_value1].selected = true;
    }

    function industry_onchange() {
        var ddl_industry = document.getElementById("ddl_industry");
        var ddl_industry_value1 = ddl_industry.options[ddl_industry.selectedIndex].value;
        Calender_details.Bindfunation_value(ddl_industry_value1, Fill_function);
    }

    function Fill_function(result) {
        var xml = parseXml(result);
        if (xml) {
            bindfunction_dll(xml.documentElement);
        }
    }

    function bindfunction_dll(DistNode) {

        var ddl_function = document.getElementById("ddl_function");
        for (var count = ddl_function.options.length - 1; count > -1; count--) {
            ddl_function.options[count] = null;
        }
        var val;
        var desc;
        var optionitem;
        val = "0";
        desc = "----Select----"; ;
        optionitem = new Option(desc, val, false, false);
        ddl_function.options[ddl_function.length] = optionitem;
        var IdNode = DistNode.getElementsByTagName('function_id');
        var DescNode = DistNode.getElementsByTagName('funcation_name');
        for (var count1 = 0; count1 < IdNode.length; count1++) {
            val = GetInnerText(IdNode[count1]);
            desc = GetInnerText(DescNode[count1]);
            optionitem = new Option(desc, val, false, false);
            ddl_function.options[ddl_function.length] = optionitem;
        }
        ddl_function.options[0].selected = true;
    }
    function ddlyear_onchange() {

        var ddl_year = document.getElementById("ddl_year");
        var ddl_year_value1 = ddl_year.selectedIndex;
        var ddl_month = document.getElementById("ddl_month");
        var ddl_year_value2 = ddl_year.options[ddl_year.selectedIndex].value;
        if (ddl_year_value2 == "F") {
            ddl_month.options[ddl_year_value1].selected = true;
        }
        else {
            ddl_month.options[0].selected = true;
        }
    }

    function nature_onchange() {

        var ddlNature = document.getElementById("ddlNature");
        var ddlNature_value2 = ddlNature.options[ddlNature.selectedIndex].value;
        var ddldept = document.getElementById("ddldept");
        var ddldept_value2 = ddldept.options[ddldept.selectedIndex].value;
        if (ddldept_value2 != "0") {
            Calender_details.BindDegination_value(ddlNature_value2, ddldept_value2, Fill_Degisnation);
        }
    }


    function dept_onchange() {

        var ddlNature = document.getElementById("ddlNature");
        var ddlNature_value2 = ddlNature.options[ddlNature.selectedIndex].value;
        var ddldept = document.getElementById("ddldept");
        var ddldept_value2 = ddldept.options[ddldept.selectedIndex].value;
        if (ddlNature_value2 != "0") {
            Calender_details.BindDegination_value(ddlNature_value2, ddldept_value2, Fill_Degisnation);
        }
    }

    function Fill_Degisnation(result) {
        var xml = parseXml(result);
        if (xml) {
            binddegination_dll(xml.documentElement);
        }
    }

    function binddegination_dll(DistNode) {

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

    function get_emplyee_value() {
        var txt = document.getElementById("txtSearch0");
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
        var tbt = document.createElement("TBODY");
        element.appendChild(tbt);

        var txt = document.getElementById("txtSearch0");
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
                var td2 = document.createElement("TD");
                td2.appendChild(document.createTextNode(empname1));
                var td3 = document.createElement("TD");
                td3.appendChild(document.createTextNode(empcode1));
                td3.style.display = "none";
                row.appendChild(td2);
                row.appendChild(td3);
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
            var empname1 ="No Record Found"
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
            var lbl_slno = document.getElementById("txtSearch0");
            lbl_slno.value = "";
        }
        else {
            var lbl_slno = document.getElementById("txtSearch0");
            lbl_slno.value = GetInnerText(tds[0]) + " (" + GetInnerText(tds[1]) + ")"; 
        }
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

