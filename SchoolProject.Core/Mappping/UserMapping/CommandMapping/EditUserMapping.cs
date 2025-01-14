using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Mappping.UserMapping
{
    public partial class UserProfile
    {
        public void EditUserMapping()
        {
            CreateMap<EditUserCommand, User>();
        }
    }
}
