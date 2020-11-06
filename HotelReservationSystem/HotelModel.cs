using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HotelReservationSystem
{
    /// <summary>
    /// hotel model to define variables
    /// </summary>
    public class HotelModel
    {

        public int totalRate;
        public string hotelName;
        public int weekdayRates;
        //adding weekend prices for hotels
        public int weekendRates;
        //adding rating to hotel
        public int ratingsForHotels;

        public HotelModel(int totalRate,string hotelName,int ratingsForHotels)
        {
            this.totalRate = totalRate;
            this.hotelName = hotelName;
            this.ratingsForHotels = ratingsForHotels;
        }
        public HotelModel(string hotelName,int weekdayRates, int weekendRates,int ratingsForHotels)
        {
            this.hotelName = hotelName;
            this.weekdayRates = weekdayRates;
            this.weekendRates = weekendRates;
            this.ratingsForHotels = ratingsForHotels;
        }
    }
}
