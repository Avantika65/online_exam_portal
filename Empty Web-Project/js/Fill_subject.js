function Fill_Grid() {

    
    var div = document.getElementById("Div1");
    var grid = document.getElementById("GridView1");
    var ddlSubject = document.getElementById("ddlSubject");

    div.style.display = "block";
    grid.style.display = "none";
    var ddlExam = document.getElementById("ddlExam");
    var subjectID = ddlSubject.options[ddlSubject.selectedIndex].value;
    var examid = ddlExam.options[ddlExam.selectedIndex].value;


    if (examid == "0" && subjectID!="0") {

        Calender_details.Bind_grid1(subjectID, Fill_Vacancy);
     }
    else {
        if (examid != "0" && subjectID == "0") {
           
            Calender_details.Bind_grid(examid, Fill_Vacancy);
        }
        else {
           
            Calender_details.Bind_Alldata(examid, subjectID, Fill_Vacancy);
        }
    }


}
function Fill_Grid1() {

    
    var div = document.getElementById("Div1");
    var grid = document.getElementById("GridView1");
    var ddlSubject = document.getElementById("ddlSubject");

    div.style.display = "block";
    grid.style.display = "none";
    var ddlExam = document.getElementById("ddlExam");
    var examid = ddlExam.options[ddlExam.selectedIndex].value;
    var subjectID = ddlSubject.options[ddlSubject.selectedIndex].value;
    

    if (examid == "0" && subjectID!="0") {

        Calender_details.Bind_grid1(subjectID, Fill_Vacancy);
     }
    else {
        if (examid != "0" && subjectID == "0") {
           
            Calender_details.Bind_grid(examid, Fill_Vacancy);
        }
        else {
            
            Calender_details.Bind_Alldata(examid, subjectID, Fill_Vacancy);
        }
    }


}


function Fill_Vacancy(result) {
    if (result == "") {
     
        var mypoup = document.getElementById('Div1');
        var trt = mypoup.getElementsByTagName("TR");
        var lnt = trt.length;
        
        for (var i = 0; i < trt.length; i++) {
            mypoup.removeChild(mypoup.childNodes[i]);
            lnt--;
            
        }
        mypoup.style.display = "block";
        var tbt = document.createElement("TBODY");
        mypoup.appendChild(tbt);
        var blankRow = document.createElement("TR");
        var blanktd = document.createElement("TD");
        blanktd.style.verticalAlign = "middle";
        blanktd.style.textAlign = "center";
        blanktd.style.width = "10%";
        var img = document.createElement("img");
        img.src = "../images/no_data.png";
        blanktd.appendChild(img);
        blankRow.appendChild(blanktd);
        tbt.appendChild(blankRow);
    }
    else {
            
         
        var mypoup = document.getElementById('Div1');
        mypoup.style.display = "block";
        
        mypoup.innerHTML = result;
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