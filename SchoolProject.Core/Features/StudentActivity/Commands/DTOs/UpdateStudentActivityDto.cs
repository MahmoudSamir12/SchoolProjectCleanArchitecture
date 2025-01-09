namespace SchoolProject.Core.Features.StudentActivity.Commands.DTOs
{
    public class UpdateStudentActivityDto
    {
        public Guid StudentId { get; set; }
        public Guid ExtraCurricularActivityId { get; set; }
    }
}
