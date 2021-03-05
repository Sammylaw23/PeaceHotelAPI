﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeaceHotelAPI.Dtos
{
    public class ClientCreateDto
    {
       
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNo { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

      
        //public DateTime DateCheckedIn { get; set; } = DateTime.Now

    }
}
