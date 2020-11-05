using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    /// <summary>
    /// hotel model to define variables
    /// </summary>
    public class HotelModel
    {
        public int totalRate;
        public string hotelName;
        public int weekdayRegularRates;
        public int weekendRegularRates;

        public HotelModel(int totalRate,string hotelName)
        {
            this.totalRate = totalRate;
            this.hotelName = hotelName;
        }
        public HotelModel(string hotelName,int weekdayRegularRates, int weekendRegularRates)
        {
            this.hotelName = hotelName;
            this.weekdayRegularRates = weekdayRegularRates;
            this.weekendRegularRates = weekendRegularRates;
        }
    }
}
