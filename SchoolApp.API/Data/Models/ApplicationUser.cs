using Microsoft.AspNetCore.Identity;

namespace SchoolAPP.API.Data.Models{
 public class ApplicationUser:IdentityUser
 {
  public string  Firstname { get; set; }
  public string  LastName { get; set; }
  public string Custom { get; set; }

  



 }
}