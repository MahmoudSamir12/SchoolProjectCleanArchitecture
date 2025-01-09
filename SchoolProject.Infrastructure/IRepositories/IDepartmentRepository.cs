using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.GenericRepos;

namespace SchoolProject.Infrastructure.IRepositories
{
    public interface IDepartmentRepository : IGenericRepositoryAsync<Department>
    {
    }
}
