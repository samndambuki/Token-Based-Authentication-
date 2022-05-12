using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SchoolApp.API.Data.Helpers;

namespace SchoolkApp.API.Data{
 public class AppDbInitializer{
  public static async Task SeeedRolesToDb(IApplicationBuilder applicationBuilder )
  {
   using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
   {
    var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    if(!await roleManager.RoleExistsAsync(UserRoles.Manager))
    await roleManager.CreateAsync(new IdentityRole(UserRoles.Manager));

    if(!await roleManager.RoleExistsAsync(UserRoles.Student))
    await roleManager.CreateAsync(new IdentityRole(UserRoles.Student));
   }   
  }
 }
}