public class SteelItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public string Dimensions { get; set; }
    public string Grade { get; set; }
    public decimal CurrentStock { get; set; }
    public string Unit { get; set; }
    public decimal PricePerUnit { get; set; }
    public string Location { get; set; }
    public decimal ReorderLevel { get; set; }
    public DateTime LastRestockDate { get; set; }
    public string Supplier { get; set; }
    public string Notes { get; set; }
}