using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.AppDbContext;
using SchoolProject.Infrastructure.GenericRepos;
using SchoolProject.Infrastructure.IRepositories;

namespace SchoolProject.Infrastructure.Repositories
{
    public class InstructorRepository : GenericRepositoryAsync<Instructor>, IInstructorsRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public InstructorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
