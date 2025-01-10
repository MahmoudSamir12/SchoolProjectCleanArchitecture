using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Department.Queries.DTOs;
using SchoolProject.Core.Features.Department.Queries.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities;
using SchoolProject.Service.IServices;
using System.Linq.Expressions;

namespace SchoolProject.Core.Features.Department.Queries.Handlers
{
    public class DepartmentQueryHandler : ResponseHandler,
                     IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentDetailsDto>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IMapper _mapper;
        private readonly IDepartmentService _departmentService;
        private readonly IStudentService _studentService;
        #endregion

        #region Constructor
        public DepartmentQueryHandler(IMapper mapper, IDepartmentService departmentService,
                               IStudentService studentService,
                               IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _localizer = localizer;
            _mapper = mapper;
            _departmentService = departmentService;
            _studentService = studentService;
        }
        #endregion

        #region HandelGetDepartmentById
        public async Task<Response<GetDepartmentDetailsDto>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var department = await _departmentService.GetDepartmentByIdWithIncludeAsync(request.Id);
            //if (student == null) return NotFound<GetStudentDetailsDto>("Student Not Found");
            if (department == null)
            {
                var notFoundMessage = $"Department with ID {request.Id} was not found in the database.";
                return NotFound<GetDepartmentDetailsDto>(_localizer[SharedResourcesKeys.NotFound],
                    new List<string> { notFoundMessage });

            }
            var mappedDepartment = _mapper.Map<GetDepartmentDetailsDto>(department);
            //Pagination
            Expression<Func<Student, StudentResponse>> expression = e => new StudentResponse(e.Id, e.Localize(e.NameAr, e.NameEn));
            var studentQuerable = _studentService.GetStudentsByDepartmentIdQueryable(request.Id);
            var paginatedList = await studentQuerable.Select(expression).ToPaginatedListAsync(request.StudentPageNumber, request.StudentPageSize);
            mappedDepartment.StudentList = paginatedList;
            return Success(mappedDepartment);

        }
        //ca248b7a-0a98-485a-889f-27f420bc41ef
        #endregion


    }
}
