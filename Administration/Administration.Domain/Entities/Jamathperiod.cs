using System;
using System.Collections.Generic;

namespace Administration.Infrastructure;

public partial class Jamathperiod
{
    public int Id { get; set; }

    public DateTime FromDate { get; set; }

    public DateTime ToDate { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime ModifiedDate { get; set; }
}
