﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public class HotelReservationCustomExceptions:Exception
    {
        public enum ExceptionType
        {
            INVALID_CUSTOMER_TYPE,INVALID_DATE,INVALID_TOTAL_RATE,INVALID_HOTEL_NAME
        }
        public ExceptionType type;
        public HotelReservationCustomExceptions(ExceptionType type,string message):base(message)
        {
            this.type = type;
        }
    }
}
