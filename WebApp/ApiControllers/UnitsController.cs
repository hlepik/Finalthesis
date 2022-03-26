namespace WebApp.ApiControllers;
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UnitsController : ControllerBase
    {
        private readonly UnitMapper _mapper = new UnitMapper();
        private readonly IAppBLL _bll;

        public UnitsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Units
        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.Unit), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.Unit>>> GetUnits()
        {
            return Ok((await _bll.Unit.GetAllAsync()).Select(a => _mapper.Map(a)));
        }

        // GET: api/Units/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.Unit), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(PublicApi.DTO.v1.Message))]
        public async Task<ActionResult<PublicApi.DTO.v1.Unit>> GetUnit(Guid id)
        {
            var unit = await _bll.Unit.FirstOrDefaultAsync(id);

            if (unit == null)
            {
                return NotFound(new Message("Unit not found"));
            }

            return Ok(_mapper.Map(unit));
        }

        // PUT: api/Units/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Message))]
        public async Task<IActionResult> PutUnit(Guid id, PublicApi.DTO.v1.Unit unit)
        {
            if (id != unit.Id)
            {
                return NotFound(new Message("Id and unit.id do not match"));
            }

            _bll.Unit.Update(_mapper.Map(unit));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Units
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Unit))]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<PublicApi.DTO.v1.Unit>> PostUnit(PublicApi.DTO.v1.Unit unit)
        {
            _bll.Unit.Add(_mapper.Map(unit));
            await _bll.SaveChangesAsync();

            return CreatedAtAction(
                "GetUnit",
                new
                {
                    id = unit.Id

                }, unit);
        }

        // DELETE: api/Units/5
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PublicApi.DTO.v1.Unit))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Message))]
        public async Task<IActionResult> DeleteUnit(Guid id)
        {

            var unit = await _bll.Unit.FirstOrDefaultAsync(id);
            if (unit == null)
            {
                return NotFound(new Message("Unit not found"));
            }

            _bll.Unit.Remove(unit);
            await _bll.SaveChangesAsync();

            return Ok(unit);
        }

    }

