using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PeaceHotelAPI.Dtos;
using PeaceHotelAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeaceHotelAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class ClientController : Controller
    {
        private readonly IClientRepo _clientRepo;
        private readonly IRoomRepo _roomRepo;
        private readonly IMapper _mapper;
        private readonly IEmailer _emailer;

        public ClientController(IClientRepo clientRepo, IRoomRepo roomRepo, IMapper mapper, IEmailer emailer)
        {
            _clientRepo = clientRepo;
            _roomRepo = roomRepo;
            _mapper = mapper;
            _emailer = emailer;
        }

        /// <summary>
        /// This methods gets all clients
        /// </summary>
        /// <returns></returns>
        [HttpGet("clients")]
        public async Task<ActionResult<IEnumerable<ClientDisplayDto>>> GetClients()
        {
            var clients = await _clientRepo.GetAllClients();
            return Ok(_mapper.Map<IEnumerable<ClientDisplayDto>>(clients));
        }

        /// <summary>
        /// This method gets clients by id
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        [HttpGet("clients/{clientId}")]
        public async Task<ActionResult<ClientDisplayDto>> GetClientById(int clientId)
        {
            var clients = await _clientRepo.GetClientById(clientId);

            if (clients == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_mapper.Map<ClientDisplayDto>(clients));
            }

        }




        /// <summary>
        /// This methods registers a new client
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>

        [HttpPost("clients")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> RegisterClient(ClientCreateDto client)
        {
            if (await _clientRepo.ClientExists(client.Email))
                return StatusCode(400, new { Error = $"{client.Email} is a registered client already" });

            var _client = await _clientRepo.AddClient(client);

            if (_client == null)
            {
                return StatusCode(500, new { Error = "Could not register client." });
            }
            else
            {
                //send mail to customer
                _emailer.SendEmailToClient(client);

                return StatusCode(201, _mapper.Map<ClientDisplayDto>(_client));
            }


        }

        #region ignore
        ///// <summary>
        ///// This method books a room for a client 
        ///// </summary>
        ///// <param name="bookRoom"></param>
        ///// <returns></returns>
        //[HttpPost("rooms")]
        //public async Task<ActionResult> RegisterRoom(BookRoomDto bookRoom)
        //{
        //    if (!await _clientRepo.ClientExists(bookRoom.Email))
        //        return StatusCode(400, new { Error = "Client has not been registered, kindly register before booking a room" });

        //    if (await _clientRepo.ClientExists(bookRoom.RoomNo, bookRoom.Email))
        //        return StatusCode(400, new { Error = "Client has already booked this room" });

        //    var _bookRoom = await _roomRepo.BookRoom(bookRoom);

        //    if (_bookRoom == null)
        //    {
        //        return StatusCode(500, new { Error = "Could not book room." });
        //    }
        //    else
        //    {
        //        //send mail to admin
        //        _emailer.SendEmailToAdmin(_bookRoom);

        //        return StatusCode(201, _mapper.Map<BookRoomDto>(_bookRoom));
        //    }

        #endregion

        #region old
        // GET: ClientController/Create
        //[HttpPost("clients")]

        //public async Task<ActionResult> RegisterClient(ClientCreateDto client)
        //{
        //    if (await _clientRepo.ClientExists(client.RoomNo, client.Email))
        //        return StatusCode(400, new { Error = "Client has already booked this room" });

        //    var _client = await _clientRepo.AddClient(client);

        //    if (_client == null)
        //    {
        //        return StatusCode(500, new { Error = "Could not add client." });
        //    }
        //    else
        //    {
        //        //send mail to customer
        //        _emailer.SendEmailToClient(client);

        //        //Book room
        //        await _roomRepo.BookRoom(client);

        //        //send mail to admin
        //        _emailer.SendEmailToAdmin(client);

        //        return StatusCode(201, _mapper.Map<ClientDisplayDto>(_client));
        //    }
        #endregion


    }
}

