﻿using System.ComponentModel.DataAnnotations;

namespace CatsTagram.Features.Identity.Models
{
    public class RegisterRequestModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
