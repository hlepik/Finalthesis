namespace WebApp.ApiControllers;
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserPatternsController : ControllerBase
    {
        private readonly UserPatternMapper _mapper = new UserPatternMapper();
        private readonly IAppBLL _bll;

        public UserPatternsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/UserPatterns
        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.UserPattern), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.UserPattern>>> GetUserPatterns()
        {
            return Ok((await _bll.UserPattern.GetAllAsync()).Select(a => _mapper.Map(a)));
        }

        // GET: api/UserPatterns/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.UserPattern), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(PublicApi.DTO.v1.Message))]
        public async Task<ActionResult<PublicApi.DTO.v1.UserPattern>> GetUserPattern(Guid id)
        {
            var userPattern = await _bll.UserPattern.FirstOrDefaultAsync(id);

            if (userPattern == null)
            {
                return NotFound(new Message("Pattern not found"));
            }

            return Ok(_mapper.Map(userPattern));
        }

        // PUT: api/UserPatterns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Message))]
        public async Task<IActionResult> PutUserPattern(Guid id, UserPattern userPattern)
        {
            if (id != userPattern.Id)
            {
                return NotFound(new Message("Id and userPattern.id do not match"));
            }

            _bll.UserPattern.Update(_mapper.Map(userPattern));
            await _bll.SaveChangesAsync();

            return NoContent();

        }

        // POST: api/UserPatterns
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserPattern))]
        [HttpPost]
        public async Task<ActionResult<UserPattern>> PostUserPattern(UserPattern userPattern)
        {
            _bll.UserPattern.Add(_mapper.Map(userPattern));
            await _bll.SaveChangesAsync();

            return CreatedAtAction(
                "GetUserPattern",
                new
                {
                    id = userPattern.Id

                }, userPattern);
        }

        // DELETE: api/UserPatterns/5
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PublicApi.DTO.v1.UserPattern))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Message))]
        public async Task<IActionResult> DeleteUserPattern(Guid id)
        {
            var user = await _bll.UserPattern.FirstOrDefaultAsync(id);
            if (user == null)
            {
                return NotFound(new Message("UserPattern not found"));
            }

            _bll.UserPattern.Remove(user);
            await _bll.SaveChangesAsync();

            return Ok(user);
        }
    }

