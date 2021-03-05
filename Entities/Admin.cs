using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PeaceHotelAPI.Entities
{
    public class Admin
    {
        public int AdminId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }

        //public virtual ICollection<Room> Rooms { get; set; }

    }

}
