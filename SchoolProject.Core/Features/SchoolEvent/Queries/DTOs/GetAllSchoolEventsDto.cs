namespace SchoolProject.Core.Features.SchoolEvent.Queries.DTOs
{
    public class GetAllSchoolEventsDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime EventDate { get; set; }
    }
}
