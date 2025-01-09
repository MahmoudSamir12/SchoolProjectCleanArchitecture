using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Student : GeneralLocalizableEntity
    {
        public Student()
        {
            NameEn = string.Empty;
            NameAr = string.Empty;
            Email = string.Empty;
            Address = string.Empty;
            Phone = string.Empty;
            Enrollments = new HashSet<Enrollment>();
            StudentActivities = new HashSet<StudentActivity>();
        }

        public Student(string name, string nameAr, string email, string phone, Department department, Parent parent)
        {
            NameEn = name ?? throw new ArgumentNullException(nameof(name));
            NameAr = nameAr ?? throw new ArgumentNullException(nameof(nameAr));
            Email = email;
            Phone = phone;
            Department = department ?? throw new ArgumentNullException(nameof(department));
            Parent = parent;
            Enrollments = new HashSet<Enrollment>();
            StudentActivities = new HashSet<StudentActivity>();

        }

        [Key]
        public Guid Id { get; set; }

        [Required, StringLength(100)]
        public string NameEn { get; set; }

        [Required, StringLength(100)]
        public string NameAr { get; set; }

        [StringLength(200), EmailAddress]
        public string Email { get; set; }

        [StringLength(500)]
        public string Address { get; set; } = string.Empty;

        [StringLength(15)]
        public string Phone { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        //Navigation Property
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<StudentActivity> StudentActivities { get; set; }

        [ForeignKey(nameof(Department))]
        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; } = null!;

        [ForeignKey(nameof(Parent))]
        public Guid ParentId { get; set; }
        public virtual Parent Parent { get; set; } = null!;


    }
}
