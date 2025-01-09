using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Data.Entities
{
    //Represents the physical classroom within the school.
    public class Classroom : GeneralLocalizableEntity
    {
        public Classroom(string roomNumber, int capacity)
        {
            RoomNumber = roomNumber ?? throw new ArgumentNullException(nameof(roomNumber));
            Capacity = capacity;
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string RoomNumber { get; set; }

        [Range(1, 100)]
        public int Capacity { get; set; }

    }
}
