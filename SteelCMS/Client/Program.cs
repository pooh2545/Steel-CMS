using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using SteelCMS.Client;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddSingleton<CartService>();

// Register HttpClient for API calls
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7178/") });
builder.Services.AddBlazoredLocalStorage();
// Register AuthService in Dependency Injection (DI)
builder.Services.AddScoped<AuthService>();

await builder.Build().RunAsync();
