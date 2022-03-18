using App.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers.Identity
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="signInManager"></param>
        /// <param name="userManager"></param>
        /// <param name="logger"></param>
        /// <param name="configuration"></param>
        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager,
            ILogger<AccountController> logger, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] App.DTO.Login dto)
        {
            var appUser = await _userManager.FindByEmailAsync(dto.Email);
            // TODO: wait a random time here to fool timing attacks
            if (appUser == null)
            {
                _logger.LogWarning("WebApi login failed. User {User} not found", dto.Email);
                return NotFound(new App.DTO.Message("User/Password problem!"));
            }

            var result = await _signInManager.CheckPasswordSignInAsync(appUser, dto.Password, false);
            if (result.Succeeded)
            {
                var claimsPrincipal = await _signInManager.CreateUserPrincipalAsync(appUser);
                var jwt = Base.Extensions.IdentityExtensions.GenerateJwt(
                    claimsPrincipal.Claims,
                    _configuration["JWT:Key"],                    
                    _configuration["JWT:Issuer"],
                    _configuration["JWT:Issuer"],
                    DateTime.Now.AddDays(_configuration.GetValue<int>("JWT:ExpireDays"))
                    );
                _logger.LogInformation("WebApi login. User {User}", dto.Email);
                return Ok(new App.DTO.JwtResponse()
                {
                    Token = jwt,
                    Firstname = appUser.FirstName,
                    Lastname = appUser.LastName,
                });
            }
            
            _logger.LogWarning("WebApi login failed. User {User} - bad password", dto.Email);
            Console.WriteLine("!!!");
            return NotFound(new App.DTO.Message("User/Password problem!"));
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] App.DTO.Register dto)
        {
            var appUser = await _userManager.FindByEmailAsync(dto.Email);
            if (appUser != null)
            {
                _logger.LogWarning(" User {User} already registered", dto.Email);
                return BadRequest(new App.DTO.Message("User already registered"));
            }

            appUser = new App.Domain.Identity.AppUser()
            {
                Email = dto.Email,
                UserName = dto.Email,
                FirstName = dto.Firstname,
                LastName = dto.Lastname,
            };
            var result = await _userManager.CreateAsync(appUser, dto.Password);
            
            if (result.Succeeded)
            {
                _logger.LogInformation("User {Email} created a new account with password", appUser.Email);
                
                var user = await _userManager.FindByEmailAsync(appUser.Email);
                if (user != null)
                {                
                    var claimsPrincipal = await _signInManager.CreateUserPrincipalAsync(user);
                    var jwt =Base. Extensions.IdentityExtensions.GenerateJwt(
                        claimsPrincipal.Claims,
                        _configuration["JWT:Key"],                    
                        _configuration["JWT:Issuer"],
                        _configuration["JWT:Issuer"],
                        DateTime.Now.AddDays(_configuration.GetValue<int>("JWT:ExpireDays"))
                    );
                    _logger.LogInformation("WebApi login. User {User}", dto.Email);
                    return Ok(new App.DTO.JwtResponse()
                    {
                        Token = jwt,
                        Firstname = appUser.FirstName,
                        Lastname = appUser.LastName,
                    });
                    
                }
                else
                {
                    _logger.LogInformation("User {Email} not found after creation", appUser.Email);
                    return BadRequest(new App.DTO.Message("User not found after creation!"));
                }
            }
            
            var errors = result.Errors.Select(error => error.Description).ToList();
            return BadRequest(new App.DTO.Message() {Messages = errors});
        }

    }
}