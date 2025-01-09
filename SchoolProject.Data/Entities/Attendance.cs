using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Attendance : GeneralLocalizableEntity
    {
        public Attendance() { }
        public Attendance(Guid enrollmentId, DateTime date, bool isPresent, Enrollment enrollment)
        {
            EnrollmentId = enrollmentId;
            Date = date;
            IsPresent = isPresent;
            Enrollment = enrollment ?? throw new ArgumentNullException(nameof(enrollment)); // Ensure Enrollment is not null
        }

        //[Key]
        //public Guid Id { get; set; }

        [ForeignKey(nameof(Enrollment))]
        public Guid EnrollmentId { get; set; }  // This should reference Enrollment
        public virtual Enrollment? Enrollment { get; set; }
        public Guid SubjectId { get; set; } // Additional property for composite key
        public Guid StudentId { get; set; } // Additional property for composite key

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }


    }
}
