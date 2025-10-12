using System;
using System.Collections.Generic;

namespace Administration.Infrastructure;

public partial class Jamathperiod
{
    public int Id { get; set; }

    public DateOnly FromDate { get; set; }

    public DateOnly ToDate { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime ModifiedDate { get; set; }
}
