using System.ComponentModel.DataAnnotations;

namespace NguyenThanhSang505 
{
  public class NTS505 
  {
    [Key]
    [MaxLength(20)]
    public string NTSId {get; set;}
    [MaxLength(50)]
    public string NTSName {get; set;}
    public Boolean NTSGender {get; set;}
  }
}