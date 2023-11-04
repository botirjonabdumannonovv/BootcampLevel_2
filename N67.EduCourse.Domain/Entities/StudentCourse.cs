namespace N67.EduCourse.Domain.Entities;

public class StudentCourse
{
    public Guid Id { get; set; }

    public Guid StudentId { get; set; }

    public Guid CourseId { get; set; }
}
