using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("employee")]
public class employee
{
    [Key] // กำหนดให้เป็น Primary Key
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ✅ ทำให้เป็น Auto-Generated ID
    public int row_Id { get; set; }
    public string emp_name { get; set; }
    public string emp_email { get; set; }
    public string emp_pass { get; set; }
    public int? position_id { get; set; }
}