using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Department : GeneralLocalizableEntity
    {
        public Department(string departmentNameEn, string departmentNameAr)
        {
            Students = new HashSet<Student>();
            DepartmentSubjects = new HashSet<DepartmentSubject>();
            Instructors = new HashSet<Instructor>();
            DepartmentNameEn = departmentNameEn ?? throw new ArgumentNullException(nameof(departmentNameEn)); // Ensures departmentName is not null
            DepartmentNameAr = departmentNameAr ?? throw new ArgumentNullException(nameof(departmentNameAr)); // Ensures departmentName is not null
        }

        [Key]
        public Guid Id { get; set; }

        [Required, StringLength(100)]
        public string DepartmentNameEn { get; set; }

        [Required, StringLength(100)]
        public string DepartmentNameAr { get; set; }
        public Guid InstManger { get; set; }
        [ForeignKey("InstManger")]
        [InverseProperty("DepartmentManager")]
        public virtual Instructor Instructor { get; set; } = null!;
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }
    }
}
