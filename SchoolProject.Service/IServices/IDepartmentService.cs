using SchoolProject.Data.Entities;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Service.IServices
{
    public interface IDepartmentService
    {
        public Task<List<Department>> GetAllDepartmentsAsync();
        public IQueryable<Department> GetAllDepartmentsQueryable();
        public IQueryable<Department> FilterDepartmentsPaginatedQueryable(StudentOrderingEnum orderingEnum, string search);
        public Task<Department?> GetDepartmentByIdWithIncludeAsync(Guid id);
        public Task<Department?> GetByIdAsync(Guid id);
        public Task<string> AddDepartmentAsync(Department department);
        public Task<bool> IsNameEnExist(string name);
        public Task<bool> IsNameArExist(string name);
        public Task<bool> IsNameEnExistExcludeSelf(string name, Guid id);
        public Task<bool> IsNameArExistExcludeSelf(string name, Guid id);
        public Task<string> EditDepartmentAsync(Department department);
        public Task<string> DeleteDepartmentAsync(Department department);
    }
}
