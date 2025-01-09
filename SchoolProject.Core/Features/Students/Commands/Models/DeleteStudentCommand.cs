using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Students.Commands.Models
{
    public class DeleteStudentCommand : IRequest<Response<string>>
    {
        public DeleteStudentCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
