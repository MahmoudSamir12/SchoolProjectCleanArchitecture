using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Helpers;
using SchoolProject.Infrastructure.IRepositories;
using SchoolProject.Service.IServices;

namespace SchoolProject.Service.Services.Abstractions
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        #region GetAllStudentsAsync
        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllStudentsAsync();
        }
        #endregion

        #region GetAllStudentsQueryable
        public IQueryable<Student> GetAllStudentsQueryable()
        {
            return _studentRepository.GetTableNoTracking()
                                            .Include(dept => dept.Department)
                                            .Include(par => par.Parent)
                                            .AsQueryable();
        }
        #endregion

        #region FilterStudentsPaginatedQueryable
        public IQueryable<Student> FilterStudentsPaginatedQueryable(StudentOrderingEnum orderingEnum, string search)
        {
            var queryable = _studentRepository.GetTableNoTracking()
                                            .Include(dept => dept.Department)
                                            .Include(par => par.Parent)
                                            .AsQueryable();
            if (search != null)
            {
                queryable = queryable.Where(x => x.NameAr.Contains(search) || x.Department.DepartmentNameAr.Contains(search));
            }

            switch (orderingEnum)
            {
                case StudentOrderingEnum.Id:
                    queryable = queryable.OrderBy(s => s.Id);
                    break;

                case StudentOrderingEnum.Name:
                    queryable = queryable.OrderBy(s => s.NameAr);
                    break;

                case StudentOrderingEnum.Address:
                    queryable = queryable.OrderBy(s => s.Address);
                    break;

                case StudentOrderingEnum.DepartmentName:
                    queryable = queryable.OrderBy(s => s.Department.DepartmentNameAr);
                    break;

                default:
                    queryable = queryable.OrderBy(s => s.Id);
                    break;
            }

            return queryable;
        }
        #endregion


        #region GetStudentByIdWithIncludeAsync
        public async Task<Student?> GetStudentByIdWithIncludeAsync(Guid id)
        {
            //return await _studentRepository.GetByIdAsync(id);
            var student = await _studentRepository.GetTableNoTracking()
                                            .Include(dept => dept.Department)
                                            .Include(par => par.Parent)
                                            .Include(enr => enr.Enrollments)
                                            .Where(std => std.Id == id)
                                            .FirstOrDefaultAsync();
            return student;
        }
        #endregion

        #region GetByIdAsync
        public async Task<Student?> GetByIdAsync(Guid id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }
        #endregion

        #region GetStudentsByDepartmentIdQueryable
        public IQueryable<Student> GetStudentsByDepartmentIdQueryable(Guid id)
        {
            return _studentRepository.GetTableNoTracking()
                                        .Where(x => x.Id.Equals(id))
                                        .AsQueryable();
        }
        #endregion

        #region AddStudentAsync
        public async Task<string> AddStudentAsync(Student student)
        {
            await _studentRepository.AddAsync(student);

            return "Success";
        }


        #endregion

        #region IsNameArExist
        public async Task<bool> IsNameArExist(string name)
        {
            var student = await _studentRepository.GetTableNoTracking()
                                            .Where(std => std.NameAr.Equals(name))
                                            .FirstOrDefaultAsync();

            if (student == null) return false;
            return true;
        }
        #endregion

        #region IsNameEnExist
        public async Task<bool> IsNameEnExist(string name)
        {
            var student = await _studentRepository.GetTableNoTracking()
                                            .Where(std => std.NameEn.Equals(name))
                                            .FirstOrDefaultAsync();

            if (student == null) return false;
            return true;
        }
        #endregion

        #region IsNameArExistExcludeSelf
        public async Task<bool> IsNameArExistExcludeSelf(string name, Guid id)
        {
            var student = await _studentRepository.GetTableNoTracking()
                                    .Where(std => std.NameAr.Equals(name) & !std.Id.Equals(id))
                                    .FirstOrDefaultAsync();

            if (student == null) return false;
            return true;
        }
        #endregion

        #region IsNameEnExistExcludeSelf
        public async Task<bool> IsNameEnExistExcludeSelf(string name, Guid id)
        {
            var student = await _studentRepository.GetTableNoTracking()
                                    .Where(std => std.NameEn.Equals(name) & !std.Id.Equals(id))
                                    .FirstOrDefaultAsync();

            if (student == null) return false;
            return true;
        }
        #endregion

        #region Edit Student
        public async Task<string> EditStudentAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
            return "Success";
        }
        #endregion

        #region Delete Student
        public async Task<string> DeleteStudentAsync(Student student)
        {
            var trans = _studentRepository.BeginTransaction();
            try
            {
                await _studentRepository.DeleteAsync(student);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }

        #endregion


    }
}
