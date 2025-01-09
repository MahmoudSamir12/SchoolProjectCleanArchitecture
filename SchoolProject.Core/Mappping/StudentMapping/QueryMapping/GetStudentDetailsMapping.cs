using SchoolProject.Core.Features.Students.Queries.DTOs;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mappping.StudentMapping
{
    public partial class StudentProfile
    {
        public void GetStudentDetailsMapping()
        {
            CreateMap<Student, GetStudentDetailsDto>()
               //.ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DepartmentName))
               .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Localize(src.Department.DepartmentNameAr, src.Department.DepartmentNameEn)))
               .ForMember(dest => dest.ParentName, opt => opt.MapFrom(src => src.Parent.Name))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));
        }
    }
}
