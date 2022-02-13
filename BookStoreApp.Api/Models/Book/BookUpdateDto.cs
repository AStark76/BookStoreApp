﻿using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.Api.Models.Book
{
    public class BookUpdateDto : BaseDto
    {
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        [Range(1500, int.MaxValue)]
        public int Year { get; set; }
        [Required]
        [StringLength(50)]
        public string Isbn { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 10)]
        public string Summary { get; set; }

        public string Image { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }
    }
}
