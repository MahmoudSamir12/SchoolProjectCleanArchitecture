using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.GenericRepos;

namespace SchoolProject.Infrastructure.IRepositories
{
    public interface IInstructorsRepository : IGenericRepositoryAsync<Instructor>
    {
    }
}
