using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Instructor : Staff
    {
        public Instructor() : base(string.Empty, string.Empty, string.Empty)
        {
            InstructorSubjects = new HashSet<InstructorSubject>();
        }
        public Instructor(string name, string nameAr, string position, string subject, DateTime hireDate)
            : base(name, nameAr, position)
        {
            Subject = subject ?? throw new ArgumentNullException(nameof(subject)); // Ensures Subject is not null
            HireDate = hireDate;
            InstructorSubjects = new HashSet<InstructorSubject>();
        }

        [StringLength(50)]
        public string Subject { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }


        [ForeignKey(nameof(Department))]
        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; } = null!;


        [InverseProperty("Instructor")]
        public virtual Department DepartmentManager { get; set; } = null!;

        public virtual ICollection<InstructorSubject> InstructorSubjects { get; set; }
    }
}
