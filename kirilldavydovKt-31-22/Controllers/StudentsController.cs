using Microsoft.AspNetCore.Mvc;
using kirilldavydovKt_31_22.Models;
using kirilldavydovKt_31_22.Services;

namespace kirilldavydovKt_31_22.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("filter")]
        public async Task<IActionResult> FilterStudents([FromBody] StudentFilter filter)
        {
            var result = await _studentService.GetStudentsAsync(filter);
            return Ok(result);
        }
    }
}