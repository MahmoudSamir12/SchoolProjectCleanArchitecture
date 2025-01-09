using SchoolProject.Core.Features.Staff.Queries.DTOs;

namespace SchoolProject.Core.Features.Teacher.Queries.DTOs
{
    public class GetInstructorDetailsDto : GetStaffDetailsDto
    {
        public string Subject { get; set; }
        public DateTime HireDate { get; set; }
    }
}
