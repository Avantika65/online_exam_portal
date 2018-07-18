function PDC_onclick(str) 
        {
    EducationService.PostDateChequeEntry(str);
			//RCSService.Journal_Subs_Detail(JRN_Id, GenDtlSuccessFn_1, OnError, OnTimeOut);
		}

		function OnComplete(arg)
		{
			alert(arg);
		}

		function OnTimeOut(arg)
		{
			alert("timeOut has occured");
		}

		function OnError(arg)
		{
			alert("error has occured: " + arg._message);
		}  