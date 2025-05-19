using System;
using System.ComponentModel.DataAnnotations;

namespace eUseControl.Domain.Entities.User
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Username or Email is required")]
        public string Credential { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
} 