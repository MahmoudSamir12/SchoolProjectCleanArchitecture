namespace SchoolProject.Core.Features.Users.Queries.DTOs
{
    public class GetUserByIdDto
    {
        public GetUserByIdDto()
        {
            FullName = string.Empty;
            Email = string.Empty;
        }
        public GetUserByIdDto(string FName, string email)
        {
            FullName = FName;
            Email = email;
        }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }
}
