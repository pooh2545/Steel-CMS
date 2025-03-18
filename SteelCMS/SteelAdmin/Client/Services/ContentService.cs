using SteelAdmin.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

   public class ContentService : IContentService
    {
        private readonly HttpClient _httpClient;

        public ContentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // บทความ
        public async Task<List<Article>> GetArticlesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Article>>("api/articles");
        }

        public async Task<Article> GetArticleByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Article>($"api/articles/{id}");
        }

        public async Task<Article> CreateArticleAsync(Article article)
        {
            var response = await _httpClient.PostAsJsonAsync("api/articles", article);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Article>();
        }

        public async Task<bool> UpdateArticleAsync(Article article)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/articles/{article.Id}", article);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteArticleAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/articles/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> PublishArticleAsync(int id)
        {
            var response = await _httpClient.PutAsync($"api/articles/{id}/publish", null);
            return response.IsSuccessStatusCode;
        }

        // ผลงาน (Portfolio)
        public async Task<List<Portfolio>> GetPortfoliosAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Portfolio>>("api/portfolios");
        }

        public async Task<Portfolio> GetPortfolioByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Portfolio>($"api/portfolios/{id}");
        }

        public async Task<Portfolio> CreatePortfolioAsync(Portfolio portfolio)
        {
            var response = await _httpClient.PostAsJsonAsync("api/portfolios", portfolio);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Portfolio>();
        }

        public async Task<bool> UpdatePortfolioAsync(Portfolio portfolio)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/portfolios/{portfolio.Id}", portfolio);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeletePortfolioAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/portfolios/{id}");
            return response.IsSuccessStatusCode;
        }
    }
