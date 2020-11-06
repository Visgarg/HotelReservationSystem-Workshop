using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace HotelReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            HotelReservation hotelReservation = new HotelReservation();
            Console.WriteLine("Welcome to Hotel Reservation Program");
            //instatiating hotel reservations
            List<DayOfWeek> datesList;
            //getting input from user
            string[] datesArray = InputCustomerTypeAndDate();

            //adding data into hotel list in hotel reservations using customer type
            AddingHotelDataAccToCustomerType(hotelReservation,datesArray);

            //adding dates in list and converting them to days of week
            //if date input is not in correct form, then custom exception thrown by method is catched.
            try
            {
                datesList = AddingDatesInList(datesArray);
            }
            catch(HotelReservationCustomExceptions ex)
            {
                Console.WriteLine(ex.Message);
                return;
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
                        //calling the method for getting cheapest hotel for given dates
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
            
            
        }
        /// <summary>
        /// Addings the type of the hotel data acc to customer.
        /// </summary>
        /// <param name="hotelReservation">The hotel reservation.</param>
        /// <param name="datesArray">The dates array.</param>
        public static void AddingHotelDataAccToCustomerType(HotelReservation hotelReservation,string[] datesArray)
        {
            
            try
            {
                //first input was taken as customer type, which is seperated and assigned to customer type
                string customerType = datesArray[0];
                //calling method for adding hotels in list
                hotelReservation.AddingHotelsInList(customerType);
                //creating day of week dates list
            }
            catch (HotelReservationCustomExceptions ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
        }
        /// <summary>
        /// Addings the dates in list.
        /// </summary>
        /// <param name="datesArray">The dates array.</param>
        /// <returns>list of day of weeks</returns>
        /// <exception cref="HotelReservationCustomExceptions">Date is not of correct type</exception>
        public static  List<DayOfWeek>  AddingDatesInList(string[] datesArray)
        {
            List<DayOfWeek> datesList = new List<DayOfWeek>();
            //iterating over array of dates, converting it in date and then adding day of week  in list
            //iteration from 1 as first input was customer type
             for (int i = 1; i < datesArray.Length; i++)
             {
                DateTime date;
                //using regex validation to validate correct format of date
                if (DateTime.TryParseExact(datesArray[i], "ddMMMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    Console.WriteLine(date+"\t"+date.DayOfWeek);
                    datesList.Add(date.DayOfWeek);
                }
                else
                { 
                    throw new HotelReservationCustomExceptions(HotelReservationCustomExceptions.ExceptionType.INVALID_DATE, "Date is not of correct type");
                }
             }
            return datesList;

        }
        /// <summary>
        /// Inputs the customer type and date.
        /// </summary>
        /// <returns>array of dates with first element as customer type</returns>
        public static string[] InputCustomerTypeAndDate()
        {
            Console.WriteLine("Please enter the customer type and dates(DDMMMMYYYY) for which cheapest hotel needs to be find out");
            //reading the dates in string
            string datesString = Console.ReadLine();
            //adding the string of dates in array
            string[] datesArray = datesString.Split(',');
            return datesArray;
        }

    }
}
