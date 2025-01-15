using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Users.Commands.Models
{
    public class ChangeUserPasswordCommand : IRequest<Response<string>>
    {
        public Guid Id { get; set; }
        public string CurrentPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
