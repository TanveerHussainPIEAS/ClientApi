using ClientApi.DBContext;

namespace ClientApi.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }

        public int TypeId { get; set; }

        public int? CategoryId { get; set; }
        public int? ProductGenCategoryId { get; set; }

        public int? DesignerId { get; set; }
        public int? EditId { get; set; }

        public string Name { get; set; } = null!;

        public string Size { get; set; } = null!;

        public string Brand { get; set; } = null!;
        public bool? IsAvailable { get; set; }

        public string Color { get; set; } = null!;
        public string? InternationalSize { get; set; }

        public string Condition { get; set; } = null!;

        public string? SellPrice { get; set; }
        public string? Price { get; set; }

        public string? RentPrice4Days { get; set; }

        public string? RentPrice8Days { get; set; }

        public string? RentPrice16Days { get; set; }

        public string? RentPrice30Days { get; set; }

        public string Rrp { get; set; } = null!;

        public string Code { get; set; } = null!;

        public string Details { get; set; } = null!;

        public bool IsEbayStore { get; set; }

        public int? DeletedBy { get; set; }

        public int? ModifiedBy { get; set; }

        public int? CreatedBy { get; set; }

        public  ICollection<ProductImageDto> ProductImages { get; set; } 

    }

}
