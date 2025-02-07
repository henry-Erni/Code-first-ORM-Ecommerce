using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.Entities
{
    public class Roles
    {
        [Key]
        public int RoleId { get; set; }
        public required string RoleName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public  ICollection<Users>? Users { get; set; }
    }
}
