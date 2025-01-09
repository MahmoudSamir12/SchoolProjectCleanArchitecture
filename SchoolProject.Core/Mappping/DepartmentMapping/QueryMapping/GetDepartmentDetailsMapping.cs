using SchoolProject.Core.Features.Department.Queries.DTOs;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mappping.DepartmentMapping
{
    public partial class DepartmentProfile
    {
        public void GetDepartmentDetailsMapping()
        {
            CreateMap<Department, GetDepartmentDetailsDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Localize(src.DepartmentNameAr, src.DepartmentNameEn)))
                //.ForMember(dest => dest.StudentList, opt => opt.MapFrom(src => src.Students))
                .ForMember(dest => dest.SubjectList, opt => opt.MapFrom(src => src.DepartmentSubjects))
                .ForMember(dest => dest.InstructorList, opt => opt.MapFrom(src => src.Instructors))
                .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Instructor.Localize(src.Instructor.NameAr, src.Instructor.NameEn)));


            CreateMap<DepartmentSubject, SubjectResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SubjectId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Subject.Localize(src.Subject.SubjectNameAr, src.Subject.SubjectNameEn)));

            //CreateMap<Student, StudentResponse>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));

            CreateMap<Instructor, InstructorResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));


        }
    }
}
