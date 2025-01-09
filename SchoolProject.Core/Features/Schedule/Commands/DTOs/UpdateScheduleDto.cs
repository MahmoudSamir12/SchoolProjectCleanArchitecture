namespace SchoolProject.Core.Features.Schedule.Commands.DTOs
{
    public class UpdateScheduleDto
    {
        public Guid? SubjectTeacherId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? Location { get; set; }
    }
}
