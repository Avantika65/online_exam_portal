var URI=null;
var StrYear, StrMonth, strmail;
var CurrentPage=(document.URL).substring(document.URL.lastIndexOf("/")+1,document.URL.length);

    function InitializeService()
    {
    debugger
        var toindex=(document.URL.lastIndexOf("/"));
        URI=(document.URL).substring(0,toindex-8);
        service.useService(URI+"Medi_Serv.asmx?wsdl","GetAgeService");
      //  var hsp_ddl = document.getElementById("DropDownList1"); 
        // var Sess_ddl=document.getElementById('DropDownList2');   
          //service.GetAgeService.callService("IsValidUser", StrUser, StrPWD,Str_Hosp_nm_Id,Str_Sess,Str_Hosp_nm);
         
         // service.GetAgeService.callService("Fill_ddl_Lst",hsp_ddl);
          //service.GetAgeService.callService("Fill_ddl_Lst");
        //service.useService((document.URL).substring(0,document.URL.lastIndexOf("/")+1)+"MyWebService.asmx?wsdl",  "GetAgeService");
    }
       
    function login()
    {    
        StrUser = document.getElementById('TxtUserName1').value;
        StrPWD = document.getElementById('txtPassword1').value;
        
        var hsp_ddl = document.getElementById("DropDownList1"); 
        var Str_Hosp_nm_Id = hsp_ddl.options[hsp_ddl.selectedIndex].value; 
        var Str_Hosp_nm= hsp_ddl.options[hsp_ddl.selectedIndex].text;

       // var e = document.getElementById("ddlViewBy"); 
        //var strUser = e.options[e.selectedIndex].text; 
      //Str_Hosp_nm=document.getElementById('DropDownList1').value;
               
        var Sess_ddl=document.getElementById('DropDownList2');        
        Str_Sess=Sess_ddl.options[Sess_ddl.selectedIndex].value;       
        
        service.GetAgeService.callService("IsValidUser", StrUser, StrPWD,Str_Hosp_nm_Id,Str_Sess,Str_Hosp_nm);
    }
    
//    function dos_remind()
//    {
//    debugger
//          service.GetAgeService.callService("Dose_Reminder");
//  
//    }
    function dos_remind()
        {
           
                           // CallWebMethod('RCSService.asmx','RemitanceDetail',['_JRN_Id',JRN_Id],RemDtlSuccessFn,errorFn);
                         
                            Medi_Serv.Dose_Reminder(Search_Success_Func,OnError,OnTimeOut);
                      
                
                }
    function res()
    {
    if(event.result.value==true)           
        {
        alert("true");
//        Search_Success_Func();
        }
        else
        {
        alert("false");
        }
    }
    function OnError(arg)
		{
			alert("error has occured: " + arg._message);
		} 
		function OnTimeOut(arg)
		{
			alert("timeOut has occured");
		}
    function Is_Dose() {
        try{debugger;
            Medi_Serv.Dose_Reminder(Search_Success_Func,OnError,OnTimeOut);
            }
            catch(Error){debugger;}            
        }
     function Search_Success_Func(result)
    {
    //debugger;
        var HtmlTbl='';
        if(result!=null)
        {   
            document.getElementById('divcopies').style.display="block";
            var dm;
            dm=new Date();
             var mn =parseInt(dm.getMonth())+parseInt('1'); 
             
            HtmlTbl='<table>';
            HtmlTbl=HtmlTbl+"<tr><td colspan='7' Class='header' align='left'>Date "+dm.getDate()+'-'+mn +'-'+ dm.getFullYear()+"</td></tr><tr><td Class='logintxt' align='left'>Room No.</td><td Class='logintxt' align='left'>Bed No.</td><td Class='logintxt' align='left'>Nurse</td><td Class='logintxt' align='left'>Reg. No.</td><td Class='logintxt' align='left'>Patient Name</td><td Class='logintxt' align='left'>Medicine</td><td Class='logintxt' align='left'>Given Time<a href='javascript:HideContent1(divcopies);' tooltip='Close' style='text-decoration:none;font-weight:bold;width:100%;color:red' align='right'>X</a></td></tr>";
               for(var i=0;i<result.length;i++)
                {
               
                    HtmlTbl=HtmlTbl+'<tr>';
                                  
                    HtmlTbl=HtmlTbl+'<td align="left" Class="inertxt">'+result[i].Room_No+'</td>';
                    HtmlTbl=HtmlTbl+'<td align="left" Class="inertxt">'+result[i].Bed_No+'</td>';
                      HtmlTbl=HtmlTbl+'<td align="left" Class="inertxt">'+result[i].Nm+'</td>';
                    HtmlTbl=HtmlTbl+'<td align="left" Class="inertxt">'+result[i].Reg_Id+'</td>';
                    HtmlTbl=HtmlTbl+'<td align="left" Class="inertxt">'+result[i].Pt_Nm+'</td>';
                    HtmlTbl=HtmlTbl+'<td align="left" Class="inertxt">'+result[i].M+'</td>';
                    HtmlTbl=HtmlTbl+'<td align="left" Class="inertxt">'+result[i].Giv_Dt_tm+'</td>';                
                    HtmlTbl=HtmlTbl+'</tr>';
                } 
            HtmlTbl=HtmlTbl+'</table>';
            
            $get('divcopies').innerHTML=HtmlTbl;
            //ShowWindow('divcopies');
        }
        else
        {
            document.getElementById('divcopies').style.display="hidden";
        }
    }
    function ShowResult()
    {      
      
        if(event.result.value==true)           
        {
            window.location=URI+"Home.aspx";
        }
        else
        {
         //alert("login Failed");
          document.getElementById('TxtUserName1').value = "";
          document.getElementById('txtPassword1').value= "";         
          alert("Login Failed");
          //document.getElementById('msg').innerText="Login Failed";
        }  
        
    }
    
    
    function ShowResult_1()
    {
      alert(event.result.value); 
        
    
       var hsp_lst = new Array();
        hsp_lst =event.result.value;         
       alert(hsp_lst.length);
    
      //alert("Show Result1"); 
    }
    
     //----------------------------------------Check Quantity----------------------------------------------
function ChkQty_WebReq(Prod_Id,Qntity)
     { 
        RCSService.Check_Quantity(Prod_Id,Qntity,QtysuccessFn,OnError,OnTimeOut);
     }  
  function QtysuccessFn(result) 
  { 
    if(result=='Min')
     {
        document.getElementById('lblQtyMsg').innerHTML="Quantity should be greater than Min Quantity Allowed";
       //  window.alert("Quantity should be greater than Min Quantity Allowed");        
     }   
     else if(result=='Max')
     {
         document.getElementById('lblQtyMsg').innerHTML="Quantity should be less than Max Quantity Allowed";
        // window.alert("Quantity should be less than Max Quantity Allowed");
         //var qty=$get('txtQntty').value;
        $get('txtQntty').value=0;// qty.substring(0,qty.length-1);        
     } 
     else
     {
         document.getElementById('lblQtyMsg').innerHTML="";
     }  
  } 
  
     
     //----------------------------------------Check Amount----------------------------------------------
function ChkAmt_WebReq(Amt)
     { 
        RCSService.Check_Amt(Amt,AmtsuccessFn,OnError,OnTimeOut);
     }  
  function AmtsuccessFn(result) 
  { 
    if(result!='')
     {
       window.alert(result);        
     } 
  } 
  
   //----------------------------------------Check Indent Quantity----------------------------------------------
function ChkIndentQty_WebReq(IndentId,Qntity)
     { 
        RCSService.Chk_IndentQty(IndentId,Qntity,IndntQtysuccessFn,OnError,OnTimeOut);
     }  
  function IndntQtysuccessFn(result) 
  { 
    if(result!='')
     {
         if(document.getElementById('rdbtnBoth').checked==true)
         {
             if(result=="0.00000")
             {
               window.alert("Stock balance is 0.00 so issue request not allowed"); 
               document.getElementById('rdbtnBoth').checked=false; 
               document.getElementById('rdbtnIssue').checked=false;
             }
         } 
        else if(document.getElementById('rdbtnIssue').checked==true)
         {
            window.alert("Issue quantity can not exceed the available stock:"+result); 
            document.getElementById('rdbtnIssue').checked=false; 
         } 
        else
        {
            
        }
     } 
  } 
  
   //----------------------------------------Generate Product Code----------------------------------------------
function GenProdCode_WebReq(Flag,Prod_Type, Prod_Cat,Prod_Comp)
     {//debugger;
        RCSService.Gen_ProdCode(Flag, Prod_Type, Prod_Cat, Prod_Comp, ProdCodesuccessFn,OnError,OnTimeOut);
     }  
  function ProdCodesuccessFn(Prod_Code) 
  { 
    if(Prod_Code!='')
     {
        document.getElementById('txtProdCode').value= Prod_Code;   
     } 
      
  } 
  
  
function Exchange_Rate()
{
    var CurrencyID = $get("ddlCurrency").value;
    if(CurrencyID != "0")
    {
        RCSService.Ex_Rate(CurrencyID,ExRatesuccessFn,OnError,OnTimeOut);
    }
    else
    {
         $get("txtExRate").value= "";
    }
}
function ExRatesuccessFn(ExRate_) 
  { 
    if(ExRate_!='')
     {
        $get("txtExRate").value= (parseFloat(ExRate_)).toFixed(2);   
     } 
      
  } 
  
  //----------------------------Getting Pending PO Details------------------------------------//
    function GetPendPO()
    {
         RCSService.GetPendingPO(GetPOSuccessFn,OnError,OnTimeOut);
    }
    function GetPOSuccessFn(result)
    {//debugger;
        if(result.length != 0)
        {
            HtmlTbl='<table style="border: 1px solid #006699;width:333px">';
            HtmlTbl=HtmlTbl+"<tr Class='header'><td align='left'>PO Code</td><td align='left' width='80px'>Delivery&nbsp;Date</td><td align='left'>Supplier</td></tr>";
           for(var i=0;i<result.length;i++)
            {
                var objDate = new Date();
                objDate = result[i].DeliveryDate;
                HtmlTbl=HtmlTbl+'<tr>';                                  
                HtmlTbl=HtmlTbl+'<td valign="top" Class="inertxt" width="100px"><a Class="link" href="DownloadFile.aspx?fname='+ result[i].FileName +'&ftype='+ result[i].FileType+'&FolderName=PO&stype=R">' +result[i].POCode+'</a></td>';
                HtmlTbl=HtmlTbl+'<td valign="top" Class="inertxt">'+ objDate.format("dd-MMM-yyyy")+'</td>';
                HtmlTbl=HtmlTbl+'<td valign="top" Class="inertxt" width="120px">'+result[i].Supplier+'</td>';                               
                HtmlTbl=HtmlTbl+'</tr>';
            } 
            HtmlTbl=HtmlTbl+'</table>';             
            win1 = new Window('1', {className: "bluelighting", title: "Pending PO List", width:350, height:450, top:0, left:1}); 
            win1.getContent().innerHTML = HtmlTbl;        
            win1.show();
        }
    }
                         
  //------------------------------------------------------------------------------------------//
  
  
  //---------------------------Displaying Pending Orders----------------------------------//
  function OpnenWindow()
            { //debugger; 
                GetPendPO();
            }  
  //---------------------------------------------------------------------------------------//
     