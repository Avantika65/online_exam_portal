function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        alert("Please Enter the Integer Number?");
        return false;
        
    }
    return true;
}
function IntegerNumber(cntrName) 
{

    if ((window.event.keyCode < 48) || (window.event.keyCode > 57)) 
    {
        window.event.keyCode = 0;
        window.alert("Please Enter the Integer Number");
    }
}
    function MouseEvents(objRef, evt) {
        var checkbox = objRef.getElementsByTagName("input")[0];
        if (evt.type == "mouseover") {
            objRef.style.backgroundColor = "#FFECFF";
            //objRef.style.display = "none";
        }
        else {
            if (checkbox.checked) {
                objRef.style.backgroundColor = "#FFECFF";
            }

            else if (evt.type == "mouseout") {
                if (objRef.rowIndex % 2 == 0) {
                    //Alternating Row Color
                    objRef.style.backgroundColor = "#FFECFF";
                    //objRef.style.display = "visible";
                }
                else {
                    objRef.style.backgroundColor = "white";
                }
            }
        }
    }


    //Following this code write on button click for ex. OnClientClick = "return ConfirmDelete();"
    function DeleteConfirmation() 
    {
        if (confirm("Are you sure", "you want to delete selected records ?") == true)
            return true;
        else
            return false;
    }

    function do_logout() 
    {
        var browserName = navigator.appName;
        var valLeft = (screen.width);
        var valTop = (screen.height);
        window.open('logout.aspx', '_blank', 'width=' + valLeft + ',height=' + valTop + ',left=0,top=0,toolbar=yes, location=yes,directories=yes,status=yes,menubar=yes,scrollbars=yes,copyhistory=yes, resizable=yes');
        if (browserName == "Microsoft Internet Explorer") {
            window.opener = window;
        }
        else
        {
            window.opener = window.parent;
        }
        window.close();
    }

    function g2ic_open() {
        var url = 'CHANGE PASSWORD.aspx';
        var name = 'Change Password';
        var w = 420;
        var h = 200;
        var valLeft = (screen.width) ? (screen.width - w) / 2 : 0;
        var valTop = (screen.height) ? (screen.height - h) / 2 : 0;
        window.open(url, '', 'left=' + valLeft + ',top=' + valTop + ',width=' + w + ',height=' + h + ',resizable=no,scrollbars=no');
    }
    function g2ic_open1() {
        var url = 'Forgetpassword.aspx';
        var name = 'Forget Password';
        var w = 420;
        var h = 200;
        var valLeft = (screen.width) ? (screen.width - w) / 2 : 0;
        var valTop = (screen.height) ? (screen.height - h) / 2 : 0;
        window.open(url, '', 'left=' + valLeft + ',top=' + valTop + ',width=' + w + ',height=' + h + ',resizable=no,scrollbars=no');
    }
    function g2ic_open2(SIMID) {
        var url = 'SampleDisapprovalReason.aspx?SIMID=' + SIMID;
        var name = 'Sample DisApproval Reason';
        var w = 420;
        var h = 200;
        var valLeft = (screen.width) ? (screen.width - w) / 2 : 0;
        var valTop = (screen.height) ? (screen.height - h) / 2 : 0;
        window.open(url, '', 'left=' + valLeft + ',top=' + valTop + ',width=' + w + ',height=' + h + ',resizable=no,scrollbars=no');
    }
    function CopyAdd(ctrl) {
        var Obj = $get(ctrl);
        var value_ADD = $get("txtMStreet").value;
        if (Obj.checked == true) {
            $get("txtOstreet").value = value_ADD;
        }
        else {
            $get("txtOstreet").value = '';
        }
    }

    function Caps(txtID) {
        var txt = document.getElementById(txtID);
        var txtValue = txt.value.replace(' ', '');
        txt.value = txtValue.toUpperCase();
    }
//    function CopyText() {
//        var cb = document.getElementById('CheckBox1');
//        var tb1 = document.getElementById('txtMStreet');
//        var tb2 = document.getElementById('txtOstreet');
//        if (cb.checked) {
//            tb2.value = tb1.value;
//        }
//        else {
//            tb2.value = '';
//        }
//    }
    

   
