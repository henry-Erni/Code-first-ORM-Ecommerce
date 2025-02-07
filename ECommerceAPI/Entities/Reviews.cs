

using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.Entities
{
    public class Reviews
    {
        [Key]
        public int ReviewId { get; set; }
        public required string ReviewContent { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        //Foreign key for User Id
        public int UserId { get; set; }
        public required Users Users { get; set; }

        //Foreign key for Product Id
        public int ProductId { get; set; }
        public required Products Products { get; set; }

        public ICollection<ReviewComments>? ReviewComments { get; set; }
    }
}
