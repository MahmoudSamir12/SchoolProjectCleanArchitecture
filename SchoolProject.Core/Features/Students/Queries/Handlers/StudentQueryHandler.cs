using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Queries.DTOs;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities;
using SchoolProject.Service.IServices;
using System.Linq.Expressions;

namespace SchoolProject.Core.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler : ResponseHandler,
                    IRequestHandler<GetAllStudentsQuery, Response<List<GetAllStudentsDto>>>,
                    IRequestHandler<GetStudentByIdQuery, Response<GetStudentDetailsDto>>,
                    IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentPaginatedListDto>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public StudentQueryHandler(IStudentService studentService, IMapper mapper,
                                    IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _studentService = studentService;
            _mapper = mapper;
            _localizer = localizer;
        }
        public async Task<Response<List<GetAllStudentsDto>>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _studentService.GetAllStudentsAsync();
            var mappedStudents = _mapper.Map<List<GetAllStudentsDto>>(studentList);
            var result = Success(mappedStudents);
            result.Meta = new { Count = mappedStudents.Count() };
            return result;
        }

        public async Task<Response<GetStudentDetailsDto>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdWithIncludeAsync(request.Id);
            if (student == null) return NotFound<GetStudentDetailsDto>(_localizer[SharedResourcesKeys.NotFound]);
            var mappedStudent = _mapper.Map<GetStudentDetailsDto>(student);
            return Success(mappedStudent);
        }

        public async Task<PaginatedResult<GetStudentPaginatedListDto>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, GetStudentPaginatedListDto>> expression = e => new GetStudentPaginatedListDto(e.Id, e.Localize(e.NameAr, e.NameEn), e.Email, e.Address, e.Phone, e.DateOfBirth, e.Department.DepartmentNameAr);
            var filterQuery = _studentService.FilterStudentsPaginatedQueryable(request.OrderBy, request.Search);
            var paginatedList = await filterQuery.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            paginatedList.Meta = new { Count = paginatedList.Data.Count() };
            return paginatedList;
        }
    }
}
