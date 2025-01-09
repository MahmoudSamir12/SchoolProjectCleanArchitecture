namespace SchoolProject.Core.Features.Subject.Queries.DTOs
{
    public class GetAllSubjectsDto
    {
        public Guid Id { get; set; }
        public string SubjectName { get; set; }
        public DateTime Period { get; set; }
    }
}
