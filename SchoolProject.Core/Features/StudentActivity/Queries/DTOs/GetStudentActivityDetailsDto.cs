namespace SchoolProject.Core.Features.StudentActivity.Queries.DTOs
{
    public class GetStudentActivityDetailsDto
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid ExtraCurricularActivityId { get; set; }
    }
}
