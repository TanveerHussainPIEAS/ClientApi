using System;
using System.Collections.Generic;

namespace ClientApi.DBContext;

public partial class ProductImage
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string? Name { get; set; }

    public string? Url { get; set; }

    public string? Details { get; set; }

    public bool Deleted { get; set; }

    public DateTimeOffset CreatedDate { get; set; }

    public DateTimeOffset ModifiedDate { get; set; }

    public DateTimeOffset? DeletedDate { get; set; }

    public int? DeletedBy { get; set; }

    public int? ModifiedBy { get; set; }

    public int? CreatedBy { get; set; }

    public virtual Product Product { get; set; } = null!;
}
