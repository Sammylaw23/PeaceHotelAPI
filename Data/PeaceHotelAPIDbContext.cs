using Microsoft.EntityFrameworkCore;
using PeaceHotelAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeaceHotelAPI.Data
{
    public class PeaceHotelAPIDbContext: DbContext
    {
        public PeaceHotelAPIDbContext(DbContextOptions<PeaceHotelAPIDbContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}
