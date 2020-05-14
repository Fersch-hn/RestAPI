using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Models.DTO
{
    public class CategoriesDTO
    {
       
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public bool Active { get; set; }

        public CategoriesDTO(ClientCategory category)
        {
            CategoryId = category.CategoryId;
            CategoryName = category.CategoryName;
            Active = category.Active;
        }
    }
}
