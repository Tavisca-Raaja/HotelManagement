using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.Models
{
    public class Response
    {

        public List<HotelDetails> Details { get; set; }

        public Status status { get; set; }
    }
}