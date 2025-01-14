using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Users.Queries.DTOs;

namespace SchoolProject.Core.Features.Users.Queries.Models
{
    public class GetUserByIdQuery : IRequest<Response<GetUserByIdDto>>
    {
        public Guid Id { get; set; }
        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }

    }
}
