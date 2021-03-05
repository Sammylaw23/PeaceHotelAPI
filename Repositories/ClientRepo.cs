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
    public class ClientRepo : IClientRepo
    {
        readonly PeaceHotelAPIDbContext _db;
        private readonly IMapper _mapper;
        public ClientRepo(PeaceHotelAPIDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<Client> AddClient(ClientCreateDto client)
        {
            var _client = _mapper.Map<Client>(client);
            _db.Clients.Add(_client);
            int result = await _db.SaveChangesAsync();
            return result > 0 ? _client : null;
        }


        public async Task<IEnumerable<Client>> GetAllClients()
        {
            var clients = await _db.Clients.Include(u => u.Room).ToListAsync();

            return clients;
        }
        public async Task<Client> GetClientById(int clientId)
        {
            return await _db.Clients.Where(u => u.ClientId == clientId).Include(u => u.Room).FirstOrDefaultAsync();
        }

        public async Task UpdateClient(Client client)
        {
            _db.Entry(client).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task DeleteClient(Client client)
        {
            _db.Clients.Remove(client);
            await _db.SaveChangesAsync();
        }

     
        public async Task<bool> ClientExists(int roomNo, string email)
        {
            return await _db.Rooms.AnyAsync(u => u.RoomNo == roomNo && u.RoomOccupant == email);

        }

        public async Task<bool> ClientExists(string email)
        {
            return await _db.Clients.AnyAsync(u=>u.Email == email);

        }

        //public async Task<bool> ClientExists(int clientId)
        //{
        //    return await _db.Clients.AnyAsync(u => u.ClientId == clientId);
        //}



        public Task<Client> BookRoom(int roomNo, Client client)
        {
            throw new NotImplementedException();
        }
    }
}
