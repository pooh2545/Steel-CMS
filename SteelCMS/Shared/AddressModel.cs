using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


public class AddressModel
{
    public string FullName { get; set; }
    public string Phone { get; set; }
    public string AddressText { get; set; }
    public string Province { get; set; }
    public string District { get; set; }
    public string SubDistrict { get; set; }
    public string ZipCode { get; set; }
}