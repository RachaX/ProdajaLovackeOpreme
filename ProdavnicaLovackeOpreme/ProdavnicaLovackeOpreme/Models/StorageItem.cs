using System;
using System.Collections.Generic;

namespace ProdavnicaLovackeOpreme.Models;

public partial class StorageItem
{
    public int ProductProductId { get; set; }

    public int StorageStorageId { get; set; }

    public int Quantity { get; set; }

    public virtual Product ProductProduct { get; set; } = null!;

    public virtual Storage StorageStorage { get; set; } = null!;
}
