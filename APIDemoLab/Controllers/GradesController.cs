using APIDemoLab.DTO.Request;
using APIDemoLab.DTO.Response;
using APIDemoLab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIDemoLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GradesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Grades
        // Lista solo los registros activos (IsActive = true)
        [HttpGet]
        public ActionResult<IEnumerable<GradeResponse>> GetGrades()
        {
            var items = _context.Grades
                .Where(x => x.IsActive)
                .Select(x => new GradeResponse
                {
                    GradeId = x.GradeId,
                    Name = x.Name,
                    Description = x.Description
                })
                .ToList();

            return Ok(items);
        }

        // GET: api/Grades/5
        [HttpGet("{id}")]
        public ActionResult<GradeResponse> GetGrade(int id)
        {
            var item = _context.Grades
                .Where(x => x.GradeId == id && x.IsActive)
                .Select(x => new GradeResponse
                {
                    GradeId = x.GradeId,
                    Name = x.Name,
                    Description = x.Description
                })
                .FirstOrDefault();

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // POST: api/Grades
        [HttpPost]
        public ActionResult<GradeResponse> PostGrade(GradeRequest request)
        {
            var entity = new Grade
            {
                Name = request.Name,
                Description = request.Description,
                IsActive = true
            };

            _context.Grades.Add(entity);
            _context.SaveChanges();

            var response = new GradeResponse
            {
                GradeId = entity.GradeId,
                Name = entity.Name,
                Description = entity.Description
            };

            return CreatedAtAction(nameof(GetGrade), new { id = entity.GradeId }, response);
        }

        // PUT: api/Grades/5
        [HttpPut("{id}")]
        public IActionResult PutGrade(int id, GradeRequest request)
        {
            var entity = _context.Grades
                .FirstOrDefault(x => x.GradeId == id && x.IsActive);

            if (entity == null)
            {
                return NotFound();
            }

            entity.Name = request.Name;
            entity.Description = request.Description;

            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Grades/5
        // Eliminacion LOGICA: no borra la fila, solo marca IsActive = false
        [HttpDelete("{id}")]
        public IActionResult DeleteGrade(int id)
        {
            var entity = _context.Grades
                .FirstOrDefault(x => x.GradeId == id && x.IsActive);

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
