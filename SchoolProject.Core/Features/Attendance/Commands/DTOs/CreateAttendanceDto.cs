namespace SchoolProject.Core.Features.Attendance.Commands.DTOs
{
    public class CreateAttendanceDto
    {
        public Guid EnrollmentId { get; set; }
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }
    }
}
