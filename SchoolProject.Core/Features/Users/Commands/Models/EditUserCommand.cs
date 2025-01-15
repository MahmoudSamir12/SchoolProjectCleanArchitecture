using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Users.Commands.Models
{
    public class EditUserCommand : IRequest<Response<string>>
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
