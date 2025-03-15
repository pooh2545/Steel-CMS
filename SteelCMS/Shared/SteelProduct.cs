using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("steelproduct")]
public class steelproduct
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int steel_id { get; set; }

    [Required]
    public string steel_name { get; set; }

    public string steel_detail { get; set; }

    [Required]
    public decimal steel_price { get; set; }

    // ✅ Foreign Key เชื่อมไปยัง steeltype
    [ForeignKey("SteelType")]
    public int? steeltype_id { get; set; }

    public string img_path { get; set; } = "";

    // ✅ Navigation Property เชื่อมไปยัง steeltype
    public steeltype? SteelType { get; set; }
}