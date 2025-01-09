using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Grade : GeneralLocalizableEntity
    {
        public Grade()
        {
            LetterGrade = string.Empty;
        }
        public Grade(decimal score, string letterGrade, DateTime date, Enrollment enrollment, Assessment assessment)
        {
            Score = score;
            LetterGrade = letterGrade ?? throw new ArgumentNullException(nameof(letterGrade));
            Date = date;
            Enrollment = enrollment ?? throw new ArgumentNullException(nameof(enrollment)); // Ensures Enrollment is not null
            Assessment = assessment ?? throw new ArgumentNullException(nameof(assessment)); // Ensures Enrollment is not null
        }

        //[Key]
        //public Guid Id { get; set; }
        public Guid StudentId { get; set; } // Foreign Key part
        public virtual Student Student { get; set; } = null!;
        public Guid SubjectId { get; set; } // Foreign Key part
        public virtual Subject Subject { get; set; } = null!;

        [ForeignKey(nameof(Enrollment))]
        public Guid EnrollmentId { get; set; }
        public virtual Enrollment Enrollment { get; set; } = null!;

        [ForeignKey(nameof(Assessment))]
        public Guid AssessmentId { get; set; }
        public virtual Assessment Assessment { get; set; } = null!;

        public decimal Score { get; set; }

        [Required]
        public string LetterGrade { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
