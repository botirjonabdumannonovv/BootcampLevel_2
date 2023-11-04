using Microsoft.EntityFrameworkCore;

using N67.EduCourse.Application.Common;
using N67.EduCourse.Infrastructure.Common;
using N67.EduCourse.Persistence.DataContext;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDataContext>(option =>
    option
    .UseNpgsql("Host=localhost;Port=5433;Database=EduCourses;Username=postgres;Password=0777")
);


builder.Services
    .AddScoped<IUserService, UserService>()
    .AddScoped<IRoleService, RoleService>()
    .AddScoped<ICourseService, CourseService>()
    .AddScoped<IStudentCourseService, StudentCourseService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();



app.MapControllers();

app.Run();