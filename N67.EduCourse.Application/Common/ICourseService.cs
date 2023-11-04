using N67.EduCourse.Domain.Entities;

namespace N67.EduCourse.Application.Common;

public interface ICourseService
{
    IQueryable<Course> Get();
    IQueryable<Course> Get(IEnumerable<Guid> ids);
    ValueTask<Course> GetByIdAsync(Guid Id);
    ValueTask<Course> Create(Course course);
    ValueTask<User> AddStudent(User student, Guid courseId);
    ValueTask<User> AddTeacher(User teacher, Guid courseId);
}
