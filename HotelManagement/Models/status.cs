using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.Models
{
    public class Status
    {
        public status ApiStatus { get; set; }

        public int StatusCode { get; set; }

        public string ErrorMessage { get; set; }
    }

    public enum status
    {
        Success,
        Failure,
        Warning
    }
}