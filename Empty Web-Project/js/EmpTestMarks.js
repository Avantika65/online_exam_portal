

function Result_Calculator(cltid) {
    var value1 = cltid.substring(0, 15);
    var Obtain = document.getElementById(value1 + "txtmarksObtain");
    var total = document.getElementById(value1 + "txtMarks");
    var PanelMember = document.getElementById(value1 + "ddlRecruiter");
    var Percentange = document.getElementById(value1 + "txtPercentage");

    if (Number(Obtain.value) > Number(total.value)) {
        window.alert("Obtain marks can not be more than maximum marks");
        Obtain.value = "";
        Percentange.value = "";
        setTimeout(function () { Obtain.focus(); }, 1);
        return false;
    }
    else {
        var Per = (Obtain.value) / (total.value) * 100;
        Percentange.value = Per;
    }
}
function Sel_Panel(clti) {
    var value1 = clti.substring(0, 15);
    var PanelMember = document.getElementById(value1 + "ddlRecruiter");
    var Percentange = document.getElementById(value1 + "txtPercentage");
    var Check = document.getElementById(value1 + "chk");

    var SelValue = PanelMember.options[PanelMember.selectedIndex].value;
    if (SelValue == "0") {
    }
    else {
        if (Percentange.value != "") {
            Check.checked = true;
        }
        else {
            SelValue = 0;
        }
    }
   
}