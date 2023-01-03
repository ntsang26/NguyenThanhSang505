namespace NguyenThanhSang505.Models.Process
{
  public class StringProcessNTS505
  {
    public string LowerToUpper(string strInput)
    {
      string upper = "";
      if (strInput != null)
        upper = strInput.ToUpper();
      return upper;
    }
  }
}