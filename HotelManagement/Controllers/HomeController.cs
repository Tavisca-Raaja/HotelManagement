
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelManagement.Models;
namespace HotelManagement.Controllers
{
    public class HomeController : ApiController
    {
        static int HotelIdIndex=104; 
       static  List<HotelDetails> Hotels = new List<HotelDetails>()
        {
            new HotelDetails{ HotelId="H101",HotelName="The Residence",AvailableRooms=10,HotelAddress="Viman Nagar"},
            new HotelDetails{ HotelId="H102",HotelName="Le Meridian",AvailableRooms=20,HotelAddress="Kharadi"},
            new HotelDetails{ HotelId="H103",HotelName="Hyatt",AvailableRooms=20,HotelAddress="Viman Nagar"}

        };
        
        [HttpGet]
        
        public Response DisplayHotelDetails()
        {
            try
            {
                return new Response()
                {
                    Details = Hotels,
                    status = new Status()
                    {
                        ApiStatus = status.Success,
                        ErrorMessage ="ALL Elements Displayed Successfully!!",
                        StatusCode = 200
                    }
                };
            }
            catch (Exception ex)
            {
                return new Response()
                {
                    Details = null,
                    status = new Status()
                    {
                        ApiStatus = status.Failure,
                        StatusCode = 500,
                        ErrorMessage = "Internal Server Error"
                    }
                };
            }
        }



        [HttpGet]
        public Response SearchHotelById(String id)
        {
            List<HotelDetails> searchObject = new List<HotelDetails>();
            try {
                searchObject .Add(Hotels.Find(Extract => Extract.HotelId.Equals(id)));
                if (searchObject.Count == 0)
                    throw new Exception("Element Not Found");
                else
                    return new Response()
                    {
                        Details = searchObject,
                        status = new Status()
                        {
                            ApiStatus = status.Success,
                            ErrorMessage = "Hotel Details Fetched Successfully Using ID",
                            StatusCode = 200
                        }
                    };
            }
            catch(Exception ex)
            {
                return new Response()
                {
                    Details = null,
                    status = new Status()
                    {
                        ApiStatus = status.Failure,
                        StatusCode = 500,
                        ErrorMessage = ex.Message
                    }
                };
            }
            

}

        [HttpPost]
        public HttpResponseMessage CreateNewHotel(HotelDetails newMember)
        {
            try
            {
                if (newMember != null)
                {
                    HotelIdIndex++;
                    newMember.HotelId = "H" + "" + HotelIdIndex;
                    Hotels.Add(newMember);
                    return Request.CreateResponse(HttpStatusCode.OK, newMember);
                }

                else
                    throw new Exception("Enter Valid Details");
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotImplemented, ex.Message);
            }
        }



        [HttpPut]
        public HttpResponseMessage UpdateDetails(String id,int NoOfRooms)
        {
            HotelDetails searchObject = null;
            try
            {
                searchObject = Hotels.Find(Extract => Extract.HotelId.Equals(id));
                if (searchObject == null)
                    throw new Exception("Element not found");
                else if (NoOfRooms > searchObject.AvailableRooms)
                    return Request.CreateResponse(HttpStatusCode.Gone, "Rooms Not AVailable");
                else
                {
                    searchObject.AvailableRooms -= NoOfRooms;
                    return Request.CreateResponse(HttpStatusCode.OK, searchObject);
                }
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound,ex.Message);
            }

        }

        
[HttpDelete]
        public HttpResponseMessage DeleteHotel(String id)
        {
            HotelDetails searchObject = null;
            try
            {
                searchObject = Hotels.Find(Extract => Extract.HotelId.Equals(id));
                if (searchObject == null)
                    throw new Exception("Element Not Found");
                else
                    Hotels.Remove(searchObject);
                return Request.CreateResponse(HttpStatusCode.OK, "Element deleted");
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound,ex.Message );
            }
        }
        
    }
}
