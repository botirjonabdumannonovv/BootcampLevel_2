using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using N67.EduCourse.Application.Common;
using N67.EduCourse.Domain.Entities;

namespace N67.EduCourse.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CoursesController(ICourseService courseService)
    {
        _courseService = courseService;
    }
    [HttpGet]
    public IActionResult Get() => Ok(_courseService.Get());
    [HttpPost]
    public IActionResult Create([FromBody] Course course) => Ok(_courseService.Create(course));

    [HttpPost("{courseId:Guid}/addstudent")]
    public IActionResult AddStudent([FromRoute] Guid courseId, [FromBody] User student) => Ok(_courseService.AddStudent(student, courseId));
    [HttpPost("{courseId:Guid}/addteacher")]
    public IActionResult AddTeacher([FromRoute] Guid courseId, [FromBody] User teacher) => Ok(_courseService.AddTeacher(teacher, courseId));

}
