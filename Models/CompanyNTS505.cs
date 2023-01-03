using System.ComponentModel.DataAnnotations;

namespace NguyenThanhSang505
{
  public class CompanyNTS505 {
    [Key]
    [MaxLength(20)]
    public string CompanyId {get; set;}
    [MaxLength(50)]
    public string CompanyName {get; set;}
  }
}