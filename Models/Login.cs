using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Escape.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Please enter your username")]
        public string UserNameAttempt { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password)]
        public string PasswordAttempt { get; set; }
    }
}