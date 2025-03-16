public class OrderItem
{
    public int Id { get; set; }
    public int SteelItemId { get; set; }
    public string ItemName { get; set; }
    public decimal Quantity { get; set; }
    public string Unit { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
}