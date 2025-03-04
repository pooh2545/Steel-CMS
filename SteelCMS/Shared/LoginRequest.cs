namespace SteelCMS.Shared
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; } // ควรเก็บรหัสผ่านแบบ Hash
        public string Role { get; set; } // เช่น "Admin" หรือ "User"
    }

}
