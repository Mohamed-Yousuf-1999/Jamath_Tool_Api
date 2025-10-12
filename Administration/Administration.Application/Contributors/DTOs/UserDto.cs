using Microsoft.AspNetCore.Http;

namespace Administration.Application.Contributors.DTOs
{
    public record UserDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string FatherName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Contact { get; set; } = string.Empty;
        public string Gender { get; set; } = "Male";
        public DateTime DOB { get; set; } 
        public int Age { get; set; }
        public string? PhotoPath { get; set; } = string.Empty;
    }
}
