using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace WebApp.ApiControllers.Identity;
/// <summary>
    /// Api controller for AppUser
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AppUserController : ControllerBase
    {
        private readonly IAppBLL _bll;

        private readonly UserManager<AppUser> _userManager;

        /// <summary>
        ///
        /// </summary>
        /// <param name="userManager"></param>
        public AppUserController(UserManager<AppUser> userManager, IAppBLL bll)
        {

            _userManager = userManager;
            _bll = bll;
        }


        /// <summary>
        /// Returns all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _userManager.Users.ToListAsync();

        }


        /// <summary>
        /// Retuns app user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetAppUser(Guid id)
        {
            var appUser = await _userManager.Users
                .FirstOrDefaultAsync(m => m.Id == id);

            if (appUser == null)
            {
                return NotFound();
            }
            return Ok(appUser);
        }

        /// <summary>
        /// Edit user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="appUser"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppUser(Guid id, AppUser appUser)
        {
            if (id != appUser.Id)
            {
                return BadRequest();
            }
            var user = await _userManager.FindByIdAsync(appUser.Id.ToString());
            if (user == null)
            {
                return NotFound();


            }

            user.Firstname = appUser.Firstname;
            user.Lastname = appUser.Lastname;
            if (user.Email != appUser.Email)
            {
                var appUserEmail = await _userManager.FindByEmailAsync(appUser.Email);
                if (appUserEmail != null)
                {
                    return BadRequest(new Message("Email juba kasutusel"));

                }
                user.Email = appUser.Email;


            }
            await _userManager.UpdateAsync(user);

            await _bll.SaveChangesAsync();
            return NoContent();
        }

// <summary>
        /// Edit user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="appUser"></param>
        /// <returns></returns>
        [HttpPut("password/{id}")]
        public async Task<IActionResult> UpdatePassword(Guid id, string password)
        {

            var user = await _userManager.FindByIdAsync(id.ToString());
            await _userManager.RemovePasswordAsync(user);

            await _userManager.AddPasswordAsync(user, password);

            await _userManager.UpdateAsync(user);

            await _bll.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Add new user
        /// </summary>
        /// <param name="appUser"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<AppUser>> PostAppUser(AppUser appUser)
        {

            await _userManager.CreateAsync(appUser);
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetAppUser", new { id = appUser.Id }, appUser);
        }


        /// <summary>
        /// delete app user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppUser(Guid id)
        {
            var appUser = await _userManager.FindByIdAsync(id.ToString());
            if (appUser == null)
            {
                return NotFound();
            }

            await _userManager.DeleteAsync(appUser);
            await _bll.SaveChangesAsync();

            return NoContent();
        }



    }
