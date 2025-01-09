namespace SchoolProject.Core.Features.Assessment.Queries.DTOs
{
    public class GetAllAssessmentsDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public Guid SubjectId { get; set; }
    }
}
