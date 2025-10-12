using System;
using System.Collections.Generic;

namespace Administration.Domain.Entities;

public partial class Jamathmember
{
    public int Id { get; set; }

    public int JamathId { get; set; }

    public Guid MemberId { get; set; }

    public bool? IsActive { get; set; }

    public bool IsSuspend { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime ModifiedDate { get; set; }
}
