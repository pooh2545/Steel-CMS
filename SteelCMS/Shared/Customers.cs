using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("customers")]
public class customers
{
    [Key] // กำหนดให้เป็น Primary Key
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ✅ ทำให้เป็น Auto-Generated ID
    public int row_Id { get; set; }
    public string fullname { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string? tel { get; set; }
}