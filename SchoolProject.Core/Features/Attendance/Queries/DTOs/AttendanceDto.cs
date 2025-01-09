namespace SchoolProject.Core.Features.Attendance.Queries.DTOs
{
    public class AttendanceDto
    {
        public Guid Id { get; set; }
        public Guid EnrollmentId { get; set; }
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }
    }
}
