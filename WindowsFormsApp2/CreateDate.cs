using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FareComparison {
    class CreateDate
    {
        public int year;
        public int month;
        public int day;
        public int hour;
        public int min;
        public int second = 0;

        public CreateDate(string Month, string Day, string Time)
        {
            if (Month == "JAN") month = 1;
            else if (Month == "FEB") month = 2;
            else if (Month == "MAR") month = 3;
            else if (Month == "APR") month = 4;
            else if (Month == "MAY") month = 5;
            else if (Month == "JUN") month = 6;
            else if (Month == "JUL") month = 7;
            else if (Month == "AUG") month = 8;
            else if (Month == "SEP") month = 9;
            else if (Month == "OCT") month = 10;
            else if (Month == "NOV") month = 11;
            else if (Month == "DEC") month = 12;
            if (month < DateTime.Now.Month || (month == DateTime.Now.Month && day <= DateTime.Now.Day))
            {
                this.year = DateTime.Now.Year + 1;
            }
            else this.year = DateTime.Now.Year;
            this.day = Convert.ToInt32(Day);
            hour = (Time[Time.Length - 1] == 'P' && Convert.ToInt32(Time.Substring(0, 2))!=12)? Convert.ToInt32(Time.Substring(0, 2)) + 12 : Convert.ToInt32(Time.Substring(0, 2));
            
            min = Convert.ToInt32(Time.Substring(2, 2));
            if (Time.Substring(0, 2) == "12" && min == 0 && Time.Contains('N')) hour = 12;
            else if(Time.Substring(0, 2) == "12" && min == 0) hour = 24;
        }

        public DateTime createDateTime()
        {
            return new DateTime(year, month, day, hour, min, second);
        }

    }
}
