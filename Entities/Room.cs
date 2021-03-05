using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeaceHotelAPI.Entities
{
    public class Room
    {
        [Key]
        public int RoomNo { get; set; }
        public string RoomName { get; set; }
        public string RoomOccupant { get; set; }
        public double RoomCost { get; set; }
        public RoomFree RoomFree { get; set; }         //INFO........Y means room is available and N means room is taken 

    }


    public enum RoomFree
    {
        Y = 0,
        N = 1
    }
}
