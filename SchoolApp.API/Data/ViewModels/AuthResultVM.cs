using System;

namespace SchoolApp.API.Data.ViewModels{
 public class AuthResultVM{
  public string Token { get; set; }
  public string RefreshToken { get; set; }
  public DateTime ExpiresAT { get; set; }
 }
}