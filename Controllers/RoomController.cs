using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PeaceHotelAPI.Dtos;
using PeaceHotelAPI.Entities;
using PeaceHotelAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeaceHotelAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class RoomController : Controller
    {
        private readonly IClientRepo _clientRepo;
        private readonly IRoomRepo _roomRepo;
        private readonly IMapper _mapper;
        private readonly IEmailer _emailer;

        public RoomController(IClientRepo clientRepo, IRoomRepo roomRepo, IMapper mapper, IEmailer emailer)
        {
            _clientRepo = clientRepo;
            _roomRepo = roomRepo;
            _mapper = mapper;
            _emailer = emailer;
        }


        /// <summary>
        /// This methods creates a room. 
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        [HttpPost("createroom")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> CreateRoom(RoomCreateDto room)
        {

            if (await _roomRepo.RoomExists(room))
                return StatusCode(400, new { Error = "Room already exists" });

            var _room = await _roomRepo.CreateRoom(room);
            return _room == null
                ? StatusCode(500, new { Error = "Could not create room." })
                : StatusCode(201, _room);

        }


        /// <summary>
        /// This method books a room for a client 
        /// </summary>
        /// <param name="bookRoom"></param>
        /// <returns></returns>
        [HttpPost("room")]
        public async Task<ActionResult> RegisterRoom(BookRoomDto bookRoom)
        {
            if (!await _clientRepo.ClientExists(bookRoom.Email))
                return StatusCode(400, new { Error = "Client has not been registered, kindly register before booking a room" });

            if (await _clientRepo.ClientExists(bookRoom.RoomNo, string.Concat(bookRoom.FirstName, bookRoom.LastName)))
                return StatusCode(400, new { Error = "Client has already booked this room" });

            var _bookRoom = await _roomRepo.BookRoom(bookRoom);

            if (_bookRoom == null)
            {
                return StatusCode(500, new { Error = "Could not book room." });
            }
            else
            {
                //send mail to admin
                _emailer.SendEmailToAdmin(_bookRoom);

                return StatusCode(201, _bookRoom);

            }
        }

        /// <summary>
        /// This method gets the count of all rooms
        /// </summary>
        /// <returns></returns>
        [HttpGet("roomscount")]
        public async Task<ActionResult> GetAllRoomsCount()
        {
            var roomCount = await _roomRepo.GetAllRoomsCount();
            return Ok(roomCount);
        }

        /// <summary>
        /// This method gets the count of all free rooms
        /// </summary>
        /// <returns></returns>
        [HttpGet("freeroomscount")]
        public async Task<ActionResult> GetFreeRoomsCount()
        {
            var roomCount = await _roomRepo.GetAllRoomsCount();
            return Ok(roomCount);
        }

        /// <summary>
        /// This method gets the occupant of a room by room number
        /// </summary>
        /// <param name="roomNo"></param>
        /// <returns></returns>
        [HttpGet("getoccupancy")]
        public async Task<ActionResult> GetOccupancy(int roomNo)
        {
            var roomOccupant = await _roomRepo.GetRoomOccupancy(roomNo);
            if (string.IsNullOrEmpty(roomOccupant))
                return Ok("Room has no occupant");
            return Ok(roomOccupant);
        }

    }
}
