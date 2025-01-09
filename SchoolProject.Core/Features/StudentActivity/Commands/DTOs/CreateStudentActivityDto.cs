namespace SchoolProject.Core.Features.StudentActivity.Commands.DTOs
{
    public class CreateStudentActivityDto
    {
        public Guid StudentId { get; set; }
        public Guid ExtraCurricularActivityId { get; set; }
    }
}
