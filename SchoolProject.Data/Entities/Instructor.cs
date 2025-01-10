using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Instructor : GeneralLocalizableEntity
    {
        public Instructor(string nameEn, string nameAr, string position, string address, string subject, DateTime hireDate, string image)
        {
            NameEn = nameEn ?? throw new ArgumentNullException(nameof(nameEn)); // Ensures name is not null
            NameAr = nameAr ?? throw new ArgumentNullException(nameof(nameAr)); // Ensures name is not null
            Subject = subject ?? throw new ArgumentNullException(nameof(subject)); // Ensures Subject is not null
            Position = position ?? throw new ArgumentNullException(nameof(position)); // Ensures Subject is not null
            Address = address ?? throw new ArgumentNullException(nameof(address)); // Ensures Subject is not null
            Image = image ?? throw new ArgumentNullException(nameof(image)); // Ensures Subject is not null
            HireDate = hireDate;
            InstructorSubjects = new HashSet<InstructorSubject>();
            Instructors = new HashSet<Instructor>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required, StringLength(100)]
        public string NameEn { get; set; }

        [Required, StringLength(100)]
        public string NameAr { get; set; }

        [StringLength(100)]
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }
        [StringLength(50)]
        public string Subject { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
        public string Image { get; set; }

        public Guid DepartmentId { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty("Instructors")]
        public virtual Department department { get; set; } = null!;


        [InverseProperty("Instructor")]
        public virtual Department departmentManager { get; set; } = null!;

        public Guid SupervisorId { get; set; }
        [ForeignKey(nameof(SupervisorId))]
        [InverseProperty("Instructors")]
        public virtual Instructor Supervisor { get; set; } = null!;

        [InverseProperty("Supervisor")]
        public virtual ICollection<Instructor> Instructors { get; set; }


        [InverseProperty("Instructor")]
        public virtual ICollection<InstructorSubject> InstructorSubjects { get; set; }

    }
}
