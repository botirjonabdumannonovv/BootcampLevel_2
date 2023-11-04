namespace N67.EduCourse.Domain.Entities;

public class UserSettings
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public bool IsDarkMode { get; set; }
}
