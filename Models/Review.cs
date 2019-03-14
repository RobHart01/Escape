using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Escape.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        [Required(ErrorMessage = "Please enter a rating")]
        public int ResponsiveRating { get; set; }
        public string ResponsiveDescription { get; set; }
        [Required(ErrorMessage = "Please enter a rating")]
        public int UserFriendlyRating { get; set; }
        public string UserFriendlyDescription { get; set; }
        [Required(ErrorMessage = "Please enter a rating")]
        public int UserExperienceRating { get; set; }
        public string UserExperienceDescription { get; set; }
        [Required(ErrorMessage = "Please enter a rating")]
        public int DesignRating { get; set; }
        public string DesignDescription { get; set; }
        [NotMapped]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}