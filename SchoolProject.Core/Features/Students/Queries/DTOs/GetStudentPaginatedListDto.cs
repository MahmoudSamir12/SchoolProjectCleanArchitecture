namespace SchoolProject.Core.Features.Students.Queries.DTOs
{
    public class GetStudentPaginatedListDto
    {
        public GetStudentPaginatedListDto(Guid id, string name, string email, string address,
                string phone, DateTime dateOfBirth, string departmentName, string parentName)
        {
            Id = id;
            Name = name;
            Email = email;
            Address = address;
            Phone = phone;
            DateOfBirth = dateOfBirth;
            DepartmentName = departmentName;
            ParentName = parentName;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        //public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        //public Guid ParentId { get; set; }
        public string ParentName { get; set; }
    }
}
