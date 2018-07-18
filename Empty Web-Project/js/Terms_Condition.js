
var srno = 0;
var valuec;


function Submit() {
    var rule = document.getElementById("TextBox1");
    if (rule.value == "") {
       window.alert("Please Enter rule name...");
    }
    else {
        getdata1();
    }
}

function getdata1(result) {
    
    var xml = parseXml(result); //pass result string into function for xml conversion.
    if (xml) {
        get_holiday_valueFist(xml.documentElement); // call the bindgrid method and pass the root element of of xml form in the function.
    }

}

function get_holiday_valueFist(root) {
   
    var rule = document.getElementById("TextBox1");
    var element = document.getElementById("xGrid");
    var trt = element.getElementsByTagName("TR");
    var lnt = trt.length;

    Calender_details.insert_Rule(rule.value);
        for (var i = 1; i < lnt; i++) {

            var txtvalue = document.getElementById("Type" + i);
            var txtvalue1 = document.getElementById("Action" + i);
            if (txtvalue.value == "") {
                alert("Please Enter vlaue in after no of days..");
                txtvalue.focus();
            }
            else {
                if (txtvalue1.value == "") {
                    alert("Please Enter value in marks detection in % of days..");
                }
                else {
                   
                    Calender_details.insert_Condition( txtvalue.value, txtvalue1.value);
                    
                }
            }


        }
       
        alert("Data Submit Sucessfully");
        rule.value = "";

}

function OnSuccess(response) {
//    var xmlDoc = $.parseXML(response.d);
//    var xml = $(xmlDoc);
//    var customers = xml.find("Table");
//    var row = $("[id*=gvCustomers] tr:last-child").clone(true);
//    $("[id*=gvCustomers] tr").not($("[id*=gvCustomers] tr:first-child")).remove();
//    $.each(customers, function () {
//        var customer = $(this);
//        $("td", row).eq(0).html($(this).find("CustomerID").text());
//        $("td", row).eq(1).html($(this).find("ContactName").text());
//        $("td", row).eq(2).html($(this).find("City").text());
//        $("[id*=gvCustomers]").append(row);
//        row = $("[id*=gvCustomers] tr:last-child").clone(true);
//    });
}


function Fill_Investment_Type_Master() {
  
   
        var div = document.getElementById("div");
        var div1 = document.getElementById("divBtn");
        div1.style.display = "block";
        div.style.display = "block";
        bindgrid();
    }

function bindgrid() {

    var element = document.getElementById("xGrid");
    var trt = element.getElementsByTagName("TR");
    var lnt = trt.length;
   
    var tbt = document.createElement("TBODY");
    element.appendChild(tbt);
   
    if (trt.length <= 0) {

        lnt = 1;

        var headerRow = document.createElement("TR");
        var th1 = document.createElement("TH");
        th1.appendChild(document.createTextNode("S.No"));
        th1.style.height = "30px";
        th1.style.fontSize = "11px";
        th1.style.textAlign = "center";
        th1.style.width = "10%";

        var th2 = document.createElement("TH");
        th2.appendChild(document.createTextNode("After NO OF Days"));
        th2.style.height = "30px";
        th2.style.fontSize = "11px";
        th2.style.textAlign = "center";
        th2.style.width = "20%";

        var th3 = document.createElement("TH");
        th3.appendChild(document.createTextNode("Marks detection"));
        th3.style.height = "30px";
        th3.style.fontSize = "11px";
        th3.style.textAlign = "center";
        th3.style.width = "20%";

        var th4 = document.createElement("TH");
        th4.appendChild(document.createTextNode(''));
        th4.style.height = "30px";
        th4.style.fontSize = "11px";
        th4.style.textAlign = "center";
        th4.style.width = "20%";

        var th5 = document.createElement("TH");
        th5.appendChild(document.createTextNode(''));
        th5.style.height = "30px";
        th5.style.fontSize = "11px";
        th5.style.textAlign = "center";
        th5.style.width = "20%";

        headerRow.appendChild(th1);
        headerRow.appendChild(th2);
        headerRow.appendChild(th3);
        headerRow.appendChild(th4);
        headerRow.appendChild(th5);
        tbt.appendChild(headerRow);
    }
    var row = document.createElement("TR");



    var td3 = document.createElement("TD");
    td3.appendChild(document.createTextNode(trt.length));
    td3.style.width = "10%";
    td3.style.textAlign = "center";
    td3.style.fontSize = "11px";
    td3.style.paddingLeft = "5px";


    var mi4 = document.createElement("input");
    mi4.setAttribute('type', 'text');
    mi4.setAttribute('value', '');
    mi4.setAttribute('id', 'Type' + (lnt));
    mi4.setAttribute('class', 'rdginputbox');
    mi4.setAttribute("onKeyPress", "return isNumberKey(event)");
    mi4.style.display = "block";

  var  td4 = document.createElement("TD");
    td4.appendChild(mi4);
  
    td4.style.width = "40%";
    td4.style.textAlign = "center";
    td4.style.fontSize = "11px";
    td4.style.paddingLeft = "5px";


    var mi5 = document.createElement("input");
    mi5.setAttribute('type', 'text');
    mi5.setAttribute('value', '');
    mi5.setAttribute('id', 'Action' + (lnt));
    mi5.setAttribute('class', 'rdginputbox');
    mi5.setAttribute("onKeyPress", "return isNumberKey1(event)");
    mi5.style.display = "block";

   var td5 = document.createElement("TD");
    td5.appendChild(mi5);

    td5.style.width = "40%";
    td5.style.textAlign = "center";
    td5.style.fontSize = "11px";
    td5.style.paddingLeft = "5px";


    var img2 = document.createElement('img');
    img2.style.cursor = "pointer";
    img2.src = "../images/dash_add_icon.png";
    img2.style.height = "25px";
    img2.style.width = "25px";
    img2.setAttribute('id', 'img' + (lnt));
    img2.setAttribute("onclick", "add_onclick();");

    var td6 = document.createElement("TD");
    td6.appendChild(img2);

    td6.style.width = "10%";
    td6.style.textAlign = "center";
    td6.style.fontSize = "11px";
    td6.style.paddingLeft = "5px";

    var imgRemove = document.createElement('img');
    imgRemove.style.cursor = "pointer";
    imgRemove.src = "../images/dash_remove_icon.png";
    imgRemove.style.height = "25px";
    imgRemove.style.width = "25px";
    imgRemove.setAttribute('id', 'img1' + (lnt));
    imgRemove.setAttribute("onclick", "remove_onclick('" + lnt + "');");

    var td7 = document.createElement("TD");
    td7.appendChild(imgRemove);

    td7.style.width = "10%";
    td7.style.textAlign = "center";
    td7.style.fontSize = "11px";
    td7.style.paddingLeft = "5px";


    row.appendChild(td3);
    row.appendChild(td4);
    row.appendChild(td5);
    row.appendChild(td6);
    row.appendChild(td7);
    tbt.appendChild(row);

}

function add_onclick(val1, val2) {

    Fill_Investment_Type_Master();
}

function remove_onclick(val1) {
  
    var element = document.getElementById("xGrid");
    var trt = element.getElementsByTagName("TR");
    var lnt = trt.length;
   
    if (lnt == "2") {

        val1.disabled = true;       

    }
    else {
        
        element.deleteRow(val1);

        
    }

}

function isNumberKey(evt) {
    
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        alert("Enter number");
        return false;
    }
    return true;
}


function isNumberKey1(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
   if((charCode != 45 || $(element).val().indexOf('-') != -1) &&(charCode != 46 || $(element).val().indexOf('.') != -1) &&(charCode < 48 || charCode > 57)) {
       alert("Enter only number and decimal value");
            return false;
            }
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


function subtopic_Function() {

}
