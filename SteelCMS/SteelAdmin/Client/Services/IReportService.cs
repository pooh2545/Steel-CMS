using System.Collections.Generic;
using System.Threading.Tasks;

public interface IReportService
    {
        Task<SalesReportData> GetSalesReportAsync(string period);
        Task<List<OrdersByStatusData>> GetOrdersByStatusAsync();
        Task<List<ProductSalesData>> GetTopProductsAsync(int count);
        Task<RevenueComparisonData> GetRevenueComparisonAsync(string period);
    }

    public class SalesReportData
    {
        public SalesSummary Summary { get; set; }
        public List<TopProductSales> TopProducts { get; set; }
        public List<ChartDataPoint> ChartData { get; set; }
    }

    public class SalesSummary
    {
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public int TotalProducts { get; set; }
        public decimal AverageOrderValue { get; set; }
    }

    public class TopProductSales
    {
        public string Name { get; set; }
        public int QuantitySold { get; set; }
        public decimal Revenue { get; set; }
    }

    public class ChartDataPoint
    {
        public string Label { get; set; }
        public decimal Value { get; set; }
    }

    public class OrdersByStatusData
    {
        public string Status { get; set; }
        public int Count { get; set; }
    }

    public class ProductSalesData
    {
        public string ProductName { get; set; }
        public int QuantitySold { get; set; }
        public decimal Revenue { get; set; }
    }

    public class RevenueComparisonData
    {
        public string Period { get; set; }
        public decimal CurrentRevenue { get; set; }
        public decimal PreviousRevenue { get; set; }
        public decimal PercentageChange { get; set; }
    }