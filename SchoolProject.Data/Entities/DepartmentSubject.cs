using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class DepartmentSubject : GeneralLocalizableEntity
    {
        public DepartmentSubject() { }

        public DepartmentSubject(Subject subject, Department department)
        {
            Subject = subject ?? throw new ArgumentNullException(nameof(subject)); // Ensures Subject is not null
            Department = department ?? throw new ArgumentNullException(nameof(department)); // Ensures Department is not null
        }

        //[Key]
        //public Guid Id { get; set; }



        [Key]
        public Guid SubjectId { get; set; }
        [ForeignKey(nameof(SubjectId))]
        public virtual Subject Subject { get; set; } = null!;

        [Key]
        public Guid DepartmentId { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        public virtual Department Department { get; set; } = null!;

    }
}
