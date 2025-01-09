using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.AppDbContext;
using SchoolProject.Infrastructure.GenericRepos;
using SchoolProject.Infrastructure.IRepositories;

namespace SchoolProject.Infrastructure.Repositories
{
    public class SubjectRepository : GenericRepositoryAsync<Subject>, ISubjectRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public SubjectRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
