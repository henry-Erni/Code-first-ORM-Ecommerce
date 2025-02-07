using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Entities
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public required string ProductName { get; set; }
        public int Price { get; set; }
        public int InventoryCount { get; set; }

        public int QuantitySold { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<Reviews>? Reviews { get; set; }
        public ICollection<Likes>? Likes { get; set; }
    }
}
