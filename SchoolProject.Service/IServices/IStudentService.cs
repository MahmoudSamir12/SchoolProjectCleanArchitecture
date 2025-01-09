using SchoolProject.Data.Entities;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Service.IServices
{
    public interface IStudentService
    {
        public Task<List<Student>> GetAllStudentsAsync();
        public IQueryable<Student> GetAllStudentsQueryable();
        public IQueryable<Student> FilterStudentsPaginatedQueryable(StudentOrderingEnum orderingEnum, string search);
        public Task<Student?> GetStudentByIdWithIncludeAsync(Guid id);
        public IQueryable<Student> GetStudentsByDepartmentIdQueryable(Guid id);
        public Task<Student?> GetByIdAsync(Guid id);
        public Task<string> AddStudentAsync(Student student);
        public Task<bool> IsNameEnExist(string name);
        public Task<bool> IsNameArExist(string name);
        public Task<bool> IsNameEnExistExcludeSelf(string name, Guid id);
        public Task<bool> IsNameArExistExcludeSelf(string name, Guid id);
        public Task<string> EditStudentAsync(Student student);
        public Task<string> DeleteStudentAsync(Student student);
    }
}
