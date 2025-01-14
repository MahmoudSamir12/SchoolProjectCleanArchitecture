using MediatR;
using SchoolProject.Core.Features.Users.Queries.DTOs;
using SchoolProject.Core.Wrappers;

namespace SchoolProject.Core.Features.Users.Queries.Models
{
    public class GetUsersPaginationQuery : IRequest<PaginatedResult<GetUserPaginatedListQueryDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        //public string Search { get; set; } = string.Empty;
    }
}
