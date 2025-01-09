using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Data.Entities
{
    public class SchoolEvent : GeneralLocalizableEntity
    {
        public SchoolEvent(string title, DateTime eventDate)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title)); // Ensures title is not null
            EventDate = eventDate;
            Participants = new HashSet<Student>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required, StringLength(150)]
        public string Title { get; set; }

        public string Description { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }
        public virtual ICollection<Student> Participants { get; set; }
    }
}
