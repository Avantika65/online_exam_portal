using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for GDate
/// </summary>
public class GDate
{
	public GDate()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public enum DateRangeOptions : byte
    {
        Week = 1, Month = 2, Quarter = 4, Year = 5
    }
    public struct DateRangeStruct
    {
        public DateTime startDate;
        public DateTime endDate;
    }
    /// <summary>
    /// Returns a string array with start and end dates for a given range.
    /// </summary>
    /// <param name="range">Enumeration value specifying which
    /// abstracted date range to evaluate. Note, weeks begin on Sunday
    /// and end on Saturday.</param>
    /// <param name="relativeDate">Date to use as the basis for
    /// calculating the start and end date of the range.</param>
    /// <returns>DateTimeStruct</returns>
    public static DateRangeStruct DateRange(DateRangeOptions DRO, DateTime relativeDate)
    {
        DateTime[] retValue = { DateTime.Today, DateTime.Today };
        DateTime myDate = relativeDate;

        switch (DRO)
        {
            case DateRangeOptions.Week:

                if (myDate.DayOfWeek > 0)
                {
                    myDate = myDate.AddDays(-1 * Convert.ToInt32(myDate.DayOfWeek));
                }

                retValue[0] = myDate;
                retValue[1] = myDate.AddDays(6);

                break;

            case DateRangeOptions.Month:

                if (myDate.Day > 1) myDate = myDate.AddDays(-1 * (myDate.Day - 1));

                retValue[0] = myDate;
                retValue[1] = myDate.AddMonths(1);
                retValue[1] = retValue[1].AddDays(-1);

                break;

            case DateRangeOptions.Quarter:

                if (myDate.Month < 4) retValue[0] = Convert.ToDateTime("1/1/" +
                            myDate.Year.ToString());
                if (myDate.Month > 3 && myDate.Month < 7) retValue[0] =
                            Convert.ToDateTime("4/1/" + myDate.Year.ToString());
                if (myDate.Month > 6 && myDate.Month < 10) retValue[0] =
                            Convert.ToDateTime("7/1/" + myDate.Year.ToString());
                if (myDate.Month > 9) retValue[0] = Convert.ToDateTime("10/1/" +
                            myDate.Year.ToString());

                retValue[1] = retValue[0].AddMonths(3);
                retValue[1] = retValue[1].AddDays(-1);

                break;

            case DateRangeOptions.Year:

                retValue[0] = Convert.ToDateTime("1/1/" + myDate.Year.ToString());
                retValue[1] = Convert.ToDateTime("12/31/" + myDate.Year.ToString());

                break;
        }

        DateRangeStruct retVal;
        retVal.startDate = retValue[0];
        retVal.endDate = retValue[1];

        return retVal;
    }

    public static DateRangeStruct DateRange(DateRangeOptions DRO, string relativeDate)
    {
        return DateRange(DRO, Convert.ToDateTime(relativeDate));
    }

}
