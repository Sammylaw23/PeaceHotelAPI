using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PeaceHotelAPI.Data;
using PeaceHotelAPI.Dtos;
using PeaceHotelAPI.Entities;
using PeaceHotelAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeaceHotelAPI.Repositories
{
    public class RoomRepo : IRoomRepo
    {
        readonly PeaceHotelAPIDbContext _db;
        private readonly IMapper _mapper;
        public RoomRepo(PeaceHotelAPIDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<Room> BookRoom(BookRoomDto bookRoom)
        {
            //var _room = _mapper.Map<Room>(bookRoom);
            var _room = new Room
            {
                RoomNo = bookRoom.RoomNo,
                RoomOccupant = string.Concat(bookRoom.FirstName, bookRoom.LastName),
                RoomFree = RoomFree.N
            };
            //_db.Rooms.Add(_room);
            _db.Entry(_room).State = EntityState.Modified;

            int result = await _db.SaveChangesAsync();
            return result > 0 ? _room : null;
            //return result > 0 ? _mapper.Map<BookRoomDto>(_room) : null;
        }

        public async Task<RoomCreateDto> CreateRoom(RoomCreateDto roomCreate)
        {
            var _room = _mapper.Map<Room>(roomCreate);
            _db.Rooms.Add(_room);
            int result = await _db.SaveChangesAsync();
            return result > 0 ? _mapper.Map<RoomCreateDto>(_room) : null;

        }

        public async Task<int> GetAllRoomsCount()
        {
            var rooms = await _db.Rooms.ToListAsync();
            return rooms.Count;
        }
        public async Task<int> GetFreeRoomsCount()
        {
            var rooms = await _db.Rooms.Where(r => r.RoomFree == RoomFree.Y).ToListAsync();
            return rooms.Count;
        }

        public async Task<string> GetRoomOccupancy(int roomNo)
        {
            return await _db.Rooms.Where(r => r.RoomNo == roomNo).Select(n => n.RoomOccupant).FirstOrDefaultAsync();
        }

        public async Task<bool> RoomExists(RoomCreateDto roomCreate)
        {
            return await _db.Rooms.AnyAsync(u => u.RoomName.Equals(roomCreate.RoomName) && u.RoomCost.Equals(roomCreate.RoomCost));

        }




    }
}
