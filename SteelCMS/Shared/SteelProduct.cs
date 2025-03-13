using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("steelproduct")]
public class steelproduct
{
    [Key] // กำหนดให้เป็น Primary Key
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ✅ ทำให้เป็น Auto-Generated ID
    public int steel_id { get; set; }
    public string steel_name { get; set; }
    public string steel_detail { get; set; }
    public decimal steel_price { get; set; }
    public int steeltype_id { get; set; }
    public string img_path { get; set; } = "";
}