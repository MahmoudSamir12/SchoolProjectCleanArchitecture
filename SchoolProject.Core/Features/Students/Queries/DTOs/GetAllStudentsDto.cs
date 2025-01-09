using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Queries.DTOs
{
    public class GetAllStudentsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        //public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        //public Guid ParentId { get; set; }
        public string ParentName { get; set; } = string.Empty;
    }
}
