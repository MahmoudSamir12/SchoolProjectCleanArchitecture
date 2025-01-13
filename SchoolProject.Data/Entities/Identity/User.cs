using Microsoft.AspNetCore.Identity;

namespace SchoolProject.Data.Entities.Identity
{
    // If I want the Id type int
    // public class User : IdentityUser<int>
    public class User : IdentityUser<Guid>
    {
        public string? Address { get; set; }
        public string? Country { get; set; }
    }
}
