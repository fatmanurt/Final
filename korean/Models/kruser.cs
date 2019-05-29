﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace korean.Models
{
    public class kruser : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }


        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

    }
}
