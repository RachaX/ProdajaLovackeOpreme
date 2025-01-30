using System;
using System.Collections.Generic;

namespace ProdavnicaLovackeOpreme.Models;

public partial class Storage
{
    public int StorageId { get; set; }

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public virtual ICollection<StorageItem> StorageItems { get; set; } = new List<StorageItem>();
}
