using System;
using System.Collections.Generic;

namespace ProdavnicaLovackeOpreme.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Type { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? CompanyName { get; set; }

    public string? Jib { get; set; }

    public string Font { get; set; } = null!;

    public sbyte Theme { get; set; }

    public sbyte Mode { get; set; }

    public sbyte Logged { get; set; }

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
}
