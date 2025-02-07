using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.Entities
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<Reviews>? Reviews { get; set; }
        public ICollection<ReviewComments>? ReviewComments { get; set; }
        public ICollection<Likes>? Likes { get; set; }

        //Foreign key for Role Id
        public int RoleId { get; set; }
        public Roles? Role { get; set; }
    }
}
