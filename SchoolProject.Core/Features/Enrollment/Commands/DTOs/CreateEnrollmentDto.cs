namespace SchoolProject.Core.Features.Enrollment.Commands.DTOs
{
    public class CreateEnrollmentDto
    {
        public Guid StudentId { get; set; }
        public Guid SubjectId { get; set; }
    }
}
