using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SchoolApp.API.Data;
using SchoolApp.API.Data.ViewModels;
using SchoolAPP.API.Data.Models;

namespace SchoolApp.API.Controllers{
 [Route("api/[controller]")]
 [ApiController]
 public class AuthenticationController : ControllerBase
 {
  private readonly UserManager<ApplicationUser> _userManager;
  private readonly RoleManager<IdentityRole> _roleManager;
  private readonly AppDbContext _context;
  private readonly IConfiguration _configuration;

  public AuthenticationController(UserManager<ApplicationUser> userManager,
  RoleManager<IdentityRole> roleManager,
  AppDbContext context,
  IConfiguration configuration
  )
  {
   _userManager = userManager;
   _roleManager = roleManager;
   _context = context;
   _configuration = configuration;
  }

  [HttpPost("register-user")]
  public async Task<IActionResult>Register([FromBody]RegisterVM registerVM)
  {
   if(!ModelState.IsValid){
    return BadRequest("Please,provide all the required fields");
   }
   //check if user exists in database
   var userExists = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
   if(userExists != null){
    return BadRequest($"User{registerVM.EmailAddress} already exists");
   }
   ApplicationUser newUser = new ApplicationUser(){
    Firstname = registerVM.FirstName,
    LastName = registerVM.LastName,
    Email = registerVM.EmailAddress,
    UserName = registerVM.UserName,
    SecurityStamp = Guid.NewGuid().ToString()
   };
   var result = await _userManager.CreateAsync(newUser,registerVM.Password);
   if(result.Succeeded) return Ok("User Created ");
   return BadRequest("User could not be created");
  }
 }
}