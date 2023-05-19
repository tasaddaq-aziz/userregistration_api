using LoggerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserRegistrationAPI.Entities.Models;
using UserRegistrationAPI.Entities.ViewModels;
using UserRegistrationAPI.Helpers;
using UserRegistrationAPI.Service.IService;

namespace UserRegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IConfiguration configuration;
        private IUserService userService;
        private readonly ILoggerManager logger;

        public UserController(IUserService _userService, ILoggerManager _logger)
        {
            userService = _userService;
            logger = _logger;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserViewModel _user)
        {
            try
            {
                if (_user == null)
                    return Ok(new { message = "error", status = 0 });

                if (ModelState.IsValid)
                {
                    if (CheckEmailExists(_user.Email))
                        return Ok(new { message = "Email Already Exist!", status = 0 });

                    User newUser = new User();
                    newUser.FRST_NAME = _user.FirstName;
                    newUser.LAST_NAME = _user.LastName;
                    newUser.EMAL = _user.Email;
                    newUser.PWRD = PasswordHasher.PasswordEncrypt(_user.Password);
                    userService.CreateUser(newUser);
                    return Ok(new { message = "Registration Success!", status = 1 });
                }
                else
                {
                    string[] errorMsg = ModelState.Select(x => x.Value.Errors.Select(y => y.ErrorMessage)).First().ToArray();
                    return Ok(new { message = errorMsg[0], status = 0 });
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex);
                return Ok(new { message = "error", status = 0 });
            }
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserLoginViewModel _user)
        {
            try
            {
                if (_user == null)
                    return Ok(new { message = "error", status = 0 });
                if (CheckEmailExists(_user.Email))
                {
                    var user = userService.GetByEmailAndPassword(_user.Email, PasswordHasher.PasswordEncrypt(_user.Password), true);
                    if (user == null)
                        return Ok(new { message = "Password is Incorrect!", status = 0 });
                    else
                    {
                        user.TOKN = GenerateToken(user);
                        return Ok(new { message = "Login Success!", token = user.TOKN, status = 1 });
                    }
                }
                else
                {
                    return Ok(new { message = "Email not Found!", status = 0 });
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex);
                return Ok(new { message = "error", status = 0 });
            }
        }
        #region Helper Methods
        private bool CheckEmailExists(string _email)
        {
            var user = userService.GetByEmail(_email, true);
            if (user != null)
                return true;
            else
                return false;
        }

        public string GenerateToken(User _user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("SecretKeyJWTTASDDAQ");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, string.Concat(_user.FRST_NAME," ",_user.LAST_NAME)),
                new Claim(ClaimTypes.Email, _user.EMAL),
                new Claim(ClaimTypes.PrimarySid,Convert.ToString(_user.USER_ID)),
                new Claim(ClaimTypes.Role,"E")
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        #endregion
    }
}
