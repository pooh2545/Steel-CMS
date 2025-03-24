// Models/ProductModel.cs
using System.ComponentModel.DataAnnotations;

    public class ProductModel
    {
        public int Id { get; set; } = 0;

        [Required(ErrorMessage = "กรุณาระบุรหัสสินค้า")]
        public string ProductCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "กรุณาระบุชื่อสินค้า")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "กรุณาเลือกประเภท")]
        public string Category { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "กรุณาระบุราคา")]
        [Range(0.01, 9999999.99, ErrorMessage = "ราคาต้องมากกว่า 0")]
        public decimal Price { get; set; } = 0;

        [Required(ErrorMessage = "กรุณาระบุจำนวนคงเหลือ")]
        [Range(0, 9999999, ErrorMessage = "จำนวนต้องไม่น้อยกว่า 0")]
        public decimal Stock { get; set; } = 0;

        [Required(ErrorMessage = "กรุณาระบุหน่วย")]
        public string Unit { get; set; } = "ชิ้น";

        public bool IsActive { get; set; } = true;
    }
