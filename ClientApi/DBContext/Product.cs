using System;
using System.Collections.Generic;

namespace ClientApi.DBContext;

public partial class Product
{
    public int Id { get; set; }

    public int TypeId { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string Details { get; set; } = null!;

    public bool Deleted { get; set; }

    public DateTimeOffset CreatedDate { get; set; }

    public DateTimeOffset ModifiedDate { get; set; }

    public DateTimeOffset? DeletedDate { get; set; }

    public int? DeletedBy { get; set; }

    public int? ModifiedBy { get; set; }

    public int? CreatedBy { get; set; }

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    public virtual ProductType Type { get; set; } = null!;
}
