using SteelAdmin.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IOrderService
{
    Task<List<Order>> GetOrdersAsync();
    Task<Order> GetOrderByIdAsync(int id);
    Task<bool> UpdateOrderStatusAsync(int id, string status);
    Task<bool> UpdatePaymentStatusAsync(int id, string status);
    Task<bool> UploadPaymentEvidenceAsync(int id, string evidenceUrl);
}
