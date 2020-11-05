using System;

namespace HotelReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DateTime dateValue = new DateTime(2008, 6, 14);
            Console.WriteLine((int)dateValue.DayOfWeek);
        }
    }
}
