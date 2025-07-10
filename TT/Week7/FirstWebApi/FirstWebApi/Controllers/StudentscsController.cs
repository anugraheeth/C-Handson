using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentscsController : ControllerBase
    {
        private static List<Studentcs> students = new List<Studentcs>
        {
            new Studentcs(1, "John Doe", "123-456-7890"),
            new Studentcs(2, "Jane Smith", "987-654-3210"),
            new Studentcs(3, "Alice Johnson", "555-123-4567"),
        };

        private readonly ILogger<StudentscsController> _logger;
        public StudentscsController(ILogger<StudentscsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Studentcs> Get()
        {
            return students;
        }

        [HttpGet("{id}")]
        public ActionResult<Studentcs> Get(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return student;
        }
        [HttpPost]
        public ActionResult<Studentcs> Post([FromBody] Studentcs student)
        {
            if (student == null)
            {
                return BadRequest("Student cannot be null");
            }
            students.Add(student);
            // Log the addition of a new student
            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }
    }
}
