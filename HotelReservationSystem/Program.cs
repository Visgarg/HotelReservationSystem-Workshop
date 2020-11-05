using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HotelReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hotel Reservation Program");
            //instatiating hotel reservations
            HotelReservation hotelReservation = new HotelReservation();
            //calling method for adding hotels in list
            hotelReservation.AddingHotelsInList();
            Console.WriteLine("Please enter the dates for which cheapest hotel needs to be find out");
            //reading the dates in string
            string datesString = Console.ReadLine();
            //adding the string of dates in array
            string[] datesArray = datesString.Split(',');
            //creating day of week dates list
            List<DayOfWeek> datesList = new List<DayOfWeek>();
            //iterating over array of dates, converting it in date and then adding day of week  in list
            for (int i=0;i<datesArray.Length;i++)
            {
               DateTime date= Convert.ToDateTime(datesArray[i]);
               //adding day of week of dates in list
               datesList.Add(date.DayOfWeek);
            }
            //printing the days
            foreach(DayOfWeek day in datesList)
            {
                Console.WriteLine(day);
            }
            //calling the method for getting cheapest hotel for given dates
            hotelReservation.CheapestHotelForGivenDates(datesList);
        }

    }
}
