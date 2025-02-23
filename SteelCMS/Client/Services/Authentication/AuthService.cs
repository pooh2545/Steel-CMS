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
                await _localStorage.SetItemAsync("authToken", result.Token);
                return true;
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Login Failed: {error}");
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in LoginAsync: {ex.Message}");
            return false;
        }
    }


    public async Task LogoutAsync()
    {
        await _localStorage.RemoveItemAsync("authToken");
    }
}

public class LoginResponse
{
    public string Token { get; set; }
}
