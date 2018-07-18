


var day = 0;
var data = "";
function save() {

    var button = document.getElementById("Button1");
    var grd = document.getElementById("GridView3");
    var checkBoxes = grd.getElementsByTagName("input");

    var p1 = null, p2 = null, p3 = null, p4 = null, p5 = null, p6 = null, p7 = null, p8 = null, p9 = null, p10 = null;

    for (var i = 1; i < grd.rows.length; i++) {
        
        day = i;
        for (j = 2; j < grd.rows[i].cells.length; j++) 
        {

            var MDay = grd.rows[i].cells[j].innerHTML;
            var p = 'null';

            if (MDay == "Lunch") 
            {
                //                alert("lunch");
                p = 0;
            }
            else
             {
                var k = i;
                var grid = "GridView3_ctl0" + (k + 1) + "_chk" + (j - 2);

                var val = document.getElementById(grid);

                if (val.type == "checkbox" )
                {
                if( val.checked) {
                        p = 1;
                    }
                    else {
                        p = 0;
                    }
                }
                
            }
            if (j == 2) {
                p1 = p;
            }
            if (j == 3) {
                p2 = p;
            }
            if (j == 4) {
                p3 = p;
            }
            if (j == 5) {
                p4 = p;
            }
            if (j == 6) {
                p5 = p;
            }
            if (j == 7) {
                p6 = p;
            }
            if (j == 8) {
                p7 = p;
            }
            if (j == 9) {
                p8 = p;
            }
            if (j == 10) {
                p9 = p;
            }
            if (j == 11) {
                p10 = p;
            }


        }
        var p = 'null';
        if (button.value == 'Save') {
            data = "1";
            Calender_details.insert_period_aval(data,i, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, getdata1);
        }
        else {
            data = "2";
            Calender_details.insert_period_aval(data,i, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, getdata1);
        }
    }
    grd.style.display = "none";
}
function getdata1(result) {
    var frmvalue = result;
    
    var grd = document.getElementById("GridView3");
 
    if (frmvalue == (grd.rows.length-1)) {
        if (data == "1") {
            alert("Data Saved Sucessfully");
            return false;
        }
        else {
            alert("Data Updated Sucessfully");
            return false;
        }
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


    function subtopic_Function() {

    }

