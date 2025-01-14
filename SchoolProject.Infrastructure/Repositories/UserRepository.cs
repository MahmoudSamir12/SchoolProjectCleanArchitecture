using SchoolProject.Data.Entities.Identity;
using SchoolProject.Infrastructure.AppDbContext;
using SchoolProject.Infrastructure.GenericRepos;
using SchoolProject.Infrastructure.IRepositories;

namespace SchoolProject.Infrastructure.Repositories
{
    public class UserRepository : GenericRepositoryAsync<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
