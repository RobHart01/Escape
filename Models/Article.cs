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
        [Required(ErrorMessage = "Please enter an image")]
        public string image { get; set; }

        [Required(ErrorMessage = "Please enter a title")]
        public string title { get; set; }

        [Required(ErrorMessage = "Please enter a sub title")]
        public string subtitle { get; set; }

        [Required(ErrorMessage = "Please enter the body")]
        public string body { get; set; }
        [NotMapped]
        public int CreatorId { get; set; }
        public User Creator { get; set; }
        public 
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}