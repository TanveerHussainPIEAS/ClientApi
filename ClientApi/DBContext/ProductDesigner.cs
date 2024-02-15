﻿using System;
using System.Collections.Generic;

namespace ClientApi.DBContext;

public partial class ProductDesigner
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Detail { get; set; }

    public bool? Deleted { get; set; }

    public DateTimeOffset? CreatedDate { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public DateTimeOffset? DeletedDate { get; set; }

    public int? DeletedBy { get; set; }

    public int? ModifiedBy { get; set; }

    public int? CreatedBy { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
