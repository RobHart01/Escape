using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Escape.Models
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }

        [Required(ErrorMessage = "Please enter a title")]
        public string title { get; set; }

        [Required(ErrorMessage = "Please enter a sub title")]
        public string subtitle { get; set; }

        public string image { get;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please create a password")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters or longer")]
        public string Password { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Pleae enter your password again")]
        [MinLength(8, ErrorMessage = "Invalid")]
        [Compare("Password")]
        public string Confirm { get; set; }
        public bool Admin { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}