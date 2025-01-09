using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Data.Entities
{
    public class Subject : GeneralLocalizableEntity
    {
        public Subject()
        {
            SubjectNameEn = string.Empty;
            SubjectNameAr = string.Empty;
            Enrollments = new HashSet<Enrollment>();
            DepartmentSubjects = new HashSet<DepartmentSubject>();
            InstructorSubjects = new HashSet<InstructorSubject>();
            Assessments = new HashSet<Assessment>();
        }
        public Subject(string subjectNameAr, string subjectNameEn)
        {
            SubjectNameEn = subjectNameEn ?? throw new ArgumentNullException(nameof(subjectNameEn));
            SubjectNameAr = subjectNameAr ?? throw new ArgumentNullException(nameof(subjectNameAr)); // Ensures subjectName is not null
            Enrollments = new HashSet<Enrollment>();
            DepartmentSubjects = new HashSet<DepartmentSubject>();
            InstructorSubjects = new HashSet<InstructorSubject>();
            Assessments = new HashSet<Assessment>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required, StringLength(100)]
        public string SubjectNameEn { get; set; }

        [Required, StringLength(100)]
        public string SubjectNameAr { get; set; }
        public int Period { get; set; }

        public virtual ICollection<InstructorSubject> InstructorSubjects { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; }
        public virtual ICollection<Assessment> Assessments { get; set; }
    }
}
