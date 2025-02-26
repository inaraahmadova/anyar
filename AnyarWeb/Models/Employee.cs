﻿using System.ComponentModel.DataAnnotations;

namespace AnyarWeb.Models
{
    public class Employee:BaseEntity
    {
        public int Id { get; set; }
        [MaxLength(32), Required]
        public string Name { get; set; }
        [MaxLength(64), Required]
        public string Subtitle { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}
