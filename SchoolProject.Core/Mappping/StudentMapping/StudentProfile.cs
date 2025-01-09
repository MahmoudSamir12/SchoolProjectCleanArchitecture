using AutoMapper;

namespace SchoolProject.Core.Mappping.StudentMapping
{
    public partial class StudentProfile : Profile
    {
        public StudentProfile()
        {
            GetAllStudentsMapping();
            GetStudentDetailsMapping();
            AddStudentMapping();
            EditStudentMapping();
        }
    }
}
