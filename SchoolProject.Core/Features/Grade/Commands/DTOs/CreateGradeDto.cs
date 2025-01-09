namespace SchoolProject.Core.Features.Grade.Commands.DTOs
{
    public class CreateGradeDto
    {
        public Guid EnrollmentId { get; set; }
        public Guid AssessmentId { get; set; }
        public decimal Score { get; set; }
        public string LetterGrade { get; set; }
        public DateTime Date { get; set; }
    }
}
