using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("steeltype")]
public class steeltype
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int steeltype_id { get; set; }

    public string steeltype_name { get; set; }

    public List<steelproduct> SteelProducts { get; set; } = new List<steelproduct>();
}
