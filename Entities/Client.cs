using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PeaceHotelAPI.Entities
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required]
        public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public int RoomNo { get; set; }
        public virtual Room Room { get; set; }
        public DateTime DateCheckedIn { get; set; }
        public DateTime? DateCheckedOut { get; set; }

    }


      

}
