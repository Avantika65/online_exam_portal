//var URI=null;
   // function InitializeService()
    //{
     //   var toindex=(document.URL.lastIndexOf("/")+1);
     //   URI=(document.URL).substring(0,toindex);
     //   service.useService(URI+"MyWebService.asmx?wsdl",  "GetAgeService");
    //} 
   
//include('../jquery-1.3.2.min.js');

function ValidateSession(sender,args)
    {//debugger;
        if(window.event.keyCode==45)
            {return true;}
        if((window.event.keyCode<48)||(window.event.keyCode>57))
            {
             window.event.keyCode=0;
            }
    }
 function CalcSession(sender,args)
    {//debugger;
       var session=args.Value.split('-');
       var sp,len,size,fyr;
       
        if(session[0].length!=4)
           {
             args.IsValid=false;
             return;
            }
       sp=Number(session[0].length) - 2;
       size=session[0].length;
       fyr=session[0].substring(sp,size);
        
       if(session[1]<fyr)
        {
            args.IsValid=false;
             return;
        }
       else
       {
           if((session[1]-fyr)!=1)
            {
                args.IsValid=false;
             return;
            }
       }
        
    }
    //---------------------------------------------------------------------------------------
    
    function ValidPhoneNo(sender,args)
    {//debugger;
       var PhoneNo=args.Value.split('-');
       var sp,len,size,fyr;
       
        if(PhoneNo[0].length!=5)
           {
             args.IsValid=false;
             return;
            }
       sp=Number(PhoneNo[0].length) -7;
       size=PhoneNo[0].length;
       fyr=PhoneNo[0].substring(sp,size);
        
       if(PhoneNo[1]<fyr)
        {
            args.IsValid=false;
             return;
        }
       else
       {
           if((PhoneNo[1]-fyr)!=1)
            {
                args.IsValid=false;
             return;
            }
       }
        
    }
    //---------------------------------------------------------------------------------------
    
function IntegerNumber1()
{

if((window.event.keyCode<48)||(window.event.keyCode>57))
{
window.event.keyCode=0;
}
}

function IntegerNumber2()
{

if((window.event.keyCode<47)||(window.event.keyCode>57))
{
window.event.keyCode=0;
}
}
 function comboValidation(sender,args)
           {
        if(args.Value=="0")
        {
         args.IsValid=false;
         return;
        }
        else
        {
         args.IsValid=true;
        }
      }  
////      function comboValidation(sender,args)
////           {
////        if(args.Value=="---Select---")
////        {
////         args.IsValid=false;
////         return;
////        }
////        else
////        {
////         args.IsValid=true;
////        }
////      }
 function Logout()
    {//debugger;
        var RedirURL="";
        var loc = window.location.href;   
            loc = (loc.substr(loc.length - 1, 1) == "/") ? loc + "Login.aspx" : loc;
        var arrUri=loc.split('/'); 
        RedirURL=arrUri[0]+'//'+arrUri[2]+'/'+arrUri[3]+'/Login.aspx';
        rootaddr=arrUri[0]+'//'+arrUri[2]+'/'+arrUri[3];
        
         window.location=RedirURL;
        //-------------------------------------
       
       // var wnd=window.open('','newWin','height=1,width=1,left=900,top=700,status=no,toolbar=no,menubar=no,scrollbars=no,maximize=false,resizable=1');
        //wnd.close();
       // window.open(RedirURL,'_parent',replace=true);
        
    }

function GotoHome()
    {
        var RedirURL="";
        var loc = window.location.href;   
            loc = (loc.substr(loc.length - 1, 1) == "/") ? loc + "LoginHome.aspx" : loc;
        var arrUri=loc.split('/'); 
        RedirURL=arrUri[0]+'//'+arrUri[2]+'/'+arrUri[3]+'/LoginHome.aspx';
        //-------------------------------------
        var wnd=window.open('','newWin','height=1,width=1,left=900,top=700,status=no,toolbar=no,menubar=no,scrollbars=no,maximize=false,resizable=1');
        wnd.close();
        window.open(RedirURL,'_parent',replace=true);
    }

function IntegerNumber(evt)
   {	   
        if(navigator.appName == "Netscape" || navigator.appName == "Opera") 
            {  
    	        if(((evt.which<48)||(evt.which>57)) && evt.which != 8 && evt.which != 0)
		            {		 
		            //evt.preventDefault();
		            window.event.keyCode=0;
		            }	
            }
         else if (navigator.appName == "Microsoft Internet Explorer")
            {
                if((window.event.keyCode<48)||(window.event.keyCode>57))
		            {		 
		                window.event.keyCode=0;
		            }	
            }
         else 
            {
                if((window.event.keyCode<48)||(window.event.keyCode>57))
		            {		 
		                window.event.keyCode=0;
		            }	
            }   	   
	
    }
function decimalNumber(cntrName,evt)
		{//debugger;
		 if(navigator.appName == "Netscape" || navigator.appName == "Opera") 
            {  
    	        if((evt.which < 48 || evt.which > 57)&& (evt.which != 46))
		            {		 
		            window.event.keyCode=0;
		            //evt.preventDefault();
		            }	
		        if (evt.which == 46)
                  { 
                 var x=(cntrName.value).indexOf('.');
                    if(x >= 0)
					evt.preventDefault();}
            }
         else if (navigator.appName == "Microsoft Internet Explorer")
            {		
				if((window.event.keyCode < 48 || window.event.keyCode > 57)&& (window.event.keyCode != 46))  
					{
						window.event.keyCode=0;
					}					
				if (window.event.keyCode == 46)
                { 
                 var x=(cntrName.value).indexOf('.');
                    if(x >= 0)
					 window.event.keyCode=0;
				}	
			}	
        }  

function precisionNumber(cntrName,precLen,evt)
		{
		 if(navigator.appName == "Netscape" || navigator.appName == "Opera") 
            {  
    	        if((evt.which < 48 || evt.which > 57)&& (evt.which != 46))
		            {		 
		            window.event.keyCode=0;
		            //evt.preventDefault();
		            }	
		        if (evt.which == 46)
                  { 
                 var x=(cntrName.value).indexOf('.');
                    if(x >= 0)
					evt.preventDefault();}
            }
         else if (navigator.appName == "Microsoft Internet Explorer")
            {		
				if((window.event.keyCode < 48 || window.event.keyCode > 57)&& (window.event.keyCode != 46))  
					{
						window.event.keyCode=0;
					}					
				if (window.event.keyCode == 46)
                { 
                 var x=(cntrName.value).indexOf('.');
                    if(x >= 0)
					 window.event.keyCode=0;
				}	
			}
			if(cntrName.value!='')
			{
//		cntrName.value=parseFloat(cntrName.value).toFixed(2)	;
            if(cntrName.value.split('.').length>1)
                if(cntrName.value.split('.')[1].length>(precLen-1))
                {
                    if (navigator.appName == "Microsoft Internet Explorer")
                    {
                    		window.event.keyCode=0;
                    }
                    if(navigator.appName == "Netscape" || navigator.appName == "Opera") 
            
            {evt.preventDefault();}
                }
		}
        }
function disallowSingleQuote(cntrName)
	{
	if (window.event.keyCode==39)
	    window.event.keyCode=0;
	}	
function ChangeState(ctrl,target)
    {    
   if(ctrl.checked == true)
        {document.getElementById(target).disabled=false;}
   else
        {document.getElementById(target).disabled=true;}
                
    }
    
     function confirm_delete()
    {
          if (confirm('Are you sure want to delete ?')==true)
            return true;
          else
            return false;
    }
    
 function CheckDate(frmDateId,toDateId)
    {
        if(document.getElementById(frmDateId).value!='' && document.getElementById(toDateId).value!='')
            {
                var stDate=document.getElementById(frmDateId).value;
                var endDate=document.getElementById(toDateId).value;
                
                stDate=new Date(stDate.replace(/[-]/g,' '));                
                endDate=new Date(endDate.replace(/[-]/g," "));
                 
                 
                if(stDate > endDate) 
                {
                    document.getElementById(toDateId).value='';
                    document.getElementById(toDateId).focus();
                    alert("End Date should be greater than Start Date"); 
                    return false; 
                } 

                return true;
        }
        
    }
    
function invalidchar(Strval)
            {
                var iChars = "../ ..\ .. ! @ $ ^ * ( ) + [ ] ; , { }";
                    iChars=iChars.split(' ');
                    var fch=1;
                    var tch=Strval.length;
                   
                  for (var i = 0; i < iChars.length; i++) 
                    {
  	                    if (Strval.indexOf(iChars[i]) != -1) 
  	                        {
  	                            if(Strval.indexOf(iChars[i])>1)
  	                                {fch=Strval.indexOf(iChars[i])-1;}
  	                            if(i==tch)
  	                                {tch=tch-1;}
  	                            else
  	                                {tch=Strval.indexOf(iChars[i])+1;}
  	                                
  	                            Strval=Strval.replace(iChars[i],'');
  	                            invalidchar(Strval);
  	                        }
                    }
                return Strval;
            }
 /*---------Circulation Module-------*/
 function Cal_OdBalance(VarCtrl1,VarCtrl2,VarToCtrl)
            {//debugger;
                var VarToCtrl=document.getElementById(VarToCtrl);
                 var TotAmt=null;//document.getElementById('txttltamt').value;
                TotAmt=((document.getElementById(VarCtrl1).value)-(document.getElementById(VarCtrl2).value)).toFixed(2);
                    if(TotAmt.toFixed)
                        {VarToCtrl.value=TotAmt.toFixed(2);}
                    else
                         {VarToCtrl.value=TotAmt;}
            }
function SetDDLSelectedValue(DDL_id,Item_Value)
    { for(i=0;i<DDL_id.length;i++)
            {
                if(DDL_id.options[i].value==Item_Value)
                {
                    DDL_id.selectedIndex=i;
                    break;
                }
            }
    }
function SetDDLSelectedText(DDL_id,Item_Text)
    {for(i=0;i<DDL_id.length;i++)
            {
                if(DDL_id.options[i].text==Item_Text)
                {
                    DDL_id.selectedIndex=i;
                    break;
                }
            }
    }
function BindDDL(DDLList,result)
       {
            var selectOfInst = $get(DDLList);
            selectOfInst.innerHTML='';
            //selectOfInst.options.length = 0;
            var customerItems = result;
            var pos = 1;
            var oOption = document.createElement("OPTION");
                oOption.text = '---Select---';
                oOption.value = 0;
           selectOfInst.add(oOption, 0); 
           for (var i=0; i<result.length;i++) 
            {   oOption = document.createElement("OPTION");
                oOption.text = result[i].Item_Text;
                oOption.value =result[i].Item_Value;
                selectOfInst.add(oOption, pos);                   
                
                pos += 1;
            }
            //selectOfInst.selectedIndex=0;
            selectOfInst.focus();
       }
function copyDDLItems(SourceDDL,TargetDDL)
    {
        var SourceDDL=$get(SourceDDL);
        var TargetDDL=$get(TargetDDL);
        //var selectOfInst = $get(DDLList);
        TargetDDL.innerHTML='';
        //var pos=0
        for (var i=0; i<SourceDDL.length;i++) 
            {   
                oOption = document.createElement("OPTION");
                oOption.text = SourceDDL.options[i].text;
                oOption.value =SourceDDL.options[i].value;
                TargetDDL.add(oOption, i);
                //pos += 1;
            }
        TargetDDL.selectedIndex=SourceDDL.selectedIndex;
    }
    
 function isEnterKey(event)
    {
    if(navigator.appName == "Netscape" || navigator.appName == "Opera") 
                {  
    	            if((evt.which < 48 || evt.which > 57)&& (evt.which != 46))
		                {		 
		                evt.preventDefault();
		                }	
		            if (evt.which == 46)
                      { 
                    }
                }
             else if (navigator.appName == "Microsoft Internet Explorer")
                {		
    //				if((window.event.keyCode < 48 || window.event.keyCode > 57)&& (window.event.keyCode != 46))  
    //					{
    //						window.event.keyCode=0;
    //					}				
                    window.alert(window.event.keyCode);
				    if (window.event.keyCode ==13 )
                    { 	
                    
				    }	
			    }	
    }   
//Validating Checkboxes inside GridView//
//Use this function on client click of the button eg: OnClientClick="ChkCheckBox(grdArrSchedule,'chk');" //
 function ChkCheckBox(gridId,checkboxName)
{   //debugger; 
  var TargetChildControl = checkboxName;
  var Inputs ;
        Inputs = gridId.getElementsByTagName("input");
  for(var n = 0; n < Inputs.length; ++n)
     if(Inputs[n].type == 'checkbox' && 
        Inputs[n].id.indexOf(TargetChildControl,0) >= 0 && 
        Inputs[n].checked)
      return true; 
  alert('Select At Least One Item.');
  return false;

//if (confirm('Select At Least One Item.')==true)
//            return true;
//          else
//            return false;
}
//-----------------------------------------// 


function ValidateFunc(evt)
   {	   //alert(evt.keycode);
        if(navigator.appName == "Netscape" || navigator.appName == "Opera") 
            {  
    	        if(((evt.which<48)||(evt.which>57)) && evt.which != 8 && evt.which != 0)
		            {		 
		            evt.preventDefault();
		            }	
            }
         else if (navigator.appName == "Microsoft Internet Explorer")
            {
                if(((window.event.keyCode<48)||(window.event.keyCode>57)) &&((window.event.keyCode<97)||(window.event.keyCode>122)) &&((window.event.keyCode<65)||(window.event.keyCode>90)) && (window.event.keycode<32))
		            {		 
		                window.event.keyCode=0;
		            }	
            }
         else 
            {
                if((window.event.keyCode<48)||(window.event.keyCode>57))
		            {		 
		                window.event.keyCode=0;
		            }	
            }   	   
	
    }
    
    //--------Opening Window For Statement of Responsibility---------//
            function popupWindow(o,d)
            {//debugger;
            // o - Object to display.
            // d - Display, true = display, false = hide
                var obj = document.getElementById(o);
                if(d)
                {
                //document.getElementById("chkRes").checked = false;
                document.getElementById("bckDiv").style.display = 'block';
                obj.style.display = 'block';
                
                //$get("popup1").focus();
                }
                else
                {
//                document.getElementById("chkRes").checked = false;
                obj.style.display = 'none';
                document.getElementById("bckDiv").style.display = 'none';
                }
            }

 function popupWindow1(o,d)
            {debugger;
            // o - Object to display.
            // d - Display, true = display, false = hide
                var obj = document.getElementById(o);
                if(d)
                {
                //document.getElementById("chkRes").checked = false;
                document.getElementById("bckDiv").style.display = 'block';
                obj.style.display = 'block';
                
                //$get("popup1").focus();
                }
                else
                {
                //document.getElementById("chkRes").checked = false;
                obj.style.display = 'none';
                document.getElementById("bckDiv").style.display = 'none';
                }
            }
            
            function CopyAdd(ctrl)
            {
                var Obj = $get(ctrl);
                var value_ADD = $get("txtHouseNo").value;
                if(Obj.checked == true)
                {
                    $get("txtMailingAdd").value = value_ADD;
                }
                else
                {
                    $get("txtMailingAdd").value = '';
                }
            }
 function SelectAllCheckboxes(spanChk)
 {
           // Added as ASPX uses SPAN for checkbox
           var oItem = spanChk.children;
           var theBox= (spanChk.type=="checkbox") ? 
                spanChk : spanChk.children.item[0];
           xState=theBox.checked;
           elm=theBox.form.elements;

           for(i=0;i<elm.length;i++)
             if(elm[i].type=="checkbox" && 
                      elm[i].id!=theBox.id)
             {//debugger;
               //elm[i].click();

               if(elm[i].checked!=xState)
                 elm[i].click();
               //elm[i].checked=xState;

             }
           
         }  
         
         
         
          function SelectAllCheckboxes(spanChk,ctrlike)
 {
           // Added as ASPX uses SPAN for checkbox
           var oItem = spanChk.children;
           var theBox= (spanChk.type=="checkbox") ? 
                spanChk : spanChk.children.item[0];
           xState=theBox.checked;
           elm=theBox.form.elements;

           for(i=0;i<elm.length;i++)
             if(elm[i].type=="checkbox" && 
                      elm[i].id!=theBox.id)
             {//debugger;
                if (elm[i].id.split('_')[2] == ctrlike)
                elm[i].checked = xState;
               //elm[i].click();
                
//               if(elm[i].checked!=xState)
//                 elm[i].click();
               //elm[i].checked=xState;

             }
           
         }  
         
         
         
         function CheckRFQDate(frmDateId,toDateId)
    {//debugger;
        if(document.getElementById(frmDateId).value!='' && document.getElementById(toDateId).value!='')
            {
                var stDate=document.getElementById(frmDateId).value;
                var endDate=document.getElementById(toDateId).value;
                
                stDate=new Date(stDate.replace(/[-]/g,' '));                
                endDate=new Date(endDate.replace(/[-]/g," "));
                 
                 
                if(stDate > endDate) 
                {
                    document.getElementById(toDateId).value='';
                    document.getElementById(toDateId).focus();
                    alert("Delivery Date should be greater than RFQ Deadline Date"); 
                    return false; 
                } 

                return true;
        }
        
    }   
    
    function ChkRFQCurDate(frmDateId,toDateId)
    {//debugger;
        if(document.getElementById(frmDateId).value!='' && document.getElementById(toDateId).value!='')
            {
                var stDate=document.getElementById(frmDateId).value;
                var endDate=document.getElementById(toDateId).value;
                
                stDate=new Date(stDate.replace(/[-]/g,' '));                
                endDate=new Date(endDate.replace(/[-]/g," "));
                 
                 
                if(stDate > endDate) 
                {
                    document.getElementById(toDateId).value='';
                    document.getElementById(toDateId).focus();
                    alert("Delivery Date should be greater than RFQ Date"); 
                    return false; 
                } 

                return true;
        }
        
    } 
    
    function ChkRFQDeadCurDate(frmDateId,toDateId)
    {//debugger;
        if(document.getElementById(frmDateId).value!='' && document.getElementById(toDateId).value!='')
            {
                var stDate=document.getElementById(frmDateId).value;
                var endDate=document.getElementById(toDateId).value;
                
                stDate=new Date(stDate.replace(/[-]/g,' '));                
                endDate=new Date(endDate.replace(/[-]/g," "));
                 
                 
                if(stDate > endDate) 
                {
                    document.getElementById(toDateId).value='';
                    document.getElementById(toDateId).focus();
                    alert("RFQ Dealine Date should be greater than RFQ Date"); 
                    return false; 
                } 

                return true;
        }
        
    }  
    
    function ClearDefValue(ctrname)
    {
        if($get(ctrname).value == '0')
        {
            $get(ctrname).value = '';
        }
        else
        {
            $get(ctrname).value = $get(ctrname).value;
        }
    }
    
    function SetDefValue(ctrname)
    {
        if($get(ctrname).value == '')
        {
            $get(ctrname).value = '0';
        }
    }
    
    
    function confirm_Update()
    {//debugger;
          if (confirm('Are you want to update stock level ?')==true)
            return true;
          else
            //return false;
            document.getElementById("btnReset").click();
            //$get("btnReset").click();
    }
    
//    //---------------------------------------Pop UP--------------------------------
//        function OpnenWindow()
//            { //debugger;        
//                
//                    $get('divMail').innerHTML="";
//                    win1.topbar.innerText="Mail";
//                win1.showCenter();
//            }
           
        

