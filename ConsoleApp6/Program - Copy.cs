using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class MyDate
    {
        private int _year;
        private int _month;
        private int _day;
        private string _day_of_week;

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public int Month
        {
            get { return _month; }
            set { _month = value; }
        }

        public int Day
        {
            get { return _day; }
            set { _day = value; }
        }

        public string _day_Of_Week
        {
            get {  return _day_of_week; }
            set { _day_of_week = value;}
        }

        public MyDate()
        {
            Console.WriteLine("Конструктор по умолчанию");
        }

        public MyDate(int day, int month, int year, string dayOfWeek)
        {
            _year = year;
            _month = month;
            _day = day;
            _day_of_week = dayOfWeek;
        }

        int GetDaysInMonth(int month)
        {
            switch (month)
            {
                case 1: // January
                case 3: // March
                case 5: // May
                case 7: // July
                case 8: // August
                case 10: // October
                case 12: // December
                    return 31;

                case 4: // April
                case 6: // June
                case 9: // September
                case 11: // November
                    return 30;

                case 2: // February
                    return 28;

                default:
                    throw new ArgumentOutOfRangeException("Invalid month");
            }
        }


        public void ShowMyDate()
        {
            Console.WriteLine($"Date: {Day}/{this.Month}/{this.Year}");
        }

        //public int getDifference(MyDate date2)
        //{
        //    int newYear = this.Year - date2.Year;
        //    int newMonth = this.Month - date2.Month;
        //    int new_day = this.Day - date2._day;

        //    // Если дни меньше, переносим из предыдущего месяца
        //    if (new_day < 0)
        //    {
        //        // Получаем количество дней в предыдущем месяце
        //        int daysInPreviousMonth = GetDaysInMonth(this.Month - 1);
        //        new_day += daysInPreviousMonth;
        //        newMonth -= 1;
        //    }

        //    // Если месяцы меньше, переносим из предыдущего года
        //    if (newMonth < 0)
        //    {
        //        newMonth += 12;
        //        newYear -= 1;
        //    }

        //    // Рассчитываем общее количество дней
        //    int total_days = newYear * 365 + newMonth * 30 + new_day;

        //    return total_days;
        //}


        public int getDifference(MyDate date2)
        {
            int newYear = this.Year - date2.Year;
            int newMonth = this.Month - date2.Month;
            int newDay = this.Day - date2.Day;

            if (newDay <= 0)
            {
                int prevMonth = this.Month - 1;

                if (prevMonth == 0)
                {
                    prevMonth = 12;
                    newYear--;
                }

                int prevMonthDays = GetDaysInMonth(prevMonth);
                newDay += prevMonthDays;
                newMonth -= 1;
            }

            if (newMonth <= 0)
            {
                newMonth += 12;
                newYear -= 1;
            }

            int totalMonthDays = 0;
            for (int i = 0; i < newMonth; i++)
            {
                int monthIndex = date2.Month + i;

                if (monthIndex > 12)
                {
                    monthIndex -= 12;
                }

                totalMonthDays += GetDaysInMonth(monthIndex);
            }

            int totalDays = (newYear * 365) + totalMonthDays + newDay;

            return totalDays;
        }

        public void changeDate(int days)
        {
            this.Day += days;

            while (this.Day > this.GetDaysInMonth(this.Month))
            {
                this.Day -= this.GetDaysInMonth(this.Month);
                this.Month++;
                if(this.Month > 12)
                {
                    this.Year += 1;
                    this.Month -= 12;
                }
            }
        }


    }
}
