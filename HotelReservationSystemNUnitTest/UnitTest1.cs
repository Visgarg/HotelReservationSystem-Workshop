using NUnit.Framework;
using HotelReservationSystem;
using System.Collections.Generic;
using System.Data;
using System;

namespace HotelReservationSystemNUnitTest
{
    public class Tests
    {
        HotelReservation hotelReservation = new HotelReservation();
        /// <summary>
        /// Findings the cheapest hotel and price for given dates for regular customer.
        /// </summary>
        [Test]
        public void FindingCheapestHotelAndPrice_ForGivenDates_ForRegularCustomer()
        {
            string[] customerTypeAnddates = { "Regular", "11September2020", "12September2020" };
            hotelReservation.AddingHotelsInList(customerTypeAnddates[0]);
            List<DayOfWeek> dayofweeks = hotelReservation.AddingDatesInList(customerTypeAnddates);
            //getting actual and expected hotel object
            HotelModel hotelModelActual = hotelReservation.CheapestHotelForGivenDates(dayofweeks);
            HotelModel hotelModelExpected = new HotelModel(200, "Bridgewood", 4);
            //assert
            Assert.AreEqual(hotelModelExpected, hotelModelActual);


        }
        /// <summary>
        /// Findings the cheapest hotel and price for given dates for rewards customer.
        /// </summary>
        [Test]
        public void FindingCheapestHotelAndPrice_ForGivenDates_ForRewardsCustomer()
        {
            //getting data
            string[] customerTypeAnddates = {"Rewards", "11September2020", "12September2020" };
            //adding customer type
            hotelReservation.AddingHotelsInList(customerTypeAnddates[0]);
            //getting days of week from method
            List<DayOfWeek> dayofweeks = hotelReservation.AddingDatesInList(customerTypeAnddates);
            //getting actual object
            HotelModel hotelModelActual = hotelReservation.CheapestHotelForGivenDates(dayofweeks);
            //expected object
            HotelModel hotelModelExpected = new HotelModel(140, "Ridgewood", 5);
            //assert
            Assert.AreEqual(hotelModelExpected, hotelModelActual);
        }
        /// <summary>
        /// Throwings the type of the custom exception when passed invalid customer.
        /// </summary>
        [Test]
        public void ThrowingCustomException_WhenPassedInvalidCustomerType()
        {
            //getting data
            string[] customerTypeAnddates = { "invalid", "11September2020", "12September2020" };
            HotelReservationCustomExceptions customException = Assert.Throws<HotelReservationCustomExceptions>(() => hotelReservation.AddingHotelsInList(customerTypeAnddates[0]));
            //assert
            Assert.AreEqual(customException.type, HotelReservationCustomExceptions.ExceptionType.INVALID_CUSTOMER_TYPE);
        }
        /// <summary>
        /// Throwings the custom exception when passed invalid date.
        /// </summary>
        [Test]
        public void ThrowingCustomException_WhenPassedInvalidDate()
        {
            //adding data
            string[] customerTypeAnddates = { "Rewards", "11September2020", "12Sep2020" };
            hotelReservation.AddingHotelsInList(customerTypeAnddates[0]);
            //getting exception
            HotelReservationCustomExceptions customException = Assert.Throws<HotelReservationCustomExceptions>(() => hotelReservation.AddingDatesInList(customerTypeAnddates));
            //assert
            Assert.AreEqual(customException.type, HotelReservationCustomExceptions.ExceptionType.INVALID_DATE);


        }
    }
}