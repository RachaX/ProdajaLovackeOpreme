using System;
using System.Collections.Generic;

namespace ProdavnicaLovackeOpreme.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string CategoryCategoryName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public byte[] Image { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int UserUserId { get; set; }

    public virtual ICollection<BillItem> BillItems { get; set; } = new List<BillItem>();

    public virtual Category CategoryCategoryNameNavigation { get; set; } = null!;

    public virtual ICollection<OfferItem> OfferItems { get; set; } = new List<OfferItem>();

    public virtual ICollection<StorageItem> StorageItems { get; set; } = new List<StorageItem>();

    public virtual User UserUser { get; set; } = null!;
}
