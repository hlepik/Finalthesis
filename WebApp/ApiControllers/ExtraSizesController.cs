using Extensions.Base;

namespace WebApp.ApiControllers;
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ExtraSizesController : ControllerBase
    {
        private readonly ExtraSizeMapper _mapper = new ExtraSizeMapper();
        private readonly IAppBLL _bll;

        public ExtraSizesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/ExtraSizes
        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.ExtraSize), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.ExtraSize>>> GetExtraSizes()
        {
            return Ok((await _bll.ExtraSize.GetAllAsync()).Select(a => _mapper.Map(a)));
        }

        // GET: api/ExtraSizes/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.ExtraSize), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(PublicApi.DTO.v1.Message))]
        public async Task<ActionResult<PublicApi.DTO.v1.ExtraSize>> GetExtraSize(Guid id)
        {
            var extraSize = await _bll.ExtraSize.FirstOrDefaultAsync(id);

            if (extraSize == null)
            {
                return NotFound(new Message("ExtraSize not found"));
            }

            return Ok(_mapper.Map(extraSize));
        }

        // PUT: api/ExtraSizes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Message))]
        public async Task<IActionResult> PutExtraSize(Guid id, ExtraSize extraSize)
        {
            if (id != extraSize.Id)
            {
                return NotFound(new Message("Id and extraSize.id do not match"));
            }

            _bll.ExtraSize.Update(_mapper.Map(extraSize));
            await _bll.SaveChangesAsync();

            return NoContent();
        }
        // GET: api/ExtraSizes/instructionId/5
        [HttpGet("instructionId/{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.PatternInstruction), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.ExtraSize>>> GetInstructionsById(Guid id)
        {
            return Ok((await _bll.ExtraSize.GetAllByInstructionId(id))!.Select(a => _mapper.Map(a)));
        }
        // POST: api/ExtraSizes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PublicApi.DTO.v1.ExtraSize))]
        [HttpPost]
        public async Task<ActionResult<ExtraSize>> PostExtraSize(ExtraSize extraSize)
        {
       
            _bll.ExtraSize.Add(_mapper.Map(extraSize));
            await _bll.SaveChangesAsync();

            return CreatedAtAction(
                "GetExtraSize",
                new
                {
                    id = extraSize.Id

                }, extraSize);
        }

        // DELETE: api/ExtraSizes/5
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PublicApi.DTO.v1.ExtraSize))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Message))]
        public async Task<IActionResult> DeleteExtraSize(Guid id)
        {
            var extraSize = await _bll.ExtraSize.FirstOrDefaultAsync(id);
            if (extraSize == null)
            {
                return NotFound(new Message("ExtraSize not found"));
            }

            _bll.ExtraSize.Remove(extraSize);
            await _bll.SaveChangesAsync();

            return Ok(extraSize);
        }

    }

