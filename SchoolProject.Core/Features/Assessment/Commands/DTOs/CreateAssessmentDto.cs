namespace SchoolProject.Core.Features.Assessment.Commands.DTOs
{
    public class CreateAssessmentDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public Guid SubjectId { get; set; }
    }
}
