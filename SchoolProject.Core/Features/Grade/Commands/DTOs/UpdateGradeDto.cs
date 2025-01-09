namespace SchoolProject.Core.Features.Grade.Commands.DTOs
{
    public class UpdateGradeDto
    {
        public decimal? Score { get; set; }
        public string? LetterGrade { get; set; }
        public DateTime? Date { get; set; }
    }
}
