using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.Entities
{
    public class Likes
    {
        [Key]
        public int LikeId { get; set; } 

        public int UserId { get; set; } 
        public required Users User { get; set; }

        public int ProductId { get; set; } 
        public required Products Product { get; set; }

        public DateTime LikedAt { get; set; } 
    }
}