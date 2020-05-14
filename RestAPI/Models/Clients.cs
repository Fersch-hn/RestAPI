using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Models
{
    public class Clients
    {
        [Key]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "This Field is required")]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "Only Accepts 1 to 500 characters")]
        public string ClientName { get; set; }
        
        [Required(ErrorMessage = "This Field is required")]
        [EmailAddress(ErrorMessage = "It is not a valid mail")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "This Field is required")]
        [Phone(ErrorMessage = "It is not a valiud number")]
        public string PhoneNumber { get; set; }
        
        public DateTime RegisteredDate { get; set; }
        
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual ClientCategory ClientCategory { get; set; }
    }
}
