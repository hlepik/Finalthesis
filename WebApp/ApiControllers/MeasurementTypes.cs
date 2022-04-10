namespace WebApp.ApiControllers;
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MeasurementTypesController : ControllerBase
    {
        private readonly MeasurementTypeMapper _mapper = new MeasurementTypeMapper();
        private readonly IAppBLL _bll;

        public MeasurementTypesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/MeasurementTypes
        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.MeasurementType), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.MeasurementType>>> GetMeasurementTypes()
        {
            return Ok((await _bll.MeasurementType.GetAllAsync()).Select(a => _mapper.Map(a)));
        }

        // GET: api/MeasurementTypes/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.MeasurementType), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(PublicApi.DTO.v1.Message))]
        public async Task<ActionResult<PublicApi.DTO.v1.MeasurementType>> GetMeasurementType(Guid id)
        {
            var measurementType = await _bll.MeasurementType.FirstOrDefaultAsync(id);

            if (measurementType == null)
            {
                return NotFound(new Message("MeasurementType not found"));
            }

            return Ok(_mapper.Map(measurementType));
        }

        // PUT: api/MeasurementTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Message))]
        public async Task<IActionResult> PutMeasurementType(Guid id, MeasurementType measurementType)
        {
            if (id != measurementType.Id)
            {
                return NotFound(new Message("Id and MeasurementType.id do not match"));
            }

            _bll.MeasurementType.Update(_mapper.Map(measurementType));
            await _bll.SaveChangesAsync();

            return NoContent();
        }
  
        // POST: api/MeasurementTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PublicApi.DTO.v1.MeasurementType))]
        [HttpPost]
        public async Task<ActionResult<MeasurementType>> PostMeasurementType(MeasurementType measurementType)
        {
       
            _bll.MeasurementType.Add(_mapper.Map(measurementType));
            await _bll.SaveChangesAsync();

            return CreatedAtAction(
                "GetMeasurementTypes",
                new
                {
                    id = measurementType.Id

                }, measurementType);
        }

        // DELETE: api/MeasurementTypes/5
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PublicApi.DTO.v1.MeasurementType))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Message))]
        public async Task<IActionResult> DeleteMeasurementType(Guid id)
        {
            var measurementType = await _bll.MeasurementType.FirstOrDefaultAsync(id);
            if (measurementType == null)
            {
                return NotFound(new Message("MeasurementType not found"));
            }

            _bll.MeasurementType.Remove(measurementType);
            await _bll.SaveChangesAsync();

            return Ok(measurementType);
        }

    }

