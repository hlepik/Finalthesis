namespace WebApp.ApiControllers;
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryMapper _mapper = new CategoryMapper();
        private readonly IAppBLL _bll;

        public CategoriesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/SubCategories
        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.Category), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.Category>>> GetCategories()
        {
            return Ok((await _bll.Category.GetAllAsync()).Select(a => _mapper.Map(a)));        }

        // GET: api/SubCategories/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.Category), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(PublicApi.DTO.v1.Message))]
        public async Task<ActionResult<PublicApi.DTO.v1.Category>> GetCategory(Guid id)
        {
            var category = await _bll.Category.FirstOrDefaultAsync(id);

            if (category == null)
            {
                return NotFound(new Message("Category not found"));
            }

            return Ok(_mapper.Map(category));
        }

        // PUT: api/SubCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Message))]
        public async Task<IActionResult> PutCategory(Guid id, PublicApi.DTO.v1.Category category)
        {
            if (id != category.Id)
            {
                return NotFound(new Message("Id and category.id do not match"));
            }

            _bll.Category.Update(_mapper.Map(category));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/SubCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Category))]
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            _bll.Category.Add(_mapper.Map(category));
            await _bll.SaveChangesAsync();

            return CreatedAtAction(
                "GetCategory",
                new
                {
                    id = category.Id

                }, category);
        }

        // DELETE: api/SubCategories/5
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PublicApi.DTO.v1.Category))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Message))]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var category = await _bll.Category.FirstOrDefaultAsync(id);
            if (category == null)
            {
                return NotFound(new Message("Category not found"));
            }

            _bll.Category.Remove(category);
            await _bll.SaveChangesAsync();

            return Ok(category);
        }

    }
