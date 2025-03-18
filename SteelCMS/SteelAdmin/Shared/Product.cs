using System.ComponentModel.DataAnnotations;

public class Product
{
    public int Id { get; set; }

    [Required(ErrorMessage = "กรุณาระบุชื่อสินค้า")]
    [StringLength(100, ErrorMessage = "ชื่อสินค้าต้องมีความยาวไม่เกิน 100 ตัวอักษร")]
    public string Name { get; set; }

    [Required(ErrorMessage = "กรุณาระบุคำอธิบายสินค้า")]
    public string Description { get; set; }

    [Required(ErrorMessage = "กรุณาระบุราคาสินค้า")]
    [Range(0.01, 1000000, ErrorMessage = "ราคาต้องมีค่ามากกว่า 0 และไม่เกิน 1,000,000")]
    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    public string ImageUrl { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; }
}