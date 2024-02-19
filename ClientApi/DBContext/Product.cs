using System;
using System.Collections.Generic;

namespace ClientApi.DBContext;

public partial class Product
{
    public int Id { get; set; }

    public int TypeId { get; set; }

    public int? CategoryId { get; set; }

    public int? DesignerId { get; set; }

    public int? EditId { get; set; }

    public string Name { get; set; } = null!;

    public string? Price { get; set; }

    public string Size { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public string Color { get; set; } = null!;

    public string Condition { get; set; } = null!;

    public string? SellPrice { get; set; }

    public string? RentPrice4Days { get; set; }

    public string? RentPrice8Days { get; set; }

    public string? RentPrice16Days { get; set; }

    public string? RentPrice30Days { get; set; }

    public string Rrp { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string Details { get; set; } = null!;

    public bool IsEbayStore { get; set; }

    public bool Deleted { get; set; }

    public bool? IsAvailable { get; set; }

    public DateTimeOffset CreatedDate { get; set; }

    public DateTimeOffset ModifiedDate { get; set; }

    public DateTimeOffset? DeletedDate { get; set; }

    public int? DeletedBy { get; set; }

    public int? ModifiedBy { get; set; }

    public int? CreatedBy { get; set; }

    public virtual ICollection<CartProduct> CartProducts { get; set; } = new List<CartProduct>();

    public virtual ProductCategory? Category { get; set; }

    public virtual ProductDesigner? Designer { get; set; }

    public virtual ProductEdit? Edit { get; set; }

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    public virtual ProductType Type { get; set; } = null!;

    public virtual ICollection<WishListProduct> WishListProducts { get; set; } = new List<WishListProduct>();
}
