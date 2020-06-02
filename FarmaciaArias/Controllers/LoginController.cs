using Datos;
using Entity;
using Logica;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using FarmaciaArias.Config;
using FarmaciaArias.Models;

namespace FarmaciaArias.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        ProductosContext _context;
        UserService _userService;
        JwtService _jwtService;
        public LoginController(ProductosContext context, IOptions<AppSetting> appSettings)
        {
            _context = context;
            var admin = _context.Users.Find("admin");
            if (admin == null) 
            {
                _context.Users.Add(new User() 
                { 
                    UserName="admin", 
                    Password="admin", 
                    Email="admin@gmail.com", 
                    Estado="AC", 
                    FirstName="Adminitrador", 
                    LastName="", 
                    MobilePhone="31800000000"}
                );
                var registrosGuardados=_context.SaveChanges();
            }
            _userService = new UserService(context);
            _jwtService = new JwtService(appSettings);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(LoginInputModel model)
        {
            var user = _userService.Validate(model.Username, model.Password);
            if (user == null) return BadRequest("Username or password is incorrect");
            var response= _jwtService.GenerateToken(user);
            return Ok(response);
        }
    }
    
}