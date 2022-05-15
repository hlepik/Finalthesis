using Microsoft.AspNetCore.Hosting;

namespace WebApp.ApiControllers;
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PatternInstructionsController : ControllerBase
    {
        private readonly PatternInstructionMapper _mapper = new PatternInstructionMapper();
        private readonly IAppBLL _bll;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public PatternInstructionsController(IAppBLL bll, IWebHostEnvironment hostingEnvironment)
        {
            _bll = bll;
            _hostingEnvironment = hostingEnvironment;

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

        // GET: api/PatternInstructions
        [HttpGet("instructionId/{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.PatternInstruction), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.PatternInstruction>>> GetPatternInstructionsById(Guid id)
        {
            return Ok((await _bll.PatternInstruction.GetAllByInstructionId(id))!.Select(a => _mapper.Map(a)));
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
        [Consumes("multipart/form-data")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Message))]
        public async Task<IActionResult> PutPatternInstruction(Guid id,[FromForm] PatternInstruction patternInstruction)
        {
            if (id != patternInstruction.Id)
            {
                return NotFound(new Message("Id and patternInstruction.id do not match"));
            }

            if (patternInstruction.Picture != null)
            {
                var instructionFromDb = await _bll.PatternInstruction.FirstOrDefaultAsync(id);
                string path = _hostingEnvironment.WebRootPath + "/content/uploads/" + instructionFromDb!.PictureName;
                FileInfo pictureToDelete = new FileInfo(path);
                if (pictureToDelete.Exists)
                {
                    pictureToDelete.Delete();
                }

                string getFirstFiveChars = patternInstruction.Id.ToString().Substring(0, 5);
                string fileName = getFirstFiveChars + "-" + patternInstruction.Picture!.FileName;

                string filePath = _hostingEnvironment.WebRootPath + "/content/uploads/"  + fileName;
                FileInfo file = new FileInfo(filePath);
                if (!file.Exists)
                {

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                       patternInstruction.Picture!.CopyTo(stream);
                    }
                    patternInstruction.PictureName = fileName;
                }
            }

            _bll.PatternInstruction.Update(_mapper.Map(patternInstruction));
            await _bll.SaveChangesAsync();

            return CreatedAtAction(
                "GetPatternInstruction",
                new
                {
                    id = patternInstruction.Id

                }, patternInstruction);
        }


        // POST: api/PatternInstructions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Produces("application/json")]
        [Consumes("multipart/form-data")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PatternInstruction))]
        [HttpPost]
        public async Task<ActionResult<PatternInstruction>> PostPatternInstruction([FromForm] PatternInstruction patternInstruction)
        {
            patternInstruction.Id = Guid.NewGuid();
            if (patternInstruction.Picture != null)
            {


                string path = Path.Combine(Directory.GetCurrentDirectory(), _hostingEnvironment.WebRootPath + "/content/uploads" );
                string getFirstFiveChars = patternInstruction.Id.ToString().Substring(0,5);
                string fileName = getFirstFiveChars + "-" + patternInstruction.Picture!.FileName;

                string fileNameWithPath = Path.Combine(path, fileName);

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    patternInstruction.Picture.CopyTo(stream);
                }
                patternInstruction.PictureName = fileName;
            }


            _bll.PatternInstruction.Add(_mapper.Map(patternInstruction));
            await _bll.SaveChangesAsync();

            return CreatedAtAction(
                "GetPatternInstruction",
                new
                {
                    id = patternInstruction.Id

                }, patternInstruction);
        }

        // DELETE: api/PatternInstructions/picture/5
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete("picture/{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PublicApi.DTO.v1.PatternInstruction))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Message))]
        public async Task<IActionResult> DeletePatternInstructionPicture(Guid id)
        {
            var patternInstruction = await _bll.PatternInstruction.FirstOrDefaultAsync(id);
            if (patternInstruction == null)
            {
                return NotFound(new Message("Pattern instruction not found"));
            }
            if (patternInstruction.PictureName != null)
            {
                string path = _hostingEnvironment.WebRootPath + "/content/uploads/"  + patternInstruction.PictureName;
                FileInfo file = new FileInfo(path);
                if (file.Exists)
                {
                    file.Delete();
                }
            }

            patternInstruction.PictureName = null;
            _bll.PatternInstruction.Update(patternInstruction);
            await _bll.SaveChangesAsync();

            return Ok(patternInstruction);
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
            if (patternInstruction.PictureName == null)
            {
                string path = _hostingEnvironment.WebRootPath + "/content/uploads/" + patternInstruction.PictureName;
                FileInfo file = new FileInfo(path);
                if (file.Exists)
                {
                    file.Delete();
                }
            }

            _bll.PatternInstruction.Remove(patternInstruction);
            await _bll.SaveChangesAsync();

            return Ok(patternInstruction);
        }

    }

