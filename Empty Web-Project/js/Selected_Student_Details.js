function Sel_s_onclick(as, Sid, j_id) {
   
    var valu = document.getElementById("Stud_Details");
    valu.style.display = "block";
    C2p.Show_SelStud_details(as, Sid, j_id, Fill_Job_details_bind);

    //C2p.Status(c_id, Fill_Job_details_bind2);
}

function CloseBtn_onclick() {
    var valu = document.getElementById("Stud_Details");
    valu.style.display = "none";
}

function Fill_Job_details_bind(result) {
   
    var xml = parseXml(result)
    if (xml) {
        Fill_Job_details(xml.documentElement);
    }
}

function Fill_Job_details(root) {

    S_Name = document.getElementById("S_Name");
    Con_no = document.getElementById("Con_no");
    Email = document.getElementById("Email");
    Stud_Add = document.getElementById("Stud_Add");
    Course_Name = document.getElementById("Course_Name");
    Spl = document.getElementById("Spl");
    S_Batch = document.getElementById("S_Batch");
    Comp_Name = document.getElementById("Comp_Name");
    Designam = document.getElementById("Designam");
    Join_Loc = document.getElementById("Join_Loc");
    S_Pacage = document.getElementById("S_Pacage");

   
    var Selected_Student_View = root.getElementsByTagName("Selected_Student_View");
    var Stud_Name = root.getElementsByTagName("Stud_Name");
    var LandlineNo = root.getElementsByTagName("LandlineNo");
    var Email = root.getElementsByTagName("Email");
    var PAddress = root.getElementsByTagName("PAddress");
    var CourseName = root.getElementsByTagName("CourseName");
    var shortName = root.getElementsByTagName("shortName");

    var Batch = root.getElementsByTagName("Batch");
    var comp_name = root.getElementsByTagName("comp_name");
    var desig = root.getElementsByTagName("desig");
    var CityName = root.getElementsByTagName("CityName");
    var ctc_incen = root.getElementsByTagName("ctc_incen");


    if (Selected_Student_View.length > 0) {

        S_Name.innerText = GetInnerText(Stud_Name[0]);
        S_Name.textContext = GetInnerText(Stud_Name[0]);

        Con_no.innerText = GetInnerText(LandlineNo[0]);
        Con_no.textContext = GetInnerText(LandlineNo[0]);

        Email.innerText = GetInnerText(Email[0]);
        Email.textContext = GetInnerText(Email[0]);

        Stud_Add.innerText = GetInnerText(PAddress[0]);
        Stud_Add.textContext = GetInnerText(PAddress[0]);

        Course_Name.innerText = GetInnerText(CourseName[0]);
        Course_Name.textContext = GetInnerText(CourseName[0]);

        Spl.innerText = GetInnerText(shortName[0]);
        Spl.textContext = GetInnerText(shortName[0]);

        S_Batch.innerText = GetInnerText(Batch[0]);
        S_Batch.textContext = GetInnerText(Batch[0]);

        Comp_Name.innerText = GetInnerText(comp_name[0]);
        Comp_Name.textContext = GetInnerText(comp_name[0]);

        Designam.innerText = GetInnerText(desig[0]);
        Designam.textContext = GetInnerText(desig[0]);

        Join_Loc.innerText = GetInnerText(CityName[0]);
        Join_Loc.textContext = GetInnerText(CityName[0]);

        S_Pacage.innerText = GetInnerText(ctc_incen[0]);
        S_Pacage.textContext = GetInnerText(ctc_incen[0]);

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
