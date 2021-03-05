using PeaceHotelAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeaceHotelAPI.Dtos
{
    public class RoomCreateDto
    {
        public string RoomName { get; set; }
        public double RoomCost { get; set; }
        public RoomFree RoomFree { get; set; } = RoomFree.N;
    }
}
