public class Order
{
    public string OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public string CustomerName { get; set; }
    public string CustomerContact { get; set; }
    public string DeliveryAddress { get; set; }
    public DateTime EstimatedDeliveryDate { get; set; }
    public string Status { get; set; }
    public string PaymentStatus { get; set; }
    public decimal TotalAmount { get; set; }
    public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    public string Notes { get; set; }
}