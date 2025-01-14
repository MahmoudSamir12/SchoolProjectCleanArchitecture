using SchoolProject.Core.Features.Users.Queries.DTOs;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Mappping.UserMapping
{
    public partial class UserProfile
    {
        public void GetUsersPaginationMapping()
        {
            CreateMap<User, GetUserPaginatedListQueryDto>();
        }
    }
}
