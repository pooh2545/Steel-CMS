using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("cart")]
public class cart
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int row_id { get; set; }

    [ForeignKey("Customer")]
    public int customer_id { get; set; }

    [ForeignKey("SteelProduct")]
    public int steel_id { get; set; }
    public int amount { get; set; }

    // 🔗 Relation: เชื่อมกับ customers
    public customers Customer { get; set; }

    // 🔗 Relation: เชื่อมกับ steelproduct
    public steelproduct SteelProduct { get; set; }
}