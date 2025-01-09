using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Staff : GeneralLocalizableEntity
    {
        public Staff()
        {
            Staffs = new HashSet<Staff>();
        }
        public Staff(string name, string nameAr, string position)
        {
            NameEn = name ?? throw new ArgumentNullException(nameof(name)); // Ensures name is not null
            NameAr = nameAr ?? throw new ArgumentNullException(nameof(nameAr)); // Ensures name is not null
            Position = position;
            Staffs = new HashSet<Staff>();
        }


        [Key]
        public Guid Id { get; set; }

        [Required, StringLength(100)]
        public string NameEn { get; set; }

        [Required, StringLength(100)]
        public string NameAr { get; set; }

        [StringLength(100)]
        public string Position { get; set; }
        public Guid SupervisorId { get; set; }
        public decimal Salary { get; set; }


        [ForeignKey(nameof(SupervisorId))]
        [InverseProperty("Staffs")]
        public virtual Staff Supervisor { get; set; } = null!;

        [InverseProperty("Supervisor")]
        public virtual ICollection<Staff> Staffs { get; set; }
    }
}
