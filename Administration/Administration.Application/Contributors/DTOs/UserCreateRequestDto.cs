using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Administration.Domain.DTOs
{
    public class UserCreateRequestDto
    {
        [Required, MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? FatherId { get; set; }
        public string? FatherName { get; set; }

        [MaxLength(50)] 
        public string? FamilyName { get; set; }
        public string Gender { get; set; } = "Male";


        [Required, DataType(DataType.Date)]
        public DateTime DOB { get; set; } 

        [Required, MaxLength(250)]
        public string Address { get; set; } = string.Empty;

        [MaxLength(250)]
        public string? MotherName { get; set; }

        public string? BloodGroup { get; set; }

        [Required, Phone]
        public string ContactNumber { get; set; } = string.Empty;
        public bool IsAlive { get; set; } = true;
        public bool IsMarried { get; set; } = false;
        public bool IsDismissed { get; set; } = false;

        public IFormFile? Photo { get; set; } = null;
    }
}
