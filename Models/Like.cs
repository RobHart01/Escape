using System;
using System.ComponentModel.DataAnnotations;

namespace Escape.Models
{
    public class Like
    {
        [Key]
        public int LikeId { get; set; }
        public int UserId { get; set; }
        public User Likers {get;set;}
        public int ArticleId { get; set; }
        public Article Articles { get; set; }
    }
}