using SchoolProject.Core.Features.Staff.Commands.DTOs;

namespace SchoolProject.Core.Features.Teacher.Commands.DTOs
{
    public class UpdateInstructorDto : UpdateStaffDto
    {
        public string? Subject { get; set; }
        public DateTime? HireDate { get; set; }
    }
}
