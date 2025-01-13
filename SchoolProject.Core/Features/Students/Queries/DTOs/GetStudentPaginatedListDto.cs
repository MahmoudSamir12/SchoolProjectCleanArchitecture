namespace SchoolProject.Core.Features.Students.Queries.DTOs
{
    public class GetStudentPaginatedListDto
    {
        public GetStudentPaginatedListDto(Guid id, string name, string email, string address,
                string phone, DateTime dateOfBirth, string departmentName)
        {
            Id = id;
            Name = name;
            Email = email;
            Address = address;
            Phone = phone;
            DateOfBirth = dateOfBirth;
            DepartmentName = departmentName;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        //public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }

    }
}
