﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ShoppingKart.Repository.Entities
{
    public class Product : BaseEntity
    {
        [Required]
        public string SKU { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal? Price { get; set; }

    }
}
