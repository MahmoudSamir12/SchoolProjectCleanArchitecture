using SchoolProject.Core.Features.Staff.Commands.DTOs;

namespace SchoolProject.Core.Features.Teacher.Commands.DTOs
{
    public class CreateInstructorDto : CreateStaffDto
    {
        public string Subject { get; set; }
        public DateTime HireDate { get; set; }
    }

}
