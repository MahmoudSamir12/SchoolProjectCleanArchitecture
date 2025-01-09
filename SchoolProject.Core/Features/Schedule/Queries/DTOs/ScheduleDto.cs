namespace SchoolProject.Core.Features.Schedule.Queries.DTOs
{
    public class ScheduleDto
    {
        public Guid Id { get; set; }
        public Guid SubjectTeacherId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
    }
}
