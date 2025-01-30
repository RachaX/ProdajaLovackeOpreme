using System;
using System.Collections.Generic;

namespace ProdavnicaLovackeOpreme.Models;

public partial class Report
{
    public int ReportId { get; set; }

    public DateOnly Date { get; set; }

    public int UserUserId { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    public virtual User UserUser { get; set; } = null!;
}
