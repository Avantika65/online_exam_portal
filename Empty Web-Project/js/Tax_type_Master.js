window.onload = init;
var valuec;
function init() {
    var progressBar1 = document.getElementById("progressBar1");
    progressBar1.style.display = "block";
    Income_Tax_Details.Get_Investment_Type_Master(Fill_Investment_Type_Master);
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

    var Invest_type = root.getElementsByTagName("Invest_type");
    var Invest_id = root.getElementsByTagName("Invest_id");
    var Invest_name = root.getElementsByTagName("Invest_name");
    var Status = root.getElementsByTagName("Status");
    var tbt = document.createElement("TBODY");
    element.appendChild(tbt);

  
        var headerRow = document.createElement("TR");
        var th1 = document.createElement("TH");
        th1.appendChild(document.createTextNode("Investment Id"));
        th1.style.height = "30px";
        th1.style.fontSize = "11px";
        th1.style.textAlign = "center";
        th1.style.width = "15%";

        var th2 = document.createElement("TH");
        th2.appendChild(document.createTextNode("Investment Name"));
        th2.style.height = "30px";
        th2.style.fontSize = "11px";
        th2.style.textAlign = "center";
        th2.style.width = "35%";

        var th3 = document.createElement("TH");
        th3.appendChild(document.createTextNode("Status"));
        th3.style.height = "30px";
        th3.style.fontSize = "11px";
        th3.style.textAlign = "center";
        th3.style.width = "20%";

        var th4 = document.createElement("TH");
        th4.appendChild(document.createTextNode(""));
        th4.style.height = "30px";
        th4.style.fontSize = "11px";
        th4.style.textAlign = "center";
        th4.style.width = "30%";
        headerRow.appendChild(th1);
        headerRow.appendChild(th2);
        headerRow.appendChild(th3);
        headerRow.appendChild(th4);
        tbt.appendChild(headerRow);
  

    if (Invest_type.length > 0) {

        for (var x = 0; x < Invest_type.length; x++) {
            var row = document.createElement("TR");
            var rid = "rc" + x;
            row.setAttribute('id', rid);
           

  
            var Invest_id1 = GetInnerText(Invest_id[x]);
            var Invest_name1 = GetInnerText(Invest_name[x]);
            var Status1 = GetInnerText(Status[x]);

            var td1 = document.createElement("TD");
            td1.appendChild(document.createTextNode(Invest_id1));
            td1.style.width = "10%";
            td1.style.textAlign = "left";
            td1.style.fontSize = "11px";
            td1.style.paddingLeft = "5px";


            var main_mi = document.createElement("input");
            main_mi.setAttribute('type', 'text');
            main_mi.setAttribute('value', Invest_name1);
            main_mi.setAttribute('id', 'input' + rid);
            main_mi.setAttribute('class', 'rdginputbox');
            main_mi.style.display = "none";


            var main_span1 = document.createElement("span");
            main_span1.setAttribute('id', 'span1' + rid);
            main_span1.style.display = "block";
            main_span1.appendChild(document.createTextNode(Invest_name1));

            var td2 = document.createElement("TD");
            td2.appendChild(main_span1);
            td2.appendChild(main_mi);
            td2.style.width = "45%";
            td2.style.textAlign = "left";
            td2.style.fontSize = "11px";
            td2.style.paddingLeft = "5px";
            var stat = "";
            if (Status1 == 'Y') {
                stat = "Active";
            }
            else {
                stat = "Inactive";
            }

            var main_mi1 = document.createElement("input");
            main_mi1.setAttribute('type', 'checkbox');
            main_mi1.setAttribute('value', '');
            main_mi1.setAttribute('id', 'check' + rid);
            main_mi1.style.width = "99%";
            main_mi1.style.display = "none";
            if (Status1 == 'Y') {
                main_mi1.checked = true;
            }
            else {
                main_mi1.checked = false;
            }
            var main_span2 = document.createElement("span");
            main_span2.setAttribute('id', 'span2' + rid);
            main_span2.style.display = "block";
            main_span2.appendChild(document.createTextNode(stat));

            var td3 = document.createElement("TD");
            td3.appendChild(main_span2);
            td3.appendChild(main_mi1);
            td3.style.width = "20%";
            td3.style.textAlign = "center";
            td3.style.fontSize = "11px";
            td3.style.paddingLeft = "5px";

            var img7 = document.createElement('img');
            img7.style.cursor = "pointer";
            img7.src = "../images/Updates-32x32.png";
            img7.style.height = "25px";
            img7.style.width = "25px";
            img7.setAttribute('id', 'img7' + rid);
            img7.setAttribute("onclick", "Update_onclick('" + Invest_id1 + "','" + rid + "');");
            img7.style.display = "none";

            var img8 = document.createElement('img');
            img8.style.cursor = "pointer";
            img8.src = "../images/dash_remove_icon.png";
            img8.style.height = "25px";
            img8.style.width = "25px";
            img8.setAttribute('id', 'img8' + rid);
            img8.setAttribute("onclick", "Cancel_onclick1('" + Invest_id1 + "','" + rid + "');");
            img8.style.display = "none";

            var img3 = document.createElement('img');
            img3.style.cursor = "pointer";
            img3.src = "../images/dash_remove_icon.png";
            img3.style.height = "25px";
            img3.style.width = "25px";
            img3.setAttribute('id', 'img9' + rid);
            img3.setAttribute("onclick", "Delete_onclick('" + Invest_id1 + "');");
            img3.style.display = "block";

            var img6 = document.createElement('img');
            img6.style.cursor = "pointer";
            img6.src = "../images/Modify.png";
            img6.style.height = "25px";
            img6.style.width = "25px";
            img6.setAttribute('id', 'img6' + rid);
            img6.setAttribute("onclick", "Edit_onclick('" + Invest_id1 + "','" + rid + "');");
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
            row.appendChild(td4);
            tbt.appendChild(row);
        }
    }
    var row1 = document.createElement("TR");
    var rid1 = "rc1" + 1;
    row1.setAttribute('id', rid1);

    var adtd1 = document.createElement("TD");
    adtd1.appendChild(document.createTextNode(''));
    adtd1.style.width = "15%";
    adtd1.style.textAlign = "left";
    adtd1.style.fontSize = "11px";
    adtd1.style.paddingLeft = "5px";

    var mi = document.createElement("input");
    mi.setAttribute('type', 'text');
    mi.setAttribute('value', '');
    mi.setAttribute('id', 'input' + rid1);
    mi.setAttribute('class', 'rdginputbox');
    mi.style.display = "none";

    var adtd2 = document.createElement("TD");
    adtd2.appendChild(mi);
    adtd2.style.width = "35%";
    adtd2.style.textAlign = "left";
    adtd2.style.fontSize = "11px";
    adtd2.style.paddingLeft = "5px";


    var mi1 = document.createElement("input");
    mi1.setAttribute('type', 'checkbox');
    mi1.setAttribute('value', '');
    mi1.setAttribute('id', 'check' + rid1);
    mi1.style.width = "99%";
    mi1.style.display = "none";

    var adtd3 = document.createElement("TD");
    adtd3.appendChild(mi1);
    adtd3.style.width = "20%";
    adtd3.style.textAlign = "center";
    adtd3.style.fontSize = "11px";
    adtd3.style.paddingLeft = "5px";


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
    adtd4.style.width = "30%";
    adtd4.style.textAlign = "left";
    adtd4.style.fontSize = "11px";
    adtd4.style.paddingLeft = "5px";

    row1.appendChild(adtd1);
    row1.appendChild(adtd2);
    row1.appendChild(adtd3);
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
    var check = document.getElementById("check" + val2);
    check.style.display = "block";
    var input = document.getElementById("input" + val2);
    input.style.display = "block";
    var span1 = document.getElementById("span1" + val2);
    span1.style.display = "none";
    var span2 = document.getElementById("span2" + val2);
    span2.style.display = "none";
    
}

function Update_onclick(val1, val2) {
    var input1 = document.getElementById("input" + val2);
    if (input1.value == "") {
        window.alert("Enter Investment Name.");
        input1.focus();
        return false;
    }
    var check1 = document.getElementById("check" + val2);
  
    var chk_val = "";
    if (check1.checked == true) {
        chk_val = 'Y';
    }
    else {
        chk_val = 'N';
    }
    Income_Tax_Details.update_Investment_Type_Master(val1, input1.value, chk_val, update_Result_final);
}

function update_Result_final(result) {
    if (result > 0) {
        var progressBar1 = document.getElementById("progressBar1");
        progressBar1.style.display = "block";
        Income_Tax_Details.Get_Investment_Type_Master(Fill_Investment_Type_Master);
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
    var check = document.getElementById("check" + val2);
    check.style.display = "none";
    var input = document.getElementById("input" + val2);
    input.style.display = "none";
    var span1 = document.getElementById("span1" + val2);
    span1.style.display = "block";
    var span2 = document.getElementById("span2" + val2);
    span2.style.display = "block";
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
    var check1 = document.getElementById("check" + value);
    check1.style.display = "block";
 
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
    var check1 = document.getElementById("check" + source);
    check1.style.display = "none";
}

function Save_onclick(source) {
    var input1 = document.getElementById("input" + source);
    if (input1.value == "") {
        window.alert("Enter Investment Name.");
        input1.focus();
        return false;
    }
    var check1 = document.getElementById("check" + source);
   
    var chk_val = "";
    if (check1.checked == true) {
        chk_val = 'Y';
    }
    else {
        chk_val = 'N';
    }
    Income_Tax_Details.insert_Investment_Type_Master(input1.value, chk_val, Inserted_Result_final);
}

    function Inserted_Result_final(result) {
        if (result > 0) {
            var progressBar1 = document.getElementById("progressBar1");
            progressBar1.style.display = "block";
            Income_Tax_Details.Get_Investment_Type_Master(Fill_Investment_Type_Master);
        }
    }

    function Delete_onclick(source) {
        var Confm =confirm("Do You want to delete record");
        if (Confm == true) {
            Income_Tax_Details.Delete_Investment_Type_Master(source, Delete_Investment_Type_Master);
        }
    }

    function Delete_Investment_Type_Master(result) {
        if (result > 0) {
            var progressBar1 = document.getElementById("progressBar1");
            progressBar1.style.display = "block";
            Income_Tax_Details.Get_Investment_Type_Master(Fill_Investment_Type_Master);
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
