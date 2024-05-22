using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int IdCategory { get; set; }

    public decimal Price { get; set; }

    public string? Description { get; set; }

    public byte[]? Image { get; set; }

    public virtual Category IdCategoryNavigation { get; set; } = null!;
}
