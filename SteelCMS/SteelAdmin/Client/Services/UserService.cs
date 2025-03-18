using SteelAdmin.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<User>>("api/users");
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<User>($"api/users/{id}");
        }

        public async Task<User> CreateUserAsync(User user)
        {
            var response = await _httpClient.PostAsJsonAsync("api/users", user);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<User>();
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/users/{user.Id}", user);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/users/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<LoginResult> LoginAsync(string username, string password)
        {
            try
            {
                var loginData = new { Username = username, Password = password };
                var content = new StringContent(JsonSerializer.Serialize(loginData), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("api/auth/login", content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<LoginResult>();
                    return result;
                }
                else
                {
                    return new LoginResult { Success = false, Message = "การเข้าสู่ระบบล้มเหลว" };
                }
            }
            catch (Exception ex)
            {
                return new LoginResult { Success = false, Message = $"เกิดข้อผิดพลาด: {ex.Message}" };
            }
        }
    }
