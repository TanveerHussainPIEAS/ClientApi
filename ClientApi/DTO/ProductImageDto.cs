using ClientApi.DBContext;

namespace ClientApi.DTO
{    
    public class ProductImageDto
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string? Name { get; set; }

        public string Url { get; set; } = null!;

        public string? Details { get; set; }

        public bool Deleted { get; set; }

        public DateTimeOffset? CreatedDate { get; set; }

        public DateTimeOffset? ModifiedDate { get; set; }

        public DateTimeOffset? DeletedDate { get; set; }

        public int? DeletedBy { get; set; }

        public int? ModifiedBy { get; set; }

        public int? CreatedBy { get; set; }
    }
}
