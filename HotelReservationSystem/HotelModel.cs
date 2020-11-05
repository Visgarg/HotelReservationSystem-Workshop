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
        public string hotelName;
        public int weekdayRegularRates;
        public int weekendRegularRates;

        /// <summary>
        /// Initializes a new instance of the <see cref="HotelModel"/> class.
        /// </summary>
        /// <param name="hotelName">Name of the hotel.</param>
        /// <param name="weekdayRegularRates">The weekday regular rates.</param>
        /// <param name="weekendRegularRates">The weekend regular rates.</param>
        public HotelModel(string hotelName,int weekdayRegularRates, int weekendRegularRates)
        {
            this.hotelName = hotelName;
            this.weekdayRegularRates = weekdayRegularRates;
            this.weekendRegularRates = weekendRegularRates;
        }
    }
}
