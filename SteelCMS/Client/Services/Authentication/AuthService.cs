using System;
using Blazored.LocalStorage;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;

public class AuthService
{
    private readonly HttpClient _http;
    private readonly ILocalStorageService _localStorage;

    // ✅ Event สำหรับแจ้งเตือน Blazor ว่า Login/Logout เปลี่ยน
    public event Action? OnAuthStateChanged;

    public AuthService(HttpClient http, ILocalStorageService localStorage)
    {
        _http = http;
        _localStorage = localStorage;
    }

    public async Task<bool> LoginAsync(string email, string password)
    {
        try
        {
            var response = await _http.PostAsJsonAsync("api/Auth/login", new { Email = email, Password = password });

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<LoginResponse>();

                if (!string.IsNullOrEmpty(result?.Token))
                {
                    await _localStorage.SetItemAsync("authToken", result.Token);

                    // ✅ แจ้งเตือน Blazor ว่ามีการล็อกอินแล้ว
                    OnAuthStateChanged?.Invoke();

                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in LoginAsync: {ex.Message}");
        }

        return false;
    }

    public async Task LogoutAsync()
    {
        await _localStorage.RemoveItemAsync("authToken");

        // ✅ แจ้ง Blazor ว่ามีการล็อกเอาต์
        OnAuthStateChanged?.Invoke();
    }

    public async Task<string> GetUserNameAsync()
    {
        var token = await _localStorage.GetItemAsync<string>("authToken");

        if (string.IsNullOrEmpty(token))
            return "";

        return GetUserNameFromToken(token);
    }

    private string GetUserNameFromToken(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        var claim = jwtToken.Claims.FirstOrDefault(c => c.Type == "fullname"); // ✅ เปลี่ยนเป็น Claim ที่ใช้จริง

        return claim?.Value ?? "";
    }

    public async Task<bool> IsUserLoggedIn()
    {
        var token = await _localStorage.GetItemAsync<string>("authToken");
        return !string.IsNullOrEmpty(token);
    }
}


public class LoginResponse
{
    public string Token { get; set; }
}
