﻿namespace SchoolProject.Core.Features.Staff.Queries.DTOs
{
    public class GetStaffDetailsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Position { get; set; }
    }
}
