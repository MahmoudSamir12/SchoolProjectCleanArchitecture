namespace SchoolProject.Core.Features.Parent.Queries.DTOs
{
    public class GetParentDetailsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
