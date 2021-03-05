using PeaceHotelAPI.Dtos;
using PeaceHotelAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeaceHotelAPI.Interfaces
{
    public interface IEmailer
    {
        public string SendEmailToClient(ClientCreateDto client);
        public string SendEmailToAdmin(Room bookRoom);



    }
}
