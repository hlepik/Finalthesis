
using WebApp.ViewModels.Test;

namespace WebApp.Controllers
{
    public class TestController : Controller
    {
        private readonly ILogger<TestController> _logger;
        private readonly AppDbContext _ctx;

        public TestController(ILogger<TestController> logger, AppDbContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        // GET
        public async  Task<IActionResult> Test()
        {
            _logger.LogInformation("Test method starts");
            var vm = new TestViewModel
            {
                Instructions = await _ctx
                    .Instructions
                    .Include(x => x.ExtraSizes)!
                    .ThenInclude(x => x!.Name)
                    .Include(x => x.PatternInstructions)

                    .Include(x => x.Category)
                    .ThenInclude(x => x!.Name)

                    .ToListAsync()
            };
            _logger.LogInformation("Test method pre-return");
            return View(vm);
        }

        [Authorize]
        public  string TestAuth()
        {
            return "OK";
        }
    }
}
