using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Data.Entities
{
    public class ExtraCurricularActivity : GeneralLocalizableEntity
    {
        public ExtraCurricularActivity(string name, string description)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name)); // Ensures name is not null
            StudentActivities = new HashSet<StudentActivity>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public virtual ICollection<StudentActivity> StudentActivities { get; set; }
    }
}
