using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingCart.Repository.Entities
{
    public class Offer : BaseEntity
    {
        [Key]
        [Required]
        public string SKU { get; set; }

        [Required]
        public int QuantityRequired { get; set; }

        [Required]
        public decimal? Price { get; set; }


    }
}
