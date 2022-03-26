namespace WebApp.ApiControllers;
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PicturesController : ControllerBase
    {
        private readonly PictureMapper _mapper = new PictureMapper();
        private readonly IAppBLL _bll;

        public PicturesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/Pictures
        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.Picture), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.Picture>>> GetPictures()
        {
            return Ok((await _bll.Picture.GetAllAsync()).Select(a => _mapper.Map(a)));

        }

        // GET: api/Pictures/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.Picture), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(PublicApi.DTO.v1.Message))]
        public async Task<ActionResult<Picture>> GetPicture(Guid id)
        {
            var picture = await _bll.Picture.FirstOrDefaultAsync(id);

            if (picture == null)
            {
                return NotFound(new Message("Picture not found"));
            }

            return Ok(_mapper.Map(picture));
        }

        // PUT: api/Pictures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Message))]
        public async Task<IActionResult> PutPicture(Guid id, Picture picture)
        {
            if (id != picture.Id)
            {
                return NotFound(new Message("Id and picture.id do not match"));
            }

            _bll.Picture.Update(_mapper.Map(picture));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Pictures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Produces("application/json")]
        [Consumes("application/json")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Picture))]
        [HttpPost]
        public async Task<ActionResult<Picture>> PostPicture(Picture picture)
        {
            _bll.Picture.Add(_mapper.Map(picture));
            await _bll.SaveChangesAsync();

            return CreatedAtAction(
                "GetPicture",
                new
                {
                    id = picture.Id

                }, picture);
        }

        // DELETE: api/Pictures/5
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PublicApi.DTO.v1.Picture))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Message))]
        public async Task<IActionResult> DeletePicture(Guid id)
        {
            var picture = await _bll.Picture.FirstOrDefaultAsync(id);
            if (picture == null)
            {
                return NotFound(new Message("Picture not found"));
            }

            _bll.Picture.Remove(picture);
            await _bll.SaveChangesAsync();

            return Ok(picture);
        }

    }

