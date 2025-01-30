using System;
using System.Collections.Generic;

namespace ProdavnicaLovackeOpreme.Models;

public partial class Offer
{
    public int OfferId { get; set; }

    public int UserUserId { get; set; }

    public sbyte Accepted { get; set; }

    public virtual ICollection<OfferItem> OfferItems { get; set; } = new List<OfferItem>();

    public virtual User UserUser { get; set; } = null!;
}
