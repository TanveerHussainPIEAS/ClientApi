using System;
using System.Collections.Generic;

namespace ClientApi.DBContext;

public partial class Country
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? CountryCode { get; set; }

    public string? Lat { get; set; }

    public string? Lang { get; set; }

    public bool Deleted { get; set; }
}
