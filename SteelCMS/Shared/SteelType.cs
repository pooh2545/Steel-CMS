using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("steeltype")]
public class steeltype
{
    [Key] // กำหนดให้เป็น Primary Key
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ✅ ทำให้เป็น Auto-Generated ID
    public int steeltype_id { get; set; }
    public string steeltype_name { get; set; }
}