using System;
using System.Collections.Generic;

namespace ProdavnicaLovackeOpreme.Models;

public partial class OfferItem
{
    public int OfferOfferId { get; set; }

    public int ProductProductId { get; set; }

    public int Quantity { get; set; }

    public virtual Offer OfferOffer { get; set; } = null!;

    public virtual Product ProductProduct { get; set; } = null!;
}
