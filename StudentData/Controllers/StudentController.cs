using Microsoft.AspNetCore.Mvc;
using StudentData.Models;

namespace StudentData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController(StudentBusiness studentBusiness) : ControllerBase
    {
        private readonly StudentBusiness _studentBusiness = studentBusiness;

        [HttpGet("totalmark/{studentId}")]
        public ActionResult<int> GetTotalMarkObtained(int studentId)
        {
            return _studentBusiness.GetTotalMarkObtained(studentId);
        }

        [HttpGet("totalpercentage/{studentId}")]
        public ActionResult<double> GetTotalPercentageObtained(int studentId)
        {
            return _studentBusiness.GetTotalPercentageObtained(studentId);
        }

        [HttpGet("allmarks/{studentId}")]
        public ActionResult<List<Marksheet>> GetAllMarksById(int studentId)
        {
            return _studentBusiness.GetAllMarksById(studentId);
        }

        [HttpPost("addmarks")]
        public ActionResult AddMarks([FromBody] Marksheet marksheet)
        {
            _studentBusiness.AddMarks(marksheet);
            return Ok();
        }

        [HttpPut("updatemarks")]
        public ActionResult UpdateMarks([FromBody] Marksheet marksheet)
        {
            _studentBusiness.UpdateMarks(marksheet);
            return Ok();
        }

        [HttpGet("studentlist")]
        public ActionResult<List<Student>> GetStudentList()
        {
            return _studentBusiness.GetStudentList();
        }

        [HttpGet("topthree/{class}")]
        public ActionResult<List<Student>> GetTopThree(int @class)
        {
            return _studentBusiness.GetTopThree(@class);
        }
    }
}