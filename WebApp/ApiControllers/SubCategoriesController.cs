namespace WebApp.ApiControllers;
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SubCategoriesController : ControllerBase
    {
        private readonly SubCategoryMapper _mapper = new SubCategoryMapper();
        private readonly IAppBLL _bll;

        public SubCategoriesController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/SubCategories
        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.SubCategory), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PublicApi.DTO.v1.SubCategory>>> GetSubCategories()
        {
            return Ok((await _bll.SubCategory.GetAllAsync()).Select(a => _mapper.Map(a)));        }

        // GET: api/SubCategories/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.SubCategory), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(PublicApi.DTO.v1.Message))]
        public async Task<ActionResult<PublicApi.DTO.v1.SubCategory>> GetSubCategory(Guid id)
        {
            var subCategory = await _bll.SubCategory.FirstOrDefaultAsync(id);

            if (subCategory == null)
            {
                return NotFound(new Message("Sub category not found"));
            }

            return Ok(_mapper.Map(subCategory));
        }

        // PUT: api/SubCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Message))]
        public async Task<IActionResult> PutSubCategory(Guid id, PublicApi.DTO.v1.SubCategory subCategory)
        {
            if (id != subCategory.Id)
            {
                return NotFound(new Message("Id and subCategory.id do not match"));
            }

            _bll.SubCategory.Update(_mapper.Map(subCategory));
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/SubCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Produces("application/json")]
        [Consumes("application/json")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SubCategory))]
        [HttpPost]
        public async Task<ActionResult<SubCategory>> PostSubCategory(SubCategory subCategory)
        {
            _bll.SubCategory.Add(_mapper.Map(subCategory));
            await _bll.SaveChangesAsync();

            return CreatedAtAction(
                "GetSubCategory",
                new
                {
                    id = subCategory.Id

                }, subCategory);
        }

        // DELETE: api/SubCategories/5
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PublicApi.DTO.v1.SubCategory))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Message))]
        public async Task<IActionResult> DeleteSubCategory(Guid id)
        {
            var subCategory = await _bll.SubCategory.FirstOrDefaultAsync(id);
            if (subCategory == null)
            {
                return NotFound(new Message("Sub category not found"));
            }

            _bll.SubCategory.Remove(subCategory);
            await _bll.SaveChangesAsync();

            return Ok(subCategory);
        }

    }

