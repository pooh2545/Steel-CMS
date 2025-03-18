using System.ComponentModel.DataAnnotations;

public class Order
{
    public int Id { get; set; }

    [Required]
    public string CustomerName { get; set; }

    [Required]
    [EmailAddress]
    public string CustomerEmail { get; set; }

    [Required]
    public string CustomerPhone { get; set; }

    [Required]
    public string ShippingAddress { get; set; }

    public decimal TotalAmount { get; set; }

    public string PaymentStatus { get; set; } // Pending, Completed, Failed

    public string OrderStatus { get; set; } // New, Processing, Shipped, Delivered, Cancelled

    public string PaymentMethod { get; set; }

    public string TransactionId { get; set; }

    public string PaymentEvidence { get; set; } // URL to payment slip image

    public List<OrderItem> Items { get; set; } = new List<OrderItem>();

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; }

    public string UpdatedBy { get; set; }
}