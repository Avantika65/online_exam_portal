
var final1 = "";
var Qualification = "";

function HideText(cntrid) {

    var value = cntrid.substring(0, 35);
    var txttMarks = document.getElementById(value + "txtTotalMarks");
    var txtobtmarks = document.getElementById(value + "txtObtMarks");
    var txtper = document.getElementById(value + "txtRank");
    var radilist = document.getElementById(value + "rdboption");
    var rad = radilist.getElementsByTagName("input");
    if (rad[1].checked == true) {
       
        txttMarks.style.display = "none";
        txtobtmarks.style.display = "none";
        txtper.setAttribute("style", "disabled:enabled");
        
    }

    else
    {
        txttMarks.style.display = "block";
        txtobtmarks.style.display = "block";
        txtper.setAttribute("style", "disabled:disabled");
    }
}

function Check_Per(CntrID) {

    var value = CntrID.substring(0, 35);
    var txtper = document.getElementById(value + "txtRank");    
    if (Number(txtper.value) > Number(100)) {
        window.alert("Total percentage can not be more than 100..!!");
        txtper.value = "";
        setTimeout(function () { txtper.focus(); }, 1);
        return false;
    }
}
function percentage_Calculator(cltid) {   
    var value = cltid.substring(0, 35);    
    final1 = value;
    var first_valu = document.getElementById(value + "txtTotalMarks");
    var second_valu = document.getElementById(value + "txtObtMarks");
    var radilist = document.getElementById(value + "rdboption");
    var rad = radilist.getElementsByTagName("input");      
    var calulate_val = "";
    if (rad[0].checked == true) {
        if (Number(second_valu.value) > Number(first_valu.value)) {
            window.alert("Obtained marks can not be more than total marks e.g. " + first_valu.value + "  ");
            second_valu.value = "";
            setTimeout(function () { second_valu.focus(); }, 1);
            return false;
        }
        calulate_val = Number(second_valu.value) / Number(first_valu.value) * 100;
    }
    else {

        first_valu.value = 10;
        if (Number(second_valu.value) > Number(first_valu.value)) {
            window.alert("Obtained CGPA can not be more than " + first_valu.value + "  ");
            second_valu.value = "";
            setTimeout(function () { second_valu.focus(); }, 1);
            return false;
        }
        calulate_val = Number(second_valu.value) * 9.5;
    }
    var final = document.getElementById(value + "txtRank");
    final.value = calulate_val;


}


function Enable_Disable_Fileupload(id) {

    var ControlID = id.substring(0, 18);
    var ddlID = document.getElementById(ControlID + "ddlOption");
    var FileUpload = document.getElementById(ControlID + "FileUpload1");
    var ddlValue = ddlID.options[ddlID.selectedIndex].text;
    if (ddlValue == 'Yes') {
        FileUpload.disabled = false;
    }
    else if (ddlValue == 'No') {
        FileUpload.disabled = true;
    }
    else if (ddlValue == 'Not-Submitted') {
        FileUpload.disabled = true;
    }
    else if (ddlValue == 'Not-Applicable') {
        FileUpload.disabled = true;
    }
    else {
        FileUpload.disabled = false;
    }
}
function IntegerNumber() {

    if ((window.event.keyCode < 46) || (window.event.keyCode > 57) || (window.event.keyCode == 47)) {
        window.event.keyCode = 0;
    }
}

function Enable_Disable_FU(ddlid, FU_ID) {

    var ddl_ID = document.getElementById(ddlid);
    var ddl_SelectedValue = ddl_ID.options[ddl_ID.selectedIndex].value
    if (ddl_SelectedValue == 1) {
        var FileUP_ID = document.getElementById(FU_ID);
        FileUP_ID.disabled = false;
    }
    else {
        var FileUP_ID = document.getElementById(FU_ID);
        FileUP_ID.disabled = true;
    }

}

function Enable_Disable_FU_SubCat(ddlid, FU_ID) {

    var ddl_ID = document.getElementById(ddlid);
    var ddl_SelectedValue = ddl_ID.options[ddl_ID.selectedIndex].value
    if (ddl_SelectedValue == 1 || ddl_SelectedValue == 2 || ddl_SelectedValue == 3) {
        var FileUP_ID = document.getElementById(FU_ID);
        FileUP_ID.disabled = false;
    }
    else {
        var FileUP_ID = document.getElementById(FU_ID);
        FileUP_ID.disabled = true;
    }

}

function Validation() {

    var grd = document.getElementById("grdDocument");

    var Row1 = grd.rows[1];
    var FileUp_Row1 = Row1.cells[2].childNodes[1].files[0];

    var Row2 = grd.rows[2];
    var FileUp_Row2 = Row2.cells[2].childNodes[1].files[0];

    var Row3 = grd.rows[3];
    var FileUp_Row3 = Row3.cells[2].childNodes[1].files[0];

    var Row4 = grd.rows[4];
    var FileUp_Row4 = Row4.cells[2].childNodes[1].files[0];

    if (!FileUp_Row1) {
        alert("Please Select & Upload proof of High School[10th standard]..!!");
        //return false;
    }

    else if (!FileUp_Row2) {
        alert("Please Select & Upload proof of Intermediate[12th standard]..!!");
        //return false;
    }
    else if (!FileUp_Row3) {
        alert("Please Select & Upload proof of Graduation..!!");
        //return false;
    }

    else if (!FileUp_Row4) {
        alert("Please Select & Upload proof of Entrance Score Card..!!");
        //return false;
    }

    else {
        $get('btnSubmit').click();
    }

}


function ValidateMandatoty() {

    var HS_ddl_ID = document.getElementById('ddlHSProof'); 
    var IM_ddl_ID = document.getElementById('ddlIntProof');
    var Grad_ddl_ID = document.getElementById('ddlGradProof');
    var ES_ddl_ID = document.getElementById('ddlAllotmentLettr');
    if (HS_ddl_ID.options[HS_ddl_ID.selectedIndex].value == 0) {
        alert("Please Select & Upload proof of High School[10th standard]..!!");
        return false;
    }

    else if (IM_ddl_ID.options[IM_ddl_ID.selectedIndex].value == 0) {
        alert("Please Select & Upload proof of Intermediate[12th standard]..!!");
        return false;
    }
    else if (Grad_ddl_ID.options[Grad_ddl_ID.selectedIndex].value == 0) {
        alert("Please Select & Upload proof of Graduation..!!");
        return false;
    }

    else if (ES_ddl_ID.options[ES_ddl_ID.selectedIndex].value == 0) {
        alert("Please Select & Upload proof of Entrance Score Card..!!");
        return false;
    }

    else {        
        $get('btnSubmit').click();
    }
}
