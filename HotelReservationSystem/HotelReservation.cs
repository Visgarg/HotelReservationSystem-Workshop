using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class HotelReservation
    {
        List<HotelModel> hotelsList = new List<HotelModel>();
        SortedDictionary<int, string> rateAndHotelsDictionary = new SortedDictionary<int, string>();

        public void AddingHotelsInList()
        {
            hotelsList.Add(new HotelModel("Lakewood", 110));
            hotelsList.Add(new HotelModel("Bridegewood", 160));
            hotelsList.Add(new HotelModel("Ridgewood", 220));
            Console.WriteLine("Hotel Name \tWeekdayHotelPrices");
            foreach(HotelModel hotelModel in hotelsList)
            {
                Console.WriteLine(hotelModel.hotelName + ":\t" + hotelModel.weekdayRegularRates);
            }
        }
        public void CalculatingPriceForEachHotel(List<DayOfWeek> datesList)
        {
            foreach (HotelModel hotelModel in hotelsList)
            {
                int totalPrice = 0;
                foreach (DayOfWeek day in datesList)
                {
                    totalPrice = totalPrice + hotelModel.weekdayRegularRates;
                }
                Console.WriteLine(" Hotel for given Dates:\t" + hotelModel.hotelName + " Total Price to be paid:\t" +totalPrice);
                rateAndHotelsDictionary.Add(totalPrice, hotelModel.hotelName);
            }
        }
        public void CheapestHotelForGivenDates(List<DayOfWeek> datesList)
        {
            CalculatingPriceForEachHotel(datesList);
            foreach(KeyValuePair<int,string> ratesAndHotels in rateAndHotelsDictionary)
            {
                Console.WriteLine("\nCheapest Hotel for given Dates:\t"+ratesAndHotels.Value+ "\nTotal Price to be paid for cheapest hotel:\t" + ratesAndHotels.Key);
                Console.WriteLine();
                break;
            }
        }
    }

}
