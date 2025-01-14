using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Service.IServices
{
    public interface IUserService
    {
        public Task<string> AddUserAsync(User user);
    }
}
