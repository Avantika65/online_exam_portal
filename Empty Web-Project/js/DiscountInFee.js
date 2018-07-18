function CheckAmtBox(cntrlid)
{
    
    var value1 = cntrlid.substring(0, 12);

    var txtid = document.getElementById(value1 + "txtDiscount");    
    var checkBoxID = document.getElementById(value1 + "chkApproval");
    
    if (txtid.value > 0) {
       
        checkBoxID.checked = true;
    }
    else
    {
        checkBoxID.checked = false;
    }
}