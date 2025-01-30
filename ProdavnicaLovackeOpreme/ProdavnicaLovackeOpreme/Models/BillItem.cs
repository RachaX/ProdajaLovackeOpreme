using System;
using System.Collections.Generic;

namespace ProdavnicaLovackeOpreme.Models;

public partial class BillItem
{
    public int Quantity { get; set; }

    public int BillBillId { get; set; }

    public int ProductProductId { get; set; }

    public virtual Bill BillBill { get; set; } = null!;

    public virtual Product ProductProduct { get; set; } = null!;
}
