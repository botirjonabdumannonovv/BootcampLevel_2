﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using N67.EduCourse.Application.Common;

namespace N67.EduCourse.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentCourseController : ControllerBase
{
    private readonly IStudentCourseService studentCourseService;

    public StudentCourseController(IStudentCourseService studentCourseService)
    {
        this.studentCourseService = studentCourseService;
    }

    [HttpGet("{studentId:Guid}/get-studentCourses")]
    public IActionResult GetStudentCourses(Guid studentId) => Ok(studentCourseService.GetStudentCoursesById(studentId));
    [HttpGet("{courseId:Guid}/get-courseStudents")]
    public IActionResult GetCourseStudents(Guid courseId) => Ok(studentCourseService.GetCourseStudentsById(courseId));
}
