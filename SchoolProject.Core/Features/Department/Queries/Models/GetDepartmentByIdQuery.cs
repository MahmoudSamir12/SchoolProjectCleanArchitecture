using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Department.Queries.DTOs;

namespace SchoolProject.Core.Features.Department.Queries.Models
{
    public class GetDepartmentByIdQuery : IRequest<Response<GetDepartmentDetailsDto>>
    {
        public Guid Id { get; set; }
        public int StudentPageNumber { get; set; }
        public int StudentPageSize { get; set; }

        //public GetDepartmentByIdQuery(Guid id)
        //{
        //    Id = id;
        //}
    }
}
