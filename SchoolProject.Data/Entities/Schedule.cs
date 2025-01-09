using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Schedule : GeneralLocalizableEntity
    {
        public Schedule() { }
        public Schedule(Guid instructorSubjectId, DateTime startTime, DateTime endTime, string location, InstructorSubject instructorSubject)
        {
            InstructorSubjectId = instructorSubjectId;
            StartTime = startTime;
            EndTime = endTime;
            Location = location;
            InstructorSubject = instructorSubject ?? throw new ArgumentNullException(nameof(InstructorSubject)); // Ensures name is not null
        }

        //[Key]
        //public Guid Id { get; set; }
        public Guid SubjectId { get; set; } // Foreign key part
        public Guid InstructorId { get; set; } // Foreign key for InstructorId

        [ForeignKey(nameof(InstructorSubject))]
        public Guid InstructorSubjectId { get; set; }

        public virtual InstructorSubject InstructorSubject { get; set; } = null!;

        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }
        public string Location { get; set; } = string.Empty;
    }
}
