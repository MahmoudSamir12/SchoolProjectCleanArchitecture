using SchoolProject.Core.Features.Staff.Queries.DTOs;

namespace SchoolProject.Core.Features.Teacher.Queries.DTOs
{
    public class GetAllInstructorsDto : GetAllStaffDto
    {
        public string Subject { get; set; }
        public DateTime HireDate { get; set; }
    }
}
