namespace N67.EduCourse.Domain.Entities;

public class Role
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string Name { get; set; } = default!;
}
