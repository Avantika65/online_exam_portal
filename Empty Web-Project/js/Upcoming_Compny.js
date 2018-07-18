var c_id;
var JOBB_id;
var staus;
var btn_Apply;
function btnVwCompnis_onclick(as,J_id) {

    c_id = as;
    JOBB_id = J_id;
    var valu = document.getElementById("contentE");
    var divbk = document.getElementById("divBG");
    valu.style.display = "block";
    divbk.style.display = "none";
    C2p.Show_Job_details(as, J_id, Fill_Job_details_bind00);

    //C2p.Status(c_id, Fill_Job_details_bind2);
}

function Aply_nw_onclick() {
   
    var valu1 = document.getElementById("Aply_nw");
    btn_Apply = valu1
    C2p.insertApply_detls(c_id, JOBB_id, Fill_Job_details_bind00);
    C2p.Status(c_id, JOBB_id, Fill_Job_details_bind2);
    //valu.style.display = "none";
}

function Fill_Job_details_bind2(result) {
    staus = result;
   
    LblSel_Pross = document.getElementById("Lbl_Status");
    if (result != "") {
        if (result == "Applied") {
            LblSel_Pross.style.color = "green";
            LblSel_Pross.innerText = "Applied Successfully, Pending For Approval";
            LblSel_Pross.textContext = "Applied Successfully, Pending For Approval";
        }
        else if (result == "Waiting") {
            LblSel_Pross.style.color = "red";
            LblSel_Pross.innerText = "Applied Successfully, Pending For Approval";
            LblSel_Pross.textContext = "Applied Successfully, Pending For Approval";
        }
        else if (result == "Allow") {
            LblSel_Pross.style.color = "green";
            LblSel_Pross.innerText = "You are allowed to appear";
            LblSel_Pross.textContext = "You are allowed to appear";
        }
        else {
            LblSel_Pross.style.color = "red";
            LblSel_Pross.innerText = "Not Allowed";
            LblSel_Pross.textContext = "Not Allowed";
            var Msg = document.getElementById("LblMSG");
            Msg.style.display = "block";
        }
    }
    else {
        LblSel_Pross.innerText = "";
        LblSel_Pross.textContext = "";
    }

    
    if (staus != "") {
        var valu1 = document.getElementById("Aply_nw");
        valu1.style.display = "none";
    }
    else 
    {
        var valu1 = document.getElementById("Aply_nw");
        valu1.style.display = "block";

    }
     //////////////
   
    
}


function BtnClose_onclick() {
    var valu = document.getElementById("contentE");
    var divbk = document.getElementById("divBG");
    
    divbk.style.display = "block";
    valu.style.display = "none";
}

function Fill_Job_details_bind00(result) {
   
    var xml = parseXml(result)
    if (xml) {
        Fill_Job_detailsL(xml.documentElement);
       
    }
}

function Fill_Job_detailsL(root) {

   
    Lbl_Compny = document.getElementById("Lbl_Compny");
    Lbl_Ctype = document.getElementById("Lbl_Ctype");
    Lbl_Joblocation = document.getElementById("Lbl_Joblocation");
    Lbl_JobPostDate = document.getElementById("Lbl_JobPostDate");
    LblAdd = document.getElementById("LblAdd");
    LblCity = document.getElementById("LblCity");
    LblCOff = document.getElementById("LblCOff");
    LblCity = document.getElementById("LblCity");
    LblCon_no = document.getElementById("LblCon_no");
    LblContry = document.getElementById("LblContry");
    LblEgap = document.getElementById("LblEgap");
    LblEmail_Comp = document.getElementById("LblEmail_Comp");
    LblState = document.getElementById("LblState");
    LblEv_Date = document.getElementById("LblEv_Date");
    LblCTC = document.getElementById("LblCTC");
    LblDesig = document.getElementById("LblDesig"); 
    LblBond = document.getElementById("LblBond");
    Lbl_JobTitle = document.getElementById("Lbl_JobTitle");
    LblRoll = document.getElementById("LblRoll");

    
    var Stud_job_details_view = root.getElementsByTagName("Stud_job_details_view");
    var comp_name = root.getElementsByTagName("comp_name");
    var Type = root.getElementsByTagName("Type");
    var e_mail = root.getElementsByTagName("e_mail");
    var phone_no = root.getElementsByTagName("phone_no");
    var desig = root.getElementsByTagName("desig");
    var roll = root.getElementsByTagName("roll");
   
    var cutt_off = root.getElementsByTagName("cutt_off");
    var bond = root.getElementsByTagName("bond");
    var ctc_incen = root.getElementsByTagName("ctc_incen");
    var ev_date = root.getElementsByTagName("ev_date");
    var po_date = root.getElementsByTagName("po_date");
    var b_log = root.getElementsByTagName("b_log");
    var e_gap = root.getElementsByTagName("e_gap");
    var CountryName = root.getElementsByTagName("CountryName");
    var StateName = root.getElementsByTagName("StateName");
    var com_city = root.getElementsByTagName("com_city");
    var job_loc = root.getElementsByTagName("other_Loc");
    
    
    var address = root.getElementsByTagName("address");
    //var sel_pross = root.getElementsByTagName("sel_pross");

    
       if (Stud_job_details_view.length > 0) {

           Lbl_Compny.innerText = GetInnerText(comp_name[0]);
           Lbl_Compny.textContext = GetInnerText(comp_name[0]);
          
           Lbl_Ctype.innerText = GetInnerText(Type[0]);
           Lbl_Ctype.textContext = GetInnerText(Type[0]);

           Lbl_JobPostDate.innerText = GetInnerText(po_date[0]);
           Lbl_JobPostDate.textContext = GetInnerText(po_date[0]);

           LblAdd.innerText = GetInnerText(address[0]);
           LblAdd.textContext = GetInnerText(address[0]);

           LblCity.innerText = GetInnerText(com_city[0]);
           LblCity.textContext = GetInnerText(com_city[0]);

         

           LblCon_no.innerText = GetInnerText(phone_no[0]);
           LblCon_no.textContext = GetInnerText(phone_no[0]);

           LblContry.innerText = GetInnerText(CountryName[0]);
           LblContry.textContext = GetInnerText(CountryName[0]);

           LblEgap.innerText = GetInnerText(e_gap[0]);
           LblEgap.textContext = GetInnerText(e_gap[0]);

           LblEmail_Comp.innerText = GetInnerText(e_mail[0]);
           LblEmail_Comp.textContext = GetInnerText(e_mail[0]);

           LblState.innerText = GetInnerText(StateName[0]);
           LblState.textContext = GetInnerText(StateName[0]);

           LblEv_Date.innerText = GetInnerText(ev_date[0]);
           LblEv_Date.textContext = GetInnerText(ev_date[0]);

           LblCTC.innerText = GetInnerText(ctc_incen[0]);
           LblCTC.textContext = GetInnerText(ctc_incen[0]);

           LblDesig.innerText = GetInnerText(desig[0]);
           LblDesig.textContext = GetInnerText(desig[0]);

           LblBond.innerText = GetInnerText(bond[0]);
           LblBond.textContext = GetInnerText(bond[0]);

           Lbl_JobTitle.innerText = GetInnerText(desig[0]);
           Lbl_JobTitle.textContext = GetInnerText(desig[0]);

           LblRoll.innerText = GetInnerText(roll[0]);
           LblRoll.textContext = GetInnerText(roll[0]);
           
           

           

//               Lbl_Joblocation.innerText = GetInnerText(job_loc[0]);
//               Lbl_Joblocation.textContext = GetInnerText(job_loc[0])
           
         
               C2p.Show_Join_loc(c_id, JOBB_id, Fill_Job_details_bind1001);
          
       }
       C2p.Bind_Qualification_Criteria(JOBB_id, Get_Details_popup);
       C2p.Show_SelPross(c_id, JOBB_id, Fill_Job_details_bind1);
       
   }

   function Fill_Job_details_bind1(result) {
      
       LblSel_Pross = document.getElementById("LblSel_Pross");
       LblSel_Pross.innerText = result;
       LblSel_Pross.textContext = result;
       C2p.Status(c_id, JOBB_id, Fill_Job_details_bind2);
   }

   function Fill_Job_details_bind1001(result) {

       LblSel_Pross = document.getElementById("Lbl_Joblocation");
       LblSel_Pross.innerText = result;
       LblSel_Pross.textContext = result;
       //C2p.Status(c_id, JOBB_id, Fill_Job_details_bind2);
   }

   

   function Get_Details_popup(result) {

       if (result == "") {

           var mypoup = document.getElementById('event_popup1');
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



           var mypoup = document.getElementById('event_popup1');

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
