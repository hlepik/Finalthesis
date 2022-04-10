namespace WebApp.ApiControllers;
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserMeasurementsController : ControllerBase
    {
        private readonly  UserMeasurementsMapper _mapper = new  UserMeasurementsMapper();
        private readonly IAppBLL _bll;

        public UserMeasurementsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/InstructionMeasurementTypes
        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.UserMeasurements), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.UserMeasurements>>> GetInstructionMeasurementTypes()
        {
            return Ok((await _bll.UserMeasurements.GetAllAsync()).Select(a => _mapper.Map(a)));
        }

        // GET: api/InstructionMeasurementTypes/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.UserMeasurements), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(PublicApi.DTO.v1.Message))]
        public async Task<ActionResult<PublicApi.DTO.v1.UserMeasurements>> GetInstructionMeasurementType(Guid id)
        {
            var instructionMeasurementType = await _bll.UserMeasurements.FirstOrDefaultAsync(id);

            if (instructionMeasurementType == null)
            {
                return NotFound(new Message("UserMeasurements not found"));
            }

            return Ok(_mapper.Map(instructionMeasurementType));
        }

        // PUT: api/InstructionMeasurementTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Message))]
        public async Task<IActionResult> PutInstructionMeasurementType(Guid id, UserMeasurements userMeasurements)
        {
            if (id != userMeasurements.Id)
            {
                return NotFound(new Message("Id and UserMeasurements.id do not match"));
            }

            _bll.UserMeasurements.Update(_mapper.Map(userMeasurements));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/InstructionMeasurementTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PublicApi.DTO.v1.UserMeasurements))]
        [HttpPost]
        public async Task<ActionResult<UserMeasurements>> PostInstructionMeasurementType(UserMeasurements userMeasurements)
        {
       
            _bll.UserMeasurements.Add(_mapper.Map(userMeasurements));
            await _bll.SaveChangesAsync();

            return CreatedAtAction(
                "GetInstructionMeasurementTypes",
                new
                {
                    id = userMeasurements.Id

                }, userMeasurements);
        }

        // DELETE: api/MeasurementTypes/5
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PublicApi.DTO.v1.UserMeasurements))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Message))]
        public async Task<IActionResult> DeleteInstructionMeasurementType(Guid id)
        {
            var instructionMeasurementType = await _bll.UserMeasurements.FirstOrDefaultAsync(id);
            if (instructionMeasurementType == null)
            {
                return NotFound(new Message("UserMeasurements not found"));
            }

            _bll.UserMeasurements.Remove(instructionMeasurementType);
            await _bll.SaveChangesAsync();

            return Ok(instructionMeasurementType);
        }

    }

