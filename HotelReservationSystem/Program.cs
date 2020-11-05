using System;

namespace HotelReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hotel Reservation Program");

            HotelReservation hotelReservation = new HotelReservation();
            hotelReservation.AddingHotelsInList();
        }

    }
}
