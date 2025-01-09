using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class StudentActivity : GeneralLocalizableEntity
    {
        public StudentActivity() { }
        public StudentActivity(Guid studentId, Guid activityId, Student student, ExtraCurricularActivity extraCurricularActivity)
        {
            StudentId = studentId;
            ExtraCurricularActivityId = activityId;
            Student = student ?? throw new ArgumentNullException(nameof(student)); // Ensures Student is not null
            ExtraCurricularActivity = extraCurricularActivity ?? throw new ArgumentNullException(nameof(extraCurricularActivity)); // Ensures ExtraCurricularActivity is not null
        }

        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Student))]
        public Guid StudentId { get; set; }
        public virtual Student? Student { get; set; }

        [ForeignKey(nameof(ExtraCurricularActivity))]
        public Guid ExtraCurricularActivityId { get; set; }
        public virtual ExtraCurricularActivity? ExtraCurricularActivity { get; set; }
    }
}
