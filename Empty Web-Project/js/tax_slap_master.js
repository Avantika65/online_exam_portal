window.onload = init;
var valuec;
function init() {
    var progressBar1 = document.getElementById("progressBar1");
    progressBar1.style.display = "block";
    Income_Tax_Details.Get_Tax_Slap_Master(Fill_Investment_Type_Master);
}

function Fill_Investment_Type_Master(result) {
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

    var Tax_Slab_Master = root.getElementsByTagName("Tax_Slab_Master");
    var id = root.getElementsByTagName("id");
    var T_from = root.getElementsByTagName("T_from");
    var T_to = root.getElementsByTagName("T_to");
    var percentge = root.getElementsByTagName("percentge");
    var taxt_type = root.getElementsByTagName("taxt_type");

    var tbt = document.createElement("TBODY");
    element.appendChild(tbt);
  
  
        var headerRow = document.createElement("TR");
        var th1 = document.createElement("TH");
        th1.appendChild(document.createTextNode("Slap Id"));
        th1.style.height = "30px";
        th1.style.fontSize = "11px";
        th1.style.textAlign = "center";
        th1.style.width = "10%";

        var th2 = document.createElement("TH");
        th2.appendChild(document.createTextNode("Tax Slap From"));
        th2.style.height = "30px";
        th2.style.fontSize = "11px";
        th2.style.textAlign = "center";
        th2.style.width = "20%";

        var th3 = document.createElement("TH");
        th3.appendChild(document.createTextNode("Tax Slap To"));
        th3.style.height = "30px";
        th3.style.fontSize = "11px";
        th3.style.textAlign = "center";
        th3.style.width = "20%";
      
        var th31 = document.createElement("TH");
        th31.appendChild(document.createTextNode("Percentage"));
        th31.style.height = "30px";
        th31.style.fontSize = "11px";
        th31.style.textAlign = "center";
        th31.style.width = "10%";
   
        var th32 = document.createElement("TH");
        th32.appendChild(document.createTextNode("Tax Type"));
        th32.style.height = "30px";
        th32.style.fontSize = "11px";
        th32.style.textAlign = "center";
        th32.style.width = "20%";

        var th4 = document.createElement("TH");
        th4.appendChild(document.createTextNode(""));
        th4.style.height = "30px";
        th4.style.fontSize = "11px";
        th4.style.textAlign = "center";
        th4.style.width = "20%";
        headerRow.appendChild(th1);
        headerRow.appendChild(th2);
        headerRow.appendChild(th3);
        headerRow.appendChild(th31);
        headerRow.appendChild(th32);
        headerRow.appendChild(th4);
        tbt.appendChild(headerRow);
  

        if (Tax_Slab_Master.length > 0) {

            for (var x = 0; x < Tax_Slab_Master.length; x++) {
            var row = document.createElement("TR");
            var rid = "rc" + x;
            row.setAttribute('id', rid);
           
            var id1 = GetInnerText(id[x]);
            var T_from1 = GetInnerText(T_from[x]);
            var T_to1 = GetInnerText(T_to[x]);
            var percentge1 = GetInnerText(percentge[x]);
            var taxt_type1 = GetInnerText(taxt_type[x]);
            
       
            var td1 = document.createElement("TD");
            td1.appendChild(document.createTextNode(id1));
            td1.style.width = "10%";
            td1.style.textAlign = "left";
            td1.style.fontSize = "11px";
            td1.style.paddingLeft = "5px";

            var main_mi = document.createElement("input");
            main_mi.setAttribute('type', 'text');
            main_mi.setAttribute('value', T_from1);
            main_mi.setAttribute('id', 'input' + rid);
            main_mi.setAttribute('class', 'rdginputbox');
            main_mi.setAttribute('onKeyPress', 'return isNumberKey(event)');
            main_mi.style.display = "none";


            var main_mi1 = document.createElement("input");
            main_mi1.setAttribute('type', 'text');
            main_mi1.setAttribute('value', T_to1);
            main_mi1.setAttribute('id', 'inputfd' + rid);
            main_mi1.setAttribute('class', 'rdginputbox');
            main_mi1.setAttribute('onKeyPress', 'return isNumberKey(event)');
            main_mi1.style.display = "none";

            var main_mi2 = document.createElement("input");
            main_mi2.setAttribute('type', 'text');
            main_mi2.setAttribute('value', percentge1);
            main_mi2.setAttribute('id', 'inputst' + rid);
            main_mi2.setAttribute('class', 'rdginputbox');
            main_mi2.setAttribute('onKeyPress', 'return isNumberKey(event)');
            main_mi2.style.display = "none";

            var select_val1 = document.createElement("select");
            select_val1.setAttribute('id', 'select' + rid);
            select_val1.setAttribute('class', 'rdgdropdown');
            select_val1.style.display = "none";
            
            j_1 = document.createElement('option');
            j_1.text = "---Select----";
            j_1.value = "0";
            j_1.selected = true;

            j1_1 = document.createElement('option');
            j1_1.text = "Normal";
            j1_1.value = "1";

            j2_1 = document.createElement('option');
            j2_1.text = "Senior Citizens";
            j2_1.value = "2";

            j3_1 = document.createElement('option');
            j3_1.text = "V Senior Citizens";
            j3_1.value = "3";

            select_val1.appendChild(j_1);
            select_val1.appendChild(j1_1);
            select_val1.appendChild(j2_1);
            select_val1.appendChild(j3_1);
           
            select_val1.value = taxt_type1;
           
            var SelValue = select_val1.options[select_val1.selectedIndex].text;

            var main_span1 = document.createElement("span");
            main_span1.setAttribute('id', 'span1' + rid);
            main_span1.style.display = "block";
            main_span1.appendChild(document.createTextNode(T_from1));

            var td2 = document.createElement("TD");
            td2.appendChild(main_span1);
            td2.appendChild(main_mi);
            td2.style.width = "20%";
            td2.style.textAlign = "left";
            td2.style.fontSize = "11px";
            td2.style.paddingLeft = "5px";
         

            var main_span2 = document.createElement("span");
            main_span2.setAttribute('id', 'span2' + rid);
            main_span2.style.display = "block";
            main_span2.appendChild(document.createTextNode(T_to1));

            var td3 = document.createElement("TD");
            td3.appendChild(main_span2);
            td3.appendChild(main_mi1);
            td3.style.width = "20%";
            td3.style.textAlign = "center";
            td3.style.fontSize = "11px";
            td3.style.paddingLeft = "5px";

            var main_span3 = document.createElement("span");
            main_span3.setAttribute('id', 'span3' + rid);
            main_span3.style.display = "block";
            main_span3.appendChild(document.createTextNode(percentge1));

            var main_span4 = document.createElement("span");
            main_span4.setAttribute('id', 'span4' + rid);
            main_span4.style.display = "block";
            main_span4.appendChild(document.createTextNode(SelValue));

            var td31 = document.createElement("TD");
            td31.appendChild(main_span3);
            td31.appendChild(main_mi2);
            td31.style.width = "10%";
            td31.style.textAlign = "center";
            td31.style.fontSize = "11px";
            td31.style.paddingLeft = "5px";

            var td32 = document.createElement("TD");
            td32.appendChild(main_span4);
            td32.appendChild(select_val1);
            td32.style.width = "20%";
            td32.style.textAlign = "center";
            td32.style.fontSize = "11px";
            td32.style.paddingLeft = "5px";

            var img7 = document.createElement('img');
            img7.style.cursor = "pointer";
            img7.src = "../images/Updates-32x32.png";
            img7.style.height = "25px";
            img7.style.width = "25px";
            img7.setAttribute('id', 'img7' + rid);
            img7.setAttribute("onclick", "Update_onclick('" + id1 + "','" + rid + "');");
            img7.style.display = "none";

            var img8 = document.createElement('img');
            img8.style.cursor = "pointer";
            img8.src = "../images/dash_remove_icon.png";
            img8.style.height = "25px";
            img8.style.width = "25px";
            img8.setAttribute('id', 'img8' + rid);
            img8.setAttribute("onclick", "Cancel_onclick1('" + id1 + "','" + rid + "');");
            img8.style.display = "none";

            var img3 = document.createElement('img');
            img3.style.cursor = "pointer";
            img3.src = "../images/dash_remove_icon.png";
            img3.style.height = "25px";
            img3.style.width = "25px";  
            img3.setAttribute('id', 'img9' + rid);
            img3.setAttribute("onclick", "Delete_onclick('" + id1 + "');");
            img3.style.display = "block";

            var img6 = document.createElement('img');
            img6.style.cursor = "pointer";
            img6.src = "../images/Modify.png";
            img6.style.height = "25px";
            img6.style.width = "25px";
            img6.setAttribute('id', 'img6' + rid);
            img6.setAttribute("onclick", "Edit_onclick('" + id1 + "','" + rid + "');");
            img6.style.display = "block";

            var tble_val2 = document.createElement('TABLE');
            tble_val2.style.width = "100%";
            tble_val2.cellPadding = "0";
            tble_val2.cellSpacing = "0";
            tble_val2.border = "0";
            tble_val2.style.borderStyle = "none";
            tble_val2.style.border = "none";
            tble_val2.setAttribute('id', 'tble_val2' + rid);
            tble_val2.style.display = "block";

            var tbl_val1_tr1 = document.createElement('TR');

            var tbl_val1_td3 = document.createElement('TD');
            tbl_val1_td3.appendChild(img6);
            tbl_val1_td3.appendChild(img7);
            tbl_val1_td3.style.width = "50%";
           


            var tbl_val1_td4 = document.createElement('TD');
            tbl_val1_td4.appendChild(img3);
            tbl_val1_td4.appendChild(img8);
            tbl_val1_td4.style.width = "50%";

            tbl_val1_tr1.appendChild(tbl_val1_td3);
            tbl_val1_tr1.appendChild(tbl_val1_td4);
            tble_val2.appendChild(tbl_val1_tr1);



            var td4 = document.createElement("TD");
            td4.appendChild(tble_val2);
            td4.style.width = "20%";
            td4.style.textAlign = "Center";
            td4.style.fontSize = "11px";

            row.appendChild(td1);
            row.appendChild(td2);
            row.appendChild(td3);
            row.appendChild(td31);
            row.appendChild(td32);
            row.appendChild(td4);
            tbt.appendChild(row);
        }
    }
    var row1 = document.createElement("TR");
    var rid1 = "rc1" + 1;
    row1.setAttribute('id', rid1);

    var adtd1 = document.createElement("TD");
    adtd1.appendChild(document.createTextNode(''));
    adtd1.style.width = "10%";
    adtd1.style.textAlign = "left";
    adtd1.style.fontSize = "11px";
    adtd1.style.paddingLeft = "5px";

    var mi = document.createElement("input");
    mi.setAttribute('type', 'text');
    mi.setAttribute('value', '');
    mi.setAttribute('id', 'input' + rid1);
    mi.setAttribute('class', 'rdginputbox');
    mi.setAttribute('onKeyPress', 'return isNumberKey(event)');
    mi.style.display = "none";

    var adtd2 = document.createElement("TD");
    adtd2.appendChild(mi);
    adtd2.style.width = "20%";
    adtd2.style.textAlign = "left";
    adtd2.style.fontSize = "11px";
    adtd2.style.paddingLeft = "5px";


    var mi1 = document.createElement("input");
    mi1.setAttribute('type', 'text');
    mi1.setAttribute('value', '');
    mi1.setAttribute('id', 'inputbj' + rid1);
    mi1.setAttribute('class', 'rdginputbox');
    mi1.setAttribute('onKeyPress', 'return isNumberKey(event)');
    mi1.style.display = "none";

    var adtd3 = document.createElement("TD");
    adtd3.appendChild(mi1);
    adtd3.style.width = "20%";
    adtd3.style.textAlign = "center";
    adtd3.style.fontSize = "11px";
    adtd3.style.paddingLeft = "5px";


    var mi2 = document.createElement("input");
    mi2.setAttribute('type', 'text');
    mi2.setAttribute('value', '');
    mi2.setAttribute('id', 'inputlg' + rid1);
    mi2.setAttribute('class', 'rdginputbox');
    mi2.setAttribute('onKeyPress', 'return isNumberKey(event)');
    mi2.style.display = "none";

    var adtd31 = document.createElement("TD");
    adtd31.appendChild(mi2);
    adtd31.style.width = "10%";
    adtd31.style.textAlign = "center";
    adtd31.style.fontSize = "11px";
    adtd31.style.paddingLeft = "5px";


    var select_val = document.createElement("select");
    select_val.setAttribute('id', 'select' + rid1);
    select_val.setAttribute('class', 'rdgdropdown');
    select_val.style.display = "none";
    j = document.createElement('option');
    j.text = "---Select----";
    j.value = "0";
    j.selected = true;

    j1 = document.createElement('option');
    j1.text = "Normal";
    j1.value = "1";

    j2 = document.createElement('option');
    j2.text = "Senior Citizens";
    j2.value = "2";

    j3 = document.createElement('option');
    j3.text = "V Senior Citizens";
    j3.value = "3";

    select_val.appendChild(j);
    select_val.appendChild(j1);
    select_val.appendChild(j2);
    select_val.appendChild(j3);

    var adtd32 = document.createElement("TD");
    adtd32.appendChild(select_val);
    adtd32.style.width = "20%";
    adtd32.style.textAlign = "center";
    adtd32.style.fontSize = "11px";
    adtd32.style.paddingLeft = "5px";


    var img2 = document.createElement('img');
    img2.style.cursor = "pointer";
    img2.src = "../images/dash_add_icon.png";
    img2.style.height = "25px";
    img2.style.width = "25px";
    img2.setAttribute('id', 'img1' + rid1);
    img2.setAttribute("onclick", "onClick2('" + rid1 + "');");

    var img4 = document.createElement('img');
    img4.style.cursor = "pointer";
    img4.src = "../images/save.png";
    img4.style.height = "25px";
    img4.style.width = "25px";
    img4.setAttribute('id', 'img2' + rid1);
    img4.setAttribute("onclick", "Save_onclick('" + rid1 + "');");
    img4.style.display = "none";

    var img5 = document.createElement('img');
    img5.style.cursor = "pointer";
    img5.src = "../images/dash_remove_icon.png";
    img5.style.height = "30px";
    img5.style.width = "30px";
    img5.setAttribute('id', 'img3' + rid1);
    img5.setAttribute("onclick", "Cancel_onclick('" + rid1 + "');");
    img5.style.display = "none";

    var tble_val1 = document.createElement('TABLE');
    tble_val1.style.width = "100%";
    tble_val1.cellPadding = "0";
    tble_val1.cellSpacing = "0";
    tble_val1.border = "0";
    tble_val1.style.borderStyle = "none";
    tble_val1.style.border = "none";
    tble_val1.setAttribute('id', 'tble_val1' + rid1);
    tble_val1.style.display = "none";

    var tbl_val1_tr = document.createElement('TR');

    var tbl_val1_td1 = document.createElement('TD');
    tbl_val1_td1.style.width = "50%";
    tbl_val1_td1.appendChild(img4);


    var tbl_val1_td2 = document.createElement('TD');
    tbl_val1_td2.appendChild(img5);
    tbl_val1_td2.style.width = "50%";

    tbl_val1_tr.appendChild(tbl_val1_td1);
    tbl_val1_tr.appendChild(tbl_val1_td2);
    tble_val1.appendChild(tbl_val1_tr);
    

    var adtd4 = document.createElement("TD");
    adtd4.appendChild(img2);
    adtd4.appendChild(tble_val1);
    adtd4.style.width = "20%";
    adtd4.style.textAlign = "left";
    adtd4.style.fontSize = "11px";
    adtd4.style.paddingLeft = "5px";

    row1.appendChild(adtd1);
    row1.appendChild(adtd2);
    row1.appendChild(adtd3);
    row1.appendChild(adtd31);
    row1.appendChild(adtd32);
    row1.appendChild(adtd4);
    tbt.appendChild(row1);

    var progressBar1 = document.getElementById("progressBar1");
    progressBar1.style.display = "none";
}

function Edit_onclick(val1, val2) {
    var Image7 = document.getElementById("img7" + val2);
    Image7.style.display = "block";
    var Image8 = document.getElementById("img8" + val2);
    Image8.style.display = "block";
    var Image9 = document.getElementById("img9" + val2);
    Image9.style.display = "none";
    var Image6 = document.getElementById("img6" + val2);
    Image6.style.display = "none";
    var input = document.getElementById("input" + val2);
    input.style.display = "block";
    var inputfd = document.getElementById("inputfd" + val2);
    inputfd.style.display = "block";
    var inputst = document.getElementById("inputst" + val2);
    inputst.style.display = "block";
    var select = document.getElementById("select" + val2);
    select.style.display = "block";
    var span1 = document.getElementById("span1" + val2);
    span1.style.display = "none";
    var span2 = document.getElementById("span2" + val2);
    span2.style.display = "none";
    var span3 = document.getElementById("span3" + val2);
    span3.style.display = "none";
    var span4 = document.getElementById("span4" + val2);
    span4.style.display = "none";
}

function Update_onclick(val1, val2) {
    var input1 = document.getElementById("input" + val2);
    var inputfd = document.getElementById("inputfd" + val2);
    var inputst = document.getElementById("inputst" + val2);
    var select = document.getElementById("select" + val2);
    var SelValue = select.options[select.selectedIndex].value;
    if (input1.value == "") {
        window.alert("Enter Tax From Amount.");
        input1.focus();
        return false;
    }

    if (inputfd.value == "") {
        window.alert("Enter Tax To Amount.");
        inputfd.focus();
        return false;
    }

    if (inputst.value == "") {
        window.alert("Enter Tax Percentage.");
        inputst.focus();
        return false;
    }
    if (SelValue == "0") {
        window.alert("Select Tax Type.");
        select.focus();
        return false;
    }
    Income_Tax_Details.update_slap_Type_Master(val1, input1.value, inputfd.value, inputst.value,SelValue, update_Result_final);
}

function update_Result_final(result) {
    if (result > 0) {
        var progressBar1 = document.getElementById("progressBar1");
        progressBar1.style.display = "block";
        Income_Tax_Details.Get_Tax_Slap_Master(Fill_Investment_Type_Master);
    }
}

function Cancel_onclick1(val1, val2) {
    var Image7 = document.getElementById("img7" + val2);
    Image7.style.display = "none";
    var Image8 = document.getElementById("img8" + val2);
    Image8.style.display = "none";
    var Image9 = document.getElementById("img9" + val2);
    Image9.style.display = "block";
    var Image6 = document.getElementById("img6" + val2);
    Image6.style.display = "block";
    var input = document.getElementById("input" + val2);
    input.style.display = "none";
    var inputfd = document.getElementById("inputfd" + val2);
    inputfd.style.display = "none";
    var inputst = document.getElementById("inputst" + val2);
    inputst.style.display = "none";
    var select = document.getElementById("select" + val2);
    select.style.display = "none";
    var span1 = document.getElementById("span1" + val2);
    span1.style.display = "block";
    var span2 = document.getElementById("span2" + val2);
    span2.style.display = "block";
    var span3 = document.getElementById("span3" + val2);
    span3.style.display = "block";
    var span4 = document.getElementById("span4" + val2);
    span4.style.display = "block";  
}


function onClick2(value) {

    var Image1 = document.getElementById("img1" + value);
    Image1.style.display = "none";
    var tble_val1 = document.getElementById("tble_val1" + value);
    tble_val1.style.display = "block";
    var Image2 = document.getElementById("img2" + value);
    Image2.style.display = "block";
    var Image3 = document.getElementById("img3" + value);
    Image3.style.display = "block";
    var input1 = document.getElementById("input" + value);
    input1.style.display = "block";
    var inputbj = document.getElementById("inputbj" + value);
    inputbj.style.display = "block";
    var inputlg = document.getElementById("inputlg" + value);
    inputlg.style.display = "block";
    var select = document.getElementById("select" + value);
    select.style.display = "block";
}

function Cancel_onclick(source) {
    var tble_val1 = document.getElementById("tble_val1" + source);
    tble_val1.style.display = "none";
    var Image1 = document.getElementById("img1" + source);
    Image1.style.display = "block";
    var Image2 = document.getElementById("img2" + source);
    Image2.style.display = "none";
    var Image3 = document.getElementById("img3" + source);
    Image3.style.display = "none";
    var input1 = document.getElementById("input" + source);
    input1.style.display = "none";
    var inputbj = document.getElementById("inputbj" + source);
    inputbj.style.display = "none";
    var inputlg = document.getElementById("inputlg" + source);
    inputlg.style.display = "none";
    var select = document.getElementById("select" + source);
    select.style.display = "none";
}

function Save_onclick(source) {
    var input1 = document.getElementById("input" + source);
    var inputbj = document.getElementById("inputbj" + source);
    var inputlg = document.getElementById("inputlg" + source);
    var select = document.getElementById("select" + source);
    var SelValue = select.options[select.selectedIndex].value;

    if (input1.value == "") {
        window.alert("Enter Tax From Amount.");
        input1.focus();
        return false;
    }

    if (inputbj.value == "") {
        window.alert("Enter Tax To Amount.");
        inputbj.focus();
        return false;
    }

    if (inputlg.value == "") {
        window.alert("Enter Tax Percentage.");
        inputlg.focus();
        return false;
    }

    if (SelValue == "0") {
        window.alert("Select Tax Type.");
        select.focus();
        return false;
    }

    Income_Tax_Details.insert_Tax_Slap_Master(input1.value, inputbj.value, inputlg.value,SelValue, Inserted_Result_final);
}

function Inserted_Result_final(result) {
    if (result > 0) {
        var progressBar1 = document.getElementById("progressBar1");
        progressBar1.style.display = "block";
        Income_Tax_Details.Get_Tax_Slap_Master(Fill_Investment_Type_Master);
    }
}

function Delete_onclick(source) {

    var Confm =confirm("Do You want to delete record");
    if (Confm == true) {
        Income_Tax_Details.Delete_Tax_slap_Master(source, Delete_Investment_Type_Master);
    }
}

function Delete_Investment_Type_Master(result) {
    if (result > 0) {
        var progressBar1 = document.getElementById("progressBar1");
        progressBar1.style.display = "block";
        Income_Tax_Details.Get_Tax_Slap_Master(Fill_Investment_Type_Master);
    }
}

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;
    return true;
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
