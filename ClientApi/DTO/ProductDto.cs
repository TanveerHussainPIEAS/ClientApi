using ClientApi.DBContext;

namespace ClientApi.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }

        public int TypeId { get; set; }

        public string Name { get; set; } = null!;

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

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset ModifiedDate { get; set; }

        public DateTimeOffset? DeletedDate { get; set; }

        public int? DeletedBy { get; set; }

        public int? ModifiedBy { get; set; }

        public int? CreatedBy { get; set; }

        public List<ProductImageDto> ProductImages { get; set; }

    }

}
