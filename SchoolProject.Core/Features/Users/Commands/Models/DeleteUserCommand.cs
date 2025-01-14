using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Users.Commands.Models
{
    public class DeleteUserCommand : IRequest<Response<string>>
    {
        public Guid Id { get; set; }
        public DeleteUserCommand(Guid id)
        {
            Id = id;
        }
    }
}
