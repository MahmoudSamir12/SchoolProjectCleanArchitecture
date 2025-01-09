using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.AppDbContext;
using SchoolProject.Infrastructure.GenericRepos;
using SchoolProject.Infrastructure.IRepositories;

namespace SchoolProject.Infrastructure.Repositories
{
    public class DepartmentRepository : GenericRepositoryAsync<Department>, IDepartmentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        //OR
        //private DbSet<Department> departments;
        public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            //OR
            //departments = dbContext.Set<Department>();
        }
    }
}
