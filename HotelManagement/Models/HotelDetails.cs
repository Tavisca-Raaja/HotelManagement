using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.Models
{
    public class HotelDetails
    {
        public String HotelId { get; set; }
        public String HotelName { get; set; }
        public int AvailableRooms { get; set; }
        public String HotelAddress { get; set; }
        
    }
}