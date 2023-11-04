using N67.EduCourse.Application.Common;
using N67.EduCourse.Domain.Entities;
using N67.EduCourse.Persistence.DataContext;

namespace N67.EduCourse.Infrastructure.Common;

public class StudentCourseService : IStudentCourseService
{
    private readonly IUserService _userService;
    private readonly ICourseService _courseService;
    private readonly AppDataContext _dbContext;
    private readonly IRoleService _roleService;
    public StudentCourseService(IUserService userService, ICourseService courseService
        , AppDataContext dbContext, IRoleService roleService)
    {
        _userService = userService;
        _courseService = courseService;
        _dbContext = dbContext;
        _roleService = roleService;
    }

    public async ValueTask<StudentCourse> Create(StudentCourse studentCourse)
    {
        await _dbContext.AddAsync(studentCourse);

        await _dbContext.SaveChangesAsync();

        return studentCourse;
    }

    public ValueTask<IEnumerable<User>> GetCourseStudentsById(Guid courseId)
    {
        var studentsIds = _roleService.GetStudents().ToList();

        var studentCourse = _dbContext.Students
            .Where(student => student.CourseId == courseId).Select(s => s.StudentId);


        var stud = studentsIds.Where(st => studentCourse.Any(id => id == st));

        return new(_userService.Get(stud));
    }

    public ValueTask<IEnumerable<Course>> GetStudentCoursesById(Guid strudentId)
    {
        var courses = _dbContext.Students
            .Where(student => student.StudentId == strudentId)
            .Select(s => s.CourseId);

        return new(_courseService.Get(courses));

    }
}
