using Microsoft.EntityFrameworkCore;
using SchoolAPP.API.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SchoolApp.API.Data.Models;

namespace SchoolApp.API.Data{
 public class AppDbContext:IdentityDbContext<ApplicationUser>
 {
  public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
  {
  }
  public DbSet<RefreshToken> RefreshTokens { get; set; }

 }
}