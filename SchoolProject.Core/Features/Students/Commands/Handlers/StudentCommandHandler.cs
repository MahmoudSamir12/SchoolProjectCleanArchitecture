using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities;
using SchoolProject.Service.IServices;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler,
                    IRequestHandler<AddStudentCommand, Response<string>>,
                    IRequestHandler<EditStudentCommand, Response<string>>,
                    IRequestHandler<DeleteStudentCommand, Response<string>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;
        public StudentCommandHandler(IStudentService studentService, IMapper mapper,
                                IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _studentService = studentService;
            _mapper = mapper;
            _localizer = localizer;
        }

        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var mappedStudent = _mapper.Map<Student>(request);
            var addedStudent = await _studentService.AddStudentAsync(mappedStudent);
            if (addedStudent == "Success") return Created("");
            else return BadRequest<string>();

        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            var existedStudent = await _studentService.GetByIdAsync(request.Id);
            if (existedStudent == null) return NotFound<string>("Student Not Found");

            //var mappedStudent = _mapper.Map<Student>(request);
            var mappedStudent = _mapper.Map(request, existedStudent);
            var updatedStudent = await _studentService.EditStudentAsync(mappedStudent);

            if (updatedStudent == "Success")
                return Success($"Updated Successfully {mappedStudent.Id}");
            else
                return BadRequest<string>();

        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetByIdAsync(request.Id);
            if (student == null) return NotFound<string>("Student Not Found");

            var result = await _studentService.DeleteStudentAsync(student);

            if (result == "Success")
                return Deleted<string>($"Student Deleted Successfully {request.Id}");
            else
                return BadRequest<string>();
        }
    }
}