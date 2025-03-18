using SteelAdmin.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

    public interface IUserService
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(User user);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int id);
        Task<LoginResult> LoginAsync(string username, string password);
    }

    public class LoginResult
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
        public string Message { get; set; }
    }
