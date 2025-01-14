using SchoolProject.Data.Entities.Identity;
using SchoolProject.Infrastructure.GenericRepos;

namespace SchoolProject.Infrastructure.IRepositories
{
    public interface IUserRepository : IGenericRepositoryAsync<User>
    {
    }
}
