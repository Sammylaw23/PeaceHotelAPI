using PeaceHotelAPI.Dtos;
using PeaceHotelAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeaceHotelAPI.Interfaces
{
    public interface IRoomRepo
    {
        Task<Room> BookRoom(BookRoomDto bookRoom);
        //Task<BookRoomDto> BookRoom(BookRoomDto bookRoom);
        Task<RoomCreateDto> CreateRoom(RoomCreateDto roomCreate);
        Task<bool> RoomExists(RoomCreateDto roomCreate);
        Task<int> GetAllRoomsCount();
        Task<int> GetFreeRoomsCount();

        Task<string> GetRoomOccupancy(int roomNo);

    }
}
