namespace SchoolProject.Core.Features.SchoolEvent.Commands.DTOs
{
    public class CreateSchoolEventDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime EventDate { get; set; }
    }
}
