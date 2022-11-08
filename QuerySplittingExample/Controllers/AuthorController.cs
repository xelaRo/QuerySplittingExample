using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuerySplittingExample.Data;

namespace QuerySplittingExample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private MyDbContext _dbContext;

        public AuthorController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAuthorsWithCourses()
        {
            var result = _dbContext.Author
                .Include(a => a.Courses)
                .AsSingleQuery()
                .ToList();

            return Ok(result);
        }
    }
}
