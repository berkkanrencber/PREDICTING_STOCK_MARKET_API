using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PREDICTING_STOCK_MARKET_API.DTO;
using PREDICTING_STOCK_MARKET_API.Models;

namespace PREDICTING_STOCK_MARKET_API.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController: ControllerBase{

    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    private readonly IConfiguration _configuration;

    public UsersController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,IConfiguration configuration){
        _userManager=userManager;
        _signInManager=signInManager;
        _configuration=configuration;
    }

    [HttpPost("register")]
    public async Task<IActionResult> CreateUser(UserDTO model){

        if(!ModelState.IsValid){
            return BadRequest(ModelState);
        }

        var user= new AppUser{
            FullName=model.FullName,
            UserName=model.UserName,
            Email=model.Email,
            DateAdded=DateTime.Now
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        if(result.Succeeded){
            var responseSuccess = new {
                success = true,
                message = "Successfully registered"
            };
            return StatusCode(201, responseSuccess);
        }

        var errors = result.Errors.Select(error => error.Description);
        var errorResponse = new {
            success = false,
            message = errors
        };
        return BadRequest(errorResponse);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginUser(LoginDTO model){

        var user = await _userManager.FindByEmailAsync(model.Email);

        if(user==null){
            return BadRequest(new {message= "The email is wrong!"});
        }


        var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password,false);

        if(result.Succeeded){
            var responseSuccess = new {
                success = true,
                message = GenerateJWT(user)
            };
            return Ok(responseSuccess); // This code will be changed later.
        }
        return Unauthorized();
    }

    private object GenerateJWT(AppUser user)
    {
        var tokenHandler= new JwtSecurityTokenHandler();
        var key= Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Secret").Value ?? "");
        var tokenDescriptor= new SecurityTokenDescriptor{
            Subject = new ClaimsIdentity(
                new Claim[] {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName ?? "")
                }
            ),
            Expires = DateTime.UtcNow.AddDays(1), // It will be finished after 1 day later.
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature),
            Issuer = "PREDICTING_STOCK_MARKET_API"
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}