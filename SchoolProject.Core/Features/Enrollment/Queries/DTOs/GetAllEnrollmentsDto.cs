namespace SchoolProject.Core.Features.Enrollment.Queries.DTOs
{
    public class GetAllEnrollmentsDto
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid SubjectId { get; set; }
    }
}
