﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Path { get; set; }
    }
}
