using SteelAdmin.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Product>>("api/products");
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Product>($"api/products/{id}");
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            var response = await _httpClient.PostAsJsonAsync("api/products", product);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Product>();
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/products/{product.Id}", product);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/products/{id}");
            return response.IsSuccessStatusCode;
        }
    }
