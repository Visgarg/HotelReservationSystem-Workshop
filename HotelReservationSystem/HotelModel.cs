using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class HotelModel
    {
        public string hotelName;
        public int weekdayRegularRates;

        public HotelModel(string hotelName,int weekdayRegularRates)
        {
            this.hotelName = hotelName;
            this.weekdayRegularRates = weekdayRegularRates;
        }
    }
}
