using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.Entities
{
    public class ReviewComments
    {
        [Key]
        public int ReviewCommentId { get; set; }
        public required string ReviewCommentContent { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //Foreign key for User Id
        public int UserId { get; set; }
        public required Users Users { get; set; }
        //Foreign key for Review Id
        public int ReviewId { get; set; }
        public required Reviews Reviews { get; set; }
    }
}
