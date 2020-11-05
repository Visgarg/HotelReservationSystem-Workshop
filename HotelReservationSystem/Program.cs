using System;
using System.Collections;
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
            //iterating loop until user wants to find best hotels
            while (true)
            {
                Console.WriteLine("Please Enter 1 to find cheapest hotel\nPlease Enter 2 to find hotel with best ratings");
                //reading input to choose between cheap hotel or best rated hotel
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        //calling method to calculate cheapest hotel
                        hotelReservation.CheapestHotelForGivenDates(datesList);
                        break;
                    case 2:
                        //calling method to calculate best rated hotel
                        hotelReservation.FindingHotelsWithBestRatings(datesList);
                        break;
                    default:
                        Console.WriteLine("Please enter the correct input");
                        break;
                }
                Console.WriteLine("Do you want to find out again,press y to check again");
                string check = Console.ReadLine();
                if(!(check.ToLower().Equals("y")))
                {
                    break;
                }
            }
            //calling the method for getting cheapest hotel for given dates
            
        }

    }
}
