using System;
using Blazored.LocalStorage;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class AuthService
{
    private readonly HttpClient _http;
    private readonly ILocalStorageService _localStorage;

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
                    Console.WriteLine("Token saved successfully");
                    return true;
                }
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Login Failed: {error}");
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
        try
        {
            // ถ้ามี API logout ให้เรียกก่อน เช่น await _http.PostAsync("api/Auth/logout", null);

            await _localStorage.RemoveItemAsync("authToken");
            Console.WriteLine("User logged out");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during logout: {ex.Message}");
        }
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
