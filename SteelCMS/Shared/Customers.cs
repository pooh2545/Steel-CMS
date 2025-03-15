using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("customers")]
public class customers
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int row_Id { get; set; }

    public string fullname { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string? tel { get; set; }
    public string? img_path { get; set; }

    // 🔗 Relation: ลูกค้าคนหนึ่งมีหลายคำสั่งซื้อ
    public List<order> Orders { get; set; } = new List<order>();
}