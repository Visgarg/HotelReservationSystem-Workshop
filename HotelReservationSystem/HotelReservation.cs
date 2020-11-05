namespace HotelReservationSystem
{
    using System;
    using System.Collections.Generic;
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

        /// <summary>
        /// Addings the hotels in list.
        /// </summary>
        public void AddingHotelsInList()
        {
            hotelsList.Add(new HotelModel("Lakewood", 110,90));
            hotelsList.Add(new HotelModel("Bridegewood", 150,50));
            hotelsList.Add(new HotelModel("Ridgewood", 220,150));
            Console.WriteLine("Hotel Name \tWeekdayHotelPrices\tweekendHotelPrices");
            //printing the details of hotels
            foreach(HotelModel hotelModel in hotelsList)
            {
                Console.WriteLine(hotelModel.hotelName + ":\t" + hotelModel.weekdayRegularRates+"\t\t"+ hotelModel.weekendRegularRates);
            }
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
                        totalPrice = totalPrice + hotelModel.weekendRegularRates;
                    }
                    else
                    {
                        //if weekday, adding rate in total price
                        totalPrice = totalPrice + hotelModel.weekdayRegularRates;
                    }
                }
                //printing the total price and hotel name for each iteration
                Console.WriteLine(" Hotel for given Dates:\t" + hotelModel.hotelName + " Total Price to be paid:\t" +totalPrice);
                //adding price and hotelname in sorted  dictionary
                //will sorted by price
                rateAndHotelsList.Add(new HotelModel(totalPrice,hotelModel.hotelName));
            }
        }
        /// <summary>
        /// Cheapests the hotel for given dates in sorted dictionary
        /// </summary>
        /// <param name="datesList">The dates list.</param>
        public void CheapestHotelForGivenDates(List<DayOfWeek> datesList)
        {
            //calling calculatingpriceforeachhotel for totalrates for each hotel
            CalculatingPriceForEachHotel(datesList);
            //iterating the loop and breaking at first iteration
            foreach(HotelModel hotelModel in rateAndHotelsList.OrderBy(r=>r.totalRate).ToList())
            {
                if (hotelModel.totalRate == rateAndHotelsList.Min(r => r.totalRate))
                {
                    Console.WriteLine("\nCheapest Hotel for given Dates:\t" + hotelModel.hotelName + "\nTotal Price to be paid for cheapest hotel:\t" + hotelModel.totalRate);
                    Console.WriteLine();
                }

            }
        }
    }

}
