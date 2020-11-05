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
        //adding weekend prices for hotels
        public int weekendRegularRates;
        //adding rating to hotel
        public int ratingsForHotels;
        public HotelModel(int totalRate,string hotelName,int ratingsForHotels)
        {
            this.totalRate = totalRate;
            this.hotelName = hotelName;
            this.ratingsForHotels = ratingsForHotels;
        }
        public HotelModel(string hotelName,int weekdayRegularRates, int weekendRegularRates,int ratingsForHotels)
        {
            this.hotelName = hotelName;
            this.weekdayRegularRates = weekdayRegularRates;
            this.weekendRegularRates = weekendRegularRates;
            this.ratingsForHotels = ratingsForHotels;
        }
    }
}
