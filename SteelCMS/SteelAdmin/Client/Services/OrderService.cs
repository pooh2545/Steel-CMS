using SteelAdmin.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Order>>("api/orders");
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Order>($"api/orders/{id}");
        }

        public async Task<bool> UpdateOrderStatusAsync(int id, string status)
        {
            var statusData = new { Status = status };
            var content = new StringContent(JsonSerializer.Serialize(statusData), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"api/orders/{id}/status", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdatePaymentStatusAsync(int id, string status)
        {
            var statusData = new { Status = status };
            var content = new StringContent(JsonSerializer.Serialize(statusData), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"api/orders/{id}/payment-status", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UploadPaymentEvidenceAsync(int id, string evidenceUrl)
        {
            var evidenceData = new { EvidenceUrl = evidenceUrl };
            var content = new StringContent(JsonSerializer.Serialize(evidenceData), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"api/orders/{id}/evidence", content);
            return response.IsSuccessStatusCode;
        }
    }
