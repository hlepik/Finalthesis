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
        [AllowAnonymous]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.Instruction), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.Instruction>>> GetInstructions()
        {

            return Ok((await _bll.Instruction.GetAllAsync()).Select(a => _mapper.Map(a)));
        }
        // GET: api/Instructions/GetLastInserted
        [HttpGet("GetLastInserted/patterns")]
        [AllowAnonymous]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.Instruction), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.Instruction>>> GetLastInsertedInstructions()
        {
            return Ok((await _bll.Instruction.GetLastInsertedAsync()).Select(a => _mapper.Map(a)));

        }
        // GET: api/Instructions/Search/name
        [HttpGet("Search/{searchInput}/{categoryId}")]
        [AllowAnonymous]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.Instruction), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.Instruction>>> GetSearchResult(string searchInput, Guid categoryId)
        {

            return Ok((await _bll.Instruction.GetSearchResult(searchInput, categoryId)).Select(a => _mapper.Map(a)));
        }

        // GET: api/Instructions/category
        [HttpGet("category/{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.Instruction), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.Instruction>>> GetInstructionsByCategory(Guid id)
        {
            return Ok((await _bll.Instruction.GetAllByCategory(id)).Select(a => _mapper.Map(a)));
        }

        // GET: api/Instructions/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.Instruction), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(PublicApi.DTO.v1.Message))]
        public async Task<ActionResult<Instruction>> GetInstruction(Guid id)
        {
            var instruction = await _bll.Instruction.FirstOrDefaultDtoAsync(id);

            if (instruction == null)
            {
                return NotFound(new Message("Instruction not found"));
            }

            return Ok(_mapper.Map(instruction));
        }
        // PUT: api/Instructions/5
        [HttpPut("file/{id}")]
        [Produces("application/json")]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Message))]
        public async Task<IActionResult> PutInstructionFile(Guid id, [FromForm] Instruction instruction)
        {
            if (id != instruction.Id)
            {
                return NotFound(new Message("Id and instruction.id do not match"));
            }

            if (instruction.PatternFile != null)
            {

                var instructionFromDb = await _bll.Instruction.FirstOrDefaultAsync(id);
                string path = "wwwroot/Files/" + instructionFromDb!.FileName;
                FileInfo fileToDelete = new FileInfo(path);
                if (fileToDelete.Exists)
                {
                    fileToDelete.Delete();
                }

                string getFirstFiveChars = instruction.Id.ToString().Substring(0, 5);
                string fileName = getFirstFiveChars + "-" + instruction.PatternFile!.FileName;

                string filePath = "wwwroot/Files/" + fileName;
                FileInfo file = new FileInfo(filePath);
                if (!file.Exists)
                {

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        instruction.PatternFile!.CopyTo(stream);
                    }
                    instruction.FileName = fileName;
                }


            }
            _bll.Instruction.Update(_mapper.Map(instruction));
            await _bll.SaveChangesAsync();
            return CreatedAtAction(
                "GetInstruction",
                new
                {
                    id = instruction.Id,

                }, instruction);
        }
        // PUT: api/Instructions/5
        [HttpPut("{id}")]
        [Produces("application/json")]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Message))]
        public async Task<IActionResult> PutInstruction(Guid id, [FromForm] Instruction instruction)
        {

             if (id != instruction.Id)
            {
                return NotFound(new Message("Id and instruction.id do not match"));
            }

            if (instruction.PatternFile != null)
            {

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");
                string getFirstFiveChars = instruction.Id.ToString().Substring(0, 5);
                string fileName = getFirstFiveChars + "-" + instruction.PatternFile!.FileName;

                string filePath = "wwwroot/Files/" + fileName;
                FileInfo file = new FileInfo(filePath);
                if (!file.Exists)
                {
                    string fileNameWithPath = Path.Combine(path, fileName);

                    using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                    {
                        instruction.PatternFile!.CopyTo(stream);
                    }
                    instruction.FileName = fileName;
                }


            }

            if(instruction.MainPicture != null){

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Pictures");
                string getFirstFiveChars = instruction.Id.ToString().Substring(0,5);
                string fileName = getFirstFiveChars + "-" + instruction.MainPicture!.FileName;

                string picturePath = "wwwroot/Pictures/" + fileName;
                FileInfo pictureFile = new FileInfo(picturePath);
                if (!pictureFile.Exists)
                {
                    string fileNameWithPath = Path.Combine(path, fileName);

                    using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                    {
                        instruction.MainPicture.CopyTo(stream);
                    }
                    instruction.MainPictureName = fileName;
                }

            }

            _bll.Instruction.Update(_mapper.Map(instruction));
            await _bll.SaveChangesAsync();

            return NoContent();

        }
        // PUT: api/Instructions/picture/5
        [HttpPut("picture/{id}")]
        [Produces("application/json")]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Message))]
        public async Task<IActionResult> PutInstructionPicture(Guid id, [FromForm] Instruction instruction)
        {
            if (id != instruction.Id)
            {
                return NotFound(new Message("Id and instruction.id do not match"));
            }

            if (instruction.MainPicture != null)
            {

                var instructionFromDb = await _bll.Instruction.FirstOrDefaultAsync(id);
                string path = "wwwroot/Pictures/" + instructionFromDb!.MainPictureName;
                FileInfo pictureToDelete = new FileInfo(path);
                if (pictureToDelete.Exists)
                {
                    pictureToDelete.Delete();
                }

                string getFirstFiveChars = instruction.Id.ToString().Substring(0, 5);
                string fileName = getFirstFiveChars + "-" + instruction.MainPicture!.FileName;

                string filePath = "wwwroot/Pictures/" + fileName;
                FileInfo file = new FileInfo(filePath);
                if (!file.Exists)
                {

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        instruction.MainPicture!.CopyTo(stream);
                    }
                    instruction.MainPictureName = fileName;
                }


            }
            _bll.Instruction.Update(_mapper.Map(instruction));
            await _bll.SaveChangesAsync();
            return CreatedAtAction(
                "GetInstruction",
                new
                {
                    id = instruction.Id,

                }, instruction);
        }


        // POST: api/Instructions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Produces("application/json")]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Instruction))]
        [HttpPost]
        public async Task<ActionResult<Instruction>> PostInstruction([FromForm] Instruction instruction)
        {

            instruction.DateAdded = DateTime.Now;
            instruction.Id = Guid.NewGuid();
            try
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");
                string picturePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Pictures");

                string getFirstFiveChars = instruction.Id.ToString().Substring(0,5);
                string fileName = getFirstFiveChars + "-" + instruction.PatternFile!.FileName;

                string fileNameWithPath = Path.Combine(path, fileName);

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    instruction.PatternFile!.CopyTo(stream);
                }
                instruction.FileName = fileName;

                string picture = getFirstFiveChars + "-" + instruction.MainPicture!.FileName;

                string pictureNameWithPath = Path.Combine(picturePath, picture);

                using (var stream = new FileStream(pictureNameWithPath, FileMode.Create))
                {
                    instruction.MainPicture!.CopyTo(stream);
                }
                instruction.MainPictureName = picture;

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
             _bll.ExtraSize.RemoveByInstructionId(id);
             _bll.PatternInstruction.RemoveByInstructionId(id);
             await _bll.SaveChangesAsync();

            var instruction = await _bll.Instruction.FirstOrDefaultAsync(id);
            if (instruction == null)
            {
                return NotFound(new Message("Instruction not found"));
            }
            string path = "wwwroot/Files/" + instruction.FileName;
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
            }
            string picturePath = "wwwroot/Pictures/" + instruction.MainPictureName;
            FileInfo pictureFile = new FileInfo(picturePath);
            if (pictureFile.Exists)
            {
                file.Delete();
            }
            _bll.Instruction.Remove(instruction);
            await _bll.SaveChangesAsync();

            return Ok(instruction);
        }


    }

