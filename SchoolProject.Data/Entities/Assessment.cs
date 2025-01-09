using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Assessment : GeneralLocalizableEntity
    {
        public Assessment()
        {
            Grades = new HashSet<Grade>();
            Title = string.Empty;
        }
        public Assessment(Guid subjectId, string title, DateTime dueDate, Subject subject)
            : this()
        {
            SubjectId = subjectId;
            Title = title ?? throw new ArgumentNullException(nameof(title), "Title cannot be null.");
            Subject = subject ?? throw new ArgumentNullException(nameof(subject), "Subject cannot be null.");
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }

        [ForeignKey(nameof(Subject))]
        public Guid SubjectId { get; set; }
        public virtual Subject Subject { get; set; } = null!;
        public virtual ICollection<Grade> Grades { get; set; }

    }
}
