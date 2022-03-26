using Microsoft.AspNetCore.Identity;

namespace WebApp.ApiControllers.Identity;
/// <summary>
/// Api endpoint for registering new user and user log-in (jwt token generation)
/// </summary>
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IConfiguration _configuration;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager,
            ILogger<AccountController> logger, IConfiguration configuration,  IAppBLL bll)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _configuration = configuration;
            _bll = bll;
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.JwtResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.Message), StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<ActionResult<PublicApi.DTO.v1.JwtResponse>> Login(
            [FromBody] PublicApi.DTO.v1.Login dto)
        {
            var appUser = await _userManager.FindByEmailAsync(dto.Email);
            // TODO: wait a random time here to fool timing attacks
            if (appUser == null)
            {
                _logger.LogWarning("WebApi login failed. User {User} not found", dto.Email);
                return NotFound(new PublicApi.DTO.v1.Message("User/Password problem!"));
            }

            var result = await _signInManager.CheckPasswordSignInAsync(appUser, dto.Password, false);
            if (result.Succeeded)
            {
                var claimsPrincipal = await _signInManager.CreateUserPrincipalAsync(appUser);
                var jwt = Extensions.Base.IdentityExtensions.GenerateJwt(
                    claimsPrincipal.Claims,
                    _configuration["JWT:Key"],
                    _configuration["JWT:Issuer"],
                    _configuration["JWT:Issuer"],
                    DateTime.Now.AddDays(_configuration.GetValue<int>("JWT:ExpireDays"))
                );
                _logger.LogInformation("WebApi login. User {User}", dto.Email);
                return Ok(new PublicApi.DTO.v1.JwtResponse()
                {
                    Token = jwt,
                    Firstname = appUser.Firstname,
                    Lastname = appUser.Lastname,
                    Id = appUser.Id
                });
            }

            _logger.LogWarning("WebApi login failed. User {User} - bad password", dto.Email);
            return NotFound(new PublicApi.DTO.v1.Message("User/Password problem!"));
        }


        [HttpPost]
        public async Task<IActionResult> Register([FromBody] PublicApi.DTO.v1.Register dto)
        {
            var appUser = await _userManager.FindByEmailAsync(dto.Email);
            if (appUser != null)
            {
                _logger.LogWarning(" User {User} already registered", dto.Email);
                return BadRequest(new PublicApi.DTO.v1.Message("User already registered"));
            }

            appUser = new Domain.App.Identity.AppUser()
            {
                Email = dto.Email,
                UserName = dto.Email,
                Firstname = dto.Firstname,
                Lastname = dto.Lastname,
            };
            var result = await _userManager.CreateAsync(appUser, dto.Password);

            await _bll.SaveChangesAsync();

            if (result.Succeeded)
            {
                _logger.LogInformation("User {Email} created a new account with password", appUser.Email);

                var user = await _userManager.FindByEmailAsync(appUser.Email);
                if (user != null)
                {
                    var claimsPrincipal = await _signInManager.CreateUserPrincipalAsync(user);
                    var jwt = Extensions.Base.IdentityExtensions.GenerateJwt(
                        claimsPrincipal.Claims,
                        _configuration["JWT:Key"],
                        _configuration["JWT:Issuer"],
                        _configuration["JWT:Issuer"],
                        DateTime.Now.AddDays(_configuration.GetValue<int>("JWT:ExpireDays"))
                    );
                    _logger.LogInformation("WebApi login. User {User}", dto.Email);
                    return Ok(new PublicApi.DTO.v1.JwtResponse()
                    {
                        Token = jwt,
                        Firstname = appUser.Firstname,
                        Lastname = appUser.Lastname,
                    });
                }
                else
                {
                    _logger.LogInformation("User {Email} not found after creation", appUser.Email);
                    return BadRequest(new PublicApi.DTO.v1.Message("User not found after creation!"));
                }
            }

            var errors = result.Errors.Select(error => error.Description).ToList();
            return BadRequest(new PublicApi.DTO.v1.Message() {Messages = errors});
        }
    }


