using SteelAdmin.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;
public interface IContentService
    {
        // บทความ
        Task<List<Article>> GetArticlesAsync();
        Task<Article> GetArticleByIdAsync(int id);
        Task<Article> CreateArticleAsync(Article article);
        Task<bool> UpdateArticleAsync(Article article);
        Task<bool> DeleteArticleAsync(int id);
        Task<bool> PublishArticleAsync(int id);

        // ผลงาน (Portfolio)
        Task<List<Portfolio>> GetPortfoliosAsync();
        Task<Portfolio> GetPortfolioByIdAsync(int id);
        Task<Portfolio> CreatePortfolioAsync(Portfolio portfolio);
        Task<bool> UpdatePortfolioAsync(Portfolio portfolio);
        Task<bool> DeletePortfolioAsync(int id);
    }