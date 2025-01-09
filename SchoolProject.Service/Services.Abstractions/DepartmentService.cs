using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Helpers;
using SchoolProject.Infrastructure.IRepositories;
using SchoolProject.Service.IServices;

namespace SchoolProject.Service.Services.Abstractions
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public Task<List<Department>> GetAllDepartmentsAsync()
        {
            throw new NotImplementedException();
        }
        public IQueryable<Department> GetAllDepartmentsQueryable()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Department> FilterDepartmentsPaginatedQueryable(StudentOrderingEnum orderingEnum, string search)
        {
            throw new NotImplementedException();
        }

        #region GetByIdAsync
        public async Task<Department?> GetByIdAsync(Guid id)
        {
            return await _departmentRepository.GetByIdAsync(id);
        }
        #endregion

        #region GetDepartmentByIdWithIncludeAsync
        public async Task<Department?> GetDepartmentByIdWithIncludeAsync(Guid Id)
        {
            var dept = await _departmentRepository.GetTableNoTracking()
                                .Where(d => d.Id == Id)
                                .Include(ds => ds.DepartmentSubjects).ThenInclude(s => s.Subject)
                                .Include(ins => ins.Instructors)
                                .Include(i => i.Instructor)
                                .FirstOrDefaultAsync();
            return dept;
        }
        #endregion


        public Task<string> AddDepartmentAsync(Department department)
        {
            throw new NotImplementedException();
        }

        public Task<string> EditDepartmentAsync(Department department)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteDepartmentAsync(Department department)
        {
            throw new NotImplementedException();
        }



        public Task<bool> IsNameArExist(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsNameArExistExcludeSelf(string name, Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsNameEnExist(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsNameEnExistExcludeSelf(string name, Guid id)
        {
            throw new NotImplementedException();
        }


    }
}
