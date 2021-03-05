using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeaceHotelAPI.Dtos
{
    public class ClientDisplayDto
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
       public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public int RoomNo { get; set; }
        public DateTime DateCheckedIn { get; set; }
    }
}
