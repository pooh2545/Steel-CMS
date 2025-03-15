using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("order")]
public class order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int order_id { get; set; }  // ✅ เปลี่ยนจาก `steel_id` เป็น `order_id` เพื่อความชัดเจน

    [ForeignKey("Customer")]
    public int customer_id { get; set; }

    public string address_id { get; set; }
    public decimal order_total { get; set; }
    public string slip_path { get; set; } = "";
    public int status_id { get; set; }
    public DateTime created_at { get; set; }
    public string tracking_number { get; set; }
    public int status { get; set; }
    public DateTime confirm_at { get; set; }
    public DateTime pay_at { get; set; }
    public DateTime verify_at { get; set; }
    public DateTime transit_at { get; set; }
    public DateTime delivery_at { get; set; }
    public DateTime prepare_at { get; set; }

    // 🔗 Relation: คำสั่งซื้อนี้เป็นของลูกค้า
    public customers Customer { get; set; }

    // 🔗 Relation: 1 Order มีหลาย OrderItems
    public List<order_items> OrderItems { get; set; } = new List<order_items>();
}