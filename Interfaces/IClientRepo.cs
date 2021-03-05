using PeaceHotelAPI.Dtos;
using PeaceHotelAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeaceHotelAPI.Interfaces
{
    public interface IClientRepo
    {
        Task<Client> AddClient(ClientCreateDto client);

        Task<Client> GetClientById(int clientId);

        Task<IEnumerable<Client>> GetAllClients();
        Task UpdateClient(Client client);
        Task<bool> ClientExists(int roomNo, string email);
        Task<bool> ClientExists(string email);

    }
}
