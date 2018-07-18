$(document).ready(function () {
    $('#btn_investment').click(function () {
        $find('ModalPopupExtender5').show();
        bind_grid_details();
    });

    $('#btn_close').click(function () {
        $find('ModalPopupExtender5').hide();
    });
});

function Save_data_investment() {
    var ddl_investmenttype = document.getElementById("ddl_investmenttype");
    var SelValue = ddl_investmenttype.options[ddl_investmenttype.selectedIndex].value;
    if (SelValue == "0") {
        window.alert("Select Investment Type.");
        ddl_investmenttype.focus();
        return false;
    }

    var txt_investno = document.getElementById("txt_investno");
    if (txt_investno.value == "") {
        window.alert("Enter Investment Number.");
        txt_investno.focus();
        return false;
    }

    var txt_investamount = document.getElementById("txt_investamount");
    if (txt_investamount.value == "") {
        window.alert("Enter Investment Amount.");
        txt_investamount.focus();
        return false;
    }  

    var txt_startdate = document.getElementById("txt_startdate");
    if (txt_startdate.value == "") {
        window.alert("Enter Investment Start Date.");
        txt_startdate.focus();
        return false;
    }

    var txt_enddate = document.getElementById("txt_enddate");
    if (txt_enddate.value == "") {
        window.alert("Enter Investment End Date.");
        txt_enddate.focus();
        return false;
    }

    var ddl_preminumtype = document.getElementById("ddl_preminumtype");
    var SelValue1 = ddl_preminumtype.options[ddl_preminumtype.selectedIndex].value;
    if (SelValue1 == "0") {
        window.alert("Select Premium Type.");
        ddl_preminumtype.focus();
        return false;
    }

    var txt_premimum = document.getElementById("txt_premimum");
    if (txt_premimum.value == "") {
        window.alert("Enter Premium Amount.");
        txt_premimum.focus();
        return false;
    }

    var txt_lastdate = document.getElementById("txt_lastdate");
    if (txt_lastdate.value == "") {
        window.alert("Enter Premium Last Date.");
        txt_lastdate.focus();
        return false;
    }

    var txt_nextdate = document.getElementById("txt_nextdate");
    if (txt_nextdate.value == "") {
        window.alert("Enter Premium Next Date.");
        txt_nextdate.focus();
        return false;
    }
    Income_Tax_Details.insert_Investment_Details(SelValue, txt_investno.value, txt_investamount.value, txt_startdate.value, txt_enddate.value, SelValue1, txt_premimum.value, txt_lastdate.value, txt_nextdate.value, Fill_investment_retrun);
}

function Fill_investment_retrun(result) {
    if (result > 0) {
        var ddl_investmenttype = document.getElementById("ddl_investmenttype");
        ddl_investmenttype.options[0].selected = "true";
        var txt_investno = document.getElementById("txt_investno");
        txt_investno.value = "";
        var txt_investamount = document.getElementById("txt_investamount");
        txt_investamount.value = "";
        var txt_startdate = document.getElementById("txt_startdate");
        txt_startdate.value = "";
        var txt_enddate = document.getElementById("txt_enddate");
        txt_enddate.value = "";
        var ddl_preminumtype = document.getElementById("ddl_preminumtype");
        ddl_preminumtype.options[0].selected = "true";
        var txt_premimum = document.getElementById("txt_premimum");
        txt_premimum.value = "";
        var txt_lastdate = document.getElementById("txt_lastdate");
        txt_lastdate.value = "";
        var txt_nextdate = document.getElementById("txt_nextdate");
        txt_nextdate.value = "";
        bind_grid_details();
    }
}

function bind_grid_details() {
    Income_Tax_Details.Get_Investment_Details(Fill_Tax_investment_bind);
}

function Fill_Tax_investment_bind(result) {
    var xml = parseXml(result); //pass result string into function for xml conversion.
    if (xml) {
        bindgrid(xml.documentElement); // call the bindgrid method and pass the root element of of xml form in the function.
    }
}

function bindgrid(root) {
    var element = document.getElementById("xGrid");
    var trt = element.getElementsByTagName("TR");
    var lnt = trt.length;
    for (var i = 0; i < trt.length; i++) {
        element.deleteRow(i);
        lnt--;
        i--;
    }

    var invest_details_user = root.getElementsByTagName("invest_details_user");
    var policyid = root.getElementsByTagName("policyid");
    var policynumber = root.getElementsByTagName("policynumber");
    var policyamount = root.getElementsByTagName("policyamount");
    var policystdate = root.getElementsByTagName("policystdate");
    var policyeddate = root.getElementsByTagName("policyeddate");
    var policypreminum = root.getElementsByTagName("policypreminum");
    var preminumamount = root.getElementsByTagName("preminumamount");
    var lstpremiumdate = root.getElementsByTagName("lstpremiumdate");
    var nxtpreminumdate = root.getElementsByTagName("nxtpreminumdate");
    var Invest_name = root.getElementsByTagName("Invest_name");
    var tbt = document.createElement("TBODY");
    element.appendChild(tbt);

                                                  
        var headerRow = document.createElement("TR");
        var th1 = document.createElement("TH");
        th1.appendChild(document.createTextNode("Investments Type"));
        th1.style.height = "30px";
        th1.style.fontSize = "11px";
        th1.style.textAlign = "center";
        th1.style.width = "12%";

        var th2 = document.createElement("TH");
        th2.appendChild(document.createTextNode("Investments NO"));
        th2.style.height = "30px";
        th2.style.fontSize = "11px";
        th2.style.textAlign = "center";
        th2.style.width = "11%";

        var th3 = document.createElement("TH");
        th3.appendChild(document.createTextNode("Investments Amount"));
        th3.style.height = "30px";
        th3.style.fontSize = "11px";
        th3.style.textAlign = "center";
        th3.style.width = "11%";

        var th4 = document.createElement("TH");
        th4.appendChild(document.createTextNode("Start Date"));
        th4.style.height = "30px";
        th4.style.fontSize = "11px";
        th4.style.textAlign = "center";
        th4.style.width = "11%";

        var th5 = document.createElement("TH");
        th5.appendChild(document.createTextNode("End Date"));
        th5.style.height = "30px";
        th5.style.fontSize = "11px";
        th5.style.textAlign = "center";
        th5.style.width = "11%";

        var th6 = document.createElement("TH");
        th6.appendChild(document.createTextNode("Premium Type"));
        th6.style.height = "30px";
        th6.style.fontSize = "11px";
        th6.style.textAlign = "center";
        th6.style.width = "11%";

        var th7 = document.createElement("TH");
        th7.appendChild(document.createTextNode("Premium Amount"));
        th7.style.height = "30px";
        th7.style.fontSize = "11px";
        th7.style.textAlign = "center";
        th7.style.width = "11%";

        var th8 = document.createElement("TH");
        th8.appendChild(document.createTextNode("Last date"));
        th8.style.height = "30px";
        th8.style.fontSize = "11px";
        th8.style.textAlign = "center";
        th8.style.width = "11%";

        var th9 = document.createElement("TH");
        th9.appendChild(document.createTextNode("Next date"));
        th9.style.height = "30px";
        th9.style.fontSize = "11px";
        th9.style.textAlign = "center";
        th9.style.width = "11%";

        headerRow.appendChild(th1);
        headerRow.appendChild(th2);
        headerRow.appendChild(th3);
        headerRow.appendChild(th4);
        headerRow.appendChild(th5);
        headerRow.appendChild(th6);
        headerRow.appendChild(th7);
        headerRow.appendChild(th8);
        headerRow.appendChild(th9);
        tbt.appendChild(headerRow);
 
    if (invest_details_user.length > 0) {
        for (var x = 0; x < invest_details_user.length; x++) {
            var row = document.createElement("TR");
            var rid = "rc" + x;
            row.setAttribute('id', rid);
            var policyid1 = GetInnerText(policyid[x]);
            var policynumber1 = GetInnerText(policynumber[x]);
            var policyamount1 = GetInnerText(policyamount[x]);
            var policystdate1 = GetInnerText(policystdate[x]);
            var policyeddate1 = GetInnerText(policyeddate[x]);
            var policypreminum1 = GetInnerText(policypreminum[x]);
            var preminumamount1 = GetInnerText(preminumamount[x]);
            var lstpremiumdate1 = GetInnerText(lstpremiumdate[x]);
            var nxtpreminumdate1 = GetInnerText(nxtpreminumdate[x]);
            var Invest_name1 = GetInnerText(Invest_name[x]);

            var td1 = document.createElement("TD");
            td1.appendChild(document.createTextNode(Invest_name1));
            td1.style.width = "12%";
            td1.style.textAlign = "left";
            td1.style.fontSize = "11px";
            td1.style.paddingLeft = "5px";

            var td2 = document.createElement("TD");
            td2.appendChild(document.createTextNode(policynumber1));
            td2.style.width = "11%";
            td2.style.textAlign = "left";
            td2.style.fontSize = "11px";
            td2.style.paddingLeft = "5px";

            var td3 = document.createElement("TD");
            td3.appendChild(document.createTextNode(policyamount1));
            td3.style.width = "11%";
            td3.style.textAlign = "left";
            td3.style.fontSize = "11px";
            td3.style.paddingLeft = "5px";

            var td4 = document.createElement("TD");
            td4.appendChild(document.createTextNode(policystdate1));
            td4.style.width = "11%";
            td4.style.textAlign = "right";
            td4.style.fontSize = "11px";
            td4.style.paddingRight = "5px";

            var td5 = document.createElement("TD");
            td5.appendChild(document.createTextNode(policyeddate1));
            td5.style.width = "11%";
            td5.style.textAlign = "right";
            td5.style.fontSize = "11px";
            td5.style.paddingRight = "5px";
            var valuepolicy = "";
            if (policypreminum1 == "1") {
                valuepolicy = "Monthly";
            }
            if (policypreminum1 == "2") {
                valuepolicy = "Quarterly";
            }
            if (policypreminum1 == "3") {
                valuepolicy = "Halfyearly";
            }
            if (policypreminum1 == "4") {
                valuepolicy = "Yearly";
            }
            var td6 = document.createElement("TD");
            td6.appendChild(document.createTextNode(valuepolicy));
            td6.style.width = "11%";
            td6.style.textAlign = "right";
            td6.style.fontSize = "11px";
            td6.style.paddingRight = "5px";

            var td7 = document.createElement("TD");
            td7.appendChild(document.createTextNode(preminumamount1));
            td7.style.width = "11%";
            td7.style.textAlign = "right";
            td7.style.fontSize = "11px";
            td7.style.paddingRight = "5px";

            var td8 = document.createElement("TD");
            td8.appendChild(document.createTextNode(lstpremiumdate1));
            td8.style.width = "11%";
            td8.style.textAlign = "right";
            td8.style.fontSize = "11px";
            td8.style.paddingRight = "5px";

            var td9 = document.createElement("TD");
            td9.appendChild(document.createTextNode(nxtpreminumdate1));
            td9.style.width = "11%";
            td9.style.textAlign = "right";
            td9.style.fontSize = "11px";
            td9.style.paddingRight = "5px";

            row.appendChild(td1);
            row.appendChild(td2);
            row.appendChild(td3);
            row.appendChild(td4);
            row.appendChild(td5);
            row.appendChild(td6);
            row.appendChild(td7);
            row.appendChild(td8);
            row.appendChild(td9);
            tbt.appendChild(row);
        }
    }


    var ddl_investmenttype = document.getElementById("ddl_investmenttype");
    ddl_investmenttype.focus();
}

function onclick_val() {
    $find('ModalPopupExtender5').hide();
}

function next_date_value() {
    var txt_lastdate = document.getElementById("txt_lastdate");
    var date1 = new Date(txt_lastdate.value);
    var ddl_preminumtype = document.getElementById("ddl_preminumtype");
    var SelValue1 = ddl_preminumtype.options[ddl_preminumtype.selectedIndex].value;
    var date2;
    if (SelValue1 == "1") {
        date1.setMonth(date1.getMonth()+1);
    }
    if (SelValue1 == "2") {
         date1.setMonth(date1.getMonth() + 3);
    }
    if (SelValue1 == "3") {
        date1.setMonth(date1.getMonth() + 6);
    }
    if (SelValue1 == "4") {
        date1.setMonth(date1.getMonth() + 12);
    }
    var txt_nextdate = document.getElementById("txt_nextdate");
    txt_nextdate.value = date1.format("dd-MMM-yyyy"); ;

    var ddl_investmenttype = document.getElementById("ddl_investmenttype");
    var SelValue = ddl_investmenttype.options[ddl_investmenttype.selectedIndex].value;
    if (SelValue == "0") {
        window.alert("Select Investment Type.");
        ddl_investmenttype.focus();
        return false;
    }

    var txt_investno = document.getElementById("txt_investno");
    if (txt_investno.value == "") {
        window.alert("Enter Investment Number.");
        txt_investno.focus();
        return false;
    }

    var txt_investamount = document.getElementById("txt_investamount");
    if (txt_investamount.value == "") {
        window.alert("Enter Investment Amount.");
        txt_investamount.focus();
        return false;
    }

    var txt_startdate = document.getElementById("txt_startdate");
    if (txt_startdate.value == "") {
        window.alert("Enter Investment Start Date.");
        txt_startdate.focus();
        return false;
    }

    var txt_enddate = document.getElementById("txt_enddate");
    if (txt_enddate.value == "") {
        window.alert("Enter Investment End Date.");
        txt_enddate.focus();
        return false;
    }



    if (SelValue1 == "0") {
        window.alert("Select Premium Type.");
        ddl_preminumtype.focus();
        return false;
    }

    var txt_premimum = document.getElementById("txt_premimum");
    if (txt_premimum.value == "") {
        window.alert("Enter Premium Amount.");
        txt_premimum.focus();
        return false;
    }

    var txt_lastdate = document.getElementById("txt_lastdate");
    if (txt_lastdate.value == "") {
        window.alert("Enter Premium Last Date.");
        txt_lastdate.focus();
        return false;
    }

    var txt_nextdate = document.getElementById("txt_nextdate");
    if (txt_nextdate.value == "") {
        window.alert("Enter Premium Next Date.");
        txt_nextdate.focus();
        return false;
    }

    Income_Tax_Details.insert_Investment_Details(SelValue, txt_investno.value, txt_investamount.value, txt_startdate.value, txt_enddate.value, SelValue1, txt_premimum.value, txt_lastdate.value, txt_nextdate.value, Fill_investment_retrun);
}

function policy_end_onchnage() {
    var txt_startdate = document.getElementById("txt_startdate");
    var txt_enddate = document.getElementById("txt_enddate");
    var date1 = new Date(txt_startdate.value);
    var date2 = new Date(txt_enddate.value);
    if (date2 < date1) {
        window.alert("Enter Investment End date greater than Start date.");
        txt_enddate.value = "";
        txt_enddate.focus();
        return false;
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


