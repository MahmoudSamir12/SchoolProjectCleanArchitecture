using SchoolProject.Data.Entities.Identity;
using SchoolProject.Infrastructure.IRepositories;
using SchoolProject.Service.IServices;

namespace SchoolProject.Service.Services.Abstractions
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }



        #region AddUserAsync
        public async Task<string> AddUserAsync(User user)
        {
            await _userRepository.AddAsync(user);
            return "Success";
        }
        #endregion

    }
}
