namespace WebApp.ApiControllers;
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class InstructionsController : ControllerBase
    {
        private readonly InstructionMapper _mapper = new InstructionMapper();
        private readonly IAppBLL _bll;

        public InstructionsController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Instructions
        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.Unit), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.Instruction>>> GetInstructions()
        {

            return Ok((await _bll.Instruction.GetAllAsync()).Select(a => _mapper.Map(a)));
        }

        // GET: api/Instructions/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.Instruction), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(PublicApi.DTO.v1.Message))]
        public async Task<ActionResult<Instruction>> GetInstruction(Guid id)
        {
            var instruction = await _bll.Instruction.FirstOrDefaultAsync(id);

            if (instruction == null)
            {
                return NotFound(new Message("Instruction not found"));
            }

            return Ok(_mapper.Map(instruction));
        }

        // PUT: api/Instructions/5
        [HttpPut("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Message))]
        public async Task<IActionResult> PutInstruction(Guid id, Instruction instruction)
        {
            if (id != instruction.Id)
            {
                return NotFound(new Message("Id and instruction.id do not match"));
            }

            _bll.Instruction.Update(_mapper.Map(instruction));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Instructions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Produces("application/json")]
        [Consumes("application/json")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Instruction))]
        [HttpPost]
        public async Task<ActionResult<Instruction>> PostInstruction(Instruction instruction)
        {
            try
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

                //create folder if not exist
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                //get file extension
                FileInfo fileInfo = new FileInfo(instruction.PatternFile!.FileName);
                string fileName = instruction.PatternFile!.FileName + fileInfo.Extension;

                string fileNameWithPath = Path.Combine(path, fileName);

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    instruction.PatternFile!.CopyTo(stream);
                }

                instruction.FileName = fileName;

            }
            catch (Exception)
            {
                return BadRequest(new PublicApi.DTO.v1.Message("File laadmine ebaõnnestu!"));
            }


            _bll.Instruction.Add(_mapper.Map(instruction));
            await _bll.SaveChangesAsync();

            return CreatedAtAction(
                "GetInstruction",
                new
                {
                    id = instruction.Id

                }, instruction);
        }

        // DELETE: api/Instructions/5
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PublicApi.DTO.v1.Instruction))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Message))]
        public async Task<IActionResult> DeleteInstruction(Guid id)
        {
            var instruction = await _bll.Instruction.FirstOrDefaultAsync(id);
            if (instruction == null)
            {
                return NotFound(new Message("Instruction not found"));
            }

            _bll.Instruction.Remove(instruction);
            await _bll.SaveChangesAsync();

            return Ok(instruction);
        }

    }

