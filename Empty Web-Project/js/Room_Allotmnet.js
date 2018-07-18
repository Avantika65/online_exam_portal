var id1 = "";

function Check(id) {
   
    var index = id.parentElement.parentElement.rowIndex;
    id1 = index;
    var totalseat = document.getElementById("txttotal_Seats");
    var hdnval = document.getElementById("hdnseat");

    if (hdnval.value == 0) {
       
        totalseat.value = 0;
    }
    else {
       
        totalseat.value = hdnval.value;
    }

       
    var gv = document.getElementById("GrdRoomAllotment");
    var ddlCou = document.getElementById("ddlCourse");

    var chk = gv.getElementsByTagName("input");

    for (var i = 0; i < chk.length; i++) {

        if (chk[i].type == "checkbox" && chk[i].checked) {

            var ddlValue = gv.rows[i + 1].cells[1].innerHTML;
            totalseat.value = parseInt(totalseat.value) + parseInt(ddlValue);

        }
        }



}

function getdata1(result) {
   
    if (result == 1) {
        alert("Room Already alloted to that course");
       
        var gv = document.getElementById("GrdRoomAllotment");
        var chk = gv.getElementsByTagName("input");

       
        for (var i = 0; i < chk.length; i++) {
           
                if (id1 == i) {
                    alert("d");
                    chk[i].checked = false;
                }
           
          }

    }
    else {
        var totalseat = document.getElementById("txttotal_Seats");
        alert(totalseat.value);
    var gv = document.getElementById("GrdRoomAllotment");
     var chk = gv.getElementsByTagName("input");
    
    if(totalseat.value=="")
         totalseat.value = 0;
    
    for (var i = 0; i < chk.length; i++) {

        if (chk[i].type == "checkbox" && chk[i].checked==true) {
           
            var ddlValue = gv.rows[i + 1].cells[1].innerHTML;
            totalseat.value = parseInt(totalseat.value) + parseInt(ddlValue);

        }
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