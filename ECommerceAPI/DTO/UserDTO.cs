namespace ECommerceAPI.DTO
{
    public class UserDTO
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Password { get; set; }
        public required int RoleId { get; set; }
        public required string RoleName { get; set; }
    }
}