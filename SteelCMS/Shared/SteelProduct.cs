using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("steelproduct")]
public class steelproduct
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int steel_id { get; set; }

    public string steel_name { get; set; }
    public string steel_detail { get; set; }
    public decimal steel_price { get; set; }

    [ForeignKey("SteelType")]  // ✅ เชื่อมไปยัง steeltype
    public int? steeltype_id { get; set; }

    public string img_path { get; set; } = "";

    public steeltype? SteelType { get; set; }  // ✅ Navigation Property
}
