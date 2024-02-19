using System;
using System.Collections.Generic;

namespace ClientApi.DBContext;

public partial class WishListProduct
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int? UserId { get; set; }

    public bool Deleted { get; set; }

    public DateTimeOffset CreatedDate { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User? User { get; set; }
}
