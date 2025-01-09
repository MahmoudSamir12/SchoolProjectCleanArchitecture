using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Enrollment : GeneralLocalizableEntity
    {
        public Enrollment()
        {
            Grades = new HashSet<Grade>();
            Attendances = new HashSet<Attendance>();
        }

        public Enrollment(Guid studentId, Guid subjectId, Student student, Subject subject) : this()
        {
            StudentId = studentId;
            SubjectId = subjectId;
            Student = student ?? throw new ArgumentNullException(nameof(student)); // Ensures Student is not null
            Subject = subject ?? throw new ArgumentNullException(nameof(subject)); // Ensures Subject is not null
        }

        //[Key]
        //public Guid Id { get; set; }


        [Key]
        public Guid StudentId { get; set; }
        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; } = null!;


        [Key]
        public Guid SubjectId { get; set; }
        [ForeignKey(nameof(SubjectId))]
        public virtual Subject Subject { get; set; } = null!;

        public virtual ICollection<Grade> Grades { get; set; } = new HashSet<Grade>();
        public virtual ICollection<Attendance> Attendances { get; set; } = new HashSet<Attendance>();

    }
}
