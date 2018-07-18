

var Count = 0;
var TotalObt = 0;
var pwd = "";

function Result_Calculator(cltid) {
    var ttlstu = 0;
    var pwgstu = 0;
    var failstu = 0;
    var passStu = 0;
    var value1 = cltid.substring(0, 16);
    
    

    var lbltlStu = document.getElementById("ttlStudent");
    var lblpasStu = document.getElementById("lblPassStudent");
    var lblpwgStu = document.getElementById("lblPwgStu");
    var lblFailStu = document.getElementById("lblFailStu");
    

    var grd = document.getElementById("gvStudent");
    
    var ddlSub_id = document.getElementById("ddlSubject");
    var subid = ddlSub_id.options[ddlSub_id.selectedIndex].value;
    var Stu_id = document.getElementById(value1 + "lblStu");
    var Critria = document.getElementById(value1 + "lblCriteria");
    var MaxMarks = document.getElementById(value1 + "lblMaxMarks");
    var ObtMarks = document.getElementById(value1 + "lblMarks");
    var Result = document.getElementById(value1 + "ddlStatus");
    var PWG = document.getElementById("lblGrace");
    Calender_details.Get_ID(Stu_id.innerHTML, subid, getdata1);



    function getdata1(result) {
        pwd = result;
      
        if (Number(ObtMarks.value) > Number(MaxMarks.innerText)) {
            window.alert("Obtain marks can not be more than maximum marks e.g. " + MaxMarks.innerText + "");
            ObtMarks.value = "";
            return false;
        }

        else {

            if (Number(ObtMarks.value) >= Number(Critria.innerText)) {
                Result.value = "3";
            }
            else if (Number(ObtMarks.value) < Number(Critria.innerText)) {
                Result.value = "4";

                if (Number(ObtMarks.value) + Number(PWG.innerText) >= Number(Critria.innerText) && pwd == '') {
                    Result.value = "6";
                    Count++;
                }
                else {
                    Result.value = "4";
                }
            }
        }

        for (var i = 1; i <= grd.rows.length - 1; i++) {

            var currRow = grd.rows[i];
            var selectedIndex = currRow.cells[6].childNodes[1].selectedIndex;
           
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

