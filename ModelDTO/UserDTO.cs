namespace InventoryManagement.ModelDTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string FristName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public int RoleId { get; set; }
    }
}
