namespace WebApp.ApiControllers;
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PatternInstructionsController : ControllerBase
    {
        private readonly PatternInstructionMapper _mapper = new PatternInstructionMapper();
        private readonly IAppBLL _bll;

        public PatternInstructionsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/PatternInstructions
        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.PatternInstruction), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.PatternInstruction>>> GetPatternInstructions()
        {
            return Ok((await _bll.PatternInstruction.GetAllAsync()).Select(a => _mapper.Map(a)));
        }

        // GET: api/PatternInstructions/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.PatternInstruction), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(PublicApi.DTO.v1.Message))]
        public async Task<ActionResult<PatternInstruction>> GetPatternInstruction(Guid id)
        {
            var patternInstruction = await _bll.PatternInstruction.FirstOrDefaultAsync(id);

            if (patternInstruction == null)
            {
                return NotFound(new Message("Pattern instruction not found"));
            }

            return Ok(_mapper.Map(patternInstruction));
        }

        // PUT: api/PatternInstructions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Message))]
        public async Task<IActionResult> PutPatternInstruction(Guid id, PatternInstruction patternInstruction)
        {
            if (id != patternInstruction.Id)
            {
                return NotFound(new Message("Id and patternInstruction.id do not match"));
            }

            _bll.PatternInstruction.Update(_mapper.Map(patternInstruction));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/PatternInstructions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Produces("application/json")]
        [Consumes("application/json")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PatternInstruction))]
        [HttpPost]
        public async Task<ActionResult<PatternInstruction>> PostPatternInstruction(PatternInstruction patternInstruction)
        {
            _bll.PatternInstruction.Add(_mapper.Map(patternInstruction));
            await _bll.SaveChangesAsync();

            return CreatedAtAction(
                "GetPatternInstruction",
                new
                {
                    id = patternInstruction.Id

                }, patternInstruction);
        }

        // DELETE: api/PatternInstructions/5
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PublicApi.DTO.v1.PatternInstruction))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Message))]
        public async Task<IActionResult> DeletePatternInstruction(Guid id)
        {
            var patternInstruction = await _bll.PatternInstruction.FirstOrDefaultAsync(id);
            if (patternInstruction == null)
            {
                return NotFound(new Message("Pattern instruction not found"));
            }

            _bll.PatternInstruction.Remove(patternInstruction);
            await _bll.SaveChangesAsync();

            return Ok(patternInstruction);
        }

    }

