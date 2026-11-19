using APIDemoLab.DTO.Request;
using APIDemoLab.DTO.Response;
using APIDemoLab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIDemoLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Courses
        // Lista solo los registros activos (IsActive = true)
        [HttpGet]
        public ActionResult<IEnumerable<CourseResponse>> GetCourses()
        {
            var items = _context.Courses
                .Where(x => x.IsActive)
                .Select(x => new CourseResponse
                {
                    CourseId = x.CourseId,
                    Name = x.Name,
                    Credit = x.Credit
                })
                .ToList();

            return Ok(items);
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public ActionResult<CourseResponse> GetCourse(int id)
        {
            var item = _context.Courses
                .Where(x => x.CourseId == id && x.IsActive)
                .Select(x => new CourseResponse
                {
                    CourseId = x.CourseId,
                    Name = x.Name,
                    Credit = x.Credit
                })
                .FirstOrDefault();

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // POST: api/Courses
        [HttpPost]
        public ActionResult<CourseResponse> PostCourse(CourseRequest request)
        {
            var entity = new Course
            {
                Name = request.Name,
                Credit = request.Credit,
                IsActive = true
            };

            _context.Courses.Add(entity);
            _context.SaveChanges();

            var response = new CourseResponse
            {
                CourseId = entity.CourseId,
                Name = entity.Name,
                Credit = entity.Credit
            };

            return CreatedAtAction(nameof(GetCourse), new { id = entity.CourseId }, response);
        }

        // PUT: api/Courses/5
        [HttpPut("{id}")]
        public IActionResult PutCourse(int id, CourseRequest request)
        {
            var entity = _context.Courses
                .FirstOrDefault(x => x.CourseId == id && x.IsActive);

            if (entity == null)
            {
                return NotFound();
            }

            entity.Name = request.Name;
            entity.Credit = request.Credit;

            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Courses/5
        // Eliminacion LOGICA: no borra la fila, solo marca IsActive = false
        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            var entity = _context.Courses
                .FirstOrDefault(x => x.CourseId == id && x.IsActive);

            if (entity == null)
            {
                return NotFound();
            }

            entity.IsActive = false;
            _context.SaveChanges();

            return NoContent();
        }
    }
}
