function CalcTax()
{//debugger;
    $get('txtTotalAmt').value = ''
    if($get('txtTaxPer').value != '' && $get('txtSubTtl').value != '')
    {
        if(parseFloat($get('txtTaxPer').value)>100.000)
        {
            alert("Tax% should be upto 100%");
            $get('txtTaxPer').value='0';
            $get('txtTaxAmt').value = '0';
            $get('txtBalAmt').value = '0';
            $get('txtPaidAmt').value = '0';
            $get('txtTotalAmt').value = '0';
            return;
        }
        else
        {
            var TaxPer =   $get('txtTaxPer').value;
            var SubTtl = $get('txtSubTtl').value;
            
            var TaxAmt = null;
            
            TaxAmt = parseFloat(SubTtl) * parseFloat(TaxPer)/100;
            
            $get('txtTaxAmt').value = (parseFloat(TaxAmt)).toFixed(3);
            if($get('txtDiscAmt').value == '')
            {
                if($get('txtShipping').value != '')
                {
                    $get('txtTotalAmt').value = (((parseFloat(SubTtl) + parseFloat(TaxAmt)) + parseFloat($get('txtShipping').value))).toFixed(3);                
                    $get('txtBalAmt').value = ((parseFloat(SubTtl) + parseFloat(TaxAmt)) + parseFloat($get('txtShipping').value)).toFixed(3);
                }
                if($get('txtPaidAmt').value != '')
                {
                    $get('txtTotalAmt').value = (parseFloat($get('txtTotalAmt').value)).toFixed(3); //- parseFloat($get('txtPaidAmt').value);                
                    $get('txtBalAmt').value = (parseFloat($get('txtTotalAmt').value) - parseFloat($get('txtPaidAmt').value)).toFixed(3);       
                }
            }
            else
            {
                if($get('txtShipping').value != '')
                {   
                    $get('txtTotalAmt').value = (((parseFloat(SubTtl) + parseFloat(TaxAmt)) - parseFloat($get('txtDiscAmt').value)) + parseFloat($get('txtShipping').value)).toFixed(3);                   
                    $get('txtBalAmt').value = (((parseFloat(SubTtl) + parseFloat(TaxAmt)) - parseFloat($get('txtDiscAmt').value)) + parseFloat($get('txtShipping').value)).toFixed(3);       
                }
                if($get('txtPaidAmt').value != '')
                {
                    $get('txtTotalAmt').value = (parseFloat($get('txtTotalAmt').value)).toFixed(3); //- parseFloat($get('txtPaidAmt').value);                
                    $get('txtBalAmt').value = (parseFloat($get('txtTotalAmt').value) - parseFloat($get('txtPaidAmt').value)).toFixed(3);
                }
            }
        }
    }
    else
    {
        $get('txtTaxAmt').value = '0';
        //$get('txtTaxPer').value = '0';
        if($('txtDiscPer').value != '' && $get('txtDiscAmt').value != '')
        {
            if($get('txtShipping').value != '')
            {
                $get('txtTotalAmt').value = ((parseFloat($get('txtSubTtl').value) - parseFloat($get('txtDiscAmt').value)) + parseFloat($get('txtShipping').value)).toFixed(3);
                $get('txtBalAmt').value = (parseFloat($get('txtTotalAmt').value)).toFixed(3);
            }
            if($get('txtPaidAmt').value != '')
            {
                $get('txtTotalAmt').value = (parseFloat($get('txtTotalAmt').value)).toFixed(3); //- parseFloat($get('txtPaidAmt').value);                
                $get('txtBalAmt').value = (parseFloat($get('txtTotalAmt').value) - parseFloat($get('txtPaidAmt').value)).toFixed(3);
            }
        }
        else
        {
            if($get('txtShipping').value != '')
            {
                $get('txtTotalAmt').value = (parseFloat($get('txtSubTtl').value) + parseFloat($get('txtShipping').value)).toFixed(3);
                $get('txtBalAmt').value = ($get('txtTotalAmt').value).toFixed(3);
                if($get('txtPaidAmt').value != '')
                {
                    $get('txtTotalAmt').value = (parseFloat($get('txtTotalAmt').value)).toFixed(3);// - parseFloat($get('txtPaidAmt').value);                
                    $get('txtBalAmt').value = (parseFloat($get('txtTotalAmt').value) - parseFloat($get('txtPaidAmt').value)).toFixed(3);
                }
            }
            else
            {
                $get('txtTotalAmt').value = '0';
                $get('txtBalAmt').value = '0';
            }
        }
    }
}

function CalcDisc()
{//debugger;
    $get('txtTotalAmt').value
    if($get('txtDiscPer').value != '' && $get('txtSubTtl').value != '')
    {
        if(parseFloat($get('txtDiscPer').value)>100.000)
        {
            alert("Discount% should be upto 100%");            
            $get('txtDiscPer').value='0';
            $get('txtDiscAmt').value = '0';
            $get('txtBalAmt').value = '0';
            $get('txtPaidAmt').value = '0';
            $get('txtTotalAmt').value = '0';
            return;
        }
        else
        {
            var DiscPer = $get('txtDiscPer').value;
            var SubTtl = $get('txtSubTtl').value;
            
            var DiscAmt = null;
            
            DiscAmt = SubTtl * DiscPer/100;
            
            $get('txtDiscAmt').value = parseFloat(DiscAmt).toFixed(3);
            if($get('txtTaxAmt').value != '')
            {
                if($get('txtShipping').value != '')
                {
                    $get('txtTotalAmt').value = (((parseFloat($get('txtSubTtl').value) + parseFloat($get('txtTaxAmt').value)) - parseFloat(DiscAmt)) + parseFloat($get('txtShipping').value)).toFixed(3);
                    $get('txtBalAmt').value = parseFloat($get('txtTotalAmt').value).toFixed(3);
                }
                if($get('txtPaidAmt').value != '')
                {
                    $get('txtTotalAmt').value = (parseFloat($get('txtTotalAmt').value)).toFixed(3);// - parseFloat($get('txtPaidAmt').value);                
                    $get('txtBalAmt').value = (parseFloat($get('txtTotalAmt').value) - parseFloat($get('txtPaidAmt').value)).toFixed(3);
                }
            }
            else
            {
                if($get('txtShipping').value != '')
                {
                    $get('txtTotalAmt').value = (((parseFloat($get('txtSubTtl').value) + parseFloat('0')) - parseFloat(DiscAmt)) + parseFloat($get('txtShipping').value)).toFixed(3);
                    $get('txtBalAmt').value = parseFloat($get('txtTotalAmt').value).toFixed(3);
                }
                if($get('txtPaidAmt').value != '')
                {
                    $get('txtTotalAmt').value = (parseFloat($get('txtTotalAmt').value)).toFixed(3);// - parseFloat($get('txtPaidAmt').value);                
                    $get('txtBalAmt').value = (parseFloat($get('txtTotalAmt').value) - parseFloat($get('txtPaidAmt').value)).toFixed(3);
                }
            }
        }
    }
    else
    {
        $get('txtDiscAmt').value = '0';
        //$get('txtDiscPer').value = '0'
        if($get('txtTaxPer').value != '' && $get('txtTaxAmt').value != '')
        {
            if($get('txtShipping').value != '')
            {
                $get('txtTotalAmt').value = ((parseFloat($get('txtTaxAmt').value) + parseFloat($get('txtSubTtl').value)) + parseFloat($get('txtShipping').value)).toFixed(3);
                $get('txtBalAmt').value = (parseFloat($get('txtTotalAmt').value)).toFixed(3);
            }
            if($get('txtPaidAmt').value != '')
            {
                $get('txtTotalAmt').value = (parseFloat($get('txtTotalAmt').value)).toFixed(3);// - parseFloat($get('txtPaidAmt').value);                
                $get('txtBalAmt').value = (parseFloat($get('txtTotalAmt').value) - parseFloat($get('txtPaidAmt').value)).toFixed(3);
            }
        }
        else
        {
            if($get('txtShipping').value != '')
            {
                $get('txtTotalAmt').value = (parseFloat($get('txtSubTtl').value) + parseFloat($get('txtShipping').value)).toFixed(3);
                $get('txtBalAmt').value = parseFloat($get('txtTotalAmt').value).toFixed(3);
            }
            if($get('txtPaidAmt').value != '')
            {
                $get('txtTotalAmt').value = (parseFloat($get('txtTotalAmt').value)).toFixed(3);// - parseFloat($get('txtPaidAmt').value);                
                $get('txtBalAmt').value = (parseFloat($get('txtTotalAmt').value) - parseFloat($get('txtPaidAmt').value)).toFixed(3);
            }
            else
            {
                $get('txtTotalAmt').value = '0';
                $get('txtBalAmt').value = '0';
            }
        }
    }
}

function CalBal()
{//debugger;
    if($get('txtTotalAmt').value != '' && $get('txtPaidAmt').value != '')
    {
        $get('txtBalAmt').value = (parseFloat($get('txtTotalAmt').value) - parseFloat($get('txtPaidAmt').value)).toFixed(3);
    }
    else
    {
        $get('txtBalAmt').value = (parseFloat($get('txtTotalAmt').value)).toFixed(3);
        //$get('txtPaidAmt').value = '0';
    }
}

function DefVal()
{
    $get('txtDiscPer').value=0;
    $get('txtDiscAmt').value = 0;
    $get('txtBalAmt').value = 0;
    $get('txtPaidAmt').value = 0;
    $get('txtTotalAmt').value = 0;
    $get('txtTaxPer').value= 0;
    $get('txtTaxAmt').value = 0;
    $get('txtSubTtl').value = 0;
    $get('txtShipping').value = 0;
}

function CalcShipping()
{//debugger;
    $get('txtTotalAmt').value = '';
    if($get('txtTaxAmt').value != '' && $get('txtDiscAmt').value != '')
    {
        var shipping_amt = $get('txtShipping').value;
        if(shipping_amt != '')
        {
            $get('txtTotalAmt').value = ((parseFloat($get('txtSubTtl').value) + parseFloat($get('txtTaxAmt').value) - parseFloat($get('txtDiscAmt').value)) + parseFloat(shipping_amt)).toFixed(3);
            
            $get('txtBalAmt').value = ((parseFloat($get('txtSubTtl').value) + parseFloat($get('txtTaxAmt').value) - parseFloat($get('txtDiscAmt').value)) + parseFloat(shipping_amt)).toFixed(3);
            if($get('txtPaidAmt').value != '')
            {
                $get('txtTotalAmt').value = ((parseFloat($get('txtSubTtl').value) + parseFloat($get('txtTaxAmt').value) - parseFloat($get('txtDiscAmt').value)) + parseFloat(shipping_amt)).toFixed(3);
            
                $get('txtBalAmt').value = (((parseFloat($get('txtSubTtl').value) + parseFloat($get('txtTaxAmt').value) - parseFloat($get('txtDiscAmt').value)) + parseFloat(shipping_amt)) - parseFloat($get('txtPaidAmt').value)).toFixed(3);
            }
        }
        else
        {
            //$get('txtShipping').value = '0';
            $get('txtTotalAmt').value = ((parseFloat($get('txtSubTtl').value) + parseFloat($get('txtTaxAmt').value) - parseFloat($get('txtDiscAmt').value))).toFixed(3);
            
            $get('txtBalAmt').value = ((parseFloat($get('txtSubTtl').value) + parseFloat($get('txtTaxAmt').value) - parseFloat($get('txtDiscAmt').value))).toFixed(3);
            if($get('txtPaidAmt').value != '')
            {
                 $get('txtTotalAmt').value = ((parseFloat($get('txtSubTtl').value) + parseFloat($get('txtTaxAmt').value) - parseFloat($get('txtDiscAmt').value))).toFixed(3);
            
                 $get('txtBalAmt').value = (((parseFloat($get('txtSubTtl').value) + parseFloat($get('txtTaxAmt').value) - parseFloat($get('txtDiscAmt').value))) - parseFloat($get('txtPaidAmt').value)).toFixed(3);
            }
        }
    }
}

function SetDefValue(ctrname)
{
    if($get(ctrname).value == '')
    {
        $get(ctrname).value = '0';
    }
}

function ClearDefValue(ctrname) {
    document.getElementById(ctrname).focus();
//    if($get(ctrname).value == '0')
//    {
//        $get(ctrname).value = '';
//    }
//    else
//    {
//        $get(ctrname).value = $get(ctrname).value;
//    }
    
}



function CalculatePrice(ctrlID)
{//debugger;
    var ID_Ctrl = ctrlID;
    if($get("ddlCurrency").value != "0")
    {
        if(ctrlID = 'txtPrcBasis')
        {
            $get("txtTotalPay").value = parseFloat($get("txtExRate").value) * parseFloat($get(ctrlID).value).toFixed(6);
        }
        if(ctrlID = 'txtSlsTax')
        {
            $get("txtTotalPay").value = (parseFloat(("txtPrcBasis").value) * parseFloat($get("txtSlsTax").value/100)) + parseFloat(("txtPrcBasis").value)
        }
    }
    else
    {
        $get(ctrlID).value = '';
        alert("Select Currency");
        $get("ddlCurrency").focus();
    }
}

//--------------------------------Calculation For Direct P0-------------------------------------
function CalcPrcPO()
{//debugger;
    $get('txtTotalAmt').value = '';
    var Price =  $get('txtSubTtl').value;
    if(Price != '')
    {
        $get('txtTotalAmt').value = parseFloat(Price);
    }
    else
    {
       $get('txtTotalAmt').value = '0';
        $get('txtTaxPer').value = '0';
        $get('txtTaxAmt').value = '0'
        $get('txtDiscPer').value = '0';
        $get('txtDiscAmt').value = '0'
    }
}
function SalesTax()
{//debugger;
   $get('txtTotalAmt').value = ''
    if($get('txtTaxPer').value != '' && $get('txtSubTtl').value != '')
    {
        if(parseFloat($get('txtTaxPer').value)>100.000)
        {
            alert("Tax% should be upto 100%");
            $get('txtTaxPer').value='0';
            $get('txtTaxAmt').value = '0';
            $get('txtTotalAmt').value = '0';
            return;
        }
        else
        {
            var TaxPer = $get('txtTaxPer').value;
            var SubTtl = $get('txtSubTtl').value;            
            var TaxAmt = null;            
            TaxAmt = SubTtl * TaxPer/100;            
            $get('txtTaxAmt').value = (parseFloat(TaxAmt)).toFixed(3);
            if($get('txtDiscAmt').value == '')
            {
                    $get('txtTotalAmt').value = (((parseFloat(SubTtl) + parseFloat(TaxAmt)) )).toFixed(3);                
            }
            else
            {
               $get('txtTotalAmt').value = (((parseFloat(SubTtl) + parseFloat(TaxAmt)) - parseFloat($get('txtDiscAmt').value))).toFixed(3);                   
            }
        }
    }
    else
    {
        $get('txtTaxAmt').value = '0';
        if($('txtDiscPer').value != '' && $get('txtDiscAmt').value != '')
        {
                $get('txtTotalAmt').value = ((parseFloat($get('txtSubTtl').value) - parseFloat($get('txtDiscAmt').value))).toFixed(3);
        }
        else
        {
            $get('txtTotalAmt').value = (parseFloat($get('txtSubTtl').value)).toFixed(3);
        }
    }
}
function Discount()
{//debugger;
  $get('txtTotalAmt').value
    if($get('txtDiscPer').value != '' && $get('txtSubTtl').value != '')
    {
        if(parseFloat($get('txtDiscPer').value)>100.000)
        {
            alert("Discount% should be upto 100%");            
            $get('txtDiscPer').value='0';
            $get('txtDiscAmt').value = '0';
            //$get('txtBalAmt').value = '0';
            //$get('txtPaidAmt').value = '0';
            $get('txtTotalAmt').value = '0';
            return;
        }
        else
        {
            var DiscPer = $get('txtDiscPer').value;
            var SubTtl = $get('txtSubTtl').value;
            
            var DiscAmt = null;
            
            DiscAmt = SubTtl * DiscPer/100;
            
            $get('txtDiscAmt').value = parseFloat(DiscAmt).toFixed(3);
            if($get('txtTaxAmt').value != '')
            {
                    $get('txtTotalAmt').value = ((((parseFloat($get('txtSubTtl').value) + parseFloat($get('txtTaxAmt').value)) - parseFloat(DiscAmt)))).toFixed(3);//+ parseFloat($get('txtShipping').value)).toFixed(3);
            }
            else
            {
                    $get('txtTotalAmt').value = ((((parseFloat($get('txtSubTtl').value) + parseFloat('0')) - parseFloat(DiscAmt)))).toFixed(3);// + parseFloat($get('txtShipping').value)).toFixed(3);
            }
        }
    }
    else
    {
        $get('txtDiscAmt').value = '0';
        if($get('txtTaxPer').value != '' && $get('txtTaxAmt').value != '')
        {
                $get('txtTotalAmt').value = (((parseFloat($get('txtTaxAmt').value) + parseFloat($get('txtSubTtl').value)))).toFixed(3);// + parseFloat($get('txtShipping').value)).toFixed(3);
        }
        else
        {
//            if($get('txtShipping').value != '')
//            {
//                $get('txtTotalAmt').value = (parseFloat($get('txtSubTtl').value) + parseFloat($get('txtShipping').value)).toFixed(3);
//            }
//            else
//            {
                $get('txtTotalAmt').value = '0';
//            }
        }
    }
}
//----------------------------------New Discount Function--------------------
function Discount_New()
{//debugger;
  $get('txtTotalAmt').value
    if($get('txtDiscPer').value != '' && $get('txtSubTtl').value != '')
    {
        if(parseFloat($get('txtDiscPer').value)>100.000 && $get('rdbtnFix').checked==false)
        {
            alert("Discount% should be upto 100%");            
            $get('txtDiscPer').value='0';
            $get('txtDiscAmt').value = '0';
            //$get('txtBalAmt').value = '0';
            //$get('txtPaidAmt').value = '0';
            $get('txtTotalAmt').value = parseFloat($get('txtSubTtl').value) + parseFloat($get('txtTaxAmt').value);
            return;
        }
        else if(parseFloat($get('txtDiscPer').value)>parseFloat($get('txtSubTtl').value) && $get('rdbtnFix').checked==true)
        {
            alert("Discount should be upto Total Price");            
            $get('txtDiscPer').value='0';
            $get('txtDiscAmt').value = '0';
            //$get('txtBalAmt').value = '0';
            //$get('txtPaidAmt').value = '0';
            $get('txtTotalAmt').value = parseFloat($get('txtSubTtl').value) + parseFloat($get('txtTaxAmt').value);
            return;
        }
        else
        {
            var DiscPer = $get('txtDiscPer').value;
            var SubTtl = $get('txtSubTtl').value;
            
            var DiscAmt = null;
            if($get('rdbtnFix').checked==true)
            {
               DiscAmt = DiscPer; 
            }
            else
            {
                DiscAmt = SubTtl * DiscPer/100;
            }
            $get('txtDiscAmt').value = parseFloat(DiscAmt).toFixed(3);
            if($get('txtTaxAmt').value != '')
            {
                    $get('txtTotalAmt').value = ((((parseFloat($get('txtSubTtl').value) + parseFloat($get('txtTaxAmt').value)) - parseFloat(DiscAmt)))).toFixed(3);//+ parseFloat($get('txtShipping').value)).toFixed(3);
            }
            else
            {
                    $get('txtTotalAmt').value = ((((parseFloat($get('txtSubTtl').value) + parseFloat('0')) - parseFloat(DiscAmt)))).toFixed(3);// + parseFloat($get('txtShipping').value)).toFixed(3);
            }
        }
    }
    else
    {
        $get('txtDiscAmt').value = '0';
        if($get('txtTaxPer').value != '' && $get('txtTaxAmt').value != '')
        {
                $get('txtTotalAmt').value = (((parseFloat($get('txtTaxAmt').value) + parseFloat($get('txtSubTtl').value)))).toFixed(3);// + parseFloat($get('txtShipping').value)).toFixed(3);
        }
        else
        {
//            if($get('txtShipping').value != '')
//            {
//                $get('txtTotalAmt').value = (parseFloat($get('txtSubTtl').value) + parseFloat($get('txtShipping').value)).toFixed(3);
//            }
//            else
//            {
                $get('txtTotalAmt').value = '0';
//            }
        }
    }
}
//---------------------------------------------------------------------------
function CalcFreight()
{//debugger;
    $get('txtTotalAmt').value = '';
    if($get('txtTaxAmt').value != '' && $get('txtDiscAmt').value != '')
    {
        var shipping_amt = $get('txtShipping').value;
        if(shipping_amt != '')
        {
            if($get('txtExDuty').value != '')
            {
                $get('txtTotalAmt').value = ((parseFloat($get('txtSubTtl').value) + parseFloat($get('txtTaxAmt').value) - parseFloat($get('txtDiscAmt').value)) + parseFloat(shipping_amt) + parseFloat($get('txtExDuty').value)).toFixed(3);
            }
        }
        else
        {
            if($get('txtExDuty').value != '')
            {
                $get('txtTotalAmt').value = ((parseFloat($get('txtSubTtl').value) + parseFloat($get('txtTaxAmt').value) - parseFloat($get('txtDiscAmt').value)) + parseFloat($get('txtExDuty').value)).toFixed(3);
            }
            else
            {
                $get('txtTotalAmt').value = ((parseFloat($get('txtSubTtl').value) + parseFloat($get('txtTaxAmt').value) - parseFloat($get('txtDiscAmt').value))).toFixed(3);
            }
        }
    }
}

function ExciseDuty()
{//debugger;
    $get('txtTotalAmt').value = '';
    if($get('txtTaxAmt').value != '' && $get('txtDiscAmt').value != '' && $get('txtShipping').value != '')
    {
        var shipping_amt = $get('txtShipping').value;
        if(shipping_amt != '')
        {
            $get('txtTotalAmt').value = ((parseFloat($get('txtSubTtl').value) + parseFloat($get('txtTaxAmt').value) - parseFloat($get('txtDiscAmt').value)) + parseFloat(shipping_amt) + parseFloat($get('txtExDuty').value)).toFixed(3);
        }
        else
        {
            $get('txtTotalAmt').value = ((parseFloat($get('txtSubTtl').value) + parseFloat($get('txtTaxAmt').value) - parseFloat($get('txtDiscAmt').value))).toFixed(3);
        }
    }
}
//----------------------------------------------------------------------------------------------

