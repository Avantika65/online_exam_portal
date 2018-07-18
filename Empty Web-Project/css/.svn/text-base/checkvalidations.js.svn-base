// JScript File
//*************************************************
//---------------to check the valid user id on blur 

//  debugger; 
var requester = null;
function CheckUsernameAvailability(ob) {
    debugger;
    document.body.style.cursor = 'wait';
    var username = document.getElementById("ctl00_ContentPlaceHolder1_txtLoginID1");
    var error_username = document.getElementById("userid");
    var status_username = document.getElementById("DivError");
    var params = new Array();
    var err = false;
    error_username.innerHTML = "";
    //username.value = rm_trim(username.value);
    if (username.value.length < 4) { //|| username.value.length > 100  )  {
        params = { "ErrDivObj": error_username, "ErrorMsg": "Username Must be Minimum 4 Characters Long.", "EleToFocus": username, "StatusObj": status_username, "ob": ob, "HName": "Username" }
        showErrMsg(params);
        err = true;
        //return ;
    } else if (username.value.length > 100) {
        params = { "ErrDivObj": error_username, "ErrorMsg": "Username should not be more than 100 characters long.", "EleToFocus": username, "StatusObj": status_username, "ob": ob, "HName": "Username" }
        showErrMsg(params);
        err = true;
    } else if (isValidUsername(username.value) == false) {
        params = { "ErrDivObj": error_username, "ErrorMsg": "Special Characters Other Than (Hyphen Underscore Dot @) Are Not Allowed.", "EleToFocus": username, "StatusObj": status_username, "ob": ob, "HName": "Username" }
        if (username.value.toString().indexOf(' ') > -1)
            params['ErrorMsg'] = "Username cannot contain blank space";
        showErrMsg(params);
        err = true;
        //return;
    }

    if (!err) {
        error_username.style.display = "";
        if (!this.verified) {
            error_username.innerHTML = "Checking availability of username.....";
            error_username.style.display = "";
            if (requester != null && requester.readyState != 0 && requester.readyState != 4)
                requester.abort();

            try {
                requester = new XMLHttpRequest();
            }
            catch (error) {
                try {
                    requester = new ActiveXObject("Microsoft.XMLHTTP");
                }
                catch (error) {
                    requester = null;
                    return;
                }
            }
            requester.onreadystatechange = onReadyStateChangeUsername;
            requester.open("GET", "CheckUsername.aspx?username=" + username.value);
            requester.send(null);
        }
    }
    document.body.style.cursor = 'auto';

    return true;
}
function onReadyStateChangeUsername() {
    if (requester.readyState == 4) {
        try {
            if (requester.status == 200) {
                var response = String(requester.responseText).split("|X|");
                if (String(response[0]).toLowerCase() == "show") {
                    document.getElementById("userid").className = "error";
                    document.getElementById("userid").focus;
                }
                else {
                }
                if (response[0] == "hide") {
                    document.getElementById("userid").className = "error";
                    document.getElementById("DivError").style.display = '';

                } else {
                    document.getElementById("userid").className = "error";
                }
                document.getElementById("userid").innerHTML = response[1];
            }
            else if (requester.status != 0) {
                alert("There was an error while checking username availability.\nPlease try again.");
            }
        }
        catch (e2) { }
    }
    return true;
}


function chk(ctl, msg, di, dv1) {

    //var username = document.getElementById(ctl);
    var username = document.getElementById(ctl);
    var error_username = document.getElementById(di);
    var status_username = document.getElementById(dv1);
    var params = new Array();
    var err = false;
    error_username.innerHTML = "";
    if (username.value.length < 4 && username.value != "") {
        msg = msg + " should have four characters.";
    }
    else if (username.value == "") {
        msg = "Please enter " + msg + ".";
    }
    else {
    }
    if (username.value.length < 4 || username.value == "") {
        params = { "ErrDivObj": error_username, "ErrorMsg": msg, "EleToFocus": username, "StatusObj": status_username, "ob": "1", "HName": "Username" }
        showErrMsg(params);
        err = true;
    }
    if (!err) {
        var im;
        im = "../../images";
        hideErrorCSS(ctl, di, 'error');
        document.getElementById(dv1).innerHTML = "<img src=\"" + im + "/spellcheck.gif\">";
        //        CheckUsernameAvailability(1);
    }
    else {
        document.getElementById(dv1).innerHTML = "";
    }
}

function isValidUsername(Username) {
    var pattern = /[^a-zA-Z0-9.@_-]+/;
    return !pattern.test(Username);
}


function CheckEmail(ob) {
    document.body.style.cursor = 'wait';
    var username = document.getElementById("txtEmailId");
    var error_username = document.getElementById("error");
    var status_username = document.getElementById("Div");
    var params = new Array();
    var err = false;
    error_username.innerHTML = "";
    if (isValidUsername(username.value) == false) {
        params = { "ErrDivObj": error_username, "ErrorMsg": "Special Characters Other Than (Hyphen Underscore Dot @) Are Not Allowed.", "EleToFocus": username, "StatusObj": status_username, "ob": ob, "HName": "Username" }
        if (username.value.toString().indexOf(' ') > -1)
            params['ErrorMsg'] = "Username cannot contain blank space";
        showErrMsg(params);
        err = true;
        //return;
    }

    if (!err) {
        error_username.style.display = "";
        if (!this.verified) {
            error_username.innerHTML = "Checking Email.....";
            error_username.style.display = "";
            if (requester != null && requester.readyState != 0 && requester.readyState != 4)
                requester.abort();

            try {
                requester = new XMLHttpRequest();
            }
            catch (error) {
                try {
                    requester = new ActiveXObject("Microsoft.XMLHTTP");
                }
                catch (error) {
                    requester = null;
                    return;
                }
            }

            requester.onreadystatechange = onReadyStateChangeEmail;
            requester.open("GET", "UseEmail.aspx?username=" + username.value);
            requester.send(null);
        }
    }
    document.body.style.cursor = 'auto';

    //return true;
}
function onReadyStateChangeEmail() {

    if (requester.readyState == 4) {
        try {
            if (requester.status == 200) {
                var response = String(requester.responseText).split("|X|");
                if (String(response[0]).toLowerCase() == "show") {
                    document.getElementById("Em").className = "error";
                    document.getElementById("txtEmailId").focus;
                }
                else {
                }
                if (response[0] == "hide") {
                    document.getElementById("Em").className = "error";
                    document.getElementById("Em").style.display = '';

                } else {
                    document.getElementById("Em").className = "error";

                }

                document.getElementById("Em").innerHTML = response[1];
            }
            else if (requester.status != 0) {
                alert("There was an error while checking email.\nPlease try again.");
            }
        }
        catch (e2) { }
    }

}

function isvalidMobileNum(obj, goods) {

    if (obj != '') {
        goods = goods.toLowerCase();
        var msg;
        var val = obj.value;
        val = val.toLowerCase();
        var splitarr = val.split("");
        var count = -1;
        var rt = true;
        for (var i = 0; i < splitarr.length; i++) {
            if (goods.indexOf(splitarr[i]) < 0) {
                rt = false;
                break;
            }
            if (i > 0) {
                if ((splitarr[i]) == "+") {
                    //rt = false; 
                    alert("'+' should be in first position.");
                    obj.focus();
                    obj.select();
                    break;
                }
            }

        }
        if (rt) {
            return true;
        }
        else {

            alert("Mobile no should contain numbers only.");
            obj.focus();
            obj.select();
            return false;
        }
    }
}


function validate_email(field, alerttxt) {
    debugger;
    with (field) {
        apos = value.indexOf("@");
        dotpos = value.lastIndexOf(".");

        if (apos < 1 || dotpos - apos < 2) {
            chk3('txtEmailId', 'Please check Email ID.', 'Em', 'Em1', 1);
            field.focus();
        }
        else {
            chk3('txtEmailId', 'Please check Email ID.', 'Em', 'Em1', 2);
            CheckEmail(1);
        }
    }
}


function chk3(ctl, msg, di, dv1, T) {

    var username = document.getElementById(ctl);
    var TT = T;
    var error_username = document.getElementById(di);
    var status_username = document.getElementById(dv1);
    var params = new Array();
    var err = false;
    error_username.innerHTML = "";




    if (!err && TT != 1) {
        var im;
        im = "images";
        hideErrorCSS(ctl, di, dv1);
        document.getElementById(dv1).innerHTML = "<img src=\"" + im + "/spellcheck.gif\">";
    }
    else {
        params = { "ErrDivObj": error_username, "ErrorMsg": msg, "EleToFocus": username, "StatusObj": status_username, "ob": "1", "HName": "Username" }
        showErrMsg(params);
        // document.getElementById(status_username).innerHTML ="";
    }
}


function showErrMsg(arr_params) {
    var i;
    var im;
    im = "../../images";
    arr_params['ErrDivObj'].style.display = "";
    arr_params['ErrDivObj'].innerHTML = "<img src=\"" + im + "/uncheck.gif\">" + "  " + arr_params['ErrorMsg'];

    if (arr_params['EleToFocus']) {
        if (arr_params['EleToFocus']["isArray"]) {
            for (i = 0; i < arr_params['EleToFocus'].length; ++i) {
                arr_params['EleToFocus'][i].className = "errorcss";
                if (!arr_params['noborder'] && arr_params['EleToFocus'][i].parentNode && arr_params['EleToFocus'][i].parentNode.name && arr_params['EleToFocus'][i].parentNode.name == "borderele") {
                    arr_params['EleToFocus'][i].parentNode.className = "errorcss";
                }
            }
        }
        else
            arr_params['EleToFocus'].className = "errorcss";
        if (!arr_params['noborder'] && arr_params['EleToFocus'].parentNode && arr_params['EleToFocus'].parentNode.name && arr_params['EleToFocus'].parentNode.name == "borderele") {
            arr_params['EleToFocus'].parentNode.className = "errorcss";
        }
    }
    if (arr_params['StatusObj']) {
        if (arr_params['StatusObj']["isArray"]) {
            for (i = 0; i < arr_params['StatusObj'].length; ++i) {
                arr_params['StatusObj'][i].style.display = "";
                arr_params['StatusObj'][i].src = aa + "/close.gif";
            }
        }
        else {
            arr_params['StatusObj'].style.display = "";
        }
    }

}

function hideErrorCSS(objId, ErrMsgDivId, StatusObjId) {
    var obj = document.getElementById(objId)
    // var obj = document.getElementById(objId)
    obj.className = 'rdginputbox';
    document.getElementById(ErrMsgDivId).style.display = 'none';
    document.getElementById(StatusObjId).style.display = 'none';
    if (obj.parentNode && obj.parentNode.name && obj.parentNode.name == "borderele") {
        obj.parentNode.className = "";
    }
    return true;
}

function numbersonly(e) {
    var unicode = e.charCode ? e.charCode : e.keyCode
    if (unicode != 8) {
        if ((unicode > 47 && unicode < 58) || (unicode == 43)) {
            return true;
        }
        else {
            return false;
        }
    }
}

function rm_trim(inputString) {
    if (typeof inputString != "string") { return inputString; }

    var temp_str = '';
    temp_str = inputString.replace(/[\s]+/g, "");
    if (temp_str == '')
        return "";

    var retValue = inputString;
    var ch = retValue.substring(0, 1);
    while (ch == " ") {
        retValue = retValue.substring(1, retValue.length);
        ch = retValue.substring(0, 1);
    }
    ch = retValue.substring(retValue.length - 1, retValue.length);
    while (ch == " ") {
        retValue = retValue.substring(0, retValue.length - 1);
        ch = retValue.substring(retValue.length - 1, retValue.length);
    }
    while (retValue.indexOf("  ") != -1) {
        retValue = retValue.substring(0, retValue.indexOf("  ")) + retValue.substring(retValue.indexOf("  ") + 1, retValue.length);
    }
    return retValue;
}
function disp_text(v) {
    document.getElementById("cboRegion").value = v;

}

function chPass() {
    if (document.getElementById("txtPassword").value != "") {
        if (document.getElementById("txtConfirmPassword").value != "") {
            if (rm_trim(document.getElementById("txtPassword").value) != rm_trim(document.getElementById("txtConfirmPassword").value)) {

                alert("Password Mismatch.");
                document.getElementById("txtConfirmPassword").focus();
            }
        }
    }
}
function ValidateFullName(oTextBox, bFieldType, sTextBoxName) {
    if (!gf_bCheckNull(oTextBox)) {
        if (bFieldType == '4') {
        }
        else {
            if (gf_bCheckAnySpaces(oTextBox)) {
                alert(sTextBoxName + " should not contain Spaces");
                oTextBox.focus();
                return (false);
            }
        }
        if (bFieldType == '2' || bFieldType == '4') // For first name and last name
        {
            if (gf_bCheckSpecialChar(oTextBox)) {
                alert(sTextBoxName + " should not contain any special characters");
                oTextBox.value = "";
                oTextBox.focus();
                return (false);
            }
            if (gf_CheckIntergerInText(oTextBox, bFieldType)) {
                oTextBox.value = "";
                oTextBox.focus();
                alert(sTextBoxName + " should not contain Integer");
                return (false);
            }
        }
        if (bFieldType == '3') // Email
        {
            if (gf_bCheckSpecialCharEmail(oTextBox)) {
                alert('Please do not enter any special characters');
                oTextBox.value = "";
                oTextBox.focus();
                return (false);
            }
        }
        if (!(isNaN(oTextBox.value))) {
            oTextBox.value = "";
            oTextBox.focus();
            alert(sTextBoxName + " should not contain Interger");
            return (false);
        }
    }
}

function gf_CheckIntergerInText(oTextBox, bType) {
    var iStringLength = 0; //Length of the string
    var sStringValue = ""; //String to be checked
    var iIndexOuter = 0; //Index for the outer for loop
    var iIndexInner = 0; //Index for the inner for loop
    var sStringChar = ""; //Store each character of the string
    aSpecialChar = new Array("0", "1", "2", "3", "4", "5", "6", "7", "8", "9");
    iStringLength = oTextBox.value.length;
    sStringValue = oTextBox.value;

    for (iIndexOuter = 0; iIndexOuter < iStringLength; iIndexOuter++) {
        sStringChar = sStringValue.substring(iIndexOuter, iIndexOuter + 1);
        for (iIndexInner = 0; iIndexInner < 9; iIndexInner++) {
            if (sStringChar == aSpecialChar[iIndexInner]) {
                oTextBox.focus();
                return (true);
            }
        }
    }
    return (false);
}

function ValidateNumber(oTextBox, sTextBoxName) {
    if (!gf_bCheckNull(oTextBox)) {
        if (gf_bCheckAnySpaces(oTextBox)) {
            alert(sTextBoxName + " should not contain Spaces");
            return (false);
        }
        if ((isNaN(oTextBox.value))) {
            oTextBox.value = "";
            oTextBox.focus();
            alert(sTextBoxName + " should be numeric");
            return (false);
        }
    }
}

function ValidatePassportNumber(oTextBox, sTextBoxName) {
    if (!gf_bCheckNull(oTextBox)) {
        if (gf_bCheckAnySpaces(oTextBox)) {
            alert(sTextBoxName + " should not contain Spaces");
            return (false);
        }
        if (gf_bCheckSpecialChar(oTextBox)) {
            alert(sTextBoxName + " should not contain any special characters");
            return (false);
        }
    }
}

function ValidatePercentage(oTextBox, sTextBoxName) {
    if (!gf_bCheckNull(oTextBox)) {
        if (gf_bCheckAnySpaces(oTextBox)) {
            alert(sTextBoxName + " should not contain Spaces");
            return (false);
        }
        if ((isNaN(oTextBox.value))) {
            oTextBox.value = "";
            oTextBox.focus();
            alert(sTextBoxName + " should only contain Interger");
            return (false);
        }
        if (oTextBox.value > 100) {
            oTextBox.value = "";
            oTextBox.focus();
            alert(sTextBoxName + " should not greater than 100");
            return (false);
        }
    }

    function ctrValidateDate(dtControl) {
        if (dtControl.value == "") {
        }
        else {
            var input = document.getElementById(dtControl)
            var validformat = /^\d{1,2}\/\d{1,2}\/\d{4}$/ //Basic check for format validity
            var returnval = false
            if (!validformat.test(dtControl.value))
                alert('Invalid Date Format. Please correct.')
            else { //Detailed check for valid date ranges
                var dayfield = dtControl.value.split("/")[0]
                var monthfield = dtControl.value.split("/")[1]
                var yearfield = dtControl.value.split("/")[2]
                var dayobj = new Date(yearfield, monthfield - 1, dayfield)

                if ((dayobj.getMonth() + 1 != monthfield) || (dayobj.getDate() != dayfield) || (dayobj.getFullYear() != yearfield))
                    alert('Invalid Day, Month, or Year range detected. Please correct.')
                else {
                    returnval = true
                }
            }
            if (returnval == false) {
                dtControl.value = "";
                dtControl.focus();
            }
            return returnval
        }
    }
}

/*************************************************************************
Common Functions
*************************************************************************/

function gf_bCheckNull(oTextBox) {
    if ((oTextBox.value) == "") {
        return (true);
    }
    else
        return (false);
}

function gf_bCheckAnySpaces(oTextBox) {
    var iStringLength = 0;   //Length of the string
    var sStringValue = "";   //String to be checked
    var iIndex = 0;          //Index for the for loop
    var sStringChar = "";    //Store each character of the string

    iStringLength = oTextBox.value.length;
    sStringValue = oTextBox.value;

    for (iIndex = 0; iIndex < iStringLength; iIndex++) {
        sStringChar = sStringValue.substring(iIndex, iIndex + 1);
        if (sStringChar == " ") {
            oTextBox.focus();
            oTextBox.value = "";
            return (true);
        }
    }
    return (false);
}

function gf_bCheckSpecialChar(oTextBox) {
    var iStringLength = 0;   //Length of the string
    var sStringValue = "";   //String to be checked
    var iIndexOuter = 0;     //Index for the outer for loop
    var iIndexInner = 0;     //Index for the inner for loop
    var sStringChar = "";    //Store each character of the string

    aSpecialChar = new Array("+", "-", "~", "`", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "_", "=", "{", "}", "|", "[", "]", "\\", ";", ":", "\"", "<", ">", "?", ",", ".", "/", "'");

    iStringLength = oTextBox.value.length;
    sStringValue = oTextBox.value;

    for (iIndexOuter = 0; iIndexOuter < iStringLength; iIndexOuter++) {
        sStringChar = sStringValue.substring(iIndexOuter, iIndexOuter + 1);
        for (iIndexInner = 0; iIndexInner < 32; iIndexInner++) {
            if (sStringChar == aSpecialChar[iIndexInner]) {
                oTextBox.focus();
                oTextBox.value = "";
                return (true);
            }
        }
    }
    return (false);
}

/*************************************************************************
Common Functions for Email validation
*************************************************************************/
function gf_bCheckSpecialCharEmail(oTextBox)       //Email
{
    var iStringLength = 0; //Length of the string
    var sStringValue = ""; //String to be checked
    var iIndexOuter = 0; //Index for the outer for loop
    var iIndexInner = 0; //Index for the inner for loop
    var sStringChar = ""; //Store each character of the string

    aSpecialCharEmail = new Array("+", "~", "`", "!", "#", "$", "%", "^", "&", "*", "(", ")", "=", "{", "}", "|", "[", "]", "\\", ";", ":", "\"", "<", ">", "?", ",", "/", "'");

    iStringLength = oTextBox.value.length;
    sStringValue = oTextBox.value;

    for (iIndexOuter = 0; iIndexOuter < iStringLength; iIndexOuter++) {
        sStringChar = sStringValue.substring(iIndexOuter, iIndexOuter + 1);

        for (iIndexInner = 0; iIndexInner < 32; iIndexInner++) {
            if (sStringChar == aSpecialCharEmail[iIndexInner]) {
                oTextBox.focus();
                return (true);
            }
        }
    }
    return (false);
}

//Following function is use on btnSubmit click to check valid extention
function checkaspx(oTextBox) {
    if (document.getElementById(oTextBox).value == null || document.getElementById(oTextBox).value == "") {
        alert('Please upload resume.');
        return;
    }
    else {
        var ind = document.getElementById(oTextBox).value;
        //if extension is about four characters then use following line
        var ext1 = document.getElementById(oTextBox).value.substring(ind.length, ind.length - 4);

        if (ext1 == ".doc" || ext1 == ".txt") {
            return (true);
        }
        else {
            document.getElementById(oTextBox).focus();
            alert('Only .doc OR .txt page is valid');
            return (false);
        }
    }
}

function Trim(str) {
    while (str.charAt(0) == (" ")) {
        str = str.substring(1);
    }
    while (str.charAt(str.length - 1) == " ") {
        str = str.substring(0, str.length - 1);
    }
    return str;
}