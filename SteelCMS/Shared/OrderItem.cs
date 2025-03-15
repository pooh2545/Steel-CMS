using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("order_items")]
public class order_items
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int row_id { get; set; }

    [ForeignKey("Order")]
    public int order_id { get; set; }

    [ForeignKey("SteelProduct")]
    public int steel_id { get; set; }

    public int item_seq { get; set; }
    public int amount { get; set; }
    public decimal price_per_unit { get; set; }
    public decimal item_total { get; set; }

    // 🔗 Relation: OrderItems อยู่ใน Order ใด
    public order Order { get; set; }

    // 🔗 Relation: OrderItems มีสินค้าเป็น SteelProduct
    public steelproduct SteelProduct { get; set; }
}