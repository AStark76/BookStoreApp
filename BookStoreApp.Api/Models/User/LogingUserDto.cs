﻿using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.Api.Models.User
{
    public class LogingUserDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
