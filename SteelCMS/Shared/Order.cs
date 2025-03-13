using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("order")]
public class order
{
    [Key] // กำหนดให้เป็น Primary Key
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ✅ ทำให้เป็น Auto-Generated ID
    public int steel_id { get; set; }
    public string customer_id { get; set; }
    public string address_id { get; set; }
    public decimal order_total { get; set; }
    public int steeltype_id { get; set; }
    public string slip_path { get; set; } = "";
    public int status_id { get; set; }
    public DateTime created_at { get; set; }
    public string tracking_number { get; set; }
    public bool status { get; set; }
    public DateTime comfirm_at { get; set; }
    public DateTime pay_at { get; set; }
    public DateTime verify_at { get; set; }
    public DateTime transit_at { get; set; }
    public DateTime delivery_at { get; set; }
    public DateTime prepare_at { get; set; }
}