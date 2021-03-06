﻿namespace HotelReservationSystem
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// class to add hotels elements in list and get the cheapest hotel
    /// </summary>
    public class HotelReservation
    {
        //defining the list which contain all hotel details
        List<HotelModel> hotelsList = new List<HotelModel>();
        //making a  list for adding rates and hotel names
        List<HotelModel> rateAndHotelsList = new List<HotelModel>();
        //defining a list to get a hotel with highest ratings after getting hotel with min rates
        List<HotelModel> listWithMinPrices = new List<HotelModel>();

        /// <summary>
        /// Addings the hotels in list by checking the customer type
        /// </summary>
        public void AddingHotelsInList(string customerType)
        {
            //printing custmer type
            Console.WriteLine("Type of Customer:\t" + customerType);
            //checking for customer type to be equal to value in enum customer type
            if (customerType.Equals(CustomerType.Regular.ToString()))
            {
                //adding values in hotellist according to the customer type
                hotelsList.Add(new HotelModel("Lakewood", 110, 90, 3));
                hotelsList.Add(new HotelModel("Bridgewood", 150, 50, 4));
                hotelsList.Add(new HotelModel("Ridgewood", 220, 150, 5));
                Console.WriteLine("Hotel Name \tWeekdayHotelPrices\tweekendHotelPrices");
                //printing the details of hotels
                foreach (HotelModel hotelModel in hotelsList)
                {
                    Console.WriteLine(hotelModel.hotelName + ":\t" + hotelModel.weekdayRates + "\t\t" + hotelModel.weekendRates);
                }
            }
            else if (customerType.Equals(CustomerType.Rewards.ToString()))
            {
                hotelsList.Add(new HotelModel("Lakewood", 80, 80, 3));
                hotelsList.Add(new HotelModel("Bridgewood", 110, 50, 4));
                hotelsList.Add(new HotelModel("Ridgewood", 100, 40, 5));
                Console.WriteLine("Hotel Name \tWeekdayHotelPrices\tweekendHotelPrices");
                //printing the details of hotels
                foreach (HotelModel hotelModel in hotelsList)
                {
                    Console.WriteLine(hotelModel.hotelName + ":\t" + hotelModel.weekdayRates + "\t\t" + hotelModel.weekendRates);
                }
            }
            else
            {
                throw new HotelReservationCustomExceptions(HotelReservationCustomExceptions.ExceptionType.INVALID_CUSTOMER_TYPE, "Customer type is invalid");
            }

        }
        /// <summary>
        /// Addings the dates in list.
        /// </summary>
        /// <param name="datesArray">The dates array.</param>
        /// <returns>list of day of weeks</returns>
        /// <exception cref="HotelReservationCustomExceptions">Date is not of correct type</exception>
        public List<DayOfWeek> AddingDatesInList(string[] datesArray)
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
                    Console.WriteLine(date + "\t" + date.DayOfWeek);
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
        /// Calculatings the price for each hotel.
        /// </summary>
        /// <param name="datesList">The dates list.</param>
        public void CalculatingPriceForEachHotel(List<DayOfWeek> datesList)
        {
            //iterating over hotels in hotellist
            foreach (HotelModel hotelModel in hotelsList)
            {
                //setting total price as 0
                int totalPrice = 0;
                //iterating over days in date list
                foreach (DayOfWeek day in datesList)
                {
                    //checking for saturday and sunday in days
                    if (day.ToString().Equals("Saturday")||day.ToString().Equals("Sunday"))
                    {
                        //adding rate in total price
                        totalPrice = totalPrice + hotelModel.weekendRates;
                    }
                    else
                    {
                        //if weekday, adding rate in total price
                        totalPrice = totalPrice + hotelModel.weekdayRates;
                    }
                }
                //printing the total price and hotel name for each iteration
                Console.WriteLine(" Hotel for given Dates:\t" + hotelModel.hotelName + " Total Price to be paid:\t" +totalPrice);
                //adding price and hotelname in sorted  dictionary
                //will sorted by price
                rateAndHotelsList.Add(new HotelModel(totalPrice,hotelModel.hotelName,hotelModel.ratingsForHotels));
            }
        }
        /// <summary>
        /// Cheapests the hotel for given dates in sorted dictionary
        /// </summary>
        /// <param name="datesList">The dates list.</param>
        public HotelModel CheapestHotelForGivenDates(List<DayOfWeek> datesList)
        {
            //calling calculatingpriceforeachhotel for totalrates for each hotel
            CalculatingPriceForEachHotel(datesList);
            //iterating the loop and breaking at first iteration
            //using lambda expression and linq to order the list by total rates
            foreach(HotelModel hotelModel in rateAndHotelsList.OrderBy(r=>r.totalRate).ToList())
            {
                //printing the hotels with minimum rates
                if (hotelModel.totalRate == rateAndHotelsList.Min(r => r.totalRate))
                {
                    //adding hotel with min prices in another list
                    listWithMinPrices.Add(hotelModel);
                    //printing details for all minimum hotels
                    Console.WriteLine("\nHotel for given Dates:\t" +hotelModel.hotelName + "\nTotal Price to be paid for hotel:\t" + hotelModel.totalRate+"\nRating of Hotel:\t"+hotelModel.ratingsForHotels);
                    Console.WriteLine();

                }

            }
            //iterating over list of all minimum hotels
            foreach(HotelModel hotelModel in listWithMinPrices)
            {
                //getting the hotel with max ratings in the min hotels
                if(hotelModel.ratingsForHotels==listWithMinPrices.Max(r=>r.ratingsForHotels))
                {
                    Console.WriteLine("*************************Cheapest hotel with best ratings*****************************");
                    Console.WriteLine("\nCheapest Hotel for given Dates:\t" +hotelModel.hotelName + "\nTotal Price to be paid for cheapest hotel:\t" + hotelModel.totalRate + "\nRating of Hotel:\t" + hotelModel.ratingsForHotels);
                    return hotelModel;
                }
            }
            return null;
        }
        /// <summary>
        /// Findings the hotels with best ratings.
        /// </summary>
        /// <param name="dateList">The date list.</param>
        public void FindingHotelsWithBestRatings(List<DayOfWeek> dateList)
        {
            //calculating rates for each hotel
            CalculatingPriceForEachHotel(dateList);
            //iterating to find out best rated hotel
            foreach(HotelModel hotelModel in rateAndHotelsList)
            {
                //lambda expression and linq to find best rated hotel
                if(hotelModel.ratingsForHotels==rateAndHotelsList.Max(r=>r.ratingsForHotels))
                {
                    Console.WriteLine("************************* Hotel with best ratings*****************************");
                    Console.WriteLine("\nBest Hotel for given Dates:\t" + hotelModel.hotelName + "\nTotal Price to be paid for  hotel:\t" + hotelModel.totalRate + "\nRating of Hotel:\t" + hotelModel.ratingsForHotels);
                }
            }
        }
    }

}
