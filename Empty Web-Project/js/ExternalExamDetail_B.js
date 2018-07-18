
var Count = 0;
var TotalObt = 0;
function Result_Calculator(cltid) {
    var value1 = cltid.substring(0, 31);
    var value2 = cltid.substring(0, 16);
    var value3 = cltid.substring(0, 28);

    var grdid = document.getElementById(value2 + "grdMarks");
    var grd_length = grdid.rows.length;
    var GrdFooter = document.getElementById(value3 + grd_length + "_" + "lblTtlObt");

    var Critria = document.getElementById(value1 + "lblCri");
    var MaxMarks = document.getElementById(value1 + "lblMarks");
    var ObtMarks = document.getElementById(value1 + "txtMarks");
    var Result = document.getElementById(value1 + "ddlStatus");
    var Grace = document.getElementById("lblGrace");

    if (Number(ObtMarks.value) > Number(MaxMarks.innerText)) {
        window.alert("Obtain marks can not be more than maximum marks e.g. " + MaxMarks.innerText + " ..!!");
        ObtMarks.value = "";
        setTimeout(function () { ObtMarks.focus(); }, 1);
        return false;
    }

    else {
        if (Number(ObtMarks.value) >= Number(Critria.innerText)) {
            Result.value = "3";
        }
        else if (Number(ObtMarks.value) < Number(Critria.innerText)) {
            Result.value = "4";

            if (Number(ObtMarks.value) + Number(Grace.innerText) >= Number(Critria.innerText) && Count == 0) {
                Result.value = "6";
                Count++;
            }
            else {
                Result.value = "4";
            }
        }
    }

    TotalObt = Number(TotalObt) + Number(ObtMarks.value);
    GrdFooter.innerText = TotalObt + ".00";
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