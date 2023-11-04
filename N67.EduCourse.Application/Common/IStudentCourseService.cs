using N67.EduCourse.Domain.Entities;

namespace N67.EduCourse.Application.Common;

public interface IStudentCourseService
{
    ValueTask<IEnumerable<User>> GetCourseStudentsById(Guid courseId);
    ValueTask<IEnumerable<Course>> GetStudentCoursesById(Guid strudentId);

    ValueTask<StudentCourse> Create(StudentCourse studentCourse);
}
