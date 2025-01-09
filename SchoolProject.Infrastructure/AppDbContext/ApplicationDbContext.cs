using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<InstructorSubject> InstructorSubjects { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentSubject> DepartmentSubjects { get; set; }
        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<StudentActivity> StudentActivities { get; set; }
        public DbSet<ExtraCurricularActivity> ExtraCurricularActivities { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<SchoolEvent> SchoolEvents { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
               modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
