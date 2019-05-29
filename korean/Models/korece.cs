using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace korean.Models
{
    public class korece
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string kelime { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string anlam { get; set; }
        
      

        
    }
}
