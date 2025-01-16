using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Service.IServices
{
    public interface IAuthenticationService
    {
        public Task<string> GetJWTToken(User user);
    }
}