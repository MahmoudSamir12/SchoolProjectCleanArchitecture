using Microsoft.AspNetCore.Identity;

namespace SchoolProject.Data.Entities.Identity
{
    // If I want the Id type int
    // public class User : IdentityUser<int>
    public class User : IdentityUser<Guid>
    {
        public User()
        {
            FullName = string.Empty; // Provide a default value
                                     // Password = string.Empty; // Provide a default value
        }
        public User(string FName, string password)
        {
            FullName = FName ?? throw new ArgumentNullException(nameof(FName), "FullName cannot be null.");
            //Password = password ?? throw new ArgumentNullException(nameof(password), "FullName cannot be null.");
        }
        public string FullName { get; set; }
        //public string Password { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }
}
