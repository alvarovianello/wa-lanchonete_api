using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string? Cellphone { get; set; }

    public string? Email { get; set; }

    public DateTime? Birthdate { get; set; }
}
