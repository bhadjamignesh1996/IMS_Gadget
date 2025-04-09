

namespace IMS_Gadget.ServerModel
{
    public class UsersServerModel : BaseServerModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string? FullName { get; set; }

        public string Role { get; set; } = "User";

        public bool IsActive { get; set; } = true;
    }
}
