
var Count = 0;
var TotalObt = 0;
var pwd = "";
var CountPass = "";
var CountFail = "";
var CountPWG = "";

function Result_Calculator(cltid) {

    var ttlstu = 0;
    var pwgstu = 0;
    var failstu = 0;
    var passStu = 0;

    var value1 = cltid.substring(0, 31);
    var value2 = cltid.substring(0, 16);
    var value3 = cltid.substring(0, 28);

    var lbltlStu = document.getElementById("ttlStudent");
    var lblpasStu = document.getElementById("lblPassStudent");
    var lblpwgStu = document.getElementById("lblPwgStu");
    var lblFailStu = document.getElementById("lblFailStu");


    var grd = document.getElementById("gvStudent");
    
    var ddlSub_id = document.getElementById("ddlSubject");
    var Stu_id = document.getElementById(value2 + "lblStu");
    var Critria = document.getElementById(value2 + "lblCri");
    var subid = ddlSub_id.options[ddlSub_id.selectedIndex].value;

    Calender_details.Get_ID(Stu_id.innerHTML, subid, getdata1);
    var MaxMarks = document.getElementById(value2 + "lblMarks");
    var ObtMarks = document.getElementById(value2 + "txtMarks");
    var Result = document.getElementById(value2 + "ddlStatus");
    var Grace = document.getElementById("lblGrace");


    function getdata1(result)
     {

        pwd = result;
        if (Number(ObtMarks.value) > Number(MaxMarks.innerText))
         {
            window.alert("Obtain marks can not be more than maximum marks e.g. " + MaxMarks.innerText + " ..!!");
            ObtMarks.value = "";
            setTimeout(function () { ObtMarks.focus(); }, 1);
            return false;
         }

        else
         {
             if (Number(ObtMarks.value) >= Number(Critria.innerText))
             {
                Result.value = "3";                
             }
            else if (Number(ObtMarks.value) < Number(Critria.innerText))
             {

                 if (Number(ObtMarks.value) + Number(Grace.innerText) >= Number(Critria.innerText) && pwd == '')
                {
                    Result.value = "6";                 
                    
                }
                else
                 {
                    Result.value = "4";               
                    
                 }
              }
          }

        for (var i = 1; i <= grd.rows.length - 1; i++) 
        {

            var currRow = grd.rows[i];

            var selectedIndex = currRow.cells[5].childNodes[1].selectedIndex;

            if (selectedIndex == 4)
                pwgstu = Number(pwgstu) + 1;
            if (selectedIndex == 2)
                failstu = Number(failstu) + 1;
            if (selectedIndex == 1)
                passStu = Number(passStu) + 1;
            lbltlStu.innerText = Number(grd.rows.length) - 1;
            lblpasStu.innerText = passStu;
            lblpwgStu.innerText = pwgstu;
            lblFailStu.innerText = failstu;
         }
    }


}




function CheckForMarksEntry(cltid) {

    var value1 = cltid.substring(0, 16);
    var MaxMarks = document.getElementById("Label2");
    var ObtMarks = document.getElementById(value1 + "Txtmarks");
    if (Number(ObtMarks.value) > Number(MaxMarks.value)) {
        window.alert("Obtain marks can not be more than maximum marks e.g. " + MaxMarks.value + " ..!!");
        ObtMarks.value = 0;
        setTimeout(function () { ObtMarks.focus(); }, 1);
        return false;
    }

    if (ObtMarks.value == "") {
        window.alert("plesae enter Obtain marks..!!");
        ObtMarks.value = 0;
        setTimeout(function () { ObtMarks.focus(); }, 1);
        return false;
    }
}