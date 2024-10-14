// Подключаем пространство имен, в котором находится класс MyDate
using ConsoleApp6;
using System;

namespace ConsoleApp7
{
    internal class Class1
    {
        static void Main(string[] args)
        {
            MyDate mydate1 = new MyDate(12, 12, 2024, "Wednesday");
            MyDate mydate2 = new MyDate(12, 10, 2024, "Tuesday");

            mydate1.ShowMyDate();
            Console.WriteLine("---------------");
            mydate2.ShowMyDate();

            int difference = mydate1.getDifference(mydate2);
            Console.WriteLine($"Difference in days: {difference}");

            mydate1.changeDate(25);
            mydate1.ShowMyDate();
        }


    }
}
