namespace SchoolProject.Core.Features.Grade.Queries.DTOs
{
    public class GetAllGradesDto
    {
        public Guid Id { get; set; }
        public Guid EnrollmentId { get; set; }
        public Guid AssessmentId { get; set; }
        public decimal Score { get; set; }
        public string LetterGrade { get; set; }
        public DateTime Date { get; set; }
    }
}
