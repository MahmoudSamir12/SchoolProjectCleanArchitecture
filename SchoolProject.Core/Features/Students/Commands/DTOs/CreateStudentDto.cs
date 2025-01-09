using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Core.Features.Students.Commands.DTOs
{
    public class CreateStudentDto
    {
        public CreateStudentDto()
        {
            NameEn = string.Empty;
            NameAr = string.Empty;
            Email = string.Empty;
            Address = string.Empty;
            Phone = string.Empty;
        }
        public CreateStudentDto(string nameEn, string nameAr, string email, string phone)
        {
            NameEn = nameEn ?? throw new ArgumentNullException(nameof(nameEn)); // Ensures name is not null
            NameAr = nameAr ?? throw new ArgumentNullException(nameof(nameAr)); // Ensures name is not null
            Email = email;
            Phone = phone;
        }

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
        [ForeignKey(nameof(Department))]
        public Guid DepartmentId { get; set; }

        [ForeignKey(nameof(Parent))]
        public Guid ParentId { get; set; }
    }
}
