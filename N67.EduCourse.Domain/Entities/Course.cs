namespace N67.EduCourse.Domain.Entities;

public class Course
{
    public Guid Id { get; set; }

    public Guid TeacherId { get; set; }

    public string Name { get; set; }

    public int StudentsCount { get; set; }
}
