using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
 public class ReportService : IReportService
    {
        private readonly HttpClient _httpClient;

        public ReportService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<SalesReportData> GetSalesReportAsync(string period)
        {
            return await _httpClient.GetFromJsonAsync<SalesReportData>($"api/reports/sales?period={period}");
        }

        public async Task<List<OrdersByStatusData>> GetOrdersByStatusAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<OrdersByStatusData>>("api/reports/orders-by-status");
        }

        public async Task<List<ProductSalesData>> GetTopProductsAsync(int count)
        {
            return await _httpClient.GetFromJsonAsync<List<ProductSalesData>>($"api/reports/top-products?count={count}");
        }

        public async Task<RevenueComparisonData> GetRevenueComparisonAsync(string period)
        {
            return await _httpClient.GetFromJsonAsync<RevenueComparisonData>($"api/reports/revenue-comparison?period={period}");
        }
    }
