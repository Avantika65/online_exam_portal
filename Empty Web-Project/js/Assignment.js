

var Count = 0;
var TotalObt = 0;
var pwd = "";

function Result_Calculator(cltid)
{
    alert("k");
    var value1 = cltid.substring(0, 16);
    var grd = document.getElementById("grdAssign");
    var MarksDet = document.getElementById(value1 + "lblMarksDetect");
    var MarksObt = document.getElementById(value1 + "txtMArksObt");
    var finalMarks = document.getElementById(value1 + "txtFinalMArks");
    var maxMarks = document.getElementById("txtmarks");

    alert(MarksObt.value);
    alert(maxMarks);
    alert(MarksDet.innerText);
    alert(finalMarks.value);

        if (Number(MarksObt.value) > Number(maxMarks.value)) {
            window.alert("Obtain marks can not be more than maximum marks e.g. " + maxMarks.value + "");
            MarksObt.value = "0";
            finalMarks.value = "0";
            return false;
        }

        else {
            alert(MarksDet.innerText);

            if (MarksDet.innerText != "-")
            {
                finalMarks.value = Number(MarksObt.value) - Number(MarksDet.innerText);
            }
            else {
                finalMarks.value = MarksObt.value;                
            }
        }

      
}

