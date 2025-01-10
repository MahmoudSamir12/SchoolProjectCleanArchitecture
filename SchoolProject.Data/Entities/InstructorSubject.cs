using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class InstructorSubject : GeneralLocalizableEntity
    {
        public InstructorSubject()
        {
            Schedules = new HashSet<Schedule>();
        }
        public InstructorSubject(Guid instructorId, Guid subjectId, Instructor instructor, Subject subject)
        {
            InstructorId = instructorId;
            SubjectId = subjectId;
            Instructor = instructor ?? throw new ArgumentNullException(nameof(instructor)); // Ensures Teacher is not null
            Subject = subject ?? throw new ArgumentNullException(nameof(subject)); // Ensures Subject is not null
            Schedules = new HashSet<Schedule>();
        }

        //[Key]
        //public Guid Id { get; set; }


        [Key]
        public Guid InstructorId { get; set; }
        [ForeignKey(nameof(InstructorId))]
        [InverseProperty("InstructorSubjects")]
        public virtual Instructor? Instructor { get; set; }

        [Key]
        public Guid SubjectId { get; set; }
        [ForeignKey(nameof(SubjectId))]
        [InverseProperty("InstructorSubjects")]
        public virtual Subject Subject { get; set; } = null!;

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
