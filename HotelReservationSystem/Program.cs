using System;
using System.Collections.Generic;

namespace HotelReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hotel Reservation Program");

            HotelReservation hotelReservation = new HotelReservation();
            hotelReservation.AddingHotelsInList();
            Console.WriteLine("Please enter the dates for which cheapest hotel needs to be find out");
            string datesString = Console.ReadLine();
            string[] datesArray = datesString.Split(',');
            List<DayOfWeek> datesList = new List<DayOfWeek>();
            for (int i=0;i<datesArray.Length;i++)
            {
               DateTime date= Convert.ToDateTime(datesArray[i]);
               datesList.Add(date.DayOfWeek);
            }
            foreach(DayOfWeek day in datesList)
            {
                Console.WriteLine(day);
            }
            hotelReservation.CheapestHotelForGivenDates(datesList);
        }

    }
}
