using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingCart.Repository.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        [Required]
        public  bool? IsActive { get; set; }

        [Required]
        public DateTime? DateCreated { get; set; }
    }
}
