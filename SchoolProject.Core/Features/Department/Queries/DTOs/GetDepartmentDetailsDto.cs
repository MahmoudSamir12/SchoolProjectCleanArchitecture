using SchoolProject.Core.Wrappers;

namespace SchoolProject.Core.Features.Department.Queries.DTOs
{
    public class GetDepartmentDetailsDto
    {
        public Guid Id { get; set; }
        public string? DepartmentName { get; set; }
        public string? ManagerName { get; set; }
        public PaginatedResult<StudentResponse>? StudentList { get; set; }
        //public List<StudentResponse>? StudentList { get; set; }
        public List<SubjectResponse>? SubjectList { get; set; }
        public List<InstructorResponse>? InstructorList { get; set; }

    }
    public class StudentResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public StudentResponse(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

    }

    public class SubjectResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }

    public class InstructorResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}
