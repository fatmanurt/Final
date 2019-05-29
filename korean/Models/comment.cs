using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace korean.Models
{
    public class comment
    {
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string UserFullName { get; set; }
        [Required]
        [StringLength(1000)]
        public string Content { get; set; }

        public int? ParentCommentId { get; set; }
        public DateTime CreatedDate { get; set; }
        


        [ForeignKey("ParentCommentId")]
        public comment ParentComment { get; set; }
    }
}
