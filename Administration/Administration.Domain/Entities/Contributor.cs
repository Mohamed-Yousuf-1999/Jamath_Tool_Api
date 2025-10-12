using System;
using System.Collections.Generic;

namespace Administration.Infrastructure;

public partial class Contributor
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid? FatherId { get; set; }

    public string? FatherName { get; set; }

    public DateOnly? Dob { get; set; }

    public string? ContactNumber { get; set; }

    public string? FamilyName { get; set; }

    public string? MotherName { get; set; }

    public string? Address { get; set; }

    public string? BloodGroup { get; set; }

    public bool? IsAlive { get; set; }

    public bool IsDismissed { get; set; }

    public bool IsMarried { get; set; }

    public string? Gender { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime ModifiedDate { get; set; }
}
