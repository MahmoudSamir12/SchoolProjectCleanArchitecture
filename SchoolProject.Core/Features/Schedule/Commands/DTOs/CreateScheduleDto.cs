namespace SchoolProject.Core.Features.Schedule.Commands.DTOs
{
    public class CreateScheduleDto
    {
        public Guid SubjectTeacherId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
    }
}
