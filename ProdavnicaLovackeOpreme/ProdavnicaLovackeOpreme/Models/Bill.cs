using System;
using System.Collections.Generic;

namespace ProdavnicaLovackeOpreme.Models;

public partial class Bill
{
    public int BillId { get; set; }

    public int? ReportReportId { get; set; }

    public int UserUserId { get; set; }

    public DateOnly Date { get; set; }

    public virtual ICollection<BillItem> BillItems { get; set; } = new List<BillItem>();

    public virtual Report? ReportReport { get; set; }

    public virtual User UserUser { get; set; } = null!;
}
