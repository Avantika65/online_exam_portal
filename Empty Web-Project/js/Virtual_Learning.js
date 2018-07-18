

//////////////////////////////////////////// Submit/////////////////////////

var rdbvalue = "";
function submit_value() {

        var isChecked = false;
        var rdbchk = document.getElementById("Rbl1");
        var radioButtons = rdbchk.getElementsByTagName("input");
        for (var i = 0; i < radioButtons.length; i++) {
            if (radioButtons[i].checked) {
                rdbvalue = radioButtons[i].value;
                isChecked = true;
                break;
            }
        }

        if (!isChecked) {
            alert("Please select book type from the list..!!.");
            return false;
        }

        
    var txtauther = document.getElementById("txtauther");
    if (txtauther.value == "") {
        window.alert("Please enter book's auther name..!!");
        txtauther.focus();
        return false;
    }

    var txttitle = document.getElementById("txttitle");
    if (txttitle.value == "") {
        window.alert("Please enter book's title..!!");
        txttitle.focus();
        return false;
    }

    var txtedition = document.getElementById("txtedition");
    if (txtedition.value == "") {
        window.alert("Enter book's edition..!!");
        txtedition.focus();
        return false;
    }
    var txtyear = document.getElementById("txtyear");
    if (txtyear.value == "") {
        window.alert("Please enter book's publication year..!!");
        txtyear.focus();
        return false;
    }
    var txtpub = document.getElementById("txtpub");
    if (txtpub.value == "") {
        window.alert("Please enter book's publication..!!");
        txtpub.focus();
        return false;
    }

    var txtoref = document.getElementById("txtoref");
    if (txtoref.value == "") {
        window.alert("Please enter book's publication..!!");
        txtoref.focus();
        return false;
    }

    
   Calender_details.Insert_Books_Details_For_Reference(courseid_, splid_, semid_, subid_, instid_, sessionid_, facultyid_, rdbvalue, txtauther.value, txttitle.value, txtedition.value, txtyear.value, txtpub.value, txtoref.value, Insert_Books_Details);
    
}
function Insert_Books_Details(result) {
    if (result > 0) {
        alert('submitted');
    }
}






