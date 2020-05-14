using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Models
{
    public class ClientCategory
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "This Field is required")]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "Only Accepts 1 to 500 characters" )]
        public string CategoryName { get; set; }

        public bool Active { get; set; }
    }
}
