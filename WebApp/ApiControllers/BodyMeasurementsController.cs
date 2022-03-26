using Extensions.Base;

namespace WebApp.ApiControllers;
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BodyMeasurementsController : ControllerBase
    {
        private readonly BodyMeasurementsMapper _mapper = new BodyMeasurementsMapper();
        private readonly IAppBLL _bll;

        public BodyMeasurementsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/BodyMeasurements
        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.Unit), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.BodyMeasurements>>> GetBodyMeasurements()
        {
            return Ok((await _bll.BodyMeasurements.GetAllAsync()).Select(a => _mapper.Map(a)));
        }

        // GET: api/BodyMeasurements/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.BodyMeasurements), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(PublicApi.DTO.v1.Message))]
        public async Task<ActionResult<PublicApi.DTO.v1.BodyMeasurements>> GetBodyMeasurement(Guid id)
        {
            var bodyMeasurements = await _bll.BodyMeasurements.FirstOrDefaultUserMeasurementsAsync(id);

            if (bodyMeasurements == null)
            {
                return NotFound(new Message("Body measurements not found"));
            }

            return Ok(_mapper.Map(bodyMeasurements));
        }

        // PUT: api/BodyMeasurements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Message))]
        public async Task<IActionResult> PutBodyMeasurement(Guid id, BodyMeasurements bodyMeasurement)
        {
            if (id != bodyMeasurement.Id)
            {
                return NotFound(new Message("Id and bodyMeasurement.id do not match"));
            }

            _bll.BodyMeasurements.Update(_mapper.Map(bodyMeasurement));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/BodyMeasurements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PublicApi.DTO.v1.BodyMeasurements))]
        [HttpPost]
        public async Task<ActionResult<BodyMeasurements>> PostBodyMeasurement(BodyMeasurements bodyMeasurement)
        {
            bodyMeasurement.AppUserId = User.GetUserId()!.Value;
            Console.WriteLine(bodyMeasurement);
            _bll.BodyMeasurements.Add(_mapper.Map(bodyMeasurement));
            await _bll.SaveChangesAsync();

            return CreatedAtAction(
                "GetBodyMeasurements",
                new
                {
                    id = bodyMeasurement.Id

                }, bodyMeasurement);
        }

        // DELETE: api/BodyMeasurements/5
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PublicApi.DTO.v1.BodyMeasurements))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Message))]
        public async Task<IActionResult> DeleteBodyMeasurement(Guid id)
        {
            var bodyMeasurements = await _bll.BodyMeasurements.FirstOrDefaultAsync(id);
            if (bodyMeasurements == null)
            {
                return NotFound(new Message("Body measurements not found"));
            }

            _bll.BodyMeasurements.Remove(bodyMeasurements);
            await _bll.SaveChangesAsync();

            return Ok(bodyMeasurements);
        }

    }

