using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class HotelReservation
    {
        List<HotelModel> hotelsList = new List<HotelModel>();

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
    }

}
