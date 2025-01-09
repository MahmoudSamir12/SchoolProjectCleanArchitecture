using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Data.Entities
{
    public class Parent : GeneralLocalizableEntity
    {
        public Parent(string name, string email, string phone)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name)); // Ensures name is not null
            Email = email;
            Phone = phone;
            Childrens = new HashSet<Student>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }
        public virtual ICollection<Student> Childrens { get; set; }
    }
}
