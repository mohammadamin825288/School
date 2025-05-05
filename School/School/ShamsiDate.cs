using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace School
{
    class ShamsiDate
    {
        public static string ConvertToShamsi(DateTime mydate)
        {
            PersianCalendar mypc = new PersianCalendar();
            StringBuilder mysb = new StringBuilder();
            mysb.Append(mypc.GetYear(mydate).ToString("0000"));
            mysb.Append("/");
            mysb.Append(mypc.GetMonth(mydate).ToString("00"));
            mysb.Append("/");
            mysb.Append(mypc.GetDayOfMonth(mydate).ToString("00"));
            return mysb.ToString();




        }
    }
}
